<script lang="ts">
import { defineComponent } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'
import { products } from '@/assets/products'
import { computed } from 'vue'
import CardProduct from '@/components/CardProduct.vue'
import HeaderContent from '@/components/HeaderContent.vue'

export default defineComponent({
  setup() {
    const router = useRouter()
    let input = ref("");
    const factId = computed(() => useRoute().params.id)
    return { products, input, factId}
  },
  computed: {
    cssVars() {
      return {
        '--fact-image': `url(${products[parseInt(useRoute().params.id[0])].image})`
      }
    }
  },
  components: {
    CardProduct,
    HeaderContent
  }
})

</script>

<template>
  <div class="page">
      <div class="top" z-index="300">
        <HeaderContent/>
        <div class="headerRestaurant">
            <div class="top-part-img" :style="cssVars" style="max-width:100%; height: 200px; min-width: 100%;"></div>
            <div class="top-part-text">
              <div class="restaurantTitle_grade">
                <h1>
                  {{products[parseInt(factId[0])].text}}
                </h1>
                <div class="restaurantRate">{{ products[parseInt(factId[0])].grade }}</div>
              </div>
              <p>
                {{products[parseInt(factId[0])].text}}
              </p>
            </div>
        </div>
      </div>
      <div class="bottom">
        <h2>Menus</h2>
        <div class="shopsElements" cellspacing="10" cellpadding="0">
          <div class="element" v-for="(product, i) in products" :key="i" @click="">
            <CardProduct :element=product />
          </div>
        </div>
        <h2>Entrées</h2>
        <div class="shopsElements" cellspacing="10" cellpadding="0">
          <div class="element" v-for="(product, i) in products" :key="i" @click="">
            <CardProduct :element=product />
          </div>
        </div>
    </div>
  </div>
</template>

<style scoped>
  *{
    color: black;
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
  width:100%;
  background-image: var(--fact-image);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

.top-part-text{
  position: relative;
  top: -20px;
}

  .page{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    height: calc(100% - 150px);
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
  }

  p{
    font-family: 'Roboto';
  }

  .bottom{
    background-color: white;
    width: 100%;
    height: calc(100% - 150px);
    margin-top: 40px;
    padding-top: 180px;
  }


  .top{
    width: 100%;
    height: 150px;
    margin-bottom: 40px;
    z-index: 30;
    display: flex;
    flex-direction: column;
    text-align: center;
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

.element:hover{
  cursor: pointer;
  transform: scale(1.1);
}

h2{
  margin-left: 70px;
}

</style>
