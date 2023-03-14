<!--
 * @Descripttion: (流程/wf_flowscheme)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-03-14)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-03-14)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['wf:flowscheme:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['wf:flowscheme:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['wf:flowscheme:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="schemeCode" label="流程编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeCode')"/>
      <el-table-column prop="schemeName" label="流程名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeName')"/>
      <el-table-column prop="schemeType" label="流程类型" align="center" v-if="columns.showColumn('schemeType')">
        <template #default="scope">
          <dict-tag :options=" options.schemeTypeOptions" :value="scope.row.schemeType" />
        </template>
      </el-table-column>
      <el-table-column prop="schemeVersion" label="流程版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeVersion')"/>
      <el-table-column prop="schemeCanUser" label="流程使用人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeCanUser')"/>
      <el-table-column prop="schemeContent" label="流程内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeContent')"/>
      <el-table-column prop="frmId" label="表单Id" align="center" v-if="columns.showColumn('frmId')"/>
      <el-table-column prop="frmType" label="表单类型" align="center" v-if="columns.showColumn('frmType')">
        <template #default="scope">
          <dict-tag :options=" options.frmTypeOptions" :value="scope.row.frmType" />
        </template>
      </el-table-column>
      <el-table-column prop="authorizeType" label="权限类型" align="center" v-if="columns.showColumn('authorizeType')">
        <template #default="scope">
          <dict-tag :options=" options.authorizeTypeOptions" :value="scope.row.authorizeType" />
        </template>
      </el-table-column>
      <el-table-column prop="orgId" label="组织Id" align="center" v-if="columns.showColumn('orgId')"/>
      <el-table-column prop="active" label="执行" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('active')"/>
      <el-table-column prop="status" label="状态" align="center" v-if="columns.showColumn('status')">
        <template #default="scope">
          <dict-tag :options=" options.statusOptions" :value="scope.row.status" />
        </template>
      </el-table-column>
      <el-table-column prop="sort" label="排序" align="center" v-if="columns.showColumn('sort')"/>
      <el-table-column prop="remark" label="Remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['wf:flowscheme:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['wf:flowscheme:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改流程对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="id">
              <el-input clearable v-model="form.id" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="流程编号" prop="schemeCode">
              <el-input clearable v-model="form.schemeCode" :placeholder="$t('btn.enter')+'流程编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程名称" prop="schemeName">
              <el-input clearable v-model="form.schemeName" :placeholder="$t('btn.enter')+'流程名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程类型" prop="schemeType">
              <el-select v-model="form.schemeType" filterable clearable  :placeholder="$t('btn.select')+'流程类型'">
                <el-option v-for="item in  options.schemeTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程版本" prop="schemeVersion">
              <el-input clearable v-model="form.schemeVersion" :placeholder="$t('btn.enter')+'流程版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程使用人" prop="schemeCanUser">
              <el-input clearable v-model="form.schemeCanUser" :placeholder="$t('btn.enter')+'流程使用人'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="流程内容" prop="schemeContent">
              <el-input clearable type="textarea" v-model="form.schemeContent" :placeholder="$t('btn.enter')+'流程内容'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="表单Id" prop="frmId">
              <el-input clearable v-model="form.frmId" :placeholder="$t('btn.enter')+'表单Id'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="表单类型" prop="frmType">
              <el-select v-model="form.frmType" filterable clearable  :placeholder="$t('btn.select')+'表单类型'">
                <el-option v-for="item in  options.frmTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="权限类型" prop="authorizeType">
              <el-select v-model="form.authorizeType" filterable clearable  :placeholder="$t('btn.select')+'权限类型'">
                <el-option v-for="item in  options.authorizeTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="组织Id" prop="orgId">
              <el-input clearable v-model="form.orgId" :placeholder="$t('btn.enter')+'组织Id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="执行" prop="active">
              <el-input clearable v-model="form.active" :placeholder="$t('btn.enter')+'执行'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="状态" prop="status">
              <el-radio-group v-model="form.status">
                <el-radio v-for="item in  options.statusOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="排序" prop="sort">
              <el-input clearable v-model="form.sort" :placeholder="$t('btn.enter')+'排序'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="IsDeleted" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted" :disabled="true">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Remark" prop="remark">
              <el-input clearable type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'Remark'"/>
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

<script setup name="wfflowscheme">
// 引入 wfflowscheme操作方法
import { listWfFlowscheme, addWfFlowscheme, delWfFlowscheme, updateWfFlowscheme, getWfFlowscheme, 
 
 } 
from '@/api/workflow/wfflowscheme.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中id数组数组
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
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'schemeCode', label: '流程编号' },
  { visible: true, prop: 'schemeName', label: '流程名称' },
  { visible: true, prop: 'schemeType', label: '流程类型' },
  { visible: true, prop: 'schemeVersion', label: '流程版本' },
  { visible: true, prop: 'schemeCanUser', label: '流程使用人' },
  { visible: true, prop: 'schemeContent', label: '流程内容' },
  { visible: true, prop: 'frmId', label: '表单Id' },
  { visible: false, prop: 'frmType', label: '表单类型' },
  { visible: false, prop: 'authorizeType', label: '权限类型' },
  { visible: false, prop: 'orgId', label: '组织Id' },
  { visible: false, prop: 'active', label: '执行' },
  { visible: false, prop: 'status', label: '状态' },
  { visible: false, prop: 'sort', label: '排序' },
  { visible: false, prop: 'remark', label: 'Remark' },
])
  // 总条数
const total = ref(0)
  // 流程表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取流程表记录数据
function getList(){
  loading.value = true
  listWfFlowscheme(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.id);
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    frmType: [{ required: true, message: "表单类型"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    status: [{ required: true, message: "状态"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    sort: [{ required: true, message: "排序"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 流程类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    schemeTypeOptions: [],
    // 表单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    frmTypeOptions: [],
    // 权限类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    authorizeTypeOptions: [],
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    statusOptions: [],
    // IsDeleted 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    id: undefined,
    schemeCode: undefined,
    schemeName: undefined,
    schemeType: undefined,
    schemeVersion: undefined,
    schemeCanUser: undefined,
    schemeContent: undefined,
    frmId: undefined,
    frmType: undefined,
    authorizeType: undefined,
    orgId: undefined,
    active: undefined,
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
  const id = row.id || ids.value
  getWfFlowscheme(id).then((res) => {
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
      if (form.value.id != undefined && opertype.value === 2) {
        updateWfFlowscheme(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfFlowscheme(form.value).then((res) => {
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
  const Ids = row.id || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delWfFlowscheme(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}




handleQuery()
</script>