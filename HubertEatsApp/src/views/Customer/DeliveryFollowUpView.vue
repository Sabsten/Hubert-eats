<script setup lang="ts">
import { defineComponent, onMounted } from 'vue'
import HeaderContent from '@/components/HeaderContent.vue'
import { useCustomerStore } from '@/stores/customer';
import { io } from "socket.io-client";
import { useCartStore } from '@/stores/cart';
import { storeToRefs } from 'pinia';
import { useOrderStore } from '@/stores/order';
import { getAccountId } from '@/stores/auth';
import { OrderStatus, type IOrders } from '@/models/order';
const customerStore = useCustomerStore();
const orderStore = useOrderStore();
const {order} = storeToRefs(orderStore);
defineComponent({
    HeaderContent
});

onMounted(async () => {
    await customerStore.getCustomerAccount();
    await orderStore.getOrdersByCustomer(getAccountId()!);
    const socket = io(import.meta.env.VITE_ORDER_SOCKET_URL);
    socket.on('ORDER-'+orderStore.getCurrentOrder?._id, (status: OrderStatus) => {
        order.value.status = status;
        if(status === OrderStatus.in_preparation) {
            new window.Notification('Commande en préparation par le restaurant ' + order.value.restaurant_name, {vibrate: 500, image:"https://img.freepik.com/free-vector/chef-concept-illustration_114360-1219.jpg?w=360"});
        }
        if (status === OrderStatus.in_delivery) {
            new window.Notification('Commande prise en charge par notre livreur', {vibrate: 500, image:"https://img.freepik.com/vecteurs-libre/paquet-expedition-par-messagerie-plat-illustration-cyclomoteur_74855-5227.jpg?w=2000"});
        }
    })
})
</script>

<template>
   <div class="page">
        <HeaderContent class="header"/> 

        <div class="top">
            <div class="map">
                <div class="map__container">
                    <iframe frameborder="0" width="100%" height="360px" scrolling="no" marginheight="0" marginwidth="0" src="https://www.openstreetmap.org/export/embed.html?bbox=1.4372348785400393%2C43.550292439442046%2C1.5175724029541016%2C43.59127323815584&amp;layer=mapnik&amp;marker=43.57078632436008%2C1.4774036407470703" style="border: 1px solid black"></iframe>
                </div>
            </div>
            <div class="profile">
                <div class="name">
                    John Doe
                </div>
                <div class="rate"> 4.4 </div>
                <hr size="1" color="black" width="80%">
                <div class="txtConfirm">Code de confirmation</div>
                <div class="code">
                    <input id="code1" maxlength="1" type="number" :value="[...order.validation_code+''][0]" readonly>
                    <input id="code2" maxlength="1" type="number" :value="[...order.validation_code+''][1]" readonly>
                    <input id="code3" maxlength="1" type="number" :value="[...order.validation_code+''][2]" readonly>
                    <input id="code4" maxlength="1" type="number" :value="[...order.validation_code+''][3]" readonly>
                </div>
                <hr size="1" color="black" width="80%">
                <div class="support">
                    <span>Un problème avec votre demande ?</span>
                    <input type="button" value="Contacter le support">
                </div>
            </div>
        </div>
        
        <div class="progressionMessage">Progression:</div>
        <div class="bottom">
            <div class="grey" v-if="order.status !== OrderStatus.paid && order.status !== OrderStatus.in_preparation
            && order.status !== OrderStatus.in_delivery">
                <i class="fa-solid fa-file-circle-check fa-2xl"></i>
                <span>Commande payé</span>
            </div>
            <div class="green" v-if="order.status === OrderStatus.paid || order.status === OrderStatus.in_preparation
            || order.status === OrderStatus.in_delivery">
                <i class="fa-solid fa-file-circle-check fa-2xl"></i>
                <span>Commande payé</span>
            </div>

            <hr size="3" color="grey" width="50%" v-if="order.status !== OrderStatus.in_preparation && order.status !== OrderStatus.in_delivery">
            <hr size="3" color="#3EBC72" width="50%" v-if="order.status === OrderStatus.in_preparation || order.status === OrderStatus.in_delivery">

            <div class="grey" v-if="order.status !== OrderStatus.in_preparation && order.status !== OrderStatus.in_delivery">
                <i class="fa-solid fa-utensils fa-2xl"></i>
                <span>Commande en préparation</span>
            </div>
            <div class="green" v-if="order.status === OrderStatus.in_preparation || order.status === OrderStatus.in_delivery">
                <i class="fa-solid fa-utensils fa-2xl"></i>
                <span>Commande en préparation</span>
            </div>

            <hr size="3" color="grey" width="50%" v-if="order.status !== OrderStatus.in_delivery">
            <hr size="3" color="#3EBC72" width="50%" v-if="order.status === OrderStatus.in_delivery">

            <div class="grey" v-if="order.status !== OrderStatus.in_delivery">
                <i class="fa-sharp fa-solid fa-person-biking fa-2xl"></i>
                <span>Livraison en cours</span>
            </div>
            <div class="green" v-if="order.status === OrderStatus.in_delivery">
                <i class="fa-sharp fa-solid fa-person-biking fa-2xl"></i>
                <span>Livraison en cours</span>
            </div> 
        </div>
        <div class="support2">
                <span>Un problème avec votre demande ?</span>
                <input type="button" value="Contacter le support">
        </div>
    </div>
</template>

<style lang="scss" scoped> 
.header{
    background-color: var(--light-green);
}
.top{
    display: flex;
    flex-direction: row;
    width: 100vw;
    align-items: center;
}

.bottom{
    display: flex;
    flex-direction: row;
    margin: 0 50px;
    align-items: center;
    justify-content: center;
    height: 10vh;
    margin-top: 50px;
    padding: 0px 40px;
}

i{
    width: 40px;
    height: 40px;
    margin-bottom: 0px;
}
.green{
    i {
        color:#3EBC72;
    }
    span {
        color: #3EBC72;
    }
}
.grey{
    i {
        color:grey;
    }
    span {
        color:grey;
    }
}
.bottom div{
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 100%;
    text-align: center;
}

.bottom hr{
    position: relative;
    bottom: 40px;
}

.map{
    background-color: grey;
    width: 70%;
    height: 50vh;
}

.profile{
    width: 30%;
}

.rate{
    text-align: center;
  padding: 10px;
  background-image: url(@/assets/star.png);
  background-repeat: no-repeat;
  background-size: 40px;
  background-position: 50% -7px;
  font-size: 10px;
  color: white;
  font-weight: bold;
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

/* Hide arrow in the input field */
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

.name{
    font-size: 30px;
    font-weight: bold;
    margin: 5px 0px;
    text-align: center;
}

.txtConfirm{
    font-size: 20px;
    font-weight: bold;
    margin: 20px 0px;
    text-align: center;
}

.support, .support2{
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px 0px;
    gap: 10px;
    margin-top: 50px;
    text-align: center;
}

.support input , .support2 input{
    border-color: transparent;
    background: #E0E0E0;
    border-radius: 20px;
    width: 150px;
    height: 40px;
    font-size: 15px;
    font-weight: 400;
    text-align: center;
}

.support2{
    display: none;
}

.progressionMessage{
    font-size: 20px;
    font-weight: bold;
    text-align: center;
    text-decoration: underline;
    margin-top: 30px;
    display: none;
}

@media screen and (max-width: 600px) {
.top{
    display:block;
}

.map, .profile{
    width: 100%;
}

.support{
    display: none;
}

.support2{
    display: flex;
}

.progressionMessage{
    display: block;
}

}

</style>