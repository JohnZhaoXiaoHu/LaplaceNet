<!--
 * @Descripttion: (财务期间/fico_period)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="年月" prop="fpYm">
        <el-input clearable v-model="queryParams.fpYm" :placeholder="$t('btn.enter')+'年月'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:period:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:period:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:period:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['fico:period:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:period:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="fpId" label="ID" align="center" v-if="columns.showColumn('fpId')"/>
      <el-table-column prop="fpFy" label="财年" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpFy')"/>
      <el-table-column prop="fpYm" label="年月" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpYm')"/>
      <el-table-column prop="fpYear" label="年" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpYear')"/>
      <el-table-column prop="fpMonth" label="月" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpMonth')"/>
      <el-table-column prop="fpQuarter" label="季度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpQuarter')"/>
      <el-table-column prop="isDeleted" label="isDeleted" align="center" v-if="columns.showColumn('isDeleted')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:period:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:period:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改财务期间对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="fpId">
              <el-input-number clearable v-model.number="form.fpId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="财年" prop="fpFy">
              <el-input clearable v-model="form.fpFy" :placeholder="$t('btn.enter')+'财年'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fpYm">
              <el-input clearable v-model="form.fpYm" :placeholder="$t('btn.enter')+'年月'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年" prop="fpYear">
              <el-input clearable v-model="form.fpYear" :placeholder="$t('btn.enter')+'年'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="月" prop="fpMonth">
              <el-input clearable v-model="form.fpMonth" :placeholder="$t('btn.enter')+'月'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季度" prop="fpQuarter">
              <el-input clearable v-model="form.fpQuarter" :placeholder="$t('btn.enter')+'季度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="isDeleted" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'isDeleted'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="reMark" prop="reMark">
              <el-input clearable v-model="form.reMark" :placeholder="$t('btn.enter')+'reMark'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker clearable v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker clearable v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ficoperiod">
// 引入 ficoperiod操作方法
import { listFicoPeriod, addFicoPeriod, delFicoPeriod, updateFicoPeriod, getFicoPeriod, 
 
 } 
from '@/api/financial/ficoperiod.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中fpId数组数组
const ids = ref([])
// 非单个禁用
const single = ref(true)
// 非多个禁用
const multiple = ref(true)
const loading = ref(false)
  // 显示搜索条件
const showSearch = ref(true)
//使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const queryParams = reactive({
  pageNum: 1,
  pageSize: 17,
  sort: '',
  sortType: 'asc',
  fpYm: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fpId', label: 'ID' },
  { visible: true, prop: 'fpFy', label: '财年' },
  { visible: true, prop: 'fpYm', label: '年月' },
  { visible: true, prop: 'fpYear', label: '年' },
  { visible: true, prop: 'fpMonth', label: '月' },
  { visible: true, prop: 'fpQuarter', label: '季度' },
  { visible: true, prop: 'isDeleted', label: '' },
])
  // 总条数
const total = ref(0)
  // 财务期间表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取财务期间表记录数据
function getList(){
  loading.value = true
  listFicoPeriod(queryParams).then(res => {
    const { code, data } = res
    if (code == 200) {
      dataList.value = data.result
      total.value = data.totalNum
      loading.value = false
    }
  })
}

// 查询
function handleQuery() {
  queryParams.pageNum = 1
  getList()
}

// 重置查询操作
function resetQuery(){
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.fpId);
  single.value = selection.length != 1
  multiple.value = !selection.length;
}

// 自定义排序
function sortChange(column) {
  var sort = undefined
  var sortType = undefined

  if (column.prop != null && column.order != null) {
    sort = column.prop
    sortType = column.order

  }
  queryParams.sort = sort
  queryParams.sortType = sortType
  handleQuery()
}

/*************** form操作 ***************/
//定义响应式变量
const formRef = ref()
  // 弹出层标题
const title = ref("")
// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开变更
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  form: {},
  rules: {
    fpFy: [{ required: true, message: "财年"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpYear: [{ required: true, message: "年"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpMonth: [{ required: true, message: "月"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpQuarter: [{ required: true, message: "季度"+proxy.$t('btn.empty'), trigger: "blur" }],
    isDeleted: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
  }
})
//将响应式对象转换成普通对象
const { form, rules, options } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    fpFy: undefined,
    fpYm: undefined,
    fpYear: undefined,
    fpMonth: undefined,
    fpQuarter: undefined,
    isDeleted: undefined,
    createBy: undefined,
    createTime: undefined,
    updateBy: undefined,
    updateTime: undefined,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')
  opertype.value = 1
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fpId || ids.value
  getFicoPeriod(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')
      opertype.value = 2

      form.value = {
      ...data,
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      if (form.value.fpId != undefined && opertype.value === 2) {
        updateFicoPeriod(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoPeriod(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
          .catch(() => {})
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.fpId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoPeriod(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"财务期间", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/financial/FicoPeriod/export', { ...queryParams })
    })
}

handleQuery()
</script>