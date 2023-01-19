import { connect } from 'mongoose';

export class db {

    public dbConnect() {
        try {
            connect(process.env.MONGO_DB_URL!);
        } catch(e) {
            console.log(e);
        }
    }
}