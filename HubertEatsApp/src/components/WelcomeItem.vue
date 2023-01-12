<template>
  <div class="item">
    <i>
      <slot name="icon"></slot>
    </i>
    <div class="details">
      <h3>
        <slot name="heading"></slot>
      </h3>
      <slot></slot>
    </div>
  </div>
</template>

<style scoped>
.item {
  display: flex;
  flex-direction: row;
  gap: 20px;
  margin-bottom: 20px;
  background-color: red;
  width: 300px;
  height: 3000px;
  overflow: scroll;
}
</style>
