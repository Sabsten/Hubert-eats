<script lang="ts">
import { defineComponent } from 'vue'
import HeaderContent from '@/components/HeaderContent.vue'

export default defineComponent({
  setup() {
  },
  components: {
    HeaderContent
  }
})
</script>

<template>
   <div class="page">
        <HeaderContent class="header"/> 

        <div class="top">
            <div class="map">
                <div class="map__container">
                </div>
            </div>
            <div class="profile">
                <div class="name">
                    John Doe
                </div>
                <div class="rate"> 4.4 </div>
                <hr size="1" color="black" width="80%">
                <div class="txtConfirm">Code de confirmation</div>
                <div class="code">
                    <input id="code1" maxlength="1" type="number">
                    <input id="code2" maxlength="1" type="number">
                    <input id="code3" maxlength="1" type="number">
                    <input id="code4" maxlength="1" type="number">
                </div>
                
                <hr size="1" color="black" width="80%">
                <div class="support">
                    <span>Un problème avec votre demande ?</span>
                    <input type="button" value="Contacter le support">
                </div>
            </div>
        </div>
        
        <div class="progressionMessage">Progression:</div>
        <div class="bottom">
            <div>
                <i class="fa-solid fa-file-circle-check fa-2xl"></i>
                <span>Demande acceptée</span>
            </div>
            <hr size="2" color="black" width="10%">
            <div>
                <i class="fa-solid fa-utensils fa-2xl"></i>
                <span>Demande prête</span>
            </div> 
            <hr size="2" color="black" width="10%">
            <div>
                <i class="fa-sharp fa-solid fa-person-biking fa-2xl"></i>
                <span>Livraison en cours</span>
            </div> 
            <hr size="2" color="black" width="10%">
            <div>
                <i class="fa-sharp fa-solid fa-circle-check  fa-2xl"></i>
                <span>Repas livré</span>
            </div> 
        </div>
        <div class="support2">
                <span>Un problème avec votre demande ?</span>
                <input type="button" value="Contacter le support">
        </div>
    </div>
</template>

<style scoped> 
.header{
    background-color: var(--light-green);
}
.top{
    display: flex;
    flex-direction: row;
    width: 100vw;
    align-items: center;
}

.bottom{
    display: flex;
    flex-direction: row;
    width: calc(100vw - 80px);
    align-items: center;
    justify-content: center;
    height: 10vh;
    margin-top: 50px;
    padding: 0px 40px;
}

i{
    width: 40px;
    height: 40px;
    margin-bottom: 0px;
}

.bottom div{
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 100%;
    text-align: center;
}

.bottom hr{
    position: relative;
    bottom: 40px;
}

.map{
    background-color: grey;
    width: 70%;
    height: 50vh;
}

.profile{
    width: 30%;
}

.rate{
    text-align: center;
  padding: 10px;
  background-image: url(@/assets/star.png);
  background-repeat: no-repeat;
  background-size: 40px;
  background-position: 50% -7px;
  font-size: 10px;
  color: white;
  font-weight: bold;
}

.code{
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap:10px;
}

.code input{
    background-color: black;
    border-color: transparent;
    border-radius: 5px;
    width: 30px;
    height: 50px;
    color: white;
    font-size: 20px;
    text-align: center;
}

/* Hide arrow in the input field */
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

.name{
    font-size: 30px;
    font-weight: bold;
    margin: 5px 0px;
    text-align: center;
}

.txtConfirm{
    font-size: 20px;
    font-weight: bold;
    margin: 20px 0px;
    text-align: center;
}

.support, .support2{
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px 0px;
    gap: 10px;
    margin-top: 50px;
    text-align: center;
}

.support input , .support2 input{
    border-color: transparent;
    background: #E0E0E0;
    border-radius: 20px;
    width: 150px;
    height: 40px;
    font-size: 15px;
    font-weight: 400;
    text-align: center;
}

.support2{
    display: none;
}

.progressionMessage{
    font-size: 20px;
    font-weight: bold;
    text-align: center;
    text-decoration: underline;
    margin-top: 30px;
    display: none;
}

@media screen and (max-width: 600px) {
.top{
    display:block;
}

.map, .profile{
    width: 100%;
}

.support{
    display: none;
}

.support2{
    display: flex;
}

.progressionMessage{
    display: block;
}

}

</style>