<!--
 * @Descripttion: (审批流程/wf_workflowtable)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-03-14)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-03-14)
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
        <el-button type="primary" v-hasPermi="['la:wfworkflowtable:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:wfworkflowtable:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:wfworkflowtable:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:wfworkflowtable:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="workflowtableId" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workflowtableId')"/>
      <el-table-column prop="workflowId" label="流程id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workflowId')"/>
      <el-table-column prop="workName" label="流程名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workName')"/>
      <el-table-column prop="workTableKey" label="表主键id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workTableKey')"/>
      <el-table-column prop="workTable" label="表名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workTable')"/>
      <el-table-column prop="workTableName" label="业务名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workTableName')"/>
      <el-table-column prop="currentOrderId" label="当前审批节点" align="center" v-if="columns.showColumn('currentOrderId')"/>
      <el-table-column prop="auditStatus" label="审批状态" align="center" v-if="columns.showColumn('auditStatus')">
        <template #default="scope">
          <dict-tag :options=" options.auditStatusOptions" :value="scope.row.auditStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="enable" label="启用" align="center" v-if="columns.showColumn('enable')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:wfworkflowtable:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:wfworkflowtable:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改审批流程对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="workflowtableId">
              <el-input clearable v-model="form.workflowtableId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="流程id" prop="workflowId">
              <el-input clearable v-model="form.workflowId" :placeholder="$t('btn.enter')+'流程id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程名称" prop="workName">
              <el-input clearable v-model="form.workName" :placeholder="$t('btn.enter')+'流程名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表主键id" prop="workTableKey">
              <el-input clearable v-model="form.workTableKey" :placeholder="$t('btn.enter')+'表主键id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表名" prop="workTable">
              <el-input clearable v-model="form.workTable" :placeholder="$t('btn.enter')+'表名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="业务名称" prop="workTableName">
              <el-input clearable v-model="form.workTableName" :placeholder="$t('btn.enter')+'业务名称'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="当前审批节点" prop="currentOrderId">
              <el-input clearable v-model="form.currentOrderId" :placeholder="$t('btn.enter')+'当前审批节点'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审批状态" prop="auditStatus">
              <el-radio-group v-model="form.auditStatus">
                <el-radio v-for="item in  options.auditStatusOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="启用" prop="enable">
              <el-input clearable v-model="form.enable" :placeholder="$t('btn.enter')+'启用'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateBy" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'CreateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateTime" prop="createTime">
              <el-date-picker clearable v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateBy" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'UpdateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateTime" prop="updateTime">
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

<script setup name="wfworkflowtable">
// 引入 wfworkflowtable操作方法
import { listWfWorkflowtable, addWfWorkflowtable, delWfWorkflowtable, updateWfWorkflowtable, getWfWorkflowtable, 
 
 } 
from '@/api/workflow/wfworkflowtable.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中workflowtableId数组数组
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
  { visible: true, prop: 'workflowtableId', label: 'ID' },
  { visible: true, prop: 'workflowId', label: '流程id' },
  { visible: true, prop: 'workName', label: '流程名称' },
  { visible: true, prop: 'workTableKey', label: '表主键id' },
  { visible: true, prop: 'workTable', label: '表名' },
  { visible: true, prop: 'workTableName', label: '业务名称' },
  { visible: true, prop: 'currentOrderId', label: '当前审批节点' },
  { visible: true, prop: 'auditStatus', label: '审批状态' },
  { visible: false, prop: 'enable', label: '启用' },
])
  // 总条数
const total = ref(0)
  // 审批流程表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取审批流程表记录数据
function getList(){
  loading.value = true
  listWfWorkflowtable(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.workflowtableId);
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
    workflowtableId: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 审批状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    auditStatusOptions: [],
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
    workflowtableId: undefined,
    workflowId: undefined,
    workName: undefined,
    workTableKey: undefined,
    workTable: undefined,
    workTableName: undefined,
    currentOrderId: undefined,
    auditStatus: undefined,
    enable: undefined,
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
  const id = row.workflowtableId || ids.value
  getWfWorkflowtable(id).then((res) => {
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
      if (form.value.workflowtableId != undefined && opertype.value === 2) {
        updateWfWorkflowtable(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfWorkflowtable(form.value).then((res) => {
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
  const Ids = row.workflowtableId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delWfWorkflowtable(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"审批流程", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/workflow/WfWorkflowtable/export', { ...queryParams })
    })
}

handleQuery()
</script>