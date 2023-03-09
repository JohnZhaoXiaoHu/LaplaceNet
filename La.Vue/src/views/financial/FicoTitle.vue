<!--
 * @Descripttion: (会计科目/fico_title)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="公司名称" prop="ftCorpCode">
        <el-select filterable clearable  v-model="queryParams.ftCorpCode" :placeholder="$t('btn.select')+'公司名称'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目代码" prop="ftTitleCode">
        <el-input clearable v-model="queryParams.ftTitleCode" :placeholder="$t('btn.enter')+'科目代码'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:title:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:title:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:title:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:title:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="ftId" label="ID" align="center" v-if="columns.showColumn('ftId')"/>
      <el-table-column prop="ftCorpCode" label="公司名称" align="center" v-if="columns.showColumn('ftCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.ftCorpCode" />
        </template>
      </el-table-column>
      <el-table-column prop="ftTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ftTitleCode')"/>
      <el-table-column prop="fttitlenameZh" label="科目名称_ZH" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fttitlenameZh')"/>
      <el-table-column prop="fttitlenameEn" label="科目名称_EN" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fttitlenameEn')"/>
      <el-table-column prop="fttitlenameJa" label="科目名称_JA" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fttitlenameJa')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:title:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:title:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改会计科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="ftId">
              <el-input-number clearable v-model.number="form.ftId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司名称" prop="ftCorpCode">
              <el-select v-model="form.ftCorpCode" filterable clearable  :placeholder="$t('btn.select')+'公司名称'">
                <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="ftTitleCode">
              <el-input clearable v-model="form.ftTitleCode" :placeholder="$t('btn.enter')+'科目代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称_ZH" prop="fttitlenameZh">
              <el-input clearable v-model="form.fttitlenameZh" :placeholder="$t('btn.enter')+'科目名称_ZH'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称_EN" prop="fttitlenameEn">
              <el-input clearable v-model="form.fttitlenameEn" :placeholder="$t('btn.enter')+'科目名称_EN'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称_JA" prop="fttitlenameJa">
              <el-input clearable v-model="form.fttitlenameJa" :placeholder="$t('btn.enter')+'科目名称_JA'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input clearable v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
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

<script setup name="ficotitle">
// 引入 ficotitle操作方法
import { listFicoTitle, addFicoTitle, delFicoTitle, updateFicoTitle, getFicoTitle, 
 
 } 
from '@/api/financial/ficotitle.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中ftId数组数组
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
  ftCorpCode: undefined,
  ftTitleCode: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ftId', label: 'ID' },
  { visible: true, prop: 'ftCorpCode', label: '公司名称' },
  { visible: true, prop: 'ftTitleCode', label: '科目代码' },
  { visible: true, prop: 'fttitlenameZh', label: '科目名称_ZH' },
  { visible: true, prop: 'fttitlenameEn', label: '科目名称_EN' },
  { visible: true, prop: 'fttitlenameJa', label: '科目名称_JA' },
  { visible: true, prop: 'remark', label: '说明' },
])
  // 总条数
const total = ref(0)
  // 会计科目表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_crop_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取会计科目表记录数据
function getList(){
  loading.value = true
  listFicoTitle(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ftId);
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
    ftCorpCode: [{ required: true, message: "公司名称"+proxy.$t('btn.empty'), trigger: "change" }],
    ftTitleCode: [{ required: true, message: "科目代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    fttitlenameZh: [{ required: true, message: "科目名称_ZH"+proxy.$t('btn.empty'), trigger: "blur" }],
    fttitlenameEn: [{ required: true, message: "科目名称_EN"+proxy.$t('btn.empty'), trigger: "blur" }],
    fttitlenameJa: [{ required: true, message: "科目名称_JA"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 公司名称 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_crop_list: [],
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
    ftCorpCode: undefined,
    ftTitleCode: undefined,
    fttitlenameZh: undefined,
    fttitlenameEn: undefined,
    fttitlenameJa: undefined,
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
  const id = row.ftId || ids.value
  getFicoTitle(id).then((res) => {
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
      if (form.value.ftId != undefined && opertype.value === 2) {
        updateFicoTitle(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoTitle(form.value).then((res) => {
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
  const Ids = row.ftId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delFicoTitle(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"会计科目", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/financial/FicoTitle/export', { ...queryParams })
    })
}

handleQuery()
</script>