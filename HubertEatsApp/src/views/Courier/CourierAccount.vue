<script setup lang="ts">
import CourierHeader from '@/components/courier/CourierHeader.vue';
import CourierHistory from '@/components/courier/CourierHistory.vue';

const historyTest = {
    duree: 900,
    distance: 2700,
    gain: 3.7,
    date: new Date(),
}
</script>

<template>
    <div class="accountLayout">
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
        <div class="historyContent">
            <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date />
            <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date />
            <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date />
            <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date />
            <CourierHistory :duree=historyTest.duree :distance=historyTest.distance :gain=historyTest.gain :date=historyTest.date />
        </div>
    </div>
    </div>
</template>

<style scope lang="scss">
.sub-layout {
    margin-bottom: 0 !important;
}
.accountLayout {
    overflow-y: scroll;
    -ms-overflow-style: none;
    scrollbar-width: none;
}
.accountLayout::-webkit-scrollbar{
    display: none;
  }
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
    i:hover {
        cursor: pointer;
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
.history {
    margin-bottom: 20px;
}
.historyContent {
    display: flex;
    flex-direction: column;
    row-gap: 20px;
}
</style>


