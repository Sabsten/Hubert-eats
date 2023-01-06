import express from "express";
import { componentsController } from "../controllers/components";

const compoController = new componentsController();
const composantRouter = express.Router();
composantRouter.get('/', compoController.getAllcomponents);
composantRouter.post('/', compoController.addcomponents);
composantRouter.delete('/:id', compoController.deletecomponentsById);
composantRouter.put('/:id', compoController.modifycomponents);


export default composantRouter;