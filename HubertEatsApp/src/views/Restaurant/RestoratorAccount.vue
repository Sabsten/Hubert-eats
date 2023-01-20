<script setup lang="ts">
import { defineComponent, onMounted, ref, type Ref } from 'vue'
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
const { orders, getOrdersHistory} = storeToRefs(orderStore);
const restaurantStore = useRestaurantStore();
const { restaurantAccount} = storeToRefs(restaurantStore);

onMounted(async () => {
  let accountId = getAccountId();
  if(accountId !== undefined) {
    await orderStore.getOrdersByRestaurant(accountId);
    await restaurantStore.getRestaurantAccount(accountId);
    console.log(restaurantAccount.value);
  }
});

let editionMode: Ref<boolean> = ref(false);

async function updateRestaurantAcount() {
  // await restaurantStore.updateRestaurantAcount();
  await orderStore.getOrdersByRestaurant(getAccountId()!);
  editionMode.value = false;
}

</script>

<template>
   <div class="page">
    <HeaderContent class="header"/> 
    <div class="content_">
      <div class="left-part">
        <form class="personalInformationsForm" @submit="updateRestaurantAcount()">
          <div  v-if="!editionMode" class="customer-info">
            <div class="name">
              {{ restaurantAccount?.name }}
              <i class="fa-solid fa-pen-to-square" @click="editionMode = true"></i>
            </div>
            <span><u>Email :</u>&nbsp;{{ restaurantAccount?.account?.mail }}</span>
              <span><u>Adresse :</u></span>
            <span>{{ restaurantAccount?.address?.street_number }}&nbsp;{{ restaurantAccount?.address?.street_name }}</span>
            <span>{{ restaurantAccount?.address?.postal_code }},&nbsp;{{ restaurantAccount?.address?.city }}</span>
            <span><u>Parrain :</u>&nbsp;{{ restaurantAccount?.account?.referent }}</span>
          </div>
          <div class="customer-form" v-if="editionMode">
            <div class="info-line">
              <span>Nom du restaurant : </span>
              <input type="text" v-model="restaurantAccount!.name" class="inputForm">
            </div>
            <div class="info-line">
              <span>Email : </span>
              <input type="email" v-model="restaurantAccount!.account.mail" class="inputForm">
            </div>
            <div class="info-line">
              <span>Mot de passe : </span>
              <input type="password" v-model="restaurantAccount!.account.password" class="inputForm">
            </div>
            <div class="info-line">
              <span>Nom de la rue : </span>
              <input type="text" v-model="restaurantAccount!.address.street_name" class="inputForm">
            </div>
            <div class="info-line">
              <span>N° de rue : </span>
              <input type="number" v-model="restaurantAccount!.address.street_number" class="inputForm">
            </div>
            <div class="info-line">
              <span>Code postal : </span>
              <input type="text" v-model="restaurantAccount!.address.postal_code" class="inputForm">
            </div>
            <div class="info-line">
              <span>Ville : </span>
              <input type="text" v-model="restaurantAccount!.address.city" class="inputForm">
            </div>
            <div>
              <button class="form-button modif-button" type="submit">Modifier</button>
              <button class="form-button cancel-button" @click="editionMode = false">Annuler</button>
            </div>
          </div>
        </form>

    </div> 
      
      <div class="commandsHistory">
        <div class="name">
          Historique des commandes <i class="fa-solid fa-receipt"></i>
        </div>
        <div v-for="order in getOrdersHistory">
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
.customer-info {
  display: flex;
  flex-direction: column;
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

.customer-form {
  display: flex;
  flex-direction: column;
  row-gap: 10px;
}
.info-line {
  display: flex;
  flex-direction: column;
}
.customer-info {
  display: flex;
  flex-direction: column;
  row-gap: 20px;
}
.form-button {
  padding: 10px 30px;
  border-radius: 20px;
  font-size: 15px;
  border: none;
  font-size: 15px;
  margin-right: 10px;
}

.modif-button {
  background-color: #3EBC72;
  color: white;
}
.cancel-button {
  background-color: red;
  color: white;
}
</style>
  