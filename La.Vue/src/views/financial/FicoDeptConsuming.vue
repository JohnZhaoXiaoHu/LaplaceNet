<!--
 * @Descripttion: (部门消耗/fico_dept_consuming)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="期间" prop="dcFy">
        <el-input clearable v-model="queryParams.dcFy" :placeholder="$t('btn.enter')+'期间'" />
      </el-form-item>
      <el-form-item label="年月" prop="dcYm">
        <el-input clearable v-model="queryParams.dcYm" :placeholder="$t('btn.enter')+'年月'" />
      </el-form-item>
      <el-form-item label="公司代码" prop="dcCorpCode">
        <el-input clearable v-model="queryParams.dcCorpCode" :placeholder="$t('btn.enter')+'公司代码'" />
      </el-form-item>
      <el-form-item label="工厂" prop="dcPlant">
        <el-input clearable v-model="queryParams.dcPlant" :placeholder="$t('btn.enter')+'工厂'" />
      </el-form-item>
      <el-form-item label="物料" prop="dcMateriel">
        <el-input clearable v-model="queryParams.dcMateriel" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:deptconsuming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:deptconsuming:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:deptconsuming:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="dcId" label="ID" align="center" v-if="columns.showColumn('dcId')"/>
      <el-table-column prop="dcFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcFy')"/>
      <el-table-column prop="dcYm" label="年月" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcYm')"/>
      <el-table-column prop="dcCorpCode" label="公司代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCorpCode')"/>
      <el-table-column prop="dcCorpName" label="公司名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCorpName')"/>
      <el-table-column prop="dcExpCategory" label="统计类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcExpCategory')"/>
      <el-table-column prop="dcCostCode" label="成本代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostCode')"/>
      <el-table-column prop="dcCostName" label="成本名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostName')"/>
      <el-table-column prop="dcTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleCode')"/>
      <el-table-column prop="dcTitleName" label="科目名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleName')"/>
      <el-table-column prop="dcTitleNote" label="科目分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleNote')"/>
      <el-table-column prop="dcBudgetAmt" label="预算" align="center" v-if="columns.showColumn('dcBudgetAmt')"/>
      <el-table-column prop="dcActualAmt" label="实际" align="center" v-if="columns.showColumn('dcActualAmt')"/>
      <el-table-column prop="dcDiffAmt" label="差异" align="center" v-if="columns.showColumn('dcDiffAmt')"/>
      <el-table-column prop="dcPlant" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcPlant')"/>
      <el-table-column prop="dcMateriel" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMateriel')"/>
      <el-table-column prop="dcStorageLocation" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcStorageLocation')"/>
      <el-table-column prop="dcMoveType" label="移动类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMoveType')"/>
      <el-table-column prop="dcMaterielDoc" label="物料凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDoc')"/>
      <el-table-column prop="dcMaterielDocDetails" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDocDetails')"/>
      <el-table-column prop="dcUseQty" label="数量" align="center" v-if="columns.showColumn('dcUseQty')"/>
      <el-table-column prop="dcUseAmt" label="金额" align="center" v-if="columns.showColumn('dcUseAmt')"/>
      <el-table-column prop="dcReserveDoc" label="预留单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcReserveDoc')"/>
      <el-table-column prop="dcAccountant" label="预留明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcAccountant')"/>
      <el-table-column prop="dcBalanceDate" label="登录日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcBalanceDate')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:deptconsuming:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:deptconsuming:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改部门消耗对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="dcId">
              <el-input-number clearable v-model.number="form.dcId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="期间" prop="dcFy">
              <el-input clearable v-model="form.dcFy" :placeholder="$t('btn.enter')+'期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="dcYm">
              <el-input clearable v-model="form.dcYm" :placeholder="$t('btn.enter')+'年月'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="dcCorpCode">
              <el-input clearable v-model="form.dcCorpCode" :placeholder="$t('btn.enter')+'公司代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司名称" prop="dcCorpName">
              <el-input clearable v-model="form.dcCorpName" :placeholder="$t('btn.enter')+'公司名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统计类别" prop="dcExpCategory">
              <el-input clearable v-model="form.dcExpCategory" :placeholder="$t('btn.enter')+'统计类别'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本代码" prop="dcCostCode">
              <el-input clearable v-model="form.dcCostCode" :placeholder="$t('btn.enter')+'成本代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本名称" prop="dcCostName">
              <el-input clearable v-model="form.dcCostName" :placeholder="$t('btn.enter')+'成本名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="dcTitleCode">
              <el-input clearable v-model="form.dcTitleCode" :placeholder="$t('btn.enter')+'科目代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="dcTitleName">
              <el-input clearable v-model="form.dcTitleName" :placeholder="$t('btn.enter')+'科目名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="dcTitleNote">
              <el-input clearable v-model="form.dcTitleNote" :placeholder="$t('btn.enter')+'科目分类'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="dcBudgetAmt">
              <el-input clearable v-model="form.dcBudgetAmt" :placeholder="$t('btn.enter')+'预算'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="dcActualAmt">
              <el-input clearable v-model="form.dcActualAmt" :placeholder="$t('btn.enter')+'实际'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="dcDiffAmt">
              <el-input clearable v-model="form.dcDiffAmt" :placeholder="$t('btn.enter')+'差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="dcPlant">
              <el-input clearable v-model="form.dcPlant" :placeholder="$t('btn.enter')+'工厂'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="dcMateriel">
              <el-input clearable v-model="form.dcMateriel" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="dcStorageLocation">
              <el-input clearable v-model="form.dcStorageLocation" :placeholder="$t('btn.enter')+'仓库'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="dcMoveType">
              <el-input clearable v-model="form.dcMoveType" :placeholder="$t('btn.enter')+'移动类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="dcMaterielDoc">
              <el-input clearable v-model="form.dcMaterielDoc" :placeholder="$t('btn.enter')+'物料凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="dcMaterielDocDetails">
              <el-input clearable v-model="form.dcMaterielDocDetails" :placeholder="$t('btn.enter')+'凭证明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dcUseQty">
              <el-input clearable v-model="form.dcUseQty" :placeholder="$t('btn.enter')+'数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="dcUseAmt">
              <el-input clearable v-model="form.dcUseAmt" :placeholder="$t('btn.enter')+'金额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="dcReserveDoc">
              <el-input clearable v-model="form.dcReserveDoc" :placeholder="$t('btn.enter')+'预留单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="dcAccountant">
              <el-input clearable v-model="form.dcAccountant" :placeholder="$t('btn.enter')+'预留明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="dcBalanceDate">
              <el-date-picker clearable v-model="form.dcBalanceDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'说明'" />
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

