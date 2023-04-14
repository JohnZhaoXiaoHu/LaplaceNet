<!--
 * @Descripttion: (从源设变/pp_ec_slv_source)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-13)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-13)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="设变No." prop="dSapZpabdS001">
        <el-input clearable v-model="queryParams.dSapZpabdS001" :placeholder="$t('btn.enter')+'设变No.'" />
      </el-form-item>
      <el-form-item label="完成品" prop="dSapZpabdS002">
        <el-input clearable v-model="queryParams.dSapZpabdS002" :placeholder="$t('btn.enter')+'完成品'" />
      </el-form-item>
      <el-form-item label="上阶" prop="dSapZpabdS003">
        <el-input clearable v-model="queryParams.dSapZpabdS003" :placeholder="$t('btn.enter')+'上阶'" />
      </el-form-item>
      <el-form-item label="旧物料" prop="dSapZpabdS004">
        <el-input clearable v-model="queryParams.dSapZpabdS004" :placeholder="$t('btn.enter')+'旧物料'" />
      </el-form-item>
      <el-form-item label="新物料" prop="dSapZpabdS008">
        <el-input clearable v-model="queryParams.dSapZpabdS008" :placeholder="$t('btn.enter')+'新物料'" />
      </el-form-item>
      <el-form-item label="处理标记" prop="isSolved">
        <el-select filterable clearable  v-model="queryParams.isSolved" :placeholder="$t('btn.select')+'处理标记'">
          <el-option v-for="item in  options.sys_sop_yn " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['pp:ecslvsource:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecslvsource:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecslvsource:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['pp:ecslvsource:delete']" plain icon="delete" @click="handleClear">
         {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:ecslvsource:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslvsource:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="guid" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('guid')"/>
      <el-table-column prop="dSapZpabdS001" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS001')"/>
      <el-table-column prop="dSapZpabdS002" label="完成品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS002')"/>
      <el-table-column prop="dSapZpabdS003" label="上阶" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS003')"/>
      <el-table-column prop="dSapZpabdS004" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS004')"/>
      <el-table-column prop="dSapZpabdS005" label="品名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS005')"/>
      <el-table-column prop="dSapZpabdS006" label="数量" align="center" v-if="columns.showColumn('dSapZpabdS006')"/>
      <el-table-column prop="dSapZpabdS007" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS007')"/>
      <el-table-column prop="dSapZpabdS008" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS008')"/>
      <el-table-column prop="dSapZpabdS009" label="品名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS009')"/>
      <el-table-column prop="dSapZpabdS010" label="数量" align="center" v-if="columns.showColumn('dSapZpabdS010')"/>
      <el-table-column prop="dSapZpabdS011" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS011')"/>
      <el-table-column prop="dSapZpabdS012" label="BOM番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS012')"/>
      <el-table-column prop="dSapZpabdS013" label="互换性" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS013')"/>
      <el-table-column prop="dSapZpabdS014" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS014')"/>
      <el-table-column prop="dSapZpabdS015" label="安排指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS015')"/>
      <el-table-column prop="dSapZpabdS016" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS016')"/>
      <el-table-column prop="dSapZpabdS017" label="BOM生效" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dSapZpabdS017')"/>
      <el-table-column prop="isSolved" label="处理标记" align="center" v-if="columns.showColumn('isSolved')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.isSolved" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecslvsource:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecslvsource:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改从源设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="guid">
              <el-input clearable v-model="form.guid" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="设变No." prop="dSapZpabdS001">
              <el-input clearable v-model="form.dSapZpabdS001" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完成品" prop="dSapZpabdS002">
              <el-input clearable v-model="form.dSapZpabdS002" :placeholder="$t('btn.enter')+'完成品'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上阶" prop="dSapZpabdS003">
              <el-input clearable v-model="form.dSapZpabdS003" :placeholder="$t('btn.enter')+'上阶'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="dSapZpabdS004">
              <el-input clearable v-model="form.dSapZpabdS004" :placeholder="$t('btn.enter')+'旧物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品名" prop="dSapZpabdS005">
              <el-input clearable v-model="form.dSapZpabdS005" :placeholder="$t('btn.enter')+'品名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dSapZpabdS006">
              <el-input-number clearable v-model.number="form.dSapZpabdS006" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="dSapZpabdS007">
              <el-input clearable v-model="form.dSapZpabdS007" :placeholder="$t('btn.enter')+'位置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="dSapZpabdS008">
              <el-input clearable v-model="form.dSapZpabdS008" :placeholder="$t('btn.enter')+'新物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品名" prop="dSapZpabdS009">
              <el-input clearable v-model="form.dSapZpabdS009" :placeholder="$t('btn.enter')+'品名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dSapZpabdS010">
              <el-input-number clearable v-model.number="form.dSapZpabdS010" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="dSapZpabdS011">
              <el-input clearable v-model="form.dSapZpabdS011" :placeholder="$t('btn.enter')+'位置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BOM番号" prop="dSapZpabdS012">
              <el-input clearable v-model="form.dSapZpabdS012" :placeholder="$t('btn.enter')+'BOM番号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换性" prop="dSapZpabdS013">
              <el-input clearable v-model="form.dSapZpabdS013" :placeholder="$t('btn.enter')+'互换性'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="dSapZpabdS014">
              <el-input clearable v-model="form.dSapZpabdS014" :placeholder="$t('btn.enter')+'区分'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安排指示" prop="dSapZpabdS015">
              <el-input clearable v-model="form.dSapZpabdS015" :placeholder="$t('btn.enter')+'安排指示'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="dSapZpabdS016">
              <el-input clearable v-model="form.dSapZpabdS016" :placeholder="$t('btn.enter')+'旧品处理'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BOM生效" prop="dSapZpabdS017">
              <el-date-picker clearable v-model="form.dSapZpabdS017" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标记" prop="isSolved">
              <el-radio-group v-model="form.isSolved">
                <el-radio v-for="item in  options.sys_sop_yn " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number clearable v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'" :disabled="true"/>
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

<script setup name="ppecslvsource">
// 引入 ppecslvsource操作方法
import { listPpEcSlvSource, addPpEcSlvSource, delPpEcSlvSource, updatePpEcSlvSource, getPpEcSlvSource, 
 clearPpEcSlvSource,  
 } 
from '@/api/production/ppecslvsource.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中guid数组数组
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
  dSapZpabdS001: undefined,
  dSapZpabdS002: undefined,
  dSapZpabdS003: undefined,
  dSapZpabdS004: undefined,
  dSapZpabdS008: undefined,
  isSolved: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'guid', label: 'ID' },
  { visible: true, prop: 'dSapZpabdS001', label: '设变No.' },
  { visible: true, prop: 'dSapZpabdS002', label: '完成品' },
  { visible: true, prop: 'dSapZpabdS003', label: '上阶' },
  { visible: true, prop: 'dSapZpabdS004', label: '旧物料' },
  { visible: true, prop: 'dSapZpabdS005', label: '品名' },
  { visible: true, prop: 'dSapZpabdS006', label: '数量' },
  { visible: true, prop: 'dSapZpabdS007', label: '位置' },
  { visible: false, prop: 'dSapZpabdS008', label: '新物料' },
  { visible: false, prop: 'dSapZpabdS009', label: '品名' },
  { visible: false, prop: 'dSapZpabdS010', label: '数量' },
  { visible: false, prop: 'dSapZpabdS011', label: '位置' },
  { visible: false, prop: 'dSapZpabdS012', label: 'BOM番号' },
  { visible: false, prop: 'dSapZpabdS013', label: '互换性' },
  { visible: false, prop: 'dSapZpabdS014', label: '区分' },
  { visible: false, prop: 'dSapZpabdS015', label: '安排指示' },
  { visible: false, prop: 'dSapZpabdS016', label: '旧品处理' },
  { visible: false, prop: 'dSapZpabdS017', label: 'BOM生效' },
  { visible: false, prop: 'isSolved', label: '处理标记' },
])
  // 总条数
