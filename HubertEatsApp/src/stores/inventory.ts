import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { IRestaurant } from '@/models/restaurants';
import { ArticleType, type IArticle, type IInventory } from '@/models/inventaire';
import { useRoute } from 'vue-router';

export const useInventoryStore = defineStore({
    id: 'Inventaire',
    state: () => {
        return {
            inventory: null as IInventory| null,
            error: null as string | null
        }
    },
    getters: {
        getStarters: (state): IArticle[] | undefined => {
            return state.inventory?.articles?.filter(article => article.type === ArticleType.starter);
        },
        getMains: (state): IArticle[] | undefined => {
            return state.inventory?.articles?.filter(article => article.type === ArticleType.main);
        },
        getDesserts: (state): IArticle[] | undefined => {
            return state.inventory?.articles?.filter(article => article.type === ArticleType.dessert);
        },
        getDrinks: (state): IArticle[] | undefined => {
            return state.inventory?.articles?.filter(article => article.type === ArticleType.drink);
        },
    },
    actions: {
        async getInventory(restaurantID: string) {
            console.log("restID "+ restaurantID);
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_INVENTORY_SERVICE_URL + '/' + restaurantID;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer: ' + authStore.getToken!
                },
            });
            const data: IInventory = await RES.json();
            console.log(data);
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return
            } else {
                this.$patch({ inventory: data });
                return
            };
        },
    }
})
