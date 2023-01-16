<script setup lang="ts">
import { defineComponent, onMounted } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { products } from '@/assets/products'
import CardRestaurant from '@/components/CardRestaurant.vue'
import HeaderContent from '@/components/HeaderContent.vue'
// Caroussel
import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'
import { useRestaurantStore } from '@/stores/restaurant';
import { storeToRefs } from 'pinia'

const carouselSettings = {
  itemsToShow: 2,
  snapAlign: 'center',
}
const carouselBreakPoints = {
  // 200 and up
  200: {
    itemsToShow: 2,
    snapAlign: 'center',
  },
  // 400 and up
  400: {
    itemsToShow: 6,
    snapAlign: 'center',
  },
  // 700px and up
  700: {
    itemsToShow: 8,
    snapAlign: 'center',
  },
  // 1024 and up
  1024: {
    itemsToShow: 10,
    snapAlign: 'start',
  },
  // 1268 and up
  1268: {
    itemsToShow: 14,
    snapAlign: 'start',
  },
}
defineComponent({
  Carousel,
  Slide,
  Pagination,
  Navigation,
  CardRestaurant,
  HeaderContent
});
const restaurantStore = useRestaurantStore();
const { restaurantsList, error } = storeToRefs(restaurantStore);
onMounted(async () => {
  await restaurantStore.getRestaurants('');
})
let searchValue: string;

</script>

<template>
  <HeaderContent class="header"/>
    <div class="top">
      <div class="title">
        <h1 class="title">Enjoy a good meal</h1>
        <img class="vegetables" src="@/assets/freshVegetable.png" width="170px" style="position:relative; left:10px; bottom:20px;">
      </div>
      <div class="searchBar">
          <div class="searchBarInputArea">
            <div class="localisation">
              <i class="fa-solid fa-location-dot fa-xl"></i>
              <input value="" placeholder="Localisation">
            </div>
            <input v-model="searchValue" class="inputSearch" type="text" placeholder="Which dishes are you looking for ?"/>
          </div>
          <input class="searchButton" type="button" value="Search" @click="restaurantStore.getRestaurants('?name='+searchValue)">
      </div>
      <Carousel class="carousel" :settings="carouselSettings" :breakpoints="carouselBreakPoints">
      <Slide v-for="(product, i) in products" :key="i">
        <div class="carousel_item">
          <img :src="product.image" width="40" height="40">
          <span>Test</span>
        </div>
      </Slide>

      <template #addons>
        <Navigation />
      </template>
    </Carousel>
  </div>
  <div class="shopsElements">
    <div v-for="(restaurant) in restaurantsList">
      <router-link :to="{name: 'restaurant-selection', params: {id: restaurant._id}}">
        <CardRestaurant class="card-restaurant" :restaurant=restaurant />
      </router-link>
    </div>
  </div>
 </template>

<style lang="scss" scoped>

  *{
    color: black;
  }

  a {
    text-decoration: none;
  }
  .top{
    width: 100%;
    display: flex;
    flex-direction: column;
    background-color: #D8E3E2;
  }

.header{
    position: sticky; top: 0;
    z-index: 1;
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
  margin-bottom: 20px;
}

  .bottom{
    background-color: white;
    width: 100%;
    margin-top: 80px;
  }

  .title{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: center;
    margin: 20px;
  }

/* Barre de recherche */
  .searchBar{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: space-between;
    flex-wrap: wrap;
    bottom: 25px;
    left: 30px;
    width: calc(100% - 30px)
  }


  .searchButton{
    background-color: #3EBC72;
    color: white;
    border: none;
    border-radius: 10px;
    font-size: 15px;
    padding: 5px;
    padding-left: 20px;
    padding-right: 20px;
    margin-top: 2px;
    margin-left: 30px;
    &:hover {
      cursor: pointer;
    }
  }

  .inputSearch{
    border: 1px solid #DEDEDE;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 10px;
    border-width: 1px;
    border-color: rgb(165, 163, 163);
    width: 220px;
    height: 30px;
    padding-left: 10px;
  }

  .searchBarInputArea{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: center;
    gap: 3px;
    height: 30px;
  }

  .localisation{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 13px;
    margin-top: 15px;
  }

  .localisation input{
    border: none;
    width: 100px;
    height: 20px;
    font-size: 15px;
    background-color: transparent;
    text-align: center;
    color: rgb(155, 27, 17)
  }

  .inputSearch:focus{
    outline: none;
  }

  .localisation input:focus{
    outline: none;
  }

  .carousel{
    margin:30px 0px;
    width: 100%;
  }

  .carousel_item{
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
  }

.card-restaurant {
  width:300px;
}
.card-restaurant:hover {
  cursor: pointer;
}
.shopsElements{
  display: flex;
  justify-content:space-evenly;
  flex-wrap: wrap;
  row-gap: 30px;
  margin: 40px;
}

.restaurantName{
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 16px;
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

@media screen and (max-width: 800px) {
  .title{
    display: none;
  }

.top{
  margin-bottom: 30px;
}

}

</style>
