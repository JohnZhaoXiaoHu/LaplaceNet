<template>
  <div>
    <el-dropdown trigger="hover" @command="handleLanguageChange" style="vertical-align: middle">
      <svg-icon class-name="size-icon" name="language" :color="props.color" />
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
  const props = defineProps({
    color: {
      type: String
    }
  })
  const { proxy } = getCurrentInstance()
  const langOptions = ref([
    { label: '简体中文', value: 'zh-cn' },
    { label: '繁體中文', value: 'zh-tw' },
    { label: 'English', value: 'en' },
    { label: '日本語', value: 'ja' },
  ])

  function handleLanguageChange(lang) {
    proxy.$modal.loading('正在设置语言，请稍候...')
    appStore.setLang(lang)
    setTimeout('window.location.reload()', 1000)
  }
</script>

<style lang="scss" scoped>
  .size-icon--style {
    width: 20px;
    height: 20px;
    vertical-align: 10px;
    font-size: 18px;
    line-height: 50px;
    padding-right: 7px;

  }
</style>