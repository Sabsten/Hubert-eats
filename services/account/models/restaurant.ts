import { Schema, model, connect, Types } from 'mongoose';
import addressSchema, { IAddress } from './address';
import { ObjectId } from 'mongodb';
import accountSchema, { IAccount } from './account';

// Create an interface representing a document in MongoDB.
export interface IRestaurant {
    _id?: ObjectId;
    account: IAccount;
    name: string;
    address: IAddress;
    image?: string;
    tags?: string[];
    referent?: string;
    rating?: number[];
}

// Create a Schema corresponding to the document interface.
const restaurantSchema = new Schema<IRestaurant>({
  account: {type: accountSchema, required: true},
  name: { type: String, required: true },
  address: {type: addressSchema, required: true},
  image: String,
  tags: [String],
  rating: Number,
}, { versionKey: false, timestamps: true });

// Create a Model.
const Restaurant = model<IRestaurant>('Restaurant', restaurantSchema);
export default Restaurant