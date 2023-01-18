<script setup lang="ts">
import CourierHeader from '@/components/courier/CourierHeader.vue';
import Map from '@/components/Map.vue';
import type { IOrders } from '@/models/order';
import { OrderStatus } from '@/models/order';
import router from '@/router';
import { getAccountId } from '@/stores/auth';
import { useOrderStore } from '@/stores/order';
import { storeToRefs } from 'pinia';
import { io } from 'socket.io-client';
import { onMounted, ref, defineComponent, type Ref } from 'vue';

defineComponent({
    Map,
})

const orderStore = useOrderStore()
const {order, getCurrentOrder} = storeToRefs(orderStore);

let newOrder: Ref<IOrders | undefined> = ref(undefined);
let code1: Ref<number | undefined> = ref(undefined)
let code2: Ref<number | undefined> = ref(undefined)
let code3: Ref<number | undefined> = ref(undefined)
let code4: Ref<number | undefined> = ref(undefined)

function constructCode(): number {
    const code = "" + code1.value + code2.value + code3.value + code4.value;
    return Number(code);
}

onMounted(async () => {
    await orderStore.getOrdersByCourier(getAccountId()!);
    const socket = io(import.meta.env.VITE_ORDER_SOCKET_URL);
    if(!getCurrentOrder.value) {
        socket.on('NEW_ORDER', async (order: IOrders) => {
        new window.Notification('Nouvelle livraison disponible !', {vibrate: 200, image:"https://cdn.dribbble.com/users/791530/screenshots/6322090/ouch_illustration_animation_icons8.gif"});
        newOrder.value = order;
    })
    }
});

function refuseOrder() {
    newOrder.value = undefined;
}
async function acceptOrder(orderID: string) {
    const bool:boolean = await orderStore.assignOrder(orderID);
    if (bool === true){
        let accountId = getAccountId();
        if(accountId !== undefined) {
            let b = await orderStore.getOrdersByCourier(accountId);
            if(b === true) {
                newOrder.value = undefined;
            }
        }
    }
}
async function updateOrder(orderID: string, status: OrderStatus) {
    await orderStore.changeOrderStatus(orderID, status);
    let accountId = getAccountId();
    if(accountId !== undefined) {
        await orderStore.getOrdersByCourier(accountId);
    }
}
async function closeOrder(orderID: string, status: OrderStatus, code: number) {
    const isOK = await orderStore.changeOrderStatus(orderID, status, code);
    if(isOK) {
        await orderStore.getOrdersByCourier(getAccountId()!);
        new Notification('Course terminée ! + '+(order.value.price * (15/100)).toString()+' €', {vibrate: 200, image:"https://img.freepik.com/premium-vector/cartoon-money-payment-mobile-bank-electronic-transaction-transfer-money-via-online-mobile-app-vector-illustration-people-send-receive-money-online-hand-holding-smartphone-with-flowing-banknote_229548-2459.jpg?w=2000"})
    } else {
        new Notification('Code de validation incorrect', {vibrate: 200, image:"https://media.istockphoto.com/id/1332343413/vector/man-trying-to-login-into-his-devices-user-forgot-password-web-and-cyber-security-with-wrong.jpg?b=1&s=612x612&w=0&k=20&c=74UvzayDfGfVgkj8kOsuLxcWVzwLb5wz8PT_pzB_cy4="})
    }
    
}
</script>

