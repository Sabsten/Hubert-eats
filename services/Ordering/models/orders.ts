import { Double } from 'mongodb';
import { Schema, model, connect, Types } from 'mongoose';
import { IArticles } from './articles';
import { IAddress } from './IAddress';
import { IMenu } from './menu';

// Create an interface representing a document in MongoDB.
interface IOrders {
    _id?: Types.ObjectId;
    customer_id: Types.ObjectId;
    restaurant_id: Types.ObjectId;
    restaurant_address: IAddress;
    menu : IMenu;
    articles : IArticles;
    price : number;
    status: string;
   
  
   
}
// Create a Schema corresponding to the document interface.
const ordersSchema = new Schema<IOrders>({
  customer_id: {  type: Schema.Types.ObjectId, required: true },
  restaurant_id: {  type: Schema.Types.ObjectId, required: true },
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
  menu: { 
    type: {
      restaurant_id : Types.ObjectId,
      composition_id : Types.ObjectId,
      article: {
       restaurant_id : Types.ObjectId,
       description : String,
       name : String,
       quantity : Number,
       type : String,
       price : Number
      }
    },
  },
  articles: { 
    type: {
    restaurant_id : Types.ObjectId,
    description : String,
    name : String,
    quantity : Number,
    type : String,
    price : Number
    },
    
  },

  price: { type: Number, required: true },
  status: { type: String, required: true },

  
}, { versionKey: false, timestamps: true });

// Create a Model.
const orders= model<IOrders>('orders', ordersSchema);

export default orders

