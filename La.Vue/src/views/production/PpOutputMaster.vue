<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-07-20)
 * @LastEditors: (Lean365)
 * @LastEditTime: (2023-07-20)
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
        <el-button type="primary" v-hasPermi="['pp:outputmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputmaster:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputmaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" v-hasPermi="['pp:outputmaster:delete']" plain icon="delete" @click="handleClear">
          {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputmaster:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:outputmaster:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table
      :data="dataList"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
height="602"
      style="width: 100%" >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="pomId" label="ID" align="center" v-if="columns.showColumn('pomId')"/>
      <el-table-column prop="pomGuid" label="GUID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomGuid')"/>
      <el-table-column prop="pomOrder" label="生产工单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomOrder')"/>
      <el-table-column prop="pomOrderQty" label="工单数量" align="center" v-if="columns.showColumn('pomOrderQty')"/>
      <el-table-column prop="pomOrderSerial" label="管理序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomOrderSerial')"/>
      <el-table-column prop="pomMflot" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomMflot')"/>
      <el-table-column prop="pomModelName" label="机种名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomModelName')"/>
      <el-table-column prop="pomMfItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomMfItem')"/>
      <el-table-column prop="pomMfDate" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('pomMfDate')"/>
      <el-table-column prop="pomLineName" label="生产班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomLineName')"/>
      <el-table-column prop="pomDirect" label="直接人数" align="center" v-if="columns.showColumn('pomDirect')"/>
      <el-table-column prop="pomIndirect" label="间接人数" align="center" v-if="columns.showColumn('pomIndirect')"/>
      <el-table-column prop="pomStdTime" label="标准工时" align="center" v-if="columns.showColumn('pomStdTime')"/>
      <el-table-column prop="pomStdOutput" label="标准产能" align="center" v-if="columns.showColumn('pomStdOutput')"/>
      <el-table-column prop="reMark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMark')"/>
      <el-table-column prop="createBy" label="CreateBy" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="CreateTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operate')" width="200">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputmaster:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputmaster:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改oph主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
        
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID" prop="pomId">
              <el-input-number v-model.number="form.pomId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GUID" prop="pomGuid">
              <el-input v-model="form.pomGuid" :placeholder="$t('btn.enter')+'GUID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产工单" prop="pomOrder">
              <el-input v-model="form.pomOrder" :placeholder="$t('btn.enter')+'生产工单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单数量" prop="pomOrderQty">
              <el-input v-model="form.pomOrderQty" :placeholder="$t('btn.enter')+'工单数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="管理序列号" prop="pomOrderSerial">
              <el-input v-model="form.pomOrderSerial" :placeholder="$t('btn.enter')+'管理序列号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="pomMflot">
              <el-input v-model="form.pomMflot" :placeholder="$t('btn.enter')+'生产批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="pomModelName">
              <el-input v-model="form.pomModelName" :placeholder="$t('btn.enter')+'机种名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="pomMfItem">
              <el-input v-model="form.pomMfItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="pomMfDate">
              <el-date-picker v-model="form.pomMfDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')+'生产日期'"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="pomLineName">
              <el-input v-model="form.pomLineName" :placeholder="$t('btn.enter')+'生产班组'" />
            </el-form-item>
          </el-col>
        
          <el-col :lg="12">
            <el-form-item label="直接人数" prop="pomDirect">
              <el-input v-model.number="form.pomDirect" :placeholder="$t('btn.enter')+'直接人数'" />
            </el-form-item>
          </el-col>
        
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="pomIndirect">
              <el-input v-model.number="form.pomIndirect" :placeholder="$t('btn.enter')+'间接人数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准工时" prop="pomStdTime">
              <el-input v-model="form.pomStdTime" :placeholder="$t('btn.enter')+'标准工时'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准产能" prop="pomStdOutput">
              <el-input v-model="form.pomStdOutput" :placeholder="$t('btn.enter')+'标准产能'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF01" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'UDF01'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF02" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'UDF02'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF03" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'UDF03'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF04" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'UDF04'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF05" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'UDF05'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF06" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'UDF06'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF51" prop="uDF51">
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enter')+'UDF51'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF52" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enter')+'UDF52'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF53" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enter')+'UDF53'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF54" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enter')+'UDF54'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF55" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enter')+'UDF55'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF56" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enter')+'UDF56'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :label="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMark">
              <el-input type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateBy" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'CreateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')+'CreateTime'"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateBy" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'UpdateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')+'UpdateTime'"></el-date-picker>
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

