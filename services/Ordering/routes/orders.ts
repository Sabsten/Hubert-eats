import express from "express";
import { orderController } from "../controllers/orders";

const orderingController = new orderController();
const orderRouter = express.Router();
orderRouter.get('/restaurant/:id', orderingController.getRestaurantOrders);
orderRouter.get('/customer/:id', orderingController.getCustomerOrders);
orderRouter.get('/courier/:id', orderingController.getCourierOrders);
orderRouter.post('/', orderingController.createOrders);
orderRouter.patch('/:id', orderingController.updateOrder)
orderRouter.patch('/:id/courier/:courier_id', orderingController.assignOrder)
// orderRouter.put('/:id', orderingController.modifyorders);


export default orderRouter;