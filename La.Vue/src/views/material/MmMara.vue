<!--
 * @Descripttion: (常规物料数据/mm_mara)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-14)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-14)
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
        <el-button type="primary" v-hasPermi="['mm:mara:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:mara:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:mara:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['mm:mara:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="maraID" label="ID主键" align="center" v-if="columns.showColumn('maraID')"/>
      <el-table-column prop="maraADPROF" label="调整参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraADPROF')"/>
      <el-table-column prop="maraAEKLK" label="净改变成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraAEKLK')"/>
      <el-table-column prop="maraAENAM" label="更改者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraAENAM')"/>
      <el-table-column prop="maraAESZN" label="文档变更号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraAESZN')"/>
      <el-table-column prop="maraallowPmatIgno" label="允许的变式价格" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraallowPmatIgno')"/>
      <el-table-column prop="maraanimalOrigin" label="动物源 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraanimalOrigin')"/>
      <el-table-column prop="maraANP" label="ANP Code" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraANP')"/>
      <el-table-column prop="maraATTYP" label="物料类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraATTYP')"/>
      <el-table-column prop="maraBBTYP" label="分类清单类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBBTYP')"/>
      <el-table-column prop="maraBEGRU" label="权限组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBEGRU')"/>
      <el-table-column prop="maraBEHVO" label="容器" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBEHVO')"/>
      <el-table-column prop="maraBFLME" label="后勤变量" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBFLME')"/>
      <el-table-column prop="maraBISMT" label="旧物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBISMT')"/>
      <el-table-column prop="maraBLANZ" label="页数" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBLANZ')"/>
      <el-table-column prop="maraBLATT" label="页号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBLATT')"/>
      <el-table-column prop="maraBMATN" label="内部物料编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBMATN')"/>
      <el-table-column prop="marabrandId" label="商标" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marabrandId')"/>
      <el-table-column prop="maraBREIT" label="宽度" align="center" v-if="columns.showColumn('maraBREIT')"/>
      <el-table-column prop="maraBRGEW" label="毛重" align="center" v-if="columns.showColumn('maraBRGEW')"/>
      <el-table-column prop="maraBSTAT" label="创建状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBSTAT')"/>
      <el-table-column prop="maraBSTME" label="订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBSTME')"/>
      <el-table-column prop="maraBWSCL" label="货源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBWSCL')"/>
      <el-table-column prop="maraBWVOR" label="采购规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraBWVOR')"/>
      <el-table-column prop="maraCADKZ" label="CAD 标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCADKZ')"/>
      <el-table-column prop="maracareCode" label="护理代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maracareCode')"/>
      <el-table-column prop="maraCMETH" label="转换方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCMETH')"/>
      <el-table-column prop="maraCMREL" label="CM 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCMREL')"/>
      <el-table-column prop="maraCOLOR" label="颜色" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCOLOR')"/>
      <el-table-column prop="maracolorAtinn" label="内部特性 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maracolorAtinn')"/>
      <el-table-column prop="maraCOMMODITY" label="实物商品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCOMMODITY')"/>
      <el-table-column prop="maraCOMPL" label="完成水平" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCOMPL')"/>
      <el-table-column prop="maraCUOBF" label="内部对象号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCUOBF')"/>
      <el-table-column prop="maraCWQPROC" label="CW 参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCWQPROC')"/>
      <el-table-column prop="maraCWQREL" label="称重物料相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCWQREL')"/>
      <el-table-column prop="maraCWQTOLGR" label="CW 容差组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraCWQTOLGR')"/>
      <el-table-column prop="maraDATAB" label="有效起始日 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraDATAB')"/>
      <el-table-column prop="maradgPackStatus" label="危险品包装状态" align="center" v-if="columns.showColumn('maradgPackStatus')">
        <template #default="scope">
          <dict-tag :options=" options.maradgPackStatusOptions" :value="scope.row.maradgPackStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="maraDISST" label="低层代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraDISST')"/>
      <el-table-column prop="maraEAN11" label="EAN/UPC" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraEAN11')"/>
      <el-table-column prop="maraEANNR" label="EAN 号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraEANNR')"/>
      <el-table-column prop="maraEKWSL" label="采购值代码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraEKWSL')"/>
      <el-table-column prop="maraENTAR" label="取消激活字段 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraENTAR')"/>
      <el-table-column prop="maraERGEI" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraERGEI')"/>
      <el-table-column prop="maraERGEW" label="允许的包装重量" align="center" v-if="columns.showColumn('maraERGEW')"/>
      <el-table-column prop="maraERNAM" label="创建者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraERNAM')"/>
      <el-table-column prop="maraERSDA" label="创建日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraERSDA')"/>
      <el-table-column prop="maraERVOE" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraERVOE')"/>
      <el-table-column prop="maraERVOL" label="允许的体积 " align="center" v-if="columns.showColumn('maraERVOL')"/>
      <el-table-column prop="maraETIAG" label="给物料组加标签" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraETIAG')"/>
      <el-table-column prop="maraETIAR" label="标号类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraETIAR')"/>
      <el-table-column prop="maraETIFO" label="标签格式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraETIFO')"/>
      <el-table-column prop="maraEXTWG" label="外部物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraEXTWG')"/>
      <el-table-column prop="maraFASHGRD" label="时装等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraFASHGRD')"/>
      <el-table-column prop="maraFERTH" label="生产/检验备忘录" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraFERTH')"/>
      <el-table-column prop="marafiberCode1" label="组件1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberCode1')"/>
      <el-table-column prop="marafiberCode2" label="组件2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberCode2')"/>
      <el-table-column prop="marafiberCode3" label="组件3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberCode3')"/>
      <el-table-column prop="marafiberCode4" label="组件4" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberCode4')"/>
      <el-table-column prop="marafiberCode5" label="组件5" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberCode5')"/>
      <el-table-column prop="marafiberPart1" label="百分比共享1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberPart1')"/>
      <el-table-column prop="marafiberPart2" label="百分比共享2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberPart2')"/>
      <el-table-column prop="marafiberPart3" label="百分比共享3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberPart3')"/>
      <el-table-column prop="marafiberPart4" label="百分比共享4" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberPart4')"/>
      <el-table-column prop="marafiberPart5" label="百分比共享5" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafiberPart5')"/>
      <el-table-column prop="maraFORMT" label="页格式 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraFORMT')"/>
      <el-table-column prop="marafreeChar" label="特性值 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafreeChar')"/>
      <el-table-column prop="marafshMgAt1" label="Fashion 属性 1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshMgAt1')"/>
      <el-table-column prop="marafshMgAt2" label="Fashion 属性 2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshMgAt2')"/>
      <el-table-column prop="marafshMgAt3" label="Fashion 属性 3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshMgAt3')"/>
      <el-table-column prop="marafshScMid" label="物料转换标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshScMid')"/>
      <el-table-column prop="marafshSeaim" label="库存管理中激活季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshSeaim')"/>
      <el-table-column prop="marafshSealv" label="季节使用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marafshSealv')"/>
      <el-table-column prop="maraFUELG" label="最大层次 " align="center" v-if="columns.showColumn('maraFUELG')"/>
      <el-table-column prop="maragdsRelevant" label="GDS 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maragdsRelevant')"/>
      <el-table-column prop="maraGENNR" label="一般物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraGENNR')"/>
      <el-table-column prop="maraGEWEI" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraGEWEI')"/>
      <el-table-column prop="maraGEWTO" label="超重量容差 " align="center" v-if="columns.showColumn('maraGEWTO')"/>
      <el-table-column prop="maraGROES" label="大小/量纲" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraGROES')"/>
      <el-table-column prop="maragtinVariant" label="EAN变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maragtinVariant')"/>
      <el-table-column prop="maraHAZMAT" label="危险物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraHAZMAT')"/>
      <el-table-column prop="maraHERKL" label="原产地国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraHERKL')"/>
      <el-table-column prop="maraHNDLCODE" label="处理标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraHNDLCODE')"/>
      <el-table-column prop="maraHOEHE" label="高度" align="center" v-if="columns.showColumn('maraHOEHE')"/>
      <el-table-column prop="maraHUTYP" label="处理单位类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraHUTYP')"/>
      <el-table-column prop="marahutypDflt" label="标准处理单位类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marahutypDflt')"/>
      <el-table-column prop="maraIHIVI" label="高粘性的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraIHIVI')"/>
      <el-table-column prop="maraILOOS" label="以大批/液体" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraILOOS')"/>
      <el-table-column prop="maraIMATN" label="完全互换组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraIMATN')"/>
      <el-table-column prop="maraINHAL" label="净内容" align="center" v-if="columns.showColumn('maraINHAL')"/>
      <el-table-column prop="maraINHBR" label="毛内容 " align="center" v-if="columns.showColumn('maraINHBR')"/>
      <el-table-column prop="maraINHME" label="内容单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraINHME')"/>
      <el-table-column prop="maraIPMIPPRODUCT" label="知识产权" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraIPMIPPRODUCT')"/>
      <el-table-column prop="maraIPRKZ" label="期间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraIPRKZ')"/>
      <el-table-column prop="maraKOSCH" label="产品分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKOSCH')"/>
      <el-table-column prop="maraKUNNR" label="竞争者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKUNNR')"/>
      <el-table-column prop="maraKZEFF" label="参数有效值· " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZEFF')"/>
      <el-table-column prop="maraKZGVH" label="密闭的 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZGVH')"/>
      <el-table-column prop="maraKZKFG" label="可配置 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZKFG')"/>
      <el-table-column prop="maraKZKUP" label="联产品 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZKUP')"/>
      <el-table-column prop="maraKZNFM" label="后继的物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZNFM')"/>
      <el-table-column prop="maraKZREV" label="修订等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZREV')"/>
      <el-table-column prop="maraKZUMW" label="环境是相关的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZUMW')"/>
      <el-table-column prop="maraKZWSM" label="测量单位用法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraKZWSM')"/>
      <el-table-column prop="maraLABOR" label="实验室/办公室 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraLABOR')"/>
      <el-table-column prop="maraLAEDA" label="上次更改" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraLAEDA')"/>
      <el-table-column prop="maraLAENG" label="长度" align="center" v-if="columns.showColumn('maraLAENG')"/>
      <el-table-column prop="maraLIQDT" label="有效至 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraLIQDT')"/>
      <el-table-column prop="maraloglevReto" label="退货到后勤等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraloglevReto')"/>
      <el-table-column prop="maraLOGUNIT" label="后勤计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraLOGUNIT')"/>
      <el-table-column prop="maraLVORM" label="集团级的 DF" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraLVORM')"/>
      <el-table-column prop="maraMAGRV" label="物料组包装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMAGRV')"/>
      <el-table-column prop="maraMANDT" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMANDT')"/>
      <el-table-column prop="maraMATFI" label="物料被锁定 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMATFI')"/>
      <el-table-column prop="maraMATKL" label="物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMATKL')"/>
      <el-table-column prop="maraMATNR" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMATNR')"/>
      <el-table-column prop="maraMAXB" label="最大包宽度" align="center" v-if="columns.showColumn('maraMAXB')"/>
      <el-table-column prop="maraMAXC" label="最大容量 " align="center" v-if="columns.showColumn('maraMAXC')"/>
      <el-table-column prop="maramaxcTol" label="超过容量容差" align="center" v-if="columns.showColumn('maramaxcTol')"/>
      <el-table-column prop="maramaxdimUom" label="计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maramaxdimUom')"/>
      <el-table-column prop="maraMAXH" label="最大高度 " align="center" v-if="columns.showColumn('maraMAXH')"/>
      <el-table-column prop="maraMAXL" label="最大长度 " align="center" v-if="columns.showColumn('maraMAXL')"/>
      <el-table-column prop="maraMBRSH" label="行业领域" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMBRSH')"/>
      <el-table-column prop="maraMCOND" label="物料条件管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMCOND')"/>
      <el-table-column prop="maraMEABM" label="单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMEABM')"/>
      <el-table-column prop="maraMEDIUM" label="中间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMEDIUM')"/>
      <el-table-column prop="maraMEINS" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMEINS')"/>
      <el-table-column prop="maraMFRGR" label="物料运输组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMFRGR')"/>
      <el-table-column prop="maraMFRNR" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMFRNR')"/>
      <el-table-column prop="maraMFRPN" label="制造商零件编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMFRPN')"/>
      <el-table-column prop="maraMHDHB" label="总货架寿命 " align="center" v-if="columns.showColumn('maraMHDHB')"/>
      <el-table-column prop="maraMHDLP" label="仓储 %" align="center" v-if="columns.showColumn('maraMHDLP')"/>
      <el-table-column prop="maraMHDRZ" label="剩余货架寿命" align="center" v-if="columns.showColumn('maraMHDRZ')"/>
      <el-table-column prop="maraMLGUT" label="含空BOM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMLGUT')"/>
      <el-table-column prop="maraMPROF" label="制造商部件参数文" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMPROF')"/>
      <el-table-column prop="maraMSTAE" label="跨工厂物料状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMSTAE')"/>
      <el-table-column prop="maraMSTAV" label="跨分销链状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMSTAV')"/>
      <el-table-column prop="maraMSTDE" label="有效起始期 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMSTDE')"/>
      <el-table-column prop="maraMSTDV" label="有效从 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMSTDV')"/>
      <el-table-column prop="maraMTART" label="物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraMTART')"/>
      <el-table-column prop="maramtposMara" label="普通项目类别组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maramtposMara')"/>
      <el-table-column prop="maraNORMT" label="行业标准描述" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraNORMT')"/>
      <el-table-column prop="maraNRFHG" label="折扣类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraNRFHG')"/>
      <el-table-column prop="maraNSNID" label="NIIN" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraNSNID')"/>
      <el-table-column prop="maraNTGEW" label="净重 " align="center" v-if="columns.showColumn('maraNTGEW')"/>
      <el-table-column prop="maraNUMTP" label="EAN 类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraNUMTP')"/>
      <el-table-column prop="maraPACKCODE" label="Packaging Code" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPACKCODE')"/>
      <el-table-column prop="maraPICNUM" label="链编号 " align="center" v-if="columns.showColumn('maraPICNUM')">
        <template #default="scope">
          <el-image preview-teleported :hide-on-click-modal="true" lazy class="table-td-thumb" fit="contain" :src="scope.row.maraPICNUM" :preview-src-list="[scope.row.maraPICNUM]">
            <div><el-icon :size="15"><document /></el-icon></div>
          </el-image>
        </template>
      </el-table-column>
      <el-table-column prop="maraPILFERABLE" label="可偷窃的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPILFERABLE')"/>
      <el-table-column prop="maraPLGTP" label="价格标记类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPLGTP')"/>
      <el-table-column prop="maraPMATA" label="定价参考物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPMATA')"/>
      <el-table-column prop="maraPRDHA" label="产品层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPRDHA')"/>
      <el-table-column prop="maraPROFL" label="DG标识参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPROFL')"/>
      <el-table-column prop="maraPRZUS" label="产品成分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPRZUS')"/>
      <el-table-column prop="marapsSmartform" label="表格名 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marapsSmartform')"/>
      <el-table-column prop="maraPSTAT" label="维护状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraPSTAT')"/>
      <el-table-column prop="maraQGRP" label="质量检查组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraQGRP')"/>
      <el-table-column prop="maraQMPUR" label="QM 采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraQMPUR')"/>
      <el-table-column prop="maraQQTIME" label="隔离期间" align="center" v-if="columns.showColumn('maraQQTIME')"/>
      <el-table-column prop="maraQQTIMEUOM" label="时间单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraQQTIMEUOM')"/>
      <el-table-column prop="maraRAUBE" label="存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraRAUBE')"/>
      <el-table-column prop="maraRBNRM" label="类别参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraRBNRM')"/>
      <el-table-column prop="maraRDMHD" label="舍入规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraRDMHD')"/>
      <el-table-column prop="maraRETDELC" label="返回代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraRETDELC')"/>
      <el-table-column prop="maraRMATP" label="包装的参考物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraRMATP')"/>
      <el-table-column prop="maraSAISJ" label="季度年 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSAISJ')"/>
      <el-table-column prop="maraSAISO" label="季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSAISO')"/>
      <el-table-column prop="maraSAITY" label="展开" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSAITY')"/>
      <el-table-column prop="maraSATNR" label="一般可配置物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSATNR')"/>
      <el-table-column prop="maraSERIAL" label="序列号参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSERIAL')"/>
      <el-table-column prop="maraSERLV" label="序列化层次 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSERLV')"/>
      <el-table-column prop="marasgtCovsa" label="分段策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasgtCovsa')"/>
      <el-table-column prop="marasgtCsgr" label="分段结构" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasgtCsgr')"/>
      <el-table-column prop="marasgtRel" label="分段相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasgtRel')"/>
      <el-table-column prop="marasgtScope" label="分段范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasgtScope')"/>
      <el-table-column prop="marasgtStat" label="分段状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasgtStat')"/>
      <el-table-column prop="maraSIZE1" label="主尺寸 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSIZE1')"/>
      <el-table-column prop="marasize1Atinn" label="内部特性 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasize1Atinn')"/>
      <el-table-column prop="maraSIZE2" label="次尺寸 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSIZE2')"/>
      <el-table-column prop="marasize2Atinn" label="内部特性 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasize2Atinn')"/>
      <el-table-column prop="marasledBbd" label="过期日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marasledBbd')"/>
      <el-table-column prop="maraSPART" label="产品组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSPART')"/>
      <el-table-column prop="maraSPROF" label="定价参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSPROF')"/>
      <el-table-column prop="maraSTFAK" label="堆栈因子" align="center" v-if="columns.showColumn('maraSTFAK')"/>
      <el-table-column prop="maraSTOFF" label="危险物料号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraSTOFF')"/>
      <el-table-column prop="maraTAKLV" label="税收分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraTAKLV')"/>
      <el-table-column prop="maratareVar" label="可变皮重" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maratareVar')"/>
      <el-table-column prop="maraTEMPB" label="温度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraTEMPB')"/>
      <el-table-column prop="maratextileCompInd" label="纺织组分活动" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maratextileCompInd')"/>
      <el-table-column prop="maraTRAGR" label="运输组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraTRAGR')"/>
      <el-table-column prop="maraVABME" label="可变的订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraVABME')"/>
      <el-table-column prop="maraVHART" label="包装物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraVHART')"/>
      <el-table-column prop="maraVOLEH" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraVOLEH')"/>
      <el-table-column prop="maraVOLTO" label="超过体积容差" align="center" v-if="columns.showColumn('maraVOLTO')"/>
      <el-table-column prop="maraVOLUM" label="业务量 " align="center" v-if="columns.showColumn('maraVOLUM')"/>
      <el-table-column prop="maraVPREH" label="比较价格单位" align="center" v-if="columns.showColumn('maraVPREH')"/>
      <el-table-column prop="maraVPSTA" label="完整状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraVPSTA')"/>
      <el-table-column prop="maraWEORA" label="原始接受" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraWEORA')"/>
      <el-table-column prop="maraWESCH" label="GR单数量 " align="center" v-if="columns.showColumn('maraWESCH')"/>
      <el-table-column prop="maraWHMATGR" label="仓库物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraWHMATGR')"/>
      <el-table-column prop="maraWHSTC" label="仓库存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraWHSTC')"/>
      <el-table-column prop="maraWRKST" label="基本物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraWRKST')"/>
      <el-table-column prop="maraXCHPF" label="批次管理需求 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraXCHPF')"/>
      <el-table-column prop="maraXGCHP" label="需要批量记录 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraXGCHP')"/>
      <el-table-column prop="maraZEIAR" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraZEIAR')"/>
      <el-table-column prop="maraZEIFO" label="页面大小" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraZEIFO')"/>
      <el-table-column prop="maraZEINR" label="凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraZEINR')"/>
      <el-table-column prop="maraZEIVR" label="凭证版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maraZEIVR')"/>
      <el-table-column prop="uDF01" label="UDF01" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF01')"/>
      <el-table-column prop="uDF02" label="UDF02" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF02')"/>
      <el-table-column prop="uDF03" label="UDF03" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF03')"/>
      <el-table-column prop="uDF04" label="UDF04" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF04')"/>
      <el-table-column prop="uDF05" label="UDF05" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF05')"/>
      <el-table-column prop="uDF06" label="UDF06" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF06')"/>
      <el-table-column prop="uDF51" label="UDF51" align="center" v-if="columns.showColumn('uDF51')"/>
      <el-table-column prop="uDF52" label="UDF52" align="center" v-if="columns.showColumn('uDF52')"/>
      <el-table-column prop="uDF53" label="UDF53" align="center" v-if="columns.showColumn('uDF53')"/>
      <el-table-column prop="uDF54" label="UDF54" align="center" v-if="columns.showColumn('uDF54')"/>
      <el-table-column prop="uDF55" label="UDF55" align="center" v-if="columns.showColumn('uDF55')"/>
      <el-table-column prop="uDF56" label="UDF56" align="center" v-if="columns.showColumn('uDF56')"/>
      <el-table-column prop="remark" label="Remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['mm:mara:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['mm:mara:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改常规物料数据对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID主键" prop="maraID">
              <el-input-number clearable v-model.number="form.maraID" controls-position="right" :placeholder="$t('btn.enter')+'ID主键'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="调整参数文件" prop="maraADPROF">
              <el-input clearable v-model="form.maraADPROF" :placeholder="$t('btn.enter')+'调整参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净改变成本核算" prop="maraAEKLK">
              <el-input clearable v-model="form.maraAEKLK" :placeholder="$t('btn.enter')+'净改变成本核算'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更改者 " prop="maraAENAM">
              <el-input clearable v-model="form.maraAENAM" :placeholder="$t('btn.enter')+'更改者 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="文档变更号 " prop="maraAESZN">
              <el-input clearable v-model="form.maraAESZN" :placeholder="$t('btn.enter')+'文档变更号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的变式价格" prop="maraallowPmatIgno">
              <el-input clearable v-model="form.maraallowPmatIgno" :placeholder="$t('btn.enter')+'允许的变式价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="动物源 " prop="maraanimalOrigin">
              <el-input clearable v-model="form.maraanimalOrigin" :placeholder="$t('btn.enter')+'动物源 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ANP Code" prop="maraANP">
              <el-input clearable v-model="form.maraANP" :placeholder="$t('btn.enter')+'ANP Code'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类别" prop="maraATTYP">
              <el-input clearable v-model="form.maraATTYP" :placeholder="$t('btn.enter')+'物料类别'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分类清单类型" prop="maraBBTYP">
              <el-input clearable v-model="form.maraBBTYP" :placeholder="$t('btn.enter')+'分类清单类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="权限组 " prop="maraBEGRU">
              <el-input clearable v-model="form.maraBEGRU" :placeholder="$t('btn.enter')+'权限组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="容器" prop="maraBEHVO">
              <el-input clearable v-model="form.maraBEHVO" :placeholder="$t('btn.enter')+'容器'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤变量" prop="maraBFLME">
              <el-input clearable v-model="form.maraBFLME" :placeholder="$t('btn.enter')+'后勤变量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料号" prop="maraBISMT">
              <el-input clearable v-model="form.maraBISMT" :placeholder="$t('btn.enter')+'旧物料号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页数" prop="maraBLANZ">
              <el-input clearable v-model="form.maraBLANZ" :placeholder="$t('btn.enter')+'页数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页号" prop="maraBLATT">
              <el-input clearable v-model="form.maraBLATT" :placeholder="$t('btn.enter')+'页号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部物料编号" prop="maraBMATN">
              <el-input clearable v-model="form.maraBMATN" :placeholder="$t('btn.enter')+'内部物料编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商标" prop="marabrandId">
              <el-input clearable v-model="form.marabrandId" :placeholder="$t('btn.enter')+'商标'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="宽度" prop="maraBREIT">
              <el-input clearable v-model="form.maraBREIT" :placeholder="$t('btn.enter')+'宽度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛重" prop="maraBRGEW">
              <el-input clearable v-model="form.maraBRGEW" :placeholder="$t('btn.enter')+'毛重'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建状态 " prop="maraBSTAT">
              <el-input clearable v-model="form.maraBSTAT" :placeholder="$t('btn.enter')+'创建状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单单位" prop="maraBSTME">
              <el-input clearable v-model="form.maraBSTME" :placeholder="$t('btn.enter')+'订单单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源" prop="maraBWSCL">
              <el-input clearable v-model="form.maraBWSCL" :placeholder="$t('btn.enter')+'货源'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购规则" prop="maraBWVOR">
              <el-input clearable v-model="form.maraBWVOR" :placeholder="$t('btn.enter')+'采购规则'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAD 标识" prop="maraCADKZ">
              <el-input clearable v-model="form.maraCADKZ" :placeholder="$t('btn.enter')+'CAD 标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="护理代码" prop="maracareCode">
              <el-input clearable v-model="form.maracareCode" :placeholder="$t('btn.enter')+'护理代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换方法" prop="maraCMETH">
              <el-input clearable v-model="form.maraCMETH" :placeholder="$t('btn.enter')+'转换方法'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CM 相关" prop="maraCMREL">
              <el-input clearable v-model="form.maraCMREL" :placeholder="$t('btn.enter')+'CM 相关'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="颜色" prop="maraCOLOR">
              <el-input clearable v-model="form.maraCOLOR" :placeholder="$t('btn.enter')+'颜色'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="maracolorAtinn">
              <el-input clearable v-model="form.maracolorAtinn" :placeholder="$t('btn.enter')+'内部特性 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实物商品" prop="maraCOMMODITY">
              <el-input clearable v-model="form.maraCOMMODITY" :placeholder="$t('btn.enter')+'实物商品'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完成水平" prop="maraCOMPL">
              <el-input clearable v-model="form.maraCOMPL" :placeholder="$t('btn.enter')+'完成水平'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部对象号 " prop="maraCUOBF">
              <el-input clearable v-model="form.maraCUOBF" :placeholder="$t('btn.enter')+'内部对象号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW 参数文件" prop="maraCWQPROC">
              <el-input clearable v-model="form.maraCWQPROC" :placeholder="$t('btn.enter')+'CW 参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="称重物料相关" prop="maraCWQREL">
              <el-input clearable v-model="form.maraCWQREL" :placeholder="$t('btn.enter')+'称重物料相关'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW 容差组 " prop="maraCWQTOLGR">
              <el-input clearable v-model="form.maraCWQTOLGR" :placeholder="$t('btn.enter')+'CW 容差组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始日 " prop="maraDATAB">
              <el-date-picker clearable v-model="form.maraDATAB" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险品包装状态" prop="maradgPackStatus">
              <el-radio-group v-model="form.maradgPackStatus">
                <el-radio v-for="item in  options.maradgPackStatusOptions" :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="低层代码" prop="maraDISST">
              <el-input clearable v-model="form.maraDISST" :placeholder="$t('btn.enter')+'低层代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN/UPC" prop="maraEAN11">
              <el-input clearable v-model="form.maraEAN11" :placeholder="$t('btn.enter')+'EAN/UPC'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN 号 " prop="maraEANNR">
              <el-input clearable v-model="form.maraEANNR" :placeholder="$t('btn.enter')+'EAN 号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购值代码 " prop="maraEKWSL">
              <el-input clearable v-model="form.maraEKWSL" :placeholder="$t('btn.enter')+'采购值代码 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="取消激活字段 " prop="maraENTAR">
              <el-input clearable v-model="form.maraENTAR" :placeholder="$t('btn.enter')+'取消激活字段 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="maraERGEI">
              <el-input clearable v-model="form.maraERGEI" :placeholder="$t('btn.enter')+'重量单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的包装重量" prop="maraERGEW">
              <el-input clearable v-model="form.maraERGEW" :placeholder="$t('btn.enter')+'允许的包装重量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者 " prop="maraERNAM">
              <el-input clearable v-model="form.maraERNAM" :placeholder="$t('btn.enter')+'创建者 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建日期" prop="maraERSDA">
              <el-date-picker clearable v-model="form.maraERSDA" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="maraERVOE">
              <el-input clearable v-model="form.maraERVOE" :placeholder="$t('btn.enter')+'体积单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的体积 " prop="maraERVOL">
              <el-input clearable v-model="form.maraERVOL" :placeholder="$t('btn.enter')+'允许的体积 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="给物料组加标签" prop="maraETIAG">
              <el-input clearable v-model="form.maraETIAG" :placeholder="$t('btn.enter')+'给物料组加标签'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标号类型" prop="maraETIAR">
              <el-input clearable v-model="form.maraETIAR" :placeholder="$t('btn.enter')+'标号类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标签格式" prop="maraETIFO">
              <el-input clearable v-model="form.maraETIFO" :placeholder="$t('btn.enter')+'标签格式'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部物料组 " prop="maraEXTWG">
              <el-input clearable v-model="form.maraEXTWG" :placeholder="$t('btn.enter')+'外部物料组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时装等级" prop="maraFASHGRD">
              <el-input clearable v-model="form.maraFASHGRD" :placeholder="$t('btn.enter')+'时装等级'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产/检验备忘录" prop="maraFERTH">
              <el-input clearable v-model="form.maraFERTH" :placeholder="$t('btn.enter')+'生产/检验备忘录'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件1" prop="marafiberCode1">
              <el-input clearable v-model="form.marafiberCode1" :placeholder="$t('btn.enter')+'组件1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件2" prop="marafiberCode2">
              <el-input clearable v-model="form.marafiberCode2" :placeholder="$t('btn.enter')+'组件2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件3" prop="marafiberCode3">
              <el-input clearable v-model="form.marafiberCode3" :placeholder="$t('btn.enter')+'组件3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件4" prop="marafiberCode4">
              <el-input clearable v-model="form.marafiberCode4" :placeholder="$t('btn.enter')+'组件4'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件5" prop="marafiberCode5">
              <el-input clearable v-model="form.marafiberCode5" :placeholder="$t('btn.enter')+'组件5'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="百分比共享1" prop="marafiberPart1">
              <el-input clearable v-model="form.marafiberPart1" :placeholder="$t('btn.enter')+'百分比共享1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="百分比共享2" prop="marafiberPart2">
              <el-input clearable v-model="form.marafiberPart2" :placeholder="$t('btn.enter')+'百分比共享2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="百分比共享3" prop="marafiberPart3">
              <el-input clearable v-model="form.marafiberPart3" :placeholder="$t('btn.enter')+'百分比共享3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="百分比共享4" prop="marafiberPart4">
              <el-input clearable v-model="form.marafiberPart4" :placeholder="$t('btn.enter')+'百分比共享4'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="百分比共享5" prop="marafiberPart5">
              <el-input clearable v-model="form.marafiberPart5" :placeholder="$t('btn.enter')+'百分比共享5'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页格式 " prop="maraFORMT">
              <el-input clearable v-model="form.maraFORMT" :placeholder="$t('btn.enter')+'页格式 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特性值 " prop="marafreeChar">
              <el-input clearable v-model="form.marafreeChar" :placeholder="$t('btn.enter')+'特性值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 1" prop="marafshMgAt1">
              <el-input clearable v-model="form.marafshMgAt1" :placeholder="$t('btn.enter')+'Fashion 属性 1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 2" prop="marafshMgAt2">
              <el-input clearable v-model="form.marafshMgAt2" :placeholder="$t('btn.enter')+'Fashion 属性 2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 3" prop="marafshMgAt3">
              <el-input clearable v-model="form.marafshMgAt3" :placeholder="$t('btn.enter')+'Fashion 属性 3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料转换标识" prop="marafshScMid">
              <el-input clearable v-model="form.marafshScMid" :placeholder="$t('btn.enter')+'物料转换标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理中激活季节" prop="marafshSeaim">
              <el-input clearable v-model="form.marafshSeaim" :placeholder="$t('btn.enter')+'库存管理中激活季节'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季节使用" prop="marafshSealv">
              <el-input clearable v-model="form.marafshSealv" :placeholder="$t('btn.enter')+'季节使用'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大层次 " prop="maraFUELG">
              <el-input clearable v-model="form.maraFUELG" :placeholder="$t('btn.enter')+'最大层次 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GDS 相关" prop="maragdsRelevant">
              <el-input clearable v-model="form.maragdsRelevant" :placeholder="$t('btn.enter')+'GDS 相关'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般物料 " prop="maraGENNR">
              <el-input clearable v-model="form.maraGENNR" :placeholder="$t('btn.enter')+'一般物料 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="maraGEWEI">
              <el-input clearable v-model="form.maraGEWEI" :placeholder="$t('btn.enter')+'重量单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超重量容差 " prop="maraGEWTO">
              <el-input clearable v-model="form.maraGEWTO" :placeholder="$t('btn.enter')+'超重量容差 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="大小/量纲" prop="maraGROES">
              <el-input clearable v-model="form.maraGROES" :placeholder="$t('btn.enter')+'大小/量纲'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN变式" prop="maragtinVariant">
              <el-input clearable v-model="form.maragtinVariant" :placeholder="$t('btn.enter')+'EAN变式'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料" prop="maraHAZMAT">
              <el-input clearable v-model="form.maraHAZMAT" :placeholder="$t('btn.enter')+'危险物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原产地国" prop="maraHERKL">
              <el-input clearable v-model="form.maraHERKL" :placeholder="$t('btn.enter')+'原产地国'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标识" prop="maraHNDLCODE">
              <el-input clearable v-model="form.maraHNDLCODE" :placeholder="$t('btn.enter')+'处理标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高度" prop="maraHOEHE">
              <el-input clearable v-model="form.maraHOEHE" :placeholder="$t('btn.enter')+'高度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理单位类型" prop="maraHUTYP">
              <el-input clearable v-model="form.maraHUTYP" :placeholder="$t('btn.enter')+'处理单位类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准处理单位类" prop="marahutypDflt">
              <el-input clearable v-model="form.marahutypDflt" :placeholder="$t('btn.enter')+'标准处理单位类'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高粘性的" prop="maraIHIVI">
              <el-input clearable v-model="form.maraIHIVI" :placeholder="$t('btn.enter')+'高粘性的'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="以大批/液体" prop="maraILOOS">
              <el-input clearable v-model="form.maraILOOS" :placeholder="$t('btn.enter')+'以大批/液体'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完全互换组 " prop="maraIMATN">
              <el-input clearable v-model="form.maraIMATN" :placeholder="$t('btn.enter')+'完全互换组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净内容" prop="maraINHAL">
              <el-input clearable v-model="form.maraINHAL" :placeholder="$t('btn.enter')+'净内容'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛内容 " prop="maraINHBR">
              <el-input clearable v-model="form.maraINHBR" :placeholder="$t('btn.enter')+'毛内容 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容单位" prop="maraINHME">
              <el-input clearable v-model="form.maraINHME" :placeholder="$t('btn.enter')+'内容单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="知识产权" prop="maraIPMIPPRODUCT">
              <el-input clearable v-model="form.maraIPMIPPRODUCT" :placeholder="$t('btn.enter')+'知识产权'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间标识" prop="maraIPRKZ">
              <el-input clearable v-model="form.maraIPRKZ" :placeholder="$t('btn.enter')+'期间标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品分配" prop="maraKOSCH">
              <el-input clearable v-model="form.maraKOSCH" :placeholder="$t('btn.enter')+'产品分配'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="竞争者 " prop="maraKUNNR">
              <el-input clearable v-model="form.maraKUNNR" :placeholder="$t('btn.enter')+'竞争者 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参数有效值· " prop="maraKZEFF">
              <el-input clearable v-model="form.maraKZEFF" :placeholder="$t('btn.enter')+'参数有效值· '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="密闭的 " prop="maraKZGVH">
              <el-input clearable v-model="form.maraKZGVH" :placeholder="$t('btn.enter')+'密闭的 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可配置 " prop="maraKZKFG">
              <el-input clearable v-model="form.maraKZKFG" :placeholder="$t('btn.enter')+'可配置 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联产品 " prop="maraKZKUP">
              <el-input clearable v-model="form.maraKZKUP" :placeholder="$t('btn.enter')+'联产品 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后继的物料 " prop="maraKZNFM">
              <el-input clearable v-model="form.maraKZNFM" :placeholder="$t('btn.enter')+'后继的物料 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修订等级" prop="maraKZREV">
              <el-input clearable v-model="form.maraKZREV" :placeholder="$t('btn.enter')+'修订等级'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="环境是相关的" prop="maraKZUMW">
              <el-input clearable v-model="form.maraKZUMW" :placeholder="$t('btn.enter')+'环境是相关的'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="测量单位用法" prop="maraKZWSM">
              <el-input clearable v-model="form.maraKZWSM" :placeholder="$t('btn.enter')+'测量单位用法'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实验室/办公室 " prop="maraLABOR">
              <el-input clearable v-model="form.maraLABOR" :placeholder="$t('btn.enter')+'实验室/办公室 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上次更改" prop="maraLAEDA">
              <el-date-picker clearable v-model="form.maraLAEDA" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长度" prop="maraLAENG">
              <el-input clearable v-model="form.maraLAENG" :placeholder="$t('btn.enter')+'长度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效至 " prop="maraLIQDT">
              <el-date-picker clearable v-model="form.maraLIQDT" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="退货到后勤等级" prop="maraloglevReto">
              <el-input clearable v-model="form.maraloglevReto" :placeholder="$t('btn.enter')+'退货到后勤等级'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤计量单位" prop="maraLOGUNIT">
              <el-input clearable v-model="form.maraLOGUNIT" :placeholder="$t('btn.enter')+'后勤计量单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团级的 DF" prop="maraLVORM">
              <el-input clearable v-model="form.maraLVORM" :placeholder="$t('btn.enter')+'集团级的 DF'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组包装物料" prop="maraMAGRV">
              <el-input clearable v-model="form.maraMAGRV" :placeholder="$t('btn.enter')+'物料组包装物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="maraMANDT">
              <el-input clearable v-model="form.maraMANDT" :placeholder="$t('btn.enter')+'集团'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料被锁定 " prop="maraMATFI">
              <el-input clearable v-model="form.maraMATFI" :placeholder="$t('btn.enter')+'物料被锁定 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组 " prop="maraMATKL">
              <el-input clearable v-model="form.maraMATKL" :placeholder="$t('btn.enter')+'物料组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="maraMATNR">
              <el-input clearable v-model="form.maraMATNR" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大包宽度" prop="maraMAXB">
              <el-input clearable v-model="form.maraMAXB" :placeholder="$t('btn.enter')+'最大包宽度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大容量 " prop="maraMAXC">
              <el-input clearable v-model="form.maraMAXC" :placeholder="$t('btn.enter')+'最大容量 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超过容量容差" prop="maramaxcTol">
              <el-input clearable v-model="form.maramaxcTol" :placeholder="$t('btn.enter')+'超过容量容差'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位" prop="maramaxdimUom">
              <el-input clearable v-model="form.maramaxdimUom" :placeholder="$t('btn.enter')+'计量单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大高度 " prop="maraMAXH">
              <el-input clearable v-model="form.maraMAXH" :placeholder="$t('btn.enter')+'最大高度 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大长度 " prop="maraMAXL">
              <el-input clearable v-model="form.maraMAXL" :placeholder="$t('btn.enter')+'最大长度 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业领域" prop="maraMBRSH">
              <el-input clearable v-model="form.maraMBRSH" :placeholder="$t('btn.enter')+'行业领域'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料条件管理" prop="maraMCOND">
              <el-input clearable v-model="form.maraMCOND" :placeholder="$t('btn.enter')+'物料条件管理'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="maraMEABM">
              <el-input clearable v-model="form.maraMEABM" :placeholder="$t('btn.enter')+'单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中间" prop="maraMEDIUM">
              <el-input clearable v-model="form.maraMEDIUM" :placeholder="$t('btn.enter')+'中间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="maraMEINS">
              <el-input clearable v-model="form.maraMEINS" :placeholder="$t('btn.enter')+'基本单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料运输组 " prop="maraMFRGR">
              <el-input clearable v-model="form.maraMFRGR" :placeholder="$t('btn.enter')+'物料运输组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="maraMFRNR">
              <el-input clearable v-model="form.maraMFRNR" :placeholder="$t('btn.enter')+'制造商'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商零件编号" prop="maraMFRPN">
              <el-input clearable v-model="form.maraMFRPN" :placeholder="$t('btn.enter')+'制造商零件编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总货架寿命 " prop="maraMHDHB">
              <el-input clearable v-model="form.maraMHDHB" :placeholder="$t('btn.enter')+'总货架寿命 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓储 %" prop="maraMHDLP">
              <el-input clearable v-model="form.maraMHDLP" :placeholder="$t('btn.enter')+'仓储 %'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="剩余货架寿命" prop="maraMHDRZ">
              <el-input clearable v-model="form.maraMHDRZ" :placeholder="$t('btn.enter')+'剩余货架寿命'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="含空BOM" prop="maraMLGUT">
              <el-input clearable v-model="form.maraMLGUT" :placeholder="$t('btn.enter')+'含空BOM'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商部件参数文" prop="maraMPROF">
              <el-input clearable v-model="form.maraMPROF" :placeholder="$t('btn.enter')+'制造商部件参数文'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨工厂物料状态" prop="maraMSTAE">
              <el-input clearable v-model="form.maraMSTAE" :placeholder="$t('btn.enter')+'跨工厂物料状态'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨分销链状态 " prop="maraMSTAV">
              <el-input clearable v-model="form.maraMSTAV" :placeholder="$t('btn.enter')+'跨分销链状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始期 " prop="maraMSTDE">
              <el-date-picker clearable v-model="form.maraMSTDE" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效从 " prop="maraMSTDV">
              <el-date-picker clearable v-model="form.maraMSTDV" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类型" prop="maraMTART">
              <el-input clearable v-model="form.maraMTART" :placeholder="$t('btn.enter')+'物料类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="普通项目类别组" prop="maramtposMara">
              <el-input clearable v-model="form.maramtposMara" :placeholder="$t('btn.enter')+'普通项目类别组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业标准描述" prop="maraNORMT">
              <el-input clearable v-model="form.maraNORMT" :placeholder="$t('btn.enter')+'行业标准描述'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折扣类型" prop="maraNRFHG">
              <el-input clearable v-model="form.maraNRFHG" :placeholder="$t('btn.enter')+'折扣类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="NIIN" prop="maraNSNID">
              <el-input clearable v-model="form.maraNSNID" :placeholder="$t('btn.enter')+'NIIN'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净重 " prop="maraNTGEW">
              <el-input clearable v-model="form.maraNTGEW" :placeholder="$t('btn.enter')+'净重 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN 类别" prop="maraNUMTP">
              <el-input clearable v-model="form.maraNUMTP" :placeholder="$t('btn.enter')+'EAN 类别'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Packaging Code" prop="maraPACKCODE">
              <el-input clearable v-model="form.maraPACKCODE" :placeholder="$t('btn.enter')+'Packaging Code'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="链编号 " prop="maraPICNUM">
              <UploadImage clearable v-model="form.maraPICNUM" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可偷窃的" prop="maraPILFERABLE">
              <el-input clearable v-model="form.maraPILFERABLE" :placeholder="$t('btn.enter')+'可偷窃的'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格标记类型" prop="maraPLGTP">
              <el-input clearable v-model="form.maraPLGTP" :placeholder="$t('btn.enter')+'价格标记类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参考物料 " prop="maraPMATA">
              <el-input clearable v-model="form.maraPMATA" :placeholder="$t('btn.enter')+'定价参考物料 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品层次" prop="maraPRDHA">
              <el-input clearable v-model="form.maraPRDHA" :placeholder="$t('btn.enter')+'产品层次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="DG标识参数文件" prop="maraPROFL">
              <el-input clearable v-model="form.maraPROFL" :placeholder="$t('btn.enter')+'DG标识参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品成分" prop="maraPRZUS">
              <el-input clearable v-model="form.maraPRZUS" :placeholder="$t('btn.enter')+'产品成分'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表格名 " prop="marapsSmartform">
              <el-input clearable v-model="form.marapsSmartform" :placeholder="$t('btn.enter')+'表格名 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态 " prop="maraPSTAT">
              <el-input clearable v-model="form.maraPSTAT" :placeholder="$t('btn.enter')+'维护状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="质量检查组" prop="maraQGRP">
              <el-input clearable v-model="form.maraQGRP" :placeholder="$t('btn.enter')+'质量检查组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM 采购" prop="maraQMPUR">
              <el-input clearable v-model="form.maraQMPUR" :placeholder="$t('btn.enter')+'QM 采购'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隔离期间" prop="maraQQTIME">
              <el-input clearable v-model="form.maraQQTIME" :placeholder="$t('btn.enter')+'隔离期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时间单位" prop="maraQQTIMEUOM">
              <el-input clearable v-model="form.maraQQTIMEUOM" :placeholder="$t('btn.enter')+'时间单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存储条件" prop="maraRAUBE">
              <el-input clearable v-model="form.maraRAUBE" :placeholder="$t('btn.enter')+'存储条件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别参数文件" prop="maraRBNRM">
              <el-input clearable v-model="form.maraRBNRM" :placeholder="$t('btn.enter')+'类别参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入规则" prop="maraRDMHD">
              <el-input clearable v-model="form.maraRDMHD" :placeholder="$t('btn.enter')+'舍入规则'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="返回代码" prop="maraRETDELC">
              <el-input clearable v-model="form.maraRETDELC" :placeholder="$t('btn.enter')+'返回代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装的参考物料" prop="maraRMATP">
              <el-input clearable v-model="form.maraRMATP" :placeholder="$t('btn.enter')+'包装的参考物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季度年 " prop="maraSAISJ">
              <el-input clearable v-model="form.maraSAISJ" :placeholder="$t('btn.enter')+'季度年 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季节" prop="maraSAISO">
              <el-input clearable v-model="form.maraSAISO" :placeholder="$t('btn.enter')+'季节'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="展开" prop="maraSAITY">
              <el-input clearable v-model="form.maraSAITY" :placeholder="$t('btn.enter')+'展开'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般可配置物料" prop="maraSATNR">
              <el-input clearable v-model="form.maraSATNR" :placeholder="$t('btn.enter')+'一般可配置物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号参数文件" prop="maraSERIAL">
              <el-input clearable v-model="form.maraSERIAL" :placeholder="$t('btn.enter')+'序列号参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列化层次 " prop="maraSERLV">
              <el-input clearable v-model="form.maraSERLV" :placeholder="$t('btn.enter')+'序列化层次 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段策略" prop="marasgtCovsa">
              <el-input clearable v-model="form.marasgtCovsa" :placeholder="$t('btn.enter')+'分段策略'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段结构" prop="marasgtCsgr">
              <el-input clearable v-model="form.marasgtCsgr" :placeholder="$t('btn.enter')+'分段结构'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段相关" prop="marasgtRel">
              <el-input clearable v-model="form.marasgtRel" :placeholder="$t('btn.enter')+'分段相关'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段范围" prop="marasgtScope">
              <el-input clearable v-model="form.marasgtScope" :placeholder="$t('btn.enter')+'分段范围'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段状态 " prop="marasgtStat">
              <el-input clearable v-model="form.marasgtStat" :placeholder="$t('btn.enter')+'分段状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主尺寸 " prop="maraSIZE1">
              <el-input clearable v-model="form.maraSIZE1" :placeholder="$t('btn.enter')+'主尺寸 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="marasize1Atinn">
              <el-input clearable v-model="form.marasize1Atinn" :placeholder="$t('btn.enter')+'内部特性 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="次尺寸 " prop="maraSIZE2">
              <el-input clearable v-model="form.maraSIZE2" :placeholder="$t('btn.enter')+'次尺寸 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="marasize2Atinn">
              <el-input clearable v-model="form.marasize2Atinn" :placeholder="$t('btn.enter')+'内部特性 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过期日期" prop="marasledBbd">
              <el-input clearable v-model="form.marasledBbd" :placeholder="$t('btn.enter')+'过期日期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组 " prop="maraSPART">
              <el-input clearable v-model="form.maraSPART" :placeholder="$t('btn.enter')+'产品组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参数文件" prop="maraSPROF">
              <el-input clearable v-model="form.maraSPROF" :placeholder="$t('btn.enter')+'定价参数文件'" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="堆栈因子" prop="maraSTFAK">
              <el-input clearable v-model="form.maraSTFAK" :placeholder="$t('btn.enter')+'堆栈因子'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料号 " prop="maraSTOFF">
              <el-input clearable v-model="form.maraSTOFF" :placeholder="$t('btn.enter')+'危险物料号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税收分类" prop="maraTAKLV">
              <el-input clearable v-model="form.maraTAKLV" :placeholder="$t('btn.enter')+'税收分类'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变皮重" prop="maratareVar">
              <el-input clearable v-model="form.maratareVar" :placeholder="$t('btn.enter')+'可变皮重'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="温度" prop="maraTEMPB">
              <el-input clearable v-model="form.maraTEMPB" :placeholder="$t('btn.enter')+'温度'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="纺织组分活动" prop="maratextileCompInd">
              <el-input clearable v-model="form.maratextileCompInd" :placeholder="$t('btn.enter')+'纺织组分活动'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输组 " prop="maraTRAGR">
              <el-input clearable v-model="form.maraTRAGR" :placeholder="$t('btn.enter')+'运输组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变的订单单位" prop="maraVABME">
              <el-input clearable v-model="form.maraVABME" :placeholder="$t('btn.enter')+'可变的订单单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料类型" prop="maraVHART">
              <el-input clearable v-model="form.maraVHART" :placeholder="$t('btn.enter')+'包装物料类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="maraVOLEH">
              <el-input clearable v-model="form.maraVOLEH" :placeholder="$t('btn.enter')+'体积单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超过体积容差" prop="maraVOLTO">
              <el-input clearable v-model="form.maraVOLTO" :placeholder="$t('btn.enter')+'超过体积容差'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="业务量 " prop="maraVOLUM">
              <el-input clearable v-model="form.maraVOLUM" :placeholder="$t('btn.enter')+'业务量 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="比较价格单位" prop="maraVPREH">
              <el-input clearable v-model="form.maraVPREH" :placeholder="$t('btn.enter')+'比较价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完整状态 " prop="maraVPSTA">
              <el-input clearable v-model="form.maraVPSTA" :placeholder="$t('btn.enter')+'完整状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始接受" prop="maraWEORA">
              <el-input clearable v-model="form.maraWEORA" :placeholder="$t('btn.enter')+'原始接受'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GR单数量 " prop="maraWESCH">
              <el-input clearable v-model="form.maraWESCH" :placeholder="$t('btn.enter')+'GR单数量 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库物料组 " prop="maraWHMATGR">
              <el-input clearable v-model="form.maraWHMATGR" :placeholder="$t('btn.enter')+'仓库物料组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库存储条件" prop="maraWHSTC">
              <el-input clearable v-model="form.maraWHSTC" :placeholder="$t('btn.enter')+'仓库存储条件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本物料" prop="maraWRKST">
              <el-input clearable v-model="form.maraWRKST" :placeholder="$t('btn.enter')+'基本物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理需求 " prop="maraXCHPF">
              <el-input clearable v-model="form.maraXCHPF" :placeholder="$t('btn.enter')+'批次管理需求 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="需要批量记录 " prop="maraXGCHP">
              <el-input clearable v-model="form.maraXGCHP" :placeholder="$t('btn.enter')+'需要批量记录 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="maraZEIAR">
              <el-input clearable v-model="form.maraZEIAR" :placeholder="$t('btn.enter')+'凭证类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页面大小" prop="maraZEIFO">
              <el-input clearable v-model="form.maraZEIFO" :placeholder="$t('btn.enter')+'页面大小'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证" prop="maraZEINR">
              <el-input clearable v-model="form.maraZEINR" :placeholder="$t('btn.enter')+'凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证版本" prop="maraZEIVR">
              <el-input clearable v-model="form.maraZEIVR" :placeholder="$t('btn.enter')+'凭证版本'" />
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

          <el-col :lg="12">
            <el-form-item label="Remark" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'Remark'" />
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

