**中文** | [English](./README.en.md)
<h2 align="center">🏬Laplace.NET通用管理系统🏬</h2>
<h4 align="center">👉.Net7+Vue3.x+Element plus前后端分离的快速发开框架👈</h4>  
<div align=center>
<img src="https://github.com/Lean365/LaplaceNet/blob/master/La.Vue/src/assets/logo/Laplace.png" width=128" height="128" />
<img src="https://github.com/Lean365/LaplaceNet/blob/master/La.Vue/src/assets/logo/Lean365.png" width=128" height="128" />
<img src="https://github.com/Lean365/LaplaceNet/blob/master/La.Vue/src/assets/logo/Antares.png" width=128" height="128" />
</div>

<p align="center">
	<a href="https://github.com/Lean365/LaplaceNET"><img src="https://img.shields.io/github/stars/Lean365/LaplaceNet?style=flat-square&logo=github&color=red"></a>
	<a href="https://github.com/Lean365/LaplaceNet/blob/master/LICENSE"><img src="https://img.shields.io/github/license/Lean365/LaplaceNet?style=flat-square&logo=github&color=0000FF"></a>
  <a href="https://github.com/Lean365/LaplaceNet/watchers"><img src="https://img.shields.io/github/watchers/Lean365/LaplaceNet?style=flat-square&logo=github&color=616ae5"></a>
  <a href="https://github.com/Lean365/LaplaceNet/network/members"><img src="https://img.shields.io/github/forks/Lean365/Lean365.github.io.svg?style=flat-square&logo=github&color=00C78C"></a>
  
</p>

## 🎉概述

