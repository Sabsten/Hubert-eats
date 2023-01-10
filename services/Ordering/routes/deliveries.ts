import express from "express";
import {deliveriesController } from "../controllers/deliveries";

const deliverController = new deliveriesController();
const delRouter = express.Router();
delRouter.get('/', deliverController.getAlldeliver);
delRouter.post('/', deliverController.adddeliver);
delRouter.put('/:id', deliverController.modifydeliver);


export default delRouter;