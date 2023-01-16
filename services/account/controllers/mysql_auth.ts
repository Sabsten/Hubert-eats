import { Request, Response } from "express";
import jwt from "jsonwebtoken";
import { dbMysql} from "../config/db_mysql";
import { UserType } from "../models/enums/userType";
import { createHash } from 'crypto';
import IUser from "../models/intern";


export class MySqlAuthController {
    
    public async signIn(req: Request, res: Response) {
        this.checkIfUserExists(req.body.username, req.body.password).then((result) => {
            const accessToken = jwt.sign({username: req.body.username, role: result.role }, process.env.PRIVATE_TOKEN_KEY!)
            return res.json(accessToken);
        }).catch((err) => {
            return  "NOT FOUND"
        });
    };

    public async checkIfUserExists(username: string, password: string) {
        return new Promise<IUser>((resolve, reject) => {
            dbMysql.connection.execute(
                `SELECT identifiant, password, role FROM InternalUserTable WHERE identifiant = ?`,
                [username],
                (err, results) => {
                    if (err) {
                        reject(err);
                    } else {
                        if (this.hashSHA256(password) === results[0].password) {
                            resolve(results[0]);
                        } else {
                            reject(false);
                        }
                    }
                }
            );
        });
    }

    private hashSHA256(password: string): string {
        const sha256 = createHash('sha256');
        const passwordBytes = Buffer.from(password, 'ascii');
        const encryptedBytes = sha256.update(passwordBytes).digest();
        return encryptedBytes.toString('base64');
    }
}