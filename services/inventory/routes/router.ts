import express from 'express';
import articlesRouter from './articles';
import { InventoryController } from '../controllers/inventory';

const inventoryController = new InventoryController();
const routes = express.Router();
routes.use('/articles', articlesRouter);
routes.get('/:restaurant_id', inventoryController.getInventoryByRestaurant)

export default routes;