const total = ref(0)
  // 从源设变表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_sop_yn" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取从源设变表记录数据
function getList(){
  loading.value = true
  listPpEcSlvSource(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.guid);
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
    guid: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    dSapZpabdS006: [{ required: true, message: "数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    dSapZpabdS010: [{ required: true, message: "数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    isSolved: [{ required: true, message: "处理标记"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 处理标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_sop_yn: [],
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
    guid: undefined,
    dSapZpabdS001: undefined,
    dSapZpabdS002: undefined,
    dSapZpabdS003: undefined,
    dSapZpabdS004: undefined,
    dSapZpabdS005: undefined,
    dSapZpabdS006: undefined,
    dSapZpabdS007: undefined,
    dSapZpabdS008: undefined,
    dSapZpabdS009: undefined,
    dSapZpabdS010: undefined,
    dSapZpabdS011: undefined,
    dSapZpabdS012: undefined,
    dSapZpabdS013: undefined,
    dSapZpabdS014: undefined,
    dSapZpabdS015: undefined,
    dSapZpabdS016: undefined,
    dSapZpabdS017: undefined,
    isSolved: undefined,
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
  const id = row.guid || ids.value
  getPpEcSlvSource(id).then((res) => {
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
      if (form.value.guid != undefined && opertype.value === 2) {
        updatePpEcSlvSource(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpEcSlvSource(form.value).then((res) => {
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
  const Ids = row.guid || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpEcSlvSource(Ids)
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
      return clearPpEcSlvSource()
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
    .$confirm(proxy.$t('common.confirmExport')+"从源设变", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Production/PpEcSlvSource/export', { ...queryParams })
    })
}

handleQuery()
</script>