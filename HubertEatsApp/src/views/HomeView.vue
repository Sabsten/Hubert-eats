<script lang="ts">
import { defineComponent } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { products } from '@/assets/products'

// Caroussel
import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'

export default defineComponent({
  setup() {
    const router = useRouter()
    let input = ref("");
    const goToFact = (id: number) => {
      router.push({ path: `/fact/${id}` })
    }
    return { products, goToFact, input}

  },

  components: {
    Carousel,
    Slide,
    Pagination,
    Navigation
  }
})
</script>

<template>
  <div class="page">
      <div class="top">
        <div class="header">
            <img src="@/assets/HubertEatsLogo.png" width="150">
            <div class="personnal">
              <div>Basket</div>
              <div>Account</div>
            </div>
        </div>
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
          
          <carousel class="carousel" :items-to-show="5">
            <slide v-for="slide in 10" :key="slide">
              <div class="slide">{{ slide }}</div>
            </slide>

            <template #addons>
              <navigation class="pag" />
            </template>
          </carousel>
        </div>
      </div>
      <div class="bottom">
        <div class="table-wrapper">
          <div class="table-scroll">
            <div class="shopsElements" cellspacing="10" cellpadding="0">
              <div class="clickable" v-for="(product, i) in products" :key="i"
                @click="goToFact(i)">
                <td class="row-content">
                  <div class="left-part">
                    <div class="picRow">
                      <img :src="product.image" width="150" height="150" class="pic" />
                    </div>
                    <div class="descriptionRow">
                      <div class="descriptionRow1">
                        <div class="restaurantName">{{ product.text }}</div>
                        <div class="restaurantRate">{{ product.grade }}</div>
                      </div>
                      <div class="address">{{ product.address }}</div>
                    </div>
                  </div>
                </td>
              </div>
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
    height: calc(100% - 150px);
    flex-direction: column;
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
    width: 100%;
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

  .carousel{
    width: 300px;
    
  }




/* Allow the table to be scrollable */
.table-scroll {
  overflow: auto;
  height: 100%;
}

.table-wrapper{
  height: 100%;
}

.descriptionRow1{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
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

.restaurantRate{
  padding: 10px;
  background-image: url(@/assets/star.png);
  background-repeat: no-repeat;
  background-size: 35px;
  background-position: -1px -3px;
  font-size: 10px;
  color: white;
  font-weight: bold;
}

.header{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin: 20px;

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
