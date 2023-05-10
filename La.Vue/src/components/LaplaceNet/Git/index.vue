<template>
  <div>
    <svg-icon name="github" @click="goto" />
  </div>
</template>
<script>
  export default {
    setup() {
      const url = ref("https://github.com/Lean365/LaplaceNet");

      function goto() {
        window.open(url.value);
      }

      return {
        goto,
      };
    },
  };
</script>
<style scoped>
  .svg-icon {
    width: 1.2em;
    height: 1.2em;
    vertical-align: -0.15em;
    fill: #673AB7;
    overflow: hidden;
  }
</style>