import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { IRestaurant } from '@/models/restaurants';

export const useRestaurantStore = defineStore({
    id: 'Restaurant',
    state: () => {
        return {
            restaurantsList: [] as IRestaurant[],
            error: null as string | null
        }
    },
    getters: {
    },
    actions: {
        async getRestaurants() {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/restaurants';
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer: ' + authStore.getToken!
                },
            });
            const data: IRestaurant[] = await RES.json();
            console.log(data);
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return
            } else {
                this.$patch({ restaurantsList: data });
                return
            };
        },
    }
})
