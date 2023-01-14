import express, { Express, Request, Response } from 'express';
import dotenv from 'dotenv';
import routes from "./routes/router";
import { db } from "./config/db";
import morgan from "morgan";
import cors from "cors";

dotenv.config();

const app: Express = express();
const port = 3002;
const database = new db()

database.dbConnect();

app.use(morgan('tiny'));
app.use(cors());
app.use(routes);


app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});