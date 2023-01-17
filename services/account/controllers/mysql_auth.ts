import { Request, Response } from "express";
import jwt from "jsonwebtoken";
import { dbMysql} from "../config/db_mysql";
import { createHash } from 'crypto';
import IUser from "../models/intern";
import {FieldPacket, PoolConnection, RowDataPacket} from 'mysql2/promise';

export class MySqlAuthController {
    public signIn = async (req: Request, res: Response) => {
        const {identifiant, password} = req.body;
        const connection = dbMysql.getConnection();
        var rows = await (await connection).query(
            'SELECT role FROM InternalUserTable WHERE identifiant = ? AND password = ?',
            [identifiant, this.hashSHA256(password)]
        );
        if (rows[0].length === 0) {
            res.status(401).send('Invalid credentials');

        }
        console.log(rows[0]);
        const token = jwt.sign({role: rows[0].toString(), identifiant: identifiant},process.env.JWT_SECRET as string);
        res.send({token: token});
    }


    private hashSHA256(password: string): string {
        const sha256 = createHash('sha256');
        const passwordBytes = Buffer.from(password, 'ascii');
        const encryptedBytes = sha256.update(passwordBytes).digest();
        return encryptedBytes.toString('base64');
    }
}