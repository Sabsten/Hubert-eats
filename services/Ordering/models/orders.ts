import { Double } from 'mongodb';
import { Schema, model, connect, Types } from 'mongoose';
import { IArticleCart, articleCartSchema } from './articles';
import addressSchema, { IAddress } from './IAddress';
import { IMenu } from './menu';

// Create an interface representing a document in MongoDB.
export interface IOrders {
    _id?: Types.ObjectId;
    customer_id: Types.ObjectId;
    restaurant_id: Types.ObjectId;
    courier_id?: Types.ObjectId;
    customer_address: IAddress;
    restaurant_address: IAddress;
    restaurant_name: String;
    articles : [IArticleCart];
    price : number;
    validation_code: number; 
    status: string;
}

export enum OrderStatus {
  paid = "paid",
  in_preparation = "in_preparation",
  in_delivery = "in_delivery",
  delivered = "delivered",
  refused = "refused"
}

// Create a Schema corresponding to the document interface.
const ordersSchema = new Schema<IOrders>({
  customer_id: {  type: Schema.Types.ObjectId, required: true },
  restaurant_id: {  type: Schema.Types.ObjectId, required: true },
  courier_id: {  type: Schema.Types.ObjectId, required: false },
  customer_address: { type: addressSchema , required: true},
  restaurant_address: { type: addressSchema , required: true},
  restaurant_name: { type: String, required: true},
  articles: { type: [articleCartSchema], required: true},
  price: { type: Number, required: true },
  validation_code: {type: Number, required: true},
  status: { type: String, required: true },
}, { versionKey: false, timestamps: true });

// Create a Model.
const orders= model<IOrders>('orders', ordersSchema);

export default orders

