<!--
 * @Descripttion: (bom成本核算/fico_bom_costing)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-16)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-16)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="bcPlant">
        <el-select clearable v-model="queryParams.bcPlant" placeholder="请选择工厂">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="bcFy">
        <el-select clearable v-model="queryParams.bcFy" placeholder="请选择期间">
          <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="bcYm">
        <el-select clearable v-model="queryParams.bcYm" placeholder="请选择年月">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="成品物料" prop="bcBomItem">
        <el-select clearable v-model="queryParams.bcBomItem" placeholder="请选择成品物料">
          <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['fico:bomcosting:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:bomcosting:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:bomcosting:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:bomcosting:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="bcId" label="ID" align="center" v-if="columns.showColumn('bcId')" />
      <el-table-column prop="bcPlant" label="工厂" align="center" v-if="columns.showColumn('bcPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.bcPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="bcFy" label="期间" align="center" v-if="columns.showColumn('bcFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.bcFy" />
        </template>
      </el-table-column>
      <el-table-column prop="bcYm" label="年月" align="center" v-if="columns.showColumn('bcYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.bcYm" />
        </template>
      </el-table-column>
      <el-table-column prop="bcBomItem" label="成品物料" align="center" v-if="columns.showColumn('bcBomItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.bcBomItem" />
        </template>
      </el-table-column>
      <el-table-column prop="bcItemText" label="物料文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bcItemText')" />
      <el-table-column prop="bcBomCost" label="成本" align="center" v-if="columns.showColumn('bcBomCost')" />
      <el-table-column prop="bcCurrency" label="币种" align="center" v-if="columns.showColumn('bcCurrency')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.bcCurrency" />
        </template>
      </el-table-column>
      <el-table-column prop="bcBalancedate" label="核算日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bcBalancedate')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['fico:bomcosting:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['fico:bomcosting:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改bom成本核算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="bcId">
              <el-input-number v-model.number="form.bcId" controls-position="right" :placeholder="$t('btn.enter')+'ID'"
                :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂" prop="bcPlant">
              <el-select v-model="form.bcPlant" :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="bcFy">
              <el-select v-model="form.bcFy" :placeholder="$t('btn.select')+'期间'">
                <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="bcYm">
              <el-select v-model="form.bcYm" :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成品物料" prop="bcBomItem">
              <el-select v-model="form.bcBomItem" :placeholder="$t('btn.select')+'成品物料'" @change="onInstitutionChange">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="bcItemText">
              <el-input v-model="form.bcItemText" :placeholder="$t('btn.enter')+'物料文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本" prop="bcBomCost">
              <el-input-number v-model.number="form.bcBomCost" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'成本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="bcCurrency">
              <el-select v-model="form.bcCurrency" :placeholder="$t('btn.select')+'币种'">
                <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="核算日期" prop="bcBalancedate">
              <el-date-picker v-model="form.bcBalancedate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficobomcosting">
  // 引入 ficobomcosting操作方法
  import {
    listFicoBomCosting, addFicoBomCosting, delFicoBomCosting, updateFicoBomCosting, getFicoBomCosting,

  }
    from '@/api/financial/ficobomcosting.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中bcId数组数组
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
    bcPlant: undefined,
    bcFy: undefined,
    bcYm: undefined,
    bcBomItem: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'bcId', label: 'ID' },
    { visible: true, prop: 'bcPlant', label: '工厂' },
    { visible: true, prop: 'bcFy', label: '期间' },
    { visible: true, prop: 'bcYm', label: '年月' },
    { visible: true, prop: 'bcBomItem', label: '成品物料' },
    { visible: true, prop: 'bcItemText', label: '物料文本' },
    { visible: true, prop: 'bcBomCost', label: '成本' },
    { visible: true, prop: 'bcCurrency', label: '币种' },
    { visible: false, prop: 'bcBalancedate', label: '核算日期' },
    { visible: false, prop: 'remark', label: '备注' },
  ])
  // 总条数
  const total = ref(0)
  // bom成本核算表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sql_period_list" },
    { dictType: "sql_ym_list" },
    { dictType: "sql_moc_item" },
    { dictType: "sys_ccy_type" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取bom成本核算表记录数据
  function getList() {
    loading.value = true
    listFicoBomCosting(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.bcId);
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
      bcPlant: [{ required: true, message: "工厂" + proxy.$t('btn.empty'), trigger: "change" }],
      bcFy: [{ required: true, message: "期间" + proxy.$t('btn.empty'), trigger: "change" }],
      bcYm: [{ required: true, message: "年月" + proxy.$t('btn.empty'), trigger: "change" }],
      bcBomItem: [{ required: true, message: "成品物料" + proxy.$t('btn.empty'), trigger: "change" }],
      bcItemText: [{ required: true, message: "物料文本" + proxy.$t('btn.empty'), trigger: "blur" }],
      bcBomCost: [{ required: true, message: "成本" + proxy.$t('btn.empty'), trigger: "blur" }],
      bcCurrency: [{ required: true, message: "币种" + proxy.$t('btn.empty'), trigger: "change" }],
      bcBalancedate: [{ required: true, message: "核算日期" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_period_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ym_list: [],
      // 成品物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
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
      bcPlant: undefined,
      bcFy: undefined,
      bcYm: undefined,
      bcBomItem: undefined,
      bcItemText: undefined,
      bcBomCost: undefined,
      bcCurrency: undefined,
      bcBalancedate: undefined,
      remark: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
    };
    proxy.resetForm("formRef")
  }
  function onInstitutionChange(val) {

    form.value.bcItemText = val

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
    const id = row.bcId || ids.value
    getFicoBomCosting(id).then((res) => {
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
        if (form.value.bcId != undefined && opertype.value === 2) {
          updateFicoBomCosting(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addFicoBomCosting(form.value).then((res) => {
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
    const Ids = row.bcId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delFicoBomCosting(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "bom成本核算", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/financial/FicoBomCosting/export', { ...queryParams })
      })
  }

  handleQuery()
</script>