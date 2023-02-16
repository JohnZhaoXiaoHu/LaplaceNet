<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @version: (1.0)
 * @Author: (Laplace)
 * @Date: (2022-12-21)
 * @LastEditors: (Laplace)
 * @LastEditTime: (2022-12-21)
 * @Example: 行内编辑示例
-->
<template>
  <div>
    <p></p>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
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
          :shortcuts="dateOptions">
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
      <el-col :span="1.5">
        <el-button color="#33CCFF" plain icon="plus" @click="handleNew" v-hasPermi="['pp:output:add']">
          {{ $t('btn.newRow') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-form ref="formRef" :model="form" :rules="rules">
      <el-table :data="dataList" v-loading="loading" ref="table" :key="dataListKey" max-height="635" stripe border
        highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange">
        <el-table-column type="selection" width="50" align="center" />
        <el-table-column prop="pomId" label="ID" align="center" v-if="columns.showColumn('pomId')">

        </el-table-column>
        <el-table-column prop="pomGuid" label="GUID" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('pomGuid')" />
        <el-table-column prop="pomOrder" label="生产工单" align="center" v-if="columns.showColumn('pomOrder')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name" align="center">
              <el-select v-if="scope.row.isEdit && !scope.row.pomId" v-model="scope.row.pomOrder"
                @change="(val) => { SelAssignmentinline(dataList, val, scope.$index, scope.row) }">
                <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
              <span v-else v-text="scope.row.pomOrder"></span>
            </el-form-item>
          </template>
        </el-table-column>
        <el-table-column prop="pomOrderQty" label="工单数量" align="center" v-if="columns.showColumn('pomOrderQty')">
        </el-table-column>
        <el-table-column prop="pomOrderSerial" label="管理序列号" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('pomOrderSerial')">
        </el-table-column>
        <el-table-column prop="pomMflot" label="生产批次" align="center" v-if="columns.showColumn('pomMflot')">
        </el-table-column>
        <el-table-column prop="pomModelName" label="机种名" align="center" v-if="columns.showColumn('pomModelName')">
        </el-table-column>
        <el-table-column prop="pomMfItem" label="物料" align="center" v-if="columns.showColumn('pomMfItem')">
        </el-table-column>
        <el-table-column prop="pomStdTime" label="标准工时" align="center" v-if="columns.showColumn('pomStdTime')">
        </el-table-column>
        <el-table-column prop="pomMfDate" label="生产日期" align="center" :show-overflow-tooltip="true" format="YYYY-MM-DD"
          v-if="columns.showColumn('pomMfDate')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name">
              <el-date-picker v-if="scope.row.isEdit" v-model="scope.row.pomMfDate" type="date" format="YYYY-MM-DD"
                value-format="YYYY-MM-DD" />
              <span v-else v-text="proxy.$filters.timeFormat(scope.row.pomMfDate)"></span>
            </el-form-item>
          </template>
        </el-table-column>
        <el-table-column prop="pomLineName" label="生产班组" align="center" v-if="columns.showColumn('pomLineName')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name">
              <el-select v-if="scope.row.isEdit" v-model="scope.row.pomLineName" placeholder="请选择">
                <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
              <span v-else v-text="scope.row.pomLineName"></span>
            </el-form-item>
          </template>
        </el-table-column>
        <el-table-column prop="pomDirect" label="直接人数" align="center" v-if="columns.showColumn('pomDirect')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name">
              <el-input-number v-if="scope.row.isEdit" v-model.number="scope.row.pomDirect" controls-position="right"
                placeholder="请输入直接人数" :min="1" :max="25"
                @input="(val) => { CalculateStdOutput(dataList, val, scope.$index, scope.row) }" />
              <span v-else v-text="scope.row.pomDirect"></span>
            </el-form-item>
          </template>
        </el-table-column>
        <el-table-column prop="pomIndirect" label="间接人数" align="center" v-if="columns.showColumn('pomIndirect')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name">
              <el-input-number v-if="scope.row.isEdit" v-model.number="scope.row.pomIndirect" controls-position="right"
                placeholder="请输入间接人数" :min="1" :max="10" />
              <span v-else v-text="scope.row.pomIndirect"></span>
            </el-form-item>
          </template>
        </el-table-column>

        <el-table-column prop="pomStdOutput" label="标准产能" align="center" v-if="columns.showColumn('pomStdOutput')">
          <template #default="scope">
            <el-form-item :prop="'dataList.' + scope.$index + '.name'" :rules="rules.name">
              <el-input-number v-if="scope.row.isEdit" v-model.number="scope.row.pomStdOutput" controls-position="right"
                placeholder="请输入标准产能" />
              <span v-else v-text="scope.row.pomStdOutput"></span>
            </el-form-item>
          </template>
        </el-table-column>
        <el-table-column align="center" label="行内编辑" width="160">
          <template #default="scope">
            <div v-if="scope.row.isEdit">
              <el-button v-hasPermi="['pp:output:edit']" type="success" icon="select"
                @click="handleConfirmEditRow(scope.row, scope.$index)" :title="$t('btn.submit')">
              </el-button>
              <el-button v-hasPermi="['pp:output:edit']" type="danger" icon="CloseBold"
                @click="handleCancelEditRow(scope.row, scope.$index)" :title="$t('btn.cancel')">
              </el-button>
            </div>
            <div v-else>
              <el-button v-hasPermi="['pp:output:delete']" color="#CCCCCC" icon="minus"
                @click="handleEraseRow(scope.$index, dataList)" :title="$t('btn.eraseRow')"></el-button>
              <el-button v-hasPermi="['pp:output:edit']" color="#3366FF" icon="EditPen"
                @click="handleEditRow(scope.row, scope.$index)" :title="$t('btn.edit')"></el-button>

            </div>
          </template>

        </el-table-column>
        <el-table-column label="弹窗操作" align="center" width="160">
          <template #default="scope">
            <div v-if="scope.row.pomId">
              <el-button v-hasPermi="['pp:output:edit']" type="success" icon="edit" :title="$t('btn.edit')"
                @click="handleUpdate(scope.row)"></el-button>
              <el-button v-hasPermi="['pp:output:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
                @click="handleDelete(scope.row)"></el-button>
            </div>
          </template>
        </el-table-column>
      </el-table>
    </el-form>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改oph主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="24">
            <el-form-item label="生产工单" prop="pomOrder">
              <el-select clearable filterable v-model="form.pomOrder" placeholder="请选择生产工单" @change="SelAssignment"
                :disabled="title==$t('btn.edit')">
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
              <el-input v-model="form.pomGuid" placeholder="请输入GUID" disabled :disabled="title==$t('btn.edit')" />
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
  import {
    listPpOutputMaster, addPpOutputMaster, delPpOutputMaster, updatePpOutputMaster, getPpOutputMaster,
    exportPpOutputMaster,
  }
    from '@/api/production/ppoutputmaster.js'
  //uuid，guid函数
  import { v4 as uuidv4 } from 'uuid'
  //日期格式化函数
  import { getCurrentTime } from '@/utils/date'
  const { proxy } = getCurrentInstance()
  // 选中pomId数组数组
  const ids = ref([])
  // 非单选禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 150,
    sort: undefined,
    sortType: undefined,
    pomOrder: undefined,
    pomMflot: undefined,
    pomModelName: undefined,
    pomMfItem: undefined,
    pomMfDate: undefined,
    pomLineName: undefined,
  })
  const columns = ref([
    { visible: true, prop: 'pomId', label: 'ID' },
    { visible: true, prop: 'pomGuid', label: 'GUID' },
    { visible: true, prop: 'pomOrder', label: '生产工单' },
    { visible: false, prop: 'pomOrderQty', label: '工单数量' },
    { visible: false, prop: 'pomOrderSerial', label: '管理序列号' },
    { visible: true, prop: 'pomMflot', label: '生产批次' },
    { visible: false, prop: 'pomModelName', label: '机种名' },
    { visible: true, prop: 'pomMfItem', label: '物料' },
    { visible: true, prop: 'pomMfDate', label: '生产日期' },
    { visible: true, prop: 'pomLineName', label: '生产班组' },
    { visible: true, prop: 'pomDirect', label: '直接人数' },
    { visible: true, prop: 'pomIndirect', label: '间接人数' },
    { visible: true, prop: 'pomStdTime', label: '标准工时' },
    { visible: true, prop: 'pomStdOutput', label: '标准产能' },
  ])
  const title = ref("")
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
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
    }
  })

  const { form, rules, options } = toRefs(state)
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
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

  //读取数据表
  function getList() {
    proxy.addDateRange(queryParams, dateRangePomMfDate.value, 'PomMfDate');
    loading.value = true
    listPpOutputMaster(queryParams).then(res => {
      if (res.code == 200) {
        dataList.value = res.data.result
        total.value = res.data.totalNum
        loading.value = false
      }
    })
  }

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }
  //计算标准产量保留两位小数(直接人数*单位时间(60分钟)/标准工时(st)*效率(0.85)),parseFloat().toFixed(2)保留小数位
  //计算计划产出(标准产能)
  function CalculateStdOutputinline(data, val, index, row) {

    if (row.pomStdTime != undefined && row.pomStdTime != null && row.pomStdTime != 0) {
      row.pomStdOutput = parseFloat(Number(val) * 60 / Number(row.pomStdTime) * 0.85).toFixed(2)
    }
    else {
      row.pomStdOutput = 0
    }
    //两种都可以
    this.$set(data, index, row)
    //this.$set(this.topicList,index,row)
  }

  //select选择框，赋值到其它文本框。split(",")分割数组，slice()截取，.join()转字符串parseFloat().toFixed(2)保留小数位
  function SelAssignmentinline(data, val, index, row) {
    //赋值给文本框
    let vals = val
    row.pomGuid = uuidv4()
    row.pomOrder = vals.split(",").slice(0, 1).join()
    row.pomOrderQty = 1000// val.split(",").slice(3, 4).join()
    row.pomOrderSerial = vals.split(",").slice(4, 5).join()
    row.pomMflot = vals.split(",").slice(2, 3).join()
    row.pomModelName = vals.split(",").slice(5, 6).join()
    row.pomMfItem = vals.split(",").slice(1, 2).join()
    row.pomStdTime = vals.split(",").slice(-1).join()
    row.pomMfDate = getCurrentTime()
    //计算计划产出(标准产能)
    //判断直接人数
    if (row.pomDirect != undefined && row.pomDirect != null && row.pomDirect != 0) {
      row.pomStdOutput = parseFloat(Number(row.pomDirect) * 60 / Number(val.split(",").slice(-1).join()) * 0.85).toFixed(2)
    }
    else {
      row.pomStdOutput = 0
    }
    row.pomIndirect = 0
    //两种都可以
    this.$set(data, index, row)
    //this.$set(this.topicList,index,row)
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

  //重置行编辑输入
  function resetRow() {
    pomGuid: undefined
    pomOrder: undefined
    pomOrderQty: undefined
    pomOrderSerial: undefined
    pomMflot: undefined
    pomModelName: undefined
    pomMfItem: undefined
    pomMfDate: undefined
    pomLineName: undefined
    pomDirect: undefined
    pomIndirect: undefined
    pomStdTime: undefined
    pomStdOutput: undefined
  }

  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  //行内编辑 删除指定行
  function handleEraseRow(index, row) {
    row.splice(index, 1);
  }
  //行内编辑 保存前确认
  function handleConfirmEditRow(row, index) {
    row.isEdit = false

    // for (let key in row) {
    //   // 判断一行字段是否输入完整
    //   if (row[key] === '' || row[key] === null || row[key] == 0 || typeof row[key] === 'undefined') {
    //     proxy.$modal.msgSuccess('Please complete the information')
    //     return
    //   }
    //   else {

    //     RowdataSave(row, index)

    //   }
    // }
    RowdataSave(row, index)
    //var resss = 'pomGuid:' + row.pomGuid + ',' + row.pomOrder + ',' + row.pomOrderQty + ',' + row.pomOrderSerial + ',' + row.pomMflot + ',' + row.pomModelName + ',' + row.pomMfItem + ',' + row.pomMfDate + ',' + row.pomLineName + ',' + row.pomDirect + ',' + row.pomIndirect + ',' + row.pomStdTime + ',' + row.pomStdOutput
    //row.pomId = _this.row.pomGuid//pars.split(',') // jsonstr是json字符串
    //row.pomId = row.pomDirect
    // if (proxy.isEmpty(row.pomLineName) || proxy.isEmpty(row.pomDirect) || proxy.isEmpty(row.pomIndirect) || proxy.isEmpty(row.pomMfDate) || proxy.isEmpty(row.pomStdOutput)) {
    //   proxy.$modal.msgSuccess("请输入")
    // }
    // else {
    //   RowdataSave(row, index)

    // }


  }

  //行内编辑 保存

  function RowdataSave(row, index) {


    let parm = {
      pomId: row.pomId,
      pomGuid: row.pomGuid,
      pomOrder: row.pomOrder,
      pomOrderQty: row.pomOrderQty,
      pomOrderSerial: row.pomOrderSerial,
      pomMflot: row.pomMflot,
      pomModelName: row.pomModelName,
      pomMfItem: row.pomMfItem,
      pomMfDate: row.pomMfDate,
      pomLineName: row.pomLineName,
      pomDirect: row.pomDirect,
      pomIndirect: row.pomIndirect,
      pomStdTime: row.pomStdTime,
      pomStdOutput: row.pomStdOutput
    }
    //!row.pomId && row.pomId != undefined
    if (row.pomId != undefined) {
      updatePpOutputMaster(parm).then(response => {
        proxy.$modal.msgSuccess("修改成功")
        getList()
      }).catch(e => {
        this.resetRow()
        this.handleDelete(row)
      })
    } else {
      addPpOutputMaster(parm).then(response => {
        proxy.$modal.msgSuccess("添加成功")
        getList()
      }).catch(e => {
        this.resetRow()
        this.handleDelete(row)
      });
    }
  }

  //行内编辑 取消
  function handleCancelEditRow(row, index) {
    row.isEdit = false

  }
  // 增加一个空行, 用于录入或显示第一行
  function handleNew() {
    //row.isEdit = !row.isEdit;

    onInit()
    //row.isEdit = true;
    //const Ids = row.pomId


  }
  // 函数增加空行
  const onInit = () => {

    dataList.value.push({
      // pomGuid: uuidv4(),
      // pomOrder: '',
      // pomOrderQty: '',
      // pomOrderSerial: '',
      // pomMflot: '',
      // pomModelName: '',
      // pomMfItem: '',
      // pomMfDate: getCurrentTime(),
      // pomLineName: '',
      // pomDirect: 10,
      // pomIndirect: 2,
      // pomStdTime: 10,
      // pomStdOutput: 10,
    })
  }

  //行内编辑 
  function handleEditRow(row, index) {
    row.isEdit = true
    //Input disabled编辑属性
    //v-if="scope.row.isEdit && !scope.row.pomId"



  }



  // 添加
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add')
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
        title.value = "proxy.$t('btn.edit')"
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
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm("是否确认导出所有oph主表数据项?", "警告", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
      .then(function () {
        return exportPpOutputMaster(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {

    this.selectlistRow = selection
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

  handleQuery()
</script>