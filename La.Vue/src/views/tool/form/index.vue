<template>
  <div id="app">
    <div class="_fc-t-header">
      <img class="_fc-t-logo" src="http://form-create.com/logo.png">
      <div class="_fc-t-name">form-create-designer</div>
      <div class="_fc-t-menu">
        <el-button size="small" @click="setJson"> 导入JSON</el-button>
        <el-button size="small" @click="setOption"> 导入Options</el-button>
        <el-button size="small" type="primary" @click="showJson">生成JSON</el-button>
        <el-button size="small" type="success" @click="showOption">生成Options</el-button>
        <el-button size="small" type="danger" @click="showTemplate">生成组件</el-button>
        <el-button size="small" @click="changeLocale">中英切换</el-button>
      </div>
    </div>
    <fc-designer ref="designer" :locale="locale" />
  </div>
</template>

<script setup>
  const TITLE = ['生成规则', '表单规则', '生成组件', '设置生成规则', '设置表单规则'];
  function showJson() {
    this.state = true;
    this.type = 0;
    this.value = this.$refs.designer.getRule();
  }


</script>

<style>
  ._fc-t-header {
    height: 60px;
    margin: 0 20px;
    position: relative;
    display: flex;
    align-items: center;
    cursor: default;
  }

  ._fc-t-logo {
    height: 26px;
  }

  ._fc-t-name {
    display: inline-block;
    color: rgba(0, 0, 0, 0.8);
    font-size: 20px;
    font-weight: 600;
    margin-left: 5px;
  }

  ._fc-t-menu {
    position: absolute;
    right: 0;
  }

  ._fc-t-menu i {
    font-size: 12px;
  }

  body {
    min-height: 100vh;
    padding: 0;
    margin: 0;
    display: flex !important;
    flex-direction: column !important;
  }

  #app {
    display: flex;
    flex-direction: column;
    flex: 1;
  }

  ._fc-copyright {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    padding: 0 20px;
    font-size: 16px;
    border-top: 1px solid #ECECEC;
    background-color: #fff;
    cursor: pointer;
  }

  ._fc-t-dialog .CodeMirror {
    height: 450px;
  }

  ._fc-t-dialog .CodeMirror-line {
    line-height: 16px !important;
    font-size: 13px !important;
  }

  .CodeMirror-lint-tooltip {
    z-index: 2021 !important;
  }

  ._fc-t-dialog .el-dialog__body {
    padding: 0px 20px;
  }

  ._fc-b-item {
    display: flex;
  }
</style>