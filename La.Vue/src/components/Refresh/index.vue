<template>
  <div>
    <svg-icon name="refresh" @click="refresh()" />
  </div>
</template>

<script setup>
  import { inject } from 'vue'
  const reload = inject('reload')

  // 下面这行代码写在你需要reload的地方
  function refresh() {
    reload();
  }

</script>

<style lang="scss" scoped>
  .refresh-svg {
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