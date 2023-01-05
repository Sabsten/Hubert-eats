import { Request, Response } from "express";


export class componentsController {

    public getAllcomponents(req: Request, res: Response) {
        // return res.status(200).json
        return res.status(200).json({message: "GET ALL ARTICLES SUCCESS !"});
    };
    
    public deletecomponentsById(req: Request, res: Response){
        return res.send("DELETE ARTICLE WITH ID : " + req.params.id +" SUCCESS !");
    };
    
    public addcomponents(req: Request, res: Response) {
        return res.send("POST ARTICLE SUCCESS !");
    };

    public modifycomponents(req: Request, res: Response) {
        return res.send("PUT ARTICLE SUCCESS !");
    }
}