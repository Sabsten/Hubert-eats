<script setup lang="ts">
import { useCartStore } from '@/stores/cart';
import { useRestaurantStore } from '@/stores/restaurant';
import { defineStore } from 'pinia';
import { defineComponent } from 'vue';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';
import { storeToRefs } from 'pinia';

const routeLocation = useRoute()
const router = useRouter()
const goToPurchase = () => {
  router.push({ path: `/customer/payment` })
}
const restaurantStore = useRestaurantStore();
const cartStore = useCartStore();
let { cart, totalPrice } = storeToRefs(cartStore);

</script>

<template>
  <div class="pageComponent">
    <div class="listOrder">
      <div class="element">
          <h1>{{ cart.restaurant_name }}</h1>
          <div v-for="article in cart.articles">
            <div class="elementInfo">
                <div class="add-sub">
                    <i class="fa-solid fa-minus pointer" @click="cartStore.removeToCart(article)"></i>
                    <span>{{article.quantity}}</span>
                    <i class="fa-solid fa-plus pointer" @click="cartStore.addQuantity(article)"></i>
                </div>
                <div class="description">
                    <div class="name">{{ article.name }}</div>
                    <div class="price">{{ article.price * article.quantity }}&nbsp;€</div>
                </div>
                <div class="image">
                    <img width="100px" :src="article.image">
                </div>
            </div>
            <hr size="1" color="white" width="100%">
          </div>
          <input type="button" @click="goToPurchase()" class="confirm pointer" :value="'Commander · '+totalPrice.toString()+'€'"> 
      </div>
    </div>
  </div>
</template>

<style scoped>

*{
color: white;
}
.pageComponent{
display: flex;
flex-direction: row;
min-height: 90vh;
justify-content: start;
align-items: center;
flex-direction: column;
background-color: var(--green);
}

.pointer:hover {
  cursor: pointer;
}
.listOrder{
  display:flex;
  flex-direction: column;
  gap: 10px;
}


.confirm{
  background-color: white;
  color: black;
  padding: 20px 40px;
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 20px;
  border-color: transparent;
  border-radius: 10px;
  margin-top: 20px;
}

.elementInfo{
  display: flex;
  flex-direction: row;
  gap: 20px;
  margin-bottom: 20px;
}

i{
  padding: 20px;
}

.name{
  font-size: 20px;
}

.element{
  display:flex;
  flex-direction: column;
  margin-bottom: 20px;
}

h1, h2{
  margin-bottom: 0px;
}
</style>
