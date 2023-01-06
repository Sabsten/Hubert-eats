import { Request, Response } from "express";
import Restaurant from "../models/restaurant";
import { CallbackError, Document } from "mongoose";

export class RestaurantsController {

    public getRestaurants(req: Request, res: Response) {
        let filter = {};
        if (req.query.name) {
            filter = {name: { $regex: req.query.name , $options: 'i' }}
        } else if (req.query.tags) {
            filter = {tags: req.query.tags}
        } else if (req.query.city) {
            filter = {"address.city": req.query.city}
        }
        Restaurant.find(filter , (err: CallbackError, docs: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(docs);
        });
    };
}