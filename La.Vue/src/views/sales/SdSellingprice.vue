<!--
 * @Descripttion: (销售价格/sd_sellingprice)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="spPlnt">
        <el-select filterable clearable  v-model="queryParams.spPlnt" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="spYm">
        <el-select filterable clearable  v-model="queryParams.spYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="spItem">
        <el-select filterable clearable  v-model="queryParams.spItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料文本" prop="spItemText">
        <el-input clearable v-model="queryParams.spItemText" :placeholder="$t('btn.enter')+'物料文本'" />
      </el-form-item>
      <el-form-item label="生效日期">
        <el-date-picker 
          v-model="dateRangeSpEffDate" 
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
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['sd:sellingprice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sd:sellingprice:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sd:sellingprice:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['sd:sellingprice:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="spId" label="ID" align="center" v-if="columns.showColumn('spId')"/>
      <el-table-column prop="spPlnt" label="工厂" align="center" v-if="columns.showColumn('spPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.spPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="spFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spFy')"/>
      <el-table-column prop="spYm" label="年月" align="center" v-if="columns.showColumn('spYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.spYm" />
        </template>
      </el-table-column>
      <el-table-column prop="spItem" label="物料" align="center" v-if="columns.showColumn('spItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.spItem" />
        </template>
      </el-table-column>
      <el-table-column prop="spItemText" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spItemText')"/>
      <el-table-column prop="spOriginalFob" label="原币价格" align="center" v-if="columns.showColumn('spOriginalFob')"/>
      <el-table-column prop="spOriginalCcy" label="原币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spOriginalCcy')"/>
      <el-table-column prop="spOriginalPerUnit" label="原币Per单位" align="center" v-if="columns.showColumn('spOriginalPerUnit')"/>
      <el-table-column prop="spOriginalPrctr" label="原币利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spOriginalPrctr')"/>
      <el-table-column prop="spLocalFob" label="本币价格" align="center" v-if="columns.showColumn('spLocalFob')"/>
      <el-table-column prop="spLocalCcy" label="本币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spLocalCcy')"/>
      <el-table-column prop="spLocalPerUnit" label="本币Per单位" align="center" v-if="columns.showColumn('spLocalPerUnit')"/>
      <el-table-column prop="spLocalPrctr" label="本币利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spLocalPrctr')"/>
      <el-table-column prop="spEffDate" label="生效日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spEffDate')"/>
      <el-table-column prop="spExpDate" label="失效日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spExpDate')"/>
      <el-table-column prop="spBalancedate" label="登录日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spBalancedate')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['sd:sellingprice:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sd:sellingprice:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改销售价格对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="spId">
              <el-input-number clearable v-model.number="form.spId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂" prop="spPlnt">
              <el-select v-model="form.spPlnt" filterable clearable  :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="spFy">
              <el-input clearable v-model="form.spFy" :placeholder="$t('btn.enter')+'期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="spYm">
              <el-select v-model="form.spYm" filterable clearable  :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="spItem">
              <el-select v-model="form.spItem" filterable clearable  :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="spItemText">
              <el-input clearable v-model="form.spItemText" :placeholder="$t('btn.enter')+'物料文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币价格" prop="spOriginalFob">
              <el-input clearable v-model="form.spOriginalFob" :placeholder="$t('btn.enter')+'原币价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币种" prop="spOriginalCcy">
              <el-input clearable v-model="form.spOriginalCcy" :placeholder="$t('btn.enter')+'原币种'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="原币Per单位" prop="spOriginalPerUnit">
              <el-input clearable v-model="form.spOriginalPerUnit" :placeholder="$t('btn.enter')+'原币Per单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币利润中心" prop="spOriginalPrctr">
              <el-input clearable v-model="form.spOriginalPrctr" :placeholder="$t('btn.enter')+'原币利润中心'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币价格" prop="spLocalFob">
              <el-input clearable v-model="form.spLocalFob" :placeholder="$t('btn.enter')+'本币价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币种" prop="spLocalCcy">
              <el-input clearable v-model="form.spLocalCcy" :placeholder="$t('btn.enter')+'本币种'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="本币Per单位" prop="spLocalPerUnit">
              <el-input clearable v-model="form.spLocalPerUnit" :placeholder="$t('btn.enter')+'本币Per单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币利润中心" prop="spLocalPrctr">
              <el-input clearable v-model="form.spLocalPrctr" :placeholder="$t('btn.enter')+'本币利润中心'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生效日期" prop="spEffDate">
              <el-date-picker clearable v-model="form.spEffDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="失效日期" prop="spExpDate">
              <el-date-picker clearable v-model="form.spExpDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="spBalancedate">
              <el-date-picker clearable v-model="form.spBalancedate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"  :disabled="true"/>
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

<script setup name="sdsellingprice">
// 引入 sdsellingprice操作方法
import { listSdSellingprice, addSdSellingprice, delSdSellingprice, updateSdSellingprice, getSdSellingprice, 
 
 } 
from '@/api/sales/sdsellingprice.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中spId数组数组
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
  spPlnt: undefined,
  spYm: undefined,
  spItem: undefined,
  spItemText: undefined,
  spEffDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'spId', label: 'ID' },
  { visible: true, prop: 'spPlnt', label: '工厂' },
  { visible: true, prop: 'spFy', label: '期间' },
  { visible: true, prop: 'spYm', label: '年月' },
  { visible: true, prop: 'spItem', label: '物料' },
  { visible: true, prop: 'spItemText', label: '物料文本' },
  { visible: true, prop: 'spOriginalFob', label: '原币价格' },
  { visible: true, prop: 'spOriginalCcy', label: '原币种' },
  { visible: false, prop: 'spOriginalPerUnit', label: '原币Per单位' },
  { visible: false, prop: 'spOriginalPrctr', label: '原币利润中心' },
  { visible: false, prop: 'spLocalFob', label: '本币价格' },
  { visible: false, prop: 'spLocalCcy', label: '本币种' },
  { visible: false, prop: 'spLocalPerUnit', label: '本币Per单位' },
  { visible: false, prop: 'spLocalPrctr', label: '本币利润中心' },
  { visible: false, prop: 'spEffDate', label: '生效日期' },
  { visible: false, prop: 'spExpDate', label: '失效日期' },
  { visible: false, prop: 'spBalancedate', label: '登录日期' },
])
  // 总条数