<script setup name="mmmara">
// 引入 mmmara操作方法
import { listMmMara, addMmMara, delMmMara, updateMmMara, getMmMara, 
 
 } 
from '@/api/material/mmmara.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中maraID数组数组
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
  sort: 'MaraMATNR',
  sortType: 'asc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'maraID', label: 'ID主键' },
  { visible: true, prop: 'maraADPROF', label: '调整参数文件' },
  { visible: true, prop: 'maraAEKLK', label: '净改变成本核算' },
  { visible: true, prop: 'maraAENAM', label: '更改者 ' },
  { visible: true, prop: 'maraAESZN', label: '文档变更号 ' },
  { visible: true, prop: 'maraallowPmatIgno', label: '允许的变式价格' },
  { visible: true, prop: 'maraanimalOrigin', label: '动物源 ' },
  { visible: true, prop: 'maraANP', label: 'ANP Code' },
  { visible: false, prop: 'maraATTYP', label: '物料类别' },
  { visible: false, prop: 'maraBBTYP', label: '分类清单类型' },
  { visible: false, prop: 'maraBEGRU', label: '权限组 ' },
  { visible: false, prop: 'maraBEHVO', label: '容器' },
  { visible: false, prop: 'maraBFLME', label: '后勤变量' },
  { visible: false, prop: 'maraBISMT', label: '旧物料号' },
  { visible: false, prop: 'maraBLANZ', label: '页数' },
  { visible: false, prop: 'maraBLATT', label: '页号' },
  { visible: false, prop: 'maraBMATN', label: '内部物料编号' },
  { visible: false, prop: 'marabrandId', label: '商标' },
  { visible: false, prop: 'maraBREIT', label: '宽度' },
  { visible: false, prop: 'maraBRGEW', label: '毛重' },
  { visible: false, prop: 'maraBSTAT', label: '创建状态 ' },
  { visible: false, prop: 'maraBSTME', label: '订单单位' },
  { visible: false, prop: 'maraBWSCL', label: '货源' },
  { visible: false, prop: 'maraBWVOR', label: '采购规则' },
  { visible: false, prop: 'maraCADKZ', label: 'CAD 标识' },
  { visible: false, prop: 'maracareCode', label: '护理代码' },
  { visible: false, prop: 'maraCMETH', label: '转换方法' },
  { visible: false, prop: 'maraCMREL', label: 'CM 相关' },
  { visible: false, prop: 'maraCOLOR', label: '颜色' },
  { visible: false, prop: 'maracolorAtinn', label: '内部特性 ' },
  { visible: false, prop: 'maraCOMMODITY', label: '实物商品' },
  { visible: false, prop: 'maraCOMPL', label: '完成水平' },
  { visible: false, prop: 'maraCUOBF', label: '内部对象号 ' },
  { visible: false, prop: 'maraCWQPROC', label: 'CW 参数文件' },
  { visible: false, prop: 'maraCWQREL', label: '称重物料相关' },
  { visible: false, prop: 'maraCWQTOLGR', label: 'CW 容差组 ' },
  { visible: false, prop: 'maraDATAB', label: '有效起始日 ' },
  { visible: false, prop: 'maradgPackStatus', label: '危险品包装状态' },
  { visible: false, prop: 'maraDISST', label: '低层代码' },
  { visible: false, prop: 'maraEAN11', label: 'EAN/UPC' },
  { visible: false, prop: 'maraEANNR', label: 'EAN 号 ' },
  { visible: false, prop: 'maraEKWSL', label: '采购值代码 ' },
  { visible: false, prop: 'maraENTAR', label: '取消激活字段 ' },
  { visible: false, prop: 'maraERGEI', label: '重量单位' },
  { visible: false, prop: 'maraERGEW', label: '允许的包装重量' },
  { visible: false, prop: 'maraERNAM', label: '创建者 ' },
  { visible: false, prop: 'maraERSDA', label: '创建日期' },
  { visible: false, prop: 'maraERVOE', label: '体积单位' },
  { visible: false, prop: 'maraERVOL', label: '允许的体积 ' },
  { visible: false, prop: 'maraETIAG', label: '给物料组加标签' },
  { visible: false, prop: 'maraETIAR', label: '标号类型' },
  { visible: false, prop: 'maraETIFO', label: '标签格式' },
  { visible: false, prop: 'maraEXTWG', label: '外部物料组 ' },
  { visible: false, prop: 'maraFASHGRD', label: '时装等级' },
  { visible: false, prop: 'maraFERTH', label: '生产/检验备忘录' },
  { visible: false, prop: 'marafiberCode1', label: '组件1' },
  { visible: false, prop: 'marafiberCode2', label: '组件2' },
  { visible: false, prop: 'marafiberCode3', label: '组件3' },
  { visible: false, prop: 'marafiberCode4', label: '组件4' },
  { visible: false, prop: 'marafiberCode5', label: '组件5' },
  { visible: false, prop: 'marafiberPart1', label: '百分比共享1' },
  { visible: false, prop: 'marafiberPart2', label: '百分比共享2' },
  { visible: false, prop: 'marafiberPart3', label: '百分比共享3' },
  { visible: false, prop: 'marafiberPart4', label: '百分比共享4' },
  { visible: false, prop: 'marafiberPart5', label: '百分比共享5' },
  { visible: false, prop: 'maraFORMT', label: '页格式 ' },
  { visible: false, prop: 'marafreeChar', label: '特性值 ' },
  { visible: false, prop: 'marafshMgAt1', label: 'Fashion 属性 1' },
  { visible: false, prop: 'marafshMgAt2', label: 'Fashion 属性 2' },
  { visible: false, prop: 'marafshMgAt3', label: 'Fashion 属性 3' },
  { visible: false, prop: 'marafshScMid', label: '物料转换标识' },
  { visible: false, prop: 'marafshSeaim', label: '库存管理中激活季节' },
  { visible: false, prop: 'marafshSealv', label: '季节使用' },
  { visible: false, prop: 'maraFUELG', label: '最大层次 ' },
  { visible: false, prop: 'maragdsRelevant', label: 'GDS 相关' },
  { visible: false, prop: 'maraGENNR', label: '一般物料 ' },
  { visible: false, prop: 'maraGEWEI', label: '重量单位' },
  { visible: false, prop: 'maraGEWTO', label: '超重量容差 ' },
  { visible: false, prop: 'maraGROES', label: '大小/量纲' },
  { visible: false, prop: 'maragtinVariant', label: 'EAN变式' },
  { visible: false, prop: 'maraHAZMAT', label: '危险物料' },
  { visible: false, prop: 'maraHERKL', label: '原产地国' },
  { visible: false, prop: 'maraHNDLCODE', label: '处理标识' },
  { visible: false, prop: 'maraHOEHE', label: '高度' },
  { visible: false, prop: 'maraHUTYP', label: '处理单位类型' },
  { visible: false, prop: 'marahutypDflt', label: '标准处理单位类' },
  { visible: false, prop: 'maraIHIVI', label: '高粘性的' },
  { visible: false, prop: 'maraILOOS', label: '以大批/液体' },
  { visible: false, prop: 'maraIMATN', label: '完全互换组 ' },
  { visible: false, prop: 'maraINHAL', label: '净内容' },
  { visible: false, prop: 'maraINHBR', label: '毛内容 ' },
  { visible: false, prop: 'maraINHME', label: '内容单位' },
  { visible: false, prop: 'maraIPMIPPRODUCT', label: '知识产权' },
  { visible: false, prop: 'maraIPRKZ', label: '期间标识' },
  { visible: false, prop: 'maraKOSCH', label: '产品分配' },
  { visible: false, prop: 'maraKUNNR', label: '竞争者 ' },
  { visible: false, prop: 'maraKZEFF', label: '参数有效值· ' },
  { visible: false, prop: 'maraKZGVH', label: '密闭的 ' },
  { visible: false, prop: 'maraKZKFG', label: '可配置 ' },
  { visible: false, prop: 'maraKZKUP', label: '联产品 ' },
  { visible: false, prop: 'maraKZNFM', label: '后继的物料 ' },
  { visible: false, prop: 'maraKZREV', label: '修订等级' },
  { visible: false, prop: 'maraKZUMW', label: '环境是相关的' },
  { visible: false, prop: 'maraKZWSM', label: '测量单位用法' },
  { visible: false, prop: 'maraLABOR', label: '实验室/办公室 ' },
  { visible: false, prop: 'maraLAEDA', label: '上次更改' },
  { visible: false, prop: 'maraLAENG', label: '长度' },
  { visible: false, prop: 'maraLIQDT', label: '有效至 ' },
  { visible: false, prop: 'maraloglevReto', label: '退货到后勤等级' },
  { visible: false, prop: 'maraLOGUNIT', label: '后勤计量单位' },
  { visible: false, prop: 'maraLVORM', label: '集团级的 DF' },
  { visible: false, prop: 'maraMAGRV', label: '物料组包装物料' },
  { visible: false, prop: 'maraMANDT', label: '集团' },
  { visible: false, prop: 'maraMATFI', label: '物料被锁定 ' },
  { visible: false, prop: 'maraMATKL', label: '物料组 ' },
  { visible: false, prop: 'maraMATNR', label: '物料' },
  { visible: false, prop: 'maraMAXB', label: '最大包宽度' },
  { visible: false, prop: 'maraMAXC', label: '最大容量 ' },
  { visible: false, prop: 'maramaxcTol', label: '超过容量容差' },
  { visible: false, prop: 'maramaxdimUom', label: '计量单位' },
  { visible: false, prop: 'maraMAXH', label: '最大高度 ' },
  { visible: false, prop: 'maraMAXL', label: '最大长度 ' },
  { visible: false, prop: 'maraMBRSH', label: '行业领域' },
  { visible: false, prop: 'maraMCOND', label: '物料条件管理' },
  { visible: false, prop: 'maraMEABM', label: '单位' },
  { visible: false, prop: 'maraMEDIUM', label: '中间' },
  { visible: false, prop: 'maraMEINS', label: '基本单位' },
  { visible: false, prop: 'maraMFRGR', label: '物料运输组 ' },
  { visible: false, prop: 'maraMFRNR', label: '制造商' },
  { visible: false, prop: 'maraMFRPN', label: '制造商零件编号' },
  { visible: false, prop: 'maraMHDHB', label: '总货架寿命 ' },
  { visible: false, prop: 'maraMHDLP', label: '仓储 %' },
  { visible: false, prop: 'maraMHDRZ', label: '剩余货架寿命' },
  { visible: false, prop: 'maraMLGUT', label: '含空BOM' },
  { visible: false, prop: 'maraMPROF', label: '制造商部件参数文' },
  { visible: false, prop: 'maraMSTAE', label: '跨工厂物料状态' },
  { visible: false, prop: 'maraMSTAV', label: '跨分销链状态 ' },
  { visible: false, prop: 'maraMSTDE', label: '有效起始期 ' },
  { visible: false, prop: 'maraMSTDV', label: '有效从 ' },
  { visible: false, prop: 'maraMTART', label: '物料类型' },
  { visible: false, prop: 'maramtposMara', label: '普通项目类别组' },
  { visible: false, prop: 'maraNORMT', label: '行业标准描述' },
  { visible: false, prop: 'maraNRFHG', label: '折扣类型' },
  { visible: false, prop: 'maraNSNID', label: 'NIIN' },
  { visible: false, prop: 'maraNTGEW', label: '净重 ' },
  { visible: false, prop: 'maraNUMTP', label: 'EAN 类别' },
  { visible: false, prop: 'maraPACKCODE', label: 'Packaging Code' },
  { visible: false, prop: 'maraPICNUM', label: '链编号 ' },
  { visible: false, prop: 'maraPILFERABLE', label: '可偷窃的' },
  { visible: false, prop: 'maraPLGTP', label: '价格标记类型' },
  { visible: false, prop: 'maraPMATA', label: '定价参考物料 ' },
  { visible: false, prop: 'maraPRDHA', label: '产品层次' },
  { visible: false, prop: 'maraPROFL', label: 'DG标识参数文件' },
  { visible: false, prop: 'maraPRZUS', label: '产品成分' },
  { visible: false, prop: 'marapsSmartform', label: '表格名 ' },
  { visible: false, prop: 'maraPSTAT', label: '维护状态 ' },
  { visible: false, prop: 'maraQGRP', label: '质量检查组' },
  { visible: false, prop: 'maraQMPUR', label: 'QM 采购' },
  { visible: false, prop: 'maraQQTIME', label: '隔离期间' },
  { visible: false, prop: 'maraQQTIMEUOM', label: '时间单位' },
  { visible: false, prop: 'maraRAUBE', label: '存储条件' },
  { visible: false, prop: 'maraRBNRM', label: '类别参数文件' },
  { visible: false, prop: 'maraRDMHD', label: '舍入规则' },
  { visible: false, prop: 'maraRETDELC', label: '返回代码' },
  { visible: false, prop: 'maraRMATP', label: '包装的参考物料' },
  { visible: false, prop: 'maraSAISJ', label: '季度年 ' },
  { visible: false, prop: 'maraSAISO', label: '季节' },
  { visible: false, prop: 'maraSAITY', label: '展开' },
  { visible: false, prop: 'maraSATNR', label: '一般可配置物料' },
  { visible: false, prop: 'maraSERIAL', label: '序列号参数文件' },
  { visible: false, prop: 'maraSERLV', label: '序列化层次 ' },
  { visible: false, prop: 'marasgtCovsa', label: '分段策略' },
  { visible: false, prop: 'marasgtCsgr', label: '分段结构' },
  { visible: false, prop: 'marasgtRel', label: '分段相关' },
  { visible: false, prop: 'marasgtScope', label: '分段范围' },
  { visible: false, prop: 'marasgtStat', label: '分段状态 ' },
  { visible: false, prop: 'maraSIZE1', label: '主尺寸 ' },
  { visible: false, prop: 'marasize1Atinn', label: '内部特性 ' },
  { visible: false, prop: 'maraSIZE2', label: '次尺寸 ' },
  { visible: false, prop: 'marasize2Atinn', label: '内部特性 ' },
  { visible: false, prop: 'marasledBbd', label: '过期日期' },
  { visible: false, prop: 'maraSPART', label: '产品组 ' },
  { visible: false, prop: 'maraSPROF', label: '定价参数文件' },
  { visible: false, prop: 'maraSTFAK', label: '堆栈因子' },
  { visible: false, prop: 'maraSTOFF', label: '危险物料号 ' },
  { visible: false, prop: 'maraTAKLV', label: '税收分类' },
  { visible: false, prop: 'maratareVar', label: '可变皮重' },
  { visible: false, prop: 'maraTEMPB', label: '温度' },
  { visible: false, prop: 'maratextileCompInd', label: '纺织组分活动' },
  { visible: false, prop: 'maraTRAGR', label: '运输组 ' },
  { visible: false, prop: 'maraVABME', label: '可变的订单单位' },
  { visible: false, prop: 'maraVHART', label: '包装物料类型' },
  { visible: false, prop: 'maraVOLEH', label: '体积单位' },
  { visible: false, prop: 'maraVOLTO', label: '超过体积容差' },
  { visible: false, prop: 'maraVOLUM', label: '业务量 ' },
  { visible: false, prop: 'maraVPREH', label: '比较价格单位' },
  { visible: false, prop: 'maraVPSTA', label: '完整状态 ' },
  { visible: false, prop: 'maraWEORA', label: '原始接受' },
  { visible: false, prop: 'maraWESCH', label: 'GR单数量 ' },
  { visible: false, prop: 'maraWHMATGR', label: '仓库物料组 ' },
  { visible: false, prop: 'maraWHSTC', label: '仓库存储条件' },
  { visible: false, prop: 'maraWRKST', label: '基本物料' },
  { visible: false, prop: 'maraXCHPF', label: '批次管理需求 ' },
  { visible: false, prop: 'maraXGCHP', label: '需要批量记录 ' },
  { visible: false, prop: 'maraZEIAR', label: '凭证类型' },
  { visible: false, prop: 'maraZEIFO', label: '页面大小' },
  { visible: false, prop: 'maraZEINR', label: '凭证' },
  { visible: false, prop: 'maraZEIVR', label: '凭证版本' },
  { visible: false, prop: 'uDF01', label: 'UDF01' },
  { visible: false, prop: 'uDF02', label: 'UDF02' },
  { visible: false, prop: 'uDF03', label: 'UDF03' },
  { visible: false, prop: 'uDF04', label: 'UDF04' },
  { visible: false, prop: 'uDF05', label: 'UDF05' },
  { visible: false, prop: 'uDF06', label: 'UDF06' },
  { visible: false, prop: 'uDF51', label: 'UDF51' },
  { visible: false, prop: 'uDF52', label: 'UDF52' },
  { visible: false, prop: 'uDF53', label: 'UDF53' },
  { visible: false, prop: 'uDF54', label: 'UDF54' },
  { visible: false, prop: 'uDF55', label: 'UDF55' },
  { visible: false, prop: 'uDF56', label: 'UDF56' },
  { visible: false, prop: 'remark', label: 'Remark' },
])
  // 总条数
