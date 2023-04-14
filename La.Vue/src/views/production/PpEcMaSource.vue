<!--
 * @Descripttion: (主源设变/pp_ec_ma_source)
 * @version: (1.0)
 * @Author: (Davis.Cheng)
 * @Date: (2023-04-13)
 * @LastEditors: (Davis.Cheng)
 * @LastEditTime: (2023-04-13)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="设变No." prop="dSapZpabdZ001">
        <el-input clearable v-model="queryParams.dSapZpabdZ001" :placeholder="$t('btn.enter')+'设变No.'" />
      </el-form-item>
      <el-form-item label="标题" prop="dSapZpabdZ003">
        <el-input clearable v-model="queryParams.dSapZpabdZ003" :placeholder="$t('btn.enter')+'标题'" />
      </el-form-item>
      <el-form-item label="状态" prop="dSapZpabdZ004">
        <el-select filterable clearable v-model="queryParams.dSapZpabdZ004" :placeholder="$t('btn.select')+'状态'">
          <el-option v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="发行日">
        <el-date-picker v-model="dateRangeDSapZpabdZ005" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :placeholder="$t('btn.select')+'发行日'" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="处理标记" prop="isSolved">
        <el-radio-group v-model="queryParams.isSolved">
          <el-radio v-for="item in  options.sys_sop_yn " :key="parseInt(item.dictValue)"
            :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
        </el-radio-group>

      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:ecmasource:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecmasource:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecmasource:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#DC143C" v-hasPermi="['pp:ecmasource:delete']" plain icon="delete" @click="handleClear">
          {{ $t('btn.clean') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#00CED1" plain icon="Upload" @click="handleImport" v-hasPermi="['pp:ecmasource:import']">
          {{ $t('btn.import') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecmasource:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange" height="602" style="width: 100%">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="guid" label="ID" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('guid')" />
      <el-table-column prop="dSapZpabdZ001" label="设变No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ001')" />
      <el-table-column prop="dSapZpabdZ002" label="机种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ002')" />
      <el-table-column prop="dSapZpabdZ003" label="标题" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ003')" />
      <el-table-column prop="dSapZpabdZ004" label="状态" align="center" v-if="columns.showColumn('dSapZpabdZ004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.dSapZpabdZ004" />
        </template>
      </el-table-column>
      <el-table-column prop="dSapZpabdZ005" label="发行日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ005')" />
      <el-table-column prop="dSapZpabdZ006" label="担当" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ006')" />
      <el-table-column prop="dSapZpabdZ007" label="依赖" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ007')" />
      <el-table-column prop="dSapZpabdZ008" label="会议" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ008')" />
      <el-table-column prop="dSapZpabdZ009" label="PP番号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ009')" />
      <el-table-column prop="dSapZpabdZ010" label="联络书" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ010')" />
      <el-table-column prop="dSapZpabdZ011" label="实施" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ011')" />
      <el-table-column prop="dSapZpabdZ012" label="主理由" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ012')" />
      <el-table-column prop="dSapZpabdZ013" label="次理由" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ013')" />
      <el-table-column prop="dSapZpabdZ014" label="安规" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ014')" />
      <el-table-column prop="dSapZpabdZ015" label="状况" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ015')" />
      <el-table-column prop="dSapZpabdZ016" label="机番" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ016')" />
      <el-table-column prop="dSapZpabdZ017" label="承认" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ017')" />
      <el-table-column prop="dSapZpabdZ018" label="服务手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ018')" />
      <el-table-column prop="dSapZpabdZ019" label="用户手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ019')" />
      <el-table-column prop="dSapZpabdZ020" label="宣传手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ020')" />
      <el-table-column prop="dSapZpabdZ021" label="SOP订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ021')" />
      <el-table-column prop="dSapZpabdZ022" label="信息发行" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ022')" />
      <el-table-column prop="dSapZpabdZ023" label="成本变动" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ023')" />
      <el-table-column prop="dSapZpabdZ024" label="单位成本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ024')" />
      <el-table-column prop="dSapZpabdZ025" label="模具改造费" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ025')" />
      <el-table-column prop="dSapZpabdZ026" label="图纸" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ026')" />
      <el-table-column prop="dSapZpabdZ027" label="设变内容" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dSapZpabdZ027')" />
      <el-table-column prop="isSolved" label="处理标记" align="center" v-if="columns.showColumn('isSolved')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.isSolved" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button type="primary" icon="view" @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecmasource:edit']" type="success" icon="edit" :title="$t('btn.edit')"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:ecmasource:delete']" type="danger" icon="delete" :title="$t('btn.delete')"
            @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改主源设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID" prop="guid">
              <el-input clearable v-model="form.guid" controls-position="right" :placeholder="$t('btn.enter')+'ID'"
                :disabled="title==$t('btn.edit')" />
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="设变No." prop="dSapZpabdZ001">
              <el-input clearable v-model="form.dSapZpabdZ001" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="dSapZpabdZ002">
              <el-input clearable v-model="form.dSapZpabdZ002" :placeholder="$t('btn.enter')+'机种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="dSapZpabdZ003">
              <el-input clearable v-model="form.dSapZpabdZ003" :placeholder="$t('btn.enter')+'标题'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="dSapZpabdZ004">
              <el-select v-model="form.dSapZpabdZ004" filterable clearable :placeholder="$t('btn.select')+'状态'">
                <el-option v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日" prop="dSapZpabdZ005">
              <el-date-picker clearable v-model="form.dSapZpabdZ005" type="datetime" :teleported="false"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="dSapZpabdZ006">
              <el-input clearable v-model="form.dSapZpabdZ006" :placeholder="$t('btn.enter')+'担当'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="依赖" prop="dSapZpabdZ007">
              <el-input clearable v-model="form.dSapZpabdZ007" :placeholder="$t('btn.enter')+'依赖'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会议" prop="dSapZpabdZ008">
              <el-input clearable v-model="form.dSapZpabdZ008" :placeholder="$t('btn.enter')+'会议'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PP番号" prop="dSapZpabdZ009">
              <el-input clearable v-model="form.dSapZpabdZ009" :placeholder="$t('btn.enter')+'PP番号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络书" prop="dSapZpabdZ010">
              <el-input clearable v-model="form.dSapZpabdZ010" :placeholder="$t('btn.enter')+'联络书'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实施" prop="dSapZpabdZ011">
              <el-input clearable v-model="form.dSapZpabdZ011" :placeholder="$t('btn.enter')+'实施'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主理由" prop="dSapZpabdZ012">
              <el-input clearable v-model="form.dSapZpabdZ012" :placeholder="$t('btn.enter')+'主理由'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="次理由" prop="dSapZpabdZ013">
              <el-input clearable v-model="form.dSapZpabdZ013" :placeholder="$t('btn.enter')+'次理由'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安规" prop="dSapZpabdZ014">
              <el-input clearable v-model="form.dSapZpabdZ014" :placeholder="$t('btn.enter')+'安规'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状况" prop="dSapZpabdZ015">
              <el-input clearable v-model="form.dSapZpabdZ015" :placeholder="$t('btn.enter')+'状况'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机番" prop="dSapZpabdZ016">
              <el-input clearable v-model="form.dSapZpabdZ016" :placeholder="$t('btn.enter')+'机番'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认" prop="dSapZpabdZ017">
              <el-input clearable v-model="form.dSapZpabdZ017" :placeholder="$t('btn.enter')+'承认'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务手册订正" prop="dSapZpabdZ018">
              <el-input clearable v-model="form.dSapZpabdZ018" :placeholder="$t('btn.enter')+'服务手册订正'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户手册订正" prop="dSapZpabdZ019">
              <el-input clearable v-model="form.dSapZpabdZ019" :placeholder="$t('btn.enter')+'用户手册订正'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="宣传手册订正" prop="dSapZpabdZ020">
              <el-input clearable v-model="form.dSapZpabdZ020" :placeholder="$t('btn.enter')+'宣传手册订正'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SOP订正" prop="dSapZpabdZ021">
              <el-input clearable v-model="form.dSapZpabdZ021" :placeholder="$t('btn.enter')+'SOP订正'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="信息发行" prop="dSapZpabdZ022">
              <el-input clearable v-model="form.dSapZpabdZ022" :placeholder="$t('btn.enter')+'信息发行'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本变动" prop="dSapZpabdZ023">
              <el-input clearable v-model="form.dSapZpabdZ023" :placeholder="$t('btn.enter')+'成本变动'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位成本" prop="dSapZpabdZ024">
              <el-input-number clearable v-model.number="form.dSapZpabdZ024" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'单位成本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="模具改造费" prop="dSapZpabdZ025">
              <el-input-number clearable v-model.number="form.dSapZpabdZ025" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'模具改造费'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="图纸" prop="dSapZpabdZ026">
              <el-input clearable v-model="form.dSapZpabdZ026" :placeholder="$t('btn.enter')+'图纸'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="设变内容" prop="dSapZpabdZ027">
              <el-input clearable type="textarea" v-model="form.dSapZpabdZ027" :placeholder="$t('btn.enter')+'设变内容'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标记" prop="isSolved">
              <el-radio-group v-model="form.isSolved">
                <el-radio v-for="item in  options.sys_sop_yn " :key="parseInt(item.dictValue)"
                  :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IsDeleted" prop="isDeleted">
              <el-input-number clearable v-model.number="form.isDeleted" :controls="true" controls-position="right"
                :placeholder="$t('btn.enter')+'IsDeleted'" :disabled="true" />
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

<script setup name="ppecmasource">
  // 引入 ppecmasource操作方法
  import {
    listPpEcMaSource, addPpEcMaSource, delPpEcMaSource, updatePpEcMaSource, getPpEcMaSource,
    clearPpEcMaSource,
  }
    from '@/api/production/ppecmasource.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 选中guid数组数组
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
    dSapZpabdZ001: undefined,
    dSapZpabdZ003: undefined,
    dSapZpabdZ004: undefined,
    dSapZpabdZ005: undefined,
    isSolved: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'guid', label: 'ID' },
    { visible: true, prop: 'dSapZpabdZ001', label: '设变No.' },
    { visible: true, prop: 'dSapZpabdZ002', label: '机种' },
    { visible: true, prop: 'dSapZpabdZ003', label: '标题' },
    { visible: true, prop: 'dSapZpabdZ004', label: '状态' },
    { visible: true, prop: 'dSapZpabdZ005', label: '发行日' },
    { visible: true, prop: 'dSapZpabdZ006', label: '担当' },
    { visible: true, prop: 'dSapZpabdZ007', label: '依赖' },
    { visible: false, prop: 'dSapZpabdZ008', label: '会议' },
    { visible: false, prop: 'dSapZpabdZ009', label: 'PP番号' },
    { visible: false, prop: 'dSapZpabdZ010', label: '联络书' },
    { visible: false, prop: 'dSapZpabdZ011', label: '实施' },
    { visible: false, prop: 'dSapZpabdZ012', label: '主理由' },
    { visible: false, prop: 'dSapZpabdZ013', label: '次理由' },
    { visible: false, prop: 'dSapZpabdZ014', label: '安规' },
    { visible: false, prop: 'dSapZpabdZ015', label: '状况' },
    { visible: false, prop: 'dSapZpabdZ016', label: '机番' },
    { visible: false, prop: 'dSapZpabdZ017', label: '承认' },
    { visible: false, prop: 'dSapZpabdZ018', label: '服务手册订正' },
    { visible: false, prop: 'dSapZpabdZ019', label: '用户手册订正' },
    { visible: false, prop: 'dSapZpabdZ020', label: '宣传手册订正' },
    { visible: false, prop: 'dSapZpabdZ021', label: 'SOP订正' },
    { visible: false, prop: 'dSapZpabdZ022', label: '信息发行' },
    { visible: false, prop: 'dSapZpabdZ023', label: '成本变动' },
    { visible: false, prop: 'dSapZpabdZ024', label: '单位成本' },
    { visible: false, prop: 'dSapZpabdZ025', label: '模具改造费' },
    { visible: false, prop: 'dSapZpabdZ026', label: '图纸' },
    { visible: false, prop: 'dSapZpabdZ027', label: '设变内容' },
    { visible: false, prop: 'isSolved', label: '处理标记' },
  ])
  // 总条数
  const total = ref(0)
  // 主源设变表格数据
  const dataList = ref([])
  // 查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 发行日时间范围
  const dateRangeDSapZpabdZ005 = ref([])


  var dictParams = [
    { dictType: "sys_ec_status" },
    { dictType: "sys_sop_yn" },
  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //获取主源设变表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeDSapZpabdZ005.value, 'DSapZpabdZ005');
    loading.value = true
    listPpEcMaSource(queryParams).then(res => {
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
    dateRangeDSapZpabdZ005.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.guid);
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
      guid: [{ required: true, message: "ID" + proxy.$t('btn.empty'), trigger: "blur" }],
      isSolved: [{ required: true, message: "处理标记" + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_status: [],
      // 处理标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sop_yn: [],
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
      guid: undefined,
      dSapZpabdZ001: undefined,
      dSapZpabdZ002: undefined,
      dSapZpabdZ003: undefined,
      dSapZpabdZ004: undefined,
      dSapZpabdZ005: undefined,
      dSapZpabdZ006: undefined,
      dSapZpabdZ007: undefined,
      dSapZpabdZ008: undefined,
      dSapZpabdZ009: undefined,
      dSapZpabdZ010: undefined,
      dSapZpabdZ011: undefined,
      dSapZpabdZ012: undefined,
      dSapZpabdZ013: undefined,
      dSapZpabdZ014: undefined,
      dSapZpabdZ015: undefined,
      dSapZpabdZ016: undefined,
      dSapZpabdZ017: undefined,
      dSapZpabdZ018: undefined,
      dSapZpabdZ019: undefined,
      dSapZpabdZ020: undefined,
      dSapZpabdZ021: undefined,
      dSapZpabdZ022: undefined,
      dSapZpabdZ023: undefined,
      dSapZpabdZ024: undefined,
      dSapZpabdZ025: undefined,
      dSapZpabdZ026: undefined,
      dSapZpabdZ027: undefined,
      isSolved: undefined,
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
    const id = row.guid || ids.value
    getPpEcMaSource(id).then((res) => {
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
        if (form.value.guid != undefined && opertype.value === 2) {
          updatePpEcMaSource(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
            .catch(() => { })
        } else {
          addPpEcMaSource(form.value).then((res) => {
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
    const Ids = row.guid || ids.value

    proxy.$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPpEcMaSource(Ids)
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
        return clearPpEcMaSource()
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
      .$confirm(proxy.$t('common.confirmExport') + "主源设变", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Production/PpEcMaSource/export', { ...queryParams })
      })
  }

  handleQuery()
</script>