<script setup name="ficodeptconsuming">
// 引入 ficodeptconsuming操作方法
import { listFicoDeptConsuming, addFicoDeptConsuming, delFicoDeptConsuming, updateFicoDeptConsuming, getFicoDeptConsuming, 
 
 } 
from '@/api/financial/ficodeptconsuming.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中dcId数组数组
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
  dcFy: undefined,
  dcYm: undefined,
  dcCorpCode: undefined,
  dcPlant: undefined,
  dcMateriel: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'dcId', label: 'ID' },
  { visible: true, prop: 'dcFy', label: '期间' },
  { visible: true, prop: 'dcYm', label: '年月' },
  { visible: true, prop: 'dcCorpCode', label: '公司代码' },
  { visible: true, prop: 'dcCorpName', label: '公司名称' },
  { visible: true, prop: 'dcExpCategory', label: '统计类别' },
  { visible: true, prop: 'dcCostCode', label: '成本代码' },
  { visible: true, prop: 'dcCostName', label: '成本名称' },
  { visible: false, prop: 'dcTitleCode', label: '科目代码' },
  { visible: false, prop: 'dcTitleName', label: '科目名称' },
  { visible: false, prop: 'dcTitleNote', label: '科目分类' },
  { visible: false, prop: 'dcBudgetAmt', label: '预算' },
  { visible: false, prop: 'dcActualAmt', label: '实际' },
  { visible: false, prop: 'dcDiffAmt', label: '差异' },
  { visible: false, prop: 'dcPlant', label: '工厂' },
  { visible: false, prop: 'dcMateriel', label: '物料' },
  { visible: false, prop: 'dcStorageLocation', label: '仓库' },
  { visible: false, prop: 'dcMoveType', label: '移动类型' },
  { visible: false, prop: 'dcMaterielDoc', label: '物料凭证' },
  { visible: false, prop: 'dcMaterielDocDetails', label: '凭证明细' },
  { visible: false, prop: 'dcUseQty', label: '数量' },
  { visible: false, prop: 'dcUseAmt', label: '金额' },
  { visible: false, prop: 'dcReserveDoc', label: '预留单' },
  { visible: false, prop: 'dcAccountant', label: '预留明细' },
  { visible: false, prop: 'dcBalanceDate', label: '登录日期' },
  { visible: false, prop: 'remark', label: '说明' },
])
  // 总条数
