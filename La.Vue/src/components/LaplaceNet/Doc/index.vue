<template>
  <div>
    <svg-icon name="question-solid" @click="goto" />
  </div>
</template>
<script setup>
  const url = ref('https://laplacenet.github.io/');

  function goto() {
    window.open(url.value)
  }
</script>
<style scoped>
  .svg-icon {
    width: 1.2em;
    height: 1.2em;
    vertical-align: -0.15em;
    fill: #6495ED;
    overflow: hidden;
  }
</style>