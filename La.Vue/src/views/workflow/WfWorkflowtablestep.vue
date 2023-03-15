<!--
 * @Descripttion: (审批节点/wf_workflowtablestep)
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
        <el-button type="primary" v-hasPermi="['la:wfworkflowtablestep:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:wfworkflowtablestep:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:wfworkflowtablestep:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:wfworkflowtablestep:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="sysWorkflowtablestepId" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sysWorkflowtablestepId')"/>
      <el-table-column prop="workflowtableId" label="主表id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workflowtableId')"/>
      <el-table-column prop="workflowId" label="流程id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('workflowId')"/>
      <el-table-column prop="stepId" label="节点id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('stepId')"/>
      <el-table-column prop="stepName" label="节名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('stepName')"/>
      <el-table-column prop="stepType" label="审批类型" align="center" v-if="columns.showColumn('stepType')">
        <template #default="scope">
          <dict-tag :options=" options.stepTypeOptions" :value="scope.row.stepType" />
        </template>
      </el-table-column>
      <el-table-column prop="stepValue" label="节点类型" align="center" v-if="columns.showColumn('stepValue')"/>
      <el-table-column prop="orderId" label="审批顺序" align="center" v-if="columns.showColumn('orderId')"/>
      <el-table-column prop="auditId" label="审核人id" align="center" v-if="columns.showColumn('auditId')"/>
      <el-table-column prop="auditor" label="审核人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('auditor')"/>
      <el-table-column prop="auditStatus" label="审核状态" align="center" v-if="columns.showColumn('auditStatus')">
        <template #default="scope">
          <dict-tag :options=" options.auditStatusOptions" :value="scope.row.auditStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="auditDate" label="审核时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('auditDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="enable" label="启用" align="center" v-if="columns.showColumn('enable')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:wfworkflowtablestep:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:wfworkflowtablestep:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改审批节点对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="sysWorkflowtablestepId">
              <el-input clearable v-model="form.sysWorkflowtablestepId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="主表id" prop="workflowtableId">
              <el-input clearable v-model="form.workflowtableId" :placeholder="$t('btn.enter')+'主表id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程id" prop="workflowId">
              <el-input clearable v-model="form.workflowId" :placeholder="$t('btn.enter')+'流程id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="节点id" prop="stepId">
              <el-input clearable v-model="form.stepId" :placeholder="$t('btn.enter')+'节点id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="节名称" prop="stepName">
              <el-input clearable v-model="form.stepName" :placeholder="$t('btn.enter')+'节名称'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审批类型" prop="stepType">
              <el-select v-model="form.stepType" filterable clearable  :placeholder="$t('btn.select')+'审批类型'">
                <el-option v-for="item in  options.stepTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="节点类型" prop="stepValue">
              <el-input clearable v-model="form.stepValue" :placeholder="$t('btn.enter')+'节点类型'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审批顺序" prop="orderId">
              <el-input clearable v-model="form.orderId" :placeholder="$t('btn.enter')+'审批顺序'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审核人id" prop="auditId">
              <el-input clearable v-model="form.auditId" :placeholder="$t('btn.enter')+'审核人id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人" prop="auditor">
              <el-input clearable v-model="form.auditor" :placeholder="$t('btn.enter')+'审核人'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审核状态" prop="auditStatus">
              <el-radio-group v-model="form.auditStatus">
                <el-radio v-for="item in  options.auditStatusOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核时间" prop="auditDate">
              <el-date-picker clearable v-model="form.auditDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
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

<script setup name="wfworkflowtablestep">
// 引入 wfworkflowtablestep操作方法
import { listWfWorkflowtablestep, addWfWorkflowtablestep, delWfWorkflowtablestep, updateWfWorkflowtablestep, getWfWorkflowtablestep, 
 
 } 
from '@/api/workflow/wfworkflowtablestep.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中sysWorkflowtablestepId数组数组
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
  { visible: true, prop: 'sysWorkflowtablestepId', label: 'ID' },
  { visible: true, prop: 'workflowtableId', label: '主表id' },
  { visible: true, prop: 'workflowId', label: '流程id' },
  { visible: true, prop: 'stepId', label: '节点id' },
  { visible: true, prop: 'stepName', label: '节名称' },
  { visible: true, prop: 'stepType', label: '审批类型' },
  { visible: true, prop: 'stepValue', label: '节点类型' },
  { visible: true, prop: 'orderId', label: '审批顺序' },
  { visible: false, prop: 'auditId', label: '审核人id' },
  { visible: false, prop: 'auditor', label: '审核人' },
  { visible: false, prop: 'auditStatus', label: '审核状态' },
  { visible: false, prop: 'auditDate', label: '审核时间' },
  { visible: false, prop: 'remark', label: '备注' },
  { visible: false, prop: 'enable', label: '启用' },
])
  // 总条数
const total = ref(0)
  // 审批节点表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取审批节点表记录数据
function getList(){
  loading.value = true
  listWfWorkflowtablestep(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.sysWorkflowtablestepId);
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
    sysWorkflowtablestepId: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    workflowtableId: [{ required: true, message: "主表id"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 审批类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    stepTypeOptions: [],
    // 审核状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    sysWorkflowtablestepId: undefined,
    workflowtableId: undefined,
    workflowId: undefined,
    stepId: undefined,
    stepName: undefined,
    stepType: undefined,
    stepValue: undefined,
    orderId: undefined,
    auditId: undefined,
    auditor: undefined,
    auditStatus: undefined,
    auditDate: undefined,
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
  const id = row.sysWorkflowtablestepId || ids.value
  getWfWorkflowtablestep(id).then((res) => {
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
      if (form.value.sysWorkflowtablestepId != undefined && opertype.value === 2) {
        updateWfWorkflowtablestep(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfWorkflowtablestep(form.value).then((res) => {
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
  const Ids = row.sysWorkflowtablestepId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delWfWorkflowtablestep(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"审批节点", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/workflow/WfWorkflowtablestep/export', { ...queryParams })
    })
}

handleQuery()
</script>