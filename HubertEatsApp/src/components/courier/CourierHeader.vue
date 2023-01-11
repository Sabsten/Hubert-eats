<script setup lang="ts">
const props = withDefaults(
    defineProps<{
        icon: String;
        link: String;
    }>(),
    {},
);
</script>

<template>
    <div class="courierHeader">
        <router-link :to=props.link.toString()><i :class=props.icon.toString()></i></router-link>
        <router-link to="/livreur"><img src="/logo_light.png"/></router-link>
    </div>
</template>

<style lang="scss">
.courierHeader {
    width:100%;
    height: fit-content;
    display: flex;
    justify-content: space-between;
    align-items: center;
    i {
        font-size: 45px;
        color: #3EBC72
    }
}
</style>