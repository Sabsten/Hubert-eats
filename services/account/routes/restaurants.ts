import express from "express";
import { RestaurantsController } from "../controllers/restaurant";

const restaurantsController = new RestaurantsController();
const restaurantsRouter = express.Router();
restaurantsRouter.get('/', restaurantsController.getRestaurants);

export default restaurantsRouter;