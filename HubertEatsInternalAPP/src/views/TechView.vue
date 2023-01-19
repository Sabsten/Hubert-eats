<script lang="ts">
import { defineComponent } from 'vue'
import HeaderContent from '@/components/HeaderContent.vue'

export default defineComponent({
  components: { HeaderContent },
})

</script>

<template>
    <div>
        <HeaderContent title="Service commerciale"/>
        <div class="page">
          <form class="userForm">
            <h1>Vos informations personnelles</h1>
            <input class="lastName textInput" placeholder="Nom de l'utilisateur"/>
            <input class="name textInput" placeholder="Prénom de l'utilisateur"/>
            <input class="email textInput" placeholder="Email"/>
            <input class="address textInput" placeholder="Adresse"/>
          </form>
          <div class="components">
            <h1>Composants</h1>
            <a href="#">Composant1</a>
            <a href="#">Composant2</a>
          </div>
        </div>
    </div>
</template>

<style scoped>
.page{
    display: flex;
    flex-direction: row;
    align-items: start;
    justify-content: space-around;
    background-color: #ffffff;
    gap: 50px;
    width: 100%;
    height: 100%;
    flex-wrap: wrap;
}

.userForm{
  display: flex;
  flex-direction: column;
  align-items: start;
  margin: 20px;
  max-width: 300px;
  gap: 20px;
}

.textInput{
  min-width: 200px;
  height: 15px;
  border: 1px solid black;
  border-radius: 5px;
  padding: 10px;
}

.components{
    margin: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
    background-color: white;
    align-items: left;
    min-width: 300px;
    gap: 15px;
}

.components *{
  align-items: left;
}

h1{
  width: 100%;
}

a{
  width: 100%;
  font-size: 20px;
}

@media screen and (max-width: 1200px) {
}

</style>