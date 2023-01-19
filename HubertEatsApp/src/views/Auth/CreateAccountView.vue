<script setup lang="ts">
import type { CreateForm } from '@/models/createForm';
import { useAuthStore } from '@/stores/auth';
import { defineComponent, ref, type Ref } from 'vue';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';

const authStore = useAuthStore();
const routeLocation = useRoute();
const router = useRouter();
const goToLogin = () => {
  router.push({ path: `/login` });
};
let err: Ref<string | null> = ref(null);

let mail: string | undefined;
let password: string | undefined;
let referent: string | undefined;
let firstname: string | undefined;
let lastname: string | undefined;
let name: string | undefined;
let accountType: Ref<string> = ref('customer');
let street_name:string | undefined;
let street_number: number | undefined;
let city:string | undefined;
let postal_code: number | undefined;

async function createAccount(){
  const form: CreateForm = {
    account: {
      mail: mail,
      password: password,
      referent: referent
    },
    firstname: firstname,
    lastname: lastname,
    name: name,
    address: {
      street_name: street_name,
      street_number: street_number,
      city: city,
      postal_code: postal_code,
    }
  }
  err.value = await authStore.createAccount(accountType.value, form);
  if (err.value === null){
    switch(accountType.value) {
      case 'customer':
        router.push({ path: '/customer'});
        break;
      case 'courier':
        router.push({ path: '/courier'});
        break
      case 'restaurant':
        router.push({ path: '/home'});
    }
  }
}
</script>


<template>
    <div class="page">
        <div class="presentation">
          <h1>Bonjour !</h1>
          <input class="sign_in button" type="button" value="CONNEXION" @click="goToLogin()">
        </div>
        <div class="rightPart">
          <h2>
            Créer un compte
          </h2>
            <form class="loginForm" @submit.prevent="createAccount()">
                <div class="inputs1">
                    <input class="shadow" type="email" v-model="mail" placeholder="Entrez un mail" required/>
                    <input class="shadow" type="password" v-model="password" placeholder="Entrez un mot de passe" required/>
                </div>
                <div class="wrapper">
                  <input v-model="accountType" value="customer" type="radio" name="select" id="option-1" checked required>
                  <input v-model="accountType" value="restaurant" type="radio" name="select" id="option-2">
                  <input v-model="accountType" value="courier" type="radio" name="select" id="option-3">
                    <label for="option-1" class="option option-1">
                      <div class="dot"></div>
                        <span>Client</span>
                        </label>
                    <label for="option-2" class="option option-2">
                      <div class="dot"></div>
                        <span>Restaurant</span>
                    </label>
                    <label for="option-3" class="option option-3">
                      <div class="dot"></div>
                        <span>Livreur</span>
                    </label>
                </div>
                <div class="inputs1">
                    <input v-if="accountType !== 'restaurant'" class="shadow" type="text" v-model="firstname" placeholder="Prénom" required/>
                    <input v-if="accountType !== 'restaurant'" class="shadow" type="text" v-model="lastname" placeholder="Nom" required/>
                    <input v-if="accountType === 'restaurant'" class="shadow" type="text" v-model="name" placeholder="Nom du restaurant" required/>
                    <input class="shadow" type="text" v-model="referent" placeholder="Parrain"/>
                </div>
                <span class="subtitle">Adresse :</span>
                <div class="inputs2">
                  <div>
                    <input class="shadow" type="text" v-model="street_name" placeholder="Nom de la rue" required/>
                    <input class="shadow small" type="number" v-model="street_number" placeholder="Numéro de la rue" required/>
                  </div>
                  <div>
                    <input class="shadow small" type="text" v-model="city" placeholder="Ville" required/>
                    <input class="shadow small" type="number" v-model="postal_code" placeholder="Code postal" required/>
                    </div>
                </div>
                <button class="sign_up button" type="submit">S'ENREGISTRER</button>
                <span v-if="err !== null">{{ err }}</span>
            </form>
            <div class="connectMessage">
              <span><br><br>Vous avez déjà un compte?<br>
              <a href="#" @click="goToLogin()">Se connecter</a></span>
            </div>
        </div>
    </div>
</template>
  
<style scoped>
.subtitle{
  color:black;
  text-decoration: underline;
  font-weight: bold;
}

