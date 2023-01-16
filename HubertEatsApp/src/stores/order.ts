import { defineStore } from 'pinia';
import { useAuthStore } from './auth';
import type { IArticleCart, ICart } from '@/models/cart';
import { useRestaurantStore } from './restaurant';
import { useCustomerStore } from './customer';
import { useCartStore } from './cart';

export const useOrderStore = defineStore({
    id: 'Order',
    state: () => {
        return {
            error: null as string | null,
            order: Object,
        }
    },
    getters: {
    },
    actions: {
        async payOrder(articles: IArticleCart[], restaurant_id: string, customer_id: string, price: number): Promise<boolean> {
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders';
            const cartStore = useCartStore();
            const customerStore = useCustomerStore();
            const RES: Response = await fetch(URL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
                body: JSON.stringify({
                    articles: articles,
                    restaurant_id: restaurant_id,
                    restaurant_address: cartStore.cart.restaurant_address,
                    customer_id: customer_id,
                    customer_address: customerStore?.customerAccount?.address,
                    price: price,
                })
            });
            const data: {} = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$patch({ order: data });
                return true
            };
        },
    }
})
