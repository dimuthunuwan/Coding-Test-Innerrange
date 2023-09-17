<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="header">
    <div class="headerItem"> 
      <RouterLink to="/">Instruction</RouterLink> | 
      <RouterLink to="/validate">CSV Validator</RouterLink> 
    </div>
  </div>
  
  <div class="page">
    <RouterView />
  </div>
</template>

<style scoped>
.header {
  border: 1px solid lightgray;
  padding: 4px;
  margin: 4px;
  display: flex;
}
.headerItem {
  margin: 4px;
}

.page {
  border: 1px solid lightgray;
  
  padding: 4px;
  margin: 4px;
}
</style>
