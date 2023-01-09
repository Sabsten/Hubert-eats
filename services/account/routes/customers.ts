import express from "express";
import { CustomersController } from "../controllers/customers";
import { customerAccess } from "../middlewares/auth";

const customersController = new CustomersController();
const customersRouter = express.Router();

customersRouter.get('/', customersController.getCustomers);
customersRouter.get('/:id', customersController.getCustomersById);
customersRouter.get('/account/:id', customerAccess, customersController.getCustomersAccountById);

export default customersRouter;

/**
 * @swagger
 * tags:
 *   - name : customers
 *     description : Operations about customers
 * 
 * /customers/account/{id}:
 *   get:
 *     tags: [customers]
 *     summary: Retrieve all informations about a customer including account
 *     security:
 *       - bearerAuth: []
 *     parameters:
 *       - in: path
 *         name: id
 *     responses:
 *       200:
 *         description: OK
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Customer'
 *       404:
 *         description: Account not found, check the id given in param
 *       500:
 *         description: Unexpected error
 */