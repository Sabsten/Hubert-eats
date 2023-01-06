import { Schema, model, connect, Types } from 'mongoose';
import { ObjectId } from 'mongodb';
import { UserType } from './enums/userType';

// Create an interface representing a document in MongoDB.
export interface IAccount {
    _id?: ObjectId;
    mail: string;
    password: string;
    type: UserType;
}

// Create a Schema corresponding to the document interface.
const accountSchema = new Schema<IAccount>({
  mail: { type: String, required: true },
  password: { type: String, required: true },
  type: { type: String, required: true },
}, { versionKey: false, timestamps: true });

// Create a Model.
const Account = model<IAccount>('Account', accountSchema);

export default Account