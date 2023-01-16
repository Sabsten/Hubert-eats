import { Request, Response } from "express";
import orderSchema, {IOrders, OrderStatus} from "../models/orders";
import { CallbackError, Document } from "mongoose";
import { IArticleCart } from "../models/articles";

export class orderController {

    public getAllorders(req: Request, res: Response) {
       orderSchema.find((err: CallbackError, docs: Document) => {
        return err ?
            res.status(500).send(err) :
            res.status(200).json(docs);
    })
    };

    public deleteordersById(req: Request, res: Response){
        orderSchema.findByIdAndDelete(req.params.id,(err: CallbackError, docs: Document) => {
            return err ? 
            res.status(500).send(err) :
            res.status(200).json(docs);
    })
    };
    
    public async createOrders(req: Request, res: Response) {
        const test = new orderSchema<IOrders>({
            articles: req.body.articles,
            customer_id: req.body.customer_id,
            restaurant_id: req.body.restaurant_id,
            customer_address: req.body.customer_address,
            restaurant_address: req.body.restaurant_address,
            price: req.body.price,
            status: OrderStatus.paid,
        });
        test.save((err, doc) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Order with id : ' + doc.id + ' successfully created !');
        });
        
    };

    public modifyorders(req: Request, res: Response) {
        const componame: string = req.body.name;
        const compodescription: string = req.body.description;
        const commpolink: string = req.body.link;
        orderSchema.findByIdAndUpdate(req.params.id,{name: componame, description: compodescription, link: commpolink}, (err: ErrorCallback, doc: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully modify !');
        }); 
    }
}