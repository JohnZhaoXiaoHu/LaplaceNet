<!--
 * @Descripttion: (电子辞典/sys_et_dict)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-26)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-26)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="类别" prop="etType">
        <el-select filterable clearable  v-model="queryParams.etType" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.sys_et_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="字母" prop="etLetter">
        <el-input clearable v-model="queryParams.etLetter" :placeholder="$t('btn.enter')+'字母'" />
      </el-form-item>
      <el-form-item label="隶属范围" prop="etArea">
        <el-select filterable clearable  v-model="queryParams.etArea" :placeholder="$t('btn.select')+'隶属范围'">
          <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['sys:etdict:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sys:etdict:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sys:etdict:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['sys:etdict:delete']" plain icon="delete" @click="handleClear">
         {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['sys:etdict:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['sys:etdict:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="etGuid" label="Guid" align="center" v-if="columns.showColumn('etGuid')"/>
      <el-table-column prop="etType" label="类别" align="center" v-if="columns.showColumn('etType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_et_type " :value="scope.row.etType" />
        </template>
      </el-table-column>
      <el-table-column prop="etLetter" label="字母" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etLetter')"/>
      <el-table-column prop="etLangKey" label="语言" align="center" v-if="columns.showColumn('etLangKey')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_list " :value="scope.row.etLangKey" />
        </template>
      </el-table-column>
      <el-table-column prop="etPhrase" label="短语" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etPhrase')"/>
      <el-table-column prop="etExplain" label="解释" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etExplain')"/>
      <el-table-column prop="etArea" label="隶属范围" align="center" v-if="columns.showColumn('etArea')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.etArea" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['sys:etdict:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sys:etdict:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改电子辞典对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="Guid" prop="etGuid">
              <el-input-number clearable v-model.number="form.etGuid" controls-position="right" :placeholder="$t('btn.enter')+'Guid'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="类别" prop="etType">
              <el-select v-model="form.etType" filterable clearable  :placeholder="$t('btn.select')+'类别'">
                <el-option v-for="item in  options.sys_et_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="字母" prop="etLetter">
              <el-input clearable v-model="form.etLetter" :placeholder="$t('btn.enter')+'字母'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言" prop="etLangKey">
              <el-select v-model="form.etLangKey" filterable clearable  :placeholder="$t('btn.select')+'语言'">
                <el-option v-for="item in  options.sys_lang_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="短语" prop="etPhrase">
              <el-input clearable v-model="form.etPhrase" :placeholder="$t('btn.enter')+'短语'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="解释" prop="etExplain">
              <el-input clearable v-model="form.etExplain" :placeholder="$t('btn.enter')+'解释'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隶属范围" prop="etArea">
              <el-select v-model="form.etArea" filterable clearable  :placeholder="$t('btn.select')+'隶属范围'">
                <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
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

<script setup name="sysetdict">
// 引入 sysetdict操作方法
import { listSysEtDict, addSysEtDict, delSysEtDict, updateSysEtDict, getSysEtDict, 
 clearSysEtDict,  
 } 
from '@/api/system/sysetdict.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中etGuid数组数组
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
  etType: undefined,
  etLetter: undefined,
  etArea: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'etGuid', label: 'Guid' },
  { visible: true, prop: 'etType', label: '类别' },
  { visible: true, prop: 'etLetter', label: '字母' },
  { visible: true, prop: 'etLangKey', label: '语言' },
  { visible: true, prop: 'etPhrase', label: '短语' },
  { visible: true, prop: 'etExplain', label: '解释' },
  { visible: true, prop: 'etArea', label: '隶属范围' },
  { visible: true, prop: 'remark', label: '备注' },
])
  // 总条数
const total = ref(0)
  // 电子辞典表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_et_type" },
  { dictType: "sys_lang_list" },
  { dictType: "sys_ind_type" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取电子辞典表记录数据
function getList(){
  loading.value = true
  listSysEtDict(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.etGuid);
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
    etType: [{ required: true, message: "类别"+proxy.$t('btn.empty'), trigger: "change" }],
    etLetter: [{ required: true, message: "字母"+proxy.$t('btn.empty'), trigger: "blur" }],
    etLangKey: [{ required: true, message: "语言"+proxy.$t('btn.empty'), trigger: "change" }],
    etPhrase: [{ required: true, message: "短语"+proxy.$t('btn.empty'), trigger: "blur" }],
    etExplain: [{ required: true, message: "解释"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_et_type: [],
    // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_lang_list: [],
    // 隶属范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ind_type: [],
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
    etType: undefined,
    etLetter: undefined,
    etLangKey: undefined,
    etPhrase: undefined,
    etExplain: undefined,
    etArea: undefined,
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
  const id = row.etGuid || ids.value
  getSysEtDict(id).then((res) => {
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
      if (form.value.etGuid != undefined && opertype.value === 2) {
        updateSysEtDict(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addSysEtDict(form.value).then((res) => {
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
  const Ids = row.etGuid || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delSysEtDict(Ids)
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
      return clearSysEtDict()
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
    .$confirm(proxy.$t('common.confirmExport')+"电子辞典", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/System/SysEtDict/export', { ...queryParams })
    })
}

handleQuery()
</script>