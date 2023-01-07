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