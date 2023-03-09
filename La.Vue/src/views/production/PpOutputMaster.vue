<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="生产工单" prop="pomOrder">
        <el-select filterable clearable  v-model="queryParams.pomOrder" :placeholder="$t('btn.select')+'生产工单'">
          <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产批次" prop="pomMflot">
        <el-select filterable clearable  v-model="queryParams.pomMflot" :placeholder="$t('btn.select')+'生产批次'">
          <el-option v-for="item in  options.sql_lot_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种名" prop="pomModelName">
        <el-select filterable clearable  v-model="queryParams.pomModelName" :placeholder="$t('btn.select')+'机种名'">
          <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="pomMfItem">
        <el-select filterable clearable  v-model="queryParams.pomMfItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker 
          v-model="dateRangePomMfDate" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'生产日期'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产班组" prop="pomLineName">
        <el-select filterable clearable  v-model="queryParams.pomLineName" :placeholder="$t('btn.select')+'生产班组'">
          <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['pp:outputmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputmaster:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputmaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputmaster:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="pomId" label="ID" align="center" v-if="columns.showColumn('pomId')"/>
      <el-table-column prop="pomGuid" label="GUID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomGuid')"/>
      <el-table-column prop="pomOrder" label="生产工单" align="center" v-if="columns.showColumn('pomOrder')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_list " :value="scope.row.pomOrder" />
        </template>
      </el-table-column>
      <el-table-column prop="pomOrderQty" label="工单数量" align="center" v-if="columns.showColumn('pomOrderQty')"/>
      <el-table-column prop="pomOrderSerial" label="管理序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomOrderSerial')"/>
      <el-table-column prop="pomMflot" label="生产批次" align="center" v-if="columns.showColumn('pomMflot')">
        <template #default="scope">
          <dict-tag :options=" options.sql_lot_list " :value="scope.row.pomMflot" />
        </template>
      </el-table-column>
      <el-table-column prop="pomModelName" label="机种名" align="center" v-if="columns.showColumn('pomModelName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_model " :value="scope.row.pomModelName" />
        </template>
      </el-table-column>
      <el-table-column prop="pomMfItem" label="物料" align="center" v-if="columns.showColumn('pomMfItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.pomMfItem" />
        </template>
      </el-table-column>
      <el-table-column prop="pomMfDate" label="生产日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomMfDate')"/>
      <el-table-column prop="pomLineName" label="生产班组" align="center" v-if="columns.showColumn('pomLineName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.pomLineName" />
        </template>
      </el-table-column>
      <el-table-column prop="pomDirect" label="直接人数" align="center" v-if="columns.showColumn('pomDirect')"/>
      <el-table-column prop="pomIndirect" label="间接人数" align="center" v-if="columns.showColumn('pomIndirect')"/>
      <el-table-column prop="pomStdTime" label="标准工时" align="center" v-if="columns.showColumn('pomStdTime')"/>
      <el-table-column prop="pomStdOutput" label="标准产能" align="center" v-if="columns.showColumn('pomStdOutput')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:outputmaster:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputmaster:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改oph主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="pomId">
              <el-input-number clearable v-model.number="form.pomId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="GUID" prop="pomGuid">
              <el-input clearable v-model="form.pomGuid" :placeholder="$t('btn.enter')+'GUID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产工单" prop="pomOrder">
              <el-select v-model="form.pomOrder" filterable clearable  :placeholder="$t('btn.select')+'生产工单'">
                <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单数量" prop="pomOrderQty">
              <el-input clearable v-model="form.pomOrderQty" :placeholder="$t('btn.enter')+'工单数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="管理序列号" prop="pomOrderSerial">
              <el-input clearable v-model="form.pomOrderSerial" :placeholder="$t('btn.enter')+'管理序列号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="pomMflot">
              <el-select v-model="form.pomMflot" filterable clearable  :placeholder="$t('btn.select')+'生产批次'">
                <el-option v-for="item in  options.sql_lot_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="pomModelName">
              <el-select v-model="form.pomModelName" filterable clearable  :placeholder="$t('btn.select')+'机种名'">
                <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="pomMfItem">
              <el-select v-model="form.pomMfItem" filterable clearable  :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="pomMfDate">
              <el-date-picker clearable v-model="form.pomMfDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="pomLineName">
              <el-select v-model="form.pomLineName" filterable clearable  :placeholder="$t('btn.select')+'生产班组'">
                <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="直接人数" prop="pomDirect">
              <el-input clearable v-model="form.pomDirect" :placeholder="$t('btn.enter')+'直接人数'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="pomIndirect">
              <el-input clearable v-model="form.pomIndirect" :placeholder="$t('btn.enter')+'间接人数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准工时" prop="pomStdTime">
              <el-input clearable v-model="form.pomStdTime" :placeholder="$t('btn.enter')+'标准工时'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准产能" prop="pomStdOutput">
              <el-input clearable v-model="form.pomStdOutput" :placeholder="$t('btn.enter')+'标准产能'" />
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
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'uDF54'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'uDF55'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'uDF56'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="reMark">
              <el-input clearable v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'"  :disabled="true"/>
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

<script setup name="ppoutputmaster">
// 引入 ppoutputmaster操作方法
import { listPpOutputMaster, addPpOutputMaster, delPpOutputMaster, updatePpOutputMaster, getPpOutputMaster, 
 
 } 
from '@/api/production/ppoutputmaster.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中pomId数组数组
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
  pomOrder: undefined,
  pomMflot: undefined,
  pomModelName: undefined,
  pomMfItem: undefined,
  pomMfDate: undefined,
  pomLineName: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'pomId', label: 'ID' },
  { visible: true, prop: 'pomGuid', label: 'GUID' },
  { visible: true, prop: 'pomOrder', label: '生产工单' },
  { visible: true, prop: 'pomOrderQty', label: '工单数量' },
  { visible: true, prop: 'pomOrderSerial', label: '管理序列号' },
  { visible: true, prop: 'pomMflot', label: '生产批次' },
  { visible: true, prop: 'pomModelName', label: '机种名' },
  { visible: true, prop: 'pomMfItem', label: '物料' },
  { visible: false, prop: 'pomMfDate', label: '生产日期' },
  { visible: false, prop: 'pomLineName', label: '生产班组' },
  { visible: false, prop: 'pomDirect', label: '直接人数' },
  { visible: false, prop: 'pomIndirect', label: '间接人数' },
  { visible: false, prop: 'pomStdTime', label: '标准工时' },
  { visible: false, prop: 'pomStdOutput', label: '标准产能' },
])
  // 总条数
