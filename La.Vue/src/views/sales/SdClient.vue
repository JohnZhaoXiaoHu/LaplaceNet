<!--
 * @Descripttion: (客户信息/sd_client)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
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
        <el-button type="primary" v-hasPermi="['sd:client:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sd:client:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sd:client:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['sd:client:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="scId" label="ID" align="center" v-if="columns.showColumn('scId')"/>
      <el-table-column prop="scOrg" label="销售组织" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scOrg')"/>
      <el-table-column prop="scPlant" label="销售工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scPlant')"/>
      <el-table-column prop="scIndustryType" label="行业类别" align="center" v-if="columns.showColumn('scIndustryType')">
        <template #default="scope">
          <dict-tag :options=" options.scIndustryTypeOptions" :value="scope.row.scIndustryType" />
        </template>
      </el-table-column>
      <el-table-column prop="scEnterpriseNature" label="企业性质" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scEnterpriseNature')"/>
      <el-table-column prop="scCode" label="客户代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCode')"/>
      <el-table-column prop="scAbbr" label="客户简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scAbbr')"/>
      <el-table-column prop="scName" label="客户名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scName')"/>
      <el-table-column prop="scEbe" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scEbe')"/>
      <el-table-column prop="scBusinessNo" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBusinessNo')"/>
      <el-table-column prop="scTaxNo" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scTaxNo')"/>
      <el-table-column prop="scTaxType" label="税别" align="center" v-if="columns.showColumn('scTaxType')">
        <template #default="scope">
          <dict-tag :options=" options.scTaxTypeOptions" :value="scope.row.scTaxType" />
        </template>
      </el-table-column>
      <el-table-column prop="scMainBusiness" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scMainBusiness')"/>
      <el-table-column prop="scCcy" label="交易币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCcy')"/>
      <el-table-column prop="scPayTerms" label="付款条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scPayTerms')"/>
      <el-table-column prop="scPayMethod" label="付款方式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scPayMethod')"/>
      <el-table-column prop="scRecAccount" label="统驭科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scRecAccount')"/>
      <el-table-column prop="scTradeTerms" label="贸易条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scTradeTerms')"/>
      <el-table-column prop="scShippingTerms" label="装运条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scShippingTerms')"/>
      <el-table-column prop="scCustomerGrade" label="客户等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCustomerGrade')"/>
      <el-table-column prop="scCustomerCredit" label="客户信用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCustomerCredit')"/>
      <el-table-column prop="scFirstTransDate" label="首次交易" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scFirstTransDate')"/>
      <el-table-column prop="scLastTransDate" label="最近交易" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scLastTransDate')"/>
      <el-table-column prop="scBankCode" label="银行代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankCode')"/>
      <el-table-column prop="scBankName" label="银行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankName')"/>
      <el-table-column prop="scBranchName" label="分行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBranchName')"/>
      <el-table-column prop="scBankCountry" label="银行所在国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankCountry')"/>
      <el-table-column prop="scBankState" label="银行所在州省" align="center" v-if="columns.showColumn('scBankState')">
        <template #default="scope">
          <dict-tag :options=" options.scBankStateOptions" :value="scope.row.scBankState" />
        </template>
      </el-table-column>
      <el-table-column prop="scBankCity" label="银行所在市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankCity')"/>
      <el-table-column prop="scBankCounty" label="银行所在县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankCounty')"/>
      <el-table-column prop="scBankAddr" label="银行地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankAddr')"/>
      <el-table-column prop="scBankAddr1" label="银行地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankAddr1')"/>
      <el-table-column prop="scBankAddr2" label="银行地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankAddr2')"/>
      <el-table-column prop="scBankAccount" label="银行账号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankAccount')"/>
      <el-table-column prop="scBankSwiftNo" label="SWIFT代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scBankSwiftNo')"/>
      <el-table-column prop="scRegionCode" label="国家地区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scRegionCode')"/>
      <el-table-column prop="scState" label="州省" align="center" v-if="columns.showColumn('scState')">
        <template #default="scope">
          <dict-tag :options=" options.scStateOptions" :value="scope.row.scState" />
        </template>
      </el-table-column>
      <el-table-column prop="scCity" label="市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCity')"/>
      <el-table-column prop="scCounty" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scCounty')"/>
      <el-table-column prop="scAddr" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scAddr')"/>
      <el-table-column prop="scAddr1" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scAddr1')"/>
      <el-table-column prop="scAddr2" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scAddr2')"/>
      <el-table-column prop="scContacts" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scContacts')"/>
      <el-table-column prop="scEmail" label="电邮" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scEmail')"/>
      <el-table-column prop="scTelNo" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scTelNo')"/>
      <el-table-column prop="scFaxNp" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scFaxNp')"/>
      <el-table-column prop="scPhoneNo" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('scPhoneNo')"/>
      <el-table-column prop="isFroze" label="冻结标记" align="center" v-if="columns.showColumn('isFroze')">
        <template #default="scope">
          <dict-tag :options=" options.isFrozeOptions" :value="scope.row.isFroze" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['sd:client:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['sd:client:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改客户信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="scId">
              <el-input-number clearable v-model.number="form.scId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="销售组织" prop="scOrg">
              <el-input clearable v-model="form.scOrg" :placeholder="$t('btn.enter')+'销售组织'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售工厂" prop="scPlant">
              <el-input clearable v-model="form.scPlant" :placeholder="$t('btn.enter')+'销售工厂'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业类别" prop="scIndustryType">
              <el-select v-model="form.scIndustryType" filterable clearable  :placeholder="$t('btn.select')+'行业类别'">
                <el-option v-for="item in  options.scIndustryTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业性质" prop="scEnterpriseNature">
              <el-input clearable v-model="form.scEnterpriseNature" :placeholder="$t('btn.enter')+'企业性质'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户代码" prop="scCode">
              <el-input clearable v-model="form.scCode" :placeholder="$t('btn.enter')+'客户代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户简称" prop="scAbbr">
              <el-input clearable v-model="form.scAbbr" :placeholder="$t('btn.enter')+'客户简称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户名称" prop="scName">
              <el-input clearable v-model="form.scName" :placeholder="$t('btn.enter')+'客户名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="scEbe">
              <el-input clearable v-model="form.scEbe" :placeholder="$t('btn.enter')+'企业法人'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="scBusinessNo">
              <el-input clearable v-model="form.scBusinessNo" :placeholder="$t('btn.enter')+'营业执照'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="scTaxNo">
              <el-input clearable v-model="form.scTaxNo" :placeholder="$t('btn.enter')+'税号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="scTaxType">
              <el-select v-model="form.scTaxType" filterable clearable  :placeholder="$t('btn.select')+'税别'">
                <el-option v-for="item in  options.scTaxTypeOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主营业务" prop="scMainBusiness">
              <el-input clearable v-model="form.scMainBusiness" :placeholder="$t('btn.enter')+'主营业务'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交易币种" prop="scCcy">
              <el-input clearable v-model="form.scCcy" :placeholder="$t('btn.enter')+'交易币种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="付款条件" prop="scPayTerms">
              <el-input clearable v-model="form.scPayTerms" :placeholder="$t('btn.enter')+'付款条件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="付款方式" prop="scPayMethod">
              <el-input clearable v-model="form.scPayMethod" :placeholder="$t('btn.enter')+'付款方式'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="scRecAccount">
              <el-input clearable v-model="form.scRecAccount" :placeholder="$t('btn.enter')+'统驭科目'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="scTradeTerms">
              <el-input clearable v-model="form.scTradeTerms" :placeholder="$t('btn.enter')+'贸易条件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装运条件" prop="scShippingTerms">
              <el-input clearable v-model="form.scShippingTerms" :placeholder="$t('btn.enter')+'装运条件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户等级" prop="scCustomerGrade">
              <el-input clearable v-model="form.scCustomerGrade" :placeholder="$t('btn.enter')+'客户等级'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户信用" prop="scCustomerCredit">
              <el-input clearable v-model="form.scCustomerCredit" :placeholder="$t('btn.enter')+'客户信用'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="首次交易" prop="scFirstTransDate">
              <el-date-picker clearable v-model="form.scFirstTransDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最近交易" prop="scLastTransDate">
              <el-date-picker clearable v-model="form.scLastTransDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行代码" prop="scBankCode">
              <el-input clearable v-model="form.scBankCode" :placeholder="$t('btn.enter')+'银行代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行名称" prop="scBankName">
              <el-input clearable v-model="form.scBankName" :placeholder="$t('btn.enter')+'银行名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分行名称" prop="scBranchName">
              <el-input clearable v-model="form.scBranchName" :placeholder="$t('btn.enter')+'分行名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在国" prop="scBankCountry">
              <el-input clearable v-model="form.scBankCountry" :placeholder="$t('btn.enter')+'银行所在国'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在州省" prop="scBankState">
              <el-radio-group v-model="form.scBankState">
                <el-radio v-for="item in  options.scBankStateOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在市" prop="scBankCity">
              <el-input clearable v-model="form.scBankCity" :placeholder="$t('btn.enter')+'银行所在市'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在县" prop="scBankCounty">
              <el-input clearable v-model="form.scBankCounty" :placeholder="$t('btn.enter')+'银行所在县'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址" prop="scBankAddr">
              <el-input clearable v-model="form.scBankAddr" :placeholder="$t('btn.enter')+'银行地址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址1" prop="scBankAddr1">
              <el-input clearable v-model="form.scBankAddr1" :placeholder="$t('btn.enter')+'银行地址1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址2" prop="scBankAddr2">
              <el-input clearable v-model="form.scBankAddr2" :placeholder="$t('btn.enter')+'银行地址2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行账号" prop="scBankAccount">
              <el-input clearable v-model="form.scBankAccount" :placeholder="$t('btn.enter')+'银行账号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SWIFT代码" prop="scBankSwiftNo">
              <el-input clearable v-model="form.scBankSwiftNo" :placeholder="$t('btn.enter')+'SWIFT代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="scRegionCode">
              <el-input clearable v-model="form.scRegionCode" :placeholder="$t('btn.enter')+'国家地区'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="州省" prop="scState">
              <el-radio-group v-model="form.scState">
                <el-radio v-for="item in  options.scStateOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="市" prop="scCity">
              <el-input clearable v-model="form.scCity" :placeholder="$t('btn.enter')+'市'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="县" prop="scCounty">
              <el-input clearable v-model="form.scCounty" :placeholder="$t('btn.enter')+'县'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="scAddr">
              <el-input clearable v-model="form.scAddr" :placeholder="$t('btn.enter')+'地址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址1" prop="scAddr1">
              <el-input clearable v-model="form.scAddr1" :placeholder="$t('btn.enter')+'地址1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址2" prop="scAddr2">
              <el-input clearable v-model="form.scAddr2" :placeholder="$t('btn.enter')+'地址2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="scContacts">
              <el-input clearable v-model="form.scContacts" :placeholder="$t('btn.enter')+'联系人'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电邮" prop="scEmail">
              <el-input clearable v-model="form.scEmail" :placeholder="$t('btn.enter')+'电邮'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="scTelNo">
              <el-input clearable v-model="form.scTelNo" :placeholder="$t('btn.enter')+'电话'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="scFaxNp">
              <el-input clearable v-model="form.scFaxNp" :placeholder="$t('btn.enter')+'传真'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="scPhoneNo">
              <el-input clearable v-model="form.scPhoneNo" :placeholder="$t('btn.enter')+'手机'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="冻结标记" prop="isFroze">
              <el-radio-group v-model="form.isFroze">
                <el-radio v-for="item in  options.isFrozeOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'uDF01'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'uDF02'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'uDF03'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'uDF04'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'uDF05'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'uDF06'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'uDF51'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'uDF52'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'uDF53'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'uDF54'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'uDF55'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="uDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'uDF56'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
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

<script setup name="sdclient">
// 引入 sdclient操作方法
import { listSdClient, addSdClient, delSdClient, updateSdClient, getSdClient, 
 
 } 
from '@/api/sales/sdclient.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中scId数组数组
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
  { visible: true, prop: 'scId', label: 'ID' },
  { visible: true, prop: 'scOrg', label: '销售组织' },
  { visible: true, prop: 'scPlant', label: '销售工厂' },
  { visible: true, prop: 'scIndustryType', label: '行业类别' },
  { visible: true, prop: 'scEnterpriseNature', label: '企业性质' },
  { visible: true, prop: 'scCode', label: '客户代码' },
  { visible: true, prop: 'scAbbr', label: '客户简称' },
  { visible: true, prop: 'scName', label: '客户名称' },
  { visible: false, prop: 'scEbe', label: '企业法人' },
  { visible: false, prop: 'scBusinessNo', label: '营业执照' },
  { visible: false, prop: 'scTaxNo', label: '税号' },
  { visible: false, prop: 'scTaxType', label: '税别' },
  { visible: false, prop: 'scMainBusiness', label: '主营业务' },
  { visible: false, prop: 'scCcy', label: '交易币种' },
  { visible: false, prop: 'scPayTerms', label: '付款条件' },
  { visible: false, prop: 'scPayMethod', label: '付款方式' },
  { visible: false, prop: 'scRecAccount', label: '统驭科目' },
  { visible: false, prop: 'scTradeTerms', label: '贸易条件' },
  { visible: false, prop: 'scShippingTerms', label: '装运条件' },
  { visible: false, prop: 'scCustomerGrade', label: '客户等级' },
  { visible: false, prop: 'scCustomerCredit', label: '客户信用' },
  { visible: false, prop: 'scFirstTransDate', label: '首次交易' },
  { visible: false, prop: 'scLastTransDate', label: '最近交易' },
  { visible: false, prop: 'scBankCode', label: '银行代码' },
  { visible: false, prop: 'scBankName', label: '银行名称' },
  { visible: false, prop: 'scBranchName', label: '分行名称' },
  { visible: false, prop: 'scBankCountry', label: '银行所在国' },
  { visible: false, prop: 'scBankState', label: '银行所在州省' },
  { visible: false, prop: 'scBankCity', label: '银行所在市' },
  { visible: false, prop: 'scBankCounty', label: '银行所在县' },
  { visible: false, prop: 'scBankAddr', label: '银行地址' },
  { visible: false, prop: 'scBankAddr1', label: '银行地址1' },
  { visible: false, prop: 'scBankAddr2', label: '银行地址2' },
  { visible: false, prop: 'scBankAccount', label: '银行账号' },
  { visible: false, prop: 'scBankSwiftNo', label: 'SWIFT代码' },
  { visible: false, prop: 'scRegionCode', label: '国家地区' },
  { visible: false, prop: 'scState', label: '州省' },
  { visible: false, prop: 'scCity', label: '市' },
  { visible: false, prop: 'scCounty', label: '县' },
  { visible: false, prop: 'scAddr', label: '地址' },
  { visible: false, prop: 'scAddr1', label: '地址1' },
  { visible: false, prop: 'scAddr2', label: '地址2' },
  { visible: false, prop: 'scContacts', label: '联系人' },
  { visible: false, prop: 'scEmail', label: '电邮' },
  { visible: false, prop: 'scTelNo', label: '电话' },
  { visible: false, prop: 'scFaxNp', label: '传真' },
  { visible: false, prop: 'scPhoneNo', label: '手机' },
  { visible: false, prop: 'isFroze', label: '冻结标记' },
  { visible: false, prop: 'remark', label: '说明' },
])
  // 总条数
