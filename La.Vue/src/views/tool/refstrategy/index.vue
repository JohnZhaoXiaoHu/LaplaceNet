<!--
 * @Descripttion: (单据编码/sys_ref_strategy)
 * @version: (1.0)
 * @Author: (Laplace)
 * @Date: (2022-12-28)
 * @LastEditors: (Laplace)
 * @LastEditTime: (2022-12-28)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="模块" prop="refModule">
        <el-select clearable v-model="queryParams.refModule" placeholder="请选择模块">
          <el-option v-for="item in  options.sys_module_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="refCategory">
        <el-select clearable v-model="queryParams.refCategory" placeholder="请选择类别">
          <el-option v-for="item in  options.sys_ref_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="编码代号" prop="refCode">
        <el-input v-model="queryParams.refCode" placeholder="请输入编码代号" />
      </el-form-item>
      <el-form-item label="编码名称" prop="refName">
        <el-input v-model="queryParams.refName" placeholder="请输入编码名称" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button color="#409EFF" v-hasPermi="['sys:refstrategy:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#67C23A" :disabled="single" v-hasPermi="['sys:refstrategy:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#F56C6C" :disabled="multiple" v-hasPermi="['sys:refstrategy:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#E6A23C" plain icon="download" @click="handleExport" v-hasPermi="['sys:refstrategy:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" max-height="635" stripe border highlight-current-row
      @sort-change="sortChange" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="refId" label="ID" align="center" v-if="columns.showColumn('refId')" />
      <el-table-column prop="refModule" label="模块" align="center" v-if="columns.showColumn('refModule')">
        <template #default="scope">
          <dict-tag :options="options.sys_module_list" :value="scope.row.refModule" />
        </template>
      </el-table-column>
      <el-table-column prop="refCategory" label="类别" align="center" v-if="columns.showColumn('refCategory')">
        <template #default="scope">
          <dict-tag :options="options.sys_ref_type" :value="scope.row.refCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="refCode" label="编码代号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('refCode')" />
      <el-table-column prop="refName" label="编码名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('refName')" />
      <el-table-column prop="refPattern" label="编码模式" align="center" v-if="columns.showColumn('refPattern')">
        <template #default="scope">
          <dict-tag :options="options.sys_numbering_method" :value="scope.row.refPattern" />
        </template>
      </el-table-column>
      <el-table-column prop="refPrefix" label="前缀" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('refPrefix')" />
      <el-table-column prop="refLenth" label="长度" align="center" v-if="columns.showColumn('refLenth')" />
      <el-table-column prop="initNumber" label="初始编码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('initNumber')" />
      <el-table-column prop="isoNumber" label="ISO编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('isoNumber')" />
      <el-table-column prop="status" label="状态" align="center" v-if="columns.showColumn('status')">
        <template #default="scope">
          <dict-tag :options="options.sys_normal_disable" :value="scope.row.status" />
        </template>
      </el-table-column>
      <el-table-column prop="sort" label="排序" align="center" v-if="columns.showColumn('sort')" />
      <el-table-column prop="isDeleted" label="isDeleted" align="center" v-if="columns.showColumn('isDeleted')" />
      <el-table-column prop="remark" label="remark" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column label="操作" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['sys:refstrategy:edit']" type="success" icon="edit" title="编辑"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sys:refstrategy:delete']" type="danger" icon="delete" title="删除"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改单据编码对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="模块" prop="refModule">
              <el-select v-model="form.refModule" placeholder="请选择模块" clearable @change="selrefModule">
                <el-option v-for="item in  options.sys_module_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="refCategory">
              <el-select v-model="form.refCategory" placeholder="请选择类别" clearable @change="selrefCategory">
                <el-option v-for="item in  options.sys_ref_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue" :disabled="item.disabled"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="编码代号" prop="refCode">
              <el-input v-model="form.refCode" placeholder="请输入编码代号" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="编码名称" prop="refName">
              <el-input v-model="form.refName" placeholder="请输入编码名称" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="编码模式" prop="refPattern">
              <el-select v-model="form.refPattern" placeholder="请选择编码模式" @change="selrefPattern">
                <el-option v-for="item in  options.sys_numbering_method " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前缀" prop="refPrefix">
              <el-input v-model="form.refPrefix" placeholder="请输入前缀" @input="InitrefPrefix" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长度" prop="refLenth">
              <el-input-number v-model.number="form.refLenth" controls-position="right" placeholder="请输入长度" :min="4"
                :max="10" @input="InitrefLenth" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="初始编码" prop="initNumber">
              <el-input v-model="form.initNumber" placeholder="请输入初始编码" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="ISO编号" prop="isoNumber">
              <el-input v-model="form.isoNumber" placeholder="请输入ISO编号" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="status">
              <el-radio-group v-model="form.status">
                <el-radio v-for="item in  options.sys_normal_disable " :key="item.dictValue" :label="item.dictValue">{{
                  item.dictLabel
                  }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="排序" prop="sort">
              <el-input-number v-model.number="form.sort" controls-position="right" placeholder="请输入排序" />
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

<script setup name="sysrefstrategy">
  // 引入 sysrefstrategy操作方法
  import {
    listSysRefStrategy, addSysRefStrategy, delSysRefStrategy, updateSysRefStrategy, getSysRefStrategy,

  }
    from '@/api/system/sysrefstrategy.js'
  //日期格式化函数
  import { getCurrentDate } from '@/utils/date'
  const { proxy } = getCurrentInstance()
  // 选中refId数组数组
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
    refModule: undefined,
    refCategory: undefined,
    refCode: undefined,
    refName: undefined,
  })
  const columns = ref([
    { visible: true, prop: 'refId', label: 'ID' },
    { visible: true, prop: 'refModule', label: '模块' },
    { visible: true, prop: 'refCategory', label: '类别' },
    { visible: true, prop: 'refCode', label: '编码代号' },
    { visible: true, prop: 'refName', label: '编码名称' },
    { visible: true, prop: 'refPattern', label: '编码模式' },
    { visible: true, prop: 'refPrefix', label: '前缀' },
    { visible: true, prop: 'refLenth', label: '长度' },
    { visible: true, prop: 'initNumber', label: '初始编码' },
    { visible: true, prop: 'isoNumber', label: 'ISO编号' },
    { visible: false, prop: 'status', label: '状态' },
    { visible: false, prop: 'sort', label: '排序' },
    { visible: false, prop: 'isDeleted', label: '' },
    { visible: false, prop: 'remark', label: '' },
  ])
  const title = ref("")
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
  const open = ref(false)
  const state = reactive({
    form: {},
    rules: {
      refModule: [{ required: true, message: "模块不能为空", trigger: "change" }],
      refCategory: [{ required: true, message: "类别不能为空", trigger: "change" }],
      refCode: [{ required: true, message: "编码代号不能为空", trigger: "blur" }],
      refName: [{ required: true, message: "编码名称不能为空", trigger: "blur" }],
      refPattern: [{ required: true, message: "编码模式不能为空", trigger: "change" }],
      refPrefix: [{ required: true, message: "前缀不能为空", trigger: "blur" }],
      refLenth: [{ required: true, message: "长度不能为空", trigger: "blur", type: "number" }],
      initNumber: [{ required: true, message: "初始编码不能为空", trigger: "blur" }],
      isoNumber: [{ required: true, message: "ISO编号不能为空", trigger: "blur" }],
      status: [{ required: true, message: "状态不能为空", trigger: "blur" }],
      sort: [{ required: true, message: "排序不能为空", trigger: "blur", type: "number" }],
      isDeleted: [{ required: true, message: "不能为空", trigger: "blur" }],
    },
    options: {
      //  模块 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_module_list: [],
      //  类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ref_type: [],
      //  编码模式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_numbering_method: [],
      //  状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_normal_disable: [],
    }
  })

  const { form, rules, options } = toRefs(state)
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const formRef = ref()

  var dictParams = [
    { dictType: "sys_module_list" },
    { dictType: "sys_ref_type" },
    { dictType: "sys_numbering_method" },
    { dictType: "sys_normal_disable" },
  ]

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })

  function getList() {
    loading.value = true
    listSysRefStrategy(queryParams).then(res => {
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

  // 重置表单
  function reset() {
    form.value = {
      refModule: undefined,
      refCategory: undefined,
      refCode: undefined,
      refName: undefined,
      refPattern: undefined,
      refPrefix: undefined,
      refLenth: undefined,
      initNumber: undefined,
      isoNumber: undefined,
      status: undefined,
      sort: undefined,
      isDeleted: undefined,
      remark: undefined,
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
  //模块类别下拉框选中事件
  function selrefModule(val) {

    switch (val) {
      case 'FI':
        form.value.refPrefix = 'FI'
        //禁用其它项
        state.options["sys_ref_type"].forEach(item => {
          //if (item.dictValue != 'Form') { item.disabled = true };
          if (item.dictValue === 'Notify') { item.disabled = true };
          if (item.dictValue === 'Notice') { item.disabled = true };
          if (item.dictValue === 'Matnr') { item.disabled = true };
          if (item.dictValue === 'Vendor') { item.disabled = true };
          if (item.dictValue === 'Client') { item.disabled = true };

        })
        form.value.refCategory = 'Form'
        break;
      case 'CO':
        form.value.refPrefix = 'CO'
        //禁用其它项
        state.options["sys_ref_type"].forEach(item => {
          //if (item.dictValue != 'Form') { item.disabled = true };
          if (item.dictValue === 'Notify') { item.disabled = true };
          if (item.dictValue === 'Notice') { item.disabled = true };
          if (item.dictValue === 'Matnr') { item.disabled = true };
          if (item.dictValue === 'Vendor') { item.disabled = true };
          if (item.dictValue === 'Client') { item.disabled = true };
        })
        form.value.refCategory = 'Form'
        break;
      case 'MM':
        form.value.refPrefix = 'MM'
        //禁用其它项
        state.options["sys_ref_type"].forEach(item => {
          //if (item.dictValue != 'Form') { item.disabled = true };
          if (item.dictValue === 'Notify') { item.disabled = true };
          if (item.dictValue === 'Notice') { item.disabled = true };
          //if (item.dictValue === 'Matnr') { item.disabled = true };
          //if (item.dictValue === 'Vendor') { item.disabled = true };
          if (item.dictValue === 'Client') { item.disabled = true };
        })
        form.value.refCategory = 'Form'
        break;
      case 'SD':
        form.value.refPrefix = 'SD'
        form.value.refPrefix = 'MM'
        //禁用其它项
        state.options["sys_ref_type"].forEach(item => {
          //if (item.dictValue != 'Form') { item.disabled = true };
          if (item.dictValue === 'Notify') { item.disabled = true };
          if (item.dictValue === 'Notice') { item.disabled = true };
          if (item.dictValue === 'Matnr') { item.disabled = true };
          if (item.dictValue === 'Vendor') { item.disabled = true };
          //if (item.dictValue === 'Client') { item.disabled = true };
        })
        form.value.refCategory = 'Form'
        break;
      case 'HR':
        form.value.refPrefix = 'HR'
        break;
      case 'PP':
        form.value.refPrefix = 'PP'
        break;
      case 'QM':
        form.value.refPrefix = 'QM'
        break;
      case 'PM':
        form.value.refPrefix = 'PM'
        break;
      case 'PS':
        form.value.refPrefix = 'PS'
        break;
      case 'BW':
        form.value.refPrefix = 'BW'
        break;
      case 'AM':
        form.value.refPrefix = 'AM'
        break;
      case 'WF':
        form.value.refPrefix = 'WF'
        break;
      case 'IS':
        form.value.refPrefix = 'IS'
        break;
      case 'CS':
        form.value.refPrefix = 'CS'
        break;
      default:
        form.value.refPrefix = 'CO'
        break;
    }
    switch (form.value.refCategory) {
      case 'Form':
        form.value.refPrefix = form.value.refPrefix + 'FM'

        break;
      case 'Notify':
        form.value.refPrefix = form.value.refPrefix + 'NY'
        break;
      case 'Notice':
        form.value.refPrefix = form.value.refPrefix + 'NE'
        break;
      case 'Matnr':
        form.value.refPrefix = form.value.refPrefix + 'MA'
        break;
      case 'Vendor':
        form.value.refPrefix = form.value.refPrefix + 'VE'
        break;
      case 'Client':
        form.value.refPrefix = form.value.refPrefix + 'CL'
        break;

      default:
        form.value.refPrefix = form.value.refPrefix + 'CO'
        break;
    }

  }

  function typeChange() {

  }

  //表单类别下拉框选中事件
  function selrefCategory(val) {

    switch (form.value.refModule) {
      case 'FI':
        form.value.refPrefix = 'FI'
        form.value.refCategory = 'Form'
        break;
      case 'CO':
        form.value.refPrefix = 'CO'
        break;
      case 'MM':
        form.value.refPrefix = 'MM'
        break;
      case 'SD':
        form.value.refPrefix = 'SD'
        break;
      case 'HR':
        form.value.refPrefix = 'HR'
        break;
      case 'PP':
        form.value.refPrefix = 'PP'
        break;
      case 'QM':
        form.value.refPrefix = 'QM'
        break;
      case 'PM':
        form.value.refPrefix = 'PM'
        break;
      case 'PS':
        form.value.refPrefix = 'PS'
        break;
      case 'BW':
        form.value.refPrefix = 'BW'
        break;
      case 'AM':
        form.value.refPrefix = 'AM'
        break;
      case 'WF':
        form.value.refPrefix = 'WF'
        break;
      case 'IS':
        form.value.refPrefix = 'IS'
        break;
      case 'CS':
        form.value.refPrefix = 'CS'
        break;
      default:
        form.value.refPrefix = 'CO'
        break;
    }
    switch (val) {
      case 'Form':
        form.value.refPrefix = form.value.refPrefix + 'FM'

        break;
      case 'Notify':
        form.value.refPrefix = form.value.refPrefix + 'NY'
        break;
      case 'Notice':
        form.value.refPrefix = form.value.refPrefix + 'NE'
        break;
      case 'Matnr':
        form.value.refPrefix = form.value.refPrefix + 'MA'
        break;
      case 'Vendor':
        form.value.refPrefix = form.value.refPrefix + 'VE'
        break;
      case 'Client':
        form.value.refPrefix = form.value.refPrefix + 'CL'
        break;

      default:
        form.value.refPrefix = form.value.refPrefix + 'CO'
        break;
    }
    form.value.isoNumber = 'DTA-05-'
    form.value.refLenth = '4'
    InitrefPrefix()
  }
  //编号前缀文本框@input事件

  function InitrefPrefix() {

    if ((form.value.refPattern) != null || (form.value.refLenth) != null) {

      switch (form.value.refPattern) {
        //padStart()用于头部补全，padEnd()用于尾部补全
        case '1':
          //form.value.refLenth = 10
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)

          form.value.initNumber = form.value.refPrefix + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '2':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString()).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString() + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '3':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '4':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '5':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '6':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '7':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().slice(2, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().slice(2, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().slice(2, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        default:
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
      }
    }
  }
  //编号位数文本框@input事件
  function InitrefLenth() {
    if ((form.value.refPattern) != null || (form.value.refPrefix) != null) {
      switch (form.value.refPattern) {
        //padStart()用于头部补全，padEnd()用于尾部补全
        case '1':
          //form.value.refLenth = 10
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)

          form.value.initNumber = form.value.refPrefix + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '2':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString()).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString() + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '3':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '4':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '5':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '6':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '7':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().slice(2, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().slice(2, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().slice(2, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        default:
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
      }
    }
  }

  //编码规则下拉框选中事件
  function selrefPattern(val) {
    //let refPrefixLen=parseInt((form.value.refPrefix.length) + (form.value.refLenth)) + 8

    if (form.value.refPrefix != null || form.value.refLenth != null) {
      //form.value.createBy=refPrefixLen
      switch (val) {
        //padStart()用于头部补全，padEnd()用于尾部补全
        case '1':
          //form.value.refLenth = 10
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)

          form.value.initNumber = form.value.refPrefix + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '2':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString()).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString() + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '3':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '4':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '5':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(2, 6)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(2, 6).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2, 6) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '6':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().substring(0, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().substring(0, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(0, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        case '7':
          //form.value.initNumber = (form.value.refPrefix + getCurrentDate().toString().slice(2, 4)).padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth) + parseInt(getCurrentDate().toString().slice(2, 4).length), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().slice(2, 4) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
        default:
          //form.value.initNumber = form.value.refPrefix.padEnd(parseInt(form.value.refPrefix.length) + parseInt(form.value.refLenth), 0)
          form.value.initNumber = form.value.refPrefix + getCurrentDate().toString().substring(2) + '1'.padStart(parseInt(form.value.refLenth), 0)
          break;
      }
    }
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
    const Ids = row.refId || ids.value

    proxy.$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
      .then(function () {
        return delSysRefStrategy(Ids)
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
    const id = row.refId || ids.value
    getSysRefStrategy(id).then((res) => {
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
        if (form.value.refId != undefined && opertype.value === 2) {
          updateSysRefStrategy(form.value).then((res) => {
            proxy.$modal.msgSuccess("修改成功")
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addSysRefStrategy(form.value).then((res) => {
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
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm("是否确认导出所有单据编码数据项?", "警告", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
      .then(function () {
        return exportSysRefStrategy(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.refId);
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