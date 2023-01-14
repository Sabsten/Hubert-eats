export interface IInventory {
    articles?: IArticle[];
}

export interface IArticle {
    _id?: string;
    restaurant_id : string;
    description : string;
    name : string;
    quantity : number;
    type : ArticleType;
    price : number;
    image?: string;
}

export enum ArticleType {
    starter = "starter",
    main = "main",
    dessert = "dessert",
    drink = "drink"
}