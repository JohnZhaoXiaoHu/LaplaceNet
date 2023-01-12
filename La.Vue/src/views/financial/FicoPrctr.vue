<!--
 * @Descripttion: (利润中心/fico_prctr)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-01-11)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-01-11)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="fpPlnt">
        <el-select clearable v-model="queryParams.fpPlnt" placeholder="请选择工厂">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="代码" prop="fpCode">
        <el-input v-model="queryParams.fpCode" placeholder="请输入代码" />
      </el-form-item>
      <el-form-item label="名称" prop="fpName">
        <el-input v-model="queryParams.fpName" placeholder="请输入名称" />
      </el-form-item>
      <el-form-item label="类别" prop="fpType">
        <el-select clearable v-model="queryParams.fpType" placeholder="请选择类别">
          <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="有效从">
        <el-date-picker v-model="dateRangeFpActDate" type="datetimerange" range-separator="-" start-placeholder="开始日期"
          end-placeholder="结束日期" placeholder="请选择有效从" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:prctr:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:prctr:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:prctr:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['fico:prctr:export']">
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
      <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
        @selection-change="handleSelectionChange" height="602" style="width: 100%">
        <el-table-column type="selection" width="50" align="center" />
        <el-table-column prop="fpId" label="Id主键" align="center" v-if="columns.showColumn('fpId')" />
        <el-table-column prop="fpPlnt" label="工厂" align="center" v-if="columns.showColumn('fpPlnt')">
          <template #default="scope">
            <el-form-item v-if="scope.row.isEdit && !scope.row.fpId">
              <el-select v-model="scope.row.fpPlnt">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
            <span v-else v-text="scope.row.fpPlnt"></span>
          </template>
        </el-table-column>
        <el-table-column prop="fpCode" label="代码" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('fpCode')">
          <!-- 变量rules -->
          <template #default="scope">
            <el-form-item v-if="scope.row.isEdit && !scope.row.fpId">
              <el-input v-model="scope.row.fpCode"></el-input>
            </el-form-item>
            <span v-else v-text="scope.row.fpCode"></span>
          </template>
        </el-table-column>
        <el-table-column prop="fpName" label="名称" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('fpName')">
          <!-- 变量rules -->
          <template #default="scope">
            <el-form-item v-if="scope.row.isEdit && !scope.row.fpId">
              <el-input v-model="scope.row.fpName"></el-input>
            </el-form-item>
            <span v-else v-text="scope.row.fpName"></span>
          </template>
        </el-table-column>
        <el-table-column prop="fpType" label="类别" align="center" v-if="columns.showColumn('fpType')">
          <template #default="scope">
            <el-form-item v-if="scope.row.isEdit && !scope.row.fpId">
              <el-select v-model="scope.row.fpType">
                <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
            <span v-else v-text="scope.row.fpType"></span>
          </template>
        </el-table-column>
        <el-table-column prop="fpActDate" label="有效从" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('fpActDate')">
          <template #default="scope">
            <el-date-picker v-if="scope.row.isEdit" v-model="scope.row.fpActDate" type="date" format="YYYY-MM-DD"
              value-format="YYYY-MM-DD" />
            <span v-else v-text="scope.row.fpActDate"></span>
          </template>
        </el-table-column>
        <el-table-column prop="fpExpDate" label="有效到" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('fpExpDate')">
          <template #default="scope">
            <el-date-picker v-if="scope.row.isEdit" v-model="scope.row.fpExpDate" type="date" format="YYYY-MM-DD"
              value-format="YYYY-MM-DD" />
            <span v-else v-text="scope.row.fpExpDate"></span>
          </template>
        </el-table-column>
        <!-- 行内编辑 -->
        <el-table-column align="center" :label="$t('btn.inlineEditing')" width="160">
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
              <el-button v-hasPermi="['pp:output:edit']" color="#2b85e4" icon="edit"
                @click="handleEditRow(scope.row, scope.$index)" :title="$t('btn.editRow')"></el-button>
              <el-button v-hasPermi="['pp:output:delete']" color="#c45656" icon="SemiSelect"
                @click="handleEraseRow(scope.row,scope.$index, dataList)" :title="$t('btn.eraseRow')"></el-button>

            </div>
          </template>

        </el-table-column>
        <!-- 弹窗操作 -->
        <el-table-column :label="$t('btn.popupOperation')" align="center" width="160">
          <template #default="scope">
            <div v-if="scope.row.fpId">
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

    <!-- 添加或修改利润中心对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Id主键" prop="fpId">
              <span v-html="form.fpId" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="fpPlnt">
              <el-select v-model="form.fpPlnt" placeholder="请选择工厂">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="代码" prop="fpCode">
              <el-input v-model="form.fpCode" placeholder="请输入代码" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="fpName">
              <el-input v-model="form.fpName" placeholder="请输入名称" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="fpType">
              <el-select v-model="form.fpType" placeholder="请选择类别">
                <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效从" prop="fpActDate">
              <el-date-picker v-model="form.fpActDate" type="datetime" :teleported="false"
                placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效到" prop="fpExpDate">
              <el-date-picker v-model="form.fpExpDate" type="datetime" :teleported="false"
                placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="isDeleted" prop="isDeleted">
              <el-input v-model="form.isDeleted" placeholder="请输入isDeleted" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="remark" prop="remark">
              <el-input v-model="form.remark" placeholder="请输入remark" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input v-model="form.createBy" placeholder="请输入createBy" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入updateBy" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                placeholder="选择日期时间"></el-date-picker>
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

<script setup name="ficoprctr">
  import {
    listFicoPrctr, addFicoPrctr, delFicoPrctr, updateFicoPrctr, getFicoPrctr,

  }
    from '@/api/financial/ficoprctr.js'

  const { proxy } = getCurrentInstance()
  // 选中fpId数组数组
  const ids = ref([])
  const single = ref(true)
  const multiple = ref(true)
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 17,
    sort: '',
    sortType: 'asc',
    fpPlnt: undefined,
    fpCode: undefined,
    fpName: undefined,
    fpType: undefined,
    fpActDate: undefined,
  })
  const columns = ref([
    { visible: true, prop: 'fpId', label: 'Id主键' },
    { visible: true, prop: 'fpPlnt', label: '工厂' },
    { visible: true, prop: 'fpCode', label: '代码' },
    { visible: true, prop: 'fpName', label: '名称' },
    { visible: true, prop: 'fpType', label: '类别' },
    { visible: true, prop: 'fpActDate', label: '有效从' },
    { visible: true, prop: 'fpExpDate', label: '有效到' },
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 有效从时间范围
  const dateRangeFpActDate = ref([])


  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_fin_costtype" },
  ]

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })

  function getList() {
    proxy.addDateRange(queryParams, dateRangeFpActDate.value, 'FpActDate');
    loading.value = true
    listFicoPrctr(queryParams).then(res => {
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
    // 有效从时间范围
    dateRangeFpActDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.fpId);
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
  const formRef = ref()
  const title = ref("")
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
  const open = ref(false)
  const state = reactive({
    form: {},
    rules: {
      fpPlnt: [{ required: true, message: "工厂不能为空", trigger: "change" }],
      fpCode: [{ required: true, message: "利润中心代码不能为空", trigger: "blur" }],
      fpName: [{ required: true, message: "利润中心名称不能为空", trigger: "blur" }],
      fpType: [{ required: true, message: "利润中心类别不能为空", trigger: "change" }],
      fpActDate: [{ required: true, message: "有效日期不能为空", trigger: "blur" }],
      fpExpDate: [{ required: true, message: "失效日期不能为空", trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_fin_costtype: [],
    }
  })

  const { form, rules, options } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      fpPlnt: undefined,
      fpCode: undefined,
      fpName: undefined,
      fpType: undefined,
      fpActDate: undefined,
      fpExpDate: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
    };
    proxy.resetForm("formRef")
  }
  //重置行编辑输入
  function resetRow() {
    fpPlnt: undefined
    fpCode: undefined
    fpName: undefined
    fpType: undefined
    fpActDate: undefined
    fpExpDate: undefined
    createBy: undefined
    createTime: undefined
    updateBy: undefined
    updateTime: undefined
  }
  //行内编辑 删除指定行
  function handleEraseRow(row, index, dataList) {

    //判断ID，删除
    if (row.fpId) {
      handleDelete(row)
    }
    else {
      proxy.$confirm('是否确认删除新增的行？')
        .then(function () {
          //删除新增的行
          dataList.splice(index, 1);
        })
        .then(() => {
          getList()
          proxy.$modal.msgSuccess("删除成功")
        })
        .catch(() => { })


    }
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
    //   }
    // }
    RowdataSave(row, index)



  }

  //行内编辑 保存
  function RowdataSave(row, index) {


    let parm = {
      fpId: row.fpId,
      fpPlnt: row.fpPlnt,
      fpCode: row.fpCode,
      fpName: row.fpName,
      fpType: row.fpType,
      fpActDate: row.fpActDate,
      fpExpDate: row.fpExpDate,
    }



    //!row.pomId && row.pomId != undefined
    if (row.fpId != undefined) {
      updateFicoPrctr(parm).then(res => {
        proxy.$modal.msgSuccess("修改成功")
        getList()
      }).catch(e => {
        //this.resetRow()
        //this.handleDelete(row)
      })

    } else {
      addFicoPrctr(parm).then(response => {
        proxy.$modal.msgSuccess("新增成功")
        getList()
      }).catch(e => {
        proxy.$modal.msgError("新增失败")
        resetRow()
        //handleEraseRow(row, index, dataList)
      });
    }

  }

  //行内编辑 取消
  function handleCancelEditRow(row, index) {
    row.isEdit = false

  }
  // 增加一个空行, 用于录入或显示第一行
  function handleNew() {
    onInit()
  }
  // 函数增加空行
  const onInit = () => {
    dataList.value.push({
    })
  }

  //行内编辑 
  function handleEditRow(row, index) {
    row.isEdit = true

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
    const id = row.fpId || ids.value
    getFicoPrctr(id).then((res) => {
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
        if (form.value.fpId != undefined && opertype.value === 2) {
          updateFicoPrctr(form.value).then((res) => {
            proxy.$modal.msgSuccess("修改成功")
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addFicoPrctr(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
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
    const Ids = row.fpId || ids.value

    proxy.$confirm('是否确认删除ID为"' + Ids + '"的数据项？')
      .then(function () {
        return delFicoPrctr(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess("删除成功")
      })
      .catch(() => { })
  }



  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm("是否确认导出利润中心数据项?", "警告", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/financial/FicoPrctr/export', { ...queryParams })
      })
  }

  handleQuery()
</script>

<!-- primary = #2d8cf0
lightPrimary = #5cadff
darkPrimary = #2b85e4
info = #2db7f5
success = #19be6b
warning = #ff9900
error = #ed4014
title = #17233d
content = #515a6e
subColor = #808695
disabled = #c5c8ce
border = #dcdee2
divider = #e8eaec
background = #f8f8f9
menuColor = #465cb9
menuBgColor = #5873e8
aColor = #00c1de
lightSuccess = #dff0d8
lightInfo = #d9edf7
lightWarning = #fcf8e3
lightError = #f2dede
lightActive = #f5f5f5 -->