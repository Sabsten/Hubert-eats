<template>
    <div class="popup">
		<div class="contener">
			<div class="popup-inner">
				<slot />
				<div class="header">
					<h1>Éditer mon profil</h1>
					<img src="@/assets/profil2.png" width="50" height="50">
				</div>
				<div class="formFields">
					<input id="name" type="text" placeholder="Nom" />
					<input id="password" type="password" placeholder="Mot de passe" />
				</div>
				
			<img src="@/assets/form_pic.png" class="formPic">
			</div>
			<div>
				<button class="btnClose" @click="TogglePopup()">
					Annuler
				</button>
				<button class="btnValidation">
						Valider
				</button>
			</div>
		</div>
	</div>
</template>

<script lang="ts">
export default{
    props: ['TogglePopup']
}
</script>

<style scoped>
input {
  width: 200px;
  background: 
      linear-gradient(#000, #000) center bottom 5px /calc(100% - 10px) 1px no-repeat;
  background-color: #fcfcfc;
  border: none;
  
  padding: 10px;
}

input:focus{
	outline: none;
	background: 
      linear-gradient(#000, #000) center bottom 5px /calc(100% - 10px) 2px no-repeat;
}

.popup {
	position: fixed;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	z-index: 99;
	background-color: rgba(0, 0, 0, 0.2);
	
	display: flex;
	align-items: center;
	justify-content: center;
}

.popup-inner {
		background: #FFF;
		border-top: 1px solid #000;
		border-left: 1px solid #000;
		border-right: 1px solid #000;
		border-radius: 5px 5px 0px 0px;
}

.formFields{
	display: flex;
	flex-direction: column;
	justify-content: space-between;
	align-items: center;
}

.header{
	display: flex;
	flex-direction: row;
	justify-content: space-between;
	align-items: center;
	width: 250px;
	margin-left: 20px;
	margin-right: 20px;
}

h1{
	max-width: 170px;
}

.btnValidation{
	background-color: #629c44;
	color: white;
	border: 1px solid #232323;
	padding: 7px 30px 7px 30px;
	border-radius: 50px;
	position: relative;
	bottom: 20px;
	right: 30px;
	font-size: 14px;
	font-family: helvetica;
	font-weight: bold;
}

.btnValidation:hover{
	cursor: pointer;
	background-color: #4d7f35;
}

.btnClose{
	border: none;
	color: white;
	background-color: transparent;
	text-decoration: underline;
	position: relative;
	bottom: 35px;
	right: 60px;
	font-size: 14px;
	font-family: helvetica;
}

.btnClose:hover{
	cursor: pointer;
	color: blue;
}

.formPic{
	width:300px;
	height: 90px;
	object-fit: cover;
	position: relative;
	top: 15px;
}

.contener{
	display: flex;
	flex-direction: column;
	justify-content: center;
	align-items: center;
}

</style>