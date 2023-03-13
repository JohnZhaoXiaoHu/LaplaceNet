<!--
 * @Descripttion: (oph从表/pp_output_slave)
 * @version: (1.0)
 * @Author: (Laplace)
 * @Date: (2022-12-22)
 * @LastEditors: (Laplace)
 * @LastEditTime: (2022-12-22)
-->
<template>
  <div>
    <!-- <div>{{ queryParams }},,,{{ GuidOptions }}999{{ dataList }}</div> -->
    <el-form :model="queryParams" ref="queryForm" :inline="true" label-width="68px">
      <el-form-item label="GUID" prop="pomGuid">
        <el-select clearable v-model="queryParams.pomGuid">
          <el-option v-for="item in GuidOptions" :key="item.pomGuid" :label="item.pomGuid" :value="item.pomGuid">

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
        <el-button color="#409EFF" v-hasPermi="['pp:output:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>

    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="452" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <!-- <el-table-column prop="pomGuid" label="父GUID" align="center" /> -->
      <el-table-column prop="posStartEndTime" label="生产时段" align="center">
      </el-table-column>
      <el-table-column prop="posRealOutput" label="实际产能" align="center" />
      <el-table-column prop="posLineStopTime" label="停线时间" align="center" />
      <el-table-column prop="posStopCause" label="停线原因" align="center">
      </el-table-column>
      <el-table-column prop="posStopMemo" label="停线说明" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="posBadCause" label="不良原因" align="center">
      </el-table-column>
      <el-table-column prop="posBadMemo" label="不良说明" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="posRealTime" label="实际工数" align="center" />
      <el-table-column prop="posRealWork" label="实际工时" align="center" />
      <el-table-column prop="posRealWorkDiff" label="工时差异" align="center" />
      <el-table-column prop="posRealOutputDiff" label="产能差异" align="center" />
      <el-table-column prop="posAchRatio" label="达成率" align="center" />
      <el-table-column label="操作" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:output:edit']" type="success" icon="edit" title="编辑"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:output:delete']" type="danger" icon="delete" title="删除"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改oph从表对话框 -->
    <el-dialog :title="title" v-model="open" draggable append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="24">
            <el-form-item label="父GUID">
              <el-input v-model="form.pomGuid" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产时段" prop="posStartEndTime">
              <el-select v-model="form.posStartEndTime" placeholder="请选择生产时段">
                <el-option v-for="item in  options.sys_productive_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="实际产能" prop="posRealOutput">
              <el-input-number v-model.number="form.posRealOutput" controls-position="right" placeholder="请输入实际产能" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="停线时间" prop="posLineStopTime">
              <el-input-number v-model.number="form.posLineStopTime" controls-position="right" placeholder="请输入停线时间" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="停线原因" prop="posStopCause">
              <el-select v-model="form.posStopCause" placeholder="请选择停线原因">
                <el-option v-for="item in  options.sql_stop_line " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="停线说明" prop="posStopMemo">
              <el-input v-model="form.posStopMemo" placeholder="请输入停线说明" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="未达成原因" prop="posBadCause">
              <el-select v-model="form.posBadCause" placeholder="请选择未达成原因">
                <el-option v-for="item in  options.sql_notreachebad_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="未达成说明" prop="posBadMemo">
              <el-input v-model="form.posBadMemo" placeholder="请输入未达成说明" />
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