<script setup name="ppoutputmaster">
// 引入 ppoutputmaster操作方法
import { listPpOutputMaster,
 addPpOutputMaster, delPpOutputMaster, 
 updatePpOutputMaster,getPpOutputMaster, 
 clearPpOutputMaster,  } 
from '@/api/production/ppoutputmaster.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中pomId数组数组
const ids = ref([])
//加载动画
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
  { visible: true, prop: 'pomId', label: 'ID' },
  { visible: true, prop: 'pomGuid', label: 'GUID' },
  { visible: true, prop: 'pomOrder', label: '生产工单' },
  { visible: true, prop: 'pomOrderQty', label: '工单数量' },
  { visible: true, prop: 'pomOrderSerial', label: '管理序列号' },
  { visible: true, prop: 'pomMflot', label: '生产批次' },
  { visible: true, prop: 'pomModelName', label: '机种名' },
  { visible: true, prop: 'pomMfItem', label: '物料' },
  { visible: false, prop: 'pomMfDate', label: '生产日期' },
  { visible: false, prop: 'pomLineName', label: '生产班组' },
  { visible: false, prop: 'pomDirect', label: '直接人数' },
  { visible: false, prop: 'pomIndirect', label: '间接人数' },
  { visible: false, prop: 'pomStdTime', label: '标准工时' },
  { visible: false, prop: 'pomStdOutput', label: '标准产能' },
  { visible: false, prop: 'reMark', label: '备注' },
  { visible: false, prop: 'createBy', label: 'CreateBy' },
  { visible: false, prop: 'createTime', label: 'CreateTime' },
])
// 总条数
const total = ref(0)
// oph主表表格数据
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

//字典定义

var dictParams = [
]

//获取oph主表表记录数据
function getList(){
  loading.value = true
  listPpOutputMaster(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.pomId);
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
const title = ref('')
// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  single: true,
  multiple: true,
  form: {},
  rules: {
    pomGuid: [{ required: true, message: "GUID"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomOrder: [{ required: true, message: "生产工单"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomOrderQty: [{ required: true, message: "工单数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomOrderSerial: [{ required: true, message: "管理序列号"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomMflot: [{ required: true, message: "生产批次"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomModelName: [{ required: true, message: "机种名"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomMfItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomMfDate: [{ required: true, message: "生产日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomLineName: [{ required: true, message: "生产班组"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomDirect: [{ required: true, message: "直接人数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    pomIndirect: [{ required: true, message: "间接人数"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    pomStdTime: [{ required: true, message: "标准工时"+proxy.$t('btn.empty'), trigger: "blur" }],
    pomStdOutput: [{ required: true, message: "标准产能"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isDeletedOptions: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    pomId: null,
    pomGuid: null,
    pomOrder: null,
    pomOrderQty: null,
    pomOrderSerial: null,
    pomMflot: null,
    pomModelName: null,
    pomMfItem: null,
    pomMfDate: null,
    pomLineName: null,
    pomDirect: null,
    pomIndirect: null,
    pomStdTime: null,
    pomStdOutput: null,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: null,
    uDF52: null,
    uDF53: null,
    uDF54: null,
    uDF55: null,
    uDF56: null,
    isDeleted: null,
    reMark: null,
    createBy: null,
    createTime: null,
    updateBy: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+'oph主表'
  opertype.value = 1
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.pomId || ids.value
  getPpOutputMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'oph主表'
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

      if (form.value.pomId != undefined && opertype.value === 2) {
        updatePpOutputMaster(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpOutputMaster(form.value).then((res) => {
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
  const Ids = row.pomId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpOutputMaster(Ids)
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
      return clearPpOutputMaster()
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
  title.value = proxy.$t('btn.preview')
  opertype.value = 3
  form.value = row
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"oph主表", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpOutputMaster/export', { ...queryParams })
    })
}


handleQuery()
</script>