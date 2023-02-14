<!--
 * @Descripttion: (原因类别/pp_cause_type)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-10)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-10)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="原因类别" prop="ctCauseType">
        <el-select clearable  v-model="queryParams.ctCauseType" placeholder="请选择原因类别">
          <el-option v-for="item in  options.sys_cause_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['pp:causetype:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:causetype:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:causetype:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:causetype:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="ctId" label="ID" align="center" v-if="columns.showColumn('ctId')"/>
      <el-table-column prop="ctCauseType" label="原因类别" align="center" v-if="columns.showColumn('ctCauseType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cause_type " :value="scope.row.ctCauseType" />
        </template>
      </el-table-column>
      <el-table-column prop="ctcausetextZh" label="原因名称ZH" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ctcausetextZh')"/>
      <el-table-column prop="ctcausetextEn" label="原因名称EN" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ctcausetextEn')"/>
      <el-table-column prop="ctcausetextJa" label="原因名称JA" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ctcausetextJa')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:causetype:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:causetype:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改原因类别对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="ctId">
              <el-input-number v-model.number="form.ctId" controls-position="right" placeholder="请输入ID" :disabled="title=='修改数据'"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="原因类别" prop="ctCauseType">
              <el-select v-model="form.ctCauseType" placeholder="请选择原因类别">
                <el-option v-for="item in  options.sys_cause_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原因名称ZH" prop="ctcausetextZh">
              <el-input v-model="form.ctcausetextZh" placeholder="请输入原因名称ZH" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原因名称EN" prop="ctcausetextEn">
              <el-input v-model="form.ctcausetextEn" placeholder="请输入原因名称EN" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原因名称JA" prop="ctcausetextJa">
              <el-input v-model="form.ctcausetextJa" placeholder="请输入原因名称JA" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input v-model="form.isDelete" placeholder="请输入软删除"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="remark">
              <el-input v-model="form.remark" placeholder="请输入备注" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input v-model="form.createBy" placeholder="请输入createBy" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入updateBy" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" placeholder="选择日期时间"></el-date-picker>
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

<script setup name="ppcausetype">
// 引入 ppcausetype操作方法
import { listPpCauseType, addPpCauseType, delPpCauseType, updatePpCauseType, getPpCauseType, 
 
 } 
from '@/api/production/ppcausetype.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中ctId数组数组
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
  ctCauseType: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ctId', label: 'ID' },
  { visible: true, prop: 'ctCauseType', label: '原因类别' },
  { visible: true, prop: 'ctcausetextZh', label: '原因名称ZH' },
  { visible: true, prop: 'ctcausetextEn', label: '原因名称EN' },
  { visible: true, prop: 'ctcausetextJa', label: '原因名称JA' },
  { visible: true, prop: 'remark', label: '备注' },
])
  // 总条数
const total = ref(0)
  // 原因类别表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_cause_type" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取原因类别表记录数据
function getList(){
  loading.value = true
  listPpCauseType(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ctId);
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
    ctCauseType: [{ required: true, message: "原因类别不能为空", trigger: "change" }],
    ctcausetextZh: [{ required: true, message: "原因名称ZH不能为空", trigger: "blur" }],
    ctcausetextEn: [{ required: true, message: "原因名称EN不能为空", trigger: "blur" }],
    ctcausetextJa: [{ required: true, message: "原因名称JA不能为空", trigger: "blur" }],
  },
  options: {
    // 原因类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_cause_type: [],
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
    ctCauseType: undefined,
    ctcausetextZh: undefined,
    ctcausetextEn: undefined,
    ctcausetextJa: undefined,
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
  title.value = '添加'
  opertype.value = 1
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ctId || ids.value
  getPpCauseType(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = "修改数据"
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
      if (form.value.ctId != undefined && opertype.value === 2) {
        updatePpCauseType(form.value).then((res) => {
          proxy.$modal.msgSuccess("修改成功")
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpCauseType(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
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
  const Ids = row.ctId || ids.value

  proxy.$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
  .then(function () {
      return delPpCauseType(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess("删除成功")
  })
  .catch(() => {})
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm("是否确认导出原因类别数据项?", "警告", {
      confirmButtonText: "确定",
      cancelButtonText: "取消",
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpCauseType/export', { ...queryParams })
    })
}

handleQuery()
</script>