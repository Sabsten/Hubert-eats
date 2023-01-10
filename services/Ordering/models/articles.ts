import { Types } from "mongoose";

export interface IArticles {
    _id?: Types.ObjectId;
    restaurant_id : Types.ObjectId;
    description : string;
    name : string;
    quantity : number;
    type : string;
    price : number;
}

export enum ArticleType {
    starter = "starter",
    main = "main",
    dessert = "dessert",
    drink = "drink"
}