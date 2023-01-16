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
                restaurant_address: {
                    city: '',
                    street_name: 'string',
                    street_number: 0,
                    postal_code: 0,
                },
                articles: [],
            } as ICart,
        }
    },
    getters: {
        getArticlesNumber: (state): number => {
            return state.cart.articles.length;
        },
        totalPrice: (state): number => {
            let somme = 0;
            state.cart.articles.forEach(a => {
                somme += (a.price * a.quantity)
            });
            return somme;
        }
    },
    actions: {
        addToCart(article: IArticle, restaurant: IRestaurant){
            if (this.cart.articles.length === 0) {
                this.$patch({
                    cart: {
                        restaurant_id: restaurant._id,
                        restaurant_name: restaurant.name,
                        restaurant_address: restaurant.address,
                    }
                });
            }
            let existingArticle = this.$state.cart.articles.find(a => a.article_id === article._id);
            if (existingArticle){
                existingArticle.quantity += 1;
            } else {
                const newArticle: IArticleCart = {
                    article_id: article._id,
                    name: article.name,
                    quantity: 1,
                    price: article.price,
                    image: article.image,
                }
                this.$state.cart.articles.push(newArticle);
            }
        },
        removeToCart(article: IArticleCart) {
            let existingArticle = this.$state.cart.articles.find(a => a.article_id === article.article_id);
            if (!existingArticle){
                return;
            }
            if (existingArticle.quantity <= 1) {
                let index = this.$state.cart.articles.indexOf(existingArticle);
                this.$state.cart.articles.splice(index, 1);
            } else {
                existingArticle.quantity -= 1;
            }
            if (this.$state.cart.articles.length === 0) {
                this.$reset();
            }
        },
        addQuantity(article: IArticleCart) {
            let existingArticle = this.$state.cart.articles.find(a => a.article_id === article.article_id);
            if (!existingArticle){
                return;
            }
            existingArticle.quantity += 1;
        },
    }
})
