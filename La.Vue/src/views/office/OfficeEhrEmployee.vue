<!--
 * @Descripttion: (人事信息/office_ehr_employee)
 * @version: (1.0)
 * @Author: (Davis.Ching)
 * @Date: (2023-05-16)
 * @LastEditors: (Davis.Ching)
 * @LastEditTime: (2023-05-16)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="姓名" prop="eeName">
        <el-input clearable v-model="queryParams.eeName" :placeholder="$t('btn.enter')+'姓名'" />
      </el-form-item>
      <el-form-item label="性别" prop="eeGender">
        <el-select filterable clearable  v-model="queryParams.eeGender" :placeholder="$t('btn.select')+'性别'">
          <el-option v-for="item in  options.sys_user_sex " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="出生日期">
        <el-date-picker 
          v-model="dateRangeEeBirthday" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'出生日期'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="身份证号" prop="eeIdentityCard">
        <el-input clearable v-model="queryParams.eeIdentityCard" :placeholder="$t('btn.enter')+'身份证号'" />
      </el-form-item>
      <el-form-item label="婚姻状态" prop="eeWedlock">
        <el-select filterable clearable  v-model="queryParams.eeWedlock" :placeholder="$t('btn.select')+'婚姻状态'">
          <el-option v-for="item in  options.sys_wedlock_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="民族" prop="eeNationId">
        <el-select filterable clearable  v-model="queryParams.eeNationId" :placeholder="$t('btn.select')+'民族'">
          <el-option v-for="item in  options.sys_nation_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="籍贯" prop="eeNativePlace">
        <el-select filterable clearable  v-model="queryParams.eeNativePlace" :placeholder="$t('btn.select')+'籍贯'">
          <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="政治面貌" prop="eePoliticId">
        <el-select filterable clearable  v-model="queryParams.eePoliticId" :placeholder="$t('btn.select')+'政治面貌'">
          <el-option v-for="item in  options.sys_politic_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="国家/地区" prop="eeCountry">
        <el-select filterable clearable  v-model="queryParams.eeCountry" :placeholder="$t('btn.select')+'国家/地区'">
          <el-option v-for="item in  options.sys_country_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="省区" prop="eeProvince">
        <el-select filterable clearable  v-model="queryParams.eeProvince" :placeholder="$t('btn.select')+'省区'">
          <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="户口性质" prop="eeHouseholdType">
        <el-select filterable clearable  v-model="queryParams.eeHouseholdType" :placeholder="$t('btn.select')+'户口性质'">
          <el-option v-for="item in  options.sys_household_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部门" prop="eeDepartmentId">
        <el-select filterable clearable  v-model="queryParams.eeDepartmentId" :placeholder="$t('btn.select')+'部门'">
          <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="职称" prop="eeTitlesId">
        <el-select filterable clearable  v-model="queryParams.eeTitlesId" :placeholder="$t('btn.select')+'职称'">
          <el-option v-for="item in  options.sys_titles_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="岗位" prop="eePostId">
        <el-select filterable clearable  v-model="queryParams.eePostId" :placeholder="$t('btn.select')+'岗位'">
          <el-option v-for="item in  options.sys_post_level " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="等级" prop="eePostLevel">
        <el-select filterable clearable  v-model="queryParams.eePostLevel" :placeholder="$t('btn.select')+'等级'">
          <el-option v-for="item in  options.sys_post_level " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="职务" prop="eeDutyName">
        <el-select filterable clearable  v-model="queryParams.eeDutyName" :placeholder="$t('btn.select')+'职务'">
          <el-option v-for="item in  options.sql_posts_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="招聘来源" prop="eeRecruited">
        <el-select filterable clearable  v-model="queryParams.eeRecruited" :placeholder="$t('btn.select')+'招聘来源'">
          <el-option v-for="item in  options.sys_recruited_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="聘用形式" prop="eeEngageForm">
        <el-select filterable clearable  v-model="queryParams.eeEngageForm" :placeholder="$t('btn.select')+'聘用形式'">
          <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="学历" prop="eeTiptopDegrEe">
        <el-select filterable clearable  v-model="queryParams.eeTiptopDegrEe" :placeholder="$t('btn.select')+'学历'">
          <el-option v-for="item in  options.sys_level_education " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="专业" prop="eeSpecialty">
        <el-select filterable clearable  v-model="queryParams.eeSpecialty" :placeholder="$t('btn.select')+'专业'">
          <el-option v-for="item in  options.sys_specialty_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工号" prop="eeWorkID">
        <el-input clearable v-model="queryParams.eeWorkID" :placeholder="$t('btn.enter')+'工号'" />
      </el-form-item>
      <el-form-item label="在职状态" prop="eeWorkState">
        <el-select filterable clearable  v-model="queryParams.eeWorkState" :placeholder="$t('btn.select')+'在职状态'">
          <el-option v-for="item in  options.sys_workstate_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="试用期" prop="eeProbation">
        <el-select filterable clearable  v-model="queryParams.eeProbation" :placeholder="$t('btn.select')+'试用期'">
          <el-option v-for="item in  options.sys_trialterm_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="合同期限" prop="eeContractTerm">
        <el-select filterable clearable  v-model="queryParams.eeContractTerm" :placeholder="$t('btn.select')+'合同期限'">
          <el-option v-for="item in  options.sys_contractterm_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="离职日期">
        <el-date-picker 
          v-model="dateRangeEeLeaveDate" 
          type="datetimerange" 
          range-separator="-"
          :start-placeholder="$t('btn.dateStart')" 
          :end-placeholder="$t('btn.dateEnd')" 
          :placeholder="$t('btn.select')+'离职日期'"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
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
        <el-button type="primary" v-hasPermi="['office:ehremployee:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['office:ehremployee:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['office:ehremployee:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['office:ehremployee:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['office:ehremployee:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="eeId" label="ID" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeId')"/>
      <el-table-column prop="eeName" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeName')"/>
      <el-table-column prop="eeNameUsed" label="曾用名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNameUsed')"/>
      <el-table-column prop="eeNickName" label="昵称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNickName')"/>
      <el-table-column prop="eeEnglishName" label="英文名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEnglishName')"/>
      <el-table-column prop="eeGender" label="性别" align="center" v-if="columns.showColumn('eeGender')">
        <template #default="scope">
          <dict-tag :options=" options.sys_user_sex " :value="scope.row.eeGender" />
        </template>
      </el-table-column>
      <el-table-column prop="eeBirthday" label="出生日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeBirthday')"/>
      <el-table-column prop="eeIdentityCard" label="身份证号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeIdentityCard')"/>
      <el-table-column prop="eeWedlock" label="婚姻状态" align="center" v-if="columns.showColumn('eeWedlock')">
        <template #default="scope">
          <dict-tag :options=" options.sys_wedlock_state " :value="scope.row.eeWedlock" />
        </template>
      </el-table-column>
      <el-table-column prop="eeNationId" label="民族" align="center" v-if="columns.showColumn('eeNationId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nation_list " :value="scope.row.eeNationId" />
        </template>
      </el-table-column>
      <el-table-column prop="eeNativePlace" label="籍贯" align="center" v-if="columns.showColumn('eeNativePlace')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.eeNativePlace" />
        </template>
      </el-table-column>
      <el-table-column prop="eePoliticId" label="政治面貌" align="center" v-if="columns.showColumn('eePoliticId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_politic_list " :value="scope.row.eePoliticId" />
        </template>
      </el-table-column>
      <el-table-column prop="eeEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEmail')"/>
      <el-table-column prop="eePhone" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePhone')"/>
      <el-table-column prop="eeCountry" label="国家/地区" align="center" v-if="columns.showColumn('eeCountry')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.eeCountry" />
        </template>
      </el-table-column>
      <el-table-column prop="eeProvince" label="省区" align="center" v-if="columns.showColumn('eeProvince')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.eeProvince" />
        </template>
      </el-table-column>
      <el-table-column prop="eeCity" label="市区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeCity')"/>
      <el-table-column prop="eeCounty" label="县区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeCounty')"/>
      <el-table-column prop="eeHomeAddress" label="家庭住址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeHomeAddress')"/>
      <el-table-column prop="eePostCode" label="邮编" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePostCode')"/>
      <el-table-column prop="eeHouseholdType" label="户口性质" align="center" v-if="columns.showColumn('eeHouseholdType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_household_type " :value="scope.row.eeHouseholdType" />
        </template>
      </el-table-column>
      <el-table-column prop="eeStayAddress" label="暂住地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeStayAddress')"/>
      <el-table-column prop="eeDepartmentId" label="部门" align="center" v-if="columns.showColumn('eeDepartmentId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.eeDepartmentId" />
        </template>
      </el-table-column>
      <el-table-column prop="eeTitlesId" label="职称" align="center" v-if="columns.showColumn('eeTitlesId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_titles_list " :value="scope.row.eeTitlesId" />
        </template>
      </el-table-column>
      <el-table-column prop="eePostId" label="岗位" align="center" v-if="columns.showColumn('eePostId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_post_level " :value="scope.row.eePostId" />
        </template>
      </el-table-column>
      <el-table-column prop="eePostLevel" label="等级" align="center" v-if="columns.showColumn('eePostLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_post_level " :value="scope.row.eePostLevel" />
        </template>
      </el-table-column>
      <el-table-column prop="eeDutyName" label="职务" align="center" v-if="columns.showColumn('eeDutyName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.eeDutyName" />
        </template>
      </el-table-column>
      <el-table-column prop="eeRecruited" label="招聘来源" align="center" v-if="columns.showColumn('eeRecruited')">
        <template #default="scope">
          <dict-tag :options=" options.sys_recruited_list " :value="scope.row.eeRecruited" />
        </template>
      </el-table-column>
      <el-table-column prop="eeEngageForm" label="聘用形式" align="center" v-if="columns.showColumn('eeEngageForm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.eeEngageForm" />
        </template>
      </el-table-column>
      <el-table-column prop="eeTiptopDegrEe" label="学历" align="center" v-if="columns.showColumn('eeTiptopDegrEe')">
        <template #default="scope">
          <dict-tag :options=" options.sys_level_education " :value="scope.row.eeTiptopDegrEe" />
        </template>
      </el-table-column>
      <el-table-column prop="eeSpecialty" label="专业" align="center" v-if="columns.showColumn('eeSpecialty')">
        <template #default="scope">
          <dict-tag :options=" options.sys_specialty_list " :value="scope.row.eeSpecialty" />
        </template>
      </el-table-column>
      <el-table-column prop="eeSchool" label="院校" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeSchool')"/>
      <el-table-column prop="eeWorkID" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeWorkID')"/>
      <el-table-column prop="eeBeginDate" label="入职日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeBeginDate')"/>
      <el-table-column prop="eeWorkState" label="在职状态" align="center" v-if="columns.showColumn('eeWorkState')">
        <template #default="scope">
          <dict-tag :options=" options.sys_workstate_list " :value="scope.row.eeWorkState" />
        </template>
      </el-table-column>
      <el-table-column prop="eeProbation" label="试用期" align="center" v-if="columns.showColumn('eeProbation')">
        <template #default="scope">
          <dict-tag :options=" options.sys_trialterm_list " :value="scope.row.eeProbation" />
        </template>
      </el-table-column>
      <el-table-column prop="eeContractTerm" label="合同期限" align="center" v-if="columns.showColumn('eeContractTerm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_contractterm_list " :value="scope.row.eeContractTerm" />
        </template>
      </el-table-column>
      <el-table-column prop="eeConversionTime" label="转正日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeConversionTime')"/>
      <el-table-column prop="eeLeaveDate" label="离职日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeLeaveDate')"/>
      <el-table-column prop="eeBeginContract" label="合同起始日" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeBeginContract')"/>
      <el-table-column prop="eeBndContract" label="合同终止晶" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeBndContract')"/>
      <el-table-column prop="eeWorkAge" label="工龄" align="center" v-if="columns.showColumn('eeWorkAge')"/>
      <el-table-column prop="eeAvatar" label="头像" align="center" v-if="columns.showColumn('eeAvatar')">
        <template #default="scope">
          <el-image preview-teleported :hide-on-click-modal="true" lazy class="table-td-thumb" fit="contain" :src="scope.row.eeAvatar" :preview-src-list="[scope.row.eeAvatar]">
            <div><el-icon :size="15"><document /></el-icon></div>
          </el-image>
        </template>
      </el-table-column>
      <el-table-column prop="eeQualificationAffix" label="学历附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeQualificationAffix')"/>
      <el-table-column prop="eeTitleAffix" label="职称附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeTitleAffix')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['office:ehremployee:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['office:ehremployee:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改人事信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="eeId">
              <el-input clearable v-model="form.eeId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="姓名" prop="eeName">
              <el-input clearable v-model="form.eeName" :placeholder="$t('btn.enter')+'姓名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="曾用名" prop="eeNameUsed">
              <el-input clearable v-model="form.eeNameUsed" :placeholder="$t('btn.enter')+'曾用名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="昵称" prop="eeNickName">
              <el-input clearable v-model="form.eeNickName" :placeholder="$t('btn.enter')+'昵称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="英文名" prop="eeEnglishName">
              <el-input clearable v-model="form.eeEnglishName" :placeholder="$t('btn.enter')+'英文名'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="性别" prop="eeGender">
              <el-select v-model="form.eeGender" filterable clearable  :placeholder="$t('btn.select')+'性别'">
                <el-option v-for="item in  options.sys_user_sex " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出生日期" prop="eeBirthday">
              <el-date-picker clearable v-model="form.eeBirthday" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="身份证号" prop="eeIdentityCard">
              <el-input clearable v-model="form.eeIdentityCard" :placeholder="$t('btn.enter')+'身份证号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="婚姻状态" prop="eeWedlock">
              <el-select v-model="form.eeWedlock" filterable clearable  :placeholder="$t('btn.select')+'婚姻状态'">
                <el-option v-for="item in  options.sys_wedlock_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="民族" prop="eeNationId">
              <el-select v-model="form.eeNationId" filterable clearable  :placeholder="$t('btn.select')+'民族'">
                <el-option v-for="item in  options.sys_nation_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="籍贯" prop="eeNativePlace">
              <el-select v-model="form.eeNativePlace" filterable clearable  :placeholder="$t('btn.select')+'籍贯'">
                <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="政治面貌" prop="eePoliticId">
              <el-select v-model="form.eePoliticId" filterable clearable  :placeholder="$t('btn.select')+'政治面貌'">
                <el-option v-for="item in  options.sys_politic_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="eeEmail">
              <el-input clearable v-model="form.eeEmail" :placeholder="$t('btn.enter')+'邮件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="eePhone">
              <el-input clearable v-model="form.eePhone" :placeholder="$t('btn.enter')+'电话'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家/地区" prop="eeCountry">
              <el-select v-model="form.eeCountry" filterable clearable  :placeholder="$t('btn.select')+'国家/地区'">
                <el-option v-for="item in  options.sys_country_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="省区" prop="eeProvince">
              <el-select v-model="form.eeProvince" filterable clearable  :placeholder="$t('btn.select')+'省区'">
                <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="市区" prop="eeCity">
              <el-input clearable v-model="form.eeCity" :placeholder="$t('btn.enter')+'市区'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="县区" prop="eeCounty">
              <el-input clearable v-model="form.eeCounty" :placeholder="$t('btn.enter')+'县区'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="家庭住址" prop="eeHomeAddress">
              <el-input clearable v-model="form.eeHomeAddress" :placeholder="$t('btn.enter')+'家庭住址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮编" prop="eePostCode">
              <el-input clearable v-model="form.eePostCode" :placeholder="$t('btn.enter')+'邮编'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="户口性质" prop="eeHouseholdType">
              <el-select v-model="form.eeHouseholdType" filterable clearable  :placeholder="$t('btn.select')+'户口性质'">
                <el-option v-for="item in  options.sys_household_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="暂住地址" prop="eeStayAddress">
              <el-input clearable v-model="form.eeStayAddress" :placeholder="$t('btn.enter')+'暂住地址'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="部门" prop="eeDepartmentId">
              <el-select v-model="form.eeDepartmentId" filterable clearable  :placeholder="$t('btn.select')+'部门'">
                <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="职称" prop="eeTitlesId">
              <el-select v-model="form.eeTitlesId" filterable clearable  :placeholder="$t('btn.select')+'职称'">
                <el-option v-for="item in  options.sys_titles_list " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="岗位" prop="eePostId">
              <el-select v-model="form.eePostId" filterable clearable  :placeholder="$t('btn.select')+'岗位'">
                <el-option v-for="item in  options.sys_post_level " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="等级" prop="eePostLevel">
              <el-select v-model="form.eePostLevel" filterable clearable  :placeholder="$t('btn.select')+'等级'">
                <el-option v-for="item in  options.sys_post_level " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="职务" prop="eeDutyName">
              <el-select v-model="form.eeDutyName" filterable clearable  :placeholder="$t('btn.select')+'职务'">
                <el-option v-for="item in  options.sql_posts_list " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="招聘来源" prop="eeRecruited">
              <el-select v-model="form.eeRecruited" filterable clearable  :placeholder="$t('btn.select')+'招聘来源'">
                <el-option v-for="item in  options.sys_recruited_list " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="聘用形式" prop="eeEngageForm">
              <el-select v-model="form.eeEngageForm" filterable clearable  :placeholder="$t('btn.select')+'聘用形式'">
                <el-option v-for="item in  options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="学历" prop="eeTiptopDegrEe">
              <el-select v-model="form.eeTiptopDegrEe" filterable clearable  :placeholder="$t('btn.select')+'学历'">
                <el-option v-for="item in  options.sys_level_education " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="专业" prop="eeSpecialty">
              <el-select v-model="form.eeSpecialty" filterable clearable  :placeholder="$t('btn.select')+'专业'">
                <el-option v-for="item in  options.sys_specialty_list " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="院校" prop="eeSchool">
              <el-input clearable v-model="form.eeSchool" :placeholder="$t('btn.enter')+'院校'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工号" prop="eeWorkID">
              <el-input clearable v-model="form.eeWorkID" :placeholder="$t('btn.enter')+'工号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入职日期" prop="eeBeginDate">
              <el-date-picker clearable v-model="form.eeBeginDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="在职状态" prop="eeWorkState">
              <el-radio-group v-model="form.eeWorkState">
                <el-radio v-for="item in  options.sys_workstate_list " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="试用期" prop="eeProbation">
              <el-select v-model="form.eeProbation" filterable clearable  :placeholder="$t('btn.select')+'试用期'">
                <el-option v-for="item in  options.sys_trialterm_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同期限" prop="eeContractTerm">
              <el-select v-model="form.eeContractTerm" filterable clearable  :placeholder="$t('btn.select')+'合同期限'">
                <el-option v-for="item in  options.sys_contractterm_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转正日期" prop="eeConversionTime">
              <el-date-picker clearable v-model="form.eeConversionTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离职日期" prop="eeLeaveDate">
              <el-date-picker clearable v-model="form.eeLeaveDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同起始日" prop="eeBeginContract">
              <el-date-picker clearable v-model="form.eeBeginContract" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同终止晶" prop="eeBndContract">
              <el-date-picker clearable v-model="form.eeBndContract" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="工龄" prop="eeWorkAge">
              <el-input clearable v-model="form.eeWorkAge" :placeholder="$t('btn.enter')+'工龄'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="头像" prop="eeAvatar">
              <UploadImage clearable v-model="form.eeAvatar" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="学历附件" prop="eeQualificationAffix">
              <UploadFile  clearable v-model="form.eeQualificationAffix" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="职称附件" prop="eeTitleAffix">
              <UploadFile  clearable v-model="form.eeTitleAffix" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF01" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'UDF01'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF02" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'UDF02'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF03" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'UDF03'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF04" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'UDF04'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF05" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'UDF05'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF06" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'UDF06'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF51" prop="uDF51">
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'UDF51'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF52" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'UDF52'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF53" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'UDF53'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF54" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'UDF54'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF55" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'UDF55'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="UDF56" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'UDF56'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IsDeleted" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in  options.isDeletedOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="ReMark" prop="reMark">
              <el-input clearable type="textarea" v-model="form.reMark" :placeholder="$t('btn.enter')+'ReMark'"/>
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

