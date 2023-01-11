import { Request, Response } from "express";
import Restaurant, { IRestaurant } from "../models/restaurant";
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
        Restaurant.find(filter , (err: CallbackError, docs: IRestaurant[]) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(docs);
        }).select({account: 0});
    };

    public getRestaurantById(req: Request, res: Response) {
        Restaurant.findById(req.params.id, (err: CallbackError, doc: IRestaurant) => {
            if (err) {
                return res.status(500).json({error: err.message});
            }
            if (!doc) {
                return res.status(404).json({error: "Account not found, check the id given in param"});
            }
            return res.status(200).json(doc);
        }).select({account: 0});
    }

    public getRestaurantAccountById(req: Request, res: Response) {
        Restaurant.findById(req.params.id, (err: CallbackError, doc: IRestaurant) => {
            if (err) {
                return res.status(500).json({error: err.message});
            }
            if (!doc) {
                return res.status(404).json({error: "Account not found, check the id given in param"});
            }
            return res.status(200).json(doc);
        });
    }
}