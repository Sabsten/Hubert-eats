import type { IAddress } from "./IAddress";
import type { IArticleCart } from "./cart";

export interface IOrders {
    _id?: string;
    customer_id: string;
    restaurant_id: string;
    courier_id?: string;
    customer_address: IAddress;
    restaurant_address: IAddress;
    restaurant_name: String;
    articles : [IArticleCart];
    price : number;
    validation_code: number;
    status: string;
    createdAt?: Date;
}

export enum OrderStatus {
    paid = "paid",
    in_preparation = "in_preparation",
    in_delivery = "in_delivery",
    delivered = "delivered",
    refused = "refused"
  }