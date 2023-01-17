import express from "express";
import { orderController } from "../controllers/orders";

const orderingController = new orderController();
const orderRouter = express.Router();
orderRouter.get('/restaurant/:id', orderingController.getRestaurantOrders);
orderRouter.get('/customer/:id', orderingController.getCustomerOrders);
orderRouter.post('/', orderingController.createOrders);
orderRouter.patch('/:id', orderingController.updateOrder)
// orderRouter.put('/:id', orderingController.modifyorders);


export default orderRouter;