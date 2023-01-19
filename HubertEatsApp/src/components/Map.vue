<script setup>
import "leaflet/dist/leaflet.css";
import {LMap, LTileLayer, LMarker, LIcon} from '@vue-leaflet/vue-leaflet'
import { defineComponent } from "vue";

defineComponent({
    LMap,
    LTileLayer,
    LMarker,
    LIcon
})
defineProps({
    restauLatLong: {
        type: Array,
        required: false
    },
    courierLatLong: {
        type: Array,
        required: true
    },
    customerLatLong: {
        type: Array,
        required: false
    }
});
const zoom = 13;
const iconSize = [40];
const veloIconUrl = "https://cdn-icons-png.flaticon.com/512/2264/2264728.png";
const restauIconUrl = "https://cdn-icons-png.flaticon.com/512/1376/1376387.png";
const customerIconUrl = "https://cdn-icons-png.flaticon.com/512/4766/4766761.png"

</script>

<template>
    <div style="height:100%; width:100%">
      <l-map ref="map" :zoom="zoom" :center="[1, 1]">
        <l-tile-layer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          layer-type="base"
          name="OpenStreetMap"
        ></l-tile-layer>
        <l-marker v-if="courierLatLong" :lat-lng="[1, 1]">
            <l-icon :icon-url="veloIconUrl" :icon-size="iconSize" />
        </l-marker>
        <l-marker v-if="restauLatLong" :lat-lng="[1, 1]">
            <l-icon :icon-url="restauIconUrl" :icon-size="iconSize" />
        </l-marker>
        <l-marker v-if="customerLatLong" :lat-lng="[1, 1]">
            <l-icon :icon-url="customerIconUrl" :icon-size="iconSize" />
        </l-marker>
      </l-map>
    </div>
</template>
