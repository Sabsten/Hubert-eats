import { Request, Response } from "express";
import jwt from "jsonwebtoken";
import { CallbackError, Document} from "mongoose";
import mongodb, { MongoError } from "mongodb"
import Restaurant, { IRestaurant } from "../models/restaurant";
import { UserType } from "../models/enums/userType";
import Customer, { ICustomer } from "../models/customer";

export class AuthController {
    
    public async signIn(req: Request, res: Response) {
        if (!Object.values(UserType).includes(req.body.type)) {
            return res.status(500).json({error: "Missing request.body.type please retry ..."});
        }
        let document: Document | null = null;
        switch(req.body.type) {
            case UserType.restaurant: {
                document = await Restaurant.findOne({"account.mail": req.body.mail, "account.password": req.body.password});
                break;
            }
            case UserType.customer: {
                document = await Customer.findOne({"account.mail": req.body.mail, "account.password": req.body.password});
                break;
            }
            // case UserType.courier: {
            //     document = await Courier.findOne({mail: req.body.mail, password: req.body.password});
            // }
        }
        if (document === null) {
            return res.status(404).json({error: "NOT FOUND"});
        };
        const accessToken = jwt.sign({accountId: document._id, type: req.body.type}, process.env.PRIVATE_TOKEN_KEY! ,{
            expiresIn: "24h",
        });
        return res.status(200).json({token: accessToken});
    };

    public async signUp(req: Request, res: Response) {
        let accountType: string = req.body.type;
        if (!(accountType in UserType)) {
            return res.status(500).json({error: "Missing request.body.type please retry ..."});
        }
        let document: Document | null = null;
        switch(accountType) {
            case UserType.restaurant: {
                const newRestaurant = new Restaurant<IRestaurant>({
                    account: req.body.account,
                    name: req.body.name,
                    address: req.body.address
                });
                try {
                    document = await newRestaurant.save()
                } catch (err) {
                    const error = err as mongodb.MongoError
                    return res.status(500).json({error: error.message});
                }
                break;
            }
            case UserType.customer: {
                const newCustomer = new Customer<ICustomer>({
                    account: req.body.account,
                    firstname: req.body.firstname,
                    lastname: req.body.lastname,
                    address: req.body.address
                });
                try {
                    document = await newCustomer.save()
                } catch (err) {
                    const error = err as mongodb.MongoError
                    return res.status(500).json({error: error.message});
                }
                break;
            }
        }
        if (document === null) {
            return res.status(500).json({error: "document null"});
        };
        const accessToken = jwt.sign({accountId: document._id, type: accountType}, process.env.PRIVATE_TOKEN_KEY! ,{
            expiresIn: "24h",
        });
        return res.status(200).json({token: accessToken});
    }
}