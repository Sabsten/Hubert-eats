<script setup lang="ts">
import { defineComponent, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'
import HeaderContent from '@/components/HeaderContentRestorator.vue'
import CardPayment from '@/components/CardPayment.vue'
import { useOrderStore } from '@/stores/order'
import { useRestaurantStore } from '@/stores/restaurant'
import { storeToRefs } from 'pinia'
import Order from '@/components/restaurant/Order.vue'
import { getAccountId } from '@/stores/auth'

defineComponent({
  HeaderContent,
    CardPayment,
    Order,
});
const routeLocation = useRoute()
const router = useRouter()
const goToCreateAccount = () => {
  router.push({ path: `/signup` })
}

const orderStore = useOrderStore();
const { orders, getRestaurantOrdersHistory} = storeToRefs(orderStore);
const restaurantStore = useRestaurantStore();
const { restaurantAccount} = storeToRefs(restaurantStore);

onMounted(async () => {
  let accountId = getAccountId();
  if(accountId !== undefined) {
    await orderStore.getOrdersByRestaurant(accountId);
    await restaurantStore.getRestaurantAccount(accountId);
  }
});

</script>

<template>
   <div class="page">
    <HeaderContent class="header"/> 
    <div class="content_">
      <div class="left-part">
        <form class="personalInformationsForm" @submit.prevent="">
          <div class="name">
            John Doe <i class="fa-solid fa-pen-to-square"></i>
          </div>
          <input placeholder="Adresse Postale" class="inputForm">
          <input placeholder="Adresse Mail" class="inputForm">
          <input placeholder="Mot De Passe" class="inputForm">
          <input placeholder="Parrainage" class="inputForm">
        </form>

    </div> 
      
      <div class="commandsHistory">
        <div class="name">
          Historique des commandes <i class="fa-solid fa-receipt"></i>
        </div>
        <div v-for="order in getRestaurantOrdersHistory">
          <Order :order="order"></Order>
        </div>
      </div>
    </div> 
  </div>
</template>
  
<style scoped>

.header{
  background-color: var(--light-green);
  margin-bottom: 50px;
}

.page{
    min-height: 100vh;
    width: 100%;
    display: flex;
    flex-direction: column;
}

.content_{
  justify-content: space-around;
  gap: 30px;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-items: top;
  margin-bottom: 30px;
}

.top-part{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-items: top;
  margin-bottom: 30px;
}

.left-part{
  display: flex;
  flex-direction: column;
  gap: 50px;
  width: 50%;
  min-width: 400px;
  max-width: 500px;
}

.name{
  font-size: 25px;
  display: flex;
  column-gap: 30px;
  font-weight: 700;
}

.personalInformationsForm{
  display: flex;
  flex-direction: column;
  gap: 20px;
  width: 30%;
  min-width: 400px;
}
.inputForm {
  width: 80%;
  height: 35px;
  border-radius: 5px;
  filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  padding-left: 10px;
}

.payment{
  display: flex;
  flex-direction: column;
  gap: 20px;
  max-width: 500px;
  margin-bottom: 10px;
}

.commandsHistory{
  display: flex;
  flex-direction: column;
  gap: 20px;
  min-width: 400px;
  max-width: 800px;
  align-items: left;
  justify-content: left;
  width: 50%;
}

.inputHistory {
  height: 85px;
  border-radius: 20px;
  filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
}

@media screen and (max-width: 700px) {
  .commandsHistory{
    width: 90%;
    min-width: 50px;
  }
  .left-part{
    min-width: 50px;
    width: 90%;
  }
  .personalInformationsForm{
    min-width: 50px;
    width: 90%;
  }

}

</style>
  