<!--
 * @Descripttion: (流程实例模板/wf_flowinstance)
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
        <el-button type="primary" v-hasPermi="['la:wfflowinstance:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:wfflowinstance:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:wfflowinstance:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:wfflowinstance:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="instanceSchemeId" label="流程实例模板Id" align="center" v-if="columns.showColumn('instanceSchemeId')"/>
      <el-table-column prop="code" label="实例编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('code')"/>
      <el-table-column prop="customName" label="自定义名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('customName')"/>
      <el-table-column prop="activityId" label="当前节点ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('activityId')"/>
      <el-table-column prop="activityType" label="当前节点类型（0会签节点）" align="center" v-if="columns.showColumn('activityType')">
        <template #default="scope">
          <dict-tag :options=" options.activityTypeOptions" :value="scope.row.activityType" />
        </template>
      </el-table-column>
      <el-table-column prop="activityName" label="当前节点名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('activityName')"/>
      <el-table-column prop="previousId" label="前一个ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('previousId')"/>
      <el-table-column prop="schemeContent" label="流程模板内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeContent')"/>
      <el-table-column prop="schemeId" label="流程模板ID" align="center" v-if="columns.showColumn('schemeId')"/>
      <el-table-column prop="dbName" label="数据库名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dbName')"/>
      <el-table-column prop="frmData" label="表单数据" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('frmData')"/>
      <el-table-column prop="frmType" label="表单类型" align="center" v-if="columns.showColumn('frmType')">
        <template #default="scope">
          <dict-tag :options=" options.frmTypeOptions" :value="scope.row.frmType" />
        </template>
      </el-table-column>
      <el-table-column prop="frmContentData" label="表单中的字段" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('frmContentData')"/>
      <el-table-column prop="frmContentParse" label="表单字段（冗余)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('frmContentParse')"/>
      <el-table-column prop="frmId" label="表单ID" align="center" v-if="columns.showColumn('frmId')"/>
      <el-table-column prop="schemeType" label="流程类型" align="center" v-if="columns.showColumn('schemeType')">
        <template #default="scope">
          <dict-tag :options=" options.schemeTypeOptions" :value="scope.row.schemeType" />
        </template>
      </el-table-column>
      <el-table-column prop="flowLevel" label="等级" align="center" v-if="columns.showColumn('flowLevel')"/>
      <el-table-column prop="isFinish" label="是否完成" align="center" v-if="columns.showColumn('isFinish')">
        <template #default="scope">
          <dict-tag :options=" options.isFinishOptions" :value="scope.row.isFinish" />
        </template>
      </el-table-column>
      <el-table-column prop="frmContent" label="表单参数" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('frmContent')"/>
      <el-table-column prop="makerList" label="执行人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('makerList')"/>
      <el-table-column prop="orgId" label="所属部门" align="center" v-if="columns.showColumn('orgId')"/>
      <el-table-column prop="active" label="Active" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('active')"/>
      <el-table-column prop="status" label="状态标识" align="center" v-if="columns.showColumn('status')">
        <template #default="scope">
          <dict-tag :options=" options.statusOptions" :value="scope.row.status" />
        </template>
      </el-table-column>
      <el-table-column prop="tenantId" label="TenantId" align="center" v-if="columns.showColumn('tenantId')"/>
      <el-table-column prop="remark" label="Remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:wfflowinstance:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:wfflowinstance:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改流程实例模板对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="id">
              <el-input clearable v-model="form.id" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>

    
          <el-col :lg="12">
            <el-form-item label="流程实例模板Id" prop="instanceSchemeId">
              <el-input clearable v-model="form.instanceSchemeId" :placeholder="$t('btn.enter')+'流程实例模板Id'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实例编号" prop="code">
              <el-input clearable v-model="form.code" :placeholder="$t('btn.enter')+'实例编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义名称" prop="customName">
              <el-input clearable v-model="form.customName" :placeholder="$t('btn.enter')+'自定义名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前节点ID" prop="activityId">
              <el-input clearable v-model="form.activityId" :placeholder="$t('btn.enter')+'当前节点ID'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="当前节点类型（0会签节点）" prop="activityType">
              <el-select v-model="form.activityType" filterable clearable  :placeholder="$t('btn.select')+'当前节点类型（0会签节点）'">
                <el-option v-for="item in  options.activityTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前节点名称" prop="activityName">
              <el-input clearable v-model="form.activityName" :placeholder="$t('btn.enter')+'当前节点名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一个ID" prop="previousId">
              <el-input clearable v-model="form.previousId" :placeholder="$t('btn.enter')+'前一个ID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="流程模板内容" prop="schemeContent">
              <el-input clearable type="textarea" v-model="form.schemeContent" :placeholder="$t('btn.enter')+'流程模板内容'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="流程模板ID" prop="schemeId">
              <el-input clearable v-model="form.schemeId" :placeholder="$t('btn.enter')+'流程模板ID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数据库名称" prop="dbName">
              <el-input clearable v-model="form.dbName" :placeholder="$t('btn.enter')+'数据库名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="表单数据" prop="frmData">
              <el-input clearable type="textarea" v-model="form.frmData" :placeholder="$t('btn.enter')+'表单数据'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="表单类型" prop="frmType">
              <el-select v-model="form.frmType" filterable clearable  :placeholder="$t('btn.select')+'表单类型'">
                <el-option v-for="item in  options.frmTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="表单中的字段" prop="frmContentData">
              <el-input clearable type="textarea" v-model="form.frmContentData" :placeholder="$t('btn.enter')+'表单中的字段'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="表单字段（冗余)" prop="frmContentParse">
              <el-input clearable type="textarea" v-model="form.frmContentParse" :placeholder="$t('btn.enter')+'表单字段（冗余)'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="表单ID" prop="frmId">
              <el-input clearable v-model="form.frmId" :placeholder="$t('btn.enter')+'表单ID'" />
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
            <el-form-item label="等级" prop="flowLevel">
              <el-input clearable v-model="form.flowLevel" :placeholder="$t('btn.enter')+'等级'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="是否完成" prop="isFinish">
              <el-radio-group v-model="form.isFinish">
                <el-radio v-for="item in  options.isFinishOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="表单参数" prop="frmContent">
              <el-input clearable type="textarea" v-model="form.frmContent" :placeholder="$t('btn.enter')+'表单参数'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="执行人" prop="makerList">
              <el-input clearable type="textarea" v-model="form.makerList" :placeholder="$t('btn.enter')+'执行人'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="所属部门" prop="orgId">
              <el-input clearable v-model="form.orgId" :placeholder="$t('btn.enter')+'所属部门'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Active" prop="active">
              <el-input clearable type="textarea" v-model="form.active" :placeholder="$t('btn.enter')+'Active'"/>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="状态标识" prop="status">
              <el-radio-group v-model="form.status">
                <el-radio v-for="item in  options.statusOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="IsDeleted" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="TenantId" prop="tenantId">
              <el-input clearable v-model="form.tenantId" :placeholder="$t('btn.enter')+'TenantId'" />
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

