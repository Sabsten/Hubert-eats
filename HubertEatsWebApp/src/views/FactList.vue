<template>
  <div class="page">
    <div class="searchBar">
    <input type="text"  placeholder="Search a restaurant..."/>
    </div>
    <div class="table-wrapper">
      <div class="table-scroll">
        <table class="FactTable" cellspacing="10" cellpadding="0">
          <tr class="clickable" v-for="(fact, i) in facts" :key="i"
            @click="goToFact(i)">
            <td class="row-content">
              <div class="left-part">
                <div class="picRow">
                  <img :src="fact.image" width="75" height="75" class="pic" />
                </div>
                <div class="descriptionRow">
                  <div class="restaurantName">{{ fact.text }}</div>
                  <div class="address">{{ fact.address }}</div>
                </div>
              </div>
              <div class="right-part"> 
                <div v-for="(tag, i) in fact.tags" :key="i">
                  <div class="tag-element" :class="tag">{{ tag }}</div>
                </div>
              </div>
            </td>
          </tr>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { facts } from '@/assets/enterprises'
import { useRouter } from 'vue-router'
import { ref } from "vue";

export default defineComponent({
  setup() {
    const router = useRouter()
    let input = ref("");

    const goToFact = (id: number) => {
      router.push({ path: `/fact/${id}` })
    }
    return { facts, goToFact, input}

  }
})
</script>

<style scoped>
td {
  border: 1px solid rgb(131, 148, 133);
  border-radius: 10px;
  background: white;
}

.clickable:hover {
  cursor: pointer;
  transform: scale(1.02);
}

/* Allow the table to be scrollable */
.table-scroll {
  overflow: auto;
  max-height: 85vh;
}


/* Wrapper contains all the table and the scroll*/
.table-wrapper table {
  width: 100%;
}

.pic {
  /*border-radius: 50%;*/
  height: 97px;
  width: 97px;
  border-radius: 10px;
  position: relative;
  top: 2px;
  left: 2px;
}

.descriptionRow{
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  justify-content: flex-start;
  margin-top: 10px;
} 

.left-part{
  display:flex;
  flex-direction: row;
  justify-content: flex-start;
  gap: 10px;
}


.right-part{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-around;
  align-items: center;
  height: 100px;
  max-width: 300px;
}

.tag-element{
  background-color: rgb(102, 175, 102);
  border-radius: 10px;
  padding: 5px;
  margin: 5px;
  font-size: 14px;
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: bold;
  color: white;
}

.Burger{
  background-color: rgb(190, 68, 68);
}
.Fast, .Food{
  background-color: rgb(226, 169, 62);
}
.Burger{
  background-color: rgb(190, 68, 68);
}

.Pizza{
  background-color: rgb(6, 150, 30);
}
.Sushi{
  background-color: rgb(95, 6, 167);
}

/*.price{
  font-size: 40px;
  padding: 10px;
  border-radius: 20px;
  font-family: 'calibri', 'sans-serif';
  font-weight: bold;
  margin-right: 30px;
  background-color: rgb(102, 175, 102);
}*/


.restaurantName{
  font-size: 16px;
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: bold;
}
.address{
  font-size: 14px;
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
  max-width: 200px;
  margin-top: 10px;
}




/* Navigation bar on the top */

.searchBar input{
  border: 0px solid white;
  border-radius: 5px;
  font-size: 20px;
  padding-left: 10px;
  -moz-box-sizing: border-box; 
  -webkit-box-sizing: border-box;     
  box-sizing: border-box; 
  margin: 5px;
  background-image: url(@/assets/search.png);
  background-repeat: no-repeat;
  text-indent: 20px;
  background-size: 20px;
  background-position: 5px;
  height: 38px;
  width: 100%;
}
.searchBar{
  background-color: #c9c9ce;
  height: 50px;
  width: 100%;
  padding-right: 10px;
  -moz-box-sizing: border-box; 
  -webkit-box-sizing: border-box;     
  box-sizing: border-box; 
}

.row-content{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  padding-right: 10px;
}
</style>
