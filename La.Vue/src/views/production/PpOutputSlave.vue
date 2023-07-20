<!--
 * @Descripttion: (oph从表/pp_output_slave)
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
        <el-button type="primary" v-hasPermi="['pp:outputslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputslave:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputslave:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" v-hasPermi="['pp:outputslave:delete']" plain icon="delete" @click="handleClear">
          {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputslave:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:outputslave:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" v-loading="loading" ref="table" border header-cell-class-name="el-table-header-cell"
      highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="posId" label="ID" align="center" v-if="columns.showColumn('posId')" />
      <el-table-column prop="pomGuid" label="父GUID" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomGuid')" />
      <el-table-column prop="posStartEndTime" label="生产时段" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('posStartEndTime')" />
      <el-table-column prop="posRealOutput" label="实际产能" align="center" v-if="columns.showColumn('posRealOutput')" />
      <el-table-column prop="posLineStopTime" label="停线时间" align="center"
        v-if="columns.showColumn('posLineStopTime')" />
      <el-table-column prop="posStopCause" label="停线原因" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('posStopCause')" />
      <el-table-column prop="posStopMemo" label="停线说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('posStopMemo')" />
      <el-table-column prop="posBadCause" label="未达成原因" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('posBadCause')" />
      <el-table-column prop="posBadMemo" label="未达成说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('posBadMemo')" />
      <el-table-column prop="posRealTime" label="实际工数" align="center" v-if="columns.showColumn('posRealTime')" />
      <el-table-column prop="posRealWork" label="实际工时" align="center" v-if="columns.showColumn('posRealWork')" />
      <el-table-column prop="posRealWorkDiff" label="工时差异" align="center"
        v-if="columns.showColumn('posRealWorkDiff')" />
      <el-table-column prop="posRealOutputDiff" label="产能差异" align="center"
        v-if="columns.showColumn('posRealOutputDiff')" />
      <el-table-column prop="posAchRatio" label="达成率" align="center" v-if="columns.showColumn('posAchRatio')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="CreateBy" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="CreateTime" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column :label="$t('btn.operate')" width="200">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputslave:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:outputslave:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />


    <!-- 添加或修改oph从表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID" prop="posId">
              <el-input-number v-model.number="form.posId" controls-position="right" :placeholder="$t('btn.enter')+'ID'"
                :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="父GUID" prop="pomGuid">
              <el-input v-model="form.pomGuid" :placeholder="$t('btn.enter')+'父GUID'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产时段" prop="posStartEndTime">
              <el-input v-model="form.posStartEndTime" :placeholder="$t('btn.enter')+'生产时段'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际产能" prop="posRealOutput">
              <el-input v-model.number="form.posRealOutput" :placeholder="$t('btn.enter')+'实际产能'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线时间" prop="posLineStopTime">
              <el-input v-model.number="form.posLineStopTime" :placeholder="$t('btn.enter')+'停线时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线原因" prop="posStopCause">
              <el-input v-model="form.posStopCause" :placeholder="$t('btn.enter')+'停线原因'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线说明" prop="posStopMemo">
              <el-input v-model="form.posStopMemo" :placeholder="$t('btn.enter')+'停线说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成原因" prop="posBadCause">
              <el-input v-model="form.posBadCause" :placeholder="$t('btn.enter')+'未达成原因'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成说明" prop="posBadMemo">
              <el-input v-model="form.posBadMemo" :placeholder="$t('btn.enter')+'未达成说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际工数" prop="posRealTime">
              <el-input v-model.number="form.posRealTime" :placeholder="$t('btn.enter')+'实际工数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际工时" prop="posRealWork">
              <el-input v-model="form.posRealWork" :placeholder="$t('btn.enter')+'实际工时'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时差异" prop="posRealWorkDiff">
              <el-input v-model="form.posRealWorkDiff" :placeholder="$t('btn.enter')+'工时差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产能差异" prop="posRealOutputDiff">
              <el-input v-model="form.posRealOutputDiff" :placeholder="$t('btn.enter')+'产能差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="达成率" prop="posAchRatio">
              <el-input v-model.number="form.posAchRatio" :placeholder="$t('btn.enter')+'达成率'" />
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

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateBy" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'CreateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.select')+'CreateTime'"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateBy" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'UpdateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.select')+'UpdateTime'"></el-date-picker>
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

<script setup name="ppoutputslave">
  // 引入 ppoutputslave操作方法
  import {
    listPpOutputSlave,
    addPpOutputSlave, delPpOutputSlave,
    updatePpOutputSlave, getPpOutputSlave,
    clearPpOutputSlave,
  }
    from '@/api/production/ppoutputslave.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中posId数组数组
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
    { visible: true, prop: 'posId', label: 'ID' },
    { visible: true, prop: 'pomGuid', label: '父GUID' },
    { visible: true, prop: 'posStartEndTime', label: '生产时段' },
    { visible: true, prop: 'posRealOutput', label: '实际产能' },
    { visible: true, prop: 'posLineStopTime', label: '停线时间' },
    { visible: true, prop: 'posStopCause', label: '停线原因' },
    { visible: true, prop: 'posStopMemo', label: '停线说明' },
    { visible: true, prop: 'posBadCause', label: '未达成原因' },
    { visible: false, prop: 'posBadMemo', label: '未达成说明' },
    { visible: false, prop: 'posRealTime', label: '实际工数' },
    { visible: false, prop: 'posRealWork', label: '实际工时' },
    { visible: false, prop: 'posRealWorkDiff', label: '工时差异' },
    { visible: false, prop: 'posRealOutputDiff', label: '产能差异' },
    { visible: false, prop: 'posAchRatio', label: '达成率' },
    { visible: false, prop: 'remark', label: '说明' },
    { visible: false, prop: 'createBy', label: 'CreateBy' },
    { visible: false, prop: 'createTime', label: 'CreateTime' },
  ])
  // 总条数
  const total = ref(0)
  // oph从表表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  //字典定义

  var dictParams = [
  ]

  //获取oph从表表记录数据
  function getList() {
    loading.value = true
    listPpOutputSlave(queryParams).then(res => {
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
  function resetQuery() {
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.posId);
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
      pomGuid: [{ required: true, message: "父GUID" + proxy.$t('btn.empty'), trigger: "blur" }],
      posRealOutput: [{ required: true, message: "实际产能" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      posLineStopTime: [{ required: true, message: "停线时间" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      posRealTime: [{ required: true, message: "实际工数" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      posRealWork: [{ required: true, message: "实际工时" + proxy.$t('btn.empty'), trigger: "blur" }],
      posRealWorkDiff: [{ required: true, message: "工时差异" + proxy.$t('btn.empty'), trigger: "blur" }],
      posRealOutputDiff: [{ required: true, message: "产能差异" + proxy.$t('btn.empty'), trigger: "blur" }],
      posAchRatio: [{ required: true, message: "达成率" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      isDeletedOptions: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      posId: null,
      pomGuid: null,
      posStartEndTime: null,
      posRealOutput: null,
      posLineStopTime: null,
      posStopCause: null,
      posStopMemo: null,
      posBadCause: null,
      posBadMemo: null,
      posRealTime: null,
      posRealWork: null,
      posRealWorkDiff: null,
      posRealOutputDiff: null,
      posAchRatio: null,
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
      remark: null,
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
    title.value = proxy.$t('btn.add') + 'oph从表'
    opertype.value = 1
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.posId || ids.value
    getPpOutputSlave(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + 'oph从表'
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

        if (form.value.posId != undefined && opertype.value === 2) {
          updatePpOutputSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpOutputSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        }
      }
    })
  }

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.posId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPpOutputSlave(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }

  // 清空
  function handleClear() {
    proxy
      .$confirm(proxy.$t('common.confirmClean'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return clearPpOutputSlave()
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
      .$confirm(proxy.$t('common.confirmExport') + "oph从表", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/production/PpOutputSlave/export', { ...queryParams })
      })
  }


  handleQuery()
</script>