const total = ref(0)
  // 常规物料数据表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]
//字典定义
//获取常规物料数据表记录数据
function getList(){
  loading.value = true
  listMmMara(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.maraID);
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
    maraAENAM: [{ required: true, message: "更改者 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraATTYP: [{ required: true, message: "物料类别"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraBREIT: [{ required: true, message: "宽度"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraBRGEW: [{ required: true, message: "毛重"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraERGEW: [{ required: true, message: "允许的包装重量"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraERNAM: [{ required: true, message: "创建者 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraERSDA: [{ required: true, message: "创建日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraERVOL: [{ required: true, message: "允许的体积 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraFUELG: [{ required: true, message: "最大层次 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraGEWTO: [{ required: true, message: "超重量容差 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraHOEHE: [{ required: true, message: "高度"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraINHAL: [{ required: true, message: "净内容"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraINHBR: [{ required: true, message: "毛内容 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraLAENG: [{ required: true, message: "长度"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMATKL: [{ required: true, message: "物料组 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMATNR: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMAXB: [{ required: true, message: "最大包宽度"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMAXC: [{ required: true, message: "最大容量 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maramaxcTol: [{ required: true, message: "超过容量容差"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMAXH: [{ required: true, message: "最大高度 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMAXL: [{ required: true, message: "最大长度 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMBRSH: [{ required: true, message: "行业领域"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMEINS: [{ required: true, message: "基本单位"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMHDHB: [{ required: true, message: "总货架寿命 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMHDLP: [{ required: true, message: "仓储 %"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMHDRZ: [{ required: true, message: "剩余货架寿命"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraMTART: [{ required: true, message: "物料类型"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraNTGEW: [{ required: true, message: "净重 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraQQTIME: [{ required: true, message: "隔离期间"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraSTFAK: [{ required: true, message: "堆栈因子"+proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    maraVOLTO: [{ required: true, message: "超过体积容差"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraVOLUM: [{ required: true, message: "业务量 "+proxy.$t('btn.empty'), trigger: "blur" }],
    maraVPREH: [{ required: true, message: "比较价格单位"+proxy.$t('btn.empty'), trigger: "blur" }],
    maraWESCH: [{ required: true, message: "GR单数量 "+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF51: [{ required: true, message: "UDF51"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF52: [{ required: true, message: "UDF52"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF53: [{ required: true, message: "UDF53"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF54: [{ required: true, message: "UDF54"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF55: [{ required: true, message: "UDF55"+proxy.$t('btn.empty'), trigger: "blur" }],
    uDF56: [{ required: true, message: "UDF56"+proxy.$t('btn.empty'), trigger: "blur" }],
    isDeleted: [{ required: true, message: "IsDeleted"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 危险品包装状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    maradgPackStatusOptions: [],
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
    maraADPROF: undefined,
    maraAEKLK: undefined,
    maraAENAM: undefined,
    maraAESZN: undefined,
    maraallowPmatIgno: undefined,
    maraanimalOrigin: undefined,
    maraANP: undefined,
    maraATTYP: undefined,
    maraBBTYP: undefined,
    maraBEGRU: undefined,
    maraBEHVO: undefined,
    maraBFLME: undefined,
    maraBISMT: undefined,
    maraBLANZ: undefined,
    maraBLATT: undefined,
    maraBMATN: undefined,
    marabrandId: undefined,
    maraBREIT: undefined,
    maraBRGEW: undefined,
    maraBSTAT: undefined,
    maraBSTME: undefined,
    maraBWSCL: undefined,
    maraBWVOR: undefined,
    maraCADKZ: undefined,
    maracareCode: undefined,
    maraCMETH: undefined,
    maraCMREL: undefined,
    maraCOLOR: undefined,
    maracolorAtinn: undefined,
    maraCOMMODITY: undefined,
    maraCOMPL: undefined,
    maraCUOBF: undefined,
    maraCWQPROC: undefined,
    maraCWQREL: undefined,
    maraCWQTOLGR: undefined,
    maraDATAB: undefined,
    maradgPackStatus: undefined,
    maraDISST: undefined,
    maraEAN11: undefined,
    maraEANNR: undefined,
    maraEKWSL: undefined,
    maraENTAR: undefined,
    maraERGEI: undefined,
    maraERGEW: undefined,
    maraERNAM: undefined,
    maraERSDA: undefined,
    maraERVOE: undefined,
    maraERVOL: undefined,
    maraETIAG: undefined,
    maraETIAR: undefined,
    maraETIFO: undefined,
    maraEXTWG: undefined,
    maraFASHGRD: undefined,
    maraFERTH: undefined,
    marafiberCode1: undefined,
    marafiberCode2: undefined,
    marafiberCode3: undefined,
    marafiberCode4: undefined,
    marafiberCode5: undefined,
    marafiberPart1: undefined,
    marafiberPart2: undefined,
    marafiberPart3: undefined,
    marafiberPart4: undefined,
    marafiberPart5: undefined,
    maraFORMT: undefined,
    marafreeChar: undefined,
    marafshMgAt1: undefined,
    marafshMgAt2: undefined,
    marafshMgAt3: undefined,
    marafshScMid: undefined,
    marafshSeaim: undefined,
    marafshSealv: undefined,
    maraFUELG: undefined,
    maragdsRelevant: undefined,
    maraGENNR: undefined,
    maraGEWEI: undefined,
    maraGEWTO: undefined,
    maraGROES: undefined,
    maragtinVariant: undefined,
    maraHAZMAT: undefined,
    maraHERKL: undefined,
    maraHNDLCODE: undefined,
    maraHOEHE: undefined,
    maraHUTYP: undefined,
    marahutypDflt: undefined,
    maraIHIVI: undefined,
    maraILOOS: undefined,
    maraIMATN: undefined,
    maraINHAL: undefined,
    maraINHBR: undefined,
    maraINHME: undefined,
    maraIPMIPPRODUCT: undefined,
    maraIPRKZ: undefined,
    maraKOSCH: undefined,
    maraKUNNR: undefined,
    maraKZEFF: undefined,
    maraKZGVH: undefined,
    maraKZKFG: undefined,
    maraKZKUP: undefined,
    maraKZNFM: undefined,
    maraKZREV: undefined,
    maraKZUMW: undefined,
    maraKZWSM: undefined,
    maraLABOR: undefined,
    maraLAEDA: undefined,
    maraLAENG: undefined,
    maraLIQDT: undefined,
    maraloglevReto: undefined,
    maraLOGUNIT: undefined,
    maraLVORM: undefined,
    maraMAGRV: undefined,
    maraMANDT: undefined,
    maraMATFI: undefined,
    maraMATKL: undefined,
    maraMATNR: undefined,
    maraMAXB: undefined,
    maraMAXC: undefined,
    maramaxcTol: undefined,
    maramaxdimUom: undefined,
    maraMAXH: undefined,
    maraMAXL: undefined,
    maraMBRSH: undefined,
    maraMCOND: undefined,
    maraMEABM: undefined,
    maraMEDIUM: undefined,
    maraMEINS: undefined,
    maraMFRGR: undefined,
    maraMFRNR: undefined,
    maraMFRPN: undefined,
    maraMHDHB: undefined,
    maraMHDLP: undefined,
    maraMHDRZ: undefined,
    maraMLGUT: undefined,
    maraMPROF: undefined,
    maraMSTAE: undefined,
    maraMSTAV: undefined,
    maraMSTDE: undefined,
    maraMSTDV: undefined,
    maraMTART: undefined,
    maramtposMara: undefined,
    maraNORMT: undefined,
    maraNRFHG: undefined,
    maraNSNID: undefined,
    maraNTGEW: undefined,
    maraNUMTP: undefined,
    maraPACKCODE: undefined,
    maraPICNUM: undefined,
    maraPILFERABLE: undefined,
    maraPLGTP: undefined,
    maraPMATA: undefined,
    maraPRDHA: undefined,
    maraPROFL: undefined,
    maraPRZUS: undefined,
    marapsSmartform: undefined,
    maraPSTAT: undefined,
    maraQGRP: undefined,
    maraQMPUR: undefined,
    maraQQTIME: undefined,
    maraQQTIMEUOM: undefined,
    maraRAUBE: undefined,
    maraRBNRM: undefined,
    maraRDMHD: undefined,
    maraRETDELC: undefined,
    maraRMATP: undefined,
    maraSAISJ: undefined,
    maraSAISO: undefined,
    maraSAITY: undefined,
    maraSATNR: undefined,
    maraSERIAL: undefined,
    maraSERLV: undefined,
    marasgtCovsa: undefined,
    marasgtCsgr: undefined,
    marasgtRel: undefined,
    marasgtScope: undefined,
    marasgtStat: undefined,
    maraSIZE1: undefined,
    marasize1Atinn: undefined,
    maraSIZE2: undefined,
    marasize2Atinn: undefined,
    marasledBbd: undefined,
    maraSPART: undefined,
    maraSPROF: undefined,
    maraSTFAK: undefined,
    maraSTOFF: undefined,
    maraTAKLV: undefined,
    maratareVar: undefined,
    maraTEMPB: undefined,
    maratextileCompInd: undefined,
    maraTRAGR: undefined,
    maraVABME: undefined,
    maraVHART: undefined,
    maraVOLEH: undefined,
    maraVOLTO: undefined,
    maraVOLUM: undefined,
    maraVPREH: undefined,
    maraVPSTA: undefined,
    maraWEORA: undefined,
    maraWESCH: undefined,
    maraWHMATGR: undefined,
    maraWHSTC: undefined,
    maraWRKST: undefined,
    maraXCHPF: undefined,
    maraXGCHP: undefined,
    maraZEIAR: undefined,
    maraZEIFO: undefined,
    maraZEINR: undefined,
    maraZEIVR: undefined,
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
    isDeleted: undefined,
    remark: undefined,
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
  const id = row.maraID || ids.value
  getMmMara(id).then((res) => {
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
      if (form.value.maraID != undefined && opertype.value === 2) {
        updateMmMara(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addMmMara(form.value).then((res) => {
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
  const Ids = row.maraID || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delMmMara(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"常规物料数据", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/material/MmMara/export', { ...queryParams })
    })
}

handleQuery()
</script>