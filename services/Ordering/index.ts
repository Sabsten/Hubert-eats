import express, { Express, Request, Response, json } from 'express';
import dotenv from 'dotenv';
import routes from "./routes/router";
import { db } from "./config/db";
import { Server } from 'socket.io';
import morgan from "morgan";
import cors from "cors";
import http from "http";

dotenv.config();

const app: Express = express();
const port = 3003;
const database = new db()
// const io = new Server({})

database.dbConnect();

app.use(morgan('tiny'));
app.use(cors());
app.use(json());
app.use(routes);

const server = http.createServer(app);
const io = new Server(server, {
  cors: {
    origin: "*",
    methods: ["GET", "POST"],
  }
});

app.set('io', io)

server.listen(4000, () => {
  console.log('socket listening on :4000');
});

app.listen(port, () => {
  console.log(`⚡️[server]: Server is running at http://localhost:${port}`);
});