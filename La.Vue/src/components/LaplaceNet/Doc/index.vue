<template>
  <div>
    <svg-icon name="documentation" @click="goto" />
  </div>
</template>
<script setup>
  const url = ref('https://laplacenet.github.io/');

  function goto() {
    window.open(url.value)
  }
</script>