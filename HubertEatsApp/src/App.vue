<script lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderContent from '@/components/HeaderContent.vue'
import { defineComponent } from 'vue'
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'
import CartPage from './components/CartPage.vue'

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
    const cancelCart = () => {
      router.push({ path: route.fullPath })
    }
    return { cancelCart, route }
  },
  components: { HeaderContent, CartPage },
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
console.log(import.meta.env.MODE);
</script>

<template>
  <main>
    <!-- "router-view" is a component that is defined by Vue Router -->
     <router-view v-slot="{Component}">
      <transition
      :enter-active-class="enterClass"
      :leave-active-class="leaveClass">
        <component :is="Component"/>
      </transition>

      <!-- Show the cart for any page -->
      <transition name="fade" :duration="{enter:1000, leave:200}">
          <CartPage class="element" v-if="route.query.cart=='true'"/>
      </transition>
      <transition name="fade" :duration="{enter:1000, leave:200}">
        <div @click="cancelCart()" class="background" v-if="route.query.cart=='true'">
        </div>
      </transition>
  </router-view>
  <!-- <HeaderContent class="bar"/> -->

  
  </main>
</template>

<style scoped>
body {
  margin:0;
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
  top: 0;
  left: 50%;
  transform: translate(-50%, 0);
  overflow: auto;
  min-width: 450px;
  height: 50vh;
  z-index: 101;
  border-radius: 10px;
  margin-top: 40px;
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
</style>
