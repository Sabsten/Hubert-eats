<template>
    <div class="payment">
      <div class="rectangle">
        <div class="subName">Carte de Crédit</div>
            <input type="number" placeholder="Numéro de carte" class="inputPaymentNumCard">
            <div class="inputs">
                <input type="text" placeholder="Nom du Titulaire" class="inputPaymentOther">
                <input type="text" placeholder="Date d'expiration" class="inputPaymentOther">
                <input type="text" placeholder="CVV" class="inputPaymentOther">
            </div>
        </div>
      </div>
</template>

<style scoped>


.payment{
  font-size: 25px;
  display: flex;
  flex-direction: column;
  column-gap: 30px;
  max-width: 1000px;
}


input {
    border-radius: 5px;
    filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
    padding: 5px;
    text-align: center;
}

.inputPaymentNumCard{
    width:70%;
    margin-bottom: 30px;
}

.inputs{
    width: 80%;
    display: flex;
    flex-direction: row;
    align-items: right;
    justify-content: center;
    gap: 20px;
}

.inputPaymentOther{
    width: 30%;
}

.rectangle {
  padding: 20px;
  background: #2A360F;
  border-radius: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.subName{
  width: 100%;
  font-size: 20px;
  color: white;
  display: flex;
  flex-direction: column;
  margin-left: 30px;
  margin-bottom: 30px;
}

</style>