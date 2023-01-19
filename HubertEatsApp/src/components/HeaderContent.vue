<script setup lang="ts">
import { defineComponent, onMounted } from 'vue'
import HeaderLink from './HeaderLinks.vue'
import { useRoute, useRouter } from 'vue-router'
import { useCartStore } from '@/stores/cart';
import { useOrderStore } from '@/stores/order';
import { getAccountId } from '@/stores/auth';
import { storeToRefs } from 'pinia';

defineComponent({
  HeaderLink,
})
const currentUrl = window.location.pathname;
const homePath = "/customer"
const route = useRoute();
const router = useRouter();
const cartStore = useCartStore();
const orderStore = useOrderStore();
const {getCurrentOrder} = storeToRefs(orderStore);

function logout() {
  router.push('/login');
  localStorage.removeItem('TOKEN');
}

onMounted(async () => {
  await orderStore.getOrdersByCustomer(getAccountId()!);
});

</script>
<template>
    <div class="content">
      <img src="@/assets/HubertEatsLogo.png" width="200">
      <div class="links">
        <HeaderLink v-if="route.query.cart!='true' && !getCurrentOrder" :to="route.fullPath+'?cart=true'">
          <button class="button cart-button" >
            <i class="fas fa-shopping-cart"></i>   Panier · <span>{{ cartStore.getArticlesNumber }}</span>
          </button>
        </HeaderLink>
        <HeaderLink v-if="route.query.cart=='true' && !getCurrentOrder" to="/customer">
          <button class="button cart-button" >
            <i class="fas fa-shopping-cart"></i>   Panier · <span>{{ cartStore.getArticlesNumber }}</span>
          </button>
        </HeaderLink>
        <HeaderLink v-if="getCurrentOrder" to="/customer/delivery">
          <button class="button cart-button" >
            <i class="fa-solid fa-bicycle"></i>Livraison
          </button>
        </HeaderLink>
        <HeaderLink v-if="currentUrl!=homePath" to="/customer">
          <button class="button account-button">
            <i class="fa-solid fa-house-user"></i>Accueil 
          </button>
        </HeaderLink>
        <HeaderLink v-if="currentUrl==homePath" to="/customer/account">
          <button class="button account-button">
            <i class="fa-solid fa-user"></i>Compte 
          </button>
        </HeaderLink>
        <i class="fa-solid fa-right-from-bracket logout" @click="logout()"></i>
      </div>
    </div>
  </template>
  
  <style lang="scss" scoped>
  .links{
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    justify-content: right;
    align-items: center;
    gap: 0px;
  }
.content{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  background-color: #D8E3E2;
}

.button {
  padding: 13px 40px;
  border-radius: 20px;
  font-size: 15px;
  border: none;
  font-size: 15px;
  margin-right: 10px;
  i{
    margin-right: 10px;
  }
}
.button:hover {
    cursor: pointer;
}

.cart-button {
  background-color: #3EBC72;
  color: white;
}

.account-button {
  background-color: #000000;
  color: white;
}
.logout {
  font-size: 24px;
  margin: 0 20px 0 10px;
  &:hover {
    cursor: pointer;
  }
}
  </style>