<script setup name="officeehremployee">
// 引入 officeehremployee操作方法
import { listOfficeEhrEmployee, addOfficeEhrEmployee, delOfficeEhrEmployee, updateOfficeEhrEmployee, getOfficeEhrEmployee, 
 
 } 
from '@/api/office/officeehremployee.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中eeId数组数组
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
  eeName: undefined,
  eeGender: undefined,
  eeBirthday: undefined,
  eeIdentityCard: undefined,
  eeWedlock: undefined,
  eeNationId: undefined,
  eeNativePlace: undefined,
  eePoliticId: undefined,
  eeCountry: undefined,
  eeProvince: undefined,
  eeHouseholdType: undefined,
  eeDepartmentId: undefined,
  eeTitlesId: undefined,
  eePostId: undefined,
  eePostLevel: undefined,
  eeDutyName: undefined,
  eeRecruited: undefined,
  eeEngageForm: undefined,
  eeTiptopDegrEe: undefined,
  eeSpecialty: undefined,
  eeWorkID: undefined,
  eeWorkState: undefined,
  eeProbation: undefined,
  eeContractTerm: undefined,
  eeLeaveDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'eeId', label: 'ID' },
  { visible: true, prop: 'eeName', label: '姓名' },
  { visible: true, prop: 'eeNameUsed', label: '曾用名' },
  { visible: true, prop: 'eeNickName', label: '昵称' },
  { visible: true, prop: 'eeEnglishName', label: '英文名' },
  { visible: true, prop: 'eeGender', label: '性别' },
  { visible: true, prop: 'eeBirthday', label: '出生日期' },
  { visible: true, prop: 'eeIdentityCard', label: '身份证号' },
  { visible: false, prop: 'eeWedlock', label: '婚姻状态' },
  { visible: false, prop: 'eeNationId', label: '民族' },
  { visible: false, prop: 'eeNativePlace', label: '籍贯' },
  { visible: false, prop: 'eePoliticId', label: '政治面貌' },
  { visible: false, prop: 'eeEmail', label: '邮件' },
  { visible: false, prop: 'eePhone', label: '电话' },
  { visible: false, prop: 'eeCountry', label: '国家/地区' },
  { visible: false, prop: 'eeProvince', label: '省区' },
  { visible: false, prop: 'eeCity', label: '市区' },
  { visible: false, prop: 'eeCounty', label: '县区' },
  { visible: false, prop: 'eeHomeAddress', label: '家庭住址' },
  { visible: false, prop: 'eePostCode', label: '邮编' },
  { visible: false, prop: 'eeHouseholdType', label: '户口性质' },
  { visible: false, prop: 'eeStayAddress', label: '暂住地址' },
  { visible: false, prop: 'eeDepartmentId', label: '部门' },
  { visible: false, prop: 'eeTitlesId', label: '职称' },
  { visible: false, prop: 'eePostId', label: '岗位' },
  { visible: false, prop: 'eePostLevel', label: '等级' },
  { visible: false, prop: 'eeDutyName', label: '职务' },
  { visible: false, prop: 'eeRecruited', label: '招聘来源' },
  { visible: false, prop: 'eeEngageForm', label: '聘用形式' },
  { visible: false, prop: 'eeTiptopDegrEe', label: '学历' },
  { visible: false, prop: 'eeSpecialty', label: '专业' },
  { visible: false, prop: 'eeSchool', label: '院校' },
  { visible: false, prop: 'eeWorkID', label: '工号' },
  { visible: false, prop: 'eeBeginDate', label: '入职日期' },
  { visible: false, prop: 'eeWorkState', label: '在职状态' },
  { visible: false, prop: 'eeProbation', label: '试用期' },
  { visible: false, prop: 'eeContractTerm', label: '合同期限' },
  { visible: false, prop: 'eeConversionTime', label: '转正日期' },
  { visible: false, prop: 'eeLeaveDate', label: '离职日期' },
  { visible: false, prop: 'eeBeginContract', label: '合同起始日' },
  { visible: false, prop: 'eeBndContract', label: '合同终止晶' },
  { visible: false, prop: 'eeWorkAge', label: '工龄' },
  { visible: false, prop: 'eeAvatar', label: '头像' },
  { visible: false, prop: 'eeQualificationAffix', label: '学历附件' },
  { visible: false, prop: 'eeTitleAffix', label: '职称附件' },
])
  // 总条数
