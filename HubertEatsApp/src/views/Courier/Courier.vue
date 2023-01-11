<template>
    <div class="courier-layout">
        <div class="sub-layout">
            <router-view />
        </div>
    </div>
</template>

<style scoped>
.courier-layout {
    background-color: #E3EFEB;
    width:100vw;
    height: 100vh;
    display: flex;
    justify-content: center;
}

.sub-layout {
    margin:4% 4%;
    width: inherit;
    display: flex;
    flex-direction: column;
}
</style>
