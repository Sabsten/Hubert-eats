<script setup lang="ts">
import type { IOrders } from '@/models/order';


const props = defineProps<{
    order: IOrders,
}>();

</script>

<template>
    <div class="order">
        <span><b>Commande n°{{ props.order._id }}</b></span>
        <br>
        <div v-for="article in props.order.articles">
            <span>{{ article.name }} x {{ article.quantity }}</span>
        </div>
        <span><b>{{ props.order.price }} €</b></span>
    </div>
</template>

<style lang="scss" scoped>
.order {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding:10px;
    border: 2px solid #6B706E;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    border-radius: 30px;
}
</style>