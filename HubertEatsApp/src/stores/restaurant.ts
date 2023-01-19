import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { IRestaurant, IRestaurantAccount } from '@/models/restaurants';
import { useRoute } from 'vue-router';

export const useRestaurantStore = defineStore({
    id: 'Restaurant',
    state: () => {
        return {
            restaurantsList: [] as IRestaurant[],
            error: null as string | null,
            restaurantAccount: null as IRestaurantAccount | null,
        }
    },
    getters: {
        getCurrentRestaurant: (state): IRestaurant | undefined => {
            return state.restaurantsList.find(restaurant => restaurant._id === useRoute().params.id);
        },
    },
    actions: {
        async getRestaurants(filter: string) {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/restaurants' + filter;
            console.log(URL)
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
            });
            const data: IRestaurant[] = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return
            } else {
                this.$patch({ restaurantsList: data });
                return
            };
        },
        getAverageRating(ratings: number[] | undefined){
            if (ratings === undefined) {
                return null;
            }
            const total = ratings.length;
            let somme: number = 0;
            ratings?.forEach(r => {
                somme += r;
            });
            return Math.round(somme/total * 10)/ 10;
        },
        async getRestaurantAccount(id: string){
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/restaurants/account/' + id;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
            });
            const data: IRestaurantAccount = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return
            } else {
                this.$patch({ restaurantAccount: data });
                return
            };
        }
    }
})
