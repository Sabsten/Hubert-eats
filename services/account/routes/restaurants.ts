import express from "express";
import { RestaurantsController } from "../controllers/restaurants";
import { restaurantAccess } from "../middlewares/auth";

const restaurantsController = new RestaurantsController();
const restaurantsRouter = express.Router();

restaurantsRouter.get('/', restaurantsController.getRestaurants);
restaurantsRouter.get('/:id', restaurantsController.getRestaurantById);
restaurantsRouter.get('/account/:id', restaurantAccess, restaurantsController.getRestaurantAccountById);

export default restaurantsRouter;

/**
 * @swagger
 * tags:
 *   - name : restaurants
 *     description : Operations about restaurants
 * /restaurants/:
 *   get:
 *     tags: [restaurants]
 *     summary: Retrieve all restaurants
 *
 * /restaurants/account/{id}:
 *   get:
 *     tags: [restaurants]
 *     summary: Retrieve all informations about a restaurant including account
 *     security:
 *       - bearerAuth: []
 *     parameters:
 *       - in: query
 *         name: id
 * 
 */
