import type { IAccount } from './IAccount';
import type { IAddress} from './IAddress';

export interface ICourier {
    _id: string;
    account: IAccount;
    firstname: string;
    lastname: string;
    address: IAddress;
    balance: number;
    rating?: number[];
}

export interface ICourierForm {
    mail?: string;
    firstname?: string;
    lastname?: string;
    city?: string,
    street_name?: string,
    street_number?: number,
    postal_code?: number,
}