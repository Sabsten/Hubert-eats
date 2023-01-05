import { Schema, model, connect, Types } from 'mongoose';

// Create an interface representing a document in MongoDB.
interface IArticle {
    _id?: Types.ObjectId;
    restaurant_id : Types.ObjectId;
    description : string;
    name : string;
    quantity : number;
    type : ArticleType;
    price : number;
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
  price: { type: Number, required: true}
}, { versionKey: false, timestamps: true });

// Create a Model.
const Article = model<IArticle>('Article', articleSchema);

export default Article