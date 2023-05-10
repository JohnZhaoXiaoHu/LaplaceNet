<template>
  <div>
    <svg-icon :name="isFullscreen ? 'exit-fullscreen' : 'fullscreen'" @click="toggle" />
  </div>
</template>

<script setup>
  import { useFullscreen } from '@vueuse/core'

  const { isFullscreen, enter, exit, toggle } = useFullscreen()
</script>

<style lang="scss" scoped>
  .screenfull-svg {
    display: inline-block;
    cursor: pointer;
    width: 20px;
    height: 20px;
    vertical-align: 10px;
  }

  .svg-icon {
    width: 1em;
    height: 1em;
    vertical-align: -0.15em;
    fill: #23A393;
    overflow: hidden;
  }
</style>