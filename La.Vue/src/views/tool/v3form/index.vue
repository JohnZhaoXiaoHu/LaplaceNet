<template>
  <el-table :data="tableData" style="width: 100%">

    <el-table-column label="Vue3 适用表格推荐">

      <el-table-column prop="name" label="Name" />
      <el-table-column prop="version" label="Version" />
      <el-table-column prop="introduce" label="Introduce" />
      <el-table-column prop="document" label="Document">
        <template #default="scope">
          <a :href="scope.row.document" type="danger" target="_blank" class="buttonText">{{scope.row.document}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="source" label="Source">
        <template #default="scope">
          <a :href="scope.row.source" target="_blank" class="buttonText">{{scope.row.source}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="date" label="Date" />

    </el-table-column>
  </el-table>
</template>

<script setup>
  const tableData = [
    {
      date: '2023/1/15',
      name: 'Variant Form(有冲突待解决)',
      version: 'vform3-builds',
      introduce: '提供PC、Pad、H5三种表单设计布局，PC、平板、移动表单设计同时兼顾。',
      document: 'https://www.vform666.com/document3.html',
      source: 'https://github.com/vform666/variant-form3-vite',
    },
    {
      date: '2023/1/15',
      name: 'FormMaking V3(付费,个人不予以考虑)',
      version: 'FormMaking V3',
      introduce: '基于 Vue 3.x 和 Element Plus 开发的可视化/低代码表单设计器。',
      document: 'https://form.making.link/docs/v3/getting-started.html',
      source: 'https://form.making.link/#/zh-CN/',
    },
    {
      date: '2023/1/15',
      name: 'form-generator',
      version: 'form-generator',
      introduce: 'Element UI表单设计及代码生成器。',
      document: 'https://gitee.com/mrhj/form-generator',
      source: 'https://gitee.com/mrhj/form-generator',
    },
    {
      date: '2023/1/15',
      name: 'formkit',
      version: 'formkit',
      introduce: 'old<Vue Formulate>,Build Vue 3 forms10x faster.',
      document: 'https://formkit.com/',
      source: 'https://formkit.com/',
    },
    {
      date: '2023/1/15',
      name: 'v-schema-form-next',
      version: 'vueschemaform',
      introduce: 'Vue表单解决方案',
      document: 'https://vueschemaform.aegis-info.com/doc/jieshao',
      source: 'https://gitee.com/wuhao000/v-schema-form-next',
    },
    {
      date: '2023/1/15',
      name: 'form-create',
      version: 'form-create',
      introduce: '表单生成组件',
      document: 'http://form-create.com/v3/guide/',
      source: 'https://github.com/xaboy/form-create/tree/next',
    },
  ]
</script>
<style scoped>
</style>