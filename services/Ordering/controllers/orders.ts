import { Request, Response } from "express";
import orderSchema, {IOrders, OrderStatus} from "../models/orders";
import { CallbackError, Document } from "mongoose";
import { IArticleCart } from "../models/articles";
import { Server } from 'socket.io';

export class orderController {
    
    public async createOrders(req: Request, res: Response) {
        const test = new orderSchema<IOrders>({
            articles: req.body.articles,
            customer_id: req.body.customer_id,
            restaurant_id: req.body.restaurant_id,
            customer_address: req.body.customer_address,
            restaurant_address: req.body.restaurant_address,
            restaurant_name: req.body.restaurant_name,
            price: req.body.price,
            validation_code: Math.floor((Math.random()*9999) + 1),
            status: OrderStatus.paid,
        });
        test.save((err, doc) => {
            if (err) {
                return res.status(500).send(err);
            }
            let io: Server = req.app.get('io');
            io.emit('ORDER', doc)
            return res.status(200).send(doc);
        });
        
    };

    public getRestaurantOrders(req: Request, res: Response) {
        orderSchema.find<IOrders>({restaurant_id: req.params.id},(err: CallbackError, docs: IOrders[]) => {
         return err ?
             res.status(500).send(err) :
             res.status(200).json(docs);
        })
     };

     public getCustomerOrders(req: Request, res: Response) {
        orderSchema.find<IOrders>({customer_id: req.params.id},(err: CallbackError, docs: IOrders[]) => {
         return err ?
             res.status(500).send(err) :
             res.status(200).json(docs);
        })
     };

    public assignOrder(req: Request, res: Response) {
        orderSchema.findByIdAndUpdate<IOrders>(req.params.id, {courier_id: req.params.courier_id}, (err: ErrorCallback, doc: IOrders) => {
            if (err) {
                return res.status(500).send(err);
            } else {
                return res.status(200).json(doc);
            }
        }
    )};

    public updateOrder(req: Request, res: Response) {
        switch(req.body.status){
            case OrderStatus.in_preparation: {
                orderSchema.findByIdAndUpdate<IOrders>(req.params.id, {status: req.body.status},
                (err: ErrorCallback, doc: IOrders) => {
                    if (err) {
                        return res.status(500).send(err)
                    } else {
                        let io: Server = req.app.get('io');
                        io.emit('ORDER-'+doc._id , OrderStatus.in_preparation);
                        io.emit('NEW_ORDER', doc)
                        return res.status(200).json(doc);
                    };
                }); 
                break;
            }
            case OrderStatus.in_delivery:{
                orderSchema.findByIdAndUpdate<IOrders>(req.params.id, {status: req.body.status}, (err: ErrorCallback, doc: Document) => {
                    if (err) {
                        return res.status(500).send(err)
                    } else {
                        let io: Server = req.app.get('io');
                        io.emit('ORDER-'+doc._id , OrderStatus.in_delivery);
                        return res.status(200).json(doc);
                    };
                }); 
                break;
            }
            case OrderStatus.delivered:{
                orderSchema.findByIdAndUpdate<IOrders>(req.params.id, {status: req.body.status}, (err: ErrorCallback, doc: Document) => {
                    if (err) {
                        return res.status(500).send(err)
                    } else {
                        let io: Server = req.app.get('io');
                        io.emit('ORDER-'+doc._id , OrderStatus.delivered);
                        return res.status(200).json(doc);
                    };
                }); 
                break;
            }
            case OrderStatus.refused: {
                orderSchema.findByIdAndUpdate<IOrders>(req.params.id, {status: req.body.status}, (err: ErrorCallback, doc: Document) => {
                    if (err) {
                        return res.status(500).send(err)
                    } else {
                        let io: Server = req.app.get('io');
                        io.emit('ORDER-'+doc._id , doc);
                        return res.status(200).json(doc);
                    };
                }); 
                break;
            }
            default: {
                return res.status(500);
            }
        }
    }
}