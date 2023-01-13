<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @version: (1.0)
 * @Author: (Laplace)
 * @Date: (2022-12-20)
 * @LastEditors: (Laplace)
 * @LastEditTime: (2022-12-20)
-->
<template>
  <div>
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="68px">
      <el-form-item label="生产工单" prop="pomOrder">
        <el-select clearable v-model="queryParams.pomOrder" placeholder="请选择生产工单">
          <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产批次" prop="pomMflot">
        <el-select clearable v-model="queryParams.pomMflot" placeholder="请选择生产批次">
          <el-option v-for="item in  options.sql_lot_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种名" prop="pomModelName">
        <el-select clearable v-model="queryParams.pomModelName" placeholder="请选择机种名">
          <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="pomMfItem">
        <el-select clearable v-model="queryParams.pomMfItem" placeholder="请选择物料">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker v-model="dateRangePomMfDate" style="width: 240px" type="daterange" range-separator="-"
          start-placeholder="开始日期" end-placeholder="结束日期" placeholder="请选择生产日期" value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime" :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产班组" prop="pomLineName">
        <el-select clearable v-model="queryParams.pomLineName" placeholder="请选择生产班组">
          <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
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
        <el-button color="#409EFF" v-hasPermi="['pp:output:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#67C23A" :disabled="single" v-hasPermi="['pp:output:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#F56C6C" :disabled="multiple" v-hasPermi="['pp:output:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#E6A23C" plain icon="download" @click="handleExport" v-hasPermi="['pp:output:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column label="OPH编号" align="center" prop="pomId" width="100" />
      <el-table-column label="GUID" align="center" :show-overflow-tooltip="true">
        <template #default="scope">
          <el-link type="primary" @click="showOutputData(scope.row)">{{ scope.row.pomGuid }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="pomOrder" label="生产工单" align="center">
        <template #default="scope">
          <el-input placeholder="请输入内容" v-show="scope.row.show" v-model="scope.row.pomOrder"></el-input>
          <span v-show="!scope.row.show">{{ scope.row.pomOrder }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="pomOrderQty" label="工单数量" align="center" />
      <el-table-column prop="pomOrderSerial" label="管理序列号" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="pomMflot" label="生产批次" align="center">
      </el-table-column>
      <el-table-column prop="pomModelName" label="机种名" align="center">
      </el-table-column>
      <el-table-column prop="pomMfItem" label="物料" align="center">
      </el-table-column>
      <el-table-column prop="pomMfDate" label="生产日期" align="center" :show-overflow-tooltip="true">
        <template #default="scope">
          {{ proxy.$filters.timeFormat(scope.row.pomMfDate) }}
        </template>
      </el-table-column>
      <el-table-column prop="pomLineName" label="生产班组" align="center">
      </el-table-column>
      <el-table-column prop="pomDirect" label="直接人数" align="center" />
      <el-table-column prop="pomIndirect" label="间接人数" align="center" />
      <el-table-column prop="pomStdTime" label="标准工时" align="center" />
      <el-table-column prop="pomStdOutput" label="标准产能" align="center" />
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

    <!-- 添加或修改oph主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="24">
            <el-form-item label="生产工单" prop="pomOrder">
              <el-select clearable filterable v-model="form.pomOrder" placeholder="请选择生产工单" @change="SelAssignment">
                <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单数量" prop="pomOrderQty">
              <el-input-number v-model.number="form.pomOrderQty" controls-position="right" placeholder="请输入工单数量"
                disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="管理序列号" prop="pomOrderSerial">
              <el-input v-model="form.pomOrderSerial" placeholder="请输入管理序列号" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="pomMflot">
              <el-select v-model="form.pomMflot" placeholder="请选择生产批次" disabled>
                <el-option v-for="item in  options.sql_lot_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="pomModelName">
              <el-select v-model="form.pomModelName" placeholder="请选择机种名" disabled>
                <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="pomMfItem">
              <el-select v-model="form.pomMfItem" placeholder="请选择物料" disabled>
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="标准工时" prop="pomStdTime">
              <el-input-number v-model.number="form.pomStdTime" controls-position="right" placeholder="请输入标准工时"
                disabled />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label="GUID" prop="pomGuid">
              <el-input v-model="form.pomGuid" placeholder="请输入GUID" disabled />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="生产日期" prop="pomMfDate">
              <el-date-picker v-model="form.pomMfDate" type="datetime" :teleported="false"
                placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="pomLineName" width="300">
              <el-select v-model="form.pomLineName" placeholder="请选择生产班组">
                <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="直接人数" prop="pomDirect">
              <el-input-number v-model.number="form.pomDirect" controls-position="right" placeholder="请输入直接人数" :min="1"
                :max="25" @input="CalculateStdOutput" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="标准产能" prop="pomStdOutput">
              <el-input-number v-model.number="form.pomStdOutput" controls-position="right" disabled />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="pomIndirect">
              <el-input-number v-model.number="form.pomIndirect" controls-position="right" placeholder="请输入间接人数"
                :min="0" :max="10" />
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
    <el-dialog v-model="outputDataVisible" draggable width="60%" :lock-scroll="false">
      <output-data v-model:pomId="pomId"></output-data>
    </el-dialog>
  </div>
</template>

<script setup name="ppoutputmaster">
  import outputData from '@/views/components/outputData'
  import {
    listPpOutputMaster, addPpOutputMaster, delPpOutputMaster, updatePpOutputMaster, getPpOutputMaster,

  }
    from '@/api/production/ppoutputmaster.js'
  //uuid，guid函数
  import { v4 as uuidv4 } from 'uuid'
  //日期格式化函数
  import { getCurrentTime } from '@/utils/date'
  //组合式API
  const { proxy } = getCurrentInstance()
  // 遮罩层
  const loading = ref(false)
  // 非单选禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 选中pomId数组数组
  const ids = ref([])
  // 总条数
  const total = ref(0)
  // 显示搜索条件
  const showSearch = ref(true)
  // OPH实绩弹出层
  const outputDataVisible = ref(false)

  // oph Id传值给子组件
  const pomId = ref(0)
  // 是否显示弹出层
  const open = ref(false)
  const state = reactive({
    form: {},
    rules: {
      pomGuid: [{ required: true, message: "GUID不能为空", trigger: "blur" }],
      pomOrder: [{ required: true, message: "生产工单不能为空", trigger: "change" }],
      pomOrderQty: [{ required: true, message: "工单数量不能为空", trigger: "blur" }],
      pomOrderSerial: [{ required: true, message: "管理序列号不能为空", trigger: "blur" }],
      pomMflot: [{ required: true, message: "生产批次不能为空", trigger: "change" }],
      pomModelName: [{ required: true, message: "机种名不能为空", trigger: "change" }],
      pomMfItem: [{ required: true, message: "物料不能为空", trigger: "change" }],
      pomMfDate: [{ required: true, message: "生产日期不能为空", trigger: "blur" }],
      pomLineName: [{ required: true, message: "生产班组不能为空", trigger: "change" }],
      pomDirect: [{ required: true, message: "直接人数不能为空", trigger: "blur", type: "number" }],
      pomIndirect: [{ required: true, message: "间接人数不能为空", trigger: "blur", type: "number" }],
      pomStdTime: [{ required: true, message: "标准工时不能为空", trigger: "blur" }],
      pomStdOutput: [{ required: true, message: "标准产能不能为空", trigger: "blur" }],
    },
    options: {
      //  生产工单 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_list: [],
      //  生产批次 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_lot_list: [],
      //  机种名 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_model: [],
      //  物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
      //  生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_list: [],
      //  软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      isDeletedOptions: [],
    },
    queryParams: {
      pageNum: 1,
      pageSize: 10,
      sort: undefined,
      sortType: undefined,
      pomOrder: undefined,
      pomMflot: undefined,
      pomModelName: undefined,
      pomMfItem: undefined,
      pomMfDate: undefined,
      pomLineName: undefined,
    }
  })
  const { form, rules, options, queryParams } = toRefs(state)
  //报表默认显示字段
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
  ])
  // 弹出层标题
  const title = ref("")
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)

  //
  const dataList = ref([])
  //ref属性
  const queryRef = ref()
  // 查询参数
  const formRef = ref()
  // 生产日期时间范围
  const dateRangePomMfDate = ref([])

  var dictParams = [
    { dictType: "sql_moc_list" },
    { dictType: "sql_lot_list" },
    { dictType: "sql_moc_model" },
    { dictType: "sql_moc_item" },
    { dictType: "sql_line_list" },
  ]

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  function getList() {

    loading.value = true
    listPpOutputMaster(proxy.addDateRange(queryParams.value, dateRangePomMfDate.value, 'PomMfDate')).then((response) => {
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
      pomGuid: undefined,
      pomOrder: undefined,
      pomOrderQty: undefined,
      pomOrderSerial: undefined,
      pomMflot: undefined,
      pomModelName: undefined,
      pomMfItem: undefined,
      pomMfDate: undefined,
      pomLineName: undefined,
      pomDirect: undefined,
      pomIndirect: undefined,
      pomStdTime: undefined,
      pomStdOutput: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
    };
    proxy.resetForm("formRef")
  }

  // 查询
  function handleQuery() {
    queryParams.value.pageNum = 1
    getList()
  }
  const onInit = () => {
    dataList.value.push({
      pomGuid: undefined,
      pomOrder: undefined,
      pomOrderQty: undefined,
      pomOrderSerial: undefined,
      pomMflot: undefined,
      pomModelName: undefined,
      pomMfItem: undefined,
      pomMfDate: undefined,
      pomLineName: undefined,
      pomDirect: undefined,
      pomIndirect: undefined,
      pomStdTime: undefined,
      pomStdOutput: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
    })
  }
  //计算标准产量保留两位小数(直接人数*单位时间(60分钟)/标准工时(st)*效率(0.85)),parseFloat().toFixed(2)保留小数位
  //计算计划产出(标准产能)
  function CalculateStdOutput(val) {

    if (form.value.pomStdTime != undefined && form.value.pomStdTime != null && form.value.pomStdTime != 0) {
      form.value.pomStdOutput = parseFloat(Number(val) * 60 / Number(form.value.pomStdTime) * 0.85).toFixed(2)
    }
    else {
      form.value.pomStdOutput = 0
    }
  }
  //select选择框，赋值到其它文本框。split(",")分割数组，slice()截取，.join()转字符串parseFloat().toFixed(2)保留小数位
  function SelAssignment(val) {
    //赋值给文本框
    form.value.pomGuid = uuidv4()
    form.value.pomOrder = val.split(",").slice(0, 1).join()
    form.value.pomOrderQty = val.split(",").slice(3, 4).join()
    form.value.pomOrderSerial = val.split(",").slice(4, 5).join()
    form.value.pomMflot = val.split(",").slice(2, 3).join()
    form.value.pomModelName = val.split(",").slice(5, 6).join()
    form.value.pomMfItem = val.split(",").slice(1, 2).join()
    form.value.pomStdTime = val.split(",").slice(-1).join()
    form.value.pomMfDate = getCurrentTime()
    //计算计划产出(标准产能)
    //判断直接人数
    if (form.value.pomDirect != undefined && form.value.pomDirect != null && form.value.pomDirect != 0) {
      form.value.pomStdOutput = parseFloat(Number(form.value.pomDirect) * 60 / Number(val.split(",").slice(-1).join()) * 0.85).toFixed(2)
    }
    else {
      form.value.pomStdOutput = 0
    }
    form.value.pomIndirect = 0

  }
  // 添加
  function handleAdd() {
    reset();
    open.value = true
    title.value = '添加'
    opertype.value = 1
  }

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.pomId || ids.value

    proxy.$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
      .then(function () {
        return delPpOutputMaster(Ids)
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
    const id = row.pomId || ids.value
    getPpOutputMaster(id).then((res) => {
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
        if (form.value.pomId != undefined && opertype.value === 2) {
          updatePpOutputMaster(form.value).then((res) => {
            proxy.$modal.msgSuccess("修改成功")
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpOutputMaster(form.value).then((res) => {
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
    // 生产日期时间范围
    dateRangePomMfDate.value = []
    proxy.resetForm("queryForm")
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
    if (column.prop == null || column.order == null) {
      queryParams.sort = undefined
      queryParams.sortType = undefined
    } else {
      queryParams.sort = column.prop
      queryParams.sortType = column.order
    }

    handleQuery()
  }
  function showOutputData(row) {
    pomId.value = row.pomId
    outputDataVisible.value = true

  }
  getList()
  handleQuery()
</script>