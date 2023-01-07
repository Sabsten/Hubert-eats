import { ObjectId } from "mongodb";
import Restaurant, { IRestaurant } from "../models/restaurant";
import { faker } from '@faker-js/faker';
import Customer, { ICustomer } from "../models/customer";
import mongoose, {Document} from "mongoose";
import Courier, { ICourier } from "../models/courier";

mongoose.connect('mongodb+srv://db:cesi@clusterhubert.9rf9vju.mongodb.net/?retryWrites=true&w=majority').then(async (a) => {
    await a.connection.dropCollection('restaurants');
    await a.connection.dropCollection('customers');
    await a.connection.dropCollection('couriers');
    await Restaurant.bulkSave(createRestaurants());
    await Customer.bulkSave(createCustomers());
    await Courier.bulkSave(createCouriers());
}).finally(() => {
    process.exit();
});

function createRestaurants(): Document[] {
    let restaurantsList: Document[] = [];
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
            rating: [faker.datatype.number({min: 0, max: 5, precision: 0.1})],
        });
        restaurantsList.push(newRestaurant);
    };
    return restaurantsList;
}

function createCustomers(): Document[] {
    let customersList: Document[] = [];
    for (let i = 0; i < 10; i++) {
        let newCustomer = new Customer<ICustomer>({
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
        customersList.push(newCustomer);
    };
    return customersList;
}

function createCouriers(): Document[] {
    let couriersList: Document[] = [];
    for (let i = 0; i < 10; i++) {
        let newCourier = new Courier<ICourier>({
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
            balance: faker.datatype.number({min: 0, max: 500, precision: 0.1}),
            rating: [faker.datatype.number({min: 0, max: 5, precision: 0.1})],
        });
        couriersList.push(newCourier);
    };
    return couriersList;
}
