import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { IRestaurant } from '@/models/restaurants';
import { useRoute } from 'vue-router';
import type { IArticle, IInventory } from '@/models/inventaire';
import type { IArticleCart, ICart } from '@/models/cart';

export const useCartStore = defineStore({
    id: 'Cart',
    state: () => {
        return {
            cart: {
                restaurant_id: '',
                restaurant_name: '',
                articles: [],
            } as ICart,
        }
    },
    getters: {
        getArticlesNumber: (state): number => {
            return state.cart.articles.length;
        }
        // getStarters: (state): IArticle[] | undefined => {
        //     return state.inventory?.articles?.filter(article => article.type === ArticleType.starter);
        // },
    },
    actions: {
        addToCart(article: IArticle, restaurant: IRestaurant){
            if (this.cart.articles.length === 0) {
                this.$patch({
                    cart: {
                        restaurant_id: restaurant._id,
                        restaurant_name: restaurant.name,
                    }
                });
            }
            let existingArticle = this.$state.cart.articles.find(a => a._id === article._id);
            if (existingArticle){
                existingArticle.quantity += 1;
            } else {
                const newArticle: IArticleCart = {
                    _id: article._id,
                    name: article.name,
                    quantity: 1,
                    price: article.price,
                    image: article.image,
                }
                this.$state.cart.articles.push(newArticle);
            }
        },
        removeToCart(article: IArticleCart) {
            let existingArticle = this.$state.cart.articles.find(a => a._id === article._id);
            if (!existingArticle){
                return;
            }
            if (existingArticle.quantity <= 1) {
                let index = this.$state.cart.articles.indexOf(existingArticle);
                this.$state.cart.articles.splice(index, 1);
            } else {
                existingArticle.quantity -= 1;
            }
        },
        addQuantity(article: IArticleCart) {
            let existingArticle = this.$state.cart.articles.find(a => a._id === article._id);
            if (!existingArticle){
                return;
            }
            existingArticle.quantity += 1;
        },
    }
})
