import type { IAccount } from "./IAccount";
import type { IAddress } from "./IAddress";

export interface CreateForm {
    account?: IAccount,
    firstname?: string,
    lastname?: string,
    name?: string,
    address?: IAddress;
}