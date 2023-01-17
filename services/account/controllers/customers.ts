import { Request, Response } from "express";
import { CallbackError, Document } from "mongoose";
import Customer, { ICustomer } from "../models/customer";
import { ObjectId } from "mongodb";

export class CustomersController {

    public getCustomers(req: Request, res: Response) {
        Customer.find({},(err: CallbackError, docs: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(docs);
        }).select({account: 0});
    };

    public getCustomersById(req: Request, res: Response) {
        Customer.findById(req.params.id, (err: CallbackError, doc: ICustomer) => {
            if (err) {
                return res.status(500).json({error: err.message});
            }
            if (!doc) {
                return res.status(404).json({error: "Account not found, check the id given in param"});
            }
            return res.status(200).json(doc);
        }).select({account: 0});
    };

    public getCustomersAccountById(req: Request, res: Response) {
        Customer.findById(req.params.id, (err: CallbackError, doc: ICustomer) => {
            if (err) {
                return res.status(500).json({error: err.message});
            }
            if (!doc) {
                return res.status(404).json({error: "Account not found, check the id given in param"});
            }
            return res.status(200).json(doc);
        });
    };

    public updateCustomerAccount(req: Request, res: Response) {
        Customer.findByIdAndUpdate(req.params.id, {
            'account.mail': req.body.mail,
            'account.password': req.body.password,
            firstname: req.body.firstname,
            lastname: req.body.lastname,
            'address.city': req.body.city,
            'address.street_name': req.body.street_name,
            'address.street_number': req.body.street_number,
            'address.postal_code': req.body.postal_code,
        }, (err: CallbackError, doc: ICustomer) => {
            return err ?
            res.status(500).send(err) :
            res.status(200).send(doc);
        });
    };

}