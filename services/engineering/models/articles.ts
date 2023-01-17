import { ObjectId } from 'mongodb';
import { Schema, model } from 'mongoose';

// Create an interface representing a document in MongoDB.
export interface IArticle {
    _id?: ObjectId;
    restaurant_id : ObjectId;
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

// Create a Schema corresponding to the document interface.
const articleSchema = new Schema<IArticle>({
  _id: Schema.Types.ObjectId,
  restaurant_id: { type: Schema.Types.ObjectId, required: true },
  name: { type: String, required: true },
  description: { type: String, required: true },
  quantity: { type: Number, required: true },
  type: { type: String, required: true },
  price: { type: Number, required: true},
  image: { type: String, required: false}
}, { versionKey: false, timestamps: true });

// Create a Model.
const Article = model<IArticle>('Article', articleSchema);

export default Article