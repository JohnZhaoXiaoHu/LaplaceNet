<!--
 * @Descripttion: (销售凭证/sd_sales_proof)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="spPlnt">
        <el-select filterable clearable  v-model="queryParams.spPlnt" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="spYm">
        <el-select filterable clearable  v-model="queryParams.spYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户" prop="spCustomerCode">
        <el-select filterable clearable  v-model="queryParams.spCustomerCode" :placeholder="$t('btn.select')+'客户'">
          <el-option v-for="item in  options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="spPrctr">
        <el-select filterable clearable  v-model="queryParams.spPrctr" :placeholder="$t('btn.select')+'利润中心'">
          <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="spSalesItem">
        <el-select filterable clearable  v-model="queryParams.spSalesItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['sd:salesproof:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sd:salesproof:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sd:salesproof:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['sd:salesproof:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="spId" label="ID" align="center" v-if="columns.showColumn('spId')"/>
      <el-table-column prop="spPlnt" label="工厂" align="center" v-if="columns.showColumn('spPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.spPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="spFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spFy')"/>
      <el-table-column prop="spYm" label="年月" align="center" v-if="columns.showColumn('spYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.spYm" />
        </template>
      </el-table-column>
      <el-table-column prop="spProofNo" label="销售凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spProofNo')"/>
      <el-table-column prop="spProofDetails" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spProofDetails')"/>
      <el-table-column prop="spCustomerCode" label="客户" align="center" v-if="columns.showColumn('spCustomerCode')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.spCustomerCode" />
        </template>
      </el-table-column>
      <el-table-column prop="spPrctr" label="利润中心" align="center" v-if="columns.showColumn('spPrctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.spPrctr" />
        </template>
      </el-table-column>
      <el-table-column prop="spSalesItem" label="物料" align="center" v-if="columns.showColumn('spSalesItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.spSalesItem" />
        </template>
      </el-table-column>
      <el-table-column prop="spTitleCode" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spTitleCode')"/>
      <el-table-column prop="spSalesQty" label="销售数量" align="center" v-if="columns.showColumn('spSalesQty')"/>
      <el-table-column prop="spSalesUnit" label="销售单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spSalesUnit')"/>
      <el-table-column prop="spOriginalAmount" label="原币销售额" align="center" v-if="columns.showColumn('spOriginalAmount')"/>
      <el-table-column prop="spOriginalCcy" label="原币币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spOriginalCcy')"/>
      <el-table-column prop="spLocalAmount" label="本币销售额" align="center" v-if="columns.showColumn('spLocalAmount')"/>
      <el-table-column prop="spLocalCcy" label="本币币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spLocalCcy')"/>
      <el-table-column prop="spReferenceNo" label="参考凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spReferenceNo')"/>
      <el-table-column prop="spReferenceDetails" label="参考明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spReferenceDetails')"/>
      <el-table-column prop="spPostingDate" label="过账日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spPostingDate')"/>
      <el-table-column prop="spPostingUser" label="用户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spPostingUser')"/>
      <el-table-column prop="spEntryDate" label="输入日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spEntryDate')"/>
      <el-table-column prop="spEntryTime" label="输入时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spEntryTime')"/>
      <el-table-column prop="spOrigin" label="来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spOrigin')"/>
      <el-table-column prop="spPgroup" label="产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spPgroup')"/>
      <el-table-column prop="spInvoiceType" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spInvoiceType')"/>
      <el-table-column prop="spInvoiceText" label="凭证名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spInvoiceText')"/>
      <el-table-column prop="spBalancedate" label="登入日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spBalancedate')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['sd:salesproof:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sd:salesproof:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改销售凭证对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="spId">
              <el-input-number clearable v-model.number="form.spId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂" prop="spPlnt">
              <el-select v-model="form.spPlnt" filterable clearable  :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="spFy">
              <el-input clearable v-model="form.spFy" :placeholder="$t('btn.enter')+'期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="spYm">
              <el-select v-model="form.spYm" filterable clearable  :placeholder="$t('btn.select')+'年月'">
                <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售凭证" prop="spProofNo">
              <el-input clearable v-model="form.spProofNo" :placeholder="$t('btn.enter')+'销售凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="spProofDetails">
              <el-input clearable v-model="form.spProofDetails" :placeholder="$t('btn.enter')+'凭证明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="spCustomerCode">
              <el-select v-model="form.spCustomerCode" filterable clearable  :placeholder="$t('btn.select')+'客户'">
                <el-option v-for="item in  options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="spPrctr">
              <el-select v-model="form.spPrctr" filterable clearable  :placeholder="$t('btn.select')+'利润中心'">
                <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="spSalesItem">
              <el-select v-model="form.spSalesItem" filterable clearable  :placeholder="$t('btn.select')+'物料'">
                <el-option v-for="item in  options.sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="spTitleCode">
              <el-input clearable v-model="form.spTitleCode" :placeholder="$t('btn.enter')+'科目'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售数量" prop="spSalesQty">
              <el-input clearable v-model="form.spSalesQty" :placeholder="$t('btn.enter')+'销售数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售单位" prop="spSalesUnit">
              <el-input clearable v-model="form.spSalesUnit" :placeholder="$t('btn.enter')+'销售单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币销售额" prop="spOriginalAmount">
              <el-input clearable v-model="form.spOriginalAmount" :placeholder="$t('btn.enter')+'原币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币币种" prop="spOriginalCcy">
              <el-input clearable v-model="form.spOriginalCcy" :placeholder="$t('btn.enter')+'原币币种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币销售额" prop="spLocalAmount">
              <el-input clearable v-model="form.spLocalAmount" :placeholder="$t('btn.enter')+'本币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币币种" prop="spLocalCcy">
              <el-input clearable v-model="form.spLocalCcy" :placeholder="$t('btn.enter')+'本币币种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考凭证" prop="spReferenceNo">
              <el-input clearable v-model="form.spReferenceNo" :placeholder="$t('btn.enter')+'参考凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考明细" prop="spReferenceDetails">
              <el-input clearable v-model="form.spReferenceDetails" :placeholder="$t('btn.enter')+'参考明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过账日期" prop="spPostingDate">
              <el-date-picker clearable v-model="form.spPostingDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户" prop="spPostingUser">
              <el-input clearable v-model="form.spPostingUser" :placeholder="$t('btn.enter')+'用户'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日期" prop="spEntryDate">
              <el-date-picker clearable v-model="form.spEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入时间" prop="spEntryTime">
              <el-input clearable v-model="form.spEntryTime" :placeholder="$t('btn.enter')+'输入时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="来源" prop="spOrigin">
              <el-input clearable v-model="form.spOrigin" :placeholder="$t('btn.enter')+'来源'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组" prop="spPgroup">
              <el-input clearable v-model="form.spPgroup" :placeholder="$t('btn.enter')+'产品组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="spInvoiceType">
              <el-input clearable v-model="form.spInvoiceType" :placeholder="$t('btn.enter')+'凭证类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证名称" prop="spInvoiceText">
              <el-input clearable v-model="form.spInvoiceText" :placeholder="$t('btn.enter')+'凭证名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登入日期" prop="spBalancedate">
              <el-date-picker clearable v-model="form.spBalancedate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input clearable v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker clearable v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker clearable v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="sdsalesproof">
