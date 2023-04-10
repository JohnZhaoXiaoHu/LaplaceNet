<!--
 * @Descripttion: (从设变信息表/pp_ec_slave)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-04-10)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-04-10)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
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
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="esId" label="ID" align="center" v-if="columns.showColumn('esId')"/>
      <el-table-column prop="esEntryDate" label="输入日" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esEntryDate')"/>
      <el-table-column prop="esEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esEcNo')"/>
      <el-table-column prop="esModel" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esModel')"/>
      <el-table-column prop="esItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esItem')"/>
      <el-table-column prop="esSubItem" label="子物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esSubItem')"/>
      <el-table-column prop="esOldItem" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldItem')"/>
      <el-table-column prop="esOldItemText" label="旧文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldItemText')"/>
      <el-table-column prop="esOldUsageQty" label="用量" align="center" v-if="columns.showColumn('esOldUsageQty')"/>
      <el-table-column prop="esOldSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldSetLoc')"/>
      <el-table-column prop="esNewItem" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewItem')"/>
      <el-table-column prop="esNewItemText" label="新文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewItemText')"/>
      <el-table-column prop="esNewUsageQty" label="用量" align="center" v-if="columns.showColumn('esNewUsageQty')"/>
      <el-table-column prop="esNewSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewSetLoc')"/>
      <el-table-column prop="esBomNo" label="bom番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esBomNo')"/>
      <el-table-column prop="esChange" label="互换" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esChange')"/>
      <el-table-column prop="eslocal" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eslocal')"/>
      <el-table-column prop="esnote" label="指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esnote')"/>
      <el-table-column prop="esOldProcess" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldProcess')"/>
      <el-table-column prop="esBomDate" label="bom日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esBomDate')"/>
      <el-table-column prop="esPurType" label="采购类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurType')"/>
      <el-table-column prop="emEcImpDept" label="实施部门" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcImpDept')"/>
      <el-table-column prop="esSloc" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esSloc')"/>
      <el-table-column prop="isCheck" label="检验否" align="center" v-if="columns.showColumn('isCheck')"/>
      <el-table-column prop="isEol" label="停产否" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('isEol')"/>
      <el-table-column prop="esOldCurrStock" label="旧品库存" align="center" v-if="columns.showColumn('esOldCurrStock')"/>
      <el-table-column prop="esNewCurrStock" label="新品库存" align="center" v-if="columns.showColumn('esNewCurrStock')"/>
      <el-table-column prop="esDeptEntryDate" label="部门录入日" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptEntryDate')"/>
      <el-table-column prop="esDeptName" label="部门名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptName')"/>
      <el-table-column prop="esSupplier" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esSupplier')"/>
      <el-table-column prop="esPurOrder" label="采购PO" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurOrder')"/>
      <el-table-column prop="esPurNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurNote')"/>
      <el-table-column prop="esPmcLot" label="预投入批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcLot')"/>
      <el-table-column prop="esPmcMemo" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcMemo')"/>
      <el-table-column prop="esPmcNote" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcNote')"/>
      <el-table-column prop="esIqcOrder" label="检验订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcOrder')"/>
      <el-table-column prop="esIqcNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcNote')"/>
      <el-table-column prop="esMmLot" label="领用批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmLot')"/>
      <el-table-column prop="esMmMocNo" label="工单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmMocNo')"/>
      <el-table-column prop="esMmNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmNote')"/>
      <el-table-column prop="esPpLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpLine')"/>
      <el-table-column prop="esPpLot" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpLot')"/>
      <el-table-column prop="esPpNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpNote')"/>
      <el-table-column prop="esPcbaLine" label="Pcba班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaLine')"/>
      <el-table-column prop="esPcbaLot" label="Pcba批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaLot')"/>
      <el-table-column prop="esPcbaNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaNote')"/>
      <el-table-column prop="esQaLot" label="检验批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaLot')"/>
      <el-table-column prop="esQaNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaNote')"/>
      <el-table-column prop="esDeptCreator" label="EsDeptCreator" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptCreator')"/>
      <el-table-column prop="esDeptCreateTime" label="EsDeptCreateTime" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptCreateTime')"/>
      <el-table-column prop="esDeptModifier" label="EsDeptModifier" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptModifier')"/>
      <el-table-column prop="esDeptModifyTime" label="EsDeptModifyTime" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esDeptModifyTime')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:ecslave:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecslave:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改从设变信息表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="esId">
              <el-input-number clearable v-model.number="form.esId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="输入日" prop="esEntryDate">
              <el-date-picker clearable v-model="form.esEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="esEcNo">
              <el-input clearable v-model="form.esEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="esModel">
              <el-input clearable v-model="form.esModel" :placeholder="$t('btn.enter')+'机种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="esItem">
              <el-input clearable v-model="form.esItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料" prop="esSubItem">
              <el-input clearable v-model="form.esSubItem" :placeholder="$t('btn.enter')+'子物料'" />
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
              <el-input clearable v-model="form.esOldUsageQty" :placeholder="$t('btn.enter')+'用量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="esOldSetLoc">
              <el-input clearable v-model="form.esOldSetLoc" :placeholder="$t('btn.enter')+'位置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="esNewItem">
              <el-input clearable v-model="form.esNewItem" :placeholder="$t('btn.enter')+'新物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新文本" prop="esNewItemText">
              <el-input clearable v-model="form.esNewItemText" :placeholder="$t('btn.enter')+'新文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="esNewUsageQty">
              <el-input clearable v-model="form.esNewUsageQty" :placeholder="$t('btn.enter')+'用量'" />
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
              <el-input clearable v-model="form.esBomDate" :placeholder="$t('btn.enter')+'bom日期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购类型" prop="esPurType">
              <el-input clearable v-model="form.esPurType" :placeholder="$t('btn.enter')+'采购类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实施部门" prop="emEcImpDept">
              <el-input clearable v-model="form.emEcImpDept" :placeholder="$t('btn.enter')+'实施部门'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="esSloc">
              <el-input clearable v-model="form.esSloc" :placeholder="$t('btn.enter')+'仓库'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验否" prop="isCheck">
              <el-input clearable v-model="form.isCheck" :placeholder="$t('btn.enter')+'检验否'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停产否" prop="isEol">
              <el-input clearable v-model="form.isEol" :placeholder="$t('btn.enter')+'停产否'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品库存" prop="esOldCurrStock">
              <el-input clearable v-model="form.esOldCurrStock" :placeholder="$t('btn.enter')+'旧品库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新品库存" prop="esNewCurrStock">
              <el-input clearable v-model="form.esNewCurrStock" :placeholder="$t('btn.enter')+'新品库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部门录入日" prop="esDeptEntryDate">
              <el-date-picker clearable v-model="form.esDeptEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部门名称" prop="esDeptName">
              <el-input clearable v-model="form.esDeptName" :placeholder="$t('btn.enter')+'部门名称'" />
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
            <el-form-item label="班组" prop="esPpLine">
              <el-input clearable v-model="form.esPpLine" :placeholder="$t('btn.enter')+'班组'" />
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
            <el-form-item label="Pcba班组" prop="esPcbaLine">
              <el-input clearable v-model="form.esPcbaLine" :placeholder="$t('btn.enter')+'Pcba班组'" />
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
            <el-form-item label="EsDeptCreator" prop="esDeptCreator">
              <el-input clearable v-model="form.esDeptCreator" :placeholder="$t('btn.enter')+'EsDeptCreator'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsDeptCreateTime" prop="esDeptCreateTime">
              <el-date-picker clearable v-model="form.esDeptCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsDeptModifier" prop="esDeptModifier">
              <el-input clearable v-model="form.esDeptModifier" :placeholder="$t('btn.enter')+'EsDeptModifier'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsDeptModifyTime" prop="esDeptModifyTime">
              <el-date-picker clearable v-model="form.esDeptModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
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

          <el-col :lg="12">
            <el-form-item label="备注" prop="reMark">
              <el-input clearable v-model="form.reMark" :placeholder="$t('btn.enter')+'备注'"  :disabled="true"/>
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

