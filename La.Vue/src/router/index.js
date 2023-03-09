/**
 * @Descripttion: (面包屑/页面路径)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-01-15)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-01-15)
**/
import { createWebHistory, createRouter } from 'vue-router'
import Layout from '@/layout'

/**
 * Note: 路由配置项
 *
 * hidden: true                     // 当设置 true 的时候该路由不会再侧边栏出现 如401，login等页面，或者如一些编辑页面/edit/1
 * alwaysShow: true                 // 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
 *                                  // 只有一个时，会将那个子路由当做根路由显示在侧边栏--如引导页面
 *                                  // 若你想不管路由下面的 children 声明的个数都显示你的根路由
 *                                  // 你可以设置 alwaysShow: true，这样它就会忽略之前定义的规则，一直显示根路由
 * redirect: noRedirect             // 当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
 * name:'router-name'               // 设定路由的名字，一定要填写不然使用<keep-alive>时会出现各种问题
 * query: '{"id": 1, "name": "ry"}' // 访问路由的默认传递参数
 * meta : {
    noCache: true                   // 如果设置为true，则不会被 <keep-alive> 缓存(默认 false)
    title: 'title'                  // 设置该路由在侧边栏和面包屑中展示的名字
    titleKey: '',                   //国际和翻译key值，如果不为空将使用i18n
    icon: 'svg-name'                // 设置该路由的图标，对应路径src/assets/icons/svg
    breadcrumb: false,              // 如果设置为false，则不会在breadcrumb面包屑中显示,
    affix: true                     // 设置成true表示，tag-view不可删除
    activeMenu: '/system/user'      // 当路由设置了该属性，则会高亮相对应的侧边栏。
  }
 */

// 公共路由
export const constantRoutes = [
  {
    path: '/redirect',
    component: Layout,
    meta: { hidden: true },
    hidden: true,
    children: [
      {
        path: '/redirect/:path(.*)',
        component: (resolve) => import('@/views/redirect/index.vue', resolve)
      }]
  },
  {
    path: '/login',
    component: (resolve) => import(/* webpackChunkName: "login" */ '@/views/login', resolve),
    hidden: true,
    meta: { hidden: true }
  },
  {
    path: '/sociallogin',
    component: (resolve) => import('@/views/socialLogin', resolve),
    hidden: true,
    meta: { hidden: true }
  },
  {
    path: '/register',
    component: (resolve) => import('@/views/register', resolve),
    hidden: true,
    meta: { hidden: true }
  },
  {
    path: "/:pathMatch(.*)*",
    component: (resolve) => import('@/views/error/404', resolve),
    hidden: true,
    meta: { hidden: true }
  },
  {
    path: '/401',
    component: (resolve) => import('@/views/error/401', resolve),
    hidden: true,
    meta: { hidden: true }
  },
  {
    path: '',
    component: Layout,
    redirect: '/index',
    meta: { hidden: true },
    children: [
      {
        path: '/index',
        component: (resolve) => import('@/views/index', resolve),
        name: 'Index',
        meta: { title: '首页', icon: 'house-solid', affix: true, titleKey: 'menu.home' }
      }]
  },
  {
    path: '/user',
    component: Layout,
    meta: { hidden: true },
    hidden: true,
    redirect: 'noredirect',
    children: [
      {
        path: 'profile',
        component: (resolve) => import('@/views/system/user/profile/index', resolve),
        name: 'Profile',
        meta: { title: '个人中心', icon: 'user', titleKey: 'menu.personalCenter' }
      }]
  },
  // 不用可删掉
  {
    path: '',
    component: Layout,
    hidden: false,
    meta: { hidden: true },
    meta: { title: '组件示例', icon: 'icon', noCache: 'fasle', titleKey: 'menu.component' },
    children: [
      {
        path: 'icon',
        component: (resolve) => import('@/views/components/icons/index', resolve),
        name: 'icon',
        meta: { title: '图标icon', icon: 'font-awesome', noCache: 'fasle', titleKey: 'menu.icon' }
      }]
  },
];

// 防止连续点击多次路由报错
// let routerPush = Router.prototype.push;
// Router.prototype.push = function push(location) {
//   return routerPush.call(this, location).catch(err => err)
// }

const router = createRouter({
  history: createWebHistory(
    import.meta.env.VITE_APP_ROUTER_PREFIX),
  routes: constantRoutes,
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  },
});

export default router;