const total = ref(0)
  // 客户信息表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取客户信息表记录数据
function getList(){
  loading.value = true
  listSdClient(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.scId);
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
    scOrg: [{ required: true, message: "销售组织"+proxy.$t('btn.empty'), trigger: "blur" }],
    scPlant: [{ required: true, message: "销售工厂"+proxy.$t('btn.empty'), trigger: "blur" }],
    scIndustryType: [{ required: true, message: "行业类别"+proxy.$t('btn.empty'), trigger: "change" }],
    scEnterpriseNature: [{ required: true, message: "企业性质"+proxy.$t('btn.empty'), trigger: "blur" }],
    scCode: [{ required: true, message: "客户代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    scAbbr: [{ required: true, message: "客户简称"+proxy.$t('btn.empty'), trigger: "blur" }],
    scName: [{ required: true, message: "客户名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    scEbe: [{ required: true, message: "企业法人"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBusinessNo: [{ required: true, message: "营业执照"+proxy.$t('btn.empty'), trigger: "blur" }],
    scTaxNo: [{ required: true, message: "税号"+proxy.$t('btn.empty'), trigger: "blur" }],
    scTaxType: [{ required: true, message: "税别"+proxy.$t('btn.empty'), trigger: "change" }],
    scMainBusiness: [{ required: true, message: "主营业务"+proxy.$t('btn.empty'), trigger: "blur" }],
    scCcy: [{ required: true, message: "交易币种"+proxy.$t('btn.empty'), trigger: "blur" }],
    scPayTerms: [{ required: true, message: "付款条件"+proxy.$t('btn.empty'), trigger: "blur" }],
    scPayMethod: [{ required: true, message: "付款方式"+proxy.$t('btn.empty'), trigger: "blur" }],
    scRecAccount: [{ required: true, message: "统驭科目"+proxy.$t('btn.empty'), trigger: "blur" }],
    scTradeTerms: [{ required: true, message: "贸易条件"+proxy.$t('btn.empty'), trigger: "blur" }],
    scShippingTerms: [{ required: true, message: "装运条件"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankCode: [{ required: true, message: "银行代码"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankName: [{ required: true, message: "银行名称"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankCountry: [{ required: true, message: "银行所在国"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankState: [{ required: true, message: "银行所在州省"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankCity: [{ required: true, message: "银行所在市"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankCounty: [{ required: true, message: "银行所在县"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankAddr: [{ required: true, message: "银行地址"+proxy.$t('btn.empty'), trigger: "blur" }],
    scBankAccount: [{ required: true, message: "银行账号"+proxy.$t('btn.empty'), trigger: "blur" }],
    scAddr: [{ required: true, message: "地址"+proxy.$t('btn.empty'), trigger: "blur" }],
    isFroze: [{ required: true, message: "冻结标记"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF51: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF52: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF53: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF54: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF55: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF56: [{ required: true, message: ""+proxy.$t('btn.empty'), trigger: "blur" }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    scIndustryTypeOptions: [],
    // 税别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    scTaxTypeOptions: [],
    // 银行所在州省 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    scBankStateOptions: [],
    // 州省 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    scStateOptions: [],
    // 冻结标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isFrozeOptions: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isDeletedOptions: [],
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
    scOrg: undefined,
    scPlant: undefined,
    scIndustryType: undefined,
    scEnterpriseNature: undefined,
    scCode: undefined,
    scAbbr: undefined,
    scName: undefined,
    scEbe: undefined,
    scBusinessNo: undefined,
    scTaxNo: undefined,
    scTaxType: undefined,
    scMainBusiness: undefined,
    scCcy: undefined,
    scPayTerms: undefined,
    scPayMethod: undefined,
    scRecAccount: undefined,
    scTradeTerms: undefined,
    scShippingTerms: undefined,
    scCustomerGrade: undefined,
    scCustomerCredit: undefined,
    scFirstTransDate: undefined,
    scLastTransDate: undefined,
    scBankCode: undefined,
    scBankName: undefined,
    scBranchName: undefined,
    scBankCountry: undefined,
    scBankState: undefined,
    scBankCity: undefined,
    scBankCounty: undefined,
    scBankAddr: undefined,
    scBankAddr1: undefined,
    scBankAddr2: undefined,
    scBankAccount: undefined,
    scBankSwiftNo: undefined,
    scRegionCode: undefined,
    scState: undefined,
    scCity: undefined,
    scCounty: undefined,
    scAddr: undefined,
    scAddr1: undefined,
    scAddr2: undefined,
    scContacts: undefined,
    scEmail: undefined,
    scTelNo: undefined,
    scFaxNp: undefined,
    scPhoneNo: undefined,
    isFroze: undefined,
    uDF01: undefined,
    uDF02: undefined,
    uDF03: undefined,
    uDF04: undefined,
    uDF05: undefined,
    uDF06: undefined,
    uDF51: undefined,
    uDF52: undefined,
    uDF53: undefined,
    uDF54: undefined,
    uDF55: undefined,
    uDF56: undefined,
    remark: undefined,
    isDeleted: undefined,
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
  const id = row.scId || ids.value
  getSdClient(id).then((res) => {
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
      if (form.value.scId != undefined && opertype.value === 2) {
        updateSdClient(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addSdClient(form.value).then((res) => {
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
  const Ids = row.scId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delSdClient(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"客户信息", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/sales/SdClient/export', { ...queryParams })
    })
}

handleQuery()
</script>