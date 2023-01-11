<template>
    <div class="content">
      <div class="links">
        <HeaderLink to="/profile" exact></HeaderLink>
        <HeaderLink to="/facts"></HeaderLink>
        <HeaderLink to="/basket"></HeaderLink>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  import HeaderLink from './HeaderLinks.vue'
  
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