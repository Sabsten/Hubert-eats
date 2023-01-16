import { Schema } from "mongoose"

export interface IAddress {
    city: string,
    street_name: string,
    street_number: number,
    postal_code: number,
    country?: string
}

const addressSchema = new Schema<IAddress>({
    city: {type: String, required: true},
    street_name: {type: String, required: true},
    street_number: {type: Number, required: true},
    postal_code: {type: Number, required: true},
    country: {type: String, required: false},
}, {_id : false })

export default addressSchema