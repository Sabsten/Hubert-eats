import express, { Express, Request, Response, json } from 'express';
import dotenv from 'dotenv';
import routes from "./routes/router";
import { db } from "./config/db";
import { Seeder } from './config/seed';

dotenv.config();

const app: Express = express();
const port = 3000;
const database = new db()
const seeder = new Seeder()

database.dbConnect();

//seeder.seedComponents()
app.use(json());
app.use(routes);

app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});