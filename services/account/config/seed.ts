import { ObjectId } from "mongodb";
import Restaurant, { IRestaurant } from "../models/restaurant";
import { faker } from '@faker-js/faker';
import Account, { IAccount } from "../models/account";
import { UserType } from "../models/enums/userType";

export class Seeder {

    public seedRestaurants() {
        Restaurant.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newRestaurant = new Restaurant<IRestaurant>({
                name: faker.company.name(),
                address: {
                    city: faker.address.cityName(),
                    street_name: faker.address.street(),
                    street_number: faker.datatype.number(),
                    postal_code: faker.datatype.number(),
                    country: faker.address.country(),
                },
                image: faker.image.food(300, 300, true),
                tags: [faker.datatype.string(), faker.datatype.string(), faker.datatype.string()],
                referent: faker.internet.email(),
                rating: faker.datatype.number({min: 0, max: 5, precision: 0.1}),
            });
            newRestaurant.save();
        };
    }

    public seedAccounts() {
        for (let i = 0; i < 10; i++) {
            let newAccount = new Account<IAccount>({
                mail: faker.internet.email(),
                password: faker.internet.password(),
                type: faker.helpers.arrayElement([UserType.courier, UserType.customer, UserType.restaurant]),
            });
            newAccount.save();
        };
    }
}