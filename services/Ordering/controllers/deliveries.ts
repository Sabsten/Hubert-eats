import { Request, Response } from "express";
import deliveriesSchema from "../models/deliveries";
import { CallbackError, Document } from "mongoose";



export class deliveriesController {

    public getAlldeliver(req: Request, res: Response) {
       deliveriesSchema.find((err: CallbackError, docs: Document) => {
        return err ?
            res.status(500).send(err) :
            res.status(200).json(docs);
    })
    };
    
    
    public adddeliver(req: Request, res: Response) {
        const test = new deliveriesSchema({ name: req.body.name, description: req.body.description, link: req.body.link});
        test.save((err, doc) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully added !');
        });
        
    };

    public modifydeliver(req: Request, res: Response) {
        const componame: string = req.body.name;
        const compodescription: string = req.body.description;
        const commpolink: string = req.body.link;
        deliveriesSchema.findByIdAndUpdate(req.params.id,{name: componame, description: compodescription, link: commpolink}, (err: ErrorCallback, doc: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully modify !');
        }); 
  



    }
        
       
    
}