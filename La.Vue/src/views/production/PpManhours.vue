<!--
 * @Descripttion: (标准工时/pp_manhours)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="生效日期">
        <el-date-picker 
          v-model="dateRangeMhEffDate" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'生效日期'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="工厂" prop="mhPlant">
        <el-select filterable clearable  v-model="queryParams.mhPlant" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种名" prop="mhModelType">
        <el-select filterable clearable  v-model="queryParams.mhModelType" :placeholder="$t('btn.select')+'机种名'">
          <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仕向别" prop="mhRegionType">
        <el-select filterable clearable  v-model="queryParams.mhRegionType" :placeholder="$t('btn.select')+'仕向别'">
          <el-option v-for="item in  options.sql_region_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mhItem">
        <el-select filterable clearable  v-model="queryParams.mhItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:manhours:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:manhours:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:manhours:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:manhours:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="mhId" label="ID" align="center" v-if="columns.showColumn('mhId')"/>
      <el-table-column prop="mhEffDate" label="生效日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mhEffDate')"/>
      <el-table-column prop="mhPlant" label="工厂" align="center" v-if="columns.showColumn('mhPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.mhPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="mhModelType" label="机种名" align="center" v-if="columns.showColumn('mhModelType')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_model " :value="scope.row.mhModelType" />
        </template>
      </el-table-column>
      <el-table-column prop="mhRegionType" label="仕向别" align="center" v-if="columns.showColumn('mhRegionType')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_list " :value="scope.row.mhRegionType" />
        </template>
      </el-table-column>
      <el-table-column prop="mhItem" label="物料" align="center" v-if="columns.showColumn('mhItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.mhItem" />
        </template>
      </el-table-column>
      <el-table-column prop="mhItemText" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mhItemText')"/>
      <el-table-column prop="mhWcName" label="工作中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mhWcName')"/>
      <el-table-column prop="mhWcText" label="工作中心文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mhWcText')"/>
      <el-table-column prop="mhStdShort" label="标准点数" align="center" v-if="columns.showColumn('mhStdShort')"/>
      <el-table-column prop="mhShortUnit" label="Short单位" align="center" v-if="columns.showColumn('mhShortUnit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.mhShortUnit" />
        </template>
      </el-table-column>
      <el-table-column prop="mhToMinRate" label="点数换算汇率" align="center" v-if="columns.showColumn('mhToMinRate')"/>
      <el-table-column prop="mhStdTime" label="标准工时" align="center" v-if="columns.showColumn('mhStdTime')"/>
      <el-table-column prop="mhTimeUnit" label="工时单位" align="center" v-if="columns.showColumn('mhTimeUnit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.mhTimeUnit" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:manhours:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:manhours:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改标准工时对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="mhId">
              <el-input-number clearable v-model.number="form.mhId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生效日期" prop="mhEffDate">
              <el-date-picker clearable v-model="form.mhEffDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mhPlant">
              <el-select v-model="form.mhPlant" filterable clearable  :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="mhModelType">
              <el-select v-model="form.mhModelType" filterable clearable  :placeholder="$t('btn.select')+'机种名'">
                <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向别" prop="mhRegionType">
              <el-select v-model="form.mhRegionType" filterable clearable  :placeholder="$t('btn.select')+'仕向别'">
                <el-option v-for="item in  options.sql_region_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mhItem">
              <el-select v-model="form.mhItem" filterable clearable  :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="mhItemText">
              <el-input clearable v-model="form.mhItemText" :placeholder="$t('btn.enter')+'物料文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工作中心" prop="mhWcName">
              <el-input clearable v-model="form.mhWcName" :placeholder="$t('btn.enter')+'工作中心'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工作中心文本" prop="mhWcText">
              <el-input clearable v-model="form.mhWcText" :placeholder="$t('btn.enter')+'工作中心文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准点数" prop="mhStdShort">
              <el-input-number clearable v-model.number="form.mhStdShort" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'标准点数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Short单位" prop="mhShortUnit">
              <el-select v-model="form.mhShortUnit" filterable clearable  :placeholder="$t('btn.select')+'Short单位'">
                <el-option v-for="item in  options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="点数换算汇率" prop="mhToMinRate">
              <el-input clearable v-model="form.mhToMinRate" :placeholder="$t('btn.enter')+'点数换算汇率'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准工时" prop="mhStdTime">
              <el-input-number clearable v-model.number="form.mhStdTime" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'标准工时'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时单位" prop="mhTimeUnit">
              <el-select v-model="form.mhTimeUnit" filterable clearable  :placeholder="$t('btn.select')+'工时单位'">
                <el-option v-for="item in  options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input clearable v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="remark" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'remark'" />
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

