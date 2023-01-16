import { Request, Response } from "express";
import jwt from "jsonwebtoken";
import { CallbackError, Document} from "mongoose";
import mongodb, { MongoError } from "mongodb"
import Restaurant, { IRestaurant } from "../models/restaurant";
import { UserType } from "../models/enums/userType";
import Customer, { ICustomer } from "../models/customer";
import Courier, { ICourier } from "../models/courier";

export class AuthController {
    
    public async signIn(req: Request, res: Response) {
        const accountType: UserType = req.params.accountType as UserType;
        if (!(accountType in UserType)) {
            return res.status(500).json({error: "Bad accountType parameter please retry ..."});
        }
        let document: Document | null = null;
        switch(accountType) {
            case UserType.restaurant: {
                document = await Restaurant.findOne({"account.mail": req.body.mail, "account.password": req.body.password});
                break;
            }
            case UserType.customer: {
                document = await Customer.findOne({"account.mail": req.body.mail, "account.password": req.body.password});
                break;
            }
            case UserType.courier: {
                document = await Courier.findOne({"account.mail": req.body.mail, "account.password": req.body.password});
                break;
            }
        }
        if (document === null) {
            return res.status(404).json({error: "Identifiants incorrect, aucun compte n'a été trouvé"});
        };
        const accessToken = jwt.sign({accountId: document._id, type: accountType}, process.env.PRIVATE_TOKEN_KEY!);
        return res.status(200).json({token: accessToken});
    };

    public async signUp(req: Request, res: Response) {
        console.log(req.body)
        const accountType: UserType = req.params.accountType as UserType;
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
                    if (error.code === 11000) {
                        return res.status(409).json({error: "Email already exist !"})
                    } else {
                        return res.status(500).json({error: error});
                    }
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
                    if (error.code === 11000) {
                        return res.status(409).json({error: "Email already exist !"})
                    } else {
                        return res.status(500).json({error: error});
                    }
                }
                break;
            }
            case UserType.courier: {
                const newCourier = new Courier<ICourier>({
                    account: req.body.account,
                    firstname: req.body.firstname,
                    lastname: req.body.lastname,
                    address: req.body.address,
                    balance: 0
                });
                try {
                    document = await newCourier.save()
                } catch (err) {
                    const error = err as mongodb.MongoError
                    if (error.code === 11000) {
                        return res.status(409).json({error: "Email already exist !"})
                    } else {
                        return res.status(500).json({error: error});
                    }
                }
                break;
            }
        }
        if (document === null) {
            return res.status(500).json({error: "document null"});
        };
        const accessToken = jwt.sign({accountId: document._id, type: accountType}, process.env.PRIVATE_TOKEN_KEY!);
        return res.status(200).json({token: accessToken});
    }
}