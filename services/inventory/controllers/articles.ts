import { Request, Response } from "express";
import Article, { IArticle } from "../models/articles";
import { CallbackError, Document } from "mongoose";
import { MongoError } from "mongodb";

export class ArticlesController {

    public getAllArticles(req: Request, res: Response) {
        Article.find({}, (err: CallbackError, docs: Document) => {
            return err ?
                res.status(500).json(err) :
                res.status(200).json(docs);
        });
    };

    public getArticlesByRestaurantId(req: Request, res: Response){
        Article.find({restaurant_id: req.params.restaurant_id}, (err: CallbackError, docs: Document) => {
            return err ?
            res.status(500).json(err) :
            res.status(200).json(docs);
        });
    };
    
    public deleteArticleById(req: Request, res: Response){
        Article.findByIdAndDelete(req.params.id, (err: CallbackError, doc: IArticle) => {
            return err ?
            res.status(500).json(err) :
            res.status(200).json(doc);
        });
    };
    
    public addArticle(req: Request, res: Response) {
        const newArticle: IArticle = new Article({
            restaurant_id: req.body.restaurant_id,
            description: req.body.description,
            name: req.body.name,
            price: req.body.price,
            quantity: req.body.quantity,
            type: req.body.type
        });
        Article.create(newArticle, (err: CallbackError, doc: IArticle) => {
            return err ?
            res.status(500).json(err) :
            res.status(200).json(doc);
        });
    };
    public updateArticleById(req: Request, res: Response) {
        Article.findByIdAndUpdate(req.params.id, {
            restaurant_id: req.body?.restaurant_id,
            description: req.body?.description,
            name: req.body?.name,
            price: req.body?.price,
            quantity: req.body?.quantity,
            type: req.body?.type
        }, (err: CallbackError, doc: IArticle) => {
            return err ?
            res.status(500).json(err) :
            res.status(200).json(doc);
        });
    };

}