// 引入 sdsalesproof操作方法
import { listSdSalesProof, addSdSalesProof, delSdSalesProof, updateSdSalesProof, getSdSalesProof, 
 
 } 
from '@/api/sales/sdsalesproof.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中spId数组数组
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
  spPlnt: undefined,
  spYm: undefined,
  spCustomerCode: undefined,
  spPrctr: undefined,
  spSalesItem: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'spId', label: 'ID' },
  { visible: true, prop: 'spPlnt', label: '工厂' },
  { visible: true, prop: 'spFy', label: '期间' },
  { visible: true, prop: 'spYm', label: '年月' },
  { visible: true, prop: 'spProofNo', label: '销售凭证' },
  { visible: true, prop: 'spProofDetails', label: '凭证明细' },
  { visible: true, prop: 'spCustomerCode', label: '客户' },
  { visible: true, prop: 'spPrctr', label: '利润中心' },
  { visible: false, prop: 'spSalesItem', label: '物料' },
  { visible: false, prop: 'spTitleCode', label: '科目' },
  { visible: false, prop: 'spSalesQty', label: '销售数量' },
  { visible: false, prop: 'spSalesUnit', label: '销售单位' },
  { visible: false, prop: 'spOriginalAmount', label: '原币销售额' },
  { visible: false, prop: 'spOriginalCcy', label: '原币币种' },
  { visible: false, prop: 'spLocalAmount', label: '本币销售额' },
  { visible: false, prop: 'spLocalCcy', label: '本币币种' },
  { visible: false, prop: 'spReferenceNo', label: '参考凭证' },
  { visible: false, prop: 'spReferenceDetails', label: '参考明细' },
  { visible: false, prop: 'spPostingDate', label: '过账日期' },
  { visible: false, prop: 'spPostingUser', label: '用户' },
  { visible: false, prop: 'spEntryDate', label: '输入日期' },
  { visible: false, prop: 'spEntryTime', label: '输入时间' },
  { visible: false, prop: 'spOrigin', label: '来源' },
  { visible: false, prop: 'spPgroup', label: '产品组' },
  { visible: false, prop: 'spInvoiceType', label: '凭证类型' },
  { visible: false, prop: 'spInvoiceText', label: '凭证名称' },
  { visible: false, prop: 'spBalancedate', label: '登入日期' },
])
  // 总条数
