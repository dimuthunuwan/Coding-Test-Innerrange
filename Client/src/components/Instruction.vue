<script setup>
  import VueMarkdown from 'vue-markdown-render'
  import {ref} from 'vue'

  const instruction = ref('loading..');

  function getInstruction(){
    fetch("/instruction/getInstruction")
    .then( response => response.text())
    .then(text => {
      instruction.value = text;
    })

    
  }
  getInstruction();
</script>

<template>
  <div>
    <vue-markdown :source="instruction"></vue-markdown>
  </div>
 
</template>
