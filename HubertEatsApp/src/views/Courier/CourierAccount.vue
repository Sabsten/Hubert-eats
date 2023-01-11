<script setup lang="ts">
import CourierHeader from '@/components/courier/CourierHeader.vue';
import CourierHistory from '@/components/courier/CourierHistory.vue';

const historyTest = {
    duree: 100,
    distance: 2700,
    gain: 3.7,
    date: new Date()
}
</script>

<template>
    <CourierHeader icon="fa-solid fa-reply" link="/livreur"/>
    <div class="courierInfos">
        <img class="photo" src="/avatar.jpg" alt="Avatar"/>
        <div class="informations">
            <div class="name">John Doe</div>
            <div class="address">12 Boulevard des platanes, 31000 Toulouse</div>
            <div class="note">4.5/5</div>
        </div>
        <i class="fa-solid fa-pen-to-square"></i>
    </div>
    <div class="balance">
        <h2>Solde : <span class="money">120,5 €</span></h2>
    </div>
    <div class="history">
        <h1>Historique</h1>
        <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date.getDate() />
    </div>
</template>

<style lang="scss">
.courierInfos {
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
    column-gap: 20px;
    height: 100px;
    .photo {
        clip-path: circle();
        width: 100px;
    }
    .informations {
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        .name {
            font-weight: bold;
            font-size: 24px;
        }
        .address {
            font-size: 100%;
        }
        .note {
            font-weight: bold;
        }
    }
    i {
        font-size: 25px;
        color: var(--green);
    }
}
.balance {
    margin-top:30px;
    width:100%;
    height: 100px;
    background-color: white;
    border-radius: 10px;
    display: flex;
    justify-content: center;
    align-items: center;
    .money {
        color: var(--green);
    }
}

</style>


