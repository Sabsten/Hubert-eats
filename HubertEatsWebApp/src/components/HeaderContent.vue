<template>
  <div class="content">
    <div class="links">
      <HeaderLink to="/profile" exact> <img src="@/assets/cart2black.png" width="40" height="40"> </HeaderLink>
      <HeaderLink to="/facts"> <img src="@/assets/home2.png" width="50" height="50"> </HeaderLink>
      <HeaderLink to="/basket"> <img src="@/assets/profil.png" width="40" height="40"> </HeaderLink>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HeaderLink from './HeaderLink.vue'

export default defineComponent({
  components: { HeaderLink }
})
</script>

<style scoped>
.links{
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: space-around;
  align-items: center;
  text-align: center;
  border: 2px solid black;
  background: black
}
img{
  filter: invert(100%) sepia(100%) saturate(1%) hue-rotate(183deg) brightness(103%) contrast(101%);
}

</style>