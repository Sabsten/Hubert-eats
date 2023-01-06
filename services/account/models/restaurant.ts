import { Schema, model, connect, Types } from 'mongoose';
import { IAddress } from './IAddress';
import { ObjectId } from 'mongodb';

// Create an interface representing a document in MongoDB.
export interface IRestaurant {
    _id?: ObjectId;
    name: string;
    address: IAddress;
    image?: string;
    tags?: string[];
    referent?: string;
    rating?: number;
}

// Create a Schema corresponding to the document interface.
const restaurantSchema = new Schema<IRestaurant>({
  name: { type: String, required: true },
  address: { 
    type: {
      city: String,
      street_name: String,
      street_number: Number,
      postal_code: Number,
      country: String
    },
    required: true
  },
  image: String,
  tags: [String],
  referent: String,
  rating: Number,
}, { versionKey: false, timestamps: true });

// Create a Model.
const Restaurant = model<IRestaurant>('Restaurant', restaurantSchema);

export default Restaurant