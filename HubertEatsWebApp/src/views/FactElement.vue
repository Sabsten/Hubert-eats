<template>
  <div class="page">
    <img src="@/assets/back.png" width="49" height="42" @click="goBack()"/>
    <div class="description-background">
      <div class="description" >
        <FactCard :fact-id="parseInt(factId)"/>
      </div>
    </div>
    <div class="content">
      <div class="subtitle">Boisson: Choix</div>
      <div class="buttons">
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="-" @click="subQuantity()">
        <span class="quantities">{{quantity}}</span>
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="+" @click="addQuantity()">
      </div>
      <div class="subtitle">Plat: Choix</div>
      <div class="buttons">
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="-" @click="subQuantity()">
        <span class="quantities">{{quantity}}</span>
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="+" @click="addQuantity()">
      </div>
      <div class="buttons2">
        <input type="button" value="Valider" style="padding: 5px 13px 5px 13px; font-weight: bold;" @click="goBack()">
      </div>
      <div class="buttons">
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="-" @click="subQuantity()">
        <span class="quantities">{{quantity}}</span>
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="+" @click="addQuantity()">
      </div>
      <div class="subtitle">Déssert: Choix</div>
      <div class="buttons">
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="-" @click="subQuantity()">
        <span class="quantities">{{quantity}}</span>
        <input type="button" style="padding: 5px 13px 5px 13px; font-weight: bold; font-size: 15px;" value="+" @click="addQuantity()">
      </div>
      <div class="buttons2">
        <input type="button" value="Valider" style="padding: 5px 13px 5px 13px; font-weight: bold;" @click="goBack()">
      </div>
    </div>
  </div>
</template>


<script lang="ts">
import { computed, ComputedRef, defineComponent } from 'vue'
import { useRoute } from 'vue-router'
import { useRouter } from 'vue-router'
import FactCard from '@/components/FactCard.vue'

export default defineComponent({
  components: { FactCard },
  data(){
    return {
      quantity: 0
    }
  },
  methods:{
    addQuantity(){
      this.quantity += 1
    },
    subQuantity(){
      if(this.quantity > 0){
        this.quantity -= 1
      }
    }
  },
  setup() {
    const routeLocation = useRoute()
    const router = useRouter()
    const goBack = () => {
    router.push({ path: `/facts` })
  };
    const factId = computed(() => routeLocation.params.id) as ComputedRef<string>
      
    return { factId, goBack }
  }
})
</script>

<style scoped>
.description-background{
  background: linear-gradient(black,80%, rgb(126, 164, 216));
  padding-bottom: 10px;
}
.description{
  border-bottom-left-radius: 40px;
  border-bottom-right-radius: 40px;
  padding-bottom: 10px;
  background: linear-gradient(black,70%, #84c05a);
}
.buttons{
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
  margin-top: 30px;
  margin-bottom: 0px;
  margin-left: 20px;
  margin-right: 20px;
}

.buttons2{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  margin-top: 30px;
  margin-bottom: 0px;
  margin-left: 20px;
  margin-right: 20px;
}

img{
  position: absolute;
}

.subtitle{
  font-size: 20px;
  font-weight: bold;
  margin-top: 0px;
  margin-bottom: 20px;
  font-family: helvetica;
  text-align: center;
  background-color: rgb(126, 164, 216);
  padding: 10px;
}

.quantities{
  font-size: 20px;
  font-weight: bold;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: helvetica;
  text-align: center;
}

.content{
  display: flex;
  flex-direction: column;
}

</style>