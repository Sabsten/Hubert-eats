<script lang="ts">
import { defineComponent } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { products } from '@/assets/products'
import CardRestaurant from '@/components/CardRestaurant.vue'
import HeaderContent from '@/components/HeaderContent.vue'
import WelcomeItem from '@/components/WelcomeItem.vue';

// Caroussel
import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'

export default defineComponent({
  data: () => ({
    // carousel settings
    settings: {
      itemsToShow: 2,
      snapAlign: 'center',
    },
    // breakpoints are mobile first
    // any settings not specified will fallback to the carousel settings
    breakpoints: {
      // 200 and up
      200: {
        itemsToShow: 2,
        snapAlign: 'center',
      },
      // 400 and up
      400: {
        itemsToShow: 4,
        snapAlign: 'center',
      },
      // 700px and up
      700: {
        itemsToShow: 8,
        snapAlign: 'center',
      },
      // 1024 and up
      1024: {
        itemsToShow: 8,
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
    HeaderContent,
    WelcomeItem
  }
})
</script>

<template>
  <div class="page">
      <div class="top">
        <HeaderContent/>
          <div class="afterHeader">
            <div class="title"> 
            <h1>
              Enjoy a good meal
            </h1>
            <img src="@/assets/freshVegetable.png" width="170" style="position:relative; left:10px; bottom:20px;">
          </div>
          <div class="searchBar">
              <div class="searchBarInputArea">
                <div class="localisation">
                  <i class="fa-solid fa-location-dot fa-xl"></i>
                  <input value="" placeholder="Localisation">
                </div>
                <input class="inputSearch" type="email" id="email" name="email" placeholder="Which dishes are you looking for ?"/>
              </div>
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

  <WelcomeItem class="element"/>


</template>

<style scoped>
.element{
  position:absolute;
  top: 0;
  max-height: 100vh;
  overflow: scroll;
}


  *{
    color: black;
  }

.page{
  display: flex;
  flex-direction: row;
  height: calc(100vh - 160px);
  justify-content: space-between;
  align-items: center;
  width: 100%;
  flex-direction: column;
  background-color: var(--light-green);
}

.top{
    width: 100%;
    height: 150px;
    margin-bottom: 80px;
  }

.afterHeader{
  position: relative;
  bottom: 50px;
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
  }

/* Barre de recherche */
  .searchBar{
    display: flex;
    flex-direction: row;
    justify-content: left;
    align-items: space-between;
    position: relative;
    flex-wrap: wrap;
    bottom: 30px;
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
    height: 50px;
    width: 100%;
  }

  .carousel_item{
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
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
  justify-content: center;
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
