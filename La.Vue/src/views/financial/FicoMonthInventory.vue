<!--
 * @Descripttion: (月度存货明细/fico_month_inventory)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-16)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-16)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="miPlant">
        <el-select clearable  v-model="queryParams.miPlant" placeholder="请选择工厂">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="miFy">
        <el-select clearable  v-model="queryParams.miFy" placeholder="请选择期间">
          <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="miYm">
        <el-select clearable  v-model="queryParams.miYm" placeholder="请选择年月">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="miItem">
        <el-select clearable  v-model="queryParams.miItem" placeholder="请选择物料">
          <el-option v-for="item in  options.sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="miValType">
        <el-select clearable  v-model="queryParams.miValType" placeholder="请选择评估类">
          <el-option v-for="item in  options.sys_fin_val " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="miLocalCcy">
        <el-select clearable  v-model="queryParams.miLocalCcy" placeholder="请选择币种">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['fico:monthinventory:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:monthinventory:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:monthinventory:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:monthinventory:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="miId" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miId')"/>
      <el-table-column prop="miPlant" label="工厂" align="center" v-if="columns.showColumn('miPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.miPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="miFy" label="期间" align="center" v-if="columns.showColumn('miFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.miFy" />
        </template>
      </el-table-column>
      <el-table-column prop="miYm" label="年月" align="center" v-if="columns.showColumn('miYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.miYm" />
        </template>
      </el-table-column>
      <el-table-column prop="miItem" label="物料" align="center" v-if="columns.showColumn('miItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.miItem" />
        </template>
      </el-table-column>
      <el-table-column prop="miValType" label="评估类" align="center" v-if="columns.showColumn('miValType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_fin_val " :value="scope.row.miValType" />
        </template>
      </el-table-column>
      <el-table-column prop="miPriceControl" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miPriceControl')"/>
      <el-table-column prop="miMovingAverage" label="移动平均价" align="center" v-if="columns.showColumn('miMovingAverage')"/>
      <el-table-column prop="miPerUnit" label="Per单位" align="center" v-if="columns.showColumn('miPerUnit')"/>
      <el-table-column prop="miLocalCcy" label="币种" align="center" v-if="columns.showColumn('miLocalCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.miLocalCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="miInventoryQty" label="库存" align="center" v-if="columns.showColumn('miInventoryQty')"/>
      <el-table-column prop="miInventoryAmount" label="金额" align="center" v-if="columns.showColumn('miInventoryAmount')"/>
      <el-table-column prop="miBalancedate" label="登录日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miBalancedate')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:monthinventory:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:monthinventory:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改月度存货明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="miId">
              <el-input v-model="form.miId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂" prop="miPlant">
              <el-select v-model="form.miPlant" :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="miFy">
              <el-select v-model="form.miFy" :placeholder="$t('btn.select')+'期间'">
                <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="miYm">
              <el-select v-model="form.miYm" :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="miItem">
              <el-select v-model="form.miItem" :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="miValType">
              <el-select v-model="form.miValType" :placeholder="$t('btn.select')+'评估类'">
                <el-option v-for="item in  options.sys_fin_val " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制" prop="miPriceControl">
              <el-input v-model="form.miPriceControl" :placeholder="$t('btn.enter')+'价格控制'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动平均价" prop="miMovingAverage">
              <el-input v-model="form.miMovingAverage" :placeholder="$t('btn.enter')+'移动平均价'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="Per单位" prop="miPerUnit">
              <el-input v-model="form.miPerUnit" :placeholder="$t('btn.enter')+'Per单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="miLocalCcy">
              <el-select v-model="form.miLocalCcy" :placeholder="$t('btn.select')+'币种'">
                <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存" prop="miInventoryQty">
              <el-input v-model="form.miInventoryQty" :placeholder="$t('btn.enter')+'库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="miInventoryAmount">
              <el-input v-model="form.miInventoryAmount" :placeholder="$t('btn.enter')+'金额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="miBalancedate">
              <el-date-picker v-model="form.miBalancedate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enter')+'说明'" />
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

<script setup name="ficomonthinventory">
// 引入 ficomonthinventory操作方法
import { listFicoMonthInventory, addFicoMonthInventory, delFicoMonthInventory, updateFicoMonthInventory, getFicoMonthInventory, 
 
 } 
from '@/api/financial/ficomonthinventory.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中miId数组数组
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
  miPlant: undefined,
  miFy: undefined,
  miYm: undefined,
  miItem: undefined,
  miValType: undefined,
  miLocalCcy: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'miId', label: 'ID' },
  { visible: true, prop: 'miPlant', label: '工厂' },
  { visible: true, prop: 'miFy', label: '期间' },
  { visible: true, prop: 'miYm', label: '年月' },
  { visible: true, prop: 'miItem', label: '物料' },
  { visible: true, prop: 'miValType', label: '评估类' },
  { visible: true, prop: 'miPriceControl', label: '价格控制' },
  { visible: true, prop: 'miMovingAverage', label: '移动平均价' },
  { visible: false, prop: 'miPerUnit', label: 'Per单位' },
  { visible: false, prop: 'miLocalCcy', label: '币种' },
  { visible: false, prop: 'miInventoryQty', label: '库存' },
  { visible: false, prop: 'miInventoryAmount', label: '金额' },
  { visible: false, prop: 'miBalancedate', label: '登录日期' },
  { visible: false, prop: 'remark', label: '说明' },
])
  // 总条数
const total = ref(0)
  // 月度存货明细表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_period_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sql_mats_list" },
  { dictType: "sys_fin_val" },
  { dictType: "sys_ccy_type" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取月度存货明细表记录数据
function getList(){
  loading.value = true
  listFicoMonthInventory(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.miId);
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
    miId: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    miPlant: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    miFy: [{ required: true, message: "期间"+proxy.$t('btn.empty'), trigger: "change" }],
    miYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "change" }],
    miItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "change" }],
    miValType: [{ required: true, message: "评估类"+proxy.$t('btn.empty'), trigger: "change" }],
    miPriceControl: [{ required: true, message: "价格控制"+proxy.$t('btn.empty'), trigger: "blur" }],
    miMovingAverage: [{ required: true, message: "移动平均价"+proxy.$t('btn.empty'), trigger: "blur" }],
    miPerUnit: [{ required: true, message: "Per单位"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    miLocalCcy: [{ required: true, message: "币种"+proxy.$t('btn.empty'), trigger: "change" }],
    miInventoryQty: [{ required: true, message: "库存"+proxy.$t('btn.empty'), trigger: "blur" }],
    miInventoryAmount: [{ required: true, message: "金额"+proxy.$t('btn.empty'), trigger: "blur" }],
    miBalancedate: [{ required: true, message: "登录日期"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_period_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ym_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_mats_list: [],
    // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_fin_val: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ccy_type: [],
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
    miId: undefined,
    miPlant: undefined,
    miFy: undefined,
    miYm: undefined,
    miItem: undefined,
    miValType: undefined,
    miPriceControl: undefined,
    miMovingAverage: undefined,
    miPerUnit: undefined,
    miLocalCcy: undefined,
    miInventoryQty: undefined,
    miInventoryAmount: undefined,
    miBalancedate: undefined,
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
  const id = row.miId || ids.value
  getFicoMonthInventory(id).then((res) => {
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
      if (form.value.miId != undefined && opertype.value === 2) {
        updateFicoMonthInventory(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoMonthInventory(form.value).then((res) => {
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
  const Ids = row.miId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoMonthInventory(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"月度存货明细", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/financial/FicoMonthInventory/export', { ...queryParams })
    })
}

handleQuery()
</script>