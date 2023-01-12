import mysql from "mysql2";
import { createHash } from 'crypto';

export class dbMysql {
    private connection = mysql.createConnection({
        host: "db4free.net",
        user: "hubert",
        password: "cesihubert",
        database: "huberteats"
    });


    public async checkIfUserExists(username: string, password: string) {
        return new Promise((resolve, reject) => {
            this.connection.execute(
                `SELECT identifiant, password, role FROM InternalUserTable WHERE identifiant = ?`,
                [username],
                (err, results) => {
                    if (err) {
                        reject(err);
                    } else {
                        if (this.hashSHA256(password) === results[0].password) {
                            resolve(true);
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