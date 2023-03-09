<!--
 * @Descripttion: (抽样标准/qm_check_aql)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['qm:checkaql:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['qm:checkaql:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['qm:checkaql:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['qm:checkaql:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="qcaqlGuid" label="Guid" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcaqlGuid')"/>
      <el-table-column prop="qcaqlLevel" label="查检水平" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcaqlLevel')"/>
      <el-table-column prop="qcaqlRange" label="批量范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcaqlRange')"/>
      <el-table-column prop="qcaqlRangeMinmum" label="最小值" align="center" v-if="columns.showColumn('qcaqlRangeMinmum')"/>
      <el-table-column prop="qcaqlRangeMaximum" label="最大值" align="center" v-if="columns.showColumn('qcaqlRangeMaximum')"/>
      <el-table-column prop="qcaqlSamplesCode" label="样本码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcaqlSamplesCode')"/>
      <el-table-column prop="qcaqlSamplesQty" label="抽样数" align="center" v-if="columns.showColumn('qcaqlSamplesQty')"/>
      <el-table-column prop="qcaqlAcQty" label="合格项" align="center" v-if="columns.showColumn('qcaqlAcQty')"/>
      <el-table-column prop="qcaqlReQty" label="不合格项" align="center" v-if="columns.showColumn('qcaqlReQty')"/>
      <el-table-column prop="reMark" label="reMark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['qm:checkaql:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['qm:checkaql:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改抽样标准对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Guid" prop="qcaqlGuid">
              <el-input clearable v-model="form.qcaqlGuid" controls-position="right" :placeholder="$t('btn.enter')+'Guid'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="查检水平" prop="qcaqlLevel">
              <el-input clearable v-model="form.qcaqlLevel" :placeholder="$t('btn.enter')+'查检水平'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批量范围" prop="qcaqlRange">
              <el-input clearable v-model="form.qcaqlRange" :placeholder="$t('btn.enter')+'批量范围'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="最小值" prop="qcaqlRangeMinmum">
              <el-input-number clearable v-model.number="form.qcaqlRangeMinmum" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'最小值'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="最大值" prop="qcaqlRangeMaximum">
              <el-input-number clearable v-model.number="form.qcaqlRangeMaximum" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'最大值'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="样本码" prop="qcaqlSamplesCode">
              <el-input clearable v-model="form.qcaqlSamplesCode" :placeholder="$t('btn.enter')+'样本码'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="抽样数" prop="qcaqlSamplesQty">
              <el-input-number clearable v-model.number="form.qcaqlSamplesQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'抽样数'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="合格项" prop="qcaqlAcQty">
              <el-input-number clearable v-model.number="form.qcaqlAcQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'合格项'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="不合格项" prop="qcaqlReQty">
              <el-input-number clearable v-model.number="form.qcaqlReQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'不合格项'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'uDF01'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'uDF02'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'uDF03'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'uDF04'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'uDF05'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'uDF06'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'uDF51'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'uDF52'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'uDF53'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'uDF54'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'uDF55'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'uDF56'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="isDeleted" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'isDeleted'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="reMark" prop="reMark">
              <el-input clearable v-model="form.reMark" :placeholder="$t('btn.enter')+'reMark'" />
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

<script setup name="qmcheckaql">
// 引入 qmcheckaql操作方法
import { listQmCheckAql, addQmCheckAql, delQmCheckAql, updateQmCheckAql, getQmCheckAql, 
 
 } 
from '@/api/quality/qmcheckaql.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中qcaqlGuid数组数组
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
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qcaqlGuid', label: 'Guid' },
  { visible: true, prop: 'qcaqlLevel', label: '查检水平' },
  { visible: true, prop: 'qcaqlRange', label: '批量范围' },
  { visible: true, prop: 'qcaqlRangeMinmum', label: '最小值' },
  { visible: true, prop: 'qcaqlRangeMaximum', label: '最大值' },
  { visible: true, prop: 'qcaqlSamplesCode', label: '样本码' },
  { visible: true, prop: 'qcaqlSamplesQty', label: '抽样数' },
  { visible: true, prop: 'qcaqlAcQty', label: '合格项' },
  { visible: false, prop: 'qcaqlReQty', label: '不合格项' },
  { visible: false, prop: 'reMark', label: '' },
])
  // 总条数
const total = ref(0)
  // 抽样标准表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取抽样标准表记录数据
function getList(){
  loading.value = true
  listQmCheckAql(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.qcaqlGuid);
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
    qcaqlGuid: [{ required: true, message: "Guid"+proxy.$t('btn.empty'), trigger: "blur" }],
    qcaqlLevel: [{ required: true, message: "查检水平"+proxy.$t('btn.empty'), trigger: "blur" }],
    qcaqlRange: [{ required: true, message: "批量范围"+proxy.$t('btn.empty'), trigger: "blur" }],
    qcaqlRangeMinmum: [{ required: true, message: "最小值"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    qcaqlRangeMaximum: [{ required: true, message: "最大值"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    qcaqlSamplesCode: [{ required: true, message: "样本码"+proxy.$t('btn.empty'), trigger: "blur" }],
    qcaqlSamplesQty: [{ required: true, message: "抽样数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    qcaqlAcQty: [{ required: true, message: "合格项"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    qcaqlReQty: [{ required: true, message: "不合格项"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
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
    qcaqlGuid: undefined,
    qcaqlLevel: undefined,
    qcaqlRange: undefined,
    qcaqlRangeMinmum: undefined,
    qcaqlRangeMaximum: undefined,
    qcaqlSamplesCode: undefined,
    qcaqlSamplesQty: undefined,
    qcaqlAcQty: undefined,
    qcaqlReQty: undefined,
    reMark: undefined,
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
  const id = row.qcaqlGuid || ids.value
  getQmCheckAql(id).then((res) => {
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
      if (form.value.qcaqlGuid != undefined && opertype.value === 2) {
        updateQmCheckAql(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addQmCheckAql(form.value).then((res) => {
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
  const Ids = row.qcaqlGuid || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delQmCheckAql(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"抽样标准", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/quality/QmCheckAql/export', { ...queryParams })
    })
}

handleQuery()
</script>