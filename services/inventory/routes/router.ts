import express from 'express';
import articlesRouter from './articles';

const routes = express.Router();
routes.use('/articles', articlesRouter);

export default routes;