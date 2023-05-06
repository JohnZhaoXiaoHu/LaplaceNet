<!--
 * @Descripttion: (从设变/pp_ec_slave)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-05-02)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-05-02)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="设变No." prop="esEcNo">
        <el-input clearable v-model="queryParams.esEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
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
      <el-form-item label="子物料" prop="esSubItem">
        <el-input clearable v-model="queryParams.esSubItem" :placeholder="$t('btn.enter')+'子物料'" />
      </el-form-item>
      <el-form-item label="旧物料" prop="esOldItem">
        <el-input clearable v-model="queryParams.esOldItem" :placeholder="$t('btn.enter')+'旧物料'" />
      </el-form-item>
      <el-form-item label="新物料" prop="esNewItem">
        <el-input clearable v-model="queryParams.esNewItem" :placeholder="$t('btn.enter')+'新物料'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:ecslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecslave:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecslave:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['pp:ecslave:delete']" plain icon="delete" @click="handleClear">
          {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:ecslave:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslave:export']">
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
      <el-table-column prop="esEntryDate" label="输入日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esEntryDate')" />
      <el-table-column prop="esEcNo" label="设变No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esEcNo')" />
      <el-table-column prop="esModel" label="机种" align="center" v-if="columns.showColumn('esModel')">

      </el-table-column>
      <el-table-column prop="esItem" label="物料" align="center" v-if="columns.showColumn('esItem')">

      </el-table-column>
      <el-table-column prop="esSubItem" label="子物料" align="center" v-if="columns.showColumn('esSubItem')">

      </el-table-column>
      <el-table-column prop="esOldItem" label="旧物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esOldItem')" />
      <el-table-column prop="esOldItemText" label="旧文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esOldItemText')" />
      <el-table-column prop="esOldUsageQty" label="用量" align="center" v-if="columns.showColumn('esOldUsageQty')" />
      <el-table-column prop="esOldSetLoc" label="位置" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esOldSetLoc')" />
      <el-table-column prop="esNewItem" label="新物料" align="center" v-if="columns.showColumn('esNewItem')">

      </el-table-column>
      <el-table-column prop="esNewItemText" label="新文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esNewItemText')" />
      <el-table-column prop="esNewUsageQty" label="用量" align="center" v-if="columns.showColumn('esNewUsageQty')" />
      <el-table-column prop="esNewSetLoc" label="位置" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esNewSetLoc')" />
      <el-table-column prop="esBomNo" label="bom番号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esBomNo')" />
      <el-table-column prop="esChange" label="互换" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esChange')" />
      <el-table-column prop="eslocal" label="区分" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('eslocal')" />
      <el-table-column prop="esnote" label="指示" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esnote')" />
      <el-table-column prop="esOldProcess" label="旧品处理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esOldProcess')" />
      <el-table-column prop="esBomDate" label="bom日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esBomDate')" />
      <el-table-column prop="emEcImpDept" label="实施部门" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcImpDept')" />
      <el-table-column prop="esPurType" label="采购类型" align="center" v-if="columns.showColumn('esPurType')">

      </el-table-column>
      <el-table-column prop="esSloc" label="仓库" align="center" v-if="columns.showColumn('esSloc')">

      </el-table-column>
      <el-table-column prop="esInsmk" label="检验否" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esInsmk')" />
      <el-table-column prop="esMstae" label="工厂状态" align="center" v-if="columns.showColumn('esMstae')">

      </el-table-column>
      <el-table-column prop="esSopStae" label="SOP" align="center" v-if="columns.showColumn('esSopStae')">

      </el-table-column>
      <el-table-column prop="esOldCurrStock" label="旧品库存" align="center" v-if="columns.showColumn('esOldCurrStock')" />
      <el-table-column prop="esNewCurrStock" label="新品库存" align="center" v-if="columns.showColumn('esNewCurrStock')" />
      <el-table-column prop="esPurEntryDate" label="采购登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurEntryDate')" />
      <el-table-column prop="esSupplier" label="供应商" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esSupplier')" />
      <el-table-column prop="esPurOrder" label="采购PO" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurOrder')" />
      <el-table-column prop="esPurNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurNote')" />
      <el-table-column prop="esPurCreator" label="EsPurCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurCreator')" />
      <el-table-column prop="esPurCreateTime" label="EsPurCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurCreateTime')" />
      <el-table-column prop="esPurModifier" label="EsPurModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurModifier')" />
      <el-table-column prop="esPurModifyTime" label="EsPurModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPurModifyTime')" />
      <el-table-column prop="esPmcEntryDate" label="生管登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcEntryDate')" />
      <el-table-column prop="esPmcLot" label="预投入批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcLot')" />
      <el-table-column prop="esPmcMemo" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcMemo')" />
      <el-table-column prop="esPmcNote" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcNote')" />
      <el-table-column prop="esPmcCreator" label="EsPmcCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcCreator')" />
      <el-table-column prop="esPmcCreateTime" label="EsPmcCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcCreateTime')" />
      <el-table-column prop="esPmcModifier" label="EsPmcModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcModifier')" />
      <el-table-column prop="esPmcModifyTime" label="EsPmcModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPmcModifyTime')" />
      <el-table-column prop="esIqcEntryDate" label="IQC登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcEntryDate')" />
      <el-table-column prop="esIqcOrder" label="检验订单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcOrder')" />
      <el-table-column prop="esIqcNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcNote')" />
      <el-table-column prop="esIqcCreator" label="EsIqcCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcCreator')" />
      <el-table-column prop="esIqcCreateTime" label="EsIqcCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcCreateTime')" />
      <el-table-column prop="esIqcModifier" label="EsIqcModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcModifier')" />
      <el-table-column prop="esIqcModifyTime" label="EsIqcModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esIqcModifyTime')" />
      <el-table-column prop="esMmEntryDate" label="部管登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmEntryDate')" />
      <el-table-column prop="esMmLot" label="领用批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmLot')" />
      <el-table-column prop="esMmMocNo" label="工单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmMocNo')" />
      <el-table-column prop="esMmNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmNote')" />
      <el-table-column prop="esMmCreator" label="EsMmCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmCreator')" />
      <el-table-column prop="esMmCreateTime" label="EsMmCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmCreateTime')" />
      <el-table-column prop="esMmModifier" label="EsMmModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmModifier')" />
      <el-table-column prop="esMmModifyTime" label="EsMmModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esMmModifyTime')" />
      <el-table-column prop="esPpEntryDate" label="制一登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpEntryDate')" />
      <el-table-column prop="esPpLine" label="班组" align="center" v-if="columns.showColumn('esPpLine')">
      </el-table-column>
      <el-table-column prop="esPpLot" label="生产批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpLot')" />
      <el-table-column prop="esPpNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpNote')" />
      <el-table-column prop="esPpCreator" label="EsPpCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpCreator')" />
      <el-table-column prop="esPpCreateTime" label="EsPpCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpCreateTime')" />
      <el-table-column prop="esPpModifier" label="EsPpModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpModifier')" />
      <el-table-column prop="esPpModifyTime" label="EsPpModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPpModifyTime')" />
      <el-table-column prop="esPcbaEntryDate" label="制二登入日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaEntryDate')" />
      <el-table-column prop="esPcbaLine" label="Pcba班组" align="center" v-if="columns.showColumn('esPcbaLine')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.esPcbaLine" />
        </template>
      </el-table-column>
      <el-table-column prop="esPcbaLot" label="Pcba批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaLot')" />
      <el-table-column prop="esPcbaNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaNote')" />
      <el-table-column prop="esPcbaCreator" label="EsPcbaCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaCreator')" />
      <el-table-column prop="esPcbaCreateTime" label="EsPcbaCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaCreateTime')" />
      <el-table-column prop="esPcbaModifier" label="EsPcbaModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaModifier')" />
      <el-table-column prop="esPcbaModifyTime" label="EsPcbaModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esPcbaModifyTime')" />
      <el-table-column prop="esQaEntryDate" label="QA确认日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaEntryDate')" />
      <el-table-column prop="esQaLot" label="检验批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaLot')" />
      <el-table-column prop="esQaNote" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaNote')" />
      <el-table-column prop="esQaCreator" label="EsQaCreator" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaCreator')" />
      <el-table-column prop="esQaCreateTime" label="EsQaCreateTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaCreateTime')" />
      <el-table-column prop="esQaModifier" label="EsQaModifier" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaModifier')" />
      <el-table-column prop="esQaModifyTime" label="EsQaModifyTime" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('esQaModifyTime')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecslave:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecslave:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改从设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="信息" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="ID" prop="esId">
                  <el-input-number clearable v-model.number="form.esId" controls-position="right"
                    :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')||$t('btn.view')" />
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="输入日" prop="esEntryDate">
                  <el-date-picker clearable v-model="form.esEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"
                    :disabled="title==$t('btn.edit')||$t('btn.view')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="设变No." prop="esEcNo">
                  <el-input clearable v-model="form.esEcNo" :placeholder="$t('btn.enter')+'设变No.'"
                    :disabled="title==$t('btn.edit')||$t('btn.view')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种" prop="esModel">
                  <el-select v-model="form.esModel" filterable clearable :placeholder="$t('btn.select')+'机种'"
                    :disabled="title==$t('btn.edit')||$t('btn.view')">
                    <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="esItem">
                  <el-select v-model="form.esItem" filterable clearable :placeholder="$t('btn.select')+'物料'">
                    <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="子物料" prop="esSubItem">
                  <el-select v-model="form.esSubItem" filterable clearable :placeholder="$t('btn.select')+'子物料'">
                    <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="旧物料" prop="esOldItem">
                  <el-input clearable v-model="form.esOldItem" :placeholder="$t('btn.enter')+'旧物料'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="旧文本" prop="esOldItemText">
                  <el-input clearable v-model="form.esOldItemText" :placeholder="$t('btn.enter')+'旧文本'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用量" prop="esOldUsageQty">
                  <el-input-number clearable v-model.number="form.esOldUsageQty" :controls="true"
                    controls-position="right" :placeholder="$t('btn.enter')+'用量'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="位置" prop="esOldSetLoc">
                  <el-input clearable v-model="form.esOldSetLoc" :placeholder="$t('btn.enter')+'位置'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="新物料" prop="esNewItem">
                  <el-select v-model="form.esNewItem" filterable clearable :placeholder="$t('btn.select')+'新物料'">
                    <el-option v-for="item in  options.sql_moc_item " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="新文本" prop="esNewItemText">
                  <el-input clearable v-model="form.esNewItemText" :placeholder="$t('btn.enter')+'新文本'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用量" prop="esNewUsageQty">
                  <el-input-number clearable v-model.number="form.esNewUsageQty" :controls="true"
                    controls-position="right" :placeholder="$t('btn.enter')+'用量'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="位置" prop="esNewSetLoc">
                  <el-input clearable v-model="form.esNewSetLoc" :placeholder="$t('btn.enter')+'位置'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="bom番号" prop="esBomNo">
                  <el-input clearable v-model="form.esBomNo" :placeholder="$t('btn.enter')+'bom番号'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="互换" prop="esChange">
                  <el-input clearable v-model="form.esChange" :placeholder="$t('btn.enter')+'互换'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="区分" prop="eslocal">
                  <el-input clearable v-model="form.eslocal" :placeholder="$t('btn.enter')+'区分'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示" prop="esnote">
                  <el-input clearable v-model="form.esnote" :placeholder="$t('btn.enter')+'指示'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="旧品处理" prop="esOldProcess">
                  <el-input clearable v-model="form.esOldProcess" :placeholder="$t('btn.enter')+'旧品处理'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="bom日期" prop="esBomDate">
                  <el-date-picker clearable v-model="form.esBomDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实施部门" prop="emEcImpDept">
                  <el-input clearable v-model="form.emEcImpDept" :placeholder="$t('btn.enter')+'实施部门'" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="采购" name="second">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="采购类型" prop="esPurType">
                  <el-select v-model="form.esPurType" filterable clearable :placeholder="$t('btn.select')+'采购类型'">
                    <el-option v-for="item in  options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仓库" prop="esSloc">
                  <el-select v-model="form.esSloc" filterable clearable :placeholder="$t('btn.select')+'仓库'">
                    <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检验否" prop="esInsmk">
                  <el-input clearable v-model="form.esInsmk" :placeholder="$t('btn.enter')+'检验否'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂状态" prop="esMstae">
                  <el-select v-model="form.esMstae" filterable clearable :placeholder="$t('btn.select')+'工厂状态'">
                    <el-option v-for="item in  options.sys_eol_type " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>



              <el-col :lg="12">
                <el-form-item label="旧品库存" prop="esOldCurrStock">
                  <el-input-number clearable v-model.number="form.esOldCurrStock" :controls="true"
                    controls-position="right" :placeholder="$t('btn.enter')+'旧品库存'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="新品库存" prop="esNewCurrStock">
                  <el-input-number clearable v-model.number="form.esNewCurrStock" :controls="true"
                    controls-position="right" :placeholder="$t('btn.enter')+'新品库存'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购登入日期" prop="esPurEntryDate">
                  <el-date-picker clearable v-model="form.esPurEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商" prop="esSupplier">
                  <el-input clearable v-model="form.esSupplier" :placeholder="$t('btn.enter')+'供应商'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购PO" prop="esPurOrder">
                  <el-input clearable v-model="form.esPurOrder" :placeholder="$t('btn.enter')+'采购PO'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esPurNote">
                  <el-input clearable v-model="form.esPurNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPurCreator" prop="esPurCreator">
                  <el-input clearable v-model="form.esPurCreator" :placeholder="$t('btn.enter')+'EsPurCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPurCreateTime" prop="esPurCreateTime">
                  <el-date-picker clearable v-model="form.esPurCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPurModifier" prop="esPurModifier">
                  <el-input clearable v-model="form.esPurModifier" :placeholder="$t('btn.enter')+'EsPurModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPurModifyTime" prop="esPurModifyTime">
                  <el-date-picker clearable v-model="form.esPurModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="生管" name="third">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="生管登入日期" prop="esPmcEntryDate">
                  <el-date-picker clearable v-model="form.esPmcEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预投入批次" prop="esPmcLot">
                  <el-input clearable v-model="form.esPmcLot" :placeholder="$t('btn.enter')+'预投入批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esPmcMemo">
                  <el-input clearable v-model="form.esPmcMemo" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="备注" prop="esPmcNote">
                  <el-input clearable v-model="form.esPmcNote" :placeholder="$t('btn.enter')+'备注'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPmcCreator" prop="esPmcCreator">
                  <el-input clearable v-model="form.esPmcCreator" :placeholder="$t('btn.enter')+'EsPmcCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPmcCreateTime" prop="esPmcCreateTime">
                  <el-date-picker clearable v-model="form.esPmcCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPmcModifier" prop="esPmcModifier">
                  <el-input clearable v-model="form.esPmcModifier" :placeholder="$t('btn.enter')+'EsPmcModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPmcModifyTime" prop="esPmcModifyTime">
                  <el-date-picker clearable v-model="form.esPmcModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="受检" name="fourth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="IQC登入日期" prop="esIqcEntryDate">
                  <el-date-picker clearable v-model="form.esIqcEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检验订单" prop="esIqcOrder">
                  <el-input clearable v-model="form.esIqcOrder" :placeholder="$t('btn.enter')+'检验订单'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esIqcNote">
                  <el-input clearable v-model="form.esIqcNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsIqcCreator" prop="esIqcCreator">
                  <el-input clearable v-model="form.esIqcCreator" :placeholder="$t('btn.enter')+'EsIqcCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsIqcCreateTime" prop="esIqcCreateTime">
                  <el-date-picker clearable v-model="form.esIqcCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsIqcModifier" prop="esIqcModifier">
                  <el-input clearable v-model="form.esIqcModifier" :placeholder="$t('btn.enter')+'EsIqcModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsIqcModifyTime" prop="esIqcModifyTime">
                  <el-date-picker clearable v-model="form.esIqcModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="部管" name="fifth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="部管登入日期" prop="esMmEntryDate">
                  <el-date-picker clearable v-model="form.esMmEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="领用批次" prop="esMmLot">
                  <el-input clearable v-model="form.esMmLot" :placeholder="$t('btn.enter')+'领用批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工单" prop="esMmMocNo">
                  <el-input clearable v-model="form.esMmMocNo" :placeholder="$t('btn.enter')+'工单'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esMmNote">
                  <el-input clearable v-model="form.esMmNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsMmCreator" prop="esMmCreator">
                  <el-input clearable v-model="form.esMmCreator" :placeholder="$t('btn.enter')+'EsMmCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsMmCreateTime" prop="esMmCreateTime">
                  <el-date-picker clearable v-model="form.esMmCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsMmModifier" prop="esMmModifier">
                  <el-input clearable v-model="form.esMmModifier" :placeholder="$t('btn.enter')+'EsMmModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsMmModifyTime" prop="esMmModifyTime">
                  <el-date-picker clearable v-model="form.esMmModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="制一" name="sixth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="制一登入日期" prop="esPpEntryDate">
                  <el-date-picker clearable v-model="form.esPpEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="班组" prop="esPpLine">
                  <el-select v-model="form.esPpLine" filterable clearable :placeholder="$t('btn.select')+'班组'">
                    <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产批次" prop="esPpLot">
                  <el-input clearable v-model="form.esPpLot" :placeholder="$t('btn.enter')+'生产批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esPpNote">
                  <el-input clearable v-model="form.esPpNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPpCreator" prop="esPpCreator">
                  <el-input clearable v-model="form.esPpCreator" :placeholder="$t('btn.enter')+'EsPpCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPpCreateTime" prop="esPpCreateTime">
                  <el-date-picker clearable v-model="form.esPpCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPpModifier" prop="esPpModifier">
                  <el-input clearable v-model="form.esPpModifier" :placeholder="$t('btn.enter')+'EsPpModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPpModifyTime" prop="esPpModifyTime">
                  <el-date-picker clearable v-model="form.esPpModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="制二" name="seventh">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="制二登入日期" prop="esPcbaEntryDate">
                  <el-date-picker clearable v-model="form.esPcbaEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Pcba班组" prop="esPcbaLine">
                  <el-select v-model="form.esPcbaLine" filterable clearable :placeholder="$t('btn.select')+'Pcba班组'">
                    <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Pcba批次" prop="esPcbaLot">
                  <el-input clearable v-model="form.esPcbaLot" :placeholder="$t('btn.enter')+'Pcba批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esPcbaNote">
                  <el-input clearable v-model="form.esPcbaNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPcbaCreator" prop="esPcbaCreator">
                  <el-input clearable v-model="form.esPcbaCreator" :placeholder="$t('btn.enter')+'EsPcbaCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPcbaCreateTime" prop="esPcbaCreateTime">
                  <el-date-picker clearable v-model="form.esPcbaCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPcbaModifier" prop="esPcbaModifier">
                  <el-input clearable v-model="form.esPcbaModifier" :placeholder="$t('btn.enter')+'EsPcbaModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsPcbaModifyTime" prop="esPcbaModifyTime">
                  <el-date-picker clearable v-model="form.esPcbaModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>

          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="品管" name="eighth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="QA确认日期" prop="esQaEntryDate">
                  <el-date-picker clearable v-model="form.esQaEntryDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检验批次" prop="esQaLot">
                  <el-input clearable v-model="form.esQaLot" :placeholder="$t('btn.enter')+'检验批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="esQaNote">
                  <el-input clearable v-model="form.esQaNote" :placeholder="$t('btn.enter')+'说明'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsQaCreator" prop="esQaCreator">
                  <el-input clearable v-model="form.esQaCreator" :placeholder="$t('btn.enter')+'EsQaCreator'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsQaCreateTime" prop="esQaCreateTime">
                  <el-date-picker clearable v-model="form.esQaCreateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsQaModifier" prop="esQaModifier">
                  <el-input clearable v-model="form.esQaModifier" :placeholder="$t('btn.enter')+'EsQaModifier'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EsQaModifyTime" prop="esQaModifyTime">
                  <el-date-picker clearable v-model="form.esQaModifyTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane v-if="checkPermi(['pp:ecslave:edit'])" label="制技" name="ninth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="SOP" prop="esSopStae">
                  <el-radio-group v-model="form.esSopStae">
                    <el-radio v-for="item in  options.sys_sop_yn " :key="item.dictValue"
                      :label="item.dictValue">{{item.dictLabel}}</el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>

        </el-tabs>







        <!-- <el-row :gutter="20">
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
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted" :disabled="true">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue"
                  :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'"
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
        </el-row> -->
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ppecslave">
  // 引入 ppecslave操作方法
  import {
    listPpEcSlave, addPpEcSlave, delPpEcSlave, updatePpEcSlave, getPpEcSlave,
    clearPpEcSlave,
  }
    from '@/api/production/ppecslave.js'

  const activeName = ref('first')
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
    esEcNo: undefined,
    esModel: undefined,
    esItem: undefined,
    esSubItem: undefined,
    esOldItem: undefined,
    esNewItem: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'esId', label: 'ID' },
    { visible: true, prop: 'esEntryDate', label: '输入日' },
    { visible: true, prop: 'esEcNo', label: '设变No.' },
    { visible: true, prop: 'esModel', label: '机种' },
    { visible: true, prop: 'esItem', label: '物料' },
    { visible: true, prop: 'esSubItem', label: '子物料' },
    { visible: true, prop: 'esOldItem', label: '旧物料' },
    { visible: true, prop: 'esOldItemText', label: '旧文本' },
    { visible: false, prop: 'esOldUsageQty', label: '用量' },
    { visible: false, prop: 'esOldSetLoc', label: '位置' },
    { visible: false, prop: 'esNewItem', label: '新物料' },
    { visible: false, prop: 'esNewItemText', label: '新文本' },
    { visible: false, prop: 'esNewUsageQty', label: '用量' },
    { visible: false, prop: 'esNewSetLoc', label: '位置' },
    { visible: false, prop: 'esBomNo', label: 'bom番号' },
    { visible: false, prop: 'esChange', label: '互换' },
    { visible: false, prop: 'eslocal', label: '区分' },
    { visible: false, prop: 'esnote', label: '指示' },
    { visible: false, prop: 'esOldProcess', label: '旧品处理' },
    { visible: false, prop: 'esBomDate', label: 'bom日期' },
    { visible: false, prop: 'emEcImpDept', label: '实施部门' },
    { visible: false, prop: 'esPurType', label: '采购类型' },
    { visible: false, prop: 'esSloc', label: '仓库' },
    { visible: false, prop: 'esInsmk', label: '检验否' },
    { visible: false, prop: 'esMstae', label: '工厂状态' },
    { visible: false, prop: 'esSopStae', label: 'SOP' },
    { visible: false, prop: 'esOldCurrStock', label: '旧品库存' },
    { visible: false, prop: 'esNewCurrStock', label: '新品库存' },
    { visible: false, prop: 'esPurEntryDate', label: '采购登入日期' },
    { visible: false, prop: 'esSupplier', label: '供应商' },
    { visible: false, prop: 'esPurOrder', label: '采购PO' },
    { visible: false, prop: 'esPurNote', label: '说明' },
    { visible: false, prop: 'esPurCreator', label: 'EsPurCreator' },
    { visible: false, prop: 'esPurCreateTime', label: 'EsPurCreateTime' },
    { visible: false, prop: 'esPurModifier', label: 'EsPurModifier' },
    { visible: false, prop: 'esPurModifyTime', label: 'EsPurModifyTime' },
    { visible: false, prop: 'esPmcEntryDate', label: '生管登入日期' },
    { visible: false, prop: 'esPmcLot', label: '预投入批次' },
    { visible: false, prop: 'esPmcMemo', label: '说明' },
    { visible: false, prop: 'esPmcNote', label: '备注' },
    { visible: false, prop: 'esPmcCreator', label: 'EsPmcCreator' },
    { visible: false, prop: 'esPmcCreateTime', label: 'EsPmcCreateTime' },
    { visible: false, prop: 'esPmcModifier', label: 'EsPmcModifier' },
    { visible: false, prop: 'esPmcModifyTime', label: 'EsPmcModifyTime' },
    { visible: false, prop: 'esIqcEntryDate', label: 'IQC登入日期' },
    { visible: false, prop: 'esIqcOrder', label: '检验订单' },
    { visible: false, prop: 'esIqcNote', label: '说明' },
    { visible: false, prop: 'esIqcCreator', label: 'EsIqcCreator' },
    { visible: false, prop: 'esIqcCreateTime', label: 'EsIqcCreateTime' },
    { visible: false, prop: 'esIqcModifier', label: 'EsIqcModifier' },
    { visible: false, prop: 'esIqcModifyTime', label: 'EsIqcModifyTime' },
    { visible: false, prop: 'esMmEntryDate', label: '部管登入日期' },
    { visible: false, prop: 'esMmLot', label: '领用批次' },
    { visible: false, prop: 'esMmMocNo', label: '工单' },
    { visible: false, prop: 'esMmNote', label: '说明' },
    { visible: false, prop: 'esMmCreator', label: 'EsMmCreator' },
    { visible: false, prop: 'esMmCreateTime', label: 'EsMmCreateTime' },
    { visible: false, prop: 'esMmModifier', label: 'EsMmModifier' },
    { visible: false, prop: 'esMmModifyTime', label: 'EsMmModifyTime' },
    { visible: false, prop: 'esPpEntryDate', label: '制一登入日期' },
    { visible: false, prop: 'esPpLine', label: '班组' },
    { visible: false, prop: 'esPpLot', label: '生产批次' },
    { visible: false, prop: 'esPpNote', label: '说明' },
    { visible: false, prop: 'esPpCreator', label: 'EsPpCreator' },
    { visible: false, prop: 'esPpCreateTime', label: 'EsPpCreateTime' },
    { visible: false, prop: 'esPpModifier', label: 'EsPpModifier' },
    { visible: false, prop: 'esPpModifyTime', label: 'EsPpModifyTime' },
    { visible: false, prop: 'esPcbaEntryDate', label: '制二登入日期' },
    { visible: false, prop: 'esPcbaLine', label: 'Pcba班组' },
    { visible: false, prop: 'esPcbaLot', label: 'Pcba批次' },
    { visible: false, prop: 'esPcbaNote', label: '说明' },
    { visible: false, prop: 'esPcbaCreator', label: 'EsPcbaCreator' },
    { visible: false, prop: 'esPcbaCreateTime', label: 'EsPcbaCreateTime' },
    { visible: false, prop: 'esPcbaModifier', label: 'EsPcbaModifier' },
    { visible: false, prop: 'esPcbaModifyTime', label: 'EsPcbaModifyTime' },
    { visible: false, prop: 'esQaEntryDate', label: 'QA确认日期' },
    { visible: false, prop: 'esQaLot', label: '检验批次' },
    { visible: false, prop: 'esQaNote', label: '说明' },
    { visible: false, prop: 'esQaCreator', label: 'EsQaCreator' },
    { visible: false, prop: 'esQaCreateTime', label: 'EsQaCreateTime' },
    { visible: false, prop: 'esQaModifier', label: 'EsQaModifier' },
    { visible: false, prop: 'esQaModifyTime', label: 'EsQaModifyTime' },
  ])
  // 总条数
  const total = ref(0)
  // 从设变表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


  var dictParams = [
    { dictType: "sql_moc_item" },
    { dictType: "sql_moc_model" },
    { dictType: "sql_moc_item" },
    { dictType: "sql_moc_item" },
    { dictType: "sys_pur_type" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_eol_type" },
    { dictType: "sys_sop_yn" },
    { dictType: "sql_line_list" },

    { dictType: "sql_ec_item" },
    { dictType: "sql_ec_model" },

  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取从设变表记录数据
  function getList() {
    loading.value = true
    listPpEcSlave(queryParams).then(res => {
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
      esEntryDate: [{ required: true, message: "输入日" + proxy.$t('btn.empty'), trigger: "blur" }],
      esEcNo: [{ required: true, message: "设变No." + proxy.$t('btn.empty'), trigger: "blur" }],
      esModel: [{ required: true, message: "机种" + proxy.$t('btn.empty'), trigger: "change" }],
      esItem: [{ required: true, message: "物料" + proxy.$t('btn.empty'), trigger: "change" }],
      esOldUsageQty: [{ required: true, message: "用量" + proxy.$t('btn.empty'), trigger: "blur" }],
      esNewUsageQty: [{ required: true, message: "用量" + proxy.$t('btn.empty'), trigger: "blur" }],
      esBomDate: [{ required: true, message: "bom日期" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcImpDept: [{ required: true, message: "实施部门" + proxy.$t('btn.empty'), trigger: "blur" }],
      esPurType: [{ required: true, message: "采购类型" + proxy.$t('btn.empty'), trigger: "change" }],
      esSloc: [{ required: true, message: "仓库" + proxy.$t('btn.empty'), trigger: "change" }],
      esSopStae: [{ required: true, message: "SOP" + proxy.$t('btn.empty'), trigger: "blur" }],
      esOldCurrStock: [{ required: true, message: "旧品库存" + proxy.$t('btn.empty'), trigger: "blur" }],
      esNewCurrStock: [{ required: true, message: "新品库存" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 机种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_model: [],
      // 子物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
      // 新物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_item: [],
      // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_type: [],
      // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 工厂状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_eol_type: [],
      // SOP 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sop_yn: [],
      // 班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_list: [],
      // Pcba班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_list: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      esEntryDate: undefined,
      esEcNo: undefined,
      esModel: undefined,
      esItem: undefined,
      esSubItem: undefined,
      esOldItem: undefined,
      esOldItemText: undefined,
      esOldUsageQty: undefined,
      esOldSetLoc: undefined,
      esNewItem: undefined,
      esNewItemText: undefined,
      esNewUsageQty: undefined,
      esNewSetLoc: undefined,
      esBomNo: undefined,
      esChange: undefined,
      eslocal: undefined,
      esnote: undefined,
      esOldProcess: undefined,
      esBomDate: undefined,
      emEcImpDept: undefined,
      esPurType: undefined,
      esSloc: undefined,
      esInsmk: undefined,
      esMstae: undefined,
      esSopStae: undefined,
      esOldCurrStock: undefined,
      esNewCurrStock: undefined,
      esPurEntryDate: undefined,
      esSupplier: undefined,
      esPurOrder: undefined,
      esPurNote: undefined,
      esPurCreator: undefined,
      esPurCreateTime: undefined,
      esPurModifier: undefined,
      esPurModifyTime: undefined,
      esPmcEntryDate: undefined,
      esPmcLot: undefined,
      esPmcMemo: undefined,
      esPmcNote: undefined,
      esPmcCreator: undefined,
      esPmcCreateTime: undefined,
      esPmcModifier: undefined,
      esPmcModifyTime: undefined,
      esIqcEntryDate: undefined,
      esIqcOrder: undefined,
      esIqcNote: undefined,
      esIqcCreator: undefined,
      esIqcCreateTime: undefined,
      esIqcModifier: undefined,
      esIqcModifyTime: undefined,
      esMmEntryDate: undefined,
      esMmLot: undefined,
      esMmMocNo: undefined,
      esMmNote: undefined,
      esMmCreator: undefined,
      esMmCreateTime: undefined,
      esMmModifier: undefined,
      esMmModifyTime: undefined,
      esPpEntryDate: undefined,
      esPpLine: undefined,
      esPpLot: undefined,
      esPpNote: undefined,
      esPpCreator: undefined,
      esPpCreateTime: undefined,
      esPpModifier: undefined,
      esPpModifyTime: undefined,
      esPcbaEntryDate: undefined,
      esPcbaLine: undefined,
      esPcbaLot: undefined,
      esPcbaNote: undefined,
      esPcbaCreator: undefined,
      esPcbaCreateTime: undefined,
      esPcbaModifier: undefined,
      esPcbaModifyTime: undefined,
      esQaEntryDate: undefined,
      esQaLot: undefined,
      esQaNote: undefined,
      esQaCreator: undefined,
      esQaCreateTime: undefined,
      esQaModifier: undefined,
      esQaModifyTime: undefined,
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
    getPpEcSlave(id).then((res) => {
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
          updatePpEcSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpEcSlave(form.value).then((res) => {
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
        return delPpEcSlave(Ids)
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
        return clearPpEcSlave()
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
      .$confirm(proxy.$t('common.confirmExport') + "从设变", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Production/PpEcSlave/export', { ...queryParams })
      })
  }

  handleQuery()
</script>

<style>
  /*切换项下面的长条，控制其长度*/
  .el-tabs__active-bar.is-top {
    background: red linear-gradient(90deg, transparent 20px, blue 20px, blue calc(100% - 20px), transparent calc(100% - 20px));
  }
</style>