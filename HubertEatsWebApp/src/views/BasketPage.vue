<template>
  <div class="page">
    <div class="header">
    <div class="title">Panier</div>
    <input class="commandButton" type="button" @click="goToCommands()" value="Mes commandes">
    </div>
    <div class="table-wrapper" v-if="facts.length !== 0">
      <div class="table-scroll">
        <table class="FactTable" cellspacing="20" cellpadding="0">
          <tr class="clickable" v-for="(fact, i) in facts" :key="i"
            @click="goToFact(i)">
            <td class="image-description">
              <div class="picRow">
                <img :src="fact.image" width="75" height="75" class="pic" />
              </div>
              <div class="descriptionRow">
                <div class="restaurantName">{{ fact.text }}</div>
                <div class="address">{{ fact.text }}</div>
              </div>
            </td>
          </tr>
        </table>
      </div>
    </div>

    <div class="noItems" v-if="facts.length === 0">
      <img src="@/assets/cart.png" width="200" height="200" />
      <div class="noItemText1">Ajoutez des articles pour commencer un panier</div>
      <div class="noItemText2">Une fois que vous avez ajouté des plats d'un restaurant ou les articles d'un magasin, votre panier s'affiche ici</div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { facts } from '@/assets/basket'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const router = useRouter()
    const goToFact = (id: number) => {
      router.push({ path: `/fact/${id}` })
    };
    const goToCommands = () => {
      router.push({ path: `/my-orders` })
    };
    return { facts, goToFact, goToCommands}
  }
})
//get the current height of the window
</script>

<style scoped>
.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin-top: 0px;
  margin-bottom: 0px;
  margin-left: 20px;
  margin-right: 20px;
}
.title {
  font-size: 50px;
  font-weight: bold;
  margin-top: 40px;
  margin-bottom: 20px;
  font-family: helvetica;
}
.clickable {
  cursor: pointer;
}

.commandButton{
  border: 1px solid black;
  border-radius: 5px;
  padding: 7px 7px 7px 7px;
  font-family: helvetica;
  font-size: 14;
}

/* Allow the table to be scrollable */
.table-scroll {
  overflow: auto;
  max-height: 75vh;
}

/* Wrapper contains all the table and the scroll*/
.table-wrapper table * {
  background: white;
  color: black;
}
.table-wrapper table {
  width: 100%;
}

.pic {
  border-radius: 50%;
  margin: 10px;
  border: 1px solid black;
}

 .descriptionRow{
  height: 100px;
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  justify-content: space-around;
  margin-left: 10px;
} 

.image-description{
  display: grid;
  grid-template-columns: 20vw 70vw;
}
/* Container width if screen too tall */
@media (min-width:1000px) {
  .image-description{
    display: grid;
    grid-template-columns: 200px 700px;
  }
}

.restaurantName{
  font-size: 16px;
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
}
.address{
  font-size: 14px;
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
}

.noItems{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: start;
  width: 100%;
  font-family: helvetica;
  font-size: 20px;
  gap: 30px;
  margin-top: 40px;
}

.noItemText1{
  margin-left: 10px;
  font-family: helvetica;
  font-size: 20px;
  font-weight: bold;
}
.noItemText2{
  margin-left: 20px;
  margin-right: 20px;
  text-align: center;
  max-width: 500px;
  font-size: 16px;
  font-family: helvetica;
}
</style>
