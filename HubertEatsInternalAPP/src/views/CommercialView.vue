<script lang="ts">
import { defineComponent } from 'vue'
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'
import UserFormPage from '@/components/UserFormPage.vue'
import HeaderContent from '@/components/HeaderContent.vue'

export default defineComponent({
  data() {
    return{
      enterClass: 'fade',
      leaveClass: 'fade'
    }
  },
  setup(){
    const router = useRouter()
    const route = useRoute()
    const displayCart = (id: number) => {
      router.push({ path: route.fullPath, query: { cart: 'true', number: id } })
    }
    const cancelCart = () => {
      router.push({ path: route.fullPath })
    }
    return { cancelCart, route, displayCart }
  },
  components: { HeaderContent, UserFormPage },
  watch: {
    $route(to, from) {
      if(to.path.startsWith('/fact/')){
        this.enterClass = "animate__animated animate__fadeInRight",
        this.leaveClass = "animate__animated animate__fadeOutLeft"
    }else if(from.path.startsWith('/fact/') && to.path === "/facts"){
      this.enterClass = "animate__animated animate__fadeInLeft",
      this.leaveClass = "animate__animated animate__fadeOutRight"
    }else{
      this.enterClass = "animate__animated animate__fadeIn",
      this.leaveClass = "animate__animated animate__fadeOut"
    }
    console.log(to.path)
  }
}
})

</script>

<template>
    <div>
        <HeaderContent title="Service commercial"/>
        <div class="page">
            <div class="users">
                <h1>Liste des utilisateurs</h1>
                <input class="searchUser" placeholder="Rechercher un utilisateur"/>
                <div class="userList">
                    <div class="userElement" @click="displayCart(1)">
                        <div class="userName">John Doe</div>
                        <div class="userId">john.doe@hubert.com</div>
                    </div>
                    <div class="userElement" @click="displayCart(1)">
                        <div class="userName">John Doe</div>
                        <div class="userId">john.doe@hubert.com</div>
                    </div>
                </div>
            </div>
            <div class="statistics">
                <h1>Mes statistiques générales</h1>
                <iframe width="100%" height="600px" src="https://charts.mongodb.com/charts-hubert-eats-qdmmw/public/dashboards/63b59d02-e76a-4d1b-8ba4-114428a8d75f"></iframe>
                <h1>Statistiques des processus de commandes</h1>
                <iframe width="100%" height="600px" src="https://charts.mongodb.com/charts-hubert-eats-qdmmw/public/dashboards/abf077d7-efd7-4871-a88e-7babf9cd6206"></iframe>
            </div>
        </div>
        <!-- Show the cart for any page -->
      <transition name="fade" :duration="{enter:1000, leave:200}">
          <UserFormPage class="element" v-if="route.query.cart=='true'"/>
      </transition>
      <transition name="fade" :duration="{enter:1000, leave:200}">
        <div @click="cancelCart()" class="background" v-if="route.query.cart=='true'">
        </div>
      </transition>
    </div>
</template>

<style scoped>
.page{
    display: flex;
    flex-direction: row;
    align-items: start;
    justify-content: start;
    background-color: #ffffff;
    width: 100%;
    height: 100%;
}

.users{
    margin: 20px;
    background-color: white;
    max-width: 450px;
}

.statistics{
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
    height: 100%;
    background-color: white;
    margin: 20px;
    width: calc(100% - 40px);
}

h1{
    text-align: left;
    width: 100%;
}

.userName{
    font-size: 20px;
    font-weight: 700;
    background-color: #F5F5F5;
}

.userId{
    font-size: 15px;
    font-weight: 400;
    background-color: #F5F5F5;
}

.userElement{
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: space-around;
    width: 80%;
    height: 30px;
    padding: 10px;
    max-width: 300px;
    border: 2px solid #6B706E;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 10px;
}

.userElement *{
  background-color: white;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

.element{
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  overflow: auto;
  z-index: 101;
  border-radius: 10px;
}

.background{
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 100;
}

.searchUser{
  min-width: 200px;
  height: 15px;
  border: 1px solid black;
  border-radius: 5px;
  padding: 10px;
  margin-bottom: 20px;
}

.userList{
    display: flex;
    flex-direction: column;
    gap: 5px;
    max-height: 300px;
}

@media screen and (max-width: 1200px) {
    .page {
        flex-direction: column;
    }
}

</style>