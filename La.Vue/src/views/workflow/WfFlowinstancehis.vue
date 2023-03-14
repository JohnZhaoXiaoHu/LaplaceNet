<!--
 * @Descripttion: (工作流实例流转历史记录/wf_flowinstancehis)
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
        <el-button type="primary" v-hasPermi="['wf:flowinstancehis:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['wf:flowinstancehis:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['wf:flowinstancehis:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="instanceId" label="实例Id" align="center" v-if="columns.showColumn('instanceId')"/>
      <el-table-column prop="fromNodeId" label="开始节点Id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fromNodeId')"/>
      <el-table-column prop="fromNodeType" label="开始节点类型" align="center" v-if="columns.showColumn('fromNodeType')">
        <template #default="scope">
          <dict-tag :options=" options.fromNodeTypeOptions" :value="scope.row.fromNodeType" />
        </template>
      </el-table-column>
      <el-table-column prop="fromNodeName" label="开始节点名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fromNodeName')"/>
      <el-table-column prop="toNodeId" label="结束节点Id" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('toNodeId')"/>
      <el-table-column prop="toNodeType" label="结束节点类型" align="center" v-if="columns.showColumn('toNodeType')">
        <template #default="scope">
          <dict-tag :options=" options.toNodeTypeOptions" :value="scope.row.toNodeType" />
        </template>
      </el-table-column>
      <el-table-column prop="toNodeName" label="结束节点名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('toNodeName')"/>
      <el-table-column prop="transitionSate" label="转化状态" align="center" v-if="columns.showColumn('transitionSate')"/>
      <el-table-column prop="isFinish" label="是否结束" align="center" v-if="columns.showColumn('isFinish')">
        <template #default="scope">
          <dict-tag :options=" options.isFinishOptions" :value="scope.row.isFinish" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="Remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['wf:flowinstancehis:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['wf:flowinstancehis:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改工作流实例流转历史记录对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="id">
              <el-input clearable v-model="form.id" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>

    
          <el-col :lg="12">
            <el-form-item label="实例Id" prop="instanceId">
              <el-input clearable v-model="form.instanceId" :placeholder="$t('btn.enter')+'实例Id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="开始节点Id" prop="fromNodeId">
              <el-input clearable v-model="form.fromNodeId" :placeholder="$t('btn.enter')+'开始节点Id'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="开始节点类型" prop="fromNodeType">
              <el-select v-model="form.fromNodeType" filterable clearable  :placeholder="$t('btn.select')+'开始节点类型'">
                <el-option v-for="item in  options.fromNodeTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="开始节点名称" prop="fromNodeName">
              <el-input clearable v-model="form.fromNodeName" :placeholder="$t('btn.enter')+'开始节点名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="结束节点Id" prop="toNodeId">
              <el-input clearable v-model="form.toNodeId" :placeholder="$t('btn.enter')+'结束节点Id'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="结束节点类型" prop="toNodeType">
              <el-select v-model="form.toNodeType" filterable clearable  :placeholder="$t('btn.select')+'结束节点类型'">
                <el-option v-for="item in  options.toNodeTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="结束节点名称" prop="toNodeName">
              <el-input clearable v-model="form.toNodeName" :placeholder="$t('btn.enter')+'结束节点名称'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="转化状态" prop="transitionSate">
              <el-input clearable v-model="form.transitionSate" :placeholder="$t('btn.enter')+'转化状态'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="是否结束" prop="isFinish">
              <el-radio-group v-model="form.isFinish">
                <el-radio v-for="item in  options.isFinishOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Remark" prop="remark">
              <el-input clearable type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'Remark'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建用户" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建用户'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转化时间" prop="createTime">
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

<script setup name="wfflowinstancehis">
// 引入 wfflowinstancehis操作方法
import { listWfFlowinstancehis, addWfFlowinstancehis, delWfFlowinstancehis, updateWfFlowinstancehis, getWfFlowinstancehis, 
 
 } 
from '@/api/workflow/wfflowinstancehis.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中id数组数组
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
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'instanceId', label: '实例Id' },
  { visible: true, prop: 'fromNodeId', label: '开始节点Id' },
  { visible: true, prop: 'fromNodeType', label: '开始节点类型' },
  { visible: true, prop: 'fromNodeName', label: '开始节点名称' },
  { visible: true, prop: 'toNodeId', label: '结束节点Id' },
  { visible: true, prop: 'toNodeType', label: '结束节点类型' },
  { visible: true, prop: 'toNodeName', label: '结束节点名称' },
  { visible: false, prop: 'transitionSate', label: '转化状态' },
  { visible: false, prop: 'isFinish', label: '是否结束' },
  { visible: false, prop: 'remark', label: 'Remark' },
])
  // 总条数
const total = ref(0)
  // 工作流实例流转历史记录表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取工作流实例流转历史记录表记录数据
function getList(){
  loading.value = true
  listWfFlowinstancehis(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.id);
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    instanceId: [{ required: true, message: "实例Id"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    transitionSate: [{ required: true, message: "转化状态"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    isFinish: [{ required: true, message: "是否结束"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 开始节点类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    fromNodeTypeOptions: [],
    // 结束节点类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    toNodeTypeOptions: [],
    // 是否结束 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isFinishOptions: [],
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
    id: undefined,
    instanceId: undefined,
    fromNodeId: undefined,
    fromNodeType: undefined,
    fromNodeName: undefined,
    toNodeId: undefined,
    toNodeType: undefined,
    toNodeName: undefined,
    transitionSate: undefined,
    isFinish: undefined,
    remark: undefined,
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
  const id = row.id || ids.value
  getWfFlowinstancehis(id).then((res) => {
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
      if (form.value.id != undefined && opertype.value === 2) {
        updateWfFlowinstancehis(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfFlowinstancehis(form.value).then((res) => {
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
  const Ids = row.id || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delWfFlowinstancehis(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}




handleQuery()
</script>