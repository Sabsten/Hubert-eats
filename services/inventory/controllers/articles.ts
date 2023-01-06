import { Request, Response } from "express";
import Article from "../models/articles";
import { CallbackError, Document } from "mongoose";

export class ArticlesController {

    public getAllArticles(req: Request, res: Response) {
        Article.find({}, (err: CallbackError, docs: Document) => {
            return err ?
                res.status(500).send(err) :
                res.status(200).json(docs);
        })
    };

    public getArticleById(req: Request, res: Response){
        return res.send("GET ARTICLE WITH ID : " + req.params.id +" SUCCESS !");
    };
    
    public deleteArticleById(req: Request, res: Response){
        return res.send("DELETE ARTICLE WITH ID : " + req.params.id +" SUCCESS !");
    }
    
    public addArticle(req: Request, res: Response) {
        return res.send("POST ARTICLE SUCCESS !");
    }
}