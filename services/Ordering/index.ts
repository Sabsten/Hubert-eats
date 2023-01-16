import express, { Express, Request, Response, json } from 'express';
import dotenv from 'dotenv';
import routes from "./routes/router";
import { db } from "./config/db";
import { Seeder } from './config/seed';
import morgan from "morgan";
import cors from "cors";
dotenv.config();


const app: Express = express();
const port = 3003;
const database = new db()

database.dbConnect();

app.use(morgan('tiny'));
app.use(cors());
app.use(json());
app.use(routes);

app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});