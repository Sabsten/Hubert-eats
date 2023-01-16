<template>
    <div class="content">
      <img src="@/assets/HubertEatsLogo.png" width="200">
      <div class="links">
        <HeaderLink v-if="currentUrl!='/edit-menu-products'" to="/edit-menu-products">
          <button class="button myProducts-button">
            <i class="fa-solid fa-burger-soda"></i>Mes produits 
          </button>
        </HeaderLink>
        <HeaderLink v-if="currentUrl!=homePath" to="/follow-orders">
          <button class="button account-button">
            <i class="fa-solid fa-house-user"></i>Accueil 
          </button>
        </HeaderLink>
        <HeaderLink v-if="currentUrl==homePath" to="/accountr">
          <button class="button account-button">
            <i class="fa-solid fa-user"></i>Compte 
          </button>
        </HeaderLink>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  import HeaderLink from './HeaderLinks.vue'
  import { useRoute } from 'vue-router'
  
  export default defineComponent({
    components: { HeaderLink },
    setup() {
      const currentUrl = window.location.pathname;
      const homePath = "/follow-orders"
      const route = useRoute()
      return{
        currentUrl,
        homePath,
        route
      }
  }
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
  height: 96px;
}

.button {
  padding: 13px 40px;
  border-radius: 20px;
  font-size: 15px;
  border: none;
  font-size: 15px;
  margin-right: 10px;
}


.account-button {
  background-color: #000000;
  color: white;
}

.myProducts-button{
    background-color: #55289E;
  color: white;
}

i{
  margin-right: 10px;
}



@media screen and (max-width: 550px) {
  .content{
    justify-content: right;
  }
  img{
    display: none;
  }
}

  </style>