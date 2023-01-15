import type { IArticle } from "./inventaire";

export interface ICart {
    restaurant_id: string,
    restaurant_name: string,
    articles: IArticleCart[],
}

export interface IArticleCart {
    _id: string;
    name : string;
    quantity : number;
    price : number;
    image?: string;
}