<script setup lang="ts">
import { computed, defineComponent, ref, useCssVars, type Ref } from 'vue'
import { products } from '@/assets/products'
import type { IArticle } from '@/models/inventaire';

let showDescription: Ref<boolean> = ref(false);

const props = defineProps<{
  article: IArticle,
}>();

function toggleDescription(){
  return showDescription.value ? showDescription.value = false : showDescription.value = true
}
</script>

<template>
    <div class="table-wrapper">
        <img :src="props.article.image" width="150" height="150" class="pic" />
        <div class="productName">{{ props.article.name }}&nbsp;<i class="fa-solid fa-circle-info" @click="toggleDescription()"></i></div>
        <div class="productPrice">{{ props.article.price }} €</div>
        <div v-if="showDescription" class="product-description">{{ props.article.description }}</div>
    </div>
</template>

<style scoped>

.table-wrapper {
  /* border:2px red solid; */
  display: flex;
  flex-direction: column;
  align-items: center;
  row-gap: 10px;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  background: linear-gradient(180deg, #FFFFFF 0%, #D0DCC5 0.01%, rgba(236, 250, 213, 0) 100%);
}

.productName, .productPrice{
  font-weight: 700;
  font-size: 16px;
}

.descriptionRow{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.product-description {
  text-align: justify;
}
</style>