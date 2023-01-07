import { Request, Response } from "express";
import { CallbackError, Document } from "mongoose";
import Customer, { ICustomer } from "../models/customer";

export class CustomersController {

    public getCustomers(req: Request, res: Response) {
        Customer.find({},(err: CallbackError, docs: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(docs);
        }).select({account: 0});
    };
}