import { Request, Response } from "express";
import orderSchema from "../models/orders";
import { CallbackError, Document } from "mongoose";



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
    
    public addorders(req: Request, res: Response) {
        const test = new orderSchema({ name: req.body.name, description: req.body.description, link: req.body.link});
        test.save((err, doc) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully added !');
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