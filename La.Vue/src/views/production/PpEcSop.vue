<!--
 * @Descripttion: (SOP/pp_ec_sop)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-05-03)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-05-03)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="发行日期">
        <el-date-picker v-model="dateRangeEsIssueDate" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :placeholder="$t('btn.select')+'发行日期'" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="esEcNo">
        <el-select filterable clearable v-model="queryParams.esEcNo" :placeholder="$t('btn.select')+'设变No.'">
          <el-option v-for="item in  options.sql_ec_no " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种" prop="esModel">
        <el-select filterable clearable v-model="queryParams.esModel" :placeholder="$t('btn.select')+'机种'">
          <el-option v-for="item in  options.sql_ec_model " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="esItem">
        <el-select filterable clearable v-model="queryParams.esItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  options.sql_ec_item " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['pp:ecsop:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecsop:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecsop:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['pp:ecsop:delete']" plain icon="delete" @click="handleClear">
          {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:ecsop:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecsop:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="esId" label="ID" align="center" v-if="columns.showColumn('esId')" />
      <el-table-column prop="esIssueDate" label="发行日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIssueDate')" />
      <el-table-column prop="esEcNo" label="设变No." align="center" v-if="columns.showColumn('esEcNo')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_no " :value="scope.row.esEcNo" />
        </template>
      </el-table-column>
      <el-table-column prop="esEntryDate" label="输入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esEntryDate')" />
      <el-table-column prop="esAssigned" label="担当者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esAssigned')" />
      <el-table-column prop="esModel" label="机种" align="center" v-if="columns.showColumn('esModel')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_model " :value="scope.row.esModel" />
        </template>
      </el-table-column>
      <el-table-column prop="esItem" label="物料" align="center" v-if="columns.showColumn('esItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_item " :value="scope.row.esItem" />
        </template>
      </el-table-column>
      <el-table-column prop="esPeaAssigned" label="生技担当" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPeaAssigned')" />
      <el-table-column prop="isPeaModifysop" label="组立变更否" align="center" v-if="columns.showColumn('isPeaModifysop')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.isPeaModifysop" />
        </template>
      </el-table-column>
      <el-table-column prop="esPeaDate" label="日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPeaDate')" />
      <el-table-column prop="esPeaNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPeaNote')" />
      <el-table-column prop="emPeaDocNo" label="版本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emPeaDocNo')" />
      <el-table-column prop="emPeaDoc" label="组立文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emPeaDoc')" />
      <el-table-column prop="esPeaModifier" label="组立确认" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPeaModifier')" />
      <el-table-column prop="esPeaModifyTime" label="组立确认日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPeaModifyTime')" />
      <el-table-column prop="esPepAssigned" label="生技担当" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPepAssigned')" />
      <el-table-column prop="isPepModifysop" label="PCBA变更否" align="center" v-if="columns.showColumn('isPepModifysop')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.isPepModifysop" />
        </template>
      </el-table-column>
      <el-table-column prop="esPepDate" label="日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPepDate')" />
      <el-table-column prop="esPepNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPepNote')" />
      <el-table-column prop="emPepDocNo" label="版本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emPepDocNo')" />
      <el-table-column prop="emPepDoc" label="PCBA文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emPepDoc')" />
      <el-table-column prop="esPepModifier" label="PCBA确认" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPepModifier')" />
      <el-table-column prop="esPepModifyTime" label="PCBA确认日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPepModifyTime')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecsop:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecsop:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改SOP对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <!-- <el-col :lg="12">
            <el-form-item label="ID" prop="esId">
              <el-input-number clearable v-model.number="form.esId" controls-position="right"
                :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col> -->


          <el-col :lg="12">
            <el-form-item label="发行日期" prop="esIssueDate">
              <el-date-picker clearable v-model="form.esIssueDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')" :disabled="title==$t('btn.edit')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="esEcNo">
              <el-select v-model="form.esEcNo" filterable clearable :placeholder="$t('btn.select')+'设变No.'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sql_ec_no " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日期" prop="esEntryDate">
              <el-date-picker clearable v-model="form.esEntryDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当者" prop="esAssigned">
              <el-input clearable v-model="form.esAssigned" :placeholder="$t('btn.enter')+'担当者'"
                :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="esModel">
              <el-select v-model="form.esModel" filterable clearable :placeholder="$t('btn.select')+'机种'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sql_ec_model " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="esItem">
              <el-select v-model="form.esItem" filterable clearable :placeholder="$t('btn.select')+'物料'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sql_ec_item " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生技担当" prop="esPeaAssigned">
              <el-input clearable v-model="form.esPeaAssigned" :placeholder="$t('btn.enter')+'生技担当'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组立变更否" prop="isPeaModifysop">
              <el-radio-group v-model="form.isPeaModifysop">
                <el-radio v-for="item in  options.sys_sop_yn " :key="item.dictValue"
                  :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="esPeaDate">
              <el-input clearable v-model="form.esPeaDate" :placeholder="$t('btn.enter')+'日期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPeaNote">
              <el-input clearable v-model="form.esPeaNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="版本" prop="emPeaDocNo">
              <el-input clearable v-model="form.emPeaDocNo" :placeholder="$t('btn.enter')+'版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组立文件" prop="emPeaDoc">
              <el-input clearable v-model="form.emPeaDoc" :placeholder="$t('btn.enter')+'组立文件'" />
            </el-form-item>
          </el-col>

          <!-- <el-col :lg="12">
            <el-form-item label="组立确认" prop="esPeaModifier">
              <el-input clearable v-model="form.esPeaModifier" :placeholder="$t('btn.enter')+'组立确认'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组立确认日期" prop="esPeaModifyTime">
              <el-date-picker clearable v-model="form.esPeaModifyTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col> -->

          <el-col :lg="12">
            <el-form-item label="生技担当" prop="esPepAssigned">
              <el-input clearable v-model="form.esPepAssigned" :placeholder="$t('btn.enter')+'生技担当'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PCBA变更否" prop="isPepModifysop">
              <el-radio-group v-model="form.isPepModifysop">
                <el-radio v-for="item in  options.sys_sop_yn " :key="item.dictValue"
                  :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="esPepDate">
              <el-input clearable v-model="form.esPepDate" :placeholder="$t('btn.enter')+'日期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPepNote">
              <el-input clearable v-model="form.esPepNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="版本" prop="emPepDocNo">
              <el-input clearable v-model="form.emPepDocNo" :placeholder="$t('btn.enter')+'版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PCBA文件" prop="emPepDoc">
              <el-input clearable v-model="form.emPepDoc" :placeholder="$t('btn.enter')+'PCBA文件'" />
            </el-form-item>
          </el-col>

          <!-- <el-col :lg="12">
            <el-form-item label="PCBA确认" prop="esPepModifier">
              <el-input clearable v-model="form.esPepModifier" :placeholder="$t('btn.enter')+'PCBA确认'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PCBA确认日期" prop="esPepModifyTime">
              <el-date-picker clearable v-model="form.esPepModifyTime" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'UDF01'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'UDF02'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'UDF03'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'UDF04'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'UDF05'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'UDF06'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'UDF51'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'UDF52'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'UDF53'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'UDF54'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'UDF55'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'UDF56'" :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IsDeleted" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted" :disabled="true">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue"
                  :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="ReMark" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'ReMark'"
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

<script setup name="ppecsop">
  // 引入 ppecsop操作方法
  import {
    listPpEcSop, addPpEcSop, delPpEcSop, updatePpEcSop, getPpEcSop,
    clearPpEcSop,
  }
    from '@/api/production/ppecsop.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中esId数组数组
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
    esIssueDate: undefined,
    esEcNo: undefined,
    esModel: undefined,
    esItem: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'esId', label: 'ID' },
    { visible: true, prop: 'esIssueDate', label: '发行日期' },
    { visible: true, prop: 'esEcNo', label: '设变No.' },
    { visible: true, prop: 'esEntryDate', label: '输入日期' },
    { visible: true, prop: 'esAssigned', label: '担当者' },
    { visible: true, prop: 'esModel', label: '机种' },
    { visible: true, prop: 'esItem', label: '物料' },
    { visible: true, prop: 'esPeaAssigned', label: '生技担当' },
    { visible: false, prop: 'isPeaModifysop', label: '组立变更否' },
    { visible: false, prop: 'esPeaDate', label: '日期' },
    { visible: false, prop: 'esPeaNote', label: '说明' },
    { visible: false, prop: 'emPeaDocNo', label: '版本' },
    { visible: false, prop: 'emPeaDoc', label: '组立文件' },
    { visible: false, prop: 'esPeaModifier', label: '组立确认' },
    { visible: false, prop: 'esPeaModifyTime', label: '组立确认日期' },
    { visible: false, prop: 'esPepAssigned', label: '生技担当' },
    { visible: false, prop: 'isPepModifysop', label: 'PCBA变更否' },
    { visible: false, prop: 'esPepDate', label: '日期' },
    { visible: false, prop: 'esPepNote', label: '说明' },
    { visible: false, prop: 'emPepDocNo', label: '版本' },
    { visible: false, prop: 'emPepDoc', label: 'PCBA文件' },
    { visible: false, prop: 'esPepModifier', label: 'PCBA确认' },
    { visible: false, prop: 'esPepModifyTime', label: 'PCBA确认日期' },
  ])
  // 总条数
  const total = ref(0)
  // SOP表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 发行日期时间范围
  const dateRangeEsIssueDate = ref([])


  var dictParams = [
    { dictType: "sql_ec_no" },
    { dictType: "sql_ec_model" },
    { dictType: "sql_ec_item" },
    { dictType: "sys_sop_yn" },
    { dictType: "sys_sop_yn" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取SOP表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeEsIssueDate.value, 'EsIssueDate');
    loading.value = true
    listPpEcSop(queryParams).then(res => {
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
    // 发行日期时间范围
    dateRangeEsIssueDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.esId);
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
      esEntryDate: [{ required: true, message: "输入日期" + proxy.$t('btn.empty'), trigger: "blur" }],
      isPeaModifysop: [{ required: true, message: "组立变更否" + proxy.$t('btn.empty'), trigger: "blur" }],
      isPepModifysop: [{ required: true, message: "PCBA变更否" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 设变No. 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_no: [],
      // 机种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_model: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_item: [],
      // 组立变更否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sop_yn: [],
      // PCBA变更否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sop_yn: [],
      // IsDeleted 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      isDeletedOptions: [],
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
      esIssueDate: undefined,
      esEcNo: undefined,
      esEntryDate: undefined,
      esAssigned: undefined,
      esModel: undefined,
      esItem: undefined,
      esPeaAssigned: undefined,
      isPeaModifysop: undefined,
      esPeaDate: undefined,
      esPeaNote: undefined,
      emPeaDocNo: undefined,
      emPeaDoc: undefined,
      esPeaModifier: undefined,
      esPeaModifyTime: undefined,
      esPepAssigned: undefined,
      isPepModifysop: undefined,
      esPepDate: undefined,
      esPepNote: undefined,
      emPepDocNo: undefined,
      emPepDoc: undefined,
      esPepModifier: undefined,
      esPepModifyTime: undefined,
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
    const id = row.esId || ids.value
    getPpEcSop(id).then((res) => {
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
        if (form.value.esId != undefined && opertype.value === 2) {
          updatePpEcSop(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpEcSop(form.value).then((res) => {
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
    const Ids = row.esId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPpEcSop(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }

  // 清空
  function handleClear() {
    proxy
      .$confirm(proxy.$t('common.confirmClean'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return clearPpEcSop()
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess(proxy.$t('common.Cleancompleted'))
      })
  }

  /**
   * 查看
   * @param {*} row
   */
  function handlePreview(row) {
    reset()
    open.value = true
    title.value = proxy.$t('btn.preview')
    opertype.value = 3
    form.value = row
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + "SOP", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Production/PpEcSop/export', { ...queryParams })
      })
  }

  handleQuery()
</script>