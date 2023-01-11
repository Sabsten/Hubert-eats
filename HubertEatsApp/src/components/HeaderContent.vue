<template>
    <div class="content">
      <img src="@/assets/HubertEatsLogo.png" width="150">
      <div class="links">
        <HeaderLink to="/tests"> <input class="basket" type="button" value="Panier . 1" width="40" height="40"> </HeaderLink>
        <HeaderLink to="/basket"> <input class="account" type="button" value="Compte" width="40" height="40"> </HeaderLink>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  import HeaderLink from './HeaderLinks.vue'
  
  export default defineComponent({
    components: { HeaderLink }
  })
  </script>
  
  <style scoped>
  .links{
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    justify-content: space-around;
    align-items: center;
    text-align: center;
    gap: 30px;
    /* border: 2px solid black;
    background: black */
  }
  .content{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 10px 20px 10px 10px;
}

input{
  color: white;
  border-radius: 10px;
  padding: 5px 10px 5px 35px;
  background-image: url("https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg?quality=90&resize=768,574");
  background-position: left;
  background-position-x: 5px;
  background-repeat: no-repeat;
  background-size: 20px 20px;
  font-weight: bold;
  font-size: 16px;
  font-family: 'Roboto';
  font-size: 17px;
  border-color: transparent;
}

.account{
  background: black;
}

.basket{
    background-color: #3EBC72;
}
  
  </style>