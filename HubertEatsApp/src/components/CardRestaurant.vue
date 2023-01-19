<script setup lang="ts">
import type { IRestaurant } from '@/models/restaurants';
import { computed } from 'vue';

const props = defineProps<{
  restaurant: IRestaurant,
}>();

function getRating(ratings: number[] | undefined): number | null {
  if (ratings === undefined) {
    return null;
  }
  const total = ratings.length;
  let somme: number = 0;
  ratings?.forEach(r => {
    somme += r;
  });
  return Math.round(somme/total * 10)/ 10;
}
</script>

<template>
    <div class="table-wrapper">
        <div class="image-box">
          <img v-if="restaurant.image" :src="restaurant.image" class="pic" />
        </div>
        <div class="description">
          <div class="restaurantName">
            {{ restaurant.name }}
            <span v-if="restaurant.rating!.length > 0">&nbsp;- {{ getRating(restaurant.rating)}} <i class="fa-solid fa-star"></i></span>
          </div>
          <div>{{ restaurant.address.city }}</div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.table-wrapper {
  /* border:2px red solid; */
  display: flex;
  flex-direction: column;
  align-items: center;
  row-gap: 10px;
}
.image-box {
  width:100%;
  height: 200px;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  background: linear-gradient(180deg, #FFFFFF 0%, #D0DCC5 0.01%, rgba(236, 250, 213, 0) 100%);
  display: flex;
  justify-content: center;

  img {
    width:100%;
    height: 200px;
    object-fit: cover;
  }

}

.restaurantName{
  font-weight: 700;
  font-size: 16px;
}

.description{
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
}

</style>