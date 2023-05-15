<template>
  <Particles id="tsparticles" :particlesInit="particlesInit" :particlesLoaded="particlesLoaded"
    :options="particlesConfig"></Particles>

</template>

<script setup name="animationBackground-bkg">
  //背景动画
  import { loadFull } from "tsparticles"
  //import particlesConfig from "@/views/components/particles-bkg.json"
  import particlesConfig from "@/views/components/particles-nasa.json"
  //import particlesConfig from "@/views/components/particles-star.json"

  const particlesInit = async engine => {
    await loadFull(engine);
  }

  const particlesLoaded = async container => {
    console.log("Particles container loaded", container);
  }
</script>

<style scoped lang="scss">

</style>