const total = ref(0)
  // 销售凭证表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sql_cus_list" },
  { dictType: "sql_prctr_list" },
  { dictType: "sql_mats_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取销售凭证表记录数据
function getList(){
  loading.value = true
  listSdSalesProof(queryParams).then(res => {
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
function resetQuery(){
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.spId);
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
    spPlnt: [{ required: true, message: "工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    spFy: [{ required: true, message: "期间"+proxy.$t('btn.empty'), trigger: "blur" }],
    spYm: [{ required: true, message: "年月"+proxy.$t('btn.empty'), trigger: "change" }],
    spProofNo: [{ required: true, message: "销售凭证"+proxy.$t('btn.empty'), trigger: "blur" }],
    spProofDetails: [{ required: true, message: "凭证明细"+proxy.$t('btn.empty'), trigger: "blur" }],
    spCustomerCode: [{ required: true, message: "客户"+proxy.$t('btn.empty'), trigger: "change" }],
    spPrctr: [{ required: true, message: "利润中心"+proxy.$t('btn.empty'), trigger: "change" }],
    spSalesItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "change" }],
    spTitleCode: [{ required: true, message: "科目"+proxy.$t('btn.empty'), trigger: "blur" }],
    spSalesQty: [{ required: true, message: "销售数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    spSalesUnit: [{ required: true, message: "销售单位"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalAmount: [{ required: true, message: "原币销售额"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalCcy: [{ required: true, message: "原币币种"+proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalAmount: [{ required: true, message: "本币销售额"+proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalCcy: [{ required: true, message: "本币币种"+proxy.$t('btn.empty'), trigger: "blur" }],
    spReferenceNo: [{ required: true, message: "参考凭证"+proxy.$t('btn.empty'), trigger: "blur" }],
    spReferenceDetails: [{ required: true, message: "参考明细"+proxy.$t('btn.empty'), trigger: "blur" }],
    spPostingDate: [{ required: true, message: "过账日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    spPostingUser: [{ required: true, message: "用户"+proxy.$t('btn.empty'), trigger: "blur" }],
    spEntryDate: [{ required: true, message: "输入日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    spEntryTime: [{ required: true, message: "输入时间"+proxy.$t('btn.empty'), trigger: "blur" }],
    spOrigin: [{ required: true, message: "来源"+proxy.$t('btn.empty'), trigger: "blur" }],
    spPgroup: [{ required: true, message: "产品组"+proxy.$t('btn.empty'), trigger: "blur" }],
    spInvoiceType: [{ required: true, message: "凭证类型"+proxy.$t('btn.empty'), trigger: "blur" }],
    spInvoiceText: [{ required: true, message: "凭证名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    spBalancedate: [{ required: true, message: "登入日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    isDelete: [{ required: true, message: "软删除"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ym_list: [],
    // 客户 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_cus_list: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_prctr_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_mats_list: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    spPlnt: undefined,
    spFy: undefined,
    spYm: undefined,
    spProofNo: undefined,
    spProofDetails: undefined,
    spCustomerCode: undefined,
    spPrctr: undefined,
    spSalesItem: undefined,
    spTitleCode: undefined,
    spSalesQty: undefined,
    spSalesUnit: undefined,
    spOriginalAmount: undefined,
    spOriginalCcy: undefined,
    spLocalAmount: undefined,
    spLocalCcy: undefined,
    spReferenceNo: undefined,
    spReferenceDetails: undefined,
    spPostingDate: undefined,
    spPostingUser: undefined,
    spEntryDate: undefined,
    spEntryTime: undefined,
    spOrigin: undefined,
    spPgroup: undefined,
    spInvoiceType: undefined,
    spInvoiceText: undefined,
    spBalancedate: undefined,
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
  const id = row.spId || ids.value
  getSdSalesProof(id).then((res) => {
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
      if (form.value.spId != undefined && opertype.value === 2) {
        updateSdSalesProof(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addSdSalesProof(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
          .catch(() => {})
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.spId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delSdSalesProof(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"销售凭证", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/sales/SdSalesProof/export', { ...queryParams })
    })
}

handleQuery()
</script>