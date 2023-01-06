import express, { Express, json, Request, Response } from 'express';
import routes from "./routes/router";
import { db } from "./config/db";
import { Seeder } from './config/seed';
import dotenv from 'dotenv/config'

const app: Express = express();
const port = 3000;
const database = new db()
const seeder = new Seeder()

dotenv
database.dbConnect();

// seeder.seedRestaurants()
// seeder.seedAccounts()
app.use(json());
app.use(routes);

app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});