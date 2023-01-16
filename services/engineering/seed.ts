import { ObjectId } from "mongodb";
import { faker } from '@faker-js/faker';
import mongoose, {Document, Types} from "mongoose";
import Restaurant, { IRestaurant } from "./models/restaurant";
import Customer, { ICustomer } from "./models/customer";
import Courier, { ICourier } from "./models/courier";
import Article, { ArticleType, IArticle } from "./models/articles";


let restaurantsIdList: ObjectId[] = [];
for (let i = 0 ; i < 10 ; i++) {
    restaurantsIdList.push(new ObjectId());
};

async function seed() {
    await mongoose.connect('mongodb+srv://db:cesi@clusterhubert.9rf9vju.mongodb.net/?retryWrites=true&w=majority');
    console.log("Seeding restaurants ...");
    await Restaurant.bulkSave(createRestaurants());
    console.log("Seeding customers ...");
    await Customer.bulkSave(createCustomers());
    console.log("Seeding couriers ...");
    await Courier.bulkSave(createCouriers());
    console.log("Seeding articles ...");
    await Article.bulkSave(createArticles());
    process.exit();
}
seed();

function createRestaurants(): Document[] {
    let restaurantsList: Document[] = [];
    for (let i = 0; i < 10; i++) {
        let newRestaurant = new Restaurant<IRestaurant>({
            _id: restaurantsIdList[i],
            account: {
                mail: faker.internet.email(),
                password: faker.internet.password(),
                referent: faker.internet.email(),
            },
            name: faker.company.name(),
            address: {
                city: faker.address.cityName(),
                street_name: faker.address.street(),
                street_number: faker.datatype.number({min: 1, max: 200}),
                postal_code: faker.datatype.number({min: 10000, max: 99000}),
                country: faker.address.country(),
            },
            image: faker.image.food(300, 300, true),
            tags: [faker.datatype.string(), faker.datatype.string(), faker.datatype.string()],
            rating: [faker.datatype.number({min: 0, max: 5, precision: 0.1}), faker.datatype.number({min: 0, max: 5, precision: 0.1})],
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
                street_number: faker.datatype.number({min: 1, max: 200}),
                postal_code: faker.datatype.number({min: 10000, max: 99000}),
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
                street_number: faker.datatype.number({min: 1, max: 200}),
                postal_code: faker.datatype.number({min: 10000, max: 99000}),
                country: faker.address.country(),
            },
            balance: faker.datatype.number({min: 0, max: 500, precision: 0.1}),
            rating: [
                faker.datatype.number({min: 0, max: 5, precision: 0.1}),
                faker.datatype.number({min: 0, max: 5, precision: 0.1}),
                faker.datatype.number({min: 0, max: 5, precision: 0.1}),
                faker.datatype.number({min: 0, max: 5, precision: 0.1})
            ],
        });
        couriersList.push(newCourier);
    };
    return couriersList;
}

function createArticles(): Document[] {
    let articlesList: Document[] = [];
    restaurantsIdList.forEach(restaurantID => {
        for (let i = 0; i < 10; i++) {
            articlesList.push(
                new Article<IArticle>({
                    restaurant_id : restaurantID,
                    name : faker.commerce.productName(),
                    description : faker.commerce.productDescription(),
                    quantity : faker.datatype.number(),
                    type : faker.helpers.arrayElement([ArticleType.main, ArticleType.starter, ArticleType.dessert, ArticleType.drink]),
                    price : faker.datatype.number({min: 1, max: 20}),
                    image : faker.image.food(200,200, true),
                })
            );
        };
    });
    return articlesList;
}
