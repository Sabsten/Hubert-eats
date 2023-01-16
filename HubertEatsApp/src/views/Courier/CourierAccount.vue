<script setup lang="ts">
import CourierHeader from '@/components/courier/CourierHeader.vue';
import CourierHistory from '@/components/courier/CourierHistory.vue';
import type { ICourierForm } from '@/models/courierForm';
import { useCourierStore } from '@/stores/courier';
import { storeToRefs } from 'pinia';
import { getCurrentInstance, onMounted, onUpdated, reactive, ref, type Ref } from 'vue';

const courierStore = useCourierStore()
const { courierAccount, error } = storeToRefs(courierStore);

let editionMode: Ref<boolean> = ref(false);

const historyTest = {
    duree: 900,
    distance: 2700,
    gain: 3.7,
    date: new Date(),
}

let courierForm: Ref<ICourierForm> = ref({
    mail: courierAccount.value?.account.mail,
    firstname: courierAccount.value?.firstname,
    lastname: courierAccount.value?.lastname,
    street_name: courierAccount.value?.address.street_name,
    street_number: courierAccount.value?.address.street_number,
    postal_code: courierAccount.value?.address.postal_code,
    city: courierAccount.value?.address.city,
})
courierStore.$subscribe(() => {
    courierForm.value.mail = courierAccount.value?.account.mail;
    courierForm.value.firstname = courierAccount.value?.firstname,
    courierForm.value.lastname = courierAccount.value?.lastname;
    courierForm.value.street_name = courierAccount.value?.address.street_name;
    courierForm.value.street_number = courierAccount.value?.address.street_number;
    courierForm.value.postal_code = courierAccount.value?.address.postal_code;
    courierForm.value.city = courierAccount.value?.address.city;
})

onMounted(() => {
    const courierStore = useCourierStore();
    courierStore.getCourierAccount();
});

async function updateCourier(){
    await courierStore.modifyCourierAcount(courierForm.value);
    editionMode.value = false;
}
</script>

<template>
    <div class="accountLayout">
        <CourierHeader icon="fa-solid fa-reply" link="/courier"/>
    <div class="courierInfos">
        <img class="photo" src="/avatar.jpg" alt="Avatar"/>
        <div class="informations">
            <div v-if="editionMode" class="column">
                <form>
                    <input type="email" v-model="courierForm.mail">
                    <div>
                        <input type="text" v-model="courierForm.firstname">
                        <input type="text" v-model="courierForm.lastname">
                    </div>
                <div>
                    <input type="text" v-model="courierForm.street_number">
                    <input type="text" v-model="courierForm.street_name">
                </div>
                <div>
                    <input type="text" v-model="courierForm.postal_code">
                    <input type="text" v-model="courierForm.city">
                </div>
                </form>
            </div>
            <div v-if="!editionMode">
                <div class="name">{{ courierAccount?.firstname }}&nbsp;{{courierAccount?.lastname}}</div>
                <div class="address">{{courierAccount?.address.street_number}}&nbsp;{{ courierAccount?.address.street_name }},&nbsp;
                {{ courierAccount?.address.postal_code }}&nbsp;{{ courierAccount?.address.city }}</div>
                <div class="note">{{ courierStore.getCourierRating }} / 5</div>
            </div>
        </div>
        <span v-if="error"> {{ error }}</span>
        <div v-if="editionMode">
            <i class="fa-solid fa-close" @click="editionMode = false"></i>
            <i class="fa-solid fa-floppy-disk" @click="updateCourier()"></i>
        </div>
        <i v-if="!editionMode" class="fa-solid fa-pen-to-square" @click="editionMode = true"></i>
    </div>
    <div class="balance">
        <h2>Solde : <span class="money">{{ courierAccount?.balance }} €</span></h2>
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
    // height: 150px;
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
        font-size: 30px;
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
.column {
    display: flex;
    flex-direction: column;
    row-gap: 5px;
}
</style>