<script setup name="ppecslave">
// 引入 ppecslave操作方法
import { listPpEcSlave, addPpEcSlave, delPpEcSlave, updatePpEcSlave, getPpEcSlave, 
 
 } 
from '@/api/production/ppecslave.js'
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
  { visible: false, prop: 'esPurType', label: '采购类型' },
  { visible: false, prop: 'emEcImpDept', label: '实施部门' },
  { visible: false, prop: 'esSloc', label: '仓库' },
  { visible: false, prop: 'isCheck', label: '检验否' },
  { visible: false, prop: 'isEol', label: '停产否' },
  { visible: false, prop: 'esOldCurrStock', label: '旧品库存' },
  { visible: false, prop: 'esNewCurrStock', label: '新品库存' },
  { visible: false, prop: 'esDeptEntryDate', label: '部门录入日' },
  { visible: false, prop: 'esDeptName', label: '部门名称' },
  { visible: false, prop: 'esSupplier', label: '供应商' },
  { visible: false, prop: 'esPurOrder', label: '采购PO' },
  { visible: false, prop: 'esPurNote', label: '说明' },
  { visible: false, prop: 'esPmcLot', label: '预投入批次' },
  { visible: false, prop: 'esPmcMemo', label: '说明' },
  { visible: false, prop: 'esPmcNote', label: '备注' },
  { visible: false, prop: 'esIqcOrder', label: '检验订单' },
  { visible: false, prop: 'esIqcNote', label: '说明' },
  { visible: false, prop: 'esMmLot', label: '领用批次' },
  { visible: false, prop: 'esMmMocNo', label: '工单' },
  { visible: false, prop: 'esMmNote', label: '说明' },
  { visible: false, prop: 'esPpLine', label: '班组' },
  { visible: false, prop: 'esPpLot', label: '生产批次' },
  { visible: false, prop: 'esPpNote', label: '说明' },
  { visible: false, prop: 'esPcbaLine', label: 'Pcba班组' },
  { visible: false, prop: 'esPcbaLot', label: 'Pcba批次' },
  { visible: false, prop: 'esPcbaNote', label: '说明' },
  { visible: false, prop: 'esQaLot', label: '检验批次' },
  { visible: false, prop: 'esQaNote', label: '说明' },
  { visible: false, prop: 'esDeptCreator', label: 'EsDeptCreator' },
  { visible: false, prop: 'esDeptCreateTime', label: 'EsDeptCreateTime' },
  { visible: false, prop: 'esDeptModifier', label: 'EsDeptModifier' },
  { visible: false, prop: 'esDeptModifyTime', label: 'EsDeptModifyTime' },
])
  // 总条数
