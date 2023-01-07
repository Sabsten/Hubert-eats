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