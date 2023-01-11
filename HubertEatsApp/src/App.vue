<script lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderContent from '@/components/HeaderContent.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  data() {
    return{
      enterClass: 'fade',
      leaveClass: 'fade'
    }
  },
  components: { HeaderContent },
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
  <main>
  <div class="container-fluid">
    <!-- "router-view" is a component that is defined by Vue Router -->
     <router-view class="test" v-slot="{Component}">
      <transition
      :enter-active-class="enterClass"
      :leave-active-class="leaveClass">
        <component :is="Component"/>
      </transition>
  </router-view>
  </div>
  <!-- <HeaderContent class="bar"/> -->
  </main>
</template>

<style scoped>

.container-fluid{
  display: flex;
  flex-direction: column;
  height: calc(100vh - 0px);
}

/* Change animation settings */
.animate__animated.animate__fadeIn {
  --animate-duration: 1s;
}
.animate__animated.animate__fadeOut {
  --animate-duration: 0.2s;
}

.animate__animated.animate__fadeInLeft {
  --animate-duration: 1s;
}
.animate__animated.animate__fadeOutRight {
  --animate-duration: 0.5s;
}

.animate__animated.animate__fadeInRight {
  --animate-duration: 1s;
}
.animate__animated.animate__fadeOutLeft {
  --animate-duration: 0.5s;
}
</style>
