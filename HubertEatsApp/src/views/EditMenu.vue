<script lang="ts">
import { defineComponent } from 'vue'
import { ref } from "vue";
import { useRouter } from 'vue-router'
import { useRoute } from 'vue-router'
import { products } from '@/assets/products'
import { computed } from 'vue'
import CardProduct from '@/components/CardProduct.vue'
import HeaderContent from '@/components/HeaderContentRestorator.vue'

export default defineComponent({
  setup() {
    const router = useRouter()
    let input = ref("");
    const onEdit = () => {
      console.log("edit")
      router.go(-1)
    }
    const onDelete = () => {
      console.log("delete")
        router.go(-1)
    }
    return { products, input, onEdit, onDelete}
  },
  data: () => ({
    list1: [
        {text: "fds"},
        {test: "fdsqf"}
    ]
  }),
  computed: {
    cssVars() {
      return {
        '--fact-image': `url(${products[parseInt(useRoute().params.id[0])].image})`
      }
    }
  },
  components: {
    CardProduct,
    HeaderContent
  }
})

</script>

<template>
  <div class="page">
      <div class="top" z-index="300">
        <HeaderContent/>
        <div class="title">Édition d'un produit</div>
      </div>
      <div class="bottom">
        <form @submit.prevent="">
            <input class="shadow" type="text" placeholder="Nom du menu" />
            <input class="shadow price" type="number" placeholder="Prix du menu" />
            <input class="shadow" type="url" placeholder="Lien de l'image" />

            <h2>Entrées</h2>
            <div class="shopsElements" cellspacing="10" cellpadding="0">
                <div class="element" v-for="(product, i) in products" :key="i" @click="">
                    <button value="0" v-on:click="">
                        <CardProduct :element=product />    
                    </button>
                </div>
            </div>
            <h2>Plats</h2>
            <div class="shopsElements" cellspacing="10" cellpadding="0">
                <div class="element" v-for="(product, i) in products" :key="i" @click="">
                    <button value="1" v-on:click="">
                        <CardProduct :element=product />
                    </button>
                </div>
            </div>

            <div class="endForm">
                <button class="delete" cli type="submit" @click="onDelete()">Supprimer</button>
                <button class="edit" type="submit" @click="onEdit()">Modifier</button>
            </div>
        </form>
        
    </div>
  </div>
</template>

<style scoped>
  *{
    color: black;
  }

  .page{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    height: calc(100% - 150px);
    flex-direction: column;
    background-color: #D8E3E2;
  }

  h1{
    font-family: 'Roboto';
    font-style: normal;
    font-weight: 700;
    font-size: 40px;
    line-height: 47px;
    display: flex;
    align-items: center;
    color: #000000;
  }

  p{
    font-family: 'Roboto';
  }

  .bottom{
    background-color: white;
    width: 100%;
    margin-top: 40px;
  }


  .top{
    width: 100%;
    display: flex;
    flex-direction: column;
    text-align: center;
  }

  .title{
    font-family: 'Roboto';
    font-style: normal;
    font-weight: 700;
    font-size: 35px;
    line-height: 47px;
    display: flex;
    align-items: center;
    color: #000000;
    margin-top: 30px;
    margin-left: 50px;
  }
/* Table */

.shopsElements{
  display: flex;
  flex-direction: row;
  gap: 40px;
  justify-content: center;
  margin: 20px;
  align-items: center;
  flex-wrap: wrap;
}

.element:hover{
  cursor: pointer;
  transform: scale(1.1);
}


form{
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 20px;
    margin-top: 50px;
  }

  .shadow{
  border: 1px solid #DEDEDE;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  border-radius: 5px;
  border-width: 1px;
  border-color: rgb(165, 163, 163);
  width: 200px;
  height: 30px;
}

.edit{
  font-size: 20px;
  color: white;
  background-color: #3EBC72;
  text-align: center;
  border-radius: 30px;
  width: 170px;
  font-weight: bold;
  padding: 5px;
  border-color: transparent;
}

.delete{
  font-size: 20px;
  color: white;
  background-color: #DD2F2F;
  text-align: center;
  border-radius: 30px;
  width: 170px;
  font-weight: bold;
  padding: 5px;
  border-color: transparent;
}

.endForm{
    display: flex;
    flex-direction: row;
    justify-content: center;
    width: 100%;
    margin-top: 50px;
    margin-bottom: 50px;
    gap: 20px;
    padding-left: 50px;
    padding-right: 50px;
}

button{
  border-radius: 5px;
  padding: 5px;
}

button[value="1"]{
  background-color: var(--green);
  color: white;
  width: 170px;
  font-weight: bold;
  padding: 5px;
  border-color: transparent;
}


</style>
