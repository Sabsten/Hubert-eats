import type { IAccount } from "./IAccount";
import type { IAddress } from "./IAddress";

export interface ICustomer {
    _id: string;
    account: IAccount;
    firstname: string;
    lastname: string;
    address: IAddress;
}

export interface ICustomerForm {
    mail?: string;
    password?: string;
    firstname?: string;
    lastname?: string;
    city?: string,
    street_name?: string,
    street_number?: number,
    postal_code?: number,
}