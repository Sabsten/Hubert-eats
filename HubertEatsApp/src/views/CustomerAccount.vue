<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goToCreateAccount = () => {
    router.push({ path: `/facts` })
  }
 

  
  }
})
</script>

<template>
   
   <div id="banner">
  
    <img src="@/assets/HubertEatsLogo.png" >
    <button class="button cart-button" >
  <i class="fas fa-shopping-cart"></i>   Pannier
</button>

  <button class="button account-button">
    <i class="fa-solid fa-house-user"></i>Accueil 
</button>

</div>  
<div class="name">

  John Doe <i class="fa-solid fa-pen-to-square"></i>

</div>

<div class="name2">

Historique des commandes <i class="fa-solid fa-receipt"></i>
<input type="text9" placeholder="Commande 1" class="input9">
<input type="text10" placeholder="Commande 2" class="input10">
<input type="text11" placeholder="Commande 3" class="input11">
<input type="text12" placeholder="Commande 4" class="input12">

</div>

<input type="text" placeholder="Adresse Postale" class="input1">
<input type="text1" placeholder="Adresse Mail" class="input2">
<input type="text1" placeholder="Mot De Passe" class="input3">
<input type="text1" placeholder="Parrainage" class="input4">

<div class="name1">

Mode de Paiement <i class="fa-solid fa-pen-to-square"></i>

</div>
<div class="rectangle"><div class="carte">Carte de Crédit</div>
<input type="text2" placeholder="Numéro de carte" class="input5">
<input type="text3" placeholder="Nom du Titulaire" class="input6">
<input type="text4" placeholder="Date d'expiration" class="input7">
<input type="text5" placeholder="CVV" class="input8">

</div>



</template>
  
<style scoped>

.fa-house-user{
  display: flex;
  margin-right: 10px;
  
}
.fa-shopping-cart{

display: flex;
margin-right: 10px;
  
}

#banner img {
  width: 140px; /* Ajuster la largeur de l'image à la largeur de la bannière */
  height: auto; /* Ajuster la hauteur de l'image en fonction de la largeur */
  margin-right: 820px;
  margin-bottom: 30px;
  margin-top: 10px;

}

#banner {
  width: 100%; /* Largeur de la bannière en pourcentage de la largeur de la fenêtre */
  height: 120px; /* Hauteur de la bannière en pixels */
  background-color: #E3EFEB; /* Couleur de fond de la bannière */
  text-align: center; /* Centre le texte à l'intérieur de la bannière */
  display: flex;
  justify-content: end;

}

.button {
  padding: 10px 60px;
  border-radius: 20px;
  font-size: 15px;
  border: none;
  margin-top: 35px;
  margin-bottom: 35px;
  font-size: 15px;
  margin-right: 60px;
}
.cart-button {

  display: flex;
  background-color: #3EBC72;
  color: white;
  align-items: center;
}
.account-button {
  
  background-color: #000000;
  color: white;
  display: flex;
  align-items: center;
}


.name{
  
  margin-top: 100px;
  margin-left: 150px;
  font-size: 25px;
  display: flex;
  column-gap: 30px;

}
.name2{
  position: absolute;
  margin-top: 228px;
  margin-left: 1000px;
  font-size: 25px;
  display: flex;
  column-gap: 30px;

}


.input1 {
position: absolute;
width: 350px;
height: 35px;
border-radius: 20px;
margin-left: 145px;
margin-top: 293px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input2 {
position: absolute;
width: 290px;
height: 35px;
border-radius: 20px;
margin-left: 145px;
margin-top: 390px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input3 {
position: absolute;
width: 290px;
height: 35px;
border-radius: 20px;
margin-left: 145px;
margin-top: 490px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input4 {
position: absolute;
width: 290px;
height: 35px;
border-radius: 20px;
margin-left: 145px;
margin-top: 590px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input5 {
position: absolute;
width: 350px;
height: 35px;
border-radius: 20px;
margin-left: 95px;
margin-top: 85px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input6 {
position: absolute;
width: 150px;
height: 35px;
border-radius: 20px;
margin-left: 25px;
margin-top: 180px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}
.input7 {
position: absolute;
width: 150px;
height: 35px;
border-radius: 20px;
margin-left: 215px;
margin-top: 180px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}
.input8 {
position: absolute;
width: 100px;
height: 35px;
border-radius: 20px;
margin-left: 400px;
margin-top: 180px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input9 {
position: absolute;
width: 350px;
height: 85px;
border-radius: 20px;
margin-left: 10px;
margin-top: 100px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}

.input10 {
position: absolute;
width: 350px;
height: 85px;
border-radius: 20px;
margin-left: 10px;
margin-top: 200px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}
.input11{
position: absolute;
width: 350px;
height: 85px;
border-radius: 20px;
margin-left: 10px;
margin-top: 300px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}
.input12{
position: absolute;
width: 350px;
height: 85px;
border-radius: 20px;
margin-left: 10px;
margin-top: 400px;
filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
  
}


input[type="text"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 125px;
}

input[type="text1"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 105px;
}
input[type="text2"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 118px;
}

input[type="text3"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 25px;
}
input[type="text4"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 25px;
}
input[type="text5"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 35px;
}

input[type="text9"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 135px;
}


input[type="text10"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 135px;
}

input[type="text11"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 135px;
}
input[type="text12"]::placeholder {
    color: 957E7E;
    font-size: 14px;
    padding-left: 135px;
}
.name1{
  
  margin-top: 470px;
  margin-left: 200px;
  font-size: 25px;
  display: flex;
  column-gap: 30px;

}

.rectangle {
  position: absolute;
width: 550px;
height: 339px;
margin-top: 800px;
margin-left: 200px;

background: #2A360F;
border-radius: 20px;
}

.carte{
  padding-top: 30px;
font-size: 20px;
color: white;
padding-left: 50px;
}


</style>
  