const total = ref(0)
  // 销售价格表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 生效日期时间范围
const dateRangeSpEffDate = ref([])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sql_moc_item" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取销售价格表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeSpEffDate.value, 'SpEffDate');
  loading.value = true
  listSdSellingprice(queryParams).then(res => {
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
  dateRangeSpEffDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.spId);
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
    spPlnt: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    spFy: [{ required: true, message: "期间"+proxy.$t('btn.empty'), trigger: "blur" }],
    spYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "change" }],
    spItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "change" }],
    spItemText: [{ required: true, message: "物料文本"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalFob: [{ required: true, message: "原币价格"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalCcy: [{ required: true, message: "原币种"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalPerUnit: [{ required: true, message: "原币Per单位"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    spOriginalPrctr: [{ required: true, message: "原币利润中心"+proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalFob: [{ required: true, message: "本币价格"+proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalCcy: [{ required: true, message: "本币种"+proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalPerUnit: [{ required: true, message: "本币Per单位"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    spLocalPrctr: [{ required: true, message: "本币利润中心"+proxy.$t('btn.empty'), trigger: "blur" }],
    spEffDate: [{ required: true, message: "生效日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    spExpDate: [{ required: true, message: "失效日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    spBalancedate: [{ required: true, message: "登录日期"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ym_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_moc_item: [],
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
    spPlnt: undefined,
    spFy: undefined,
    spYm: undefined,
    spItem: undefined,
    spItemText: undefined,
    spOriginalFob: undefined,
    spOriginalCcy: undefined,
    spOriginalPerUnit: undefined,
    spOriginalPrctr: undefined,
    spLocalFob: undefined,
    spLocalCcy: undefined,
    spLocalPerUnit: undefined,
    spLocalPrctr: undefined,
    spEffDate: undefined,
    spExpDate: undefined,
    spBalancedate: undefined,
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
  const id = row.spId || ids.value
  getSdSellingprice(id).then((res) => {
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
      if (form.value.spId != undefined && opertype.value === 2) {
        updateSdSellingprice(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addSdSellingprice(form.value).then((res) => {
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
  const Ids = row.spId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delSdSellingprice(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"销售价格", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/sales/SdSellingprice/export', { ...queryParams })
    })
}

handleQuery()
</script>