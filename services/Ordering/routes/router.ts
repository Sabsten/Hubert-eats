import express from 'express';
import orderRouter from './orders';
import delRouter from './deliveries';

const routes = express.Router();
routes.use('/orders', orderRouter);
routes.use('/deliveries', delRouter);

export default routes;