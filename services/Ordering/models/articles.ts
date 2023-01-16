import { Schema, Types } from "mongoose";

export interface IArticles {
    _id?: Types.ObjectId;
    restaurant_id : Types.ObjectId;
    description : string;
    name : string;
    quantity : number;
    type : string;
    price : number;
}

export interface IArticleCart {
    article_id: Types.ObjectId;
    name : string;
    quantity : number;
    price : number;
    image?: string;
}

export const articleCartSchema = new Schema<IArticleCart>({
    article_id: {type: Schema.Types.ObjectId, required: true},
    name: {type: String, required: true},
    quantity: {type: Number, required: true},
    price: {type: Number, required: true},
    image: {type: String, required: false},
}, {_id : false })

export enum ArticleType {
    starter = "starter",
    main = "main",
    dessert = "dessert",
    drink = "drink"
}