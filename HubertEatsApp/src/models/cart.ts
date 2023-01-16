import type { IAddress } from "./IAddress";
import type { IArticle } from "./inventaire";

export interface ICart {
    restaurant_id: string,
    restaurant_name: string,
    restaurant_address: IAddress,
    articles: IArticleCart[],
}

export interface IArticleCart {
    article_id: string;
    name : string;
    quantity : number;
    price : number;
    image?: string;
}