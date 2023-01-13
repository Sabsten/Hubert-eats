<script setup lang="ts">
import type { IRestaurant } from '@/models/restaurants';

defineProps<{
  restaurant: IRestaurant,
}>();

</script>

<template>
    <div class="table-wrapper">
        <img :src="restaurant.image" width="150" height="150" class="pic" />
        <div>
          <div class="descriptionRow">
            <div class="restaurantName">{{ restaurant.name }}</div>
            <!-- <div class="restaurantRate">{{ restaurant }}</div> -->
          </div>
          <!-- <div>{{ restaurant.address.street_number }}&nbsp;{{ restaurant.address.street_name }}</div> -->
          <div>{{ restaurant.address.postal_code }},&nbsp;{{ restaurant.address.city }}</div>
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