const total = ref(0)
  // oph主表表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 生产日期时间范围
const dateRangePomMfDate = ref([])


var dictParams = [
  { dictType: "sql_moc_list" },
  { dictType: "sql_lot_list" },
  { dictType: "sql_moc_model" },
  { dictType: "sql_moc_item" },
  { dictType: "sql_line_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取oph主表表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangePomMfDate.value, 'PomMfDate');
  loading.value = true
  listPpOutputMaster(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangePomMfDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.pomId);
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
    pomGuid: [{ required: true, message: "GUID"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomOrder: [{ required: true, message: "生产工单"+proxy.$t('btn.empty'), trigger: "change" }],
    pomOrderQty: [{ required: true, message: "工单数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomOrderSerial: [{ required: true, message: "管理序列号"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomMflot: [{ required: true, message: "生产批次"+proxy.$t('btn.empty'), trigger: "change" }],
    pomModelName: [{ required: true, message: "机种名"+proxy.$t('btn.empty'), trigger: "change" }],
    pomMfItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "change" }],
    pomMfDate: [{ required: true, message: "生产日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomLineName: [{ required: true, message: "生产班组"+proxy.$t('btn.empty'), trigger: "change" }],
    pomDirect: [{ required: true, message: "直接人数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    pomIndirect: [{ required: true, message: "间接人数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    pomStdTime: [{ required: true, message: "标准工时"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomStdOutput: [{ required: true, message: "标准产能"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF54: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF55: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF56: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 生产工单 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_list: [],
    // 生产批次 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_lot_list: [],
    // 机种名 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_model: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
    // 生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_line_list: [],
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
    pomOrder: undefined,
    pomOrderQty: undefined,
    pomOrderSerial: undefined,
    pomMflot: undefined,
    pomModelName: undefined,
    pomMfItem: undefined,
    pomMfDate: undefined,
    pomLineName: undefined,
    pomDirect: undefined,
    pomIndirect: undefined,
    pomStdTime: undefined,
    pomStdOutput: undefined,
    uDF54: undefined,
    uDF55: undefined,
    uDF56: undefined,
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
  const id = row.pomId || ids.value
  getPpOutputMaster(id).then((res) => {
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
      if (form.value.pomId != undefined && opertype.value === 2) {
        updatePpOutputMaster(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpOutputMaster(form.value).then((res) => {
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
  const Ids = row.pomId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpOutputMaster(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"oph主表", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpOutputMaster/export', { ...queryParams })
    })
}

handleQuery()
</script>