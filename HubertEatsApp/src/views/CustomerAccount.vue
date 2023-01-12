<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'
import HeaderContent from '@/components/HeaderContent.vue'
import CardPayment from '@/components/CardPayment.vue'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goToCreateAccount = () => {
    router.push({ path: `/signup` })
    }
  },
  components: {
    HeaderContent,
    CardPayment
  }
})
</script>

<template>
   <div class="page">
    <HeaderContent/> 
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

        <div class="payment">
          <div class="name">
            Mode de Paiement <i class="fa-solid fa-pen-to-square"></i>
          </div>
          <CardPayment/>
        </div>

    </div> 
      
      <div class="commandsHistory">
        <div class="name">
          Historique des commandes <i class="fa-solid fa-receipt"></i>
        </div>
        <input placeholder="Commande 1" class="inputHistory">
        <input placeholder="Commande 2" class="inputHistory">
        <input placeholder="Commande 3" class="inputHistory">
        <input placeholder="Commande 4" class="inputHistory">
      </div>
    </div> 
  </div>
</template>
  
<style scoped>

.page{
    min-height: 100vh;
    width: 100%;
    background-color: var(--light-green);
    display: flex;
    flex-direction: column;
}

.content_{
  justify-content: space-around;
  gap: 50px;
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


</style>
  