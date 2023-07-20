**English** | [中文](./README.md)
<h2 align="center">🏬Laplace.NET General management platform🏬</h2>
<h4 align="center">👉.Net7+Vue3.x+Element plus Fast development framework with front and rear separation👈</h4>  
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

## 🎉Overview

- A universal management platform based on. NET7 implementation (RBAC mode). Integration [ZR. Admin]（ https://gitee.com/izory ）Efficient and rapid development of framework technology, front and rear end separation mode, ready to use out of the box.
- Low code, easy to learn, easy to understand, powerful, easy to expand, and lightweight, making web development faster, simpler, and more efficient, solving 70% of repetitive work, focusing on your business, and easy to develop from now on！


## 💚 Crowd

- I am developing and want to use element ui/element plus, with 1 year of front-end development experience.
- Familiar with Vue.js technology stack and have developed several practical projects using it。
- People who are interested in principle technology and want to advance and improve。
- Zero foundation, please move to izory：[ZR.Admin](https://gitee.com/izory)。



## 🌐Online
- Official documents：https://laplacenet.github.io/
- 😭(Not open) Experience with version 3. x of Vue：http://www.ilaplace.cn/vue
- Test account：admin/123456


```
Due to being a personal project, funds are limited!!!
```
## 🐰Repositories
| Repositories | Gitee | Github                                                                           |
| ------------ | ----- | -------------------------------------------------------------------------------- |
| Vue3         |       | [Clone/Download already included in Net7](https://github.com/Lean365/LaplaceNet) |
| Net7         |       | [Clone/Download](https://github.com/Lean365/LaplaceNet)                          |

## 🐰Front-end
    vue3.x、vite、vuex、vue-router 、vue-cli 、axios、 element-plus、echats、i18n etc,using vscode tools.

## 🐰Back-end 
- Core Framework：.Net7.0 + Web API + sqlsugar + swagger + signalR + IpRateLimit + Quartz.net + Redis
- Scheduled tasks：Quartz.Net component that supports execution of assemblies or http network requests
- Security support: Filters (data permission filtering), Sql injection, request forgery
- Log management: NLog, login log, operation log, timed task log
- Tools: verification code, rich public functions
- Interface flow restriction: support interface flow restriction to avoid excessive pressure on the service layer caused by malicious requests
- Code generation: High efficiency development, code generator can generate all front and back-end code with one click
- Data dictionary: support data dictionary, which can facilitate the management of some states
- Sub-base and sub-table: using orm sqlsugar can easily realize sub-base and sub-table with superior performance
- Multi-tenant: support multi-tenant function
- Cached data: built-in memory cache and Redis


## 📌Functions

1. User Management: User is the system operator, this function mainly completes the system user configuration.
2. Department Management: Configure the system organization (company, department, group) and show the tree structure.
3. Position management: configure the system users belong to hold positions.
4. menu management: configure the system menu, operation privileges, button privilege identification, etc.
5. Role management: role menu permission assignment. 6.
6. Dictionary management: maintenance of some of the more fixed data often used in the system. 7.
7. operation log: system normal operation log record and query; system abnormal information log record and query.
8. login log: system login log records and queries include login exceptions.
9. system interface: use swagger to generate relevant api interface documents. 10.
10. service monitoring: monitor the current system CPU, memory, disk, stack and other related information.
11. online builder: drag and drop form elements to generate the corresponding VUE code (only vue2 is supported). 12.
12. task system: based on Quartz.NET, you can online (add, modify, delete, manually execute) task scheduling including execution results log.
13. article management: you can write article records.
14. code generation: you can generate front and back-end code (.cs, .vue, .js, .sql, etc.) with one click to support the download, custom configuration of front-end display controls, so that the development is faster and more efficient (the most powerful ever).
15. parameter management: dynamic configuration of the system common parameters. 16.
16. send mail: you can send mail to multiple users.
17. file management: you can upload file management, currently supports uploading to local and Ali cloud.
18. notification management: system notification announcement information release maintenance, using signalr to achieve real-time notification to users.
19. account registration: you can register an account to log into the system. 20.
20. multi-language management: support for static, back-end dynamic configuration internationalization. Currently only supports Chinese, English and Japanese (only supports vue3)

## 🎉 LeanManufacturing Management
1. Budget management
- Personnel
- Equipment
- Overtime
7. Expense management
- Actual budget comparison
8. Cost Management
- sales
- BOM
- labor
- production
9. Sales Management
- Customer Complaints
- Serial number
10. Material Management
- MRP
- FC
11. Production Management 
- **<font color="#000066">EC</font>**
- **<font color="#000066">OPH(Output per hour)</font>**
- Defects
- Manhour
12. Quality Control
- Cost
- Incoming material
- finished product

## 🎉 OA
- (pending...)

## 🎉ChatGPT
- (pending...)


## 🔰Project Structure

```
├─La.Infra                          -> [base layer class library]: data types, I/O and other class libraries;
├─La.Common                         -> [public layer class library]: Helper including data, regular, strings, etc;
├─La.Service                        -> [service layer class library]: provides WebApi interface calls;
├─La.Repository                     -> [Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─La.Model                          -> [entity layer class library]: provides database tables, data transfer objects in the project;
├─La.WebApi                         -> [webapi interface]: provides interface services for Vue version or other three-party systems.
├─La.Tasks                          -> [timed task library]: provides project timed task implementation functions;
├─La.CodeGenerator                  -> [code generation function]: contains templates, methods, code, downloads.
├─La.Vue                            -> [front-end UI]: vue3.0 version UI layer.
```

## 📌Demo Images

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

## 🎉Advantages

1. The front-end system does not need to write login, authorization and authentication modules; it is only responsible for writing business modules
2. the backend system does not need any secondary development, direct release can be used
3. front and back-end systems are separated, respectively, for different systems (domain names can be independent)
4. unified global exception handling
5. custom code generation function

## 💐 Special Acknowledgements
- 👉Ruoyi.vue：[Ruoyi](http://www.ruoyi.vip/)
- 👉SqlSugar：[SqlSugar](https://www.donet5.com/Home/Doc)
- 👉element-plus：[element-plus](https://github.com/element-plus/element-plus)
- 👉kailong321200875:[vue-element-plus-admin](https://github.com/kailong321200875/vue-element-plus-admin)
- 👉GMingChen:[vue-element-plus-admin](https://github.com/GMingChen/vue3-element-plus-admin)
- 👉Meiam.System：[Meiam.System](https://github.com/91270/Meiam.System)
- 👉izory：[ZR.Admin](https://gitee.com/izory)
- 👉cq-panda：[Vue.NetCore](https://github.com/cq-panda/Vue.NetCore)
- 👉zuohuaijun：[Admin.NET](https://toscode.gitee.com/zuohuaijun/Admin.NET)

## 🎀Donate
If you think this project has helped you, you can help the author buy a glass of juice to show your encouragement 🍹 
<img src="https://github.com/Lean365/LaplaceNET/raw/master/La.Docs/images/pay.jpg"/>


## 💡Browsers support

Modern browsers and Internet Explorer 10+.

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>IE / Edge | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Safari |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IE10, IE11, Edge                                                                                                                                                                                                 | last 2 versions                                                                                                                                                                                                    | last 2 versions                                                                                                                                                                                                | last 2 versions                                                                                                                                                                                                |

## 🔧 Instructions for use
If the deployment of iis cannot access the situation, there are two methods:
1. Backend packaging: In the VS2022 menu<Generate><Publish>
2. Open the La.WebApi.exe file directly and check the error log on the console
3. Change false to true in webconfig. After restarting the project and running the website, there is an error log file in the folder log under the directory
4. If there is an environment, please use Laplace_ Deb.sql, sql2019 version can be directly imported. If there is no environment, SQLite version, place.net.db can be used, and configured in<font color=# ff0000>appsettings. json</font>
5. Front end packaging: npm run build: prod
```
✓ build in 2m 20s
```
### 🔧 Overflow Solution
```
FATAL ERROR: Reached heap limit Allocation failed - JavaScript heap out of memory
```
1. Delete Command
```
   rimraf node_modules
```
2. Reinstall
```
   npm i
```

3. Increase memory mechanism
```
   npm install -g increase-memory-limit
```
4. Execution
```
    increase-memory-limit
```
5. Modify node_modules\.bin\webpack.cmd, "%_prog%" replace % _prog% 
6. Modify package.js
```
     "scripts": {
    "dev": "vite",
    "build:prod": "vite build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },

```
Change to
```
     "scripts": {
    "dev": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js",
    "build:prod": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
```
7. Rebuild
```
   npm run build:prod

```
6. IIS Deployment Vue
   Download[urlrewrite](https://www.iis.net/downloads/microsoft/url-rewrite)
   Download[Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing)
   Configuration Example
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

