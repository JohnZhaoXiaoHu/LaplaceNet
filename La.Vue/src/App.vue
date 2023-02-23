<template>
  <!-- 添加点击事件 -->
  <el-config-provider :locale="locale" :size="size">
    <router-view />
  </el-config-provider>
</template>
<script setup>
  import useUserStore from './store/modules/user'
  import useAppStore from './store/modules/app'
  import { ElConfigProvider } from 'element-plus'
  import zh from 'element-plus/lib/locale/lang/zh-cn' // 中文语言
  import en from 'element-plus/lib/locale/lang/en' // 英文语言
  import ja from 'element-plus/lib/locale/lang/ja' //日本語
  // import zh from 'vxe-table/lib/locale/lang/zh-CN'
  // import en from 'vxe-table/lib/locale/lang/en-US'
  // import ja from 'vxe-table/lib/locale/lang/ja-JP'
  import defaultSettings from '@/settings'
  //import login from './modules/login'
  const { proxy } = getCurrentInstance()
  // 设置超时时间:30分钟
  const zIndex = 3000
  const token = computed(() => {
    return useUserStore().token
  })

  const lang = computed(() => {
    return useAppStore().lang
  })
  const locale = ref(zh)
  const size = ref(defaultSettings.defaultSize)

  size.value = useAppStore().size
  watch(
    token,
    (val) => {
      if (val) {
        proxy.signalr.start()
      }
    },
    {
      immediate: true,
      deep: true
    }
  )
  watch(
    lang,
    (val) => {
      if (val == 'zh-cn') {
        locale.value = zh
      } else if (val == 'en') {
        locale.value = en
      } else if (val == 'ja') {
        locale.value = ja
      } else {
        locale.value = zh
      }
    },
    {
      immediate: true
    }
  )
</script>