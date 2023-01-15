import { Schema } from "mongoose"

export interface IAccount {
    mail: string,
    password: string,
    referent?: string,
}


const accountSchema = new Schema<IAccount>({
    mail: {type: String, required: true, unique: true},
    password: {type: String, required: true},
    referent: {type: String, required: false},
}, { _id : false })

export default accountSchema

/**
 * @swagger
 * components:
 *   schemas:
 *     Account:
 *       type: object
 *       properties:
 *         mail:
 *           type: string
 *         password:
 *           type: string
 *         referent:
 *           type: string
 *       example:
 *         mail: john.doe@gmail.com
 *         password: admin123
 *         referent: jane.doe@gmail.com
 */