const total = ref(0)
  // 部门消耗表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取部门消耗表记录数据
function getList(){
  loading.value = true
  listFicoDeptConsuming(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.dcId);
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
    dcFy: [{ required: true, message: "期间"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcCorpCode: [{ required: true, message: "公司代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcCorpName: [{ required: true, message: "公司名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcExpCategory: [{ required: true, message: "统计类别"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcCostCode: [{ required: true, message: "成本代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcCostName: [{ required: true, message: "成本名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcTitleCode: [{ required: true, message: "科目代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcTitleName: [{ required: true, message: "科目名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcTitleNote: [{ required: true, message: "科目分类"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcBudgetAmt: [{ required: true, message: "预算"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcActualAmt: [{ required: true, message: "实际"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcDiffAmt: [{ required: true, message: "差异"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcPlant: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcMateriel: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcStorageLocation: [{ required: true, message: "仓库"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcMoveType: [{ required: true, message: "移动类型"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcMaterielDoc: [{ required: true, message: "物料凭证"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcMaterielDocDetails: [{ required: true, message: "凭证明细"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcUseQty: [{ required: true, message: "数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcUseAmt: [{ required: true, message: "金额"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcReserveDoc: [{ required: true, message: "预留单"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcAccountant: [{ required: true, message: "预留明细"+proxy.$t('btn.empty'), trigger: "blur" }],
    dcBalanceDate: [{ required: true, message: "登录日期"+proxy.$t('btn.empty'), trigger: "blur" }],
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
    dcFy: undefined,
    dcYm: undefined,
    dcCorpCode: undefined,
    dcCorpName: undefined,
    dcExpCategory: undefined,
    dcCostCode: undefined,
    dcCostName: undefined,
    dcTitleCode: undefined,
    dcTitleName: undefined,
    dcTitleNote: undefined,
    dcBudgetAmt: undefined,
    dcActualAmt: undefined,
    dcDiffAmt: undefined,
    dcPlant: undefined,
    dcMateriel: undefined,
    dcStorageLocation: undefined,
    dcMoveType: undefined,
    dcMaterielDoc: undefined,
    dcMaterielDocDetails: undefined,
    dcUseQty: undefined,
    dcUseAmt: undefined,
    dcReserveDoc: undefined,
    dcAccountant: undefined,
    dcBalanceDate: undefined,
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
  const id = row.dcId || ids.value
  getFicoDeptConsuming(id).then((res) => {
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
      if (form.value.dcId != undefined && opertype.value === 2) {
        updateFicoDeptConsuming(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoDeptConsuming(form.value).then((res) => {
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
  const Ids = row.dcId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoDeptConsuming(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}




handleQuery()
</script>