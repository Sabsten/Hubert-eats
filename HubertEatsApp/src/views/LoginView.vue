<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goToCreateAccount = () => {
    router.push({ path: `/signup` })
  }
    const goToHome = () => {
    router.push({ path: `/home` })

  }
    return { goToCreateAccount, goToHome }
  }
})
</script>

<template>
    <div class="page">
      <div class="presentation">
        <h1>Hello !</h1>
        <input class="sign_up" type="button" value="SIGN UP" @click="goToCreateAccount()">
        </div>
        <div class="rightPart">
          <h2>
            Connect to your account
          </h2>
            <form class="loginForm" @submit.prevent="goToHome()">
                <input class="shadow" type="email" id="email" name="email" placeholder="Entrez un pseudo"/>
                <input class="shadow" type="password" id="password" name="password" placeholder="Entrez un pseudo"/>
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
                <button class="sign_in" type="submit">SIGN IN</button>
            </form>
        </div>
    </div>
</template>
  
<style scoped>
.page {
  display: flex;
  align-items: center;
  height: 100vh;
  width: 100%;
}
.presentation{
  background-color: #3EBC72;
  color: white;
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
}

h2{
  font-size: 50px;
  margin-top: 10%;
  margin: 30px;
  text-align: center;
  color: #3EBC72;
  font-weight: bold;
}

.sign_up{
  font-size: 20px;
  color: #3EBC72;
  text-align: center;
  border-radius: 30px;
  width: 50%;
  font-weight: bold;
  padding: 10px;
  border-color: transparent;
}

.sign_in{
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
  border-radius: 5px;
  border-width: 1px;
  border-color: rgb(165, 163, 163);
  width: 200px;
  height: 30px;
}

.shadow:hover{
  border: transparent
}

fieldset{
  border: none;
  color: black;
  font-size: 20px;
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
  