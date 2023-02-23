export default {
  /**
   * 框架版本号
   */
  version: '1.0.1',
  /**
   * 网页标题
   */
  title: import.meta.env.VITE_APP_TITLE,
  /**
   * 侧边栏主题 深色主题theme-dark，浅色主题theme-light
   */
  sideTheme: 'theme-dark',
  /**
   * 框架主题颜色值
   */
  theme: '#FF8C00',
  /**
   * 是否系统布局配置
   */
  showSettings: false,

  /**
   * 是否显示顶部导航
   */
  topNav: false,

  /**
   * 是否显示 tagsView
   */
  tagsView: true,

  /**
   * 是否固定头部
   */
  fixedHeader: false,

  /**
   * 是否显示logo
   */
  sidebarLogo: true,

  /**
   * 是否显示动态标题
   */
  dynamicTitle: false,

  /**
   * @type {string | array} 'production' | ['production', 'development']
   * @description Need show err logs component.
   * The default is only used in the production env
   * If you want to also use it in dev, you can pass ['production', 'development']
   */
  errorLog: 'production',
  /**
   * 版权信息
   */
  copyright: 'Copyright ©2022-2023 <a  target="_blank"  style="color: #5c6b77"  href="https://beian.miit.gov.cn/"  >粤ICP备88889999</a> <a target="_black" href="https://laplacenet.github.io/">@Laplace.NET</a> All Rights Reserved.',
  /**
   * 是否显示底部栏
   */
  showFooter: true,
  /**
   * 是否显示水印
   */
  showWatermark: false,
  /**
   * 水印文案
   */
  watermarkText: 'Laplace.NET',
  /**
   * 是否显示其他登录
   */
  showOtherLogin: false,
  /**
   * 默认大小
   */
  defaultSize: 'default'
}
