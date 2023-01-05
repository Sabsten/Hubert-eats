import express from "express";
import { ArticlesController } from "../controllers/articles";

const articlesController = new ArticlesController();
const articlesRouter = express.Router();
articlesRouter.get('/', articlesController.getAllArticles);
articlesRouter.get('/:id', articlesController.getArticleById);
articlesRouter.post('/', articlesController.addArticle);
articlesRouter.delete('/:id', articlesController.deleteArticleById);

export default articlesRouter;