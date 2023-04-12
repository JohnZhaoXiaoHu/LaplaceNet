<!--
 * @Descripttion: (部门消耗/fico_dept_consuming)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-11)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-11)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="年月" prop="dcYm">
        <el-select filterable clearable v-model="queryParams.dcYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="dcCorpCode">
        <el-select filterable clearable v-model="queryParams.dcCorpCode" :placeholder="$t('btn.select')+'公司代码'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="统计类别" prop="dcExpCategory">
        <el-select filterable clearable v-model="queryParams.dcExpCategory" :placeholder="$t('btn.select')+'统计类别'">
          <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['la:ficodeptconsuming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:ficodeptconsuming:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:ficodeptconsuming:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport"
          v-hasPermi="['la:ficodeptconsuming:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport"
          v-hasPermi="['la:ficodeptconsuming:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%" :summary-method="getSummaries"
      show-summary>
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="dcId" label="ID" align="center" v-if="columns.showColumn('dcId')" />
      <el-table-column prop="dcFy" label="期间" align="center" v-if="columns.showColumn('dcFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.dcFy" />
        </template>
      </el-table-column>
      <el-table-column prop="dcYm" label="年月" align="center" v-if="columns.showColumn('dcYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.dcYm" />
        </template>
      </el-table-column>
      <el-table-column prop="dcCorpCode" label="公司代码" align="center" v-if="columns.showColumn('dcCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.dcCorpCode" />
        </template>
      </el-table-column>
      <el-table-column prop="dcCorpName" label="公司名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcCorpName')" />
      <el-table-column prop="dcExpCategory" label="统计类别" align="center" v-if="columns.showColumn('dcExpCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_fin_costtype " :value="scope.row.dcExpCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="dcCostCode" label="成本代码" align="center" v-if="columns.showColumn('dcCostCode')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.dcCostCode" />
        </template>
      </el-table-column>
      <el-table-column prop="dcCostName" label="成本名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcCostName')" />
      <el-table-column prop="dcTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcTitleCode')" />
      <el-table-column prop="dcTitleName" label="科目名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcTitleName')" />
      <el-table-column prop="dcTitleNote" label="科目分类" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcTitleNote')" />
      <el-table-column prop="dcBudgetAmt" label="预算" align="center" v-if="columns.showColumn('dcBudgetAmt')" />
      <el-table-column prop="dcActualAmt" label="实际" align="center" v-if="columns.showColumn('dcActualAmt')" />
      <el-table-column prop="dcDiffAmt" label="差异" align="center" v-if="columns.showColumn('dcDiffAmt')" />
      <el-table-column prop="dcPlant" label="工厂" align="center" v-if="columns.showColumn('dcPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.dcPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="dcMateriel" label="物料" align="center" v-if="columns.showColumn('dcMateriel')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.dcMateriel" />
        </template>
      </el-table-column>
      <el-table-column prop="dcStorageLocation" label="仓库" align="center"
        v-if="columns.showColumn('dcStorageLocation')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.dcStorageLocation" />
        </template>
      </el-table-column>
      <el-table-column prop="dcMoveType" label="移动类型" align="center" v-if="columns.showColumn('dcMoveType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mats_type " :value="scope.row.dcMoveType" />
        </template>
      </el-table-column>
      <el-table-column prop="dcMaterielDoc" label="物料凭证" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcMaterielDoc')" />
      <el-table-column prop="dcMaterielDocDetails" label="凭证明细" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcMaterielDocDetails')" />
      <el-table-column prop="dcUseQty" label="数量" align="center" v-if="columns.showColumn('dcUseQty')" />
      <el-table-column prop="dcUseAmt" label="金额" align="center" v-if="columns.showColumn('dcUseAmt')" />
      <el-table-column prop="dcReserveDoc" label="预留单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcReserveDoc')" />
      <el-table-column prop="dcAccountant" label="预留明细" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcAccountant')" />
      <el-table-column prop="dcBalanceDate" label="登录日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dcBalanceDate')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:ficodeptconsuming:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:ficodeptconsuming:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改部门消耗对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="dcId">
              <el-input-number clearable v-model.number="form.dcId" controls-position="right"
                :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="期间" prop="dcFy">
              <el-select v-model="form.dcFy" filterable clearable :placeholder="$t('btn.select')+'期间'">
                <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="dcYm">
              <el-select v-model="form.dcYm" filterable clearable :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="dcCorpCode">
              <el-select v-model="form.dcCorpCode" filterable clearable :placeholder="$t('btn.select')+'公司代码'">
                <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司名称" prop="dcCorpName">
              <el-input clearable v-model="form.dcCorpName" :placeholder="$t('btn.enter')+'公司名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统计类别" prop="dcExpCategory">
              <el-select v-model="form.dcExpCategory" filterable clearable :placeholder="$t('btn.select')+'统计类别'">
                <el-option v-for="item in  options.sys_fin_costtype " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本代码" prop="dcCostCode">
              <el-select v-model="form.dcCostCode" filterable clearable :placeholder="$t('btn.select')+'成本代码'">
                <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本名称" prop="dcCostName">
              <el-input clearable v-model="form.dcCostName" :placeholder="$t('btn.enter')+'成本名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="dcTitleCode">
              <el-input clearable v-model="form.dcTitleCode" :placeholder="$t('btn.enter')+'科目代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="dcTitleName">
              <el-input clearable v-model="form.dcTitleName" :placeholder="$t('btn.enter')+'科目名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="dcTitleNote">
              <el-input clearable v-model="form.dcTitleNote" :placeholder="$t('btn.enter')+'科目分类'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="dcBudgetAmt">
              <el-input clearable v-model="form.dcBudgetAmt" :placeholder="$t('btn.enter')+'预算'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="dcActualAmt">
              <el-input clearable v-model="form.dcActualAmt" :placeholder="$t('btn.enter')+'实际'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="dcDiffAmt">
              <el-input clearable v-model="form.dcDiffAmt" :placeholder="$t('btn.enter')+'差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="dcPlant">
              <el-select v-model="form.dcPlant" filterable clearable :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="dcMateriel">
              <el-select v-model="form.dcMateriel" filterable clearable :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="dcStorageLocation">
              <el-select v-model="form.dcStorageLocation" filterable clearable :placeholder="$t('btn.select')+'仓库'">
                <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="dcMoveType">
              <el-select v-model="form.dcMoveType" filterable clearable :placeholder="$t('btn.select')+'移动类型'">
                <el-option v-for="item in  options.sys_mats_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="dcMaterielDoc">
              <el-input clearable v-model="form.dcMaterielDoc" :placeholder="$t('btn.enter')+'物料凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="dcMaterielDocDetails">
              <el-input-number clearable v-model.number="form.dcMaterielDocDetails" :controls="true"
                controls-position="right" :placeholder="$t('btn.enter')+'凭证明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dcUseQty">
              <el-input-number clearable v-model.number="form.dcUseQty" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="dcUseAmt">
              <el-input clearable v-model="form.dcUseAmt" :placeholder="$t('btn.enter')+'金额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="dcReserveDoc">
              <el-input clearable v-model="form.dcReserveDoc" :placeholder="$t('btn.enter')+'预留单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="dcAccountant">
              <el-input clearable v-model="form.dcAccountant" :placeholder="$t('btn.enter')+'预留明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="dcBalanceDate">
              <el-date-picker clearable v-model="form.dcBalanceDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'说明'"
                :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateBy" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'CreateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CreateTime" prop="createTime">
              <el-date-picker clearable v-model="form.createTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateBy" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'UpdateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UpdateTime" prop="updateTime">
              <el-date-picker clearable v-model="form.updateTime" type="datetime" :teleported="false"
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

<script setup name="ficodeptconsuming">
  // 引入 ficodeptconsuming操作方法
  import {
    listFicoDeptConsuming, addFicoDeptConsuming, delFicoDeptConsuming, updateFicoDeptConsuming, getFicoDeptConsuming,

  }
    from '@/api/financial/ficodeptconsuming.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中dcId数组数组
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
    dcYm: undefined,
    dcCorpCode: undefined,
    dcExpCategory: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'dcId', label: 'ID' },
    { visible: false, prop: 'dcFy', label: '期间' },
    { visible: true, prop: 'dcYm', label: '年月' },
    { visible: false, prop: 'dcCorpCode', label: '公司代码' },
    { visible: false, prop: 'dcCorpName', label: '公司名称' },
    { visible: false, prop: 'dcExpCategory', label: '统计类别' },
    { visible: false, prop: 'dcCostCode', label: '成本代码' },
    { visible: true, prop: 'dcCostName', label: '成本名称' },
    { visible: false, prop: 'dcTitleCode', label: '科目代码' },
    { visible: false, prop: 'dcTitleName', label: '科目名称' },
    { visible: true, prop: 'dcTitleNote', label: '科目分类' },
    { visible: false, prop: 'dcBudgetAmt', label: '预算' },
    { visible: false, prop: 'dcActualAmt', label: '实际' },
    { visible: false, prop: 'dcDiffAmt', label: '差异' },
    { visible: true, prop: 'dcPlant', label: '工厂' },
    { visible: true, prop: 'dcMateriel', label: '物料' },
    { visible: true, prop: 'dcStorageLocation', label: '仓库' },
    { visible: true, prop: 'dcMoveType', label: '移动类型' },
    { visible: true, prop: 'dcMaterielDoc', label: '物料凭证' },
    { visible: true, prop: 'dcMaterielDocDetails', label: '凭证明细' },
    { visible: true, prop: 'dcUseQty', label: '数量' },
    { visible: true, prop: 'dcUseAmt', label: '金额' },
    { visible: false, prop: 'dcReserveDoc', label: '预留单' },
    { visible: false, prop: 'dcAccountant', label: '预留明细' },
    { visible: true, prop: 'dcBalanceDate', label: '登录日期' },
  ])
  // 总条数
  const total = ref(0)
  // 部门消耗表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


  var dictParams = [
    { dictType: "sql_period_list" },
    { dictType: "sql_ym_list" },
    { dictType: "sys_crop_list" },
    { dictType: "sys_fin_costtype" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_plant_list" },
    { dictType: "sql_moc_item" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_mats_type" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取部门消耗表记录数据
  function getList() {
    loading.value = true
    listFicoDeptConsuming(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }
  //合计
  function getSummaries(param) {
    const { columns, data } = param
    const sums = []
    columns.forEach((column, index) => {
      if (index === 0) {
        sums[index] = '合计'
        return
      }
      const values = data.map((item) => Number(item[column.property]))
      if (column.property === 'dcUseQty' || column.property === 'dcUseAmt') {
        sums[index] = values.reduce((prev, curr) => {
          const value = Number(curr)
          if (!isNaN(value)) {
            return Number(Number(prev) + Number(curr)).toFixed(2)
          } else {
            return prev
          }
        }, 0)
        sums[index]
      }
    })
    return sums

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
    ids.value = selection.map((item) => item.dcId);
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
      dcFy: [{ required: true, message: "期间" + proxy.$t('btn.empty'), trigger: "change" }],
      dcYm: [{ required: true, message: "年月" + proxy.$t('btn.empty'), trigger: "change" }],
      dcCorpCode: [{ required: true, message: "公司代码" + proxy.$t('btn.empty'), trigger: "change" }],
      dcCorpName: [{ required: true, message: "公司名称" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcExpCategory: [{ required: true, message: "统计类别" + proxy.$t('btn.empty'), trigger: "change" }],
      dcCostCode: [{ required: true, message: "成本代码" + proxy.$t('btn.empty'), trigger: "change" }],
      dcCostName: [{ required: true, message: "成本名称" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcTitleCode: [{ required: true, message: "科目代码" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcTitleName: [{ required: true, message: "科目名称" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcTitleNote: [{ required: true, message: "科目分类" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcBudgetAmt: [{ required: true, message: "预算" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcActualAmt: [{ required: true, message: "实际" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcDiffAmt: [{ required: true, message: "差异" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcPlant: [{ required: true, message: "工厂" + proxy.$t('btn.empty'), trigger: "change" }],
      dcMateriel: [{ required: true, message: "物料" + proxy.$t('btn.empty'), trigger: "change" }],
      dcStorageLocation: [{ required: true, message: "仓库" + proxy.$t('btn.empty'), trigger: "change" }],
      dcMoveType: [{ required: true, message: "移动类型" + proxy.$t('btn.empty'), trigger: "change" }],
      dcMaterielDoc: [{ required: true, message: "物料凭证" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcMaterielDocDetails: [{ required: true, message: "凭证明细" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcUseQty: [{ required: true, message: "数量" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcUseAmt: [{ required: true, message: "金额" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcReserveDoc: [{ required: true, message: "预留单" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcAccountant: [{ required: true, message: "预留明细" + proxy.$t('btn.empty'), trigger: "blur" }],
      dcBalanceDate: [{ required: true, message: "登录日期" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_period_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ym_list: [],
      // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 统计类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_fin_costtype: [],
      // 成本代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
      // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 移动类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_mats_type: [],
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
      dcFy: undefined,
      dcYm: undefined,
      dcCorpCode: undefined,
      dcCorpName: undefined,
      dcExpCategory: undefined,
      dcCostCode: undefined,
      dcCostName: undefined,
      dcTitleCode: undefined,
      dcTitleName: undefined,
      dcTitleNote: undefined,
      dcBudgetAmt: undefined,
      dcActualAmt: undefined,
      dcDiffAmt: undefined,
      dcPlant: undefined,
      dcMateriel: undefined,
      dcStorageLocation: undefined,
      dcMoveType: undefined,
      dcMaterielDoc: undefined,
      dcMaterielDocDetails: undefined,
      dcUseQty: undefined,
      dcUseAmt: undefined,
      dcReserveDoc: undefined,
      dcAccountant: undefined,
      dcBalanceDate: undefined,
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
    opertype.value = 1
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.dcId || ids.value
    getFicoDeptConsuming(id).then((res) => {
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
        if (form.value.dcId != undefined && opertype.value === 2) {
          updateFicoDeptConsuming(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addFicoDeptConsuming(form.value).then((res) => {
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
    const Ids = row.dcId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delFicoDeptConsuming(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "部门消耗", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Financial/FicoDeptConsuming/export', { ...queryParams })
      })
  }

  handleQuery()
</script>