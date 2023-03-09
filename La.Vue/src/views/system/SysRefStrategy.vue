<!--
 * @Descripttion: (单据编码/sys_ref_strategy)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="模块" prop="refModule">
        <el-select filterable clearable  v-model="queryParams.refModule" :placeholder="$t('btn.select')+'模块'">
          <el-option v-for="item in  options.sys_module_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="refCategory">
        <el-select filterable clearable  v-model="queryParams.refCategory" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.sys_ref_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="编码模式" prop="refPattern">
        <el-select filterable clearable  v-model="queryParams.refPattern" :placeholder="$t('btn.select')+'编码模式'">
          <el-option v-for="item in  options.sys_numbering_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['sys:refstrategy:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sys:refstrategy:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sys:refstrategy:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['sys:refstrategy:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="refId" label="ID" align="center" v-if="columns.showColumn('refId')"/>
      <el-table-column prop="refModule" label="模块" align="center" v-if="columns.showColumn('refModule')">
        <template #default="scope">
          <dict-tag :options=" options.sys_module_list " :value="scope.row.refModule" />
        </template>
      </el-table-column>
      <el-table-column prop="refCategory" label="类别" align="center" v-if="columns.showColumn('refCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ref_type " :value="scope.row.refCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="refCode" label="编码代号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('refCode')"/>
      <el-table-column prop="refName" label="编码名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('refName')"/>
      <el-table-column prop="refPattern" label="编码模式" align="center" v-if="columns.showColumn('refPattern')">
        <template #default="scope">
          <dict-tag :options=" options.sys_numbering_method " :value="scope.row.refPattern" />
        </template>
      </el-table-column>
      <el-table-column prop="refPrefix" label="前缀" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('refPrefix')"/>
      <el-table-column prop="refLenth" label="长度" align="center" v-if="columns.showColumn('refLenth')"/>
      <el-table-column prop="initNumber" label="初始编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('initNumber')"/>
      <el-table-column prop="isoNumber" label="ISO编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('isoNumber')"/>
      <el-table-column prop="status" label="状态" align="center" v-if="columns.showColumn('status')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.status" />
        </template>
      </el-table-column>
      <el-table-column prop="sort" label="排序" align="center" v-if="columns.showColumn('sort')"/>
      <el-table-column prop="isDeleted" label="isDeleted" align="center" v-if="columns.showColumn('isDeleted')">
        <template #default="scope">
          <dict-tag :options=" options.isDeletedOptions" :value="scope.row.isDeleted" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['sys:refstrategy:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sys:refstrategy:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改单据编码对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="refId">
              <el-input-number clearable v-model.number="form.refId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="模块" prop="refModule">
              <el-select v-model="form.refModule" filterable clearable  :placeholder="$t('btn.select')+'模块'">
                <el-option v-for="item in  options.sys_module_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="refCategory">
              <el-select v-model="form.refCategory" filterable clearable  :placeholder="$t('btn.select')+'类别'">
                <el-option v-for="item in  options.sys_ref_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="编码代号" prop="refCode">
              <el-input clearable v-model="form.refCode" :placeholder="$t('btn.enter')+'编码代号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="编码名称" prop="refName">
              <el-input clearable v-model="form.refName" :placeholder="$t('btn.enter')+'编码名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="编码模式" prop="refPattern">
              <el-select v-model="form.refPattern" filterable clearable  :placeholder="$t('btn.select')+'编码模式'">
                <el-option v-for="item in  options.sys_numbering_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前缀" prop="refPrefix">
              <el-input clearable v-model="form.refPrefix" :placeholder="$t('btn.enter')+'前缀'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="长度" prop="refLenth">
              <el-input-number clearable v-model.number="form.refLenth" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'长度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="初始编码" prop="initNumber">
              <el-input clearable v-model="form.initNumber" :placeholder="$t('btn.enter')+'初始编码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ISO编号" prop="isoNumber">
              <el-input clearable v-model="form.isoNumber" :placeholder="$t('btn.enter')+'ISO编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="status">
              <el-radio-group v-model="form.status">
                <el-radio v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="排序" prop="sort">
              <el-input clearable v-model="form.sort" :placeholder="$t('btn.enter')+'排序'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="isDeleted" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted" :disabled="true">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
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

<script setup name="sysrefstrategy">
// 引入 sysrefstrategy操作方法
import { listSysRefStrategy, addSysRefStrategy, delSysRefStrategy, updateSysRefStrategy, getSysRefStrategy, 
 
 } 
from '@/api/system/sysrefstrategy.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中refId数组数组
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
  refModule: undefined,
  refCategory: undefined,
  refPattern: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'refId', label: 'ID' },
  { visible: true, prop: 'refModule', label: '模块' },
  { visible: true, prop: 'refCategory', label: '类别' },
  { visible: true, prop: 'refCode', label: '编码代号' },
  { visible: true, prop: 'refName', label: '编码名称' },
  { visible: true, prop: 'refPattern', label: '编码模式' },
  { visible: true, prop: 'refPrefix', label: '前缀' },
  { visible: true, prop: 'refLenth', label: '长度' },
  { visible: false, prop: 'initNumber', label: '初始编码' },
  { visible: false, prop: 'isoNumber', label: 'ISO编号' },
  { visible: false, prop: 'status', label: '状态' },
  { visible: false, prop: 'sort', label: '排序' },
  { visible: false, prop: 'isDeleted', label: '' },
])
  // 总条数
const total = ref(0)
  // 单据编码表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_module_list" },
  { dictType: "sys_ref_type" },
  { dictType: "sys_numbering_method" },
  { dictType: "sys_ec_status" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取单据编码表记录数据
function getList(){
  loading.value = true
  listSysRefStrategy(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.refId);
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
    refModule: [{ required: true, message: "模块"+proxy.$t('btn.empty'), trigger: "change" }],
    refCategory: [{ required: true, message: "类别"+proxy.$t('btn.empty'), trigger: "change" }],
    refCode: [{ required: true, message: "编码代号"+proxy.$t('btn.empty'), trigger: "blur" }],
    refName: [{ required: true, message: "编码名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    refPattern: [{ required: true, message: "编码模式"+proxy.$t('btn.empty'), trigger: "change" }],
    refPrefix: [{ required: true, message: "前缀"+proxy.$t('btn.empty'), trigger: "blur" }],
    refLenth: [{ required: true, message: "长度"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    initNumber: [{ required: true, message: "初始编码"+proxy.$t('btn.empty'), trigger: "blur" }],
    isoNumber: [{ required: true, message: "ISO编号"+proxy.$t('btn.empty'), trigger: "blur" }],
    status: [{ required: true, message: "状态"+proxy.$t('btn.empty'), trigger: "blur" }],
    sort: [{ required: true, message: "排序"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 模块 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_module_list: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ref_type: [],
    // 编码模式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_numbering_method: [],
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_status: [],
    // isDeleted选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    refModule: undefined,
    refCategory: undefined,
    refCode: undefined,
    refName: undefined,
    refPattern: undefined,
    refPrefix: undefined,
    refLenth: undefined,
    initNumber: undefined,
    isoNumber: undefined,
    status: undefined,
    sort: undefined,
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
  const id = row.refId || ids.value
  getSysRefStrategy(id).then((res) => {
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
      if (form.value.refId != undefined && opertype.value === 2) {
        updateSysRefStrategy(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addSysRefStrategy(form.value).then((res) => {
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
  const Ids = row.refId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delSysRefStrategy(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"单据编码", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/system/SysRefStrategy/export', { ...queryParams })
    })
}

handleQuery()
</script>