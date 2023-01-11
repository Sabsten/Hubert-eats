import { Schema, model, connect, Types } from 'mongoose';
import { ObjectId } from 'mongodb';
import accountSchema, { IAccount } from './account';
import addressSchema, { IAddress } from './address';

// Create an interface representing a document in MongoDB.
export interface ICourier {
    _id?: ObjectId;
    account: IAccount;
    firstname: string;
    lastname: string;
    address: IAddress;
    balance: number;
    rating?: number[];
}

// Create a Schema corresponding to the document interface.
const courierSchema = new Schema<ICourier>({
    account: {type: accountSchema, required: true},
    firstname: {type: String, required: true},
    lastname: {type: String, required: true},
    address: {type: addressSchema, required: true},
    balance: { type: Number, required: true},
    rating: { type: Number, required: false}
}, { versionKey: false, timestamps: true });

// Create a Model.
const Courier = model<ICourier>('Courier', courierSchema);

export default Courier

/**
 * @swagger
 * components:
 *   schemas:
 *     Courier:
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
 *         balance:
 *           type: number
 *         rating:
 *           type: number
 *       example:
 *         id: 63b9d56c47fa01e5381f7bdc
 *         account: {}
 *         firstname: john
 *         lastname: doe
 *         address: {}
 *         balance: 259.99
 *         rating: 4.5
 */