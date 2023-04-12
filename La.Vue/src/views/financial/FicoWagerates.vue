<!--
 * @Descripttion: (工厂工资率/fico_wagerates)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-11)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-11)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="年月" prop="fwYm">
        <el-select filterable clearable v-model="queryParams.fwYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂" prop="fwPlant">
        <el-select filterable clearable v-model="queryParams.fwPlant" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['la:ficowagerates:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:ficowagerates:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:ficowagerates:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['la:ficowagerates:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:ficowagerates:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="fwId" label="ID" align="center" v-if="columns.showColumn('fwId')" />
      <el-table-column prop="fwYm" label="年月" align="center" v-if="columns.showColumn('fwYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.fwYm" />
        </template>
      </el-table-column>
      <el-table-column prop="fwPlant" label="工厂" align="center" v-if="columns.showColumn('fwPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.fwPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="fwCcy" label="币种" align="center" v-if="columns.showColumn('fwCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.fwCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="fwSalesVolume" label="销售额" align="center" v-if="columns.showColumn('fwSalesVolume')" />
      <el-table-column prop="fwWorkingDays" label="工作天数" align="center" v-if="columns.showColumn('fwWorkingDays')" />
      <el-table-column prop="fwDirectWageRate" label="直接工资率" align="center"
        v-if="columns.showColumn('fwDirectWageRate')" />
      <el-table-column prop="fwDirect" label="直接人数" align="center" v-if="columns.showColumn('fwDirect')" />
      <el-table-column prop="fwDirectOverTime" label="直接加班费" align="center"
        v-if="columns.showColumn('fwDirectOverTime')" />
      <el-table-column prop="fwDirectWages" label="直接工资" align="center" v-if="columns.showColumn('fwDirectWages')" />
      <el-table-column prop="fwInDirectWageRate" label="间接工资率" align="center"
        v-if="columns.showColumn('fwInDirectWageRate')" />
      <el-table-column prop="fwInDirect" label="间接人数" align="center" v-if="columns.showColumn('fwInDirect')" />
      <el-table-column prop="fwInDirectOverTime" label="间接加班费" align="center"
        v-if="columns.showColumn('fwInDirectOverTime')" />
      <el-table-column prop="fwInDirectWages" label="间接工资" align="center"
        v-if="columns.showColumn('fwInDirectWages')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:ficowagerates:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:ficowagerates:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改工厂工资率对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <!-- <el-col :lg="12">
            <el-form-item label="ID" prop="fwId">
              <el-input-number clearable v-model.number="form.fwId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col> -->


          <el-col :lg="12">
            <el-form-item label="年月" prop="fwYm">
              <el-select v-model="form.fwYm" filterable clearable :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="fwPlant">
              <el-select v-model="form.fwPlant" filterable clearable :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="fwCcy">
              <el-select v-model="form.fwCcy" filterable clearable :placeholder="$t('btn.select')+'币种'">
                <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售额" prop="fwSalesVolume">
              <el-input-number clearable v-model.number="form.fwSalesVolume" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工作天数" prop="fwWorkingDays">
              <el-input-number clearable v-model.number="form.fwWorkingDays" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'工作天数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="直接工资率" prop="fwDirectWageRate">
              <el-input-number clearable v-model.number="form.fwDirectWageRate" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'直接工资率'" />
              <template #label>
                <span>
                  <el-tooltip
                    content="标准工资率 = 计划作业期间预计[工资总额]÷预计开工天数×工人人数×每天作业时间×出勤率<br/>单位工时标准工资率=预计支付直接人工标准工资总额÷标准总工时× 100 %"
                    placement="top">
                    <el-icon :size="15" color="hotpink">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  直接工资率
                </span>
              </template>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="直接人数" prop="fwDirect">
              <el-input-number clearable v-model.number="form.fwDirect" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'直接人数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="直接加班费" prop="fwDirectOverTime">
              <el-input-number clearable v-model.number="form.fwDirectOverTime" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'直接加班费'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="直接工资" prop="fwDirectWages">
              <el-input-number clearable v-model.number="form.fwDirectWages" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'直接工资'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="间接工资率" prop="fwInDirectWageRate">
              <el-input-number clearable v-model.number="form.fwInDirectWageRate" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'间接工资率'" />
              <template #label>
                <span>
                  <el-tooltip
                    content="标准工资率 = 计划作业期间预计[工资总额]÷预计开工天数×工人人数×每天作业时间×出勤率<br/>单位工时标准工资率=预计支付直接人工标准工资总额÷标准总工时× 100 %"
                    placement="top">
                    <el-icon :size="15" color="hotpink">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  间接工资率
                </span>
              </template>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="间接人数" prop="fwInDirect">
              <el-input-number clearable v-model.number="form.fwInDirect" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'间接人数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="间接加班费" prop="fwInDirectOverTime">
              <el-input-number clearable v-model.number="form.fwInDirectOverTime" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'间接加班费'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="间接工资" prop="fwInDirectWages">
              <el-input-number clearable v-model.number="form.fwInDirectWages" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'间接工资'" />
            </el-form-item>
          </el-col>

          <!-- <el-col :lg="12">
            <el-form-item label="UDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'UDF01'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'UDF02'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'UDF03'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'UDF04'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'UDF05'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'UDF06'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'UDF51'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'UDF52'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'UDF53'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'UDF54'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'UDF55'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'UDF56'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="ReMark" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'ReMark'" :disabled="true"/>
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
          </el-col> -->
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ficowagerates">
  // 引入 ficowagerates操作方法
  import {
    listFicoWagerates, addFicoWagerates, delFicoWagerates, updateFicoWagerates, getFicoWagerates,

  }
    from '@/api/financial/ficowagerates.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中fwId数组数组
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
    fwYm: undefined,
    fwPlant: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'fwId', label: 'ID' },
    { visible: true, prop: 'fwYm', label: '年月' },
    { visible: true, prop: 'fwPlant', label: '工厂' },
    { visible: true, prop: 'fwCcy', label: '币种' },
    { visible: true, prop: 'fwSalesVolume', label: '销售额' },
    { visible: true, prop: 'fwWorkingDays', label: '工作天数' },
    { visible: true, prop: 'fwDirectWageRate', label: '直接工资率' },
    { visible: true, prop: 'fwDirect', label: '直接人数' },
    { visible: false, prop: 'fwDirectOverTime', label: '直接加班费' },
    { visible: false, prop: 'fwDirectWages', label: '直接工资' },
    { visible: false, prop: 'fwInDirectWageRate', label: '间接工资率' },
    { visible: false, prop: 'fwInDirect', label: '间接人数' },
    { visible: false, prop: 'fwInDirectOverTime', label: '间接加班费' },
    { visible: false, prop: 'fwInDirectWages', label: '间接工资' },
  ])
  // 总条数
  const total = ref(0)
  // 工厂工资率表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


  var dictParams = [
    { dictType: "sql_ym_list" },
    { dictType: "sys_plant_list" },
    { dictType: "sys_ccy_type" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取工厂工资率表记录数据
  function getList() {
    loading.value = true
    listFicoWagerates(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.fwId);
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
      fwYm: [{ required: true, message: "年月" + proxy.$t('btn.empty'), trigger: "change" }],
      fwPlant: [{ required: true, message: "工厂" + proxy.$t('btn.empty'), trigger: "change" }],
      fwCcy: [{ required: true, message: "币种" + proxy.$t('btn.empty'), trigger: "change" }],
      fwSalesVolume: [{ required: true, message: "销售额" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwWorkingDays: [{ required: true, message: "工作天数" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectWageRate: [{ required: true, message: "直接工资率" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirect: [{ required: true, message: "直接人数" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectOverTime: [{ required: true, message: "直接加班费" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectWages: [{ required: true, message: "直接工资" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectWageRate: [{ required: true, message: "间接工资率" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirect: [{ required: true, message: "间接人数" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectOverTime: [{ required: true, message: "间接加班费" + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectWages: [{ required: true, message: "间接工资" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ym_list: [],
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      fwYm: undefined,
      fwPlant: undefined,
      fwCcy: undefined,
      fwSalesVolume: undefined,
      fwWorkingDays: undefined,
      fwDirectWageRate: undefined,
      fwDirect: undefined,
      fwDirectOverTime: undefined,
      fwDirectWages: undefined,
      fwInDirectWageRate: undefined,
      fwInDirect: undefined,
      fwInDirectOverTime: undefined,
      fwInDirectWages: undefined,
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
    form.value.fwYm = ""
    form.value.fwPlant = "DTA"
    form.value.fwCcy = "CNY"
    opertype.value = 1
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.fwId || ids.value
    getFicoWagerates(id).then((res) => {
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
        if (form.value.fwId != undefined && opertype.value === 2) {
          updateFicoWagerates(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addFicoWagerates(form.value).then((res) => {
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
    const Ids = row.fwId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delFicoWagerates(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }



  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + "工厂工资率", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Financial/FicoWagerates/export', { ...queryParams })
      })
  }

  handleQuery()
</script>
<style lang="scss" scoped>
  .over-flow {
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }

  .text-tooltip {
    max-width: 100%;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }

  p {
    margin: 0;
  }
</style>