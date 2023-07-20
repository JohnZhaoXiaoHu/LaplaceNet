import { createI18n } from 'vue-i18n'
// import useAppStore from '@/store/modules/app'
import { listLangByLocale } from '@/api/system/commonlang.js'
import defaultSettings from '@/settings'
import cache from '@/plugins/cache'
const language = computed(() => {
  // return useAppStore().lang
  //return jsCookie.get('lang') || 'zh-cn'
  return cache.local.get('lang') || defaultSettings.defaultLang
})
// 导入语言资源
import zh from './lang/zh-cn.json'//简中
import tw from './lang/zh-tw.json'//繁中
import en from './lang/en.json'//英语
import ja from './lang/ja.json'//日本语

// 登入页面
import pageLoginZh from './pages/login/zh-cn.json'//简中
import pageLoginTw from './pages/login/zh-tw.json'//繁中
import pageLoginEn from './pages/login/en.json'//English
import pageLoginJa from './pages/login/ja.json'//日本語


// 菜单页面
import pagemenuZh from './pages/menu/zh-cn'//简中
import pagemenuTw from './pages/menu/zh-tw'//繁中
import pagemenuEn from './pages/menu/en'//English
import pagemenuJa from './pages/menu/ja'//日本語

// 部门页面
import pagedeptZh from './pages/dept/zh-cn'//简中
import pagedeptTw from './pages/dept/zh-tw'//繁中
import pagedeptEn from './pages/dept/en'//English
import pagedeptJa from './pages/dept/ja'//日本語


// 文件上传页面
import pageuploadZh from './pages/upload/zh-cn'//简中
import pageuploadTw from './pages/upload/zh-tw'//繁中
import pageuploadEn from './pages/upload/en'//English
import pageuploadJa from './pages/upload/ja'//日本語

// 用户页面
import pageuserZh from './pages/user/zh-cn'//简中
import pageuserTw from './pages/user/zh-tw'//繁中
import pageuserEn from './pages/user/en'//English
import pageuserJa from './pages/user/ja'//日本語


const i18n = createI18n({
  // 全局注入 $t 函数
  globalInjection: true,
  fallbackLocale: 'zh-cn',
  locale: language.value, //默认选择的语言
  legacy: false, // 使用 Composition API 模式，则需要将其设置为false
  messages: {
    'zh-cn': {
      ...zh,
      ...pageLoginZh,
      ...pagemenuZh,
      ...pagedeptZh,
      ...pageuploadZh,
      ...pageuserZh
    },
    'zh-tw': {
      ...tw,
      ...pageLoginTw,
      ...pagemenuTw,
      ...pagedeptTw,
      ...pageuploadTw,
      ...pageuserTw
    },
    en: {
      ...en,
      ...pageLoginEn,
      ...pagemenuEn,
      ...pagedeptEn,
      ...pageuploadEn,
      ...pageuserEn
    },
    ja: {
      ...ja,
      ...pageLoginJa,
      ...pagemenuJa,
      ...pagedeptJa,
      ...pageuploadJa,
      ...pageuserJa
    },

    //... 在这里添加其他语言支持
  }
})

const loadLocale = () => {
  listLangByLocale(language.value).then((res) => {
    const { code, data } = res
    if (code == 200) {
      i18n.global.mergeLocaleMessage(language.value, data)
    }
  })
}
loadLocale()
export default i18n;