- 基于.NET7实现的通用管理平台（RBAC模式）。整合[ZR.Admin](https://gitee.com/izory)框架技术高效快速开发，前后端分离模式，开箱即用。
- 代码量少、学习简单、通俗易懂、功能强大、易扩展、轻量级，让web开发更快速、简单高效，解决70%的重复工作，专注您的业务，轻松开发从现在开始！


## 💚 适合人群

- 正在以及想使用 element-ui/element-plus 开发，前端开发经验 1 年+。
- 熟悉 Vue.js 技术栈，使用它开发过几个实际项目。
- 对原理技术感兴趣，想进阶和提升的同学。
- 零基础，请移步到izory：[ZR.Admin](https://gitee.com/izory)。



## 🌐在线体验
- 😭计划中...



```
由于是个人项目，资金有限！！！
```
## 🐰代码仓库
| 仓库 | Gitee | Github                                                         |
| ---- | ----- | -------------------------------------------------------------- |
| Vue3 |       | [Net7中已包含克隆/下载](https://github.com/Lean365/LaplaceNet) |
| Net7 |       | [克隆/下载](https://github.com/Lean365/LaplaceNet)             |

## 🐰前端
Vue版前端技术栈 ：基于vue3.x、vuex、vue-router 、vue-cli 、axios、 element-plus、echats、i18n国际化等，前端采用vscode工具开发

## 📌后端
- 核心框架：.Net7.0 + Web API + sqlsugar + swagger + signalR + IpRateLimit + Quartz.net + Redis
- 定时计划任务：Quartz.Net组件，支持执行程序集或者http网络请求
- 安全支持：过滤器(数据权限过滤)、Sql注入、请求伪造
- 日志管理：NLog、登录日志、操作日志、定时任务日志
- 工具类：验证码、丰富公共功能
- 接口限流：支持接口限流，避免恶意请求导致服务层压力过大
- 代码生成：高效率开发，代码生成器可以一键生成所有前后端代码
- 数据字典：支持数据字典，可以方便对一些状态进行管理
- 分库分表：使用orm sqlsugar可以很轻松的实现分库分库性能优越
- 多 租 户：支持多租户功能
- 缓存数据：内置内存缓存和Redis


## 📌内置功能

1. 用户管理：用户是系统操作者，该功能主要完成系统用户配置。
2. 部门管理：配置系统组织机构（公司、部门、小组），树结构展现。
3. 岗位管理：配置系统用户所属担任职务。
4. 菜单管理：配置系统菜单，操作权限，按钮权限标识等。
5. 角色管理：角色菜单权限分配。
6. 字典管理：对系统中经常使用的一些较为固定的数据进行维护。
7. 操作日志：系统正常操作日志记录和查询；系统异常信息日志记录和查询。
8. 登录日志：系统登录日志记录查询包含登录异常。
9. 系统接口：使用 swagger 生成相关 api 接口文档。
10. 服务监控：监视当前系统 CPU、内存、磁盘、堆栈等相关信息。
11. 在线构建器：拖动表单元素生成相应的 VUE 代码(仅支持vue2)。
12. 任务系统：基于 Quartz.NET，可以在线（添加、修改、删除、手动执行)任务调度包含执行结果日志。
13. 文章管理：可以写文章记录。
14. 代码生成：可以一键生成前后端代码(.cs、.vue、.js、.sql等)支持下载，自定义配置前端展示控件、让开发更快捷高效（史上最强）。
15. 参数管理：对系统动态配置常用参数。
16. 发送邮件：可以对多个用户进行发送邮件。
17. 文件管理：可以进行上传文件管理，目前支持上传到本地、阿里云。
18. 通知管理：系统通知公告信息发布维护，使用 signalr 实现对用户实时通知。
19. 账号注册：可以注册账号登录系统。
20. 多语言管理：支持静态、后端动态配置国际化。目前只支持中、英、日文(仅支持vue3)

## ✨精益生产管理
1. 预算管理
- 人员
- 设备
- 加班
7. 费用管理
- 实际预算对比
8. 成本管理
- 销售
- BOM
- 人工
- 生产
9.  销售管理
- 客诉
- 序列号
10. 物料管理
- MRP
- FC
11. 生产管理
- **设变**
- **OPH(每小时产量)**
- 不良
- 工数
12. 品质管理
- 成本
- 来料
- 成品

## 🔴 OA
- 计划中...

## 🔴 ChatGPT
- 计划中...


## 🔰项目结构

```
├─La.Infra                          ->[基础层类库]：数据类型，I/O以及其他类库；
├─La.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper；
├─La.Service                        ->[服务层类库]：提供WebApi接口调用；
├─La.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作；
├─La.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象；
├─La.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务。
├─La.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能；
├─La.CodeGenerator                  ->[代码生成功能]：包含模板、方法、代码、下载。
├─La.Vue                            ->[前端UI]：vue3.0版本UI层。
```

## 📌演示图

<table>
    <tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/1.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/2.png"/></td>
    </tr>
    <tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/3.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/4.png"/></td>
    </tr>
    <tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/5.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/6.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/7.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/8.png"/></td>
    </tr>	
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/9.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/10.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/11.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/12.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/13.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/14.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/15.png"/></td>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/16.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/17.png"/></td>
		<td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/18.png"/></td>
    </tr>
	<tr>
		<td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/19.png"/></td>
		<td><img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/20.png"/></td>
	</tr>
</table>

## 🎉优势

1. 前台系统不用编写登录、授权、认证模块；只负责编写业务模块即可
2. 后台系统无需任何二次开发，直接发布即可使用
3. 前台与后台系统分离，分别为不同的系统（域名可独立）
4. 全局异常统一处理
5. 自定义的代码生成功能

## 💐 特别鸣谢
- 👉Ruoyi.vue：[Ruoyi](http://www.ruoyi.vip/)
- 👉SqlSugar：[SqlSugar](https://www.donet5.com/Home/Doc)
- 👉element-plus：[element-plus](https://github.com/element-plus/element-plus)
- 👉kailong321200875:[vue-element-plus-admin](https://github.com/kailong321200875/vue-element-plus-admin)
- 👉GMingChen:[vue-element-plus-admin](https://github.com/GMingChen/vue3-element-plus-admin)
- 👉Meiam.System：[Meiam.System](https://github.com/91270/Meiam.System)
- 👉izory：[ZR.Admin](https://gitee.com/izory)
- 👉cq-panda：[Vue.NetCore](https://github.com/cq-panda/Vue.NetCore)
- 👉zuohuaijun：[Admin.NET](https://toscode.gitee.com/zuohuaijun/Admin.NET)

## 🎀捐赠
如果你觉得这个项目帮助到了你，你可以帮作者买一杯果汁表示鼓励 🍹 
<img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/pay.jpg"/>


## 💡Browsers support

Modern browsers and Internet Explorer 10+.

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>IE / Edge | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Safari |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IE10, IE11, Edge                                                                                                                                                                                                 | last 2 versions                                                                                                                                                                                                    | last 2 versions                                                                                                                                                                                                | last 2 versions                                                                                                                                                                                                |

## 🔧使用说明
如果部署iis访问不了情况可以有以下两种办法：
1. 后端打包：在VS2022菜单<生成>\<发布>
2. 直接打开La.WebApi.exe文件然后看控制台的错误日志
3. web.config里面有个false 改为 true，iis重启项目后运行网站后，跟目录下面 有个文件夹 log 里面有错误日志文件
4. 有环境的请使用Laplace_deb.sql,sql2019版本直接导入，没有环境的可以使用SQLite版本，laplace.net.db，并在<font color=#ff0000>appsettings.json</font>配置
5. 前端打包：npm run build:prod
 ```
✓ built in 2m 20s
```
### 🔧溢出解决方案
 ```
FATAL ERROR: Reached heap limit Allocation failed - JavaScript heap out of memory
```
   1. 删除命令
   ```
   rimraf node_modules
   ```
   2. 重新构建
   ```
   npm i
   ```
   3. 增加内存机制
   ```
   npm install -g increase-memory-limit
   ```
   4. 执行
   ```
    increase-memory-limit
   ```
   5. 修改node_modules\.bin\webpack.cmd文件，全局搜索 “%_prog%” 替换为 %_prog%即可
   6. 修改package.js
   ```
     "scripts": {
    "dev": "vite",
    "build:prod": "vite build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
   ```
   改成
   ```
     "scripts": {
    "dev": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js",
    "build:prod": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
   ```
   7. 重新打包
   ```
   npm run build:prod
   ```
6. IIS部署前端
   下载URL重写模块[urlrewrite](https://www.iis.net/downloads/microsoft/url-rewrite)
   下载代理模块[Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing)
   配置示例
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis1.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis2.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis3.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis4.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis5.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis6.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis7.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis8.png"/>
   <img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/iis9.png"/>

## 🚩License
[MIT](https://github.com/Lean365/LaplaceNet/blob/master/LICENSE)

