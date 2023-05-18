<template>
  <div class="app-container">
    <!-- :model属性用于表单验证使用 比如下面的el-form-item 的 prop属性用于对表单值进行验证操作 -->
    <el-form :model="queryParams" label-position="left" inline ref="queryForm" v-show="showSearch" @submit.prevent>
      <el-form-item label="" prop="fileId">
        <el-input v-model="queryParams.fileId" :placeholder="$t('btn.enter')+$t('f.fileID')" clearable />
      </el-form-item>
      <el-form-item label="">
        <el-date-picker v-model="dateRangeAddTime" type="daterange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :placeholder="$t('btn.dateselect')"></el-date-picker>
      </el-form-item>
      <el-form-item label="" prop="storeType">
        <el-select v-model="queryParams.storeType" :placeholder="$t('btn.select')+$t('f.storageType')" clearable="">
          <el-option v-for="item in storeTypeOptions" :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload" @click="handleAdd">
          {{ $t('btn.upload') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['tool:file:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="id" :label="$t('f.fileID')" align="center" width="150" />
      <el-table-column prop="fileName" :label="$t('f.fileDown')" width="500%" :show-overflow-tooltip="true">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.accessUrl" target="_blank">{{ scope.row.fileName
            }}</el-link>
        </template>
      </el-table-column>

      <el-table-column prop="fileSize" :label="$t('f.fileSize')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="fileExt" :label="$t('f.fileExt')" align="center" :show-overflow-tooltip="true"
        width="80px" />
      <el-table-column prop="storeType" :label="$t('f.fileStorageType')" align="center">
        <template #default="scope">
          {{ scope.row.storeType }}
          <!-- <dict-tag :options="storeTypeOptions" :value="parseInt(scope.row.storeType)" /> -->
        </template>
      </el-table-column>
      <el-table-column prop="create_by" :label="$t('f.fileOperator')" align="center" />
      <el-table-column prop="create_time" :label="$t('f.fileCreatedate')" align="center" width="150" />
      <el-table-column prop="accessUrl" align="center" :label="$t('f.filePreview')" width="100">
        <template #default="{ row }">
          <el-image preview-teleported :src="row.accessUrl" :preview-src-list="[row.accessUrl]"
            :hide-on-click-modal="true" fit="contain" lazy class="el-avatar">
            <template #error>
              <el-icon class="el-avatar" style="background:rgb(64, 60, 88); color: white">
                <Hide />
              </el-icon>
            </template>
          </el-image>
          <!-- <embed :src='row.accessUrl' type="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            width="90%" height="700px;" /> -->
          <!-- <embed :src='row.accessUrl' type="application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            width="90%" height="700px;" /> -->
          <!-- <embed :src='row.accessUrl' type="application/pdf" width="90%" height="700px;" /> -->
        </template>
      </el-table-column>
      <el-table-column :label="$t('f.fileOperation')" align="center" width="230">
        <template #default="scope">
          <el-button text size="small" icon="view" @click="handleView(scope.row)">{{ $t('btn.view') }}</el-button>
          <el-button class="copy-btn-main" icon="document-copy" text size="small"
            @click="copyText(scope.row.accessUrl)">
            {{ $t('btn.copy') }}
          </el-button>
          <el-button v-hasPermi="['tool:file:delete']" text size="small" icon="delete" @click="handleDelete(scope.row)">
            {{ $t('btn.delete') }}
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" width="600px" draggable>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="180px" label-position="right">
        <el-row>
          <el-col :lg="24">
            <el-form-item :label="proxy.$t('upload.StorageType')" prop="storeType">
              <el-radio-group v-model="form.storeType" :placeholder="proxy.$t('upload.StorageType')">
                <el-radio v-for="item in storeTypeOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="proxy.$t('upload.StorageFolder')" prop="storePath">
              <el-input v-model="form.storePath" :placeholder="proxy.$t('btn.enter')+proxy.$t('upload.StorageFolder')"
                clearable="" auto-complete="" disabled />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="proxy.$t('upload.Filenamerules')" prop="fileNameType">
              <el-radio-group v-model="form.fileNameType" :placeholder="proxy.$t('upload.Filenamerules')">
                <el-radio v-for="item in fileNameTypeOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.fileNameType == 2">
            <el-form-item :label="proxy.$t('upload.Customfilenames')" prop="fileName">
              <el-input v-model="form.fileName" :placeholder="proxy.$t('upload.Customfilenames')" clearable="" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <UploadFile ref="uploadRef" v-model="form.accessUrl" :fileType="['pdf']" :fileSize="10" :drag="true"
              :data="uploadData" :autoUpload="false" @success="handleUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

    <!-- 添加或修改文件存储对话框 -->
    <el-dialog :title="proxy.$t('btn.view')" :lock-scroll="false" v-model="openView">
      <el-form ref="form" :model="formView" :rules="rules" label-width="100px">
        <el-row>
          <el-col :lg="12">
            <el-form-item label="文件id">{{ formView.id }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="源文件名">{{ formView.realName }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="文件类型">
              <el-tag>{{ formView.fileType }}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="扩展名">
              <el-tag>{{ formView.fileExt }}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="文件名">{{ formView.fileName }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="仓库位置">{{ formView.storePath }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="文件大小">{{ formView.fileSize }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="创建人">{{ formView.create_by }}</el-form-item>
          </el-col>
          <el-col :lg="24" v-if="['.png', '.jpg', '.jpeg'].includes(formView.fileExt)">
            <el-form-item label="预览">
              <el-image :src="formView.accessUrl" fit="contain" style="width: 100px"></el-image>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label="访问路径">
              {{ formView.accessUrl }}
              <el-button class="copy-btn-main" icon="document-copy" text @click="copyText(formView.accessUrl)">
                {{ $t('btn.copy') }}
              </el-button>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label="存储路径">{{ formView.fileUrl }}</el-form-item>
          </el-col>
        </el-row>
      </el-form>
    </el-dialog>
  </div>
</template>
<script setup name="sysfile">
  import { listSysfile, delSysfile, getSysfile } from '@/api/tool/file.js'
  import { useClipboard } from '@vueuse/core'
  // 选中id数组
  const ids = ref([])
  // 非单个禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 遮罩层
  const loading = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  const openView = ref(false)
  // 表单
  const formRef = ref(null)
  const formView = ref({})
  const uploadRef = ref(null)
  // 上传时间时间范围
  const dateRangeAddTime = ref([])
  // 存储类型选项列表
  const storeTypeOptions = ref([
    { dictLabel: '本地存储', dictValue: 1 },
    //暂不开放
    // { dictLabel: '阿里云存储', dictValue: 2 }
  ])
  //文件名产生选项列表
  const fileNameTypeOptions = ref([
    { dictLabel: '原文件名', dictValue: 1 },
    //暂不支持
    //{ dictLabel: '自定义', dictValue: 2 },
    //{ dictLabel: '自动生成', dictValue: 3 }
  ])
  // 数据列表
  const dataList = ref([])
  // 总记录数
  const total = ref(0)

  const state = reactive({
    form: {
      storeType: 1
    },
    rules: {
      accessUrl: [
        {
          required: true,
          message: '上传文件不能为空',
          trigger: 'blur'
        }
      ],
      storeType: [
        {
          required: true,
          message: '存储类型不能为空',
          trigger: 'blur'
        }
      ],
      fileName: [
        {
          required: true,
          message: '文件名不能为空',
          trigger: 'blur'
        }
      ]
    },
    queryParams: {
      pageNum: 1,
      pageSize: 20,
      storeType: 1, // 存储类型 1、本地 2、阿里云
      fileId: undefined
    }
  })
  const { queryParams, form, rules } = toRefs(state)
  const { proxy } = getCurrentInstance()
  const uploadData = ref({})
  // 查询数据
  function getList() {
    proxy.addDateRange(queryParams.value, dateRangeAddTime.value, 'Create_time')
    loading.value = true
    listSysfile(queryParams.value).then((res) => {
      if (res.code == 200) {
        dataList.value = res.data.result
        total.value = res.data.totalNum
        loading.value = false
      }
    })
  }
  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  // 重置数据表单
  function reset() {
    form.value = {
      fileName: '',
      fileUrl: '',
      storePath: '',
      fileSize: 0,
      fileExt: '',
      storeType: 1,
      accessUrl: '',
      fileNameType: 1
    }
    proxy.resetForm('formRef')
  }
  /** 重置查询操作 */
  function resetQuery() {
    // 上传时间时间范围
    dateRangeAddTime.value = []
    proxy.resetForm('queryForm')
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }
  // 下载

  /** 删除按钮操作 */
  function handleDelete(row) {
    const Ids = row.id || ids.value
    proxy
      .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？', proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delSysfile(Ids)
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess('删除成功')
      })
      .catch(() => { })
  }
  /** 查看按钮操作 */
  function handleView(row) {
    const id = row.id || ids.value
    getSysfile(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        openView.value = true
        formView.value = data
      }
    })
  }
  // 上传成功方法
  function handleUploadSuccess(filelist) {
    open.value = false
    getList()
  }
  // 手动上传
  function submitUpload() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        uploadData.value = {
          fileDir: form.value.storePath,
          fileName: form.value.fileName,
          storeType: form.value.storeType,
          fileNameType: form.value.fileNameType
        }
        proxy.$refs.uploadRef.submitUpload()
      }
    })
  }

  const { copy, isSupported } = useClipboard()
  const copyText = async (val) => {
    if (isSupported) {
      copy(val)
      proxy.$modal.msgSuccess('复制成功！')
    } else {
      proxy.$modal.msgError('当前浏览器不支持')
    }
  }
  handleQuery()
</script>
<style scoped>
  .el-avatar {
    display: inline-block;
    text-align: center;
    background: #ccc;
    color: #fff;
    white-space: nowrap;
    position: relative;
    overflow: hidden;
    vertical-align: middle;
    width: 32px;
    height: 32px;
    line-height: 32px;
    border-radius: 16px;
  }
</style>