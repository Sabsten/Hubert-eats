import { Schema, model, connect, Types } from 'mongoose';
import { IAddress } from './IAddress';
import { ObjectId } from 'mongodb';
import { IAccount } from './IAccount';

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
    account: {
        type: {
          mail: { type: String, required: true },
          password: { type: String, required: true },
          referent: {type: String, required: false},
        }, required: true 
      },
    firstname: {type: String, required: true},
    lastname: {type: String, required: true},
    address: { 
        type: {
        city: String,
        street_name: String,
        street_number: Number,
        postal_code: Number,
        country: String
        }, required: true
  }
}, { versionKey: false, timestamps: true });

// Create a Model.
const Customer = model<IAccount>('Customer', customerSchema);

export default Customer