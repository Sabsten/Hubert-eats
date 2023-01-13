import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { ICourier } from '@/models/couriers';
import type { ICustomerForm, ICustomer } from '@/models/customers';

export const useCustomerStore = defineStore({
    id: 'Customer',
    state: () => {
        return {
            customerAccount: null as ICustomer | null,
            error: null as string | null
        }
    },
    getters: {
        getCustomerForm(state): ICustomerForm{
            return {
                mail: state.customerAccount?.account.mail,
                password: state.customerAccount?.account.password,
                firstname: state.customerAccount?.firstname,
                lastname: state.customerAccount?.lastname,
                street_name: state.customerAccount?.address.street_name,
                street_number: state.customerAccount?.address.street_number,
                city: state.customerAccount?.address.city,
                postal_code: state.customerAccount?.address.postal_code,
            }
        },
    },
    actions: {
        async getCustomerAccount() {
            const authStore = useAuthStore();
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/customers/account/' + authStore.getAccountId!;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer: ' + authStore.getToken!
                },
            });
            const data: ICustomer = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return
            } else {
                this.$patch({ customerAccount: data });
                return
            };
        },
        async updateCustomerAcount() {
            const authStore = useAuthStore();
            console.log(this.customerAccount?.firstname)
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + '/customers/account/' + authStore.getAccountId!;
            const RES: Response = await fetch(URL, {
                method: "PATCH",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + authStore.getToken!
                },
                body: JSON.stringify(this.getCustomerForm)
            });
            const data: ICourier = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
            } else {
                this.$patch({ customerAccount: data });
            }
        },
    }
})
