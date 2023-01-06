import { Schema, model, connect, Types } from 'mongoose';

// Create an interface representing a document in MongoDB.
interface Icomponents {
    _id?: Types.ObjectId;
    name : string;
    description : string;
    link : string;  
   
}
// Create a Schema corresponding to the document interface.
const componentSchema = new Schema<Icomponents>({
  name: { type: String, required: true },
  description: { type: String, required: true },
  link: { type: String, required: true },
  
}, { versionKey: false, timestamps: true });

// Create a Model.
const components = model<Icomponents>('components', componentSchema);

export default components