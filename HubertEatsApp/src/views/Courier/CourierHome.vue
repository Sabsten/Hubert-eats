<template>
    <div class="courierHome">
        <div class="courierHeader">
            <router-link to="/livreurs/compte"><i class="fa-solid fa-user"></i></router-link>
            <img src="/logo_light.png"/>
        </div>
        <div class="ordersContent">
            <h1>Aucune commandes actuellement disponible ...</h1>
        </div>
        <div class="courierBottom">
            <div class="tinderButton"><i class="fa-solid fa-xmark"></i></div>
            <div class="tinderButton"><i class="fa-solid fa-bicycle"></i></div>
        </div>
    </div>
</template>

<style scoped>
.courierHeader {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin: 10px 0;
}
.fa-user {
    color:#3EBC72;
    font-size: 45px;
}
.fa-user:hover {
    cursor: pointer;
    transform: scale(1.1);
}
.courierHome {
    background-color: #E3EFEB;
    width:90%;
    display: flex;
    flex-direction: column;
}
.ordersContent {
    background-color: white;
    width: 100%;
    height:100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
.courierBottom {
    margin-top: 30px;
    margin-bottom: 30px;
    display: flex;
    justify-content:space-around;
}
/* BUTTONS */
.tinderButton {
    background-color: white;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50px;
    width:70px;
    height: 70px;
}
.tinderButton:hover {
    cursor: pointer;
    transform: scale(1.1);
}
.tinderButton i{
    font-size: 40px;
}
.fa-xmark {
    color:red;
}
.fa-bicycle {
    color:#3EBC72;
}
</style>