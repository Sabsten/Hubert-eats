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

/**
 * @swagger
 * components:
 *   schemas:
 *     Address:
 *       type: object
 *       properties:
 *         city:
 *           type: string
 *         street_name:
 *           type: string
 *         street_number:
 *           type: integer
 *         postal_code:
 *           type: integer
 *         country:
 *           type: string
 *       example:
 *         city: Toulouse
 *         street_name: Boulevard des oliviers
 *         street_number: 12
 *         postal_code: 31000
 *         country: France
 */