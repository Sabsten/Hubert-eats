<script lang="ts">
import { defineComponent } from 'vue'
import { useRouter } from 'vue-router'
import HeaderContent from '@/components/HeaderContentRestorator.vue'

export default defineComponent({
  setup() {
    const router = useRouter()
    const goToCreateAccount = () => {
    router.push({ path: `/signup` })
    }
  },
  components: {
    HeaderContent
  }
})
</script>

<template>
   <div class="page">
    <HeaderContent class="header"/> 
    <div class="content_">
        <div class="commandsInProgress">
        <div class="headerElementInProgress">
           <i class="fa-solid fa-bicycle fa-2xl" style="color:#44795A; height:30px"></i>
           Commandes en cours
           <hr size="2" color="#3EBC72" width="200px">
        </div>
        <input placeholder="Commande 1" class="inputHistory">
        <input placeholder="Commande 2" class="inputHistory">
        <input placeholder="Commande 3" class="inputHistory">
        <input placeholder="Commande 4" class="inputHistory">
      </div>

    <div class="commandsInPending">
        <div class="restaurantStatus">
            <div class="bubble">
                <div style="font-size:18px; font-weight: 600;">
                    Nom du restaurant
                </div>
                <div class="rate"> 4.4 </div>
            </div>
            <div style="width:200px; text-align:center; font-size:25px; font-weight: 700;">John Doe</div>
            <div><hr size="2" color="black" width="200px"></div>
        </div>
        <div class="validateCommand">
          <div class="headerElementPending">
            Commande
            <i class="fa-solid fa-sheet-plastic fa-xl" style="color:#44795A; height:5px"></i>
          </div>
          <div class="elementsValidationPending">
            <div class="element">
                <div class="elementDescription">
                    Menu/arcile - Nom Livreur<br>
                    Nom client
                </div>
                <div class="choiceCommandButtons">
                    <i class="fa-solid fa-check-circle fa-2xl" style="color:#44795A"></i>
                    <i class="fa-solid fa-times-circle fa-2xl" style="color:red"></i>
                </div>
            </div>
            <div class="element">
                <div class="elementDescription">
                    Menu/arcile - Nom Livreur<br>
                    Nom client
                </div>
                <div class="choiceCommandButtons">
                    <i class="fa-solid fa-check-circle fa-2xl" style="color:#44795A"></i>
                    <i class="fa-solid fa-times-circle fa-2xl" style="color:red"></i>
                </div>
            </div>
            <div class="element">
                <div class="elementDescription">
                    Menu/arcile - Nom Livreur<br>
                    Nom client
                </div>
                <div class="choiceCommandButtons">
                    <i class="fa-solid fa-check-circle fa-2xl" style="color:#44795A"></i>
                    <i class="fa-solid fa-times-circle fa-2xl" style="color:red"></i>
                </div>
            </div>
          </div>
        </div> 
        </div>
    </div> 
  </div>
</template>
  
<style scoped>

.header{
  background-color: var(--light-green);
  margin-bottom: 50px;
}

.page{
    min-height: calc(100vh - 15px);
    width: 100%;
    display: flex;
    flex-direction: column;
    margin-bottom: 15px;
}

.content_{
  justify-content: space-around;
  gap: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
}

.headerElementInProgress{
    font-size: 25px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    column-gap: 30px;
    font-weight: 700;
}

.headerElementPending{
    font-size: 25px;
    display: flex;
    justify-content: center;
    align-items: center;
    column-gap: 30px;
    font-weight: 700;
    height: 80px;
}


.personalInformationsForm{
  display: flex;
  flex-direction: column;
  gap: 20px;
  width: 30%;
  min-width: 400px;
}

.commandsInProgress{
  display: flex;
  flex-direction: column;
  gap: 20px;
  min-width: 400px;
  max-width: 500px;
  align-items: left;
  justify-content: left;
  width: 50%;
}

.commandsInPending{
  display: flex;
  flex-direction: column;
  gap: 50px;
  width: 50%;
  min-width: 400px;
  max-width: 800px;
}


.inputHistory {
  height: 85px;
  border-radius: 20px;
  filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
}

.elementsValidationPending{
    display: flex;
    flex-direction: column;
    gap: 20px;
    margin-left: 20%;
    margin-right: 20px;
}

.element{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    width: 100%;
    gap: 20px;
}

.elementDescription{
    background: #FFFFFF;
    border: 2px solid #6B706E;
    width: 80%;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 30px;
    padding: 5px 10px;
}

.choiceCommandButtons{
    display: flex;
    flex-direction: row;
    gap: 20px;
    height: 100%;
    width: 20%;
}

.choiceCommandButtons i{
    height: 100%;
}

.rate{
    text-align: center;
    padding: 15px;
    background-image: url(@/assets/star.png);
    background-repeat: no-repeat;
    background-size: 50px;
    background-position: 50% -7px;
    height: 50px;
    font-size: 10px;
    color: white;
    font-weight: bold;
}

.restaurantStatus{
    display: flex;
    flex-direction: column;
    gap: 20px;
    align-items: end;
    justify-content: center;
    margin-right: 40px;
}

.bubble{
    padding: 30px;
    background: #FFFFFF;
    border: 1px solid #4D6356;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 50%;
    width: 150px;
    height: 50px;
    text-align: center;
}

@media screen and (max-width: 900px) {
    .content_{
  justify-content: space-around;
  gap: 100px;
  display: flex;
  flex-direction: column-reverse;
}

.elementsValidationPending{
    margin: 0px;
}

.restaurantStatus{
    align-items: center;
}

.commandsInPending{
  gap: 15px;
}

}

</style>
  