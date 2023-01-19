<script lang="ts">
import { defineComponent } from 'vue'
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'

export default defineComponent({
  setup() {
    const router = useRouter()
    const route = useRoute()
    const goToPurchase = () => {
    router.push({ path: `/purchase` })
  }
    return { goToPurchase, route }
  }
})
</script>

<template>
  <form class="pageComponent">
    <input class="lastName textInput" :value="route.query.number" placeholder="Nom de l'utilisateur"/>
    <input class="name textInput" placeholder="Prénom de l'utilisateur"/>
    <input class="email textInput" placeholder="Email"/>
    <input class="address textInput" placeholder="Adresse"/>

    <div class="endForm">
      <div class="leftButton">
        <input value="Suspendre" class="other suspend" type="button"/>
        <input value="Supprimer" class="other remove" type="button"/>
      </div>
      <input value="Modifier" class="validation" type="button"/>
    </div>
  </form>
</template>

<style scoped>

.pageComponent{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  background-color: rgb(255, 255, 255);
  gap: 20px;
  padding: 20px;
}

input{
  background-color: transparent;
}

.textInput{
  min-width: 200px;
  height: 15px;
  border: 1px solid black;
  border-radius: 5px;
  padding: 10px;
}

.endForm{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin-top: 20px;
  width: 100%;
}

.leftButton{
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.validation{
  width: 80px;
  height: 40px;
  border-radius: 5px;
  background-color: #3EBC72;
  border: none;
  color: white;
}

.suspend{
  background-color: #55289E;
}

.remove{
  background-color: #9E2828;
}

.other{
  width: 80px;
  height: 30px;
  border: 1px solid black;
  border-radius: 5px;
  color: white;
  border: none;
}

<<<<<<< HEAD
</style>
=======
</style>
>>>>>>> main
