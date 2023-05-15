<template>
  <div>
    <svg-icon name="circle-question" @click="goto" />
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
    fill: #19191a;
    overflow: hidden;
  }


  /* 
#F44336
#e91e63
#3f51b5
#009688
#5AB963
#92C27B0
#673AB7
#03A9F4
#00BCD4
#8bc34a
#CDDC39
#FFC107
#FF9800
#FF5722
*/
</style>