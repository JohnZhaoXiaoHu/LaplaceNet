<template>

  <h2 style="color: red;">{{ $t('layout.ProjectInformation') }}</h2>
  <h5 style="color: rgb(42, 3, 184);">
    Laplace.NET是一款前后端分离的、跨平台基于RBAC的通用权限管理后台。ORM采用SqlSugar。前端采用Vue、支持多租户、缓存、任务调度、支持统一异常处理、接口限流、支持一键生成前后端代码，支持动态国际化翻译(Vue3)，等诸多黑科技，代码简洁易懂、易扩展让开发更简单、更通用。
  </h5>
  <div class="panel padding-15">
    <div class="panel-content">
      <div class="margin_t-10">
        <el-button size="small" type="warning" @click="releaseHandle()" round><svg-icon name="log" />更新日志</el-button>
        <el-button size="small" type="success" @click="releaseHandle()" round><svg-icon
            name="file-code" />项目文档</el-button>
        <el-button size="small" type="info" @click="releaseHandle()" round><svg-icon name="github"
            color="BlueViolet" />GitHub</el-button>
        <el-button size="small" type="info" @click="giteeHandle()" round><svg-icon name="gitee" color="Crimson" />Gitee
        </el-button>
      </div>
    </div>
  </div>
  <el-table :data="projectData" border stripe height="150" style="width: 100%" :cell-style="cellStyle">
    <el-table-column prop="name1"></el-table-column>
    <el-table-column prop="value1">
    </el-table-column>
    <el-table-column prop="name2"></el-table-column>
    <el-table-column prop="value2">
    </el-table-column>
  </el-table>


  <h2 style="float:center">{{ $t('layout.technicalSelection') }}</h2>
  <el-row class="mt10">
    <el-col :sm="24" :lg="12">
      <el-card>
        <div style="float: left; width: 100%">
          <h4>{{ $t('layout.backendTechnology') }}</h4>
          <el-table :data="backend" border stripe height="450" style="width: 100%">
            <el-table-column type="index" label="序号" style="width: 10%"></el-table-column>
            <el-table-column prop="Name" label="依赖名" style="width: 20%"></el-table-column>
            <el-table-column prop="Fun" label="功能" style="width: 20%"></el-table-column>
          </el-table>
        </div>
      </el-card>
    </el-col>
    <el-col :sm="24" :lg="12">
      <el-card>
        <div style="float: right; width: 100%">
          <h4>{{ $t('layout.frontendTechnology') }}</h4>
          <el-table :data="frontend" border stripe height="450" style="width: 100%">
            <el-table-column type="index" label="序号" style="width: 10%"></el-table-column>
            <el-table-column prop="Name" label="依赖名" style="width: 20%"></el-table-column>
            <el-table-column prop="Fun" label="功能" style="width: 20%"></el-table-column>
          </el-table>
        </div>
      </el-card>
    </el-col>
  </el-row>
  <div>
    <el-row class="mt10">
      <el-col :sm="24" :lg="12">
        <el-card>
          <h4>{{ $t('layout.devDependencies') }}</h4>
          <el-table :data="devData" border stripe height="602" style="width: 100%">
            <el-table-column type="index" label="序号" style="width: 10%"></el-table-column>
            <el-table-column prop="name" label="依赖名" style="width: 20%"></el-table-column>
            <el-table-column prop="version" label="版本" style="width: 20%"></el-table-column>
          </el-table>
        </el-card>
      </el-col>
      <el-col :sm="24" :lg="12">
        <el-card>
          <h4>{{ $t('layout.dependencies') }}</h4>
          <el-table :data="depData" border stripe height="602" style="width: 100%">
            <el-table-column type="index" label="序号" style="width: 10%"></el-table-column>
            <el-table-column prop="name" label="依赖名" style="width: 20%"></el-table-column>
            <el-table-column prop="version" label="版本" style="width: 20%"></el-table-column>
          </el-table>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>