const total = ref(0)
  // 从设变信息表表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取从设变信息表表记录数据
function getList(){
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
function resetQuery(){
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
    esEntryDate: [{ required: true, message: "输入日"+proxy.$t('btn.empty'), trigger: "blur" }],
    esEcNo: [{ required: true, message: "设变No."+proxy.$t('btn.empty'), trigger: "blur" }],
    esModel: [{ required: true, message: "机种"+proxy.$t('btn.empty'), trigger: "blur" }],
    esItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "blur" }],
    esOldUsageQty: [{ required: true, message: "用量"+proxy.$t('btn.empty'), trigger: "blur" }],
    esNewUsageQty: [{ required: true, message: "用量"+proxy.$t('btn.empty'), trigger: "blur" }],
    esPurType: [{ required: true, message: "采购类型"+proxy.$t('btn.empty'), trigger: "blur" }],
    emEcImpDept: [{ required: true, message: "实施部门"+proxy.$t('btn.empty'), trigger: "blur" }],
    esSloc: [{ required: true, message: "仓库"+proxy.$t('btn.empty'), trigger: "blur" }],
    isCheck: [{ required: true, message: "检验否"+proxy.$t('btn.empty'), trigger: "blur" }],
    isEol: [{ required: true, message: "停产否"+proxy.$t('btn.empty'), trigger: "blur" }],
    esOldCurrStock: [{ required: true, message: "旧品库存"+proxy.$t('btn.empty'), trigger: "blur" }],
    esNewCurrStock: [{ required: true, message: "新品库存"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
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
    esPurType: undefined,
    emEcImpDept: undefined,
    esSloc: undefined,
    isCheck: undefined,
    isEol: undefined,
    esOldCurrStock: undefined,
    esNewCurrStock: undefined,
    esDeptEntryDate: undefined,
    esDeptName: undefined,
    esSupplier: undefined,
    esPurOrder: undefined,
    esPurNote: undefined,
    esPmcLot: undefined,
    esPmcMemo: undefined,
    esPmcNote: undefined,
    esIqcOrder: undefined,
    esIqcNote: undefined,
    esMmLot: undefined,
    esMmMocNo: undefined,
    esMmNote: undefined,
    esPpLine: undefined,
    esPpLot: undefined,
    esPpNote: undefined,
    esPcbaLine: undefined,
    esPcbaLot: undefined,
    esPcbaNote: undefined,
    esQaLot: undefined,
    esQaNote: undefined,
    esDeptCreator: undefined,
    esDeptCreateTime: undefined,
    esDeptModifier: undefined,
    esDeptModifyTime: undefined,
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
        .catch(() => {})
      } else {
        addPpEcSlave(form.value).then((res) => {
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
  const Ids = row.esId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpEcSlave(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}




handleQuery()
</script>