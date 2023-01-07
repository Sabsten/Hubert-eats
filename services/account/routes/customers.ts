import express from "express";
import { CustomersController } from "../controllers/customers";

const customersController = new CustomersController();
const customersRouter = express.Router();

customersRouter.get('/', customersController.getCustomers);

export default customersRouter;