<template>
  <div>
    <el-dropdown trigger="hover" @command="handleLanguageChange" style="vertical-align: middle">
      <svg-icon class-name="size-icon" name="language-outline" />
      <template #dropdown>
        <el-dropdown-menu>
          <el-dropdown-item v-for="item of langOptions" :key="item.value" :disabled="lang === item.value"
            :command="item.value">
            {{ item.label }}
          </el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>
  </div>
</template>

<script setup>
  import useAppStore from '@/store/modules/app'
  const appStore = useAppStore()
  const lang = computed(() => useAppStore().lang)

  const { proxy } = getCurrentInstance()
  const langOptions = ref([
    { label: '简体中文', value: 'zh-cn' },
    { label: 'English', value: 'en' },
    { label: '日本語', value: 'ja' },
  ])

  function handleLanguageChange(lang) {
    proxy.$modal.loading(proxy.$t('layout.switchingLanguage'))
    appStore.setLang(lang)
    setTimeout('window.location.reload()', 1000)
  }
</script>

<style lang="scss" scoped>
  .size-icon--style {
    font-size: 18px;
    line-height: 50px;
    padding-right: 7px;
  }

  /* //svg-icon修改颜色 */
  .svg-icon {
    height: 20px;
    width: 20px;
    fill: #007cdc;
    /* 宝蓝(#4b5cc4)：鲜艳明亮的蓝色 （注：英文中为 RoyalBlue 即皇家蓝色，是皇室选用的色彩，多和小面积纯黄色（金色）配合使用。） rgba(74, 74, 77, 0.65); */
  }
</style>