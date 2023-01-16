import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { ICourier } from '@/models/ICourier';
import axios, { type AxiosResponse } from 'axios';
import type { ICourierForm } from '@/models/courierForm';

export const useCourierStore = defineStore({
    id: 'Courier',
    state: () => {
        return {
            courierAccount: null as ICourier | null,
            error: null as string | null
        }
    },
    getters: {
        getCourierRating: (state): number | null => {
            if (state.courierAccount?.rating) {
                const total = state.courierAccount.rating.length;
                let somme = 0;
                for (let i = 0; i < total; i++) {
                    somme += state.courierAccount.rating[i]
                }
                return somme/total;
            }
            return null
        }
    },
    actions: {
        async getCourierAccount() {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/couriers/account/' + authStore.getAccountId!;
            const options = {headers: {'Authorization': 'Bearer: ' + authStore.getToken!}};
            axios.get<ICourier>(URL, options).then((response: AxiosResponse) => {
                this.courierAccount = response.data;
                return
            });
        },
        async modifyCourierAcount(courierForm: ICourierForm) {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/couriers/account/' + authStore.getAccountId!;
            const RES: Response = await fetch(URL, {
                method: "PATCH",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + authStore.getToken!
                },
                body: JSON.stringify(courierForm)
            });
            const data: ICourier = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
            } else {
                this.$patch({ courierAccount: data });
            }
        },
    }
})