<script setup lang="ts">
import { defineComponent, onMounted, ref, type Ref } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'
import CardPayment from '@/components/CardPayment.vue'
import { useCartStore } from '@/stores/cart';
import { storeToRefs } from 'pinia';
import { useCustomerStore } from '@/stores/customer';
import { useOrderStore } from '@/stores/order';
import { getAccountId } from '@/stores/auth';

const routeLocation = useRoute()
const router = useRouter()
const goBack = () => {
    router.go(-1)
}
defineComponent({
    CardPayment,
})
const customerStore = useCustomerStore();
let { customerAccount } = storeToRefs(customerStore);
const cartStore = useCartStore();
let { cart, totalPrice } = storeToRefs(cartStore);
const orderStore = useOrderStore();

let errorMessage: Ref<string | null> = ref(null);

async function pay() {
    let isOk: boolean = await orderStore.payOrder(cart.value.articles, getAccountId()!, cart.value.restaurant_id, totalPrice.value)
    if(!isOk){
        errorMessage.value = 'Problème au niveau de paiement'
    } else {
        router.push('/');
    }
}
onMounted(async () => {
    customerStore.getCustomerAccount();
})
</script>

<template>
   <div class="page">
    <div class="left-part">
        <div class="left-header">
            <i class="fa-solid fa-circle-arrow-left fa-2xl" @click="goBack()"></i>
            <img src="@/assets/HubertEatsLogo.png" width="250">
            <div></div>
        </div>
        <div class="left-body">
            <div class="address">
                <i class="fa-solid fa-location-dot"></i>
                <div class="editAddress">
                    <div class="name">{{customerAccount?.address.street_number}} {{customerAccount?.address.street_name}}</div>
                    <div class="name">{{customerAccount?.address.postal_code}} {{customerAccount?.address.city}}</div>
                </div>
                <i class="fa-solid fa-pen-to-square"></i>
            </div>
            <CardPayment></CardPayment>
            <input class="confirm" type="button" :value="'Payer '+totalPrice+' €'" @click="pay()">
            <span v-if="errorMessage">{{ errorMessage }}</span>
        </div>
    </div>
    <div class="right-part">
        <div class="element">
            <div class="shop">
                <h1>{{cart.restaurant_name}}</h1>
            </div>
            <div v-for="article in cart.articles">
                <div class="elementInfo">
                    <div class="description">
                        <div class="name">{{article.name}}</div>
                        <div class="price">prix : {{article.price}} €</div>
                        <div class="quantity">quantité : {{article.quantity}}</div>
                        <div class="quantity">total : {{article.price * article.quantity}} €</div>
                    </div>
                    <div class="image">
                        <img :src="article.image" width="100" height="100">
                    </div>
                </div>
            <hr size="2" color="black">
            </div>
        </div>
        <div class="total">
            <div class="name">Total</div>
            <div class="price">{{ totalPrice }} €</div>
        </div>
    </div>
  </div>
</template>
  
<style lang="scss" scoped>
.page {
    display: flex;
    flex-direction: row;
    width: 100%;
    height: 100vh;
}

.confirm{
    background-color: var(--green);
    color: white;
    padding: 10px 40px;
    font-weight: 700;
    font-size: 20px;
    border-color: transparent;
    border-radius: 10px;
    margin-top: 20px;
    &:hover {
        cursor: pointer;
    }
}

.right-part{
    background-color: var(--light-green);
    min-height: 100vh;
    padding: 0px 20px;
    width: 40%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.left-part{
    display: grid;
    grid-template-rows: 1fr 5fr;
    width:60%;
}

.left-header{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    width: 100%;
}

.left-body{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    row-gap: 40px;
}

.name{
    font-size: 20px;
}
.address {
    display: flex;
    align-items: center;
    column-gap: 20px;
    i {
        font-size: 24px;
        &:hover {
            cursor:pointer;
        }
    }
}
.total{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    margin-top: 20px;
    width: 100%;
    font-size: 20px;
    font-weight: 800;
}

.elementInfo{
    display:flex;
    flex-direction: row;
    justify-content: space-between;
    width: 100%;
    margin-bottom: 20px;
    flex-wrap: wrap;
}

.element{
    width: 100%;
}

.shop{
    margin-bottom: 50px;
}

</style>
  