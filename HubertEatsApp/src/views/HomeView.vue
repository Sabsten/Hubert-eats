<script lang="ts">
import { defineComponent } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { products } from '@/assets/products'
import CardRestaurant from '@/components/CardRestaurant.vue'
import HeaderContent from '@/components/HeaderContent.vue'

// Caroussel
import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'

export default defineComponent({
  data: () => ({
    // carousel settings
    settings: {
      itemsToShow: 1,
      snapAlign: 'center',
    },
    // breakpoints are mobile first
    // any settings not specified will fallback to the carousel settings
    breakpoints: {
      // 700px and up
      700: {
        itemsToShow: 3.5,
        snapAlign: 'center',
      },
      // 1024 and up
      1024: {
        itemsToShow: 5,
        snapAlign: 'start',
      },
    },
  }),
  setup() {
    const router = useRouter()
    let input = ref("");
    const goToFact = (id: number) => {
      router.push({ path: `/restaurantPage/${id}` })
    }
    return { products, goToFact, input}

  },

  components: {
    Carousel,
    Slide,
    Pagination,
    Navigation,
    CardRestaurant,
    HeaderContent
  }
})
</script>

<template>
  <div class="page">
      <div class="top">
        <HeaderContent/>
        <div class="title"> 
          <h1>
            Enjoy a good meal
          </h1>
          <img src="@/assets/freshVegetable.png" width="170" style="position:relative; bottom:40px;">
        </div>
        <div class="searchBar">
          <div class="searchBarLeftPart">
            <input class="inputSearch" type="email" id="email" name="email" placeholder="Which dishes are you looking for ?"/> 
            <input class="searchButton" type="button" value="Search">
          </div>
          
          <Carousel class="carousel" :settings="settings" :breakpoints="breakpoints">
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
      </div>
      <div class="bottom">
          <div class="table-scroll">
            <div class="shopsElements" cellspacing="10" cellpadding="0">
              <div v-for="(product, i) in products" :key="i" @click="goToFact(i)">
                <CardRestaurant :element=product />
              </div>
            </div>
        </div>
      </div>
  </div>
</template>

<style scoped>
  *{
    color: black;
  }

  .page{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    height: calc(100% - 122px);
    flex-direction: column;
    background-color: #D8E3E2;
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
    height: calc(100% - 150px);
    margin-top: 80px;
  }

  .title{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: center;
    margin: 20px;
    gap: 20px;
  }

  .top{
    width: 100%;
    height: 150px;
    margin-bottom: 40px;
  }

/* Barre de recherche */
  .searchBar{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: space-between;
    position: relative;
    bottom: 40px;
    left: 30px;
    width: calc(100% - 30px);
  }

  .searchBarLeftPart{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: center;
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
  }

  .inputSearch{
    border: 1px solid #DEDEDE;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 10px;
    border-width: 1px;
    border-color: rgb(165, 163, 163);
    width: 220px;
    height: 30px;
  }

  .inputSearch:focus{
    outline: none;
  }

  .carousel{
    width: 50%;
    height: 50px;
    margin-left: 20px;
  }

  .carousel_item{
    display: flex;
    flex-direction: column;
  }


/* Allow the table to be scrollable */
.table-scroll {
  overflow: auto;
  height: 100%;
}




.shopsElements{
  display: flex;
  flex-direction: row;
  gap: 40px;
  justify-content: flex-start;
  margin: 20px;
  align-items: center;
  flex-wrap: wrap;
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

</style>