const total = ref(0)
  // 人事信息表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 出生日期时间范围
const dateRangeEeBirthday = ref([])

// 离职日期时间范围
const dateRangeEeLeaveDate = ref([])


var dictParams = [
  { dictType: "sys_user_sex" },
  { dictType: "sys_wedlock_state" },
  { dictType: "sys_nation_list" },
  { dictType: "sys_employ_term" },
  { dictType: "sys_politic_list" },
  { dictType: "sys_country_list" },
  { dictType: "sys_employ_term" },
  { dictType: "sys_household_type" },
  { dictType: "sql_dept_list" },
  { dictType: "sys_titles_list" },
  { dictType: "sys_post_level" },
  { dictType: "sys_post_level" },
  { dictType: "sql_posts_list" },
  { dictType: "sys_recruited_list" },
  { dictType: "sys_employ_term" },
  { dictType: "sys_level_education" },
  { dictType: "sys_specialty_list" },
  { dictType: "sys_workstate_list" },
  { dictType: "sys_trialterm_list" },
  { dictType: "sys_contractterm_list" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取人事信息表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEeBirthday.value, 'EeBirthday');
  proxy.addDateRange(queryParams, dateRangeEeLeaveDate.value, 'EeLeaveDate');
  loading.value = true
  listOfficeEhrEmployee(queryParams).then(res => {
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
  // 出生日期时间范围
  dateRangeEeBirthday.value = []
  // 离职日期时间范围
  dateRangeEeLeaveDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.eeId);
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
    eeId: [{ required: true, message: "ID"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeName: [{ required: true, message: "姓名"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeGender: [{ required: true, message: "性别"+proxy.$t('btn.empty'), trigger: "change" }],
    eeBirthday: [{ required: true, message: "出生日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeIdentityCard: [{ required: true, message: "身份证号"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeWedlock: [{ required: true, message: "婚姻状态"+proxy.$t('btn.empty'), trigger: "change" }],
    eeNationId: [{ required: true, message: "民族"+proxy.$t('btn.empty'), trigger: "change" }],
    eeNativePlace: [{ required: true, message: "籍贯"+proxy.$t('btn.empty'), trigger: "change" }],
    eePoliticId: [{ required: true, message: "政治面貌"+proxy.$t('btn.empty'), trigger: "change" }],
    eeCountry: [{ required: true, message: "国家/地区"+proxy.$t('btn.empty'), trigger: "change" }],
    eeProvince: [{ required: true, message: "省区"+proxy.$t('btn.empty'), trigger: "change" }],
    eeCity: [{ required: true, message: "市区"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeCounty: [{ required: true, message: "县区"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeHomeAddress: [{ required: true, message: "家庭住址"+proxy.$t('btn.empty'), trigger: "blur" }],
    eeDepartmentId: [{ required: true, message: "部门"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    eeTitlesId: [{ required: true, message: "职称"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    eePostId: [{ required: true, message: "岗位"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    eePostLevel: [{ required: true, message: "等级"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    eeDutyName: [{ required: true, message: "职务"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    eeRecruited: [{ required: true, message: "招聘来源"+proxy.$t('btn.empty'), trigger: "change", type: "number" }],
  },
  options: {
    // 性别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_user_sex: [],
    // 婚姻状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_wedlock_state: [],
    // 民族 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_nation_list: [],
    // 籍贯 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_employ_term: [],
    // 政治面貌 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_politic_list: [],
    // 国家/地区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_country_list: [],
    // 省区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_employ_term: [],
    // 户口性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_household_type: [],
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_dept_list: [],
    // 职称 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_titles_list: [],
    // 岗位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_post_level: [],
    // 等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_post_level: [],
    // 职务 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_posts_list: [],
    // 招聘来源 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_recruited_list: [],
    // 聘用形式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_employ_term: [],
    // 学历 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_level_education: [],
    // 专业 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_specialty_list: [],
    // 在职状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_workstate_list: [],
    // 试用期 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_trialterm_list: [],
    // 合同期限 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_contractterm_list: [],
    // IsDeleted 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    eeId: undefined,
    eeName: undefined,
    eeNameUsed: undefined,
    eeNickName: undefined,
    eeEnglishName: undefined,
    eeGender: undefined,
    eeBirthday: undefined,
    eeIdentityCard: undefined,
    eeWedlock: undefined,
    eeNationId: undefined,
    eeNativePlace: undefined,
    eePoliticId: undefined,
    eeEmail: undefined,
    eePhone: undefined,
    eeCountry: undefined,
    eeProvince: undefined,
    eeCity: undefined,
    eeCounty: undefined,
    eeHomeAddress: undefined,
    eePostCode: undefined,
    eeHouseholdType: undefined,
    eeStayAddress: undefined,
    eeDepartmentId: undefined,
    eeTitlesId: undefined,
    eePostId: undefined,
    eePostLevel: undefined,
    eeDutyName: undefined,
    eeRecruited: undefined,
    eeEngageForm: undefined,
    eeTiptopDegrEe: undefined,
    eeSpecialty: undefined,
    eeSchool: undefined,
    eeWorkID: undefined,
    eeBeginDate: undefined,
    eeWorkState: undefined,
    eeProbation: undefined,
    eeContractTerm: undefined,
    eeConversionTime: undefined,
    eeLeaveDate: undefined,
    eeBeginContract: undefined,
    eeBndContract: undefined,
    eeWorkAge: undefined,
    eeAvatar: undefined,
    eeQualificationAffix: undefined,
    eeTitleAffix: undefined,
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
  const id = row.eeId || ids.value
  getOfficeEhrEmployee(id).then((res) => {
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
      if (form.value.eeId != undefined && opertype.value === 2) {
        updateOfficeEhrEmployee(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addOfficeEhrEmployee(form.value).then((res) => {
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
  const Ids = row.eeId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delOfficeEhrEmployee(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"人事信息", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Office/OfficeEhrEmployee/export', { ...queryParams })
    })
}

handleQuery()
</script>