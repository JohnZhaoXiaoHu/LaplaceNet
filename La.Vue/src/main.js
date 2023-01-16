import { createApp } from 'vue'
/*引入资源请求插件*/
//import VueResource from 'vue-resource'
//Axios网络请求库封装
//import axios from 'axios'
//import VueAxios from 'vue-axios'
//cookie记录
//import Cookies from 'js-cookie'


import 'dayjs/locale/zh-cn'
import '@/assets/styles/index.scss' // global css

//引入element-plus库
import ElementPlus from 'element-plus'
//引入element-plus样式
//import 'element-plus/dist/index.css'
//引入VForm3库
//import VForm3 from 'vform3-builds'
//引入VForm3样式
//import 'vform3-builds/dist/designer.style.css'

//引入form-create V3库
import formCreate from '@form-create/element-ui'
import FcDesigner from '@form-create/designer'
import ElementUI from 'element-plus/es/index'
import 'element-plus/dist/index.css'
//引入jsPlumb流程图绘制
import App from './App'
import router from './router'
import directive from './directive' // directive
// 注册指令
import plugins from './plugins' // plugins
import { downFile } from '@/utils/request'
import signalR from '@/utils/signalR'
import vueI18n from './i18n/index'
import pinia from '@/store/index'
//引入UUID
import { v4 as uuidv4 } from 'uuid'
// svg图标
import 'virtual:svg-icons-register'

import SvgIcon from '@/components/SvgIcon/index.vue'
import elementIcons from '@/components/SvgIcon/svgicon'

import './permission' // permission control

import { getConfigKey } from '@/api/system/config'
import { getDicts } from '@/api/system/dict/data'
import { parseTime, resetForm, addDateRange, handleTree, selectDictLabel, download } from '@/utils/ruoyi'

// 分页组件
import Pagination from '@/components/Pagination'
// 自定义表格工具组件
import RightToolbar from '@/components/RightToolbar'
// 文件上传组件
import FileUpload from '@/components/FileUpload'
// 图片上传组件
import ImageUpload from '@/components/ImageUpload'
// 图片预览组件
import ImagePreview from '@/components/ImagePreview'
// 字典标签组件
import DictTag from '@/components/DictTag'
// el-date-picker 快捷选项
import dateOptions from '@/utils/dateOptions'
//格式化日期
import moment from "moment"

const app = createApp(App)

app.config.globalProperties.$filters = {
  timeFormat(value, formatString) {
    formatString = formatString || 'YYYY-MM-DD';
    return moment(value).format(formatString);
  }
}
signalR.init(import.meta.env.VITE_APP_SOCKET_API)
app.config.globalProperties.signalr = signalR
// 全局方法挂载
//app.config.globalProperties.$axios = axios
app.config.globalProperties.getConfigKey = getConfigKey
app.config.globalProperties.getDicts = getDicts
app.config.globalProperties.download = download
app.config.globalProperties.downFile = downFile
app.config.globalProperties.parseTime = parseTime
app.config.globalProperties.resetForm = resetForm
app.config.globalProperties.handleTree = handleTree
app.config.globalProperties.addDateRange = addDateRange
app.config.globalProperties.selectDictLabel = selectDictLabel
app.config.globalProperties.dateOptions = dateOptions
//app.prototype.uuid = uuidv4()
// 全局组件挂载
app.component('DictTag', DictTag)
app.component('Pagination', Pagination)
app.component('UploadFile', FileUpload)
app.component('UploadImage', ImageUpload)
app.component('ImagePreview', ImagePreview)
app.component('RightToolbar', RightToolbar)
app.component('svg-icon', SvgIcon)

directive(app)
/* 注意：如果你的项目中有使用axios，请用下面一行代码将全局axios复位为你的axios！！ */
//window.axios = axios
app.use(pinia)
  .use(router)
  .use(formCreate)
  .use(FcDesigner)
  .use(plugins)
  .use(ElementUI)
  .use(ElementPlus, {})
  .use(elementIcons)
  .use(vueI18n)
  .mount('#app')
