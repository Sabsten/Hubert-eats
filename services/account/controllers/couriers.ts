import { Request, Response } from "express";
import { CallbackError, Document } from "mongoose";
import Customer, { ICustomer } from "../models/customer";
import { ICourier } from "../models/courier";

export class CouriersController {

    // getCourierById return public informations about specified courier
    public getCourierById(req: Request, res: Response) {
        Customer.findById(req.params.id, (err: CallbackError, doc: ICourier) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(doc);
        }).select({account: 0});
    };

    // getCourierById return all informations about specified courier (protected)
    public getCourierAccountById(req: Request, res: Response) {
        Customer.findById(req.params.id, (err: CallbackError, doc: ICourier) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(doc);
        });
    };
}