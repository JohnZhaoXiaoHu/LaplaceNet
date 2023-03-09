<!--
 * @Descripttion: (利润中心/fico_prctr)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="fpPlnt">
        <el-select filterable clearable  v-model="queryParams.fpPlnt" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="代码" prop="fpCode">
        <el-input clearable v-model="queryParams.fpCode" :placeholder="$t('btn.enter')+'代码'" />
      </el-form-item>
      <el-form-item label="名称" prop="fpName">
        <el-input clearable v-model="queryParams.fpName" :placeholder="$t('btn.enter')+'名称'" />
      </el-form-item>
      <el-form-item label="类别" prop="fpType">
        <el-select filterable clearable  v-model="queryParams.fpType" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['fico:prctr:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:prctr:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:prctr:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:prctr:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="fpId" label="Id主键" align="center" v-if="columns.showColumn('fpId')"/>
      <el-table-column prop="fpPlnt" label="工厂" align="center" v-if="columns.showColumn('fpPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.fpPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="fpCode" label="代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpCode')"/>
      <el-table-column prop="fpName" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpName')"/>
      <el-table-column prop="fpType" label="类别" align="center" v-if="columns.showColumn('fpType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_fin_costtype " :value="scope.row.fpType" />
        </template>
      </el-table-column>
      <el-table-column prop="fpActDate" label="有效从" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpActDate')"/>
      <el-table-column prop="fpExpDate" label="有效到" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fpExpDate')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:prctr:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:prctr:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改利润中心对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="Id主键" prop="fpId">
              <el-input-number clearable v-model.number="form.fpId" controls-position="right" :placeholder="$t('btn.enter')+'Id主键'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂" prop="fpPlnt">
              <el-select v-model="form.fpPlnt" filterable clearable  :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="代码" prop="fpCode">
              <el-input clearable v-model="form.fpCode" :placeholder="$t('btn.enter')+'代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="fpName">
              <el-input clearable v-model="form.fpName" :placeholder="$t('btn.enter')+'名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="fpType">
              <el-select v-model="form.fpType" filterable clearable  :placeholder="$t('btn.select')+'类别'">
                <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效从" prop="fpActDate">
              <el-date-picker clearable v-model="form.fpActDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效到" prop="fpExpDate">
              <el-date-picker clearable v-model="form.fpExpDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="isDeleted" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'isDeleted'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="remark" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'remark'"  :disabled="true"/>
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

<script setup name="ficoprctr">
// 引入 ficoprctr操作方法
import { listFicoPrctr, addFicoPrctr, delFicoPrctr, updateFicoPrctr, getFicoPrctr, 
 
 } 
from '@/api/financial/ficoprctr.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中fpId数组数组
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
  fpPlnt: undefined,
  fpCode: undefined,
  fpName: undefined,
  fpType: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fpId', label: 'Id主键' },
  { visible: true, prop: 'fpPlnt', label: '工厂' },
  { visible: true, prop: 'fpCode', label: '代码' },
  { visible: true, prop: 'fpName', label: '名称' },
  { visible: true, prop: 'fpType', label: '类别' },
  { visible: true, prop: 'fpActDate', label: '有效从' },
  { visible: true, prop: 'fpExpDate', label: '有效到' },
])
  // 总条数
const total = ref(0)
  // 利润中心表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sys_fin_costtype" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取利润中心表记录数据
function getList(){
  loading.value = true
  listFicoPrctr(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.fpId);
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
    fpPlnt: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    fpCode: [{ required: true, message: "代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpName: [{ required: true, message: "名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpType: [{ required: true, message: "类别"+proxy.$t('btn.empty'), trigger: "change" }],
    fpActDate: [{ required: true, message: "有效从"+proxy.$t('btn.empty'), trigger: "blur" }],
    fpExpDate: [{ required: true, message: "有效到"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_fin_costtype: [],
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
    fpPlnt: undefined,
    fpCode: undefined,
    fpName: undefined,
    fpType: undefined,
    fpActDate: undefined,
    fpExpDate: undefined,
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
  const id = row.fpId || ids.value
  getFicoPrctr(id).then((res) => {
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
      if (form.value.fpId != undefined && opertype.value === 2) {
        updateFicoPrctr(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoPrctr(form.value).then((res) => {
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
  const Ids = row.fpId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoPrctr(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"利润中心", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/financial/FicoPrctr/export', { ...queryParams })
    })
}

handleQuery()
</script>