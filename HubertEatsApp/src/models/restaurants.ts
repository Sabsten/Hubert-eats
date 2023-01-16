import type { IAccount } from "./IAccount";
import type { IAddress } from "./IAddress";

export interface IRestaurantAccount {
    _id?: string;
    account: IAccount;
    name: string;
    address: IAddress;
    image?: string;
    tags?: string[];
    rating?: number[];
}

export interface IRestaurant {
    _id: string;
    name: string;
    address: IAddress;
    image?: string;
    tags?: string[];
    rating?: number[];
}