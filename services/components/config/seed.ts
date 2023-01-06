import { ObjectId } from "mongodb";
import components from "../models/components";
import { faker } from '@faker-js/faker';

export class Seeder {

    public seedComponents() {
        components.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newCOMPONENTS = new components({
                name : faker.commerce.productName(),
                description : faker.commerce.productDescription(),
                link : faker.internet.url(),
            });
            newCOMPONENTS.save();
        };
    }
}