<script lang="ts">
import { defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'

export default defineComponent({
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goToPurchase = () => {
    router.push({ path: `/purchase` })
  }
    return { goToPurchase }
  }
})
</script>

<template>
  <div class="pageComponent">
    <div class="listOrder">
      <div class="element">
          
          <h1>Krousty</h1>
          <p>12 boulevard des platanes,<br>
31000 Toulouse</p>
          <div class="elementInfo">
              <div class="add-sub">
                  <i class="fa-solid fa-minus"></i>
                  <span>10</span>
                  <i class="fa-solid fa-plus"></i>
              </div>
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
          <hr size="1" color="white" width="100%">
          <div class="elementInfo">
              <div class="add-sub">
                  <i class="fa-solid fa-minus"></i>
                  <span>10</span>
                  <i class="fa-solid fa-plus"></i>
              </div>
              <div class="description">
                  <div class="name">Nom du produit</div>
                  <div class="price">20 €</div>
              </div>
              <div class="image">
                  <img width="100px" src="https://media.istockphoto.com/id/495204032/fr/photo/frais-savoureux-hamburger.jpg?s=612x612&w=0&k=20&c=1fXLZOBtqU_AHj-v-IH6rV6BL5vr3d95P_BGr69KC3E=">
              </div>
          </div>  
          <hr size="1" color="white" width="100%">
          <input type="button" @click="goToPurchase()" class="confirm" value="Commander . 16€"> 
      </div>

      <div class="element">
          
          <h1>McDO</h1>
          <p>12 boulevard des platanes,<br>
31000 Toulouse</p>
          <div class="elementInfo">
              <div class="add-sub">
                  <i class="fa-solid fa-minus"></i>
                  <span>10</span>
                  <i class="fa-solid fa-plus"></i>
              </div>
              <div class="description">
                  <div class="name">Nom du produit</div>
                  <div class="price">20 €</div>
              </div>
              <div class="image">
                  <img width="100px" src="https://media.istockphoto.com/id/495204032/fr/photo/frais-savoureux-hamburger.jpg?s=612x612&w=0&k=20&c=1fXLZOBtqU_AHj-v-IH6rV6BL5vr3d95P_BGr69KC3E=">
              </div>
          </div> 
          <hr size="1" color="white" width="100%"> 
          <input type="button" @click="goToPurchase()" class="confirm" value="Commander . 16€"> 
      </div>
      
    </div>
  </div>
</template>

<style scoped>

*{
color: white;
}
.pageComponent{
display: flex;
flex-direction: row;
min-height: 90vh;
justify-content: start;
align-items: center;
width: 100%;
flex-direction: column;
background-color: var(--green);
}


.listOrder{
  display:flex;
  flex-direction: column;
  gap: 10px;
}


.confirm{
  background-color: white;
  color: black;
  padding: 20px 40px;
  font-family: 'Roboto';
  font-style: normal;
  font-weight: 700;
  font-size: 20px;
  border-color: transparent;
  border-radius: 10px;
  margin-top: 20px;
}

.elementInfo{
  display: flex;
  flex-direction: row;
  gap: 20px;
  margin-bottom: 20px;
}

i{
  padding: 20px;
}

.name{
  font-size: 20px;
}

.element{
  display:flex;
  flex-direction: column;
  margin-bottom: 20px;
}
</style>
