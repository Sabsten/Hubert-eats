import { Request, Response, NextFunction } from "express";
import jwt from "jsonwebtoken";
import { UserType } from "../models/enums/userType";


interface tokenPayload {
    accountId: string,
    type: UserType
}

// Extraction du token
function getToken(req: Request){
    const authHeader = req.headers['authorization'];
    return authHeader && authHeader.split(' ')[1];
}

export function restaurantAccess(req: Request, res: Response, next: NextFunction) {
    const token = getToken(req);
      // Présence d'un token
      if (!token) {
        return res.status(401).json({ message: 'Error. Need a token' })
    }

    // Véracité du token
    jwt.verify(token, process.env.PRIVATE_TOKEN_KEY!, (err, decodedToken) => {
        if (err) {
           return res.status(401).json({ message: 'Error. Bad token' })
        }
        const payload = decodedToken as tokenPayload;
        if (payload.type === UserType.admin) {
            return next();
        } else if (payload.type === UserType.restaurant && payload.accountId === req.params.id){
            return next();
        }
        else {
            return res.status(403).json({ message: 'Account not authorized' });
        }
    })
}

export function courierAccess(req: Request, res: Response, next: NextFunction) {
    const token = getToken(req);
      // Présence d'un token
      if (!token) {
        return res.status(401).json({ message: 'Error. Need a token' })
    }

    // Véracité du token
    jwt.verify(token, process.env.PRIVATE_TOKEN_KEY!, (err, decodedToken) => {
        if (err) {
           return res.status(401).json({ message: 'Error. Bad token' })
        }
        const payload = decodedToken as tokenPayload;
        if (payload.type === UserType.admin) {
            return next();
        } else if (payload.type === UserType.courier && payload.accountId === req.params.id){
            return next();
        }
        else {
            return res.status(403).json({ message: 'Account not authorized' });
        }
    })
}

export function customerAccess(req: Request, res: Response, next: NextFunction) {
    const token = getToken(req);
      // Présence d'un token
      if (!token) {
        return res.status(401).json({ message: 'Error. Need a token' })
    }

    // Véracité du token
    jwt.verify(token, process.env.PRIVATE_TOKEN_KEY!, (err, decodedToken) => {
        if (err) {
           return res.status(401).json({ message: 'Error. Bad token' })
        }
        const payload = decodedToken as tokenPayload;
        if (payload.type === UserType.admin) {
            return next();
        } else if (payload.type === UserType.customer && payload.accountId === req.params.id){
            return next();
        }
        else {
            return res.status(403).json({ message: 'Account not authorized' });
        }
    })
}