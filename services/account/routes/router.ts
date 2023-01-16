import express from 'express';
import { AuthController } from '../controllers/auth';
import restaurantsRouter from './restaurants';
import customersRouter from './customers';
import couriersRouter from './couriers';
import { MySqlAuthController } from '../controllers/mysql_auth';

const authController = new AuthController();
const mysqlAuthController = new MySqlAuthController();

const routes = express.Router();

routes.use('/restaurants', restaurantsRouter);
routes.use('/customers', customersRouter);
routes.use('/couriers', couriersRouter);

/**
 * @swagger
 * 
 * components:
 *   securitySchemes:
 *     bearerAuth:
 *       type: http
 *       scheme: bearer
 *       bearerFormat: JWT
 *
 * tags:
 *   - name : authentication
 *     description : Authenticate users
 * /signin/{accountType}/:
 *   post:
 *     tags:
 *       - authentication
 *     summary: sign in to an account
 *     parameters:
 *       - in: path
 *         name: accountType
 *         schema:
 *           type: string
 *         required: true
 *     responses:
 *       '200':
 *         description: OK
 * /signup:
 *   post:
 *     tags:
 *       - authentication
 *     summary: create an account
*/
routes.post('/signin/:accountType', authController.signIn);
routes.post('/signup/:accountType', authController.signUp);

routes.post('/signin/intern', mysqlAuthController.signIn);

export default routes;