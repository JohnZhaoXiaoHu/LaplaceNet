<!--
 * @Descripttion: (物料信息/mm_mats)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-25)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-25)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="mmPlnt">
        <el-select clearable v-model="queryParams.mmPlnt" placeholder="请选择工厂">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mmMatItem">
        <el-input v-model="queryParams.mmMatItem" placeholder="请输入物料" />
      </el-form-item>
      <el-form-item label="行业类别" prop="mmIndustry">
        <el-select clearable v-model="queryParams.mmIndustry" placeholder="请选择行业类别">
          <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料类型" prop="mmMatType">
        <el-select clearable v-model="queryParams.mmMatType" placeholder="请选择物料类型">
          <el-option v-for="item in  options.sys_mats_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="标准单位" prop="mmBaseUnit">
        <el-select clearable v-model="queryParams.mmBaseUnit" placeholder="请选择标准单位">
          <el-option v-for="item in  options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料组" prop="mmMatGroup">
        <el-select clearable v-model="queryParams.mmMatGroup" placeholder="请选择物料组">
          <el-option v-for="item in  options.sys_mats_group " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="mmPurGroup">
        <el-select clearable v-model="queryParams.mmPurGroup" placeholder="请选择采购组">
          <el-option v-for="item in  options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购类型" prop="mmPurType">
        <el-select clearable v-model="queryParams.mmPurType" placeholder="请选择采购类型">
          <el-option v-for="item in  options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="mmProfitCenter">
        <el-select clearable v-model="queryParams.mmProfitCenter" placeholder="请选择利润中心">
          <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="mmValType">
        <el-select clearable v-model="queryParams.mmValType" placeholder="请选择评估类">
          <el-option v-for="item in  options.sys_fin_val " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="mmCcy">
        <el-select clearable v-model="queryParams.mmCcy" placeholder="请选择币种">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购仓库" prop="mmSLoc">
        <el-select clearable v-model="queryParams.mmSLoc" placeholder="请选择采购仓库">
          <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仓位" prop="mmLocPosn">
        <el-input v-model="queryParams.mmLocPosn" placeholder="请输入仓位" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['mm:mats:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:mats:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:mats:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['mm:mats:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['mm:mats:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <!-- <el-table-column prop="mmId" label="ID" align="center" v-if="columns.showColumn('mmId')" />
      <el-table-column prop="mmLastDate" label="更新日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmLastDate')" /> -->
      <el-table-column prop="mmPlnt" label="工厂" align="center" v-if="columns.showColumn('mmPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.mmPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="mmMatItem" label="物料" align="left" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmMatItem')" />
      <el-table-column prop="mmIndustry" label="行业类别" align="center" v-if="columns.showColumn('mmIndustry')">
        <!-- <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mmIndustry" />
        </template> -->
      </el-table-column>
      <el-table-column prop="mmMatType" label="物料类型" align="center" v-if="columns.showColumn('mmMatType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mats_type " :value="scope.row.mmMatType" />
        </template>
      </el-table-column>
      <el-table-column prop="mmMatDes" label="物料文本" align="left" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmMatDes')" />
      <el-table-column prop="mmBaseUnit" label="标准单位" align="center" v-if="columns.showColumn('mmBaseUnit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.mmBaseUnit" />
        </template>
      </el-table-column>
      <el-table-column prop="mmProLevel" label="层次" align="left" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmProLevel')" />
      <el-table-column prop="mmMatGroup" label="物料组" align="center" v-if="columns.showColumn('mmMatGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mats_group " :value="scope.row.mmMatGroup" />
        </template>
      </el-table-column>
      <el-table-column prop="mmPurGroup" label="采购组" align="center" v-if="columns.showColumn('mmPurGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.mmPurGroup" />
        </template>
      </el-table-column>
      <el-table-column prop="mmPurType" label="采购类型" align="center" v-if="columns.showColumn('mmPurType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.mmPurType" />
        </template>
      </el-table-column>
      <el-table-column prop="mmSpecType" label="特殊采购类" align="center" v-if="columns.showColumn('mmSpecType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_spec " :value="scope.row.mmSpecType" />
        </template>
      </el-table-column>
      <el-table-column prop="mmBulkMat" label="散装物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmBulkMat')" />
      <el-table-column prop="mmMoq" label="最小批量" align="right" v-if="columns.showColumn('mmMoq')" />
      <el-table-column prop="mmRoundingVal" label="舍入值" align="right" v-if="columns.showColumn('mmRoundingVal')" />
      <el-table-column prop="mmLeadTime" label="交货时间" align="right" v-if="columns.showColumn('mmLeadTime')" />
      <el-table-column prop="mmProDays" label="生产天数" align="right" v-if="columns.showColumn('mmProDays')" />
      <el-table-column prop="mmisChecked" label="检验否" align="center" v-if="columns.showColumn('mmisChecked')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.mmisChecked" />
        </template>
      </el-table-column>
      <el-table-column prop="mmProfitCenter" label="利润中心" align="center" v-if="columns.showColumn('mmProfitCenter')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.mmProfitCenter" />
        </template>
      </el-table-column>
      <el-table-column prop="mmDiffCode" label="差异码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmDiffCode')" />
      <el-table-column prop="mmisLot" label="批次管理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmisLot')" />
      <el-table-column prop="mmMpn" label="制造商物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmMpn')" />
      <el-table-column prop="mmMfrs" label="制造商" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmMfrs')" />
      <el-table-column prop="mmValType" label="评估类" align="center" v-if="columns.showColumn('mmValType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_fin_val " :value="scope.row.mmValType" />
        </template>
      </el-table-column>
      <el-table-column prop="mmMovingAvg" label="移动平均价" align="right" v-if="columns.showColumn('mmMovingAvg')" />
      <el-table-column prop="mmCcy" label="币种" align="center" v-if="columns.showColumn('mmCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.mmCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="mmPriceControl" label="价格控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmPriceControl')" />
      <el-table-column prop="mmPriceUnit" label="价格单位" align="right" v-if="columns.showColumn('mmPriceUnit')" />
      <el-table-column prop="mmSLoc" label="采购仓库" align="center" v-if="columns.showColumn('mmSLoc')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.mmSLoc" />
        </template>
      </el-table-column>
      <el-table-column prop="mmESLoc" label="生产仓库" align="center" v-if="columns.showColumn('mmESLoc')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.mmESLoc" />
        </template>
      </el-table-column>
      <el-table-column prop="mmLocPosn" label="仓位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmLocPosn')" />
      <el-table-column prop="mmInventory" label="库存" align="right" v-if="columns.showColumn('mmInventory')" />
      <el-table-column prop="mmLocEol" label="EOL" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmLocEol')" />
      <el-table-column prop="reMark" label="reMark" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('reMark')" />
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['mm:mats:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['mm:mats:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改物料信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <!-- <el-col :lg="12">
            <el-form-item label="ID" prop="mmId">
              <el-input-number v-model.number="form.mmId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col> -->


          <el-col :lg="24">
            <el-form-item label="更新日期" prop="mmLastDate">
              <el-date-picker v-model="form.mmLastDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="工厂" prop="mmPlnt">
              <el-select v-model="form.mmPlnt" :placeholder="$t('btn.select')+'工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="行业类别" prop="mmIndustry">
              <el-select v-model="form.mmIndustry" :placeholder="$t('btn.select')+'行业类别'" clearable>
                <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="物料类型" prop="mmMatType">
              <el-select v-model="form.mmMatType" :placeholder="$t('btn.select')+'物料类型'" clearable filterable
                :disabled="title==$t('btn.edit')" @change="Matassignment">
                <el-option v-for="(item,index) in  options.sys_mats_type " :key="index" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="物料" prop="mmMatItem">
              <el-select v-model="form.mmMatTypes" :placeholder="$t('btn.select')+'物料'" clearable filterable
                :disabled="title==$t('btn.edit')" @change="MatCodeassignment">
                <el-option v-for="item in  options.sql_mats_code " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
              <el-input v-model="form.mmMatItem" :placeholder="$t('btn.enter')+'物料'" :disabled="title==$t('btn.edit')">
              </el-input>
              <div style="color:Coral; font-weight:bolder">
                {{matscode}}
              </div>


            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="物料文本" prop="mmMatDes">
              <el-input v-model="form.mmMatDes" :placeholder="$t('btn.enter')+'物料文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="标准单位" prop="mmBaseUnit">
              <el-select v-model="form.mmBaseUnit" :placeholder="$t('btn.select')+'标准单位'" clearable
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="层次" prop="mmProLevel">
              <el-input v-model="form.mmProLevel" :placeholder="$t('btn.enter')+'层次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="物料组" prop="mmMatGroup">
              <el-select v-model="form.mmMatGroup" :placeholder="$t('btn.select')+'物料组'" clearable>
                <el-option v-for="item in  options.sys_mats_group " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="采购组" prop="mmPurGroup">
              <el-select v-model="form.mmPurGroup" :placeholder="$t('btn.select')+'采购组'" clearable>
                <el-option v-for="item in  options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="采购类型" prop="mmPurType">
              <el-select v-model="form.mmPurType" :placeholder="$t('btn.select')+'采购类型'" clearable>
                <el-option v-for="item in  options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="特殊采购类" prop="mmSpecType">
              <el-select v-model="form.mmSpecType" :placeholder="$t('btn.select')+'特殊采购类'" clearable>
                <el-option v-for="item in  options.sys_pur_spec " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="散装物料" prop="mmBulkMat">
              <el-input v-model="form.mmBulkMat" :placeholder="$t('btn.enter')+'散装物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="最小批量" prop="mmMoq">
              <el-input-number v-model.number="form.mmMoq" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'最小批量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="舍入值" prop="mmRoundingVal">
              <el-input-number v-model.number="form.mmRoundingVal" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'舍入值'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="交货时间" prop="mmLeadTime">
              <el-input-number v-model.number="form.mmLeadTime" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'交货时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="生产天数" prop="mmProDays">
              <el-input-number v-model.number="form.mmProDays" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'生产天数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="检验否" prop="mmisChecked">
              <el-select v-model="form.mmisChecked" :placeholder="$t('btn.select')+'检验否'">
                <el-option v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="利润中心" prop="mmProfitCenter">
              <el-select v-model="form.mmProfitCenter" :placeholder="$t('btn.select')+'利润中心'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="差异码" prop="mmDiffCode">
              <el-input v-model="form.mmDiffCode" :placeholder="$t('btn.enter')+'差异码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="批次管理" prop="mmisLot">
              <el-input v-model="form.mmisLot" :placeholder="$t('btn.enter')+'批次管理'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商物料" prop="mmMpn">
              <el-input v-model="form.mmMpn" :placeholder="$t('btn.enter')+'制造商物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="mmMfrs">
              <el-input v-model="form.mmMfrs" :placeholder="$t('btn.enter')+'制造商'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="评估类" prop="mmValType">
              <el-select v-model="form.mmValType" :placeholder="$t('btn.select')+'评估类'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sys_fin_val " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="移动平均价" prop="mmMovingAvg">
              <el-input-number v-model.number="form.mmMovingAvg" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'移动平均价'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="币种" prop="mmCcy">
              <el-select v-model="form.mmCcy" :placeholder="$t('btn.select')+'币种'" :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="价格控制" prop="mmPriceControl">
              <el-input v-model="form.mmPriceControl" :placeholder="$t('btn.enter')+'价格控制'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="价格单位" prop="mmPriceUnit">
              <el-input-number v-model.number="form.mmPriceUnit" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'价格单位'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="采购仓库" prop="mmSLoc">
              <el-select v-model="form.mmSLoc" :placeholder="$t('btn.select')+'采购仓库'" :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="生产仓库" prop="mmESLoc">
              <el-select v-model="form.mmESLoc" :placeholder="$t('btn.select')+'生产仓库'"
                :disabled="title==$t('btn.edit')">
                <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="仓位" prop="mmLocPosn">
              <el-input v-model="form.mmLocPosn" :placeholder="$t('btn.enter')+'仓位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="库存" prop="mmInventory">
              <el-input-number v-model.number="form.mmInventory" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="EOL" prop="mmLocEol">
              <el-select v-model="form.mmLocEol" clearable :placeholder="$t('btn.select')+'EOL'">
                <el-option v-for="item in  options.sys_eol_type " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>

            </el-form-item>
          </el-col>

          <!-- <el-col :lg="24">
            <el-form-item label="uDF01" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'uDF01'" :disabled="true" />
            </el-form-item>
          </el-col> -->
          <!-- <el-col :lg="12">
            <el-form-item label="uDF01" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'uDF01'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF02" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'uDF02'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF03" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'uDF03'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF04" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'uDF04'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF05" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'uDF05'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF06" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'uDF06'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF51" prop="uDF51">
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enter')+'uDF51'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF52" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enter')+'uDF52'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF53" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enter')+'uDF53'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF54" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enter')+'uDF54'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF55" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enter')+'uDF55'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF56" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enter')+'uDF56'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input v-model="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="reMark" prop="reMark">
              <el-input v-model="form.reMark" :placeholder="$t('btn.enter')+'reMark'" />
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
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')" :disabled="true"></el-date-picker>
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

<script setup name="mmmats">
  // 引入 mmmats操作方法
  import {
    listMmMats, addMmMats, delMmMats, updateMmMats, getMmMats,

  }
    from '@/api/material/mmmats.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中mmId数组数组
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
    sort: 'MmMatItem',
    sortType: 'asc',
    mmPlnt: undefined,
    mmMatItem: undefined,
    mmIndustry: undefined,
    mmMatType: undefined,
    mmBaseUnit: undefined,
    mmMatGroup: undefined,
    mmPurGroup: undefined,
    mmPurType: undefined,
    mmProfitCenter: undefined,
    mmValType: undefined,
    mmCcy: undefined,
    mmSLoc: undefined,
    mmLocPosn: undefined,
    matscode: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'mmId', label: 'ID' },
    { visible: true, prop: 'mmLastDate', label: '更新日期' },
    { visible: true, prop: 'mmPlnt', label: '工厂' },
    { visible: true, prop: 'mmMatItem', label: '物料' },
    { visible: true, prop: 'mmIndustry', label: '行业类别' },
    { visible: true, prop: 'mmMatType', label: '物料类型' },
    { visible: true, prop: 'mmMatDes', label: '物料文本' },
    { visible: true, prop: 'mmBaseUnit', label: '标准单位' },
    { visible: false, prop: 'mmProLevel', label: '层次' },
    { visible: false, prop: 'mmMatGroup', label: '物料组' },
    { visible: true, prop: 'mmPurGroup', label: '采购组' },
    { visible: false, prop: 'mmPurType', label: '采购类型' },
    { visible: false, prop: 'mmSpecType', label: '特殊采购类' },
    { visible: false, prop: 'mmBulkMat', label: '散装物料' },
    { visible: false, prop: 'mmMoq', label: '最小批量' },
    { visible: false, prop: 'mmRoundingVal', label: '舍入值' },
    { visible: false, prop: 'mmLeadTime', label: '交货时间' },
    { visible: false, prop: 'mmProDays', label: '生产天数' },
    { visible: false, prop: 'mmisChecked', label: '检验否' },
    { visible: true, prop: 'mmProfitCenter', label: '利润中心' },
    { visible: false, prop: 'mmDiffCode', label: '差异码' },
    { visible: false, prop: 'mmisLot', label: '批次管理' },
    { visible: false, prop: 'mmMpn', label: '制造商物料' },
    { visible: false, prop: 'mmMfrs', label: '制造商' },
    { visible: true, prop: 'mmValType', label: '评估类' },
    { visible: true, prop: 'mmMovingAvg', label: '移动平均价' },
    { visible: false, prop: 'mmCcy', label: '币种' },
    { visible: false, prop: 'mmPriceControl', label: '价格控制' },
    { visible: false, prop: 'mmPriceUnit', label: '价格单位' },
    { visible: false, prop: 'mmSLoc', label: '采购仓库' },
    { visible: false, prop: 'mmESLoc', label: '生产仓库' },
    { visible: false, prop: 'mmLocPosn', label: '仓位' },
    { visible: true, prop: 'mmInventory', label: '库存' },
    { visible: false, prop: 'mmLocEol', label: 'EOL' },
    { visible: false, prop: 'reMark', label: '' },
  ])
  // 总条数
  const total = ref(0)
  // 物料信息表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  //利用物料现有编码计算出物料号


  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_ind_type" },
    { dictType: "sys_mats_type" },
    { dictType: "sys_unit_list" },
    { dictType: "sys_mats_group" },
    { dictType: "sys_pur_group" },
    { dictType: "sys_pur_type" },
    { dictType: "sys_pur_spec" },
    { dictType: "sys_flag_list" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_fin_val" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_eol_type" },
    { dictType: "sql_mats_code" },

  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取物料信息表记录数据
  function getList() {
    loading.value = true
    listMmMats(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }
  //按物料编码获取物料号码
  const matscode = ref()
  function MatCodeassignment(val) {

    switch (val.split(",").slice(0, 1).join()) {
      case '3A':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("A") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("A") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("A") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("A") + 1)), 0)
        form.value.uDF01 = "首字符位置：" + "末字符位置：" + "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("A") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("A") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("A") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("A") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("A") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("A") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("A") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("A") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3B':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("B") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("B") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("B") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("B") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("B") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("B") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("B") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("B") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("B") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("B") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("B") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("B") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3C':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3D':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3E':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3F':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3M':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3S':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3R':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case '3Y':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'A':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'B':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'C':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'D':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'E':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'F':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'M':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'S':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'R':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      case 'Y':
        form.value.mmMatItem = val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        form.value.uDF01 = "旧物料：" + val.split(",").slice(1, 2).join() + ",开头：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数值部分：" + val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + ",数字位数：" + (val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + ",新物料编号：" + val.split(",").slice(1, 2).join().substring(0, val.split(",").slice(1, 2).join().lastIndexOf("S") + 1) + parseFloat(Number(val.split(",").slice(1, 2).join().substring(val.split(",").slice(1, 2).join().lastIndexOf("S") + 1, val.split(",").slice(1, 2).join().length - val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)) + 1).toFixed(0).padStart((val.split(",").slice(1, 2).join().length - (val.split(",").slice(1, 2).join().lastIndexOf("S") + 1)), 0)
        matscode.value = form.value.uDF01
        break;
      default:
        form.value.mmMatItem = val.split(",").slice(1, 2).join() //传值
        matscode.value = val.split(",").slice(1, 2).join() + "  目前系统中最大值请修改！！！" //传值
        break;
    }






    //form.value.mmMatItem = val
  }


  //按物料类型定义其它属性值 
  function Matassignment(val) {

    switch (val) {
      //评估类
      case 'ROH':
        form.value.mmPurType = 'F'
        form.value.mmValType = 'Z300'
        form.value.mmLeadTime = 30
        form.value.mmProDays = 1
        break;
      case 'FERT':
        form.value.mmPurType = 'M'
        form.value.mmValType = 'Z792'
        form.value.mmDiffCode = '000001'
        form.value.mmLeadTime = 1
        form.value.mmProDays = 5
        break;
      case 'HALB':
        form.value.mmPurType = 'M'
        form.value.mmValType = 'Z790'
        form.value.mmDiffCode = '000001'
        form.value.mmLeadTime = 1
        form.value.mmProDays = 2.5
        break;
      case 'FREM':
        form.value.mmPurType = 'F'
        form.value.mmValType = 'Z794'
        form.value.mmLeadTime = 30
        form.value.mmProDays = 1
        break;
      default:
        form.value.mmPurType = ''
        form.value.mmValType = ''
        form.value.mmLeadTime = 1
        form.value.mmProDays = 1
        break;
    }
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
    ids.value = selection.map((item) => item.mmId);
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
      mmLastDate: [{ required: true, message: "更新日期" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmPlnt: [{ required: true, message: "工厂" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMatItem: [{ required: true, message: "物料" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmIndustry: [{ required: true, message: "行业类别" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMatType: [{ required: true, message: "物料类型" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMatDes: [{ required: true, message: "物料文本" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmBaseUnit: [{ required: true, message: "标准单位" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMatGroup: [{ required: true, message: "物料组" + proxy.$t('btn.empty'), trigger: "change" }],
      mmPurType: [{ required: true, message: "采购类型" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMoq: [{ required: true, message: "最小批量" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      mmRoundingVal: [{ required: true, message: "舍入值" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      mmLeadTime: [{ required: true, message: "交货时间" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      mmProDays: [{ required: true, message: "生产天数" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmProfitCenter: [{ required: true, message: "利润中心" + proxy.$t('btn.empty'), trigger: "change" }],
      mmValType: [{ required: true, message: "评估类" + proxy.$t('btn.empty'), trigger: "change" }],
      mmMovingAvg: [{ required: true, message: "移动平均价" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmCcy: [{ required: true, message: "币种" + proxy.$t('btn.empty'), trigger: "change" }],
      mmPriceControl: [{ required: true, message: "价格控制" + proxy.$t('btn.empty'), trigger: "blur" }],
      mmPriceUnit: [{ required: true, message: "价格单位" + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      mmInventory: [{ required: true, message: "库存" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_mats_type: [],
      // 标准单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_unit_list: [],
      // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_mats_group: [],
      // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_group: [],
      // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_type: [],
      // 特殊采购类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_spec: [],
      // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_flag_list: [],
      // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
      // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_fin_val: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 采购仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 生产仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 停产标志 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_eol_type: [],
      // 物料编码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_mats_code: [],
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
      mmLastDate: undefined,
      mmPlnt: undefined,
      mmMatItem: undefined,
      mmIndustry: undefined,
      mmMatType: undefined,
      mmMatDes: undefined,
      mmBaseUnit: undefined,
      mmProLevel: undefined,
      mmMatGroup: undefined,
      mmPurGroup: undefined,
      mmPurType: undefined,
      mmSpecType: undefined,
      mmBulkMat: undefined,
      mmMoq: undefined,
      mmRoundingVal: undefined,
      mmLeadTime: undefined,
      mmProDays: undefined,
      mmisChecked: undefined,
      mmProfitCenter: undefined,
      mmDiffCode: undefined,
      mmisLot: undefined,
      mmMpn: undefined,
      mmMfrs: undefined,
      mmValType: undefined,
      mmMovingAvg: undefined,
      mmCcy: undefined,
      mmPriceControl: undefined,
      mmPriceUnit: undefined,
      mmSLoc: undefined,
      mmESLoc: undefined,
      mmLocPosn: undefined,
      mmInventory: undefined,
      mmLocEol: undefined,
      reMark: undefined,
      createBy: undefined,
      createTime: undefined,

    };
    proxy.resetForm("formRef")
  }

  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add')
    form.value.mmLastDate = Date.now()
    form.value.mmIndustry = 'C'
    form.value.mmPriceUnit = 1000
    form.value.mmPriceControl = "V"
    form.value.mmInventory = 0
    matscode.value = null
    opertype.value = 1
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.mmId || ids.value
    getMmMats(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit')
        matscode.value = null
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
        if (form.value.mmId != undefined && opertype.value === 2) {
          updateMmMats(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addMmMats(form.value).then((res) => {
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
    const Ids = row.mmId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delMmMats(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "物料信息", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/material/MmMats/export', { ...queryParams })
      })
  }

  handleQuery()
</script>

<style lang="scss" scoped>
</style>