<script setup name="ppmanhours">
// 引入 ppmanhours操作方法
import { listPpManhours, addPpManhours, delPpManhours, updatePpManhours, getPpManhours, 
 
 } 
from '@/api/production/ppmanhours.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中mhId数组数组
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
  mhEffDate: undefined,
  mhPlant: undefined,
  mhModelType: undefined,
  mhRegionType: undefined,
  mhItem: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'mhId', label: 'ID' },
  { visible: true, prop: 'mhEffDate', label: '生效日期' },
  { visible: true, prop: 'mhPlant', label: '工厂' },
  { visible: true, prop: 'mhModelType', label: '机种名' },
  { visible: true, prop: 'mhRegionType', label: '仕向别' },
  { visible: true, prop: 'mhItem', label: '物料' },
  { visible: true, prop: 'mhItemText', label: '物料文本' },
  { visible: true, prop: 'mhWcName', label: '工作中心' },
  { visible: false, prop: 'mhWcText', label: '工作中心文本' },
  { visible: false, prop: 'mhStdShort', label: '标准点数' },
  { visible: false, prop: 'mhShortUnit', label: 'Short单位' },
  { visible: false, prop: 'mhToMinRate', label: '点数换算汇率' },
  { visible: false, prop: 'mhStdTime', label: '标准工时' },
  { visible: false, prop: 'mhTimeUnit', label: '工时单位' },
  { visible: false, prop: 'remark', label: '' },
])
  // 总条数
const total = ref(0)
  // 标准工时表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 生效日期时间范围
const dateRangeMhEffDate = ref([])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_moc_model" },
  { dictType: "sql_region_list" },
  { dictType: "sql_moc_item" },
  { dictType: "sys_unit_list" },
  { dictType: "sys_unit_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取标准工时表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMhEffDate.value, 'MhEffDate');
  loading.value = true
  listPpManhours(queryParams).then(res => {
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
  // 生效日期时间范围
  dateRangeMhEffDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.mhId);
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
    mhPlant: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    mhModelType: [{ required: true, message: "机种名"+proxy.$t('btn.empty'), trigger: "change" }],
    mhWcName: [{ required: true, message: "工作中心"+proxy.$t('btn.empty'), trigger: "blur" }],
    mhStdShort: [{ required: true, message: "标准点数"+proxy.$t('btn.empty'), trigger: "blur" }],
    mhToMinRate: [{ required: true, message: "点数换算汇率"+proxy.$t('btn.empty'), trigger: "blur" }],
    mhStdTime: [{ required: true, message: "标准工时"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 机种名 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_model: [],
    // 仕向别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_region_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
    // Short单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_unit_list: [],
    // 工时单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_unit_list: [],
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
    mhEffDate: undefined,
    mhPlant: undefined,
    mhModelType: undefined,
    mhRegionType: undefined,
    mhItem: undefined,
    mhItemText: undefined,
    mhWcName: undefined,
    mhWcText: undefined,
    mhStdShort: undefined,
    mhShortUnit: undefined,
    mhToMinRate: undefined,
    mhStdTime: undefined,
    mhTimeUnit: undefined,
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
  const id = row.mhId || ids.value
  getPpManhours(id).then((res) => {
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
      if (form.value.mhId != undefined && opertype.value === 2) {
        updatePpManhours(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpManhours(form.value).then((res) => {
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
  const Ids = row.mhId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpManhours(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"标准工时", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpManhours/export', { ...queryParams })
    })
}

handleQuery()
</script>