<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'
import CardPayment from '@/components/CardPayment.vue'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goBack = () => {
        router.go(-1)
    }
    return{ goBack }
  },
  components: {
    CardPayment
  }
})
</script>

<template>
   <div class="page">
    <div class="left-part">
        <div class="left-header">
            <i class="fa-solid fa-circle-arrow-left fa-2xl" @click="goBack()"></i>
            <img src="@/assets/HubertEatsLogo.png" width="250">
            <div></div>
        </div>

        <div class="left-body">
            <div class="editAddress">
                <div class="name">
                    Adresse de livraison <i class="fa-solid fa-pen-to-square"></i>
                </div>
                <input type="button" value="Modifier">
            </div>
            <CardPayment></CardPayment>
            <input class="confirm" type="button" value="Payer . 16€">
        </div>
        <div></div>
    </div>
    <div class="right-part">
        <div class="element">
            <div class="shop">
            <h1>Krousty</h1>
            <p>12 boulevard des platanes,<br>
31000 Toulouse</p>
</div>
            <div class="elementInfo">
                <div class="description">
                    <div class="name">Nom du menu</div>
                    <div class="price">10 €</div>
                    <div class="quantity">- Element1</div>
                    <div class="quantity">- Element2</div>
                </div>
                <div class="image">
                    <img width="100px" src="https://media.istockphoto.com/id/495204032/fr/photo/frais-savoureux-hamburger.jpg?s=612x612&w=0&k=20&c=1fXLZOBtqU_AHj-v-IH6rV6BL5vr3d95P_BGr69KC3E=">
                </div>
            </div> 
            <hr size="2" color="black">
            <div class="elementInfo">
                <div class="description">
                    <div class="name">Nom du produit</div>
                    <div class="price">20 €</div>
                </div>
                <div class="image">
                    <img width="100px" src="https://media.istockphoto.com/id/495204032/fr/photo/frais-savoureux-hamburger.jpg?s=612x612&w=0&k=20&c=1fXLZOBtqU_AHj-v-IH6rV6BL5vr3d95P_BGr69KC3E=">
                </div>
            </div>
            <hr size="2" color="black">
        </div>
        <div class="total">
            <div class="name">Total</div>
            <div class="price">30 €</div>
        </div>
    </div>
  </div>
</template>
  
<style scoped>
.page {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    min-height: 100vh;
}

.confirm{
    background-color: var(--green);
    color: white;
    padding: 10px 40px;
    font-family: 'Roboto';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    border-color: transparent;
    border-radius: 10px;
    margin-top: 20px;
}

.right-part{
    background-color: var(--light-green);
    min-height: 100vh;
    padding: 0px 20px;
    width: 40%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.left-part{
    min-height: 100vh;
    width: 60%;
    padding-left: 20px;
    padding-right: 20px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.left-header{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    width: 100%;
    margin-top: 20px;
}

.left-body{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.name{
    font-size: 20px;
}

.total{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    margin-top: 20px;
    width: 100%;
    font-size: 20px;
    font-weight: 800;
}

.elementInfo{
    display:flex;
    flex-direction: row;
    justify-content: space-between;
    width: 100%;
    margin-bottom: 20px;
    flex-wrap: wrap;
}

.element{
    width: 100%;
}

.shop{
    margin-bottom: 50px;
}

</style>
  