.page {
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 100vh;
  width: 100%;
}
.presentation{
  background-color: var(--green);
  height: 100%;
  width: 50%;
  display: flex;
  flex-direction: column;
  gap: 200px;
  justify-content: center;
  align-items: center;
}
.loginForm{
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: start;
  gap: 30px;
  align-items: center;
}

h1{
  font-size: 50px;
  color: white;
}

h2{
  font-size: 50px;
  margin-top: 10%;
  margin: 30px;
  text-align: center;
  color: var(--green);
  font-weight: bold;
}

.sign_in{
  font-size: 20px;
  color: var(--green);
  text-align: center;
  border-radius: 30px;
  width: 50%;
  font-weight: bold;
  padding: 10px;
  border-color: transparent;
}

.sign_up{
  font-size: 20px;
  color: white;
  background-color: var(--green);
  text-align: center;
  border-radius: 30px;
  width: 200px;
  font-weight: bold;
  padding: 10px;
  border-color: transparent;
}

.rightPart{
  border-top-right-radius: 10px;
  border-bottom-right-radius: 10px;
  width: 100%;
  height: 100%;
  background-color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: stretch;
}

.shadow{
  border: 1px solid #DEDEDE;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  border-radius: 10px;
  border-width: 1px;
  border-color: rgb(165, 163, 163);
  width: 200px;
  height: 30px;;
}

.small{
  width: 100px;
}


fieldset{
  border: none;
  color: black;
  font-size: 20px;
}

.inputs1{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  gap: 30px;
  flex-wrap: wrap;
}

.inputs2{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 30px;
}

.inputs2 input{
  margin: 0px 20px;
}

/* Radio button */
.wrapper{
  display: inline-flex;
  height: 85px;
  width: 350px;
  align-items: center;
  justify-content: space-evenly;
  border-radius: 5px;
  padding: 20px 15px;
}
.wrapper .option{
  background: #fff;
  height: 100%;
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  margin: 0 10px;
  border-radius: 5px;
  cursor: pointer;
  padding: 0 10px;
  border: 2px solid lightgrey;
  transition: all 0.3s ease;
}
.wrapper .option .dot{
  height: 20px;
  width: 20px;
  background: #d9d9d9;
  border-radius: 50%;
  position: relative;
}
.wrapper .option .dot::before{
  position: absolute;
  content: "";
  top: 4px;
  left: 4px;
  width: 12px;
  height: 12px;
  background: #5ac085;
  border-radius: 50%;
  opacity: 0;
  transform: scale(1.5);
  transition: all 0.3s ease;
}
input[type="radio"]{
  display: none;
}
#option-1:checked:checked ~ .option-1,
#option-2:checked:checked ~ .option-2,
#option-3:checked:checked ~ .option-3{
  border-color: #5ac085;
  background: #5ac085;
}
#option-1:checked:checked ~ .option-1 .dot,
#option-2:checked:checked ~ .option-2 .dot,
#option-3:checked:checked ~ .option-3 .dot{
  background: #fff;
}
#option-1:checked:checked ~ .option-1 .dot::before,
#option-2:checked:checked ~ .option-2 .dot::before,
#option-3:checked:checked ~ .option-3 .dot::before{
  opacity: 1;
  transform: scale(1);
}
.wrapper .option span{
  font-size: 20px;
  margin-left: 10px;
  color: #808080;
}
#option-1:checked:checked ~ .option-1 span,
#option-2:checked:checked ~ .option-2 span,
#option-3:checked:checked ~ .option-3 span{
  color: #fff;
}

.connectMessage{
  display: none;
  text-align: center;
  margin-top: 30px;
}
.button:hover {
  cursor:pointer;
}

@media screen and (max-width: 700px) {
    .page {
        flex-direction: column;
    }
    .presentation{
      width: 100%;
      height: 150px;
    }
    .sign_in{
      display: none;
    }
    .connectMessage{
      display: contents;
    }
    .rightPart{
      max-height: calc(100% - 200px);
    }
    .page{
    min-height: 900px;
    }

    .wrapper{
      display: inline-flex;
      flex-direction: column;
      height: 85px;
      width: 150px;
      align-items: center;
      justify-content: space-evenly;
      border-radius: 5px;
      padding: 0px 15px;
    }

    .wrapper .option{
      justify-content: left;
    }

    .page{
      height: 100%;
    }

    .inputs2{
      display: flex;
      flex-direction: row;
      justify-content: center;
      align-items: center;
      gap: 20px;
    }

    .inputs2 input{
      margin-bottom: 10px;
    }
}

</style>
  