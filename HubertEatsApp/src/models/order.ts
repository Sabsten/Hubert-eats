import type { IAddress } from "./IAddress";
import type { IArticleCart } from "./cart";

export interface IOrders {
    _id?: string;
    customer_id: string;
    restaurant_id: string;
    courier_id?: string;
    customer_address: IAddress;
    restaurant_address: IAddress;
    articles : [IArticleCart];
    price : number;
    status: string;
}

export enum OrderStatus {
    paid = "paid",
    in_preparation = "in_preparation",
    to_retrieve = "to_retrieve",
    in_delivery = "in_delivery",
    delivered = "delivered",
    refused = "refused"
  }