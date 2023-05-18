<template>
  <div>
    <el-dropdown placement="bottom" trigger="hover" @command="handleSetSize" style="vertical-align: middle">
      <span class="el-dropdown-link">
        <svg-icon class-name="size-icon" name="size" />
      </span>
      <template #dropdown>
        <el-dropdown-menu>
          <el-dropdown-item v-for="item of sizeOptions" :key="item.value" :disabled="size === item.value"
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
  const size = computed(() => appStore.size)
  const route = useRoute()
  const router = useRouter()
  const { proxy } = getCurrentInstance()
  const sizeOptions = ref([
    { label: proxy.$t('layout.large'), value: 'large' },
    { label: proxy.$t('layout.default'), value: 'default' },
    { label: proxy.$t('layout.small'), value: 'small' },
  ])

  // function refreshView() {
  //   // In order to make the cached page re-rendered
  //   store.dispatch('tagsView/delAllCachedViews', route)

  //   const { fullPath } = route

  //   nextTick(() => {
  //     router.replace({
  //       path: '/redirect' + fullPath,
  //     })
  //   })
  // }
  function handleSetSize(size) {
    proxy.$modal.loading('正在设置布局大小，请稍候...')
    appStore.setSize(size)
    setTimeout('window.location.reload()', 1000)
  }
</script>

<style lang="scss" scoped>
  .size-icon--style {
    font-size: 18px;
    line-height: 50px;
    padding-right: 7px;
    width: 48px;
    height: 48px;
    vertical-align: 10px;
  }

  /* //svg-icon修改颜色 */
  .svg-icon {
    width: 1.2em;
    height: 1.2em;
    vertical-align: -0.15em;
    fill: RoyalBlue;
    overflow: hidden;
    /* 宝蓝(#4b5cc4)：鲜艳明亮的蓝色 （注：英文中为 RoyalBlue 即皇家蓝色，是皇室选用的色彩，多和小面积纯黄色（金色）配合使用。） rgba(74, 74, 77, 0.65); */
  }

  .el-dropdown+.el-dropdown {
    margin-left: 15px;
  }

  .el-dropdown-link {
    cursor: pointer;
    color: var(--el-color-primary);
    display: flex;
    align-items: center;
  }
</style>