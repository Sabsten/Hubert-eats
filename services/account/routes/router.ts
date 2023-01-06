import express from 'express';
import restaurantsRouter from './restaurants';
import { AuthController } from '../controllers/auth';

const authController = new AuthController();

const routes = express.Router();
routes.use('/restaurants', restaurantsRouter);

routes.post('/signin', authController.signIn);
routes.post('/signup', authController.signUp);


export default routes;