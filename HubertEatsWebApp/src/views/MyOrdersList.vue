<template>
  <div class="page">
    <div class="header">
    <img src="@/assets/back.png" width="49" height="42" @click="goToBasket()">
    <div class="title">Vos commandes</div>
    </div>
    <div class="table-wrapper">
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
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { facts } from '@/assets/facts'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const router = useRouter()
    const goToFact = (id: number) => {
      router.push({ path: `/fact/${id}` })
    };
    const goToBasket = () => {
      router.push({ path: `/basket` })
    };
    return { facts, goToFact, goToBasket }
  }
})
//get the current height of the window
</script>

<style scoped>
.header {
  display: flex;
  flex-direction: row;
  justify-content: start;
  align-items: center;
  margin-top: 20px;
  margin-bottom: 0px;
  margin-left: 20px;
  margin-right: 20px;
  gap: 60px;
}
.title {
  font-size: 50px;
  font-weight: bold;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: helvetica;
}
.clickable {
  cursor: pointer;
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
</style>
