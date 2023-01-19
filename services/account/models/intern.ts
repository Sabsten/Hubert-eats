import accountSchema, { IAccount } from './account';

export interface IUser {
    name: string,
    password: string,
    role: string,
}

export default IUser

/**
 * @swagger
 * components:
 *   schemas:
 *     Customer:
 *       type: object
 *       properties:
 *         _id:
 *           type: string
 *         account:
 *           type: object
 *           $ref: '#/components/schemas/Account'
 *         firstname:
 *           type: string
 *         lastname:
 *           type: string
 *         address:
 *           type: object
 *           $ref: '#/components/schemas/Address'
 *       example:
 *         id: 63b9d56c47fa01e5381f7bdc
 *         account: {}
 *         firstname: paul
 *         lastname: calimache
 *         address: {}
 */