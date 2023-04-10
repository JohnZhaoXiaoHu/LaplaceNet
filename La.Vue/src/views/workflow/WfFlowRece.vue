<!--
 * @Descripttion: (流程使用记录/wf_flow_rece)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-10)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-10)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="用户ID" prop="useid">
        <el-input clearable v-model="queryParams.useid" :placeholder="$t('btn.enter')+'用户ID'" />
      </el-form-item>
      <el-form-item label="流程模板ID" prop="floid">
        <el-input clearable v-model="queryParams.floid" :placeholder="$t('btn.enter')+'流程模板ID'" />
      </el-form-item>
      <el-form-item label="最近使用时间">
        <el-date-picker 
          v-model="dateRangeUptim" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'最近使用时间'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['la:wfflowrece:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:wfflowrece:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:wfflowrece:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:wfflowrece:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="Id主键" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('id')"/>
      <el-table-column prop="useid" label="用户ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('useid')"/>
      <el-table-column prop="floid" label="流程模板ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('floid')"/>
      <el-table-column prop="uptim" label="最近使用时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uptim')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:wfflowrece:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:wfflowrece:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改流程使用记录对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Id主键" prop="id">
              <el-input clearable v-model="form.id" controls-position="right" :placeholder="$t('btn.enter')+'Id主键'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="用户ID" prop="useid">
              <el-input clearable v-model="form.useid" :placeholder="$t('btn.enter')+'用户ID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程模板ID" prop="floid">
              <el-input clearable v-model="form.floid" :placeholder="$t('btn.enter')+'流程模板ID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最近使用时间" prop="uptim">
              <el-date-picker clearable v-model="form.uptim" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="wfflowrece">
// 引入 wfflowrece操作方法
import { listWfFlowRece, addWfFlowRece, delWfFlowRece, updateWfFlowRece, getWfFlowRece, 
 
 } 
from '@/api/workflow/wfflowrece.js'
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
  useid: undefined,
  floid: undefined,
  uptim: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'Id主键' },
  { visible: true, prop: 'useid', label: '用户ID' },
  { visible: true, prop: 'floid', label: '流程模板ID' },
  { visible: true, prop: 'uptim', label: '最近使用时间' },
])
  // 总条数
const total = ref(0)
  // 流程使用记录表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 最近使用时间时间范围
const dateRangeUptim = ref([])


var dictParams = [
]
//字典定义
//获取流程使用记录表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeUptim.value, 'Uptim');
  loading.value = true
  listWfFlowRece(queryParams).then(res => {
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
  // 最近使用时间时间范围
  dateRangeUptim.value = []
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
    id: [{ required: true, message: "Id主键"+proxy.$t('btn.empty'), trigger: "blur" }],
    useid: [{ required: true, message: "用户ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    floid: [{ required: true, message: "流程模板ID"+proxy.$t('btn.empty'), trigger: "blur" }],
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
    id: undefined,
    useid: undefined,
    floid: undefined,
    uptim: undefined,
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
  getWfFlowRece(id).then((res) => {
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
        updateWfFlowRece(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfFlowRece(form.value).then((res) => {
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
      return delWfFlowRece(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"流程使用记录", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/workflow/WfFlowRece/export', { ...queryParams })
    })
}

handleQuery()
</script>