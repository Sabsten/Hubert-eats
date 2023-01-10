<script lang="ts">
import { computed, defineComponent, useCssVars } from 'vue'
import { products } from '@/assets/products'

type FactCardProps = { factId: number }

export default defineComponent({
  props: {
    factId: {
      type: Number,
      validator: v => typeof v === 'number' && v >= 0 && v < products.length,
      required: true
    }
  },
  setup(props: FactCardProps) {
    const fact = computed(() => products[props.factId])
    return { fact }
  },
  computed: {
    cssVars(props: FactCardProps) {
      return {
        '--fact-image': `url(${products[props.factId].image})`
      }
    }
  }
}
)

</script>

<template>
  <div class="card">
      <div class="top-part" :style="cssVars" style="max-width:100%; height: 200px; min-width: 100%;">

      </div>
      <div class="bottom-part">
        <div class="description">
          <h5 class="card-title">Cat Fact #{{ factId }}</h5>
          <p class="card-text">{{ fact.text }}</p>
        </div>
      </div>
    </div>
</template>

<style scoped>
.top-part{
  width:100%;
  background-image: var(--fact-image);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

img{
  border-bottom-left-radius: 30px;
  border-bottom-right-radius: 30px;
}

.description{
  text-align: center;
}

.card-title{
  font-size: 1.5em;
  font-weight: bold;
  font-family: 'Roboto', sans-serif;
  margin-top: 10px;
  margin-bottom: 10px;
}

.card-text{
  font-size: 1.3em;
  margin-top: 10px;
  margin-bottom: 10px;
  color: rgb(0, 0, 0);
  font-weight: bold;
}

</style>