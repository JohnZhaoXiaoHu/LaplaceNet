<!--
 * @Descripttion: (审批流程/wf_workflow)
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
        <el-button type="primary" v-hasPermi="['la:wfworkflow:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:wfworkflow:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:wfworkflow:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:wfworkflow:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="workflowId" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workflowId')"/>
      <el-table-column prop="workName" label="流程名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workName')"/>
      <el-table-column prop="workTable" label="表名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workTable')"/>
      <el-table-column prop="workTableName" label="功能菜单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workTableName')"/>
      <el-table-column prop="nodeConfig" label="节点信息" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('nodeConfig')"/>
      <el-table-column prop="lineConfig" label="连接配置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('lineConfig')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="enable" label="是否启用" align="center" v-if="columns.showColumn('enable')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:wfworkflow:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:wfworkflow:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改审批流程对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="workflowId">
              <el-input clearable v-model="form.workflowId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="流程名称" prop="workName">
              <el-input clearable v-model="form.workName" :placeholder="$t('btn.enter')+'流程名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表名" prop="workTable">
              <el-input clearable v-model="form.workTable" :placeholder="$t('btn.enter')+'表名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="功能菜单" prop="workTableName">
              <el-input clearable v-model="form.workTableName" :placeholder="$t('btn.enter')+'功能菜单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="节点信息" prop="nodeConfig">
              <el-input clearable v-model="form.nodeConfig" :placeholder="$t('btn.enter')+'节点信息'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="连接配置" prop="lineConfig">
              <el-input clearable v-model="form.lineConfig" :placeholder="$t('btn.enter')+'连接配置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="是否启用" prop="enable">
              <el-input clearable v-model="form.enable" :placeholder="$t('btn.enter')+'是否启用'" />
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

<script setup name="wfworkflow">
// 引入 wfworkflow操作方法
import { listWfWorkflow, addWfWorkflow, delWfWorkflow, updateWfWorkflow, getWfWorkflow, 
 
 } 
from '@/api/workflow/wfworkflow.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中workflowId数组数组
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
  { visible: true, prop: 'workflowId', label: 'ID' },
  { visible: true, prop: 'workName', label: '流程名称' },
  { visible: true, prop: 'workTable', label: '表名' },
  { visible: true, prop: 'workTableName', label: '功能菜单' },
  { visible: true, prop: 'nodeConfig', label: '节点信息' },
  { visible: true, prop: 'lineConfig', label: '连接配置' },
  { visible: true, prop: 'remark', label: '备注' },
  { visible: true, prop: 'enable', label: '是否启用' },
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
  listWfWorkflow(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.workflowId);
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
    workflowId: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    workName: [{ required: true, message: "流程名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    workTable: [{ required: true, message: "表名"+proxy.$t('btn.empty'), trigger: "blur" }],
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
    workflowId: undefined,
    workName: undefined,
    workTable: undefined,
    workTableName: undefined,
    nodeConfig: undefined,
    lineConfig: undefined,
    remark: undefined,
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
  const id = row.workflowId || ids.value
  getWfWorkflow(id).then((res) => {
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
      if (form.value.workflowId != undefined && opertype.value === 2) {
        updateWfWorkflow(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfWorkflow(form.value).then((res) => {
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
  const Ids = row.workflowId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delWfWorkflow(Ids)
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
      await proxy.downFile('/workflow/WfWorkflow/export', { ...queryParams })
    })
}

handleQuery()
</script>