<script lang="ts">
import { computed, defineComponent } from 'vue'
import { useRoute } from 'vue-router'

export default defineComponent({
  props: {
    to: { type: String, required: true },
    exact: { type: Boolean, default: false }
  },
  setup(props) {
    const route = useRoute()
    const active = computed(() =>
      props.exact ? route.path === props.to : route.path.startsWith(props.to)
    )
    return { active }
  }
})
</script>

<template>
  <div>
    <router-link
      :to="to"
      
    >
      <slot />
    </router-link>
  </div>
</template>
<!-- :class="active ? null : 'font-weight-bold'" -->

<style scoped>
  
</style>