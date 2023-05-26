// 引入路由和storage工具函数
import useUserStore from '@/store/modules/user'
let lastTime = new Date().getTime()
let currentTime = new Date().getTime()
let timeOut = 30 * 60 * 1000  //设置超时时间: 120分钟
window.onload = function () {
  window.document.onmousedown = function () {
    localStorage.setItem("lastTime", new Date().getTime())
  }
};
function checkTimeout() {
  currentTime = new Date().getTime()		//更新当前时间
  lastTime = localStorage.getItem("lastTime");
  if (currentTime - lastTime > timeOut) { //判断是否超时
    // 清除storage的数据(登陆信息和token)
    localStorage.clear()
    // 跳到登陆页
    // if (router.currentRouter.name == 'login') {
    //   // 当前已经是登陆页时不做跳转
    //   return router.push({ name: 'login' })
    // }
    // else {
    // 跳转
    useUserStore()
      .logOut()
      .then(() => {
        location.href = import.meta.env.VITE_APP_ROUTER_PREFIX + 'index'
      })
    // }
  }
}
export default function () {
  /* 定时器 间隔30秒检测是否长时间未操作页面 */
  window.setInterval(checkTimeout, 29 * 60 * 1000);
}