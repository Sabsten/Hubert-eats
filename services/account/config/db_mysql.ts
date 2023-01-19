import mysql from "mysql2/promise";

export class dbMysql {
    private static connection = mysql.createConnection({
        host: "db4free.net",
        user: "hubert",
        password: "cesihubert",
        database: "huberteats",
    });

    public static getConnection() {
        return this.connection;
    }
}