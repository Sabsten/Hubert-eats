import { ObjectId } from "mongodb";
import { faker } from '@faker-js/faker';
import deliveries from "../models/deliveries";
import orders from "../models/orders";
import { ArticleType, IArticles } from "../models/articles";


export class Seeder {

    public seeddeliver() {
        deliveries.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newdeliveries = new deliveries({
                restaurant_address : {
                    city: faker.address.city(),
                    street_name: faker.address.streetName(),
                    street_number: faker.address.street(),
                    postal_code: faker.address.zipCode(),
                    country: faker.address.country()
                },
                customer_address: { 
                      city: faker.address.city(),
                      street_name: faker.address.streetName,
                      street_number: faker.address.street(),
                      postal_code: faker.address.zipCode(),
                      country: faker.address.country()
                    },
                status : faker.lorem.word(),
                validation_code : faker.datatype.number(),
            });
            newdeliveries.save();
        };
    }

    public seedorder() {
        orders.collection.drop();
        for (let i = 0; i < 10; i++) {
            let neworder = new orders({
                restaurant_address : {
                    city: faker.address.city(),
                    street_name: faker.address.streetName(),
                    street_number: faker.address.street(),
                    postal_code: faker.address.zipCode(),
                    country: faker.address.country()
                },

                menu : {
                
                    article: {
                        description : faker.commerce.productDescription(),
                        name : faker.commerce.productName(),
                        quantity : faker.datatype.number(),
                        type : faker.helpers.arrayElement([ArticleType.main, ArticleType.starter, ArticleType.dessert, ArticleType.drink]),
                        price : faker.datatype.number()
                       }

                },
                article: {
                    description : faker.commerce.productDescription(),
                    name : faker.commerce.productName(),
                    quantity : faker.datatype.number(),
                    type : faker.helpers.arrayElement([ArticleType.main, ArticleType.starter, ArticleType.dessert, ArticleType.drink]),
                    price : faker.datatype.number()
                   },
                description : faker.commerce.productDescription(),
                price: faker.datatype.number(),
                status:faker.lorem.word(),
            });
            neworder.save();
        };
    }
}