<template>
    <CourierHeader icon="fa-solid fa-user" link="/courier/account"/>
    <div class="ordersContent">
        <div v-if="newOrder" class="money">+ {{ newOrder.price * (15/100)}} €</div>
        <div v-if="getCurrentOrder" class="money">+ {{getCurrentOrder.price * (15/100)}} €</div>
        <div class="map">
            <!-- <Map :courier-lat-long="[47.42322, -1.239482]" :restau-lat-long="[47.41322, -1.219482]"/> -->
            <iframe width="100%" height="100%" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.openstreetmap.org/export/embed.html?bbox=1.4372348785400393%2C43.550292439442046%2C1.5175724029541016%2C43.59127323815584&amp;layer=mapnik&amp;marker=43.57078632436008%2C1.4774036407470703" style="border: 1px solid black"></iframe>
            <!-- <h2 v-if="!newOrder && !getCurrentOrder">Aucune commandes actuellement disponible ...</h2> -->
        </div>
        <div class="address" v-if="newOrder">
            <span class="restau-name">{{ newOrder.restaurant_name }}</span>
            <span>{{ newOrder.restaurant_address?.street_number }} {{ newOrder.restaurant_address?.street_name }}</span>
            <span>{{ newOrder.restaurant_address?.postal_code }} {{ newOrder.restaurant_address?.city }}</span>
        </div>
        <div class="address" v-if="getCurrentOrder">
            <span class="restau-name">{{ getCurrentOrder.restaurant_name }}</span>
            <span>{{ getCurrentOrder.restaurant_address?.street_number }} {{ getCurrentOrder.restaurant_address?.street_name }}</span>
            <span>{{ getCurrentOrder.restaurant_address?.postal_code }} {{ getCurrentOrder.restaurant_address?.city }}</span>
        </div>
    </div>
    <div class="courierBottom">
        <div v-if="!getCurrentOrder" class="tinderButton close" @click="refuseOrder()"><i class="fa-solid fa-xmark"></i></div>
        <div v-if="!getCurrentOrder" class="tinderButton bike" @click="acceptOrder(newOrder?._id!)"><i class="fa-solid fa-bicycle"></i></div>
        <div v-if="getCurrentOrder?.status === OrderStatus.in_preparation" class="retrieveButton" @click="updateOrder(order._id!, OrderStatus.in_delivery)">Commande récupérée</div>
       <form v-if="getCurrentOrder?.status === OrderStatus.in_delivery" @submit.prevent="closeOrder(order._id!, OrderStatus.delivered, constructCode())">
            <div class="code">
                <input id="code1" maxlength="1" type="number" v-model="code1" placeholder="_">
                <input id="code2" maxlength="1" type="number" v-model="code2" placeholder="_">
                <input id="code3" maxlength="1" type="number" v-model="code3" placeholder="_">
                <input id="code4" maxlength="1" type="number" v-model="code4" placeholder="_">
            </div>
            <button type="submit" class="validateButton">Valider la commande</button>
       </form>
    </div>
</template>

<style scoped lang="scss">
.ordersContent {
    background-color: white;
    width: 100%;
    height:100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    border-radius: 5px;
    .money {
        position: relative;
        top:5%;
        width:20%;
        height: 10%;
        background-color: rgba(43, 43, 43, 0.5);
        border-radius: 25px;
        display: flex;
        align-items: center;
        justify-content: center;
        color:white;
        font-size: 20px;
        font-weight: bold;
    }
    .map {
        width: 100%;
        height: 80%;
    }
    .address {
        width: 100%;
        height: 20%;
        display: flex;
        flex-direction: column;
        justify-content:space-evenly;
        border-top:1px black solid;
        span {
            margin-left: 20px;
        }
    }
    h2 {
        text-align: center;
    }
}
.restau-name {
    font-weight: bold;
    font-size: 20px;
}
.courierBottom {
    width: 100%;
    height: fit-content;
    display: flex;
    align-items: center;
    justify-content:space-around;
    margin: 20px 0;
}
/* BUTTONS */
.tinderButton {
    background-color: white;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50px;
    width:70px;
    height: 70px;
    border: 4px rgb(0,0,0,0) solid;
    i {
        font-size: 40px;
    }
}
.retrieveButton {
    display: flex;
    justify-content: center;
    align-items: center;
    color:white;
    font-size: 20px;
    width: 245px;
    height: 53.97px;
    background: #3EBC72;
    border-radius: 25px;
    &:hover {
        cursor: pointer;
    }
}
.close:hover {
    animation: 1s 1 borderRed forwards;
    cursor: pointer;
}
.bike:hover {
    cursor: pointer;
    animation: 1s 1 borderGreen forwards;
}
.fa-xmark {
    color:red;
}
.fa-bicycle {
    color:#3EBC72;
}
.code{
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap:10px;
}

.code input{
    background-color: black;
    border-color: transparent;
    border-radius: 5px;
    width: 30px;
    height: 50px;
    color: white;
    font-size: 20px;
    text-align: center;
}

@keyframes borderRed {
    25% {border-left: 4px red solid;}
    50% {border-left: 4px red solid; border-top: 4px red solid;}
    75% {border-left: 4px red solid; border-top: 4px red solid;
        border-right: 4px red solid;}
    100% {border-left: 4px red solid; border-top: 4px red solid;
        border-right: 4px red solid;border-bottom: 4px red solid;}
}
@keyframes borderGreen {
    25% {border-left: 4px #3EBC72 solid;}
    50% {border-left: 4px #3EBC72 solid; border-top: 4px #3EBC72 solid;}
    75% {border-left: 4px #3EBC72 solid; border-top: 4px #3EBC72 solid;
        border-right: 4px #3EBC72 solid;}
    100% {border-left: 4px #3EBC72 solid; border-top: 4px #3EBC72 solid;
        border-right: 4px #3EBC72 solid;border-bottom: 4px #3EBC72 solid;}
}
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}
</style>