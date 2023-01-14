import { Request, Response } from "express";
import Article, { IArticle } from "../models/articles";
import { IInventory } from "../models/inventory";

export class InventoryController {
    public async getInventoryByRestaurant(req: Request, res: Response){
        let inventory: IInventory = {};
        let articles: IArticle[] = []
        articles = await Article.find<IArticle>({restaurant_id: req.params.restaurant_id});
        if (articles.length === 0){
            return res.status(404).send("Not found");
        }
        inventory.articles = articles;
        return res.status(200).json(inventory);
    };
}