<script setup name="OutputData">
  // 引入 ppoutputslave操作方法
  import {
    listPpOutputSlave, addPpOutputSlave, delPpOutputSlave, updatePpOutputSlave, getPpOutputSlave,

  }
    from '@/api/production/ppoutputslave.js'
  // 引入 ppoutputmaster操作方法
  import {
    listPpOutputMaster, getPpOutputMaster,
  }
    from '@/api/production/ppoutputmaster.js'

  import {
    listPpOutputMasterAll,

  }

    from '@/api/production/ppoutputmasterall.js'
  const { proxy } = getCurrentInstance()
  const props = defineProps({
    pomId: {
      type: Number,
      default: 0
    }
  })
  watch(
    () => props.pomId,
    (newVal, oldValue) => {
      if (newVal) {
        getGuidInfo(newVal)
        getGuidList()
      }
    },
    {
      immediate: true,
      deep: true
    }
  )

  // 选中posId数组数组
  const ids = ref([])
  // 非单选禁用
  const single = ref(true)
  // 类型数据字典
  const GuidOptions = ref([])
  // 默认GUID
  const defaultOutputGuid = ref('')
  // 非多个禁用
  const multiple = ref(true)
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 15,
    sort: undefined,
    sortType: undefined,
    pomGuid: undefined,
  })
  //默认显示字段 
  const columns = ref([

    { visible: true, prop: 'pomGuid', label: '父GUID' },
    { visible: true, prop: 'posStartEndTime', label: '生产时段' },
    { visible: true, prop: 'posRealOutput', label: '实际产能' },
    { visible: true, prop: 'posLineStopTime', label: '停线时间' },
    { visible: true, prop: 'posStopCause', label: '停线原因' },
    { visible: true, prop: 'posStopMemo', label: '停线说明' },
    { visible: true, prop: 'posBadCause', label: '不良原因' },
    { visible: false, prop: 'posBadMemo', label: '不良说明' },
    { visible: false, prop: 'posRealTime', label: '实际工数' },
    { visible: false, prop: 'posRealWork', label: '实际工时' },
    { visible: false, prop: 'posRealWorkDiff', label: '工时差异' },
    { visible: false, prop: 'posRealOutputDiff', label: '产能差异' },
    { visible: false, prop: 'posAchRatio', label: '达成率' },

  ])
  const title = ref("")
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
  const open = ref(false)
  const state = reactive({
    form: {},
    rules: {
      pomGuid: [{ required: true, message: "父GUID不能为空", trigger: "blur" }],
      posRealOutput: [{ required: true, message: "实际产能不能为空", trigger: "blur", type: "number" }],
      posLineStopTime: [{ required: true, message: "停线时间不能为空", trigger: "blur", type: "number" }],
      posRealTime: [{ required: true, message: "实际工数不能为空", trigger: "blur", type: "number" }],
      posRealWork: [{ required: true, message: "实际工时不能为空", trigger: "blur" }],
      posRealWorkDiff: [{ required: true, message: "工时差异不能为空", trigger: "blur" }],
      posRealOutputDiff: [{ required: true, message: "产能差异不能为空", trigger: "blur", type: "number" }],
      posAchRatio: [{ required: true, message: "达成率不能为空", trigger: "blur", type: "number" }],

    },
    options: {
      //  父GUID 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      //sql_oph_list: [],
      //  生产时段 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_productive_list: [],
      //  停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_stop_line: [],
      //  不良原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_notreachebad_list: [],

    }
  })

  const { form, rules, options } = toRefs(state)
  const total = ref(0)
  const dataList = ref([])
  //const queryForm = ref()
  const formRef = ref()
  var dictParams = [
    //{ dictType: "sql_oph_list" },
    { dictType: "sys_productive_list" },
    { dictType: "sql_stop_line" },
    { dictType: "sql_notreachebad_list" },
  ]

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })

  /** 查询OPH列表 */
  function getGuidList() {
    listPpOutputMasterAll().then((response) => {
      GuidOptions.value = response.data.result
    })
  }
  /** 查询oph Guid详细 */
  function getGuidInfo(pomId) {
    getPpOutputMaster(pomId).then((response) => {
      queryParams.pomGuid = response.data.pomGuid
      defaultOutputGuid.value = response.data.pomGuid
      getList()
    })
  }
  function getList() {
    loading.value = true
    listPpOutputSlave(queryParams).then((response) => {
      dataList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      pomGuid: queryParams.pomGuid,
      posStartEndTime: undefined,
      posRealOutput: undefined,
      posLineStopTime: undefined,
      posStopCause: undefined,
      posStopMemo: undefined,
      posBadCause: undefined,
      posBadMemo: undefined,
      posRealTime: undefined,
      posRealWork: undefined,
      posRealWorkDiff: undefined,
      posRealOutputDiff: undefined,
      posAchRatio: undefined,
      uDF01: undefined,
      uDF02: undefined,
      uDF03: undefined,
      uDF04: undefined,
      uDF05: undefined,
      uDF06: undefined,
      uDF51: undefined,
      uDF52: undefined,
      uDF53: undefined,
      uDF54: undefined,
      uDF55: undefined,
      uDF56: undefined,
      isDeleted: undefined,
      reMark: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
    };
    proxy.resetForm("formRef")
  }

  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  // 添加
  function handleAdd() {
    reset();
    open.value = true
    title.value = '添加'
    form.value.pomGuid = queryParams.pomGuid
    form.value.posRealOutput = 0
    form.value.posLineStopTime = 0
    //form.value.pomGuid = defaultOutputGuid.value
    opertype.value = 1

  }

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.posId || ids.value

    proxy.$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
      .then(function () {
        return delPpOutputSlave(Ids)
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess("删除成功")
      })
      .catch(() => { })
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.posId || ids.value
    getPpOutputSlave(id).then((res) => {
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

  // 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {
        if (form.value.posId != undefined && opertype.value === 2) {
          updatePpOutputSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess("修改成功")
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpOutputSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
            open.value = false
            getList()
          })
            .catch((err) => {
              //TODO 错误逻辑
            })
        }
      }
    })
  }

  // 重置查询操作
  function resetQuery() {
    proxy.resetForm("queryForm")
    queryParams.pomGuid = defaultOutputGuid.value
    handleQuery()
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm("是否确认导出所有oph从表数据项?", "警告", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
      .then(function () {
        return exportPpOutputSlave(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.posId);
    single.value = selection.length != 1
    multiple.value = !selection.length;
  }

  // 自定义排序
  function sortChange(column) {
    if (column.prop == null || column.order == null) {
      queryParams.sort = undefined
      queryParams.sortType = undefined
    } else {
      queryParams.sort = column.prop
      queryParams.sortType = column.order
    }

    handleQuery()
  }

  handleQuery()
</script>