<script lang="ts">
import HeaderContent from '@/components/HeaderContent.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  components: {
    HeaderContent
  }
})
</script>

<template>
  <div class="greetings">
    <HeaderContent />
    <h3>
      You’ve successfully created a project with
    </h3>
  </div>
</template>

<style scoped>
</style>
