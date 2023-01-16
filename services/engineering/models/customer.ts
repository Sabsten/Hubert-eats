import { Schema, model, connect, Types } from 'mongoose';
import addressSchema, { IAddress } from './address';
import { ObjectId } from 'mongodb';
import accountSchema, { IAccount } from './account';

// Create an interface representing a document in MongoDB.
export interface ICustomer {
    _id?: ObjectId;
    account: IAccount;
    firstname: string;
    lastname: string;
    address: IAddress;
}

// Create a Schema corresponding to the document interface.
const customerSchema = new Schema<ICustomer>({
    account: {type: accountSchema, required: true},
    firstname: {type: String, required: true},
    lastname: {type: String, required: true},
    address: {type: addressSchema, required: true},
}, { versionKey: false, timestamps: true });

// Create a Model.
const Customer = model<IAccount>('Customer', customerSchema);

export default Customer

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