<script setup name="wfflowinstance">
// 引入 wfflowinstance操作方法
import { listWfFlowinstance, addWfFlowinstance, delWfFlowinstance, updateWfFlowinstance, getWfFlowinstance, 
 
 } 
from '@/api/workflow/wfflowinstance.js'
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
  { visible: true, prop: 'instanceSchemeId', label: '流程实例模板Id' },
  { visible: true, prop: 'code', label: '实例编号' },
  { visible: true, prop: 'customName', label: '自定义名称' },
  { visible: true, prop: 'activityId', label: '当前节点ID' },
  { visible: true, prop: 'activityType', label: '当前节点类型（0会签节点）' },
  { visible: true, prop: 'activityName', label: '当前节点名称' },
  { visible: true, prop: 'previousId', label: '前一个ID' },
  { visible: false, prop: 'schemeContent', label: '流程模板内容' },
  { visible: false, prop: 'schemeId', label: '流程模板ID' },
  { visible: false, prop: 'dbName', label: '数据库名称' },
  { visible: false, prop: 'frmData', label: '表单数据' },
  { visible: false, prop: 'frmType', label: '表单类型' },
  { visible: false, prop: 'frmContentData', label: '表单中的字段' },
  { visible: false, prop: 'frmContentParse', label: '表单字段（冗余)' },
  { visible: false, prop: 'frmId', label: '表单ID' },
  { visible: false, prop: 'schemeType', label: '流程类型' },
  { visible: false, prop: 'flowLevel', label: '等级' },
  { visible: false, prop: 'isFinish', label: '是否完成' },
  { visible: false, prop: 'frmContent', label: '表单参数' },
  { visible: false, prop: 'makerList', label: '执行人' },
  { visible: false, prop: 'orgId', label: '所属部门' },
  { visible: false, prop: 'active', label: 'Active' },
  { visible: false, prop: 'status', label: '状态标识' },
  { visible: false, prop: 'tenantId', label: 'TenantId' },
  { visible: false, prop: 'remark', label: 'Remark' },
])
  // 总条数
const total = ref(0)
  // 流程实例模板表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取流程实例模板表记录数据
function getList(){
  loading.value = true
  listWfFlowinstance(queryParams).then(res => {
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
    flowLevel: [{ required: true, message: "等级"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    isFinish: [{ required: true, message: "是否完成"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    status: [{ required: true, message: "状态标识"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    isDeleted: [{ required: true, message: "IsDeleted"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    tenantId: [{ required: true, message: "TenantId"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 当前节点类型（0会签节点） 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    activityTypeOptions: [],
    // 表单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    frmTypeOptions: [],
    // 流程类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    schemeTypeOptions: [],
    // 是否完成 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isFinishOptions: [],
    // 状态标识 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    instanceSchemeId: undefined,
    code: undefined,
    customName: undefined,
    activityId: undefined,
    activityType: undefined,
    activityName: undefined,
    previousId: undefined,
    schemeContent: undefined,
    schemeId: undefined,
    dbName: undefined,
    frmData: undefined,
    frmType: undefined,
    frmContentData: undefined,
    frmContentParse: undefined,
    frmId: undefined,
    schemeType: undefined,
    flowLevel: undefined,
    isFinish: undefined,
    frmContent: undefined,
    makerList: undefined,
    orgId: undefined,
    active: undefined,
    status: undefined,
    isDeleted: undefined,
    tenantId: undefined,
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
  getWfFlowinstance(id).then((res) => {
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
        updateWfFlowinstance(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addWfFlowinstance(form.value).then((res) => {
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
      return delWfFlowinstance(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"流程实例模板", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/workflow/WfFlowinstance/export', { ...queryParams })
    })
}

handleQuery()
</script>