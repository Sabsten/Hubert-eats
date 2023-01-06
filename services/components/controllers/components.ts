import { Request, Response } from "express";
import componentSchema from "../models/components";
import { CallbackError, Document } from "mongoose";



export class componentsController {

    public getAllcomponents(req: Request, res: Response) {
       componentSchema.find((err: CallbackError, docs: Document) => {
        return err ?
            res.status(500).send(err) :
            res.status(200).json(docs);
    })
    };
    

    public deletecomponentsById(req: Request, res: Response){
        componentSchema.findByIdAndDelete(req.params.id,(err: CallbackError, docs: Document) => {
            return err ? 
            res.status(500).send(err) :
            res.status(200).json(docs);
       
    })
    };
    
    public addcomponents(req: Request, res: Response) {
        const test = new componentSchema({ name: req.body.name, description: req.body.description, link: req.body.link});
        test.save((err, doc) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully added !');
        });
        
    };

    public modifycomponents(req: Request, res: Response) {
        const componame: string = req.body.name;
        const compodescription: string = req.body.description;
        const commpolink: string = req.body.link;
        componentSchema.findByIdAndUpdate(req.params.id,{name: componame, description: compodescription, link: commpolink}, (err: ErrorCallback, doc: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).send('Sensor with id : ' + doc.id + ' successfully modify !');
        }); 
  



    }
        
       
    
}