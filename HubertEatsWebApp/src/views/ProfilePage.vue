<template>
    <div class="page">
        <Transition>
            <PopupUser v-if="popupTrigger.buttonTrigger"
            :TogglePopup="() => TogglePopup()">
                <!-- <h1>My popup</h1> -->
            </PopupUser>
        </Transition>

        <div class="header">
            <h4>
            Djilali Ouadah
            </h4>
            <img src="@/assets/enveloppe.png" style="margin-top: 20px;" width="50" height="40">
        </div>

        <div class="profileContent">
            <div class="bricks1">
                <div @click="TogglePopup()" class="brick">
                    <div>Éditer mon profil</div>
                    <img src="@/assets/profil2.png" width="50" height="50">
                </div>
                <div class="brick">
                    <div>Parrainer un restaurateur</div>
                    <img src="@/assets/gift.png" width="50" height="50">
                </div>
            </div>
            <div class="bricks2">
                <div class="brickHistory">
                    <div style="background: white; padding:10px 20px 10px 20px">Historique des commandes</div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import {ref} from 'vue'
import PopupUser from '@/components/PopupUser.vue'

export default {
    components: { PopupUser },
    setup(){
        const popupTrigger = ref({
            buttonTrigger: false
        })

        const TogglePopup = () => {
            popupTrigger.value.buttonTrigger = !popupTrigger.value.buttonTrigger
        }

        return {
            PopupUser,
            popupTrigger,
            TogglePopup
        }
    }
    
}

</script>

<style scoped>

.header{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    margin-top: 0px;
    margin-bottom: 0px;
    margin-left: 20px;
    margin-right: 20px;
}

.page{
    padding-bottom: 30px;
}

h4{
    font-size: 50px;
    font-weight: bold;
    margin-top: 40px;
    margin-bottom: 20px;
    font-family: helvetica;
}

.profileContent{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    margin-top: 20px;
    margin-bottom: 0px;
    margin-left: 20px;
    margin-right: 20px;
    width: calc(100% - 40px);
}

.bricks1{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    margin-top: 20px;
    margin-bottom: 0px;
    margin-left: 20px;
    margin-right: 20px;
    gap: 30px;
    width: 100%;
}
.bricks2{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    margin-top: 20px;
    margin-bottom: 0px;
    margin-left: 20px;
    margin-right: 20px;
    gap: 30px;
    width: 100%;
}

.brick {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    font-size: 20px;
    font-weight: bold;
    padding: 10px 10px 10px 10px;
    font-family: helvetica;
    background-color: white;
    border-radius: 30px;
    padding: 20px;
    min-height: 50px;
    cursor: pointer;
    width: 100%;
}

.brick:hover{
    transform: scale(1.02);
}

.brickHistory{
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    font-size: 20px;
    font-weight: bold;
    padding: 10px 10px 10px 10px;
    font-family: helvetica;
    background-color: white;
    border-radius: 30px;
    min-height: 80px;
    background-color: white;
    cursor: pointer;
    width: 100%;
}

.brickHistory:hover{
    transform: scale(1.02);
}

.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}

</style>