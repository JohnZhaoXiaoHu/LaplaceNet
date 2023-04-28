<!--
 * @Descripttion: (新旧物料/pp_ec_digest)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-26)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-26)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="设变发行日">
        <el-date-picker 
          v-model="dateRangeEdIssueDate" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'设变发行日'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="机种" prop="edModel">
        <el-select filterable clearable  v-model="queryParams.edModel" :placeholder="$t('btn.select')+'机种'">
          <el-option v-for="item in  options.sql_region_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="editem">
        <el-select filterable clearable  v-model="queryParams.editem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="设变号" prop="edEcNo">
        <el-input clearable v-model="queryParams.edEcNo" :placeholder="$t('btn.enter')+'设变号'" />
      </el-form-item>
      <el-form-item label="旧物料" prop="edOldItem">
        <el-select filterable clearable  v-model="queryParams.edOldItem" :placeholder="$t('btn.select')+'旧物料'">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="新物料" prop="edNewItem">
        <el-select filterable clearable  v-model="queryParams.edNewItem" :placeholder="$t('btn.select')+'新物料'">
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
        <el-button type="primary" v-hasPermi="['la:ppecdigest:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:ppecdigest:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:ppecdigest:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['la:ppecdigest:delete']" plain icon="delete" @click="handleClear">
         {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['la:ppecdigest:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:ppecdigest:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="edId" label="ID" align="center" v-if="columns.showColumn('edId')"/>
      <el-table-column prop="edBalanceDate" label="输入日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('edBalanceDate')"/>
      <el-table-column prop="edIssueDate" label="设变发行日" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('edIssueDate')"/>
      <el-table-column prop="edModel" label="机种" align="center" v-if="columns.showColumn('edModel')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_list " :value="scope.row.edModel" />
        </template>
      </el-table-column>
      <el-table-column prop="editem" label="物料" align="center" v-if="columns.showColumn('editem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.editem" />
        </template>
      </el-table-column>
      <el-table-column prop="edEcNo" label="设变号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('edEcNo')"/>
      <el-table-column prop="edOldItem" label="旧物料" align="center" v-if="columns.showColumn('edOldItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.edOldItem" />
        </template>
      </el-table-column>
      <el-table-column prop="edOldQty" label="旧库存" align="center" v-if="columns.showColumn('edOldQty')"/>
      <el-table-column prop="edPoQty" label="PO数量" align="center" v-if="columns.showColumn('edPoQty')"/>
      <el-table-column prop="edBalanceQty" label="结算数量" align="center" v-if="columns.showColumn('edBalanceQty')"/>
      <el-table-column prop="edNewItem" label="新物料" align="center" v-if="columns.showColumn('edNewItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.edNewItem" />
        </template>
      </el-table-column>
      <el-table-column prop="edNewQty" label="新库存" align="center" v-if="columns.showColumn('edNewQty')"/>
      <el-table-column prop="edDisposal" label="处理方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('edDisposal')"/>
      <el-table-column prop="edNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('edNote')"/>
      <el-table-column prop="edStatus" label="设变状态" align="center" v-if="columns.showColumn('edStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.edStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['la:ppecdigest:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:ppecdigest:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改新旧物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="edId">
              <el-input-number clearable v-model.number="form.edId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="输入日期" prop="edBalanceDate">
              <el-date-picker clearable v-model="form.edBalanceDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变发行日" prop="edIssueDate">
              <el-date-picker clearable v-model="form.edIssueDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="edModel">
              <el-select v-model="form.edModel" filterable clearable  :placeholder="$t('btn.select')+'机种'">
                <el-option v-for="item in  options.sql_region_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="editem">
              <el-select v-model="form.editem" filterable clearable  :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变号" prop="edEcNo">
              <el-input clearable v-model="form.edEcNo" :placeholder="$t('btn.enter')+'设变号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="edOldItem">
              <el-select v-model="form.edOldItem" filterable clearable  :placeholder="$t('btn.select')+'旧物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧库存" prop="edOldQty">
              <el-input clearable v-model="form.edOldQty" :placeholder="$t('btn.enter')+'旧库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PO数量" prop="edPoQty">
              <el-input clearable v-model="form.edPoQty" :placeholder="$t('btn.enter')+'PO数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="结算数量" prop="edBalanceQty">
              <el-input clearable v-model="form.edBalanceQty" :placeholder="$t('btn.enter')+'结算数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="edNewItem">
              <el-select v-model="form.edNewItem" filterable clearable  :placeholder="$t('btn.select')+'新物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新库存" prop="edNewQty">
              <el-input clearable v-model="form.edNewQty" :placeholder="$t('btn.enter')+'新库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理方法" prop="edDisposal">
              <el-input clearable v-model="form.edDisposal" :placeholder="$t('btn.enter')+'处理方法'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="edNote">
              <el-input clearable v-model="form.edNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变状态" prop="edStatus">
              <el-radio-group v-model="form.edStatus">
                <el-radio v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'UDF01'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'UDF02'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'UDF03'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'UDF04'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'UDF05'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'UDF06'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'UDF51'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'UDF52'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'UDF53'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'UDF54'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'UDF55'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'UDF56'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted" :disabled="true">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'" :disabled="true"/>
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

<script setup name="ppecdigest">
// 引入 ppecdigest操作方法
import { listPpEcDigest, addPpEcDigest, delPpEcDigest, updatePpEcDigest, getPpEcDigest, 
 clearPpEcDigest,  
 } 
from '@/api/production/ppecdigest.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中edId数组数组
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
  edIssueDate: undefined,
  edModel: undefined,
  editem: undefined,
  edEcNo: undefined,
  edOldItem: undefined,
  edNewItem: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'edId', label: 'ID' },
  { visible: true, prop: 'edBalanceDate', label: '输入日期' },
  { visible: true, prop: 'edIssueDate', label: '设变发行日' },
  { visible: true, prop: 'edModel', label: '机种' },
  { visible: true, prop: 'editem', label: '物料' },
  { visible: true, prop: 'edEcNo', label: '设变号' },
  { visible: true, prop: 'edOldItem', label: '旧物料' },
  { visible: true, prop: 'edOldQty', label: '旧库存' },
  { visible: false, prop: 'edPoQty', label: 'PO数量' },
  { visible: false, prop: 'edBalanceQty', label: '结算数量' },
  { visible: false, prop: 'edNewItem', label: '新物料' },
  { visible: false, prop: 'edNewQty', label: '新库存' },
  { visible: false, prop: 'edDisposal', label: '处理方法' },
  { visible: false, prop: 'edNote', label: '说明' },
  { visible: false, prop: 'edStatus', label: '设变状态' },
])
  // 总条数
