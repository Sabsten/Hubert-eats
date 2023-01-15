import mongoose from "mongoose";

async function seed() {
    const a = await mongoose.connect('mongodb+srv://db:cesi@clusterhubert.9rf9vju.mongodb.net/?retryWrites=true&w=majority');
    await a.connection.dropCollection('restaurants');
    await a.connection.dropCollection('customers');
    await a.connection.dropCollection('couriers');
    await a.connection.dropCollection('articles');
    process.exit();
}
seed();