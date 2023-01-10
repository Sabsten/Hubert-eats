<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goToLogin = () => {
    router.push({ path: `/profile` })
  }
    const goToHome = () => {
    router.push({ path: `/basket` })
  }
    return { goToLogin,  }
  }
})
</script>


<template>
    <div class="page">
      <div class="presentation">
        <h1>Hello !</h1>
        <input class="sign_in" type="button" value="SIGN IN" @click="goToLogin()">
        </div>
        <div class="rightPart">
          <h2>
            Create an account
          </h2>
            <form class="loginForm" @submit.prevent="goToHome()">
                <div class="inputs1">
                    <input class="shadow" type="email" id="email" name="email" placeholder="Entrez un pseudo"/>
                    <input class="shadow" type="password" id="password" name="password" placeholder="Entrez un pseudo"/>
                </div>
                <div class="wrapper">
                  <input type="radio" name="select" id="option-1" checked>
                  <input type="radio" name="select" id="option-2">
                  <input type="radio" name="select" id="option-3">
                    <label for="option-1" class="option option-1">
                      <div class="dot"></div>
                        <span>Customer</span>
                        </label>
                    <label for="option-2" class="option option-2">
                      <div class="dot"></div>
                        <span>Restaurant</span>
                    </label>
                    <label for="option-3" class="option option-3">
                      <div class="dot"></div>
                        <span>Courier</span>
                    </label>
                </div>
                <div class="inputs1">
                    <input class="shadow" type="email" id="email" name="email" placeholder="First name"/>
                    <input class="shadow" type="password" id="password" name="password" placeholder="Last name"/>
                    <input class="shadow" type="password" id="password" name="password" placeholder="Referent"/>
                </div>
                <span class="subtitle">Address :</span>
                <div class="inputs1">
                    <input class="shadow" type="email" id="email" name="email" placeholder="Steet name"/>
                    <input class="shadow small" type="password" id="password" name="password" placeholder="Streen number"/>
                    <input class="shadow small" type="password" id="password" name="password" placeholder="City"/>
                    <input class="shadow small" type="email" id="email" name="email" placeholder="Postal code"/>
                    <input class="shadow small" type="password" id="password" name="password" placeholder="Country"/>
                </div>
                <button class="sign_up" type="submit">SIGN UP</button>
            </form>
        </div>
    </div>
</template>
  
<style scoped>
.subtitle{
  color:black;
  text-decoration: underline;
  width: 100%;
  margin-left: 30%;
  font-weight: bold;
}

.page {
  display: flex;
  align-items: center;
  margin-bottom: 1rem;
  height: 100%;
  width: 100%;
}
.presentation{
  background-color: #3EBC72;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
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
  border-bottom-right-radius: 10px;
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
  color: #3EBC72;
  font-weight: bold;
}

.sign_in{
  font-size: 20px;
  color: #3EBC72;
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
  background-color: #3EBC72;
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

</style>
  