const total = ref(0)
  // 新旧物料表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 设变发行日时间范围
const dateRangeEdIssueDate = ref([])


var dictParams = [
  { dictType: "sql_region_list" },
  { dictType: "sql_moc_item" },
  { dictType: "sql_moc_item" },
  { dictType: "sql_moc_item" },
  { dictType: "sys_ec_status" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取新旧物料表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEdIssueDate.value, 'EdIssueDate');
  loading.value = true
  listPpEcDigest(queryParams).then(res => {
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
  // 设变发行日时间范围
  dateRangeEdIssueDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.edId);
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
    edOldQty: [{ required: true, message: "旧库存"+proxy.$t('btn.empty'), trigger: "blur" }],
    edPoQty: [{ required: true, message: "PO数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    edBalanceQty: [{ required: true, message: "结算数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    edNewQty: [{ required: true, message: "新库存"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 机种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_region_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
    // 旧物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
    // 新物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
    // 设变状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_status: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isDeletedOptions: [],
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
    edBalanceDate: undefined,
    edIssueDate: undefined,
    edModel: undefined,
    editem: undefined,
    edEcNo: undefined,
    edOldItem: undefined,
    edOldQty: undefined,
    edPoQty: undefined,
    edBalanceQty: undefined,
    edNewItem: undefined,
    edNewQty: undefined,
    edDisposal: undefined,
    edNote: undefined,
    edStatus: undefined,
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
  const id = row.edId || ids.value
  getPpEcDigest(id).then((res) => {
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
      if (form.value.edId != undefined && opertype.value === 2) {
        updatePpEcDigest(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpEcDigest(form.value).then((res) => {
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
  const Ids = row.edId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpEcDigest(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}

// 清空
function handleClear() {
  proxy
    .$confirm(proxy.$t('common.confirmClean'), proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText:proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return clearPpEcDigest()
    })
    .then(() => {
      handleQuery()
      proxy.$modal.msgSuccess(proxy.$t('common.Cleancompleted'))
    })
}

/**
 * 查看
 * @param {*} row
 */
function handlePreview(row) {
  reset()
  open.value = true
  title.value =  proxy.$t('btn.preview')
  opertype.value = 3
  form.value = row
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"新旧物料", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Production/PpEcDigest/export', { ...queryParams })
    })
}

handleQuery()
</script>