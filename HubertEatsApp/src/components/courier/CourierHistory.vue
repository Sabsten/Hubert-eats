<script setup lang="ts">
const props = withDefaults(
    defineProps<{
        duree: number; // in seconds
        distance: number; // in meters
        gain: number;
        date: Date;
    }>(),
    {},
);
const parseDuree = (): [min: number, sec: number] => {
    let m: number = 0;
    let s: number = props.duree;
    while (s > 60) {
        m += 1;
        s -= 60;
    }
    return [m, s];
}
const parseDistance = (): [km: number, m: number] => {
    let km: number = 0;
    let m: number = props.distance;
    while (m > 1000) {
        km += 1;
        m -= 1000;
    }
    return [km, m];
}
</script>

<template>
    <div class="courierHistory">
        <div class="column">
            <div class="columnTitle">Durée</div>
            <div class="columnContent">{{ parseDuree()[0] }} min {{ parseDuree()[1] }} s</div>
        </div>
        <div class="column">
            <div class="columnTitle">Distance</div>
            <div class="columnContent">{{ parseDistance()[0] }} km {{ parseDistance()[1] }}</div>
        </div>
        <div class="column">
            <div class="columnTitle">Gain</div>
            <div class="columnContent gain">{{ props.gain }} €</div>
        </div>
        <div class="date">{{ props.date.toLocaleString("fr-FR", {month: 'long', day:'numeric', year: 'numeric', hour: 'numeric', minute: 'numeric'})}}</div>
    </div>
</template>

<style scoped lang="scss">
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