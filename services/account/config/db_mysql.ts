import mysql from "mysql2";

export class dbMysql {

    private connection = mysql.createConnection({
        host: "db4free.net",
        user: "hubert",
        password: "cesihubert",
        database: "huberteats"
    });
    static connection: mysql.Connection;
}