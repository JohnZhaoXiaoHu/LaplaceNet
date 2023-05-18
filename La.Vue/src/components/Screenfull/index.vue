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
    font-size: 18px;
    line-height: 50px;
    padding-right: 7px;
    width: 48px;
    height: 48px;
    vertical-align: text-bottom;
  }

  .svg-icon {
    width: 1.2em;
    height: 1.2em;
    vertical-align: text-bottom;
    fill: RoyalBlue;
    overflow: hidden;
  }
</style>