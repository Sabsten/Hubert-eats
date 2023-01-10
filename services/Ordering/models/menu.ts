import { Types } from "mongoose";
import { IArticles } from "./articles";

export interface IMenu {
    restaurant_id : Types.ObjectId;
    composition_id : Types.ObjectId;
    article: IArticles,
 
}