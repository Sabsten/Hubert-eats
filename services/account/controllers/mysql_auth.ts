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
        const rows: any = await (await connection).query(
            'SELECT role FROM InternalUserTable WHERE identifiant = ? AND password = ?',
            [identifiant, this.hashSHA256(password)],
        );

        if (rows[0][0].role.length === 0) {
            return res.status(404).json({error: "Identifiants incorrect, aucun compte n'a été trouvé"});
        }
        const accessToken = jwt.sign({identifiant: identifiant, role: rows[0][0].role}, process.env.PRIVATE_TOKEN_KEY!);
        return res.status(200).json({token: accessToken});
    };

    private hashSHA256(password: string): string {
        const sha256 = createHash('sha256');
        const passwordBytes = Buffer.from(password, 'ascii');
        const encryptedBytes = sha256.update(passwordBytes).digest();
        return encryptedBytes.toString('base64');
    }
}