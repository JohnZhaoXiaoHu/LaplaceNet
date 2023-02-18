<template>
  <div>
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="fpId" label="Id主键" align="center" />
      <el-table-column prop="fpPlnt" label="工厂" align="center">
      </el-table-column>
      <el-table-column prop="fpCode" label="代码" align="center" />
      <el-table-column prop="fpName" label="名称" align="center" />
      <el-table-column prop="fpType" label="类别" align="center">
      </el-table-column>
      <el-table-column prop="fpActDate" label="有效从" align="center" />
      <el-table-column prop="fpExpDate" label="有效到" align="center" />

    </el-table>

    <div>{{total}}</div>
  </div>
</template>

<script setup name="pivot">
  // 引入 ficoprctr操作方法
  import {
    listFicoPrctr, listFicoPrctrAll, addFicoPrctr, delFicoPrctr, updateFicoPrctr, getFicoPrctr,

  }
    from '@/api/financial/ficoprctr.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()

  // 总条数
  const total = ref(0)

  // 利润中心表格数据
  const dataList = ref([])
  const dataLists = ref([])
  function GetList() {
    listFicoPrctrAll().then(res => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
      }
    })
  }
  const loadLocale = computed(() => {
    listFicoPrctrAll().then(res => {
      const { code, data } = res
      if (code == 200) {
        dataLists = data.totalNum
      }
    })
  })

  GetList()
</script>