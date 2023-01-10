<script lang="ts">
import { computed, defineComponent, useCssVars } from 'vue'
import { products } from '@/assets/products'

type CardRestaurantProps = { factId: number }

export default defineComponent({
  props: {
    factId: {
      type: Number,
      validator: v => typeof v === 'number' && v >= 0 && v < products.length,
      required: true
    }
  },
  setup(props: CardRestaurantProps) {
    //const restaurant = computed(() => products[props.factId])
    const restaurant = products[0]
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
                <div class="productName">{{ restaurant.text }}</div>
                <div class="productPrice">{{ restaurant.grade }} €</div>
                <div>{{ restaurant.address }}</div>
            </div>
        </div>
    </div>
</template>

<style scoped>

.productName{
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 16px;
}

.productPrice{
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 20px;
}

.descriptionRow{
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: left;
}

</style>