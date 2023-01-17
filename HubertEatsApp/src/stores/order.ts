import { defineStore } from 'pinia';
import { getAccountId, useAuthStore } from './auth';
import type { IArticleCart, ICart } from '@/models/cart';
import { useRestaurantStore } from './restaurant';
import { useCustomerStore } from './customer';
import { useCartStore } from './cart';
import { OrderStatus} from '@/models/order';
import type {IOrders} from '@/models/order';

export const useOrderStore = defineStore({
    id: 'Order',
    state: () => {
        return {
            error: null as string | null,
            order: {} as IOrders,
            orders: [] as IOrders[],
        }
    },
    getters: {
        getOrdersToAccept: (state): IOrders[] | undefined => {
            return state.orders.filter((order) => order.status === OrderStatus.paid);
        },
        getOrdersToPrepare: (state): IOrders[] | undefined => {
            return state.orders.filter((order) => order.status === OrderStatus.in_preparation);
        },
        getRestaurantOrdersHistory: (state): IOrders[] | undefined => {
            return state.orders.filter((order) => {
                if(order.status !== OrderStatus.in_preparation && order.status !== OrderStatus.paid){
                    return order
                }
            });
        },
        getCurrentOrder: (state): IOrders | undefined => {
            return state.orders.find((order) => order.status !== OrderStatus.delivered);
        }
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
                    restaurant_name: cartStore.cart.restaurant_name,
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
        async getOrdersByRestaurant(restaurant_id: string){
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders/restaurant/' + restaurant_id;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
            });
            const data: IOrders[] = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$patch({ orders: data });
                return true
            };
        },
        async getOrdersByCustomer(customerID: string){
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders/customer/' + customerID;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
            });
            const data: IOrders[] = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$patch({ orders: data });
                this.$patch({order: this.getCurrentOrder});
                return true
            };
        },
        async getOrdersByCourier(courierID: string){
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders/courier/' + courierID;
            const RES: Response = await fetch(URL, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!
                },
            });
            const data: IOrders[] = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$patch({ orders: data });
                this.$patch({order: this.getCurrentOrder});
                return true
            };
        },
        async changeOrderStatus(order_id: string, status: OrderStatus, code?: number){
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders/' + order_id;
            const RES: Response = await fetch(URL, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!,
                },
                body: JSON.stringify({
                    status: status,
                    code: code,
                })
            });
            const data: IOrders = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$state.order = data;
                // this.$state.orders.push(data);
                return true
            };
        },
        async assignOrder(order_id: string){
            const URL: string = import.meta.env.VITE_ORDERING_SERVICE_URL + '/orders/' + order_id + '/courier/' + getAccountId()!;
            const RES: Response = await fetch(URL, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer: ' + localStorage.getItem('TOKEN')!,
                },
            });
            const data: IOrders = await RES.json();
            if (!RES.ok) {
                this.$patch({ error: RES.statusText });
                return false
            } else {
                this.$state.order = data;
                return true
            };
        }
    }
})
