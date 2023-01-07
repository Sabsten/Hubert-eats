import express from 'express';
import restaurantsRouter from './restaurants';
import customersRouter from './customers';
import { AuthController } from '../controllers/auth';

const authController = new AuthController();

const routes = express.Router();

routes.use('/restaurants', restaurantsRouter);
routes.use('/customers', customersRouter);

/**
 * @swagger
 * tags:
 *   - name : authentication
 *     description :
 * /signin:
 *   post:
 *     tags:
 *       - authentication
 *     summary: sign in to an account
 * /signup:
 *   post:
 *     tags:
 *       - authentication
 *     summary: create an account
 */
routes.post('/signin', authController.signIn);
routes.post('/signup', authController.signUp);


export default routes;