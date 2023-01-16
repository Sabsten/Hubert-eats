import express from "express";
import { orderController } from "../controllers/orders";

const orderingController = new orderController();
const orderRouter = express.Router();
orderRouter.get('/', orderingController.getAllorders);
orderRouter.post('/', orderingController.createOrders);
orderRouter.delete('/:id', orderingController.deleteordersById);
orderRouter.put('/:id', orderingController.modifyorders);


export default orderRouter;