import { Request, Response } from "express";
import jwt from "jsonwebtoken";
import Account, { IAccount } from "../models/account";
import { CallbackError, Document } from "mongoose";

export class AuthController {

    public signIn(req: Request, res: Response) {
        Account.find({mail: req.body.mail, password: req.body.password, type: req.body.type},
            (err: CallbackError, docs: Document) => {
            if (err) {
                res.status(500).send(err);
            }
            const accessToken = jwt.sign({mail: req.body.mail, type: req.body.type}, process.env.PRIVATE_TOKEN_KEY! ,{
                expiresIn: "24h",
            });
            res.status(200).json({token: accessToken});
        });
    };

    public signUp(req: Request, res: Response) {
        const newAccount = new Account<IAccount>({
            mail: req.body.mail,
            password: req.body.password,
            type: req.body.type,
        });
        newAccount.save((err: CallbackError, docs: Document) => {
            if (err) {res.status(500).send(err)};
            const accessToken = jwt.sign({mail: req.body.mail, type: req.body.type}, process.env.PRIVATE_TOKEN_KEY! ,{
                expiresIn: "24h",
            });
            res.status(200).json({token: accessToken});
        });
    };

}