import express, { Express, json, Request, Response } from 'express';
import routes from "./routes/router";
import { db } from "./config/db";
import swaggerUi from 'swagger-ui-express';
import swaggerJsDoc from 'swagger-jsdoc';
import dotenv from 'dotenv'
import { dbMysql } from "./config/db.mysql";

const swaggerOptions: swaggerJsDoc.Options = {
  swaggerDefinition: {
    openapi: '3.0.0',
    info: {
      title: "Account service API",
      version: '1.0.0',
    },
  },
  apis: ["./models/*.ts","./routes/*.ts"]
};

const swaggerDocs = swaggerJsDoc(swaggerOptions);

const app: Express = express();
const port = 3000;
const database = new db()

const MysqlDatabase = new dbMysql()


MysqlDatabase.checkIfUserExists("m.galos@hubert.com","MGALOS").then((result) => {
  console.log("resultat de la requete : ",);
  console.log(result);
})

dotenv.config()
database.dbConnect();

app.use(json());
app.use(routes);
app.use('/docs', swaggerUi.serve, swaggerUi.setup(swaggerDocs));

app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});