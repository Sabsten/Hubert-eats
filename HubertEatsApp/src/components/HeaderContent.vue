<template>
    <div class="content">
      <img src="@/assets/HubertEatsLogo.png" width="200">
      <div class="links">
        <HeaderLink to="/tests">
          <button class="button cart-button" >
            <i class="fas fa-shopping-cart"></i>   Pannier . 0
          </button>
        </HeaderLink>
        <HeaderLink to="/home">
          <button class="button account-button">
            <i class="fa-solid fa-house-user"></i>Accueil 
          </button>
        </HeaderLink>
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
    justify-content: right;
    gap: 0px;
  }
.content{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.button {
  padding: 13px 40px;
  border-radius: 20px;
  font-size: 15px;
  border: none;
  font-size: 15px;
  margin-right: 10px;
}

.cart-button {
  background-color: #3EBC72;
  color: white;
}

.account-button {
  background-color: #000000;
  color: white;
}

i{
  margin-right: 10px;
}
  </style>