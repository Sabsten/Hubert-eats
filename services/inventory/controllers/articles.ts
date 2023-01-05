import { Request, Response } from "express";
import Article, { ArticleType } from "../models/articles";
import {ObjectId} from 'mongodb'

export class ArticlesController {

    public getAllArticles(req: Request, res: Response) {
        // return res.status(200).json
        return res.status(200).json({message: "GET ALL ARTICLES SUCCESS !"});
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