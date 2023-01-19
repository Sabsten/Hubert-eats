<script setup lang="ts">
import { defineComponent, onMounted, ref, type Ref } from 'vue'
import HeaderContent from '@/components/HeaderContent.vue'
import CardPayment from '@/components/CardPayment.vue'
import Order from '@/components/restaurant/Order.vue'
import { useCustomerStore } from '@/stores/customer'
import { storeToRefs } from 'pinia'
import { useOrderStore } from '@/stores/order'
import { getAccountId } from '@/stores/auth'

defineComponent({
  Order,
})

const customerStore = useCustomerStore();
const { customerAccount, error } = storeToRefs(customerStore);
const orderStore = useOrderStore();
const {orders} = storeToRefs(orderStore);

onMounted(() => {
  customerStore.getCustomerAccount();
});

const editionMode: Ref<boolean> = ref(false);

async function updateCustomerAcount() {
  await customerStore.updateCustomerAcount()
  await orderStore.getOrdersByCustomer(getAccountId()!);
  editionMode.value = false;
}

</script>

<template>
   <div class="page">
    <HeaderContent class="header"/> 
    <div class="content_">
      <div class="left-part">
        <form class="personalInformationsForm" @submit="updateCustomerAcount()">
          <div  v-if="!editionMode" class="customer-info">
            <div class="name">
              {{ customerAccount?.firstname }}&nbsp;{{ customerAccount?.lastname }}
              <i class="fa-solid fa-pen-to-square" @click="editionMode = true"></i>
            </div>
            <span><u>Email :</u>&nbsp;{{ customerAccount?.account.mail }}</span>
              <span><u>Adresse :</u></span>
            <span>{{ customerAccount?.address.street_number }}&nbsp;{{ customerAccount?.address.street_name }}</span>
            <span>{{ customerAccount?.address.postal_code }},&nbsp;{{ customerAccount?.address.city }}</span>
            <span><u>Parrain :</u>&nbsp;{{ customerAccount?.account.referent }}</span>
          </div>
          <div class="customer-form" v-if="editionMode">
            <div class="info-line">
              <span>Prénom : </span>
              <input type="text" v-model="customerAccount!.firstname" class="inputForm">
            </div>
            <div class="info-line">
              <span>Nom : </span>
              <input type="text" v-model="customerAccount!.lastname" class="inputForm">
            </div>
            <div class="info-line">
              <span>Email : </span>
              <input type="email" v-model="customerAccount!.account.mail" class="inputForm">
            </div>
            <div class="info-line">
              <span>Mot de passe : </span>
              <input type="password" v-model="customerAccount!.account.password" class="inputForm">
            </div>
            <div class="info-line">
              <span>Nom de la rue : </span>
              <input type="text" v-model="customerAccount!.address.street_name" class="inputForm">
            </div>
            <div class="info-line">
              <span>N° de rue : </span>
              <input type="number" v-model="customerAccount!.address.street_number" class="inputForm">
            </div>
            <div class="info-line">
              <span>Code postal : </span>
              <input type="text" v-model="customerAccount!.address.postal_code" class="inputForm">
            </div>
            <div class="info-line">
              <span>Ville : </span>
              <input type="text" v-model="customerAccount!.address.city" class="inputForm">
            </div>
            <div>
              <button class="form-button modif-button" type="submit">Modifier</button>
              <button class="form-button cancel-button" @click="editionMode = false">Annuler</button>
            </div>
          </div>
        </form>

        <!-- <div class="payment">
          <div class="name">
            Mode de Paiement <i class="fa-solid fa-pen-to-square"></i>
          </div>
          <CardPayment/>
        </div> -->

    </div> 
      
      <div class="commandsHistory">
        <div class="name">
          Historique des commandes <i class="fa-solid fa-receipt"></i>
        </div>
        <div v-for="order in orders">
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
  