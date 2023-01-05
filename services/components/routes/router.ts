import express from 'express';
import composantRouter from './components';

const routes = express.Router();
routes.use('/components', composantRouter);

export default routes;