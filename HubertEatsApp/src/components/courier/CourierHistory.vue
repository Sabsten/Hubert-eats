<script setup lang="ts">
const props = withDefaults(
    defineProps<{
        duree: Number; // in seconds
        distance: Number; // in meters
        gain: Number;
        date: Number;
    }>(),
    {},
);
</script>

<template>
    <div class="courierHistory">
        <div class="column">
            <div class="columnTitle">Durée</div>
            <div class="columnContent">{{ props.duree }} min</div>
        </div>
        <div class="column">
            <div class="columnTitle">Distance</div>
            <div class="columnContent">{{ props.distance }} km</div>
        </div>
        <div class="column">
            <div class="columnTitle">Gain</div>
            <div class="columnContent gain">{{ props.gain }} €</div>
        </div>
        <div class="date">{{ props.date.valueOf() }}</div>
    </div>
</template>

<style lang="scss">
.courierHistory {
    width:100%;
    height: 100px;
    background-color: white;
    border-radius: 10px;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-rows: 1fr 1fr 1fr;
    .column {
        grid-row: 1/3;
        padding:15px;
        // border: 2px red solid;
        justify-content: center;
        .columnContent {
            font-weight: bold;
        }
        .gain {
            color: var(--green);
        }
    }
    .date {
        padding:15px;
        grid-column: 1 / 4;
        grid-row: 3;
    }
}
</style>