<script setup lang="ts">
import CourierHeader from '@/components/courier/CourierHeader.vue';
</script>

<template>
    <div class="courierHome">
        <CourierHeader icon="fa-solid fa-user" link="/livreur/compte"/>
        <div class="ordersContent">
            <h2>Aucune commandes actuellement disponible ...</h2>
        </div>
        <div class="courierBottom">
            <div class="tinderButton close"><i class="fa-solid fa-xmark"></i></div>
            <div class="tinderButton bike"><i class="fa-solid fa-bicycle"></i></div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.courierHome {
    width:100%;
    height: 100%;
    display: flex;
    flex-direction: column;
}
.ordersContent {
    background-color: white;
    width: 100%;
    height:100%;
    display: flex;
    justify-content: center;
    align-items: center;
    h2 {
        text-align: center;
    }
}
.courierBottom {
    width: 100%;
    height: fit-content;
    display: flex;
    align-items: center;
    justify-content:space-around;
    margin: 20px 0;
}
/* BUTTONS */
.tinderButton {
    background-color: white;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50px;
    width:70px;
    height: 70px;
    border: 3px rgb(0,0,0,0) solid;
    i {
        font-size: 40px;
    }
}
.close:hover {
    animation: 1.5s 1 borderRed forwards;
    cursor: pointer;
}
.bike:hover {
    cursor: pointer;
    animation: 1.5s 1 borderGreen forwards;
}
.fa-xmark {
    color:red;
}
.fa-bicycle {
    color:#3EBC72;
}

@keyframes borderRed {
    25% {border-left: 3px red solid;}
    50% {border-left: 3px red solid; border-top: 3px red solid;}
    75% {border-left: 3px red solid; border-top: 3px red solid;
        border-right: 3px red solid;}
    100% {border-left: 3px red solid; border-top: 3px red solid;
        border-right: 3px red solid;border-bottom: 3px red solid;}
}
@keyframes borderGreen {
    25% {border-left: 3px #3EBC72 solid;}
    50% {border-left: 3px #3EBC72 solid; border-top: 3px #3EBC72 solid;}
    75% {border-left: 3px #3EBC72 solid; border-top: 3px #3EBC72 solid;
        border-right: 3px #3EBC72 solid;}
    100% {border-left: 3px #3EBC72 solid; border-top: 3px #3EBC72 solid;
        border-right: 3px #3EBC72 solid;border-bottom: 3px #3EBC72 solid;}
}
</style>