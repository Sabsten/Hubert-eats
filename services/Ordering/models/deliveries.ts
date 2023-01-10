import { Schema, model, connect, Types } from 'mongoose';
import { IAddress } from './IAddress';

// Create an interface representing a document in MongoDB.
interface IDeliveries {
    _id?: Types.ObjectId;
    order_id: Types.ObjectId;
    customer_id: Types.ObjectId;
    courrier_id: Types.ObjectId;
    restaurant_address : IAddress;
    customer_address: IAddress;
    status : string;  
    validation_code : Number;
   
}
// Create a Schema corresponding to the document interface.
const deliveriesSchema = new Schema<IDeliveries>({
  order_id: {  type: Schema.Types.ObjectId, required: true },
  customer_id: {  type: Schema.Types.ObjectId, required: true },
  courrier_id: {  type: Schema.Types.ObjectId, required: true },
  restaurant_address: { 
    type: {
      city: String,
      street_name: String,
      street_number: Number,
      postal_code: Number,
      country: String
    },
    required: true
  },
  customer_address: { 
    type: {
      city: String,
      street_name: String,
      street_number: Number,
      postal_code: Number,
      country: String
    },
    required: true
  },
  status: { type: String, required: true },
  validation_code: { type: Number, required: true },

  
}, { versionKey: false, timestamps: true });

// Create a Model.
const deliveries = model<IDeliveries>('components', deliveriesSchema);

export default deliveries