<!--
 * @Descripttion: (生产班组/pp_lines)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-25)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-25)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="班组类别" prop="plLineType">
        <el-select clearable v-model="queryParams.plLineType" placeholder="请选择班组类别">
          <el-option v-for="item in  options.sys_line_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组代码" prop="plLineCode">
        <el-input v-model="queryParams.plLineCode" placeholder="请输入班组代码" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:lines:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:lines:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:lines:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:lines:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="plId" label="ID" align="center" v-if="columns.showColumn('plId')" />
      <el-table-column prop="plLineType" label="班组类别" align="center" v-if="columns.showColumn('plLineType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_line_type " :value="scope.row.plLineType" />
        </template>
      </el-table-column>
      <el-table-column prop="plLineCode" label="班组代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plLineCode')" />
      <el-table-column prop="isDelete" label="软件删除" align="center" v-if="columns.showColumn('isDelete')" />
      <el-table-column prop="remark" label="remark" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="plLineName" label="班组名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plLineName')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:lines:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:lines:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改生产班组对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <!-- <el-col :lg="12">
            <el-form-item label="ID" prop="plId">
              <el-input-number v-model.number="form.plId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col> -->


          <el-col :lg="24">
            <el-form-item label="班组类别" prop="plLineType">
              <el-select v-model="form.plLineType" :placeholder="$t('btn.select')+'班组类别'"
                :disabled="title==proxy.$t('btn.edit')">
                <el-option v-for="item in  options.sys_line_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="班组代码" prop="plLineCode">
              <el-input v-model="form.plLineCode" :placeholder="$t('btn.enter')+'班组代码'"
                :disabled="title==proxy.$t('btn.edit')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="班组名称" prop="plLineName">
              <el-input v-model="form.plLineName" :placeholder="$t('btn.enter')+'班组名称'"
                :disabled="title==proxy.$t('btn.edit')" />
            </el-form-item>
          </el-col>

          <!-- <el-col :lg="12">
            <el-form-item label="软件删除" prop="isDelete">
              <el-input v-model="form.isDelete" :placeholder="$t('btn.enter')+'软件删除'"  :disabled="true"/>
            </el-form-item>
          </el-col> -->

          <!-- <el-col :lg="12">
            <el-form-item label="remark" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enter')+'remark'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="pplines">
  // 引入 pplines操作方法
  import {
    listPpLines, addPpLines, delPpLines, updatePpLines, getPpLines,

  }
    from '@/api/production/pplines.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中plId数组数组
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
    plLineType: undefined,
    plLineCode: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'plId', label: 'ID' },
    { visible: true, prop: 'plLineType', label: '班组类别' },
    { visible: true, prop: 'plLineCode', label: '班组代码' },
    { visible: false, prop: 'isDelete', label: '软件删除' },
    { visible: false, prop: 'remark', label: '' },
    { visible: true, prop: 'plLineName', label: '班组名称' },
  ])
  // 总条数
  const total = ref(0)
  // 生产班组表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


  var dictParams = [
    { dictType: "sys_line_type" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取生产班组表记录数据
  function getList() {
    loading.value = true
    listPpLines(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.plId);
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
      plLineType: [{ required: true, message: "班组类别" + proxy.$t('btn.empty'), trigger: "change" }],
      plLineCode: [{ required: true, message: "班组代码" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 班组类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_line_type: [],
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
      plLineType: undefined,
      plLineCode: undefined,
      remark: undefined,
      createBy: undefined,
      createTime: undefined,
      updateBy: undefined,
      updateTime: undefined,
      plLineName: undefined,
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
    const id = row.plId || ids.value
    getPpLines(id).then((res) => {
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
        if (form.value.plId != undefined && opertype.value === 2) {
          updatePpLines(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpLines(form.value).then((res) => {
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
    const Ids = row.plId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPpLines(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "生产班组", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Production/PpLines/export', { ...queryParams })
      })
  }

  handleQuery()
</script>