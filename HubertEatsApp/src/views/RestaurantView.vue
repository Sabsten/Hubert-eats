<script setup lang="ts">
import { defineComponent, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { computed } from 'vue'
import CardProduct from '@/components/CardProduct.vue'
import HeaderContent from '@/components/HeaderContent.vue'
import { useInventoryStore } from '@/stores/inventory.js';
import { useRestaurantStore } from '@/stores/restaurant';

defineComponent({
  CardProduct,
  HeaderContent
});
const restaurantID: string = useRoute().params.id.toString();
const inventoryStore = useInventoryStore();
const restaurantStore = useRestaurantStore();
// const { restaurantsList, error } = storeToRefs(restaurantStore);

let cssVars = computed(() => {
  return {
    '--fact-image': `url(${restaurantStore.getCurrentRestaurant?.image})`
  }
});

onMounted(async () => {
  if (restaurantStore.$state.restaurantsList = []) {
    await restaurantStore.getRestaurants('');
  }
  inventoryStore.getInventory(restaurantID);
});

function scrollTo(anchor: string) {
  console.log("test ")
  const el = document.getElementById(anchor);
  el && el.scrollIntoView();
}

</script>

<template>
  <HeaderContent class="header"/>
  <div class="top">
    <div class="headerRestaurant">
        <div class="top-part-img" :style="cssVars"></div>
        <div class="top-part-text">
          <div class="restaurantTitle_grade">
            <h1>
              {{restaurantStore.getCurrentRestaurant?.name}}
            </h1>
            <div class="restaurantRate">{{ restaurantStore.getAverageRating(restaurantStore.getCurrentRestaurant?.rating) }}</div>
          </div>
          <h4>{{restaurantStore.getCurrentRestaurant?.address.street_number}}
            &nbsp;{{restaurantStore.getCurrentRestaurant?.address.street_name}}
            ,&nbsp;{{restaurantStore.getCurrentRestaurant?.address.city}}</h4>
        </div>
    </div>
  </div>
  <div class="main">
    <div class="nav-section">
      <div @click="scrollTo('starters')">Entrées</div>
      <div @click="scrollTo('mains')">Plats</div>
      <div @click="scrollTo('desserts')">Desserts</div>
      <div @click="scrollTo('drinks')">Boissons</div>
    </div>
    <div class="articles-section">
      <div id="starters" class="articles-type" v-if="inventoryStore.getStarters">
        <h2>Entrée</h2>
        <div class="shopsElements">
          <div class="element" v-for="product in inventoryStore.getStarters">
            <i class="fa-solid fa-circle-plus"></i>
            <CardProduct :article=product />
          </div>
        </div>
      </div>
      <div id="mains" class="articles-type" v-if="inventoryStore.getMains">
        <h2>Plats</h2>
        <div class="shopsElements">
          <div class="element" v-for="product in inventoryStore.getMains">
            <i class="fa-solid fa-circle-plus"></i>
            <CardProduct :article=product />
          </div>
        </div>
      </div>
      <div id="desserts" class="articles-type" v-if="inventoryStore.getDesserts">
        <h2>Desserts</h2>
        <div class="shopsElements">
          <div class="element" v-for="product in inventoryStore.getDesserts">
            <i class="fa-solid fa-circle-plus"></i>
            <CardProduct :article=product />
          </div>
        </div>
      </div>
      <div id="drinks" class="articles-type" v-if="inventoryStore.getDrinks">
        <h2>Boissons</h2>
        <div class="shopsElements">
          <div class="element" v-for="product in inventoryStore.getDrinks">
            <i class="fa-solid fa-circle-plus"></i>
            <CardProduct :article=product />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  *{
    color: black;
  }

  .header{
    position: sticky; top: 0;
    z-index: 1;
  }
  .restaurantTitle_grade{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    gap: 10px;
    height: 50px;
    margin-top: 30px
  }

  .top-part-img{
  width:80%;
  height: 200px;
  background-image: var(--fact-image);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

.top-part-text{
  position: relative;
  top: -20px;
}

  h1{
    font-family: 'Roboto';
    font-style: normal;
    font-weight: 700;
    font-size: 40px;
    line-height: 47px;
    display: flex;
    align-items: center;
    color: #000000;
  }

  p{
    font-family: 'Roboto';
  }

  .main{
    background-color: white;
    width: 100%;
    height: calc(100% - 150px);
    margin-top: 40px;
    padding-top: 200px;
    display: grid;
    grid-template-columns: 1fr 5fr;
    .nav-section {
      display: flex;
      flex-direction: column;
      row-gap: 25px;
      align-items: center;
      position: sticky;
      div:hover {
        text-decoration: underline;
        cursor: pointer;
      }
      div {
        font-size: 22px;
      }
    }
  }

  .top{
    width: 100%;
    height: 120px;
    margin-bottom: 40px;
    display: flex;
    flex-direction: column;
    text-align: center;
    background-color: #D8E3E2;
  }

.personnal{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  gap: 20px;
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 32px;
  line-height: 38px;
}


.headerRestaurant{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-right: 20px;
  margin-left: 20px;
}

/* Table */

.shopsElements{
  display: flex;
  flex-wrap: wrap;
  gap: 40px;
}
.element {
  width:300px;
  position: relative;
  i {
    font-size: xx-large;
    top:0;
    right:0;
    margin: 10px 10px 0 0;
    position: absolute;
  }
  i:hover {
      cursor: pointer;
    }
}

.restaurantName{
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 16px;
}

.restaurantRate{
  padding: 10px;
  background-image: url(@/assets/star.png);
  background-repeat: no-repeat;
  background-size: 35px;
  background-position: -3px -5px;
  font-size: 10px;
  color: white;
  font-weight: bold;
}

.articles-type {
  margin-bottom: 50px;
}
.articles-section {
  h2 {
    margin-top:0;
  }
}

</style>
