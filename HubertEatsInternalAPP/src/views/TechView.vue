<script lang="ts">
import { defineComponent } from 'vue'
import HeaderContent from '@/components/HeaderContent.vue'

export default defineComponent({
  components: { HeaderContent },
  setup(){
    const copyNpmCommand = (content: string) => {
      navigator.clipboard.writeText("npm install "+content);
    alert("Commande copée : npm install b" + content);
    }
    return { copyNpmCommand }
  }
})

</script>

<template>
    <div>
        <HeaderContent title="Interface développeur"/>
        
        <div class="page">
          <form class="userForm">
            <h1>Vos informations personnelles</h1>
            <input class="lastName textInput" placeholder="Nom de l'utilisateur"/>
            <input class="name textInput" placeholder="Prénom de l'utilisateur"/>
            <input type="email" class="email textInput" placeholder="Email"/>
            <input class="address textInput" placeholder="Adresse"/>
          </form>
          <div class="components">
            <h1>Composants</h1>
            <div>
              <p class="component" @click="copyNpmCommand('vue-headerhuberteats')">
            <img style="position:relative;top:10px;" height="40" src="https://static.thenounproject.com/png/32983-200.png"/> vue-headerhuberteats</p>
              <p class="description">Composant qui contient une entête dans le style de Hubert Eats. Le titre et le logo sont personnalisables.
              <p class="date">Publié le 19/01/2023</p>
            </p>
            </div>
            <div>
              <p class="component" @click="copyNpmCommand('huberteatsinternalapp')">
            <img style="position:relative;top:10px;" height="40" src="https://static.thenounproject.com/png/32983-200.png"/> huberteatsinternalapp</p>
              <p class="description">Composant pas à jour.
              <p class="date">Publié le 19/01/2023</p>
            </p>
            </div>
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
  display: none;
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
    align-items: left;
    justify-content: space-around;
    background-color: white;
    align-items: left;
    width: 100%;
    gap: 15px;
    margin-left: 50px;
}

.description{
  font-size: 20px;
  color: rgb(61, 61, 61)
}

.component{
  font-size: 27px;
}

.component:hover{
  cursor: pointer;
  text-decoration: underline;
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

.date{
  font-family: "Fira Mono", "Andale Mono", "Consolas", monospace;
}

@media screen and (max-width: 1200px) {
}

</style>