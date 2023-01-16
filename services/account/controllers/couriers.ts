import { Request, Response } from "express";
import { CallbackError, Document } from "mongoose";
import Courier, { ICourier } from "../models/courier";

export class CouriersController {

    // getCourierById return public informations about specified courier
    public getCourierById(req: Request, res: Response) {
        Courier.findById(req.params.id, (err: CallbackError, doc: ICourier) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(doc);
        }).select({account: 0});
    };

    // getCourierById return all informations about specified courier (protected)
    public getCourierAccountById(req: Request, res: Response) {
        Courier.findById(req.params.id, (err: CallbackError, doc: ICourier) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(doc);
        });
    };

    public updateCourierAccount(req: Request, res: Response) {
        console.log("test");
        Courier.findByIdAndUpdate(req.params.id, {
            'account.mail': req.body.mail,
            firstname: req.body.firstname,
            lastname: req.body.lastname,
            'address.city': req.body.city,
            'address.street_name': req.body.street_name,
            'address.street_number': req.body.street_number,
            'address.postal_code': req.body.postal_code,
        }, (err: CallbackError, doc: ICourier) => {
            return err ?
            res.status(500).send(err) :
            res.status(200).send(doc);
        });
    };
}