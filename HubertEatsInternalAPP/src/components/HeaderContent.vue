<script setup lang="ts">
import { defineComponent } from 'vue'
import {useRouter} from 'vue-router'
import { useRoute } from 'vue-router'

const route = useRoute()
const router = useRouter()

function logout() {
  router.push('/');
  localStorage.removeItem('TOKEN');
}
</script>


<template>
    <div class="content">
      <img src="@/assets/HubertEatsLogov2.png" width="200">
      <div class="title">
        {{title}}
      </div>
      <button @click="logout()">
        Deconnect
      </button>
    </div>
</template>

  
  <style scoped>
.content{
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: center;
  height: 96px;
  gap: 50px;
  background-color: var(--green);
}

.title{
    font-size: 30px;
    font-weight: 700;
    color: var(--white);
    margin-left: 20px;
}




@media screen and (max-width: 550px) {
  .content{
    justify-content: left;
  }
  img{
    display: none;
  }
}

  </style>