<script setup>
  import config from '../../package.json'
  const versionstring = config.description + ':v' + config.version;
  const data = reactive({
    github: 'https://github.com/gmingchen/vue3-element-plus-admin',
    gitee: 'https://gitee.com/shychen/vue3-element-plus-admin',
    release: 'https://github.com/gmingchen/vue3-element-plus-admin/releases',


  })
  const githubHandle = () => {
    window.open(data.github)
  }
  const giteeHandle = () => {
    window.open(data.gitee)
  }
  const releaseHandle = () => {
    window.open(data.release)
  }
  const oscsHandle = () => {
    window.open(data.oscs)
  }
  const projectInfoVersion = config.version
  const projectInfoLastBulid = 'config.version'
  const projectInfoDoc = config.version
  const projectInfoPreview = config.version
  const projectInfoGithub = config.version
  const projectInfoGitee = config.version

  let projectData = [
    {
      name1: 'Version',
      value1: config.version,

      name2: 'LastBulid',
      value2: '2023/1/10',
    }, {
      name1: 'Doc',
      value1: 'https://vben.vvbin.cn/#/about/index',
      name2: 'Preview',
      value2: 'https://vben.vvbin.cn/#/about/index',
    }, {
      name1: 'Github',
      value1: 'https://vben.vvbin.cn/#/about/index',
      name2: 'Gitee',
      value2: 'https://vben.vvbin.cn/#/about/index',
    }]

  //单元格的 style 的回调方法
  const cellStyle = ({ row, column, rowIndex, columnIndex }) => {
    // 事件等级列字体颜色

    if (rowIndex === 0 && columnIndex === 1) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',

      }
    }
    if (rowIndex === 1 && columnIndex === 1) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',


      }
    }
    if (rowIndex === 2 && columnIndex === 1) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',

      }
    }
    if (rowIndex === 0 && columnIndex === 3) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',

      }
    }
    if (rowIndex === 1 && columnIndex === 3) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',

      }
    }
    if (rowIndex === 2 && columnIndex === 3) {
      return {
        //backgroundColor: 'bluess',
        color: 'CornflowerBlue',

      }
    }
  }




  let backend = [

    { Name: 'NET7', Fun: '.NET是一种用于构建多种应用的免费开源开发平台' },
    { Name: 'JWT', Fun: 'JSON Web Tokens基于JSON的开放标准((RFC 7519)' },
    { Name: 'SqlSugar', Fun: '开源 ORM 框架' },
    { Name: 'Quartz.Net', Fun: '任务调度框架' },
    { Name: 'MySql', Fun: '关系型数据库管理系统,MariaDB数据库管理系统是MySQL的一个分支' },
    { Name: 'Mapster', Fun: '高性能对象映射框架' },
    { Name: 'MiniExcel', Fun: '.NET操作Excel高效低内存的开源框架' },
    { Name: 'Epplus', Fun: '用于.NET的Excel电子表格' },
    { Name: 'Redis', Fun: '远程字典服务' },
    { Name: 'SignalR', Fun: '实时通信，服务器端实时推送至客户端' },
  ]
  let frontend = [
    { Name: 'Vue3', Fun: 'JavaScript 框架' },
    { Name: 'Vuex', Fun: '状态管理模式 + 库' },
    { Name: 'Element plus', Fun: 'Vue3 UI组件库' },
    { Name: 'Axios', Fun: 'Web数据交互方式' },
    { Name: 'Sass', Fun: 'CSS扩展语言' },
    { Name: 'Wangeditor', Fun: '富文本编辑器' },
    { Name: 'Vite', Fun: '前端构建工具' },
    { Name: 'Composition api', Fun: '组合式API' },
    { Name: 'I18n', Fun: '国际化' },
  ]
  let devDependencies = config.devDependencies
  let depData = [
    { name: '@element-plus/icons-vue', version: config.dependencies['@element-plus/icons-vue'] },
    { name: '@microsoft/signalr', version: config.dependencies['@microsoft/signalr'] },
    { name: '@vueuse/core', version: config.dependencies['@vueuse/core'] },
    { name: '@wangeditor/editor', version: config.dependencies['@wangeditor/editor'] },
    { name: '@wangeditor/editor-for-vue', version: config.dependencies['@wangeditor/editor-for-vue'] },
    { name: 'axios', version: config.dependencies['axios'] },
    { name: 'countup.js', version: config.dependencies['countup.js'] },
    { name: 'echarts', version: config.dependencies['echarts'] },
    { name: 'echarts-wordcloud', version: config.dependencies['echarts-wordcloud'] },
    { name: 'element-plus', version: config.dependencies['element-plus'] },
    { name: 'file-saver', version: config.dependencies['file-saver'] },
    { name: 'fuse.js', version: config.dependencies['fuse.js'] },
    { name: 'highlight.js', version: config.dependencies['highlight.js'] },
    { name: 'js-cookie', version: config.dependencies['js-cookie'] },
    { name: 'jsencrypt', version: config.dependencies['jsencrypt'] },
    { name: 'md-editor-v3', version: config.dependencies['md-editor-v3'] },
    { name: 'nprogress', version: config.dependencies['nprogress'] },
    { name: 'pinia', version: config.dependencies['pinia'] },
    { name: 'qs', version: config.dependencies['qs'] },
    { name: 'sortablejs', version: config.dependencies['sortablejs'] },
    { name: 'vue', version: config.dependencies['vue'] },
    { name: 'vue-clipboard3', version: config.dependencies['vue-clipboard3'] },
    { name: 'vue-cropper', version: config.dependencies['vue-cropper'] },
    { name: 'vue-i18n', version: config.dependencies['vue-i18n'] },
    { name: 'vue-router', version: config.dependencies['vue-router'] },
    { name: 'vue3-seamless-scroll', version: config.dependencies['vue3-seamless-scroll'] },

  ]
  let devData = [
    { name: '@vitejs/plugin-vue', version: config.devDependencies['@vitejs/plugin-vue'] },
    { name: '@vue/compiler-sfc', version: config.devDependencies['@vue/compiler-sfc'] },
    { name: 'sass', version: config.devDependencies['sass'] },
    { name: 'unplugin-auto-import', version: config.devDependencies['unplugin-auto-import'] },
    { name: 'vite', version: config.devDependencies['vite'] },
    { name: 'vite-plugin-compression', version: config.devDependencies['vite-plugin-compression'] },
    { name: 'vite-plugin-svg-icons', version: config.devDependencies['vite-plugin-svg-icons'] },
    { name: 'vite-plugin-vue-setup-extend', version: config.devDependencies['vite-plugin-vue-setup-extend'] },
  ]
  // 模拟表头数据


</script>

<style>
  .el-table .warning-row {
    --el-table-tr-bg-color: var(--el-color-warning-light-9);
  }

  .el-table .success-row {
    --el-table-tr-bg-color: var(--el-color-success-light-9);
  }
</style>