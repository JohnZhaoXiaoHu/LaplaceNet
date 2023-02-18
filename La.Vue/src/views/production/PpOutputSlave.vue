<!--
 * @Descripttion: (oph从表/pp_output_slave)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-18)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-18)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="父GUID" prop="pomGuid">
        <el-input v-model="queryParams.pomGuid" placeholder="请输入父GUID" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:outputslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputslave:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="posId" label="ID" align="center" v-if="columns.showColumn('posId')"/>
      <el-table-column prop="pomGuid" label="父GUID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomGuid')"/>
      <el-table-column prop="posStartEndTime" label="生产时段" align="center" v-if="columns.showColumn('posStartEndTime')">
        <template #default="scope">
          <dict-tag :options=" options.sys_productive_list " :value="scope.row.posStartEndTime" />
        </template>
      </el-table-column>
      <el-table-column prop="posRealOutput" label="实际产能" align="center" v-if="columns.showColumn('posRealOutput')"/>
      <el-table-column prop="posLineStopTime" label="停线时间" align="center" v-if="columns.showColumn('posLineStopTime')"/>
      <el-table-column prop="posStopCause" label="停线原因" align="center" v-if="columns.showColumn('posStopCause')">
        <template #default="scope">
          <dict-tag :options=" options.sql_stop_line " :value="scope.row.posStopCause" />
        </template>
      </el-table-column>
      <el-table-column prop="posStopMemo" label="停线说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posStopMemo')"/>
      <el-table-column prop="posBadCause" label="未达成原因" align="center" v-if="columns.showColumn('posBadCause')">
        <template #default="scope">
          <dict-tag :options=" options.sql_notreachebad_list " :value="scope.row.posBadCause" />
        </template>
      </el-table-column>
      <el-table-column prop="posBadMemo" label="未达成说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posBadMemo')"/>
      <el-table-column prop="posRealTime" label="实际工数" align="center" v-if="columns.showColumn('posRealTime')"/>
      <el-table-column prop="posRealWork" label="实际工时" align="center" v-if="columns.showColumn('posRealWork')"/>
      <el-table-column prop="posRealWorkDiff" label="工时差异" align="center" v-if="columns.showColumn('posRealWorkDiff')"/>
      <el-table-column prop="posRealOutputDiff" label="产能差异" align="center" v-if="columns.showColumn('posRealOutputDiff')"/>
      <el-table-column prop="posAchRatio" label="达成率" align="center" v-if="columns.showColumn('posAchRatio')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:outputslave:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputslave:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改oph从表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="posId">
              <el-input-number v-model.number="form.posId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="父GUID" prop="pomGuid">
              <el-input v-model="form.pomGuid" :placeholder="$t('btn.enter')+'父GUID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产时段" prop="posStartEndTime">
              <el-select v-model="form.posStartEndTime" :placeholder="$t('btn.select')+'生产时段'">
                <el-option v-for="item in  options.sys_productive_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="实际产能" prop="posRealOutput">
              <el-input v-model="form.posRealOutput" :placeholder="$t('btn.enter')+'实际产能'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="停线时间" prop="posLineStopTime">
              <el-input v-model="form.posLineStopTime" :placeholder="$t('btn.enter')+'停线时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线原因" prop="posStopCause">
              <el-select v-model="form.posStopCause" :placeholder="$t('btn.select')+'停线原因'">
                <el-option v-for="item in  options.sql_stop_line " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线说明" prop="posStopMemo">
              <el-input v-model="form.posStopMemo" :placeholder="$t('btn.enter')+'停线说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成原因" prop="posBadCause">
              <el-select v-model="form.posBadCause" :placeholder="$t('btn.select')+'未达成原因'">
                <el-option v-for="item in  options.sql_notreachebad_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成说明" prop="posBadMemo">
              <el-input v-model="form.posBadMemo" :placeholder="$t('btn.enter')+'未达成说明'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="实际工数" prop="posRealTime">
              <el-input v-model="form.posRealTime" :placeholder="$t('btn.enter')+'实际工数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际工时" prop="posRealWork">
              <el-input v-model="form.posRealWork" :placeholder="$t('btn.enter')+'实际工时'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时差异" prop="posRealWorkDiff">
              <el-input v-model="form.posRealWorkDiff" :placeholder="$t('btn.enter')+'工时差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产能差异" prop="posRealOutputDiff">
              <el-input v-model="form.posRealOutputDiff" :placeholder="$t('btn.enter')+'产能差异'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="达成率" prop="posAchRatio">
              <el-input v-model="form.posAchRatio" :placeholder="$t('btn.enter')+'达成率'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF01" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'uDF01'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF02" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'uDF02'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF03" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'uDF03'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF04" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'uDF04'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF05" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'uDF05'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF06" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'uDF06'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF51" prop="uDF51">
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enter')+'uDF51'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF52" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enter')+'uDF52'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF53" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enter')+'uDF53'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF54" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enter')+'uDF54'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF55" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enter')+'uDF55'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF56" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enter')+'uDF56'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="reMark">
              <el-input v-model="form.reMark" :placeholder="$t('btn.enter')+'说明'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ppoutputslave">
// 引入 ppoutputslave操作方法
import { listPpOutputSlave, addPpOutputSlave, delPpOutputSlave, updatePpOutputSlave, getPpOutputSlave, 
 
 } 
from '@/api/production/ppoutputslave.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中posId数组数组
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
  pomGuid: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'posId', label: 'ID' },
  { visible: true, prop: 'pomGuid', label: '父GUID' },
  { visible: true, prop: 'posStartEndTime', label: '生产时段' },
  { visible: true, prop: 'posRealOutput', label: '实际产能' },
  { visible: true, prop: 'posLineStopTime', label: '停线时间' },
  { visible: true, prop: 'posStopCause', label: '停线原因' },
  { visible: true, prop: 'posStopMemo', label: '停线说明' },
  { visible: true, prop: 'posBadCause', label: '未达成原因' },
  { visible: false, prop: 'posBadMemo', label: '未达成说明' },
  { visible: false, prop: 'posRealTime', label: '实际工数' },
  { visible: false, prop: 'posRealWork', label: '实际工时' },
  { visible: false, prop: 'posRealWorkDiff', label: '工时差异' },
  { visible: false, prop: 'posRealOutputDiff', label: '产能差异' },
  { visible: false, prop: 'posAchRatio', label: '达成率' },
])
  // 总条数
const total = ref(0)
  // oph从表表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_productive_list" },
  { dictType: "sql_stop_line" },
  { dictType: "sql_notreachebad_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取oph从表表记录数据
function getList(){
  loading.value = true
  listPpOutputSlave(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.posId);
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
    pomGuid: [{ required: true, message: "父GUID"+proxy.$t('btn.empty'), trigger: "blur" }],
    posRealOutput: [{ required: true, message: "实际产能"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    posLineStopTime: [{ required: true, message: "停线时间"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    posRealTime: [{ required: true, message: "实际工数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    posRealWork: [{ required: true, message: "实际工时"+proxy.$t('btn.empty'), trigger: "blur" }],
    posRealWorkDiff: [{ required: true, message: "工时差异"+proxy.$t('btn.empty'), trigger: "blur" }],
    posRealOutputDiff: [{ required: true, message: "产能差异"+proxy.$t('btn.empty'), trigger: "blur" }],
    posAchRatio: [{ required: true, message: "达成率"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 生产时段 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_productive_list: [],
    // 停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_stop_line: [],
    // 未达成原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_notreachebad_list: [],
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
    pomGuid: undefined,
    posStartEndTime: undefined,
    posRealOutput: undefined,
    posLineStopTime: undefined,
    posStopCause: undefined,
    posStopMemo: undefined,
    posBadCause: undefined,
    posBadMemo: undefined,
    posRealTime: undefined,
    posRealWork: undefined,
    posRealWorkDiff: undefined,
    posRealOutputDiff: undefined,
    posAchRatio: undefined,
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
  const id = row.posId || ids.value
  getPpOutputSlave(id).then((res) => {
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
      if (form.value.posId != undefined && opertype.value === 2) {
        updatePpOutputSlave(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpOutputSlave(form.value).then((res) => {
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
  const Ids = row.posId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpOutputSlave(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"oph从表", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpOutputSlave/export', { ...queryParams })
    })
}

handleQuery()
</script>