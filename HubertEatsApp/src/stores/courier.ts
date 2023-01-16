import { defineStore } from 'pinia';
import { useAuthStore, getAccountId, getAccountType } from './auth';
import type { ICourier, ICourierForm } from '@/models/couriers';
import axios, { type AxiosResponse } from 'axios';

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
        },
        getCourierForm(state): ICourierForm{
            return {
                mail: state.courierAccount?.account.mail,
                firstname: state.courierAccount?.firstname,
                lastname: state.courierAccount?.lastname,
                street_name: state.courierAccount?.address.street_name,
                street_number: state.courierAccount?.address.street_number,
                city: state.courierAccount?.address.city,
                postal_code: state.courierAccount?.address.postal_code,
            }
        },
    },
    actions: {
        async getCourierAccount() {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/couriers/account/' + getAccountId()!;
            const options = {headers: {'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!}};
            axios.get<ICourier>(URL, options).then((response: AxiosResponse) => {
                this.courierAccount = response.data;
                return
            });
        },
        async modifyCourierAcount() {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/couriers/account/' + getAccountId()!;
            const RES: Response = await fetch(URL, {
                method: "PATCH",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
                body: JSON.stringify(this.getCourierForm)
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
