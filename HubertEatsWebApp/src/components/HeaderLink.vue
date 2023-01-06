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
      :class="active ? null : 'font-weight-bold'"
    >
      <slot />
    </router-link>
  </div>
</template>

<style scoped>
.font-weight-bold {
  font-weight: bold;
  filter: invert(31%) sepia(0%) saturate(2388%) hue-rotate(317deg) brightness(104%) contrast(90%);
}
</style>