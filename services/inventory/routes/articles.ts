import express from "express";
import { ArticlesController } from "../controllers/articles";

const articlesController = new ArticlesController();
const articlesRouter = express.Router();
articlesRouter.get('/', articlesController.getAllArticles);
articlesRouter.get('/:restaurant_id', articlesController.getArticlesByRestaurantId);
articlesRouter.post('/', articlesController.addArticle);
articlesRouter.delete('/:id', articlesController.deleteArticleById);

export default articlesRouter;