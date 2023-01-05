import { connect } from 'mongoose';

export class db {

    private readonly dbURI = 'mongodb+srv://db:cesi@clusterhubert.9rf9vju.mongodb.net/?retryWrites=true&w=majority';

    public dbConnect() {
        try {
            connect(this.dbURI);
        } catch(e) {
            console.log(e);
        }
    }
}