<!--
 * @Descripttion: (主设变/pp_ec_master)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-12)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-12)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="发行日">
        <el-date-picker v-model="dateRangeEmEcIssueDate" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :placeholder="$t('btn.select')+'发行日'" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="emEcNo">
        <el-input clearable v-model="queryParams.emEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
      </el-form-item>
      <el-form-item label="状态" prop="emEcStatus">
        <el-select filterable clearable v-model="queryParams.emEcStatus" :placeholder="$t('btn.select')+'状态'">
          <el-option v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="担当" prop="emEcAssigned">
        <el-select filterable clearable v-model="queryParams.emEcAssigned" :placeholder="$t('btn.select')+'担当'">
          <el-option v-for="item in  options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="管理区分" prop="emEcManageCategory">
        <el-select filterable clearable v-model="queryParams.emEcManageCategory" :placeholder="$t('btn.select')+'管理区分'">
          <el-option v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['la:ppecmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['la:ppecmaster:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['la:ppecmaster:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['la:ppecmaster:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['la:ppecmaster:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="emId" label="ID" align="center" v-if="columns.showColumn('emId')" />
      <el-table-column prop="emEcIssueDate" label="发行日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcIssueDate')" />
      <el-table-column prop="emEcNo" label="设变No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcNo')" />
      <el-table-column prop="emEcDoc" label="关联文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcDoc')">
        <template #default="scope">
          <a :href="scope.row.emEcDoc" target="_blank" class="buttonText">{{scope.row.emEcDoc}}</a>
        </template>
      </el-table-column>

      <el-table-column prop="emEcStatus" label="状态" align="center" v-if="columns.showColumn('emEcStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.emEcStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcTitle" label="标题" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcTitle')" />
      <el-table-column prop="emEcContent" label="内容" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcContent')" />
      <el-table-column prop="emEcAssigned" label="担当" align="center" v-if="columns.showColumn('emEcAssigned')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.emEcAssigned" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLossAmount" label="损失金额" align="center" v-if="columns.showColumn('emEcLossAmount')" />
      <el-table-column prop="emEcManageCategory" label="管理区分" align="center"
        v-if="columns.showColumn('emEcManageCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.emEcManageCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLiaisonNo" label="联络No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcLiaisonNo')" />
      <el-table-column prop="emEcLiaisonDoc" label="联络文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcLiaisonDoc')">
        <template #default="scope">
          <a :href="scope.row.emEcLiaisonDoc" target="_blank" class="buttonText">{{scope.row.emEcLiaisonDoc}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="emEcEppLiaisonNo" label="EppNo." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcEppLiaisonNo')" />
      <el-table-column prop="emEcEppLiaisonDoc" label="Epp文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcEppLiaisonDoc')">
        <template #default="scope">
          <a :href="scope.row.emEcEppLiaisonDoc" target="_blank" class="buttonText">{{scope.row.emEcEppLiaisonDoc}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="emEcFppLiaisonNo" label="FppNo." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcFppLiaisonNo')" />
      <el-table-column prop="emEcFppLiaisonDoc" label="Fpp文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcFppLiaisonDoc')">
        <template #default="scope">
          <a :href="scope.row.emEcFppLiaisonDoc" target="_blank" class="buttonText">{{scope.row.emEcFppLiaisonDoc}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="emEcExternalNo" label="外部No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcExternalNo')" />
      <el-table-column prop="emEcExternalDoc" label="外部文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcExternalDoc')">
        <template #default="scope">
          <a :href="scope.row.emEcExternalDoc" target="_blank" class="buttonText">{{scope.row.emEcExternalDoc}}</a>
        </template>
      </el-table-column>
      <el-table-column prop="emEcImpDept" label="实施部门" align="center" v-if="columns.showColumn('emEcImpDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.emEcImpDept" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcEntryDate" label="输入日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('emEcEntryDate')" />
      <el-table-column prop="isModifySop" label="SOP变更否" align="center" v-if="columns.showColumn('isModifySop')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.isModifySop" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['la:ppecmaster:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['la:ppecmaster:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改主设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <!-- <el-col :lg="12">
            <el-form-item label="ID" prop="emId">
              <el-input-number clearable v-model.number="form.emId" controls-position="right"
                :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col> -->


          <el-col :lg="12">
            <el-form-item label="发行日" prop="emEcIssueDate">
              <el-date-picker clearable v-model="form.emEcIssueDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="emEcNo">
              <el-input clearable v-model="form.emEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关联文件" prop="emEcDoc">
              <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload" @click="emEcDochandleAdd">
                {{ $t('btn.upload') }}
              </el-button>
              <el-input clearable v-model="form.emEcDoc" :placeholder="$t('btn.enter')+'关联文件'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="状态" prop="emEcStatus">
              <el-radio-group v-model="form.emEcStatus">
                <el-radio v-for="item in  options.sys_ec_status " :key="item.dictValue"
                  :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="emEcTitle">
              <el-input clearable v-model="form.emEcTitle" :placeholder="$t('btn.enter')+'标题'" />
            </el-form-item>
          </el-col>



          <el-col :lg="12">
            <el-form-item label="损失金额" prop="emEcLossAmount">
              <el-input clearable v-model="form.emEcLossAmount" :placeholder="$t('btn.enter')+'损失金额'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="担当" prop="emEcAssigned">
              <el-select v-model="form.emEcAssigned" filterable clearable :placeholder="$t('btn.select')+'担当'">
                <el-option v-for="item in  options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="管理区分" prop="emEcManageCategory">
              <el-select v-model="form.emEcManageCategory" filterable clearable :placeholder="$t('btn.select')+'管理区分'">
                <el-option v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel"
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="8">
            <el-form-item label="SOP变更否" prop="isModifySop">
              <el-radio-group v-model="form.isModifySop">
                <el-radio v-for="item in  options.sys_sop_yn " :key="parseInt(item.dictValue)"
                  :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络No." prop="emEcLiaisonNo">
              <el-input clearable v-model="form.emEcLiaisonNo" :placeholder="$t('btn.enter')+'联络No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络文件" prop="emEcLiaisonDoc">
              <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload"
                @click="emEcLiaisonDochandleAdd">
                {{ $t('btn.upload') }}
              </el-button>
              <el-input clearable v-model="form.emEcLiaisonDoc" :placeholder="$t('btn.enter')+'联络文件'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo." prop="emEcEppLiaisonNo">
              <el-input clearable v-model="form.emEcEppLiaisonNo" :placeholder="$t('btn.enter')+'EppNo.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Epp文件" prop="emEcEppLiaisonDoc">
              <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload"
                @click="emEcEppLiaisonDochandleAdd">
                {{ $t('btn.upload') }}
              </el-button>
              <el-input clearable v-model="form.emEcEppLiaisonDoc" :placeholder="$t('btn.enter')+'Epp文件'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo." prop="emEcFppLiaisonNo">
              <el-input clearable v-model="form.emEcFppLiaisonNo" :placeholder="$t('btn.enter')+'FppNo.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fpp文件" prop="emEcFppLiaisonDoc">
              <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload"
                @click="emEcFppLiaisonDochandleAdd">
                {{ $t('btn.upload') }}
              </el-button>
              <el-input clearable v-model="form.emEcFppLiaisonDoc" :placeholder="$t('btn.enter')+'Fpp文件'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No." prop="emEcExternalNo">
              <el-input clearable v-model="form.emEcExternalNo" :placeholder="$t('btn.enter')+'外部No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部文件" prop="emEcExternalDoc">
              <el-button type="primary" v-hasPermi="['tool:file:add']" plain icon="upload"
                @click="emEcExternalDochandleAdd">
                {{ $t('btn.upload') }}
              </el-button>
              <el-input clearable v-model="form.emEcExternalDoc" :placeholder="$t('btn.enter')+'外部文件'" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实施部门" prop="emEcImpDept">
              <el-select v-model="form.emEcImpDept" filterable clearable :placeholder="$t('btn.select')+'实施部门'">
                <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="emEcEntryDate">
              <el-date-picker clearable v-model="form.emEcEntryDate" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="内容" prop="emEcContent">
              <el-input clearable type="textarea" v-model="form.emEcContent" :placeholder="$t('btn.enter')+'内容'" />
            </el-form-item>
          </el-col>
          <!-- <el-col :lg="12">
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
          </el-col> -->
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
    <!-- ec关联文件添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="emEcDocOpen" width="400px" draggable>
      <el-form ref="emEcDocformRef" :model="emEcDocform" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <UploadFile ref="emEcDocuploadRef" v-model="emEcDocform.accessUrl" :fileType="['pdf']" :fileSize="10"
              :drag="false" :data="emEcDocuploadData" :autoUpload="false" @success="emEcDocUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="emEcDoccancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="emEcDocsubmitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

    <!-- ec关联文件添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="emEcLiaisonDocOpen" width="400px" draggable>
      <el-form ref="emEcLiaisonDocformRef" :model="emEcLiaisonDocform" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <UploadFile ref="emEcLiaisonDocuploadRef" v-model="emEcLiaisonDocform.accessUrl" :fileType="['pdf']"
              :fileSize="10" :drag="false" :data="emEcLiaisonDocuploadData" :autoUpload="false"
              @success="emEcLiaisonDocUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="emEcLiaisonDoccancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="emEcLiaisonDocsubmitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>
    <!-- ec关联文件添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="emEcEppLiaisonDocOpen" width="400px" draggable>
      <el-form ref="emEcEppLiaisonDocformRef" :model="emEcEppLiaisonDocform" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <UploadFile ref="emEcEppLiaisonDocuploadRef" v-model="emEcEppLiaisonDocform.accessUrl" :fileType="['pdf']"
              :fileSize="10" :drag="false" :data="emEcEppLiaisonDocuploadData" :autoUpload="false"
              @success="emEcEppLiaisonDocUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="emEcEppLiaisonDoccancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="emEcEppLiaisonDocsubmitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>
    <!-- ec关联文件添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="emEcFppLiaisonDocOpen" width="400px" draggable>
      <el-form ref="emEcFppLiaisonDocformRef" :model="emEcFppLiaisonDocform" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <UploadFile ref="emEcFppLiaisonDocuploadRef" v-model="emEcFppLiaisonDocform.accessUrl" :fileType="['pdf']"
              :fileSize="10" :drag="false" :data="emEcFppLiaisonDocuploadData" :autoUpload="false"
              @success="emEcFppLiaisonDocUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="emEcFppLiaisonDoccancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="emEcFppLiaisonDocsubmitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>
    <!-- ec关联文件添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="emEcExternalDocOpen" width="400px" draggable>
      <el-form ref="emEcExternalDocformRef" :model="emEcExternalDocform" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <UploadFile ref="emEcExternalDocuploadRef" v-model="emEcExternalDocform.accessUrl" :fileType="['pdf']"
              :fileSize="10" :drag="false" :data="emEcExternalDocuploadData" :autoUpload="false"
              @success="emEcExternalDocUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="emEcExternalDoccancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="emEcExternalDocsubmitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ppecmaster">
  // 引入 ppecmaster操作方法
  import {
    listPpEcMaster, addPpEcMaster, delPpEcMaster, updatePpEcMaster, getPpEcMaster,

  }
    from '@/api/production/ppecmaster.js'
  const emEcDocOpen = ref(false)
  const emEcDocformRef = ref(null)
  const emEcDocform = ref({})
  const emEcDocuploadRef = ref(null)
  const emEcDocuploadData = ref({})
  // 上传成功方法
  function emEcDocUploadSuccess(emEcDocfilelist) {
    // emEcLiaisonDocurl.value = filelist

    form.value.emEcDoc = emEcDocfilelist.split(",")[0]
  }
  // 手动上传
  // 取消按钮
  function emEcDoccancel() {
    emEcDocOpen.value = false
    //reset()
  }
  /** 新增按钮操作 */
  function emEcDochandleAdd() {
    //reset()
    emEcDocOpen.value = true
    //title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }
  function emEcDocsubmitUpload() {
    proxy.$refs['emEcDocformRef'].validate((valid) => {
      if (valid) {
        emEcDocuploadData.value = {
          fileDir: 'uploads\\ec\\docs',
          fileName: 1,
          storeType: 1,
          fileNameType: 1
        }
        proxy.$refs.emEcDocuploadRef.submitUpload()

      }
    })
    emEcDocOpen.value = false
    // form.value.emEcDoc = emEcDocform.accessUrl
    //proxy.$refs.emEcDocuploadRef.clearFiles()
  }

  const emEcLiaisonDocOpen = ref(false)
  const emEcLiaisonDocformRef = ref(null)
  const emEcLiaisonDocform = ref({})
  const emEcLiaisonDocuploadRef = ref(null)
  const emEcLiaisonDocuploadData = ref({})

  // 上传成功方法
  function emEcLiaisonDocUploadSuccess(emEcLiaisonDocfilelist) {
    //emEcLiaisonDocurl.value = filelist

    form.value.emEcLiaisonDoc = emEcLiaisonDocfilelist.split(",")[0]
  }
  // 手动上传
  // 取消按钮
  function emEcLiaisonDoccancel() {
    emEcLiaisonDocOpen.value = false
    //reset()
  }
  /** 新增按钮操作 */
  function emEcLiaisonDochandleAdd() {
    //reset()
    emEcLiaisonDocOpen.value = true
    //title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }

  function emEcLiaisonDocsubmitUpload() {
    proxy.$refs['emEcLiaisonDocformRef'].validate((valid) => {
      if (valid) {
        emEcLiaisonDocuploadData.value = {
          fileDir: 'uploads\\ec\\docs',
          fileName: 1,
          storeType: 1,
          fileNameType: 1
        }
        proxy.$refs.emEcLiaisonDocuploadRef.submitUpload()

      }

    })

    //form.value.emEcLiaisonDoc = "sss" + emEcLiaisonDocform.accessUrl
    //emEcLiaisonDocurl.value = emEcLiaisonDocform.accessUrl
    //proxy.$refs.emEcLiaisonDocuploadRef.clearFiles()
    emEcLiaisonDocOpen.value = false

    //form.value.emEcDoc = emEcLiaisonDocform.accessUrl

  }
  const emEcEppLiaisonDocOpen = ref(false)
  const emEcEppLiaisonDocformRef = ref(null)
  const emEcEppLiaisonDocform = ref({})
  const emEcEppLiaisonDocuploadRef = ref(null)
  const emEcEppLiaisonDocuploadData = ref({})

  // 上传成功方法
  function emEcEppLiaisonDocUploadSuccess(emEcEppLiaisonDocfilelist) {
    //emEcEppLiaisonDocurl.value = filelist

    form.value.emEcEppLiaisonDoc = emEcEppLiaisonDocfilelist.split(",")[0]
  }
  // 手动上传
  // 取消按钮
  function emEcEppLiaisonDoccancel() {
    emEcEppLiaisonDocOpen.value = false
    //reset()
  }
  /** 新增按钮操作 */
  function emEcEppLiaisonDochandleAdd() {
    //reset()
    emEcEppLiaisonDocOpen.value = true
    //title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }

  function emEcEppLiaisonDocsubmitUpload() {
    proxy.$refs['emEcEppLiaisonDocformRef'].validate((valid) => {
      if (valid) {
        emEcEppLiaisonDocuploadData.value = {
          fileDir: 'uploads\\ec\\docs',
          fileName: 1,
          storeType: 1,
          fileNameType: 1
        }
        proxy.$refs.emEcEppLiaisonDocuploadRef.submitUpload()

      }

    })

    //form.value.emEcEppLiaisonDoc = "sss" + emEcEppLiaisonDocform.accessUrl
    //emEcEppLiaisonDocurl.value = emEcEppLiaisonDocform.accessUrl
    //proxy.$refs.emEcEppLiaisonDocuploadRef.clearFiles()
    emEcEppLiaisonDocOpen.value = false

    //form.value.emEcDoc = emEcEppLiaisonDocform.accessUrl

  }
  const emEcFppLiaisonDocOpen = ref(false)
  const emEcFppLiaisonDocformRef = ref(null)
  const emEcFppLiaisonDocform = ref({})
  const emEcFppLiaisonDocuploadRef = ref(null)
  const emEcFppLiaisonDocuploadData = ref({})

  // 上传成功方法
  function emEcFppLiaisonDocUploadSuccess(emEcFppLiaisonDocfilelist) {
    //emEcFppLiaisonDocurl.value = filelist

    form.value.emEcFppLiaisonDoc = emEcFppLiaisonDocfilelist.split(",")[0]
  }
  // 手动上传
  // 取消按钮
  function emEcFppLiaisonDoccancel() {
    emEcFppLiaisonDocOpen.value = false
    //reset()
  }
  /** 新增按钮操作 */
  function emEcFppLiaisonDochandleAdd() {
    //reset()
    emEcFppLiaisonDocOpen.value = true
    //title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }

  function emEcFppLiaisonDocsubmitUpload() {
    proxy.$refs['emEcFppLiaisonDocformRef'].validate((valid) => {
      if (valid) {
        emEcFppLiaisonDocuploadData.value = {
          fileDir: 'uploads\\ec\\docs',
          fileName: 1,
          storeType: 1,
          fileNameType: 1
        }
        proxy.$refs.emEcFppLiaisonDocuploadRef.submitUpload()

      }

    })

    //form.value.emEcFppLiaisonDoc = "sss" + emEcFppLiaisonDocform.accessUrl
    //emEcFppLiaisonDocurl.value = emEcFppLiaisonDocform.accessUrl
    //proxy.$refs.emEcFppLiaisonDocuploadRef.clearFiles()
    emEcFppLiaisonDocOpen.value = false

    //form.value.emEcDoc = emEcFppLiaisonDocform.accessUrl

  }
  const emEcExternalDocOpen = ref(false)
  const emEcExternalDocformRef = ref(null)
  const emEcExternalDocform = ref({})
  const emEcExternalDocuploadRef = ref(null)
  const emEcExternalDocuploadData = ref({})

  // 上传成功方法
  function emEcExternalDocUploadSuccess(emEcExternalDocfilelist) {
    //emEcExternalDocurl.value = filelist
    //form.value.emEcExternalDoc = emEcExternalDocform.accessUrl
    form.value.emEcExternalDoc = emEcExternalDocfilelist.split(",")[0]
  }
  // 手动上传
  // 取消按钮
  function emEcExternalDoccancel() {
    emEcExternalDocOpen.value = false
    //reset()
  }
  /** 新增按钮操作 */
  function emEcExternalDochandleAdd() {
    //reset()
    emEcExternalDocOpen.value = true
    //title.value = '上传文件'
    // form.value.storeType = queryParams.storeType
  }

  function emEcExternalDocsubmitUpload() {
    proxy.$refs['emEcExternalDocformRef'].validate((valid) => {
      if (valid) {
        emEcExternalDocuploadData.value = {
          fileDir: 'uploads\\ec\\docs',
          fileName: 1,
          storeType: 1,
          fileNameType: 1
        }
        proxy.$refs.emEcExternalDocuploadRef.submitUpload()

      }

    })

    //form.value.emEcExternalDoc = "sss" + emEcExternalDocform.accessUrl
    //emEcExternalDocurl.value = emEcExternalDocform.accessUrl
    //proxy.$refs.emEcExternalDocuploadRef.clearFiles()
    emEcExternalDocOpen.value = false

    //form.value.emEcDoc = emEcExternalDocform.accessUrl

  }
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中emId数组数组
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
    emEcIssueDate: undefined,
    emEcNo: undefined,
    emEcStatus: undefined,
    emEcAssigned: undefined,
    emEcManageCategory: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'emId', label: 'ID' },
    { visible: true, prop: 'emEcIssueDate', label: '发行日' },
    { visible: true, prop: 'emEcNo', label: '设变No.' },
    { visible: true, prop: 'emEcDoc', label: '关联文件' },
    { visible: true, prop: 'emEcStatus', label: '状态' },
    { visible: true, prop: 'emEcTitle', label: '标题' },
    { visible: true, prop: 'emEcContent', label: '内容' },
    { visible: true, prop: 'emEcAssigned', label: '担当' },
    { visible: false, prop: 'emEcLossAmount', label: '损失金额' },
    { visible: false, prop: 'emEcManageCategory', label: '管理区分' },
    { visible: false, prop: 'emEcLiaisonNo', label: '联络No.' },
    { visible: false, prop: 'emEcLiaisonDoc', label: '联络文件' },
    { visible: false, prop: 'emEcEppLiaisonNo', label: 'EppNo.' },
    { visible: false, prop: 'emEcEppLiaisonDoc', label: 'Epp文件' },
    { visible: false, prop: 'emEcFppLiaisonNo', label: 'FppNo.' },
    { visible: false, prop: 'emEcFppLiaisonDoc', label: 'Fpp文件' },
    { visible: false, prop: 'emEcExternalNo', label: '外部No.' },
    { visible: false, prop: 'emEcExternalDoc', label: '外部文件' },
    { visible: false, prop: 'emEcImpDept', label: '实施部门' },
    { visible: false, prop: 'emEcEntryDate', label: '输入日' },
    { visible: false, prop: 'isModifySop', label: 'SOP变更否' },
  ])
  // 总条数
  const total = ref(0)
  // 主设变表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 发行日时间范围
  const dateRangeEmEcIssueDate = ref([])


  var dictParams = [
    { dictType: "sys_ec_status" },
    { dictType: "sql_ec_group" },
    { dictType: "sys_ec_mgtype" },
    { dictType: "sql_dept_list" },
    { dictType: "sys_sop_yn" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取主设变表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeEmEcIssueDate.value, 'EmEcIssueDate');
    loading.value = true
    listPpEcMaster(queryParams).then(res => {
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
    // 发行日时间范围
    dateRangeEmEcIssueDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.emId);
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
      emEcIssueDate: [{ required: true, message: "发行日" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcNo: [{ required: true, message: "设变No." + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcStatus: [{ required: true, message: "状态" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcTitle: [{ required: true, message: "标题" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcContent: [{ required: true, message: "内容" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcAssigned: [{ required: true, message: "担当" + proxy.$t('btn.empty'), trigger: "change" }],
      emEcLossAmount: [{ required: true, message: "损失金额" + proxy.$t('btn.empty'), trigger: "blur" }],
      emEcManageCategory: [{ required: true, message: "管理区分" + proxy.$t('btn.empty'), trigger: "change", type: "number" }],
      emEcImpDept: [{ required: true, message: "实施部门" + proxy.$t('btn.empty'), trigger: "change" }],
      emEcEntryDate: [{ required: true, message: "输入日" + proxy.$t('btn.empty'), trigger: "blur" }],
      isModifySop: [{ required: true, message: "SOP变更否" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_status: [],
      // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_group: [],
      // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_mgtype: [],
      // 实施部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_dept_list: [],
      // SOP变更否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sop_yn: [],
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
      emEcIssueDate: new Date(),
      emEcNo: undefined,
      emEcDoc: undefined,
      emEcStatus: "Fixed",
      emEcTitle: undefined,
      emEcContent: undefined,
      emEcAssigned: undefined,
      emEcLossAmount: 0,
      emEcManageCategory: undefined,
      emEcLiaisonNo: undefined,
      emEcLiaisonDoc: undefined,
      emEcEppLiaisonNo: undefined,
      emEcEppLiaisonDoc: undefined,
      emEcFppLiaisonNo: undefined,
      emEcFppLiaisonDoc: undefined,
      emEcExternalNo: undefined,
      emEcExternalDoc: undefined,
      emEcImpDept: undefined,
      emEcEntryDate: new Date(),
      isModifySop: 1,
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
    const id = row.emId || ids.value
    getPpEcMaster(id).then((res) => {
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
        if (form.value.emId != undefined && opertype.value === 2) {
          updatePpEcMaster(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpEcMaster(form.value).then((res) => {
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
    const Ids = row.emId || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPpEcMaster(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "主设变", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Production/PpEcMaster/export', { ...queryParams })
      })
  }

  handleQuery()
</script>