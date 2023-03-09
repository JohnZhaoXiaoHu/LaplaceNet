<!--
 * @Descripttion: (预算实际明细/fico_budgetactual_cost)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="期间" prop="fbFy">
        <el-select filterable clearable  v-model="queryParams.fbFy" :placeholder="$t('btn.select')+'期间'">
          <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="fbYm">
        <el-select filterable clearable  v-model="queryParams.fbYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="fbCorpCode">
        <el-select filterable clearable  v-model="queryParams.fbCorpCode" :placeholder="$t('btn.select')+'公司代码'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="统计类别" prop="fbExpCategory">
        <el-select filterable clearable  v-model="queryParams.fbExpCategory" :placeholder="$t('btn.select')+'统计类别'">
          <el-option v-for="item in  options.fbExpCategoryOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="成本代码" prop="fbCostCode">
        <el-select filterable clearable  v-model="queryParams.fbCostCode" :placeholder="$t('btn.select')+'成本代码'">
          <el-option v-for="item in  options.fbCostCodeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目代码" prop="fbTitleCode">
        <el-select filterable clearable  v-model="queryParams.fbTitleCode" :placeholder="$t('btn.select')+'科目代码'">
          <el-option v-for="item in  options.fbTitleCodeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目分类" prop="fbTitleNote">
        <el-select filterable clearable  v-model="queryParams.fbTitleNote" :placeholder="$t('btn.select')+'科目分类'">
          <el-option v-for="item in  options.fbTitleNoteOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['fico:budgetactualcost:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:budgetactualcost:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:budgetactualcost:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetactualcost:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="fbId" label="ID" align="center" v-if="columns.showColumn('fbId')"/>
      <el-table-column prop="fbFy" label="期间" align="center" v-if="columns.showColumn('fbFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.fbFy" />
        </template>
      </el-table-column>
      <el-table-column prop="fbYm" label="年月" align="center" v-if="columns.showColumn('fbYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.fbYm" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCorpCode" label="公司代码" align="center" v-if="columns.showColumn('fbCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fbCorpCode" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCorpName" label="公司名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbCorpName')"/>
      <el-table-column prop="fbExpCategory" label="统计类别" align="center" v-if="columns.showColumn('fbExpCategory')">
        <template #default="scope">
          <dict-tag :options=" options.fbExpCategoryOptions" :value="scope.row.fbExpCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCostCode" label="成本代码" align="center" v-if="columns.showColumn('fbCostCode')">
        <template #default="scope">
          <dict-tag :options=" options.fbCostCodeOptions" :value="scope.row.fbCostCode" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCostName" label="成本名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbCostName')"/>
      <el-table-column prop="fbTitleCode" label="科目代码" align="center" v-if="columns.showColumn('fbTitleCode')">
        <template #default="scope">
          <dict-tag :options=" options.fbTitleCodeOptions" :value="scope.row.fbTitleCode" />
        </template>
      </el-table-column>
      <el-table-column prop="fbTitleName" label="科目名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbTitleName')"/>
      <el-table-column prop="fbTitleNote" label="科目分类" align="center" v-if="columns.showColumn('fbTitleNote')">
        <template #default="scope">
          <dict-tag :options=" options.fbTitleNoteOptions" :value="scope.row.fbTitleNote" />
        </template>
      </el-table-column>
      <el-table-column prop="fbBudgetAmt" label="预算" align="center" v-if="columns.showColumn('fbBudgetAmt')"/>
      <el-table-column prop="fbActualAmt" label="实际" align="center" v-if="columns.showColumn('fbActualAmt')"/>
      <el-table-column prop="fbDiffAmt" label="差异" align="center" v-if="columns.showColumn('fbDiffAmt')"/>
      <el-table-column prop="fbAccountant" label="会计人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbAccountant')"/>
      <el-table-column prop="fbBalanceDate" label="日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbBalanceDate')"/>
      <el-table-column prop="reMark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:budgetactualcost:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:budgetactualcost:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改预算实际明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="fbId">
              <el-input-number clearable v-model.number="form.fbId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="期间" prop="fbFy">
              <el-select v-model="form.fbFy" filterable clearable  :placeholder="$t('btn.select')+'期间'">
                <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fbYm">
              <el-select v-model="form.fbYm" filterable clearable  :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="fbCorpCode">
              <el-select v-model="form.fbCorpCode" filterable clearable  :placeholder="$t('btn.select')+'公司代码'">
                <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司名称" prop="fbCorpName">
              <el-input clearable v-model="form.fbCorpName" :placeholder="$t('btn.enter')+'公司名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统计类别" prop="fbExpCategory">
              <el-select v-model="form.fbExpCategory" filterable clearable  :placeholder="$t('btn.select')+'统计类别'">
                <el-option v-for="item in  options.fbExpCategoryOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本代码" prop="fbCostCode">
              <el-select v-model="form.fbCostCode" filterable clearable  :placeholder="$t('btn.select')+'成本代码'">
                <el-option v-for="item in  options.fbCostCodeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本名称" prop="fbCostName">
              <el-input clearable v-model="form.fbCostName" :placeholder="$t('btn.enter')+'成本名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="fbTitleCode">
              <el-select v-model="form.fbTitleCode" filterable clearable  :placeholder="$t('btn.select')+'科目代码'">
                <el-option v-for="item in  options.fbTitleCodeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="fbTitleName">
              <el-input clearable v-model="form.fbTitleName" :placeholder="$t('btn.enter')+'科目名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="fbTitleNote">
              <el-select v-model="form.fbTitleNote" filterable clearable  :placeholder="$t('btn.select')+'科目分类'">
                <el-option v-for="item in  options.fbTitleNoteOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="fbBudgetAmt">
              <el-input-number clearable v-model.number="form.fbBudgetAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'预算'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="fbActualAmt">
              <el-input-number clearable v-model.number="form.fbActualAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'实际'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="fbDiffAmt">
              <el-input-number clearable v-model.number="form.fbDiffAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会计人员" prop="fbAccountant">
              <el-input clearable v-model="form.fbAccountant" :placeholder="$t('btn.enter')+'会计人员'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="fbBalanceDate">
              <el-date-picker clearable v-model="form.fbBalanceDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="reMark">
              <el-input clearable v-model="form.reMark" :placeholder="$t('btn.enter')+'说明'" />
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

<script setup name="ficobudgetactualcost">
// 引入 ficobudgetactualcost操作方法
import { listFicoBudgetactualCost, addFicoBudgetactualCost, delFicoBudgetactualCost, updateFicoBudgetactualCost, getFicoBudgetactualCost, 
 
 } 
from '@/api/financial/ficobudgetactualcost.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中fbId数组数组
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
  fbFy: undefined,
  fbYm: undefined,
  fbCorpCode: undefined,
  fbExpCategory: undefined,
  fbCostCode: undefined,
  fbTitleCode: undefined,
  fbTitleNote: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbId', label: 'ID' },
  { visible: true, prop: 'fbFy', label: '期间' },
  { visible: true, prop: 'fbYm', label: '年月' },
  { visible: true, prop: 'fbCorpCode', label: '公司代码' },
  { visible: true, prop: 'fbCorpName', label: '公司名称' },
  { visible: true, prop: 'fbExpCategory', label: '统计类别' },
  { visible: true, prop: 'fbCostCode', label: '成本代码' },
  { visible: true, prop: 'fbCostName', label: '成本名称' },
  { visible: false, prop: 'fbTitleCode', label: '科目代码' },
  { visible: false, prop: 'fbTitleName', label: '科目名称' },
  { visible: false, prop: 'fbTitleNote', label: '科目分类' },
  { visible: false, prop: 'fbBudgetAmt', label: '预算' },
  { visible: false, prop: 'fbActualAmt', label: '实际' },
  { visible: false, prop: 'fbDiffAmt', label: '差异' },
  { visible: false, prop: 'fbAccountant', label: '会计人员' },
  { visible: false, prop: 'fbBalanceDate', label: '日期' },
  { visible: false, prop: 'reMark', label: '说明' },
])
  // 总条数
const total = ref(0)
  // 预算实际明细表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sql_period_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sys_crop_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取预算实际明细表记录数据
function getList(){
  loading.value = true
  listFicoBudgetactualCost(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.fbId);
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
    fbFy: [{ required: true, message: "期间"+proxy.$t('btn.empty'), trigger: "change" }],
    fbYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "change" }],
    fbCorpCode: [{ required: true, message: "公司代码"+proxy.$t('btn.empty'), trigger: "change" }],
    fbCorpName: [{ required: true, message: "公司名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbExpCategory: [{ required: true, message: "统计类别"+proxy.$t('btn.empty'), trigger: "change" }],
    fbCostCode: [{ required: true, message: "成本代码"+proxy.$t('btn.empty'), trigger: "change" }],
    fbCostName: [{ required: true, message: "成本名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbTitleCode: [{ required: true, message: "科目代码"+proxy.$t('btn.empty'), trigger: "change" }],
    fbTitleName: [{ required: true, message: "科目名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbTitleNote: [{ required: true, message: "科目分类"+proxy.$t('btn.empty'), trigger: "change" }],
    fbBudgetAmt: [{ required: true, message: "预算"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbActualAmt: [{ required: true, message: "实际"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbDiffAmt: [{ required: true, message: "差异"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbAccountant: [{ required: true, message: "会计人员"+proxy.$t('btn.empty'), trigger: "blur" }],
    fbBalanceDate: [{ required: true, message: "日期"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_period_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ym_list: [],
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_crop_list: [],
    // 统计类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    fbExpCategoryOptions: [],
    // 成本代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    fbCostCodeOptions: [],
    // 科目代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    fbTitleCodeOptions: [],
    // 科目分类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    fbTitleNoteOptions: [],
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
    fbFy: undefined,
    fbYm: undefined,
    fbCorpCode: undefined,
    fbCorpName: undefined,
    fbExpCategory: undefined,
    fbCostCode: undefined,
    fbCostName: undefined,
    fbTitleCode: undefined,
    fbTitleName: undefined,
    fbTitleNote: undefined,
    fbBudgetAmt: undefined,
    fbActualAmt: undefined,
    fbDiffAmt: undefined,
    fbAccountant: undefined,
    fbBalanceDate: undefined,
    reMark: undefined,
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
  const id = row.fbId || ids.value
  getFicoBudgetactualCost(id).then((res) => {
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
      if (form.value.fbId != undefined && opertype.value === 2) {
        updateFicoBudgetactualCost(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoBudgetactualCost(form.value).then((res) => {
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
  const Ids = row.fbId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoBudgetactualCost(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"预算实际明细", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/financial/FicoBudgetactualCost/export', { ...queryParams })
    })
}

handleQuery()
</script>