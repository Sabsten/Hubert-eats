<script lang="ts">
import { computed, defineComponent, useCssVars } from 'vue'
import { products } from '@/assets/products'

type CardRestaurantProps = { element: any }

export default defineComponent({
  props: {
    element: {
      required: true
    }
  },
  setup(props: CardRestaurantProps) {
    //const restaurant = computed(() => products[props.factId])
    const restaurant = props.element
    return { restaurant }
  },
  computed: {
    cssVars(props: CardRestaurantProps) {
    }
  }
}
)

</script>

<template>
    <div class="table-wrapper">
        <img :src="restaurant.image" width="150" height="150" class="pic" />
        <div>
            <div class="descriptionRow">
            <div class="restaurantName">{{ restaurant.text }}</div>
            <div class="restaurantRate">{{ restaurant.grade }}</div>
        </div>
        <div>{{ restaurant.address }}</div>
        </div>
    </div>
</template>

<style scoped>

.restaurantRate{
  padding: 10px;
  background-image: url(@/assets/star.png);
  background-repeat: no-repeat;
  background-size: 35px;
  background-position: -2px -5px;
  font-size: 10px;
  color: white;
  font-weight: bold;
}

.restaurantName{
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 16px;
}

.descriptionRow{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

</style>