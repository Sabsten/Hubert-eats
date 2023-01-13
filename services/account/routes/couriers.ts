import express from "express";
import { CouriersController } from "../controllers/couriers";
import { courierAccess } from "../middlewares/auth";

const couriersController = new CouriersController();
const couriersRouter = express.Router();

couriersRouter.get('/:id', couriersController.getCourierById);
couriersRouter.get('/account/:id', courierAccess, couriersController.getCourierAccountById);
couriersRouter.patch('/account/:id', courierAccess, couriersController.updateCourierAccount)

export default couriersRouter;