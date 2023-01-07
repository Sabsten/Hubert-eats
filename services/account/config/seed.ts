import { ObjectId } from "mongodb";
import Restaurant, { IRestaurant } from "../models/restaurant";
import { faker } from '@faker-js/faker';
import Customer, { ICustomer } from "../models/customer";
import mongoose from "mongoose";

export class Seeder {

    public seedRestaurants() {
        Restaurant.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newRestaurant = new Restaurant<IRestaurant>({
                account: {
                    mail: faker.internet.email(),
                    password: faker.internet.password(),
                    referent: faker.internet.email(),
                },
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
                rating: faker.datatype.number({min: 0, max: 5, precision: 0.1}),
            });
            newRestaurant.save();
        };
    }

    public seedCustomers() {
        Customer.collection.drop();
        for (let i = 0; i < 10; i++) {
            let newAccount = new Customer<ICustomer>({
                account: {
                    mail: faker.internet.email(),
                    password: faker.internet.password(),
                    referent: faker.internet.email(),
                },
                firstname: faker.name.firstName(),
                lastname: faker.name.lastName(),
                address: {
                    city: faker.address.cityName(),
                    street_name: faker.address.street(),
                    street_number: faker.datatype.number(),
                    postal_code: faker.datatype.number(),
                    country: faker.address.country(),
                },
            });
            newAccount.save();
        };
    }

}