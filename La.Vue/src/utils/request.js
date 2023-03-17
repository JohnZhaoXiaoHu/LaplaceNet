import axios from 'axios'
import { ElMessageBox, ElMessage, ElLoading } from 'element-plus'
import { getToken, getLoginTime, removeToken } from '@/utils/auth'
import errorCode from '@/utils/errorCode'
import useUserStore from '@/store/modules/user'
import { blobValidate } from '@/utils/ruoyi'
import { saveAs } from 'file-saver'

let downloadLoadingInstance
// 是否显示重新登录
export let isRelogin = { show: false };

// 解决后端跨域获取不到cookie问题
// axios.defaults.withCredentials = true
//axios.defaults.headers['Content-Type'] = 'application/json;charset=utf-8'
axios.defaults.headers['Content-Type'] = 'application/json;charset=utf-8'
// 创建axios实例
const service = axios.create({
  // axios中请求配置有baseURL选项，表示请求URL公共部分
  baseURL: import.meta.env.VITE_APP_BASE_API,
  // 超时
  timeout: 30000
})
/**
 * 定义一个检查token 是否过期的方法
 */
// 2 天  172800000 ms (1天86400000 ms)就是 时间戳 2 天 是 token 过期的时间期限
const tokenLoginTime = 1000 * 60 * 60 * 24;
function checkTimeOut() {
  // 当前时间 发送请求的时间 在请求拦截器调用这个函数 就是发送请求的当前时间
  const curTime = Date.now();
  // 登录时候的时间
  const loginTime = getLoginTime();
  //   当前的时间 - 登录时候的时间 如果大于 2 小时 即 7200000 说明 token 过期了
  if (curTime - loginTime > tokenLoginTime) {
    // 过期了
    return true;
  } else {
    return false; //没有过期
  }
}
// request拦截器
service.interceptors.request.use(
  (config) => {
    // 是否需要设置 token
    if (getToken()) {
      // 每次请求接口的时候查看 token 是否过期了
      if (checkTimeOut()) {
        // 进来说明过期了
        removeToken();
        useUserStore()
          .logOut()
          .then(() => {
            location.href = import.meta.env.VITE_APP_ROUTER_PREFIX + 'index'
          })
      }
      //将token放到请求头发送给服务器,将tokenkey放在请求头中
      config.headers['Authorization'] = 'Bearer ' + getToken()
      config.headers['userid'] = useUserStore().userId
    }

    return config
  },
  (error) => {
    console.log(error)
    Promise.reject(error)
  }
)

// 响应拦截器
service.interceptors.response.use(
  (res) => {

    if (res.status !== 200) {
      Promise.reject('network error')
      return
    }
    // 未设置状态码则默认成功状态
    const { code, msg } = res.data
    // 二进制数据则直接返回
    if (res.request.responseType === 'blob' || res.request.responseType === 'arraybuffer') {
      return res
    }
    if (code == 401 && res && res.data && res.data.code == 10009) {
      ElMessageBox.confirm('登录状态已过期，请重新登录', '系统提示', {
        confirmButtonText: '重新登陆',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        useUserStore()
          .logOut()
          .then(() => {
            location.href = import.meta.env.VITE_APP_ROUTER_PREFIX + 'index'
          })
      })

      return Promise.reject('无效的会话，或者会话已过期，请重新登录。')
    } else if (code == 0 || code == 1 || code == 110 || code == 101 || code == 403 || code == 500 || code == 429) {
      ElMessage({
        message: msg,
        type: 'error'
      })
      return Promise.reject(res.data)
    } else {
      //返回标准 code/msg/data字段
      return res.data
    }
  },
  (error) => {
    console.log('err' + error)
    let { message } = error
    if (message == 'Network Error') {
      message = '后端接口连接异常'
    } else if (message.includes('timeout')) {
      message = '系统接口请求超时'
    } else if (message.includes('Request failed with status code 429')) {
      message = '请求过于频繁，请稍后再试'
    } else if (message.includes('Request failed with status code')) {
      message = '系统接口' + message.substr(message.length - 3) + '异常'
    }
    ElMessage({
      message: message,
      type: 'error',
      duration: 3 * 1000,
      grouping: true
    })
    return Promise.reject(error)
  }
)

/**
 * get方法，对应get请求
 * @param {String} url [请求的url地址]
 * @param {Object} params [请求时携带的参数]
 */
export function get(url, params) {
  return new Promise((resolve, reject) => {
    axios
      .get(url, {
        params: params
      })
      .then((res) => {
        resolve(res.data)
      })
      .catch((err) => {
        reject(err)
      })
  })
}

export function post(url, params) {
  return new Promise((resolve, reject) => {
    axios
      .post(url, {
        params: params
      })
      .then((res) => {
        resolve(res.data)
      })
      .catch((err) => {
        reject(err)
      })
  })
}

/**
 * 提交表单
 * @param {*} url
 * @param {*} data
 */
export function postForm(url, data, config) {
  return new Promise((resolve, reject) => {
    axios
      .post(url, data, config)
      .then((res) => {
        resolve(res.data)
      })
      .catch((err) => {
        reject(err)
      })
  })
}

/**
 * 通用下载方法
 * @param {*} url 请求地址
 * @param {*} params 请求参数
 * @param {*} config 配置
 * @returns
 */
export async function downFile(url, params, config) {
  downloadLoadingInstance = ElLoading.service({ text: '正在下载数据，请稍候', background: 'rgba(0, 0, 0, 0.7)' })

  service
    .get(url, {
      params,
      headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      responseType: 'blob',
      ...config
    })
    .then(async (resp) => {
      const { data } = resp

      const isLogin = await blobValidate(data)
      if (isLogin) {
        var patt = new RegExp('filename=([^;]+\\.[^\\.;]+);*')
        var contentDisposition = decodeURI(resp.headers['content-disposition'])
        var result = patt.exec(contentDisposition)
        var fileName = result[1]
        fileName = fileName.replace(/\"/g, '')

        const blob = new Blob([data])
        saveAs(blob, fileName)
      } else {
        const resText = await data.text()
        const rspObj = JSON.parse(resText)
        const errMsg = errorCode[rspObj.code] || rspObj.msg || errorCode['default']

        ElMessage({
          message: errMsg,
          type: 'error'
        })
      }
      downloadLoadingInstance.close()
    })
    .catch((err) => {
      ElMessage({
        message: '下载文件出现错误，请联系管理员！',
        type: 'error'
      })
      downloadLoadingInstance.close()
    })
}

export default service
