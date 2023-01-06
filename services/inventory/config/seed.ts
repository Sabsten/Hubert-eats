import { ObjectId } from "mongodb";
import Article, { ArticleType, IArticle } from "../models/articles";
import { faker } from '@faker-js/faker';

export class Seeder {

    public seedArticles() {
        Article.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newArticle = new Article<IArticle>({
                _id: new ObjectId(),
                restaurant_id : new ObjectId(),
                name : faker.commerce.productName(),
                description : faker.commerce.productDescription(),
                quantity : faker.datatype.number(),
                type : faker.helpers.arrayElement([ArticleType.main, ArticleType.starter, ArticleType.dessert, ArticleType.drink]),
                price : faker.datatype.number()
            });
            newArticle.save();
        };
    }
}