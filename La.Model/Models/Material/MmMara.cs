using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 常规物料数据，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("mm_mara")]
    public class MmMara
    {
        /// <summary>
        /// 描述 :ID主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int MaraID { get; set; }

        /// <summary>
        /// 描述 :调整参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraADPROF { get; set; }

        /// <summary>
        /// 描述 :净改变成本核算 
        /// 空值 :true 
        /// </summary>
        public string MaraAEKLK { get; set; }

        /// <summary>
        /// 描述 :更改者  
        /// 空值 :false 
        /// </summary>
        public string MaraAENAM { get; set; }

        /// <summary>
        /// 描述 :文档变更号  
        /// 空值 :true 
        /// </summary>
        public string MaraAESZN { get; set; }

        /// <summary>
        /// 描述 :允许的变式价格 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraALLOW_PMAT_IGNO")]
        public string MaraallowPmatIgno { get; set; }

        /// <summary>
        /// 描述 :动物源  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraANIMAL_ORIGIN")]
        public string MaraanimalOrigin { get; set; }

        /// <summary>
        /// 描述 :ANP Code 
        /// 空值 :true 
        /// </summary>
        public string MaraANP { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// 空值 :false 
        /// </summary>
        public string MaraATTYP { get; set; }

        /// <summary>
        /// 描述 :分类清单类型 
        /// 空值 :true 
        /// </summary>
        public string MaraBBTYP { get; set; }

        /// <summary>
        /// 描述 :权限组  
        /// 空值 :true 
        /// </summary>
        public string MaraBEGRU { get; set; }

        /// <summary>
        /// 描述 :容器 
        /// 空值 :true 
        /// </summary>
        public string MaraBEHVO { get; set; }

        /// <summary>
        /// 描述 :后勤变量 
        /// 空值 :true 
        /// </summary>
        public string MaraBFLME { get; set; }

        /// <summary>
        /// 描述 :旧物料号 
        /// 空值 :true 
        /// </summary>
        public string MaraBISMT { get; set; }

        /// <summary>
        /// 描述 :页数 
        /// 空值 :true 
        /// </summary>
        public string MaraBLANZ { get; set; }

        /// <summary>
        /// 描述 :页号 
        /// 空值 :true 
        /// </summary>
        public string MaraBLATT { get; set; }

        /// <summary>
        /// 描述 :内部物料编号 
        /// 空值 :true 
        /// </summary>
        public string MaraBMATN { get; set; }

        /// <summary>
        /// 描述 :商标 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraBRAND_ID")]
        public string MarabrandId { get; set; }

        /// <summary>
        /// 描述 :宽度 
        /// 空值 :false 
        /// </summary>
        public decimal MaraBREIT { get; set; }

        /// <summary>
        /// 描述 :毛重 
        /// 空值 :false 
        /// </summary>
        public decimal MaraBRGEW { get; set; }

        /// <summary>
        /// 描述 :创建状态  
        /// 空值 :true 
        /// </summary>
        public string MaraBSTAT { get; set; }

        /// <summary>
        /// 描述 :订单单位 
        /// 空值 :true 
        /// </summary>
        public string MaraBSTME { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// 空值 :true 
        /// </summary>
        public string MaraBWSCL { get; set; }

        /// <summary>
        /// 描述 :采购规则 
        /// 空值 :true 
        /// </summary>
        public string MaraBWVOR { get; set; }

        /// <summary>
        /// 描述 :CAD 标识 
        /// 空值 :true 
        /// </summary>
        public string MaraCADKZ { get; set; }

        /// <summary>
        /// 描述 :护理代码 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraCARE_CODE")]
        public string MaracareCode { get; set; }

        /// <summary>
        /// 描述 :转换方法 
        /// 空值 :true 
        /// </summary>
        public string MaraCMETH { get; set; }

        /// <summary>
        /// 描述 :CM 相关 
        /// 空值 :true 
        /// </summary>
        public string MaraCMREL { get; set; }

        /// <summary>
        /// 描述 :颜色 
        /// 空值 :true 
        /// </summary>
        public string MaraCOLOR { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraCOLOR_ATINN")]
        public string MaracolorAtinn { get; set; }

        /// <summary>
        /// 描述 :实物商品 
        /// 空值 :true 
        /// </summary>
        public string MaraCOMMODITY { get; set; }

        /// <summary>
        /// 描述 :完成水平 
        /// 空值 :true 
        /// </summary>
        public string MaraCOMPL { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        public string MaraCUOBF { get; set; }

        /// <summary>
        /// 描述 :CW 参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraCWQPROC { get; set; }

        /// <summary>
        /// 描述 :称重物料相关 
        /// 空值 :true 
        /// </summary>
        public string MaraCWQREL { get; set; }

        /// <summary>
        /// 描述 :CW 容差组  
        /// 空值 :true 
        /// </summary>
        public string MaraCWQTOLGR { get; set; }

        /// <summary>
        /// 描述 :有效起始日  
        /// 空值 :true 
        /// </summary>
        public DateTime? MaraDATAB { get; set; }

        /// <summary>
        /// 描述 :危险品包装状态 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraDG_PACK_STATUS")]
        public string MaradgPackStatus { get; set; }

        /// <summary>
        /// 描述 :低层代码 
        /// 空值 :true 
        /// </summary>
        public string MaraDISST { get; set; }

        /// <summary>
        /// 描述 :EAN/UPC 
        /// 空值 :true 
        /// </summary>
        public string MaraEAN11 { get; set; }

        /// <summary>
        /// 描述 :EAN 号  
        /// 空值 :true 
        /// </summary>
        public string MaraEANNR { get; set; }

        /// <summary>
        /// 描述 :采购值代码  
        /// 空值 :true 
        /// </summary>
        public string MaraEKWSL { get; set; }

        /// <summary>
        /// 描述 :取消激活字段  
        /// 空值 :true 
        /// </summary>
        public string MaraENTAR { get; set; }

        /// <summary>
        /// 描述 :重量单位 
        /// 空值 :true 
        /// </summary>
        public string MaraERGEI { get; set; }

        /// <summary>
        /// 描述 :允许的包装重量 
        /// 空值 :false 
        /// </summary>
        public decimal MaraERGEW { get; set; }

        /// <summary>
        /// 描述 :创建者  
        /// 空值 :false 
        /// </summary>
        public string MaraERNAM { get; set; }

        /// <summary>
        /// 描述 :创建日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? MaraERSDA { get; set; }

        /// <summary>
        /// 描述 :体积单位 
        /// 空值 :true 
        /// </summary>
        public string MaraERVOE { get; set; }

        /// <summary>
        /// 描述 :允许的体积  
        /// 空值 :false 
        /// </summary>
        public decimal MaraERVOL { get; set; }

        /// <summary>
        /// 描述 :给物料组加标签 
        /// 空值 :true 
        /// </summary>
        public string MaraETIAG { get; set; }

        /// <summary>
        /// 描述 :标号类型 
        /// 空值 :true 
        /// </summary>
        public string MaraETIAR { get; set; }

        /// <summary>
        /// 描述 :标签格式 
        /// 空值 :true 
        /// </summary>
        public string MaraETIFO { get; set; }

        /// <summary>
        /// 描述 :外部物料组  
        /// 空值 :true 
        /// </summary>
        public string MaraEXTWG { get; set; }

        /// <summary>
        /// 描述 :时装等级 
        /// 空值 :true 
        /// </summary>
        public string MaraFASHGRD { get; set; }

        /// <summary>
        /// 描述 :生产/检验备忘录 
        /// 空值 :true 
        /// </summary>
        public string MaraFERTH { get; set; }

        /// <summary>
        /// 描述 :组件1 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_CODE1")]
        public string MarafiberCode1 { get; set; }

        /// <summary>
        /// 描述 :组件2 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_CODE2")]
        public string MarafiberCode2 { get; set; }

        /// <summary>
        /// 描述 :组件3 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_CODE3")]
        public string MarafiberCode3 { get; set; }

        /// <summary>
        /// 描述 :组件4 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_CODE4")]
        public string MarafiberCode4 { get; set; }

        /// <summary>
        /// 描述 :组件5 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_CODE5")]
        public string MarafiberCode5 { get; set; }

        /// <summary>
        /// 描述 :百分比共享1 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_PART1")]
        public string MarafiberPart1 { get; set; }

        /// <summary>
        /// 描述 :百分比共享2 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_PART2")]
        public string MarafiberPart2 { get; set; }

        /// <summary>
        /// 描述 :百分比共享3 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_PART3")]
        public string MarafiberPart3 { get; set; }

        /// <summary>
        /// 描述 :百分比共享4 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_PART4")]
        public string MarafiberPart4 { get; set; }

        /// <summary>
        /// 描述 :百分比共享5 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFIBER_PART5")]
        public string MarafiberPart5 { get; set; }

        /// <summary>
        /// 描述 :页格式  
        /// 空值 :true 
        /// </summary>
        public string MaraFORMT { get; set; }

        /// <summary>
        /// 描述 :特性值  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFREE_CHAR")]
        public string MarafreeChar { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 1 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_MG_AT1")]
        public string MarafshMgAt1 { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 2 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_MG_AT2")]
        public string MarafshMgAt2 { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 3 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_MG_AT3")]
        public string MarafshMgAt3 { get; set; }

        /// <summary>
        /// 描述 :物料转换标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_SC_MID")]
        public string MarafshScMid { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_SEAIM")]
        public string MarafshSeaim { get; set; }

        /// <summary>
        /// 描述 :季节使用 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraFSH_SEALV")]
        public string MarafshSealv { get; set; }

        /// <summary>
        /// 描述 :最大层次  
        /// 空值 :false 
        /// </summary>
        public decimal MaraFUELG { get; set; }

        /// <summary>
        /// 描述 :GDS 相关 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraGDS_RELEVANT")]
        public string MaragdsRelevant { get; set; }

        /// <summary>
        /// 描述 :一般物料  
        /// 空值 :true 
        /// </summary>
        public string MaraGENNR { get; set; }

        /// <summary>
        /// 描述 :重量单位 
        /// 空值 :true 
        /// </summary>
        public string MaraGEWEI { get; set; }

        /// <summary>
        /// 描述 :超重量容差  
        /// 空值 :false 
        /// </summary>
        public decimal MaraGEWTO { get; set; }

        /// <summary>
        /// 描述 :大小/量纲 
        /// 空值 :true 
        /// </summary>
        public string MaraGROES { get; set; }

        /// <summary>
        /// 描述 :EAN变式 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraGTIN_VARIANT")]
        public string MaragtinVariant { get; set; }

        /// <summary>
        /// 描述 :危险物料 
        /// 空值 :true 
        /// </summary>
        public string MaraHAZMAT { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// 空值 :true 
        /// </summary>
        public string MaraHERKL { get; set; }

        /// <summary>
        /// 描述 :处理标识 
        /// 空值 :true 
        /// </summary>
        public string MaraHNDLCODE { get; set; }

        /// <summary>
        /// 描述 :高度 
        /// 空值 :false 
        /// </summary>
        public decimal MaraHOEHE { get; set; }

        /// <summary>
        /// 描述 :处理单位类型 
        /// 空值 :true 
        /// </summary>
        public string MaraHUTYP { get; set; }

        /// <summary>
        /// 描述 :标准处理单位类 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraHUTYP_DFLT")]
        public string MarahutypDflt { get; set; }

        /// <summary>
        /// 描述 :高粘性的 
        /// 空值 :true 
        /// </summary>
        public string MaraIHIVI { get; set; }

        /// <summary>
        /// 描述 :以大批/液体 
        /// 空值 :true 
        /// </summary>
        public string MaraILOOS { get; set; }

        /// <summary>
        /// 描述 :完全互换组  
        /// 空值 :true 
        /// </summary>
        public string MaraIMATN { get; set; }

        /// <summary>
        /// 描述 :净内容 
        /// 空值 :false 
        /// </summary>
        public decimal MaraINHAL { get; set; }

        /// <summary>
        /// 描述 :毛内容  
        /// 空值 :false 
        /// </summary>
        public decimal MaraINHBR { get; set; }

        /// <summary>
        /// 描述 :内容单位 
        /// 空值 :true 
        /// </summary>
        public string MaraINHME { get; set; }

        /// <summary>
        /// 描述 :知识产权 
        /// 空值 :true 
        /// </summary>
        public string MaraIPMIPPRODUCT { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// 空值 :true 
        /// </summary>
        public string MaraIPRKZ { get; set; }

        /// <summary>
        /// 描述 :产品分配 
        /// 空值 :true 
        /// </summary>
        public string MaraKOSCH { get; set; }

        /// <summary>
        /// 描述 :竞争者  
        /// 空值 :true 
        /// </summary>
        public string MaraKUNNR { get; set; }

        /// <summary>
        /// 描述 :参数有效值·  
        /// 空值 :true 
        /// </summary>
        public string MaraKZEFF { get; set; }

        /// <summary>
        /// 描述 :密闭的  
        /// 空值 :true 
        /// </summary>
        public string MaraKZGVH { get; set; }

        /// <summary>
        /// 描述 :可配置  
        /// 空值 :true 
        /// </summary>
        public string MaraKZKFG { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// 空值 :true 
        /// </summary>
        public string MaraKZKUP { get; set; }

        /// <summary>
        /// 描述 :后继的物料  
        /// 空值 :true 
        /// </summary>
        public string MaraKZNFM { get; set; }

        /// <summary>
        /// 描述 :修订等级 
        /// 空值 :true 
        /// </summary>
        public string MaraKZREV { get; set; }

        /// <summary>
        /// 描述 :环境是相关的 
        /// 空值 :true 
        /// </summary>
        public string MaraKZUMW { get; set; }

        /// <summary>
        /// 描述 :测量单位用法 
        /// 空值 :true 
        /// </summary>
        public string MaraKZWSM { get; set; }

        /// <summary>
        /// 描述 :实验室/办公室  
        /// 空值 :true 
        /// </summary>
        public string MaraLABOR { get; set; }

        /// <summary>
        /// 描述 :上次更改 
        /// 空值 :true 
        /// </summary>
        public DateTime? MaraLAEDA { get; set; }

        /// <summary>
        /// 描述 :长度 
        /// 空值 :false 
        /// </summary>
        public decimal MaraLAENG { get; set; }

        /// <summary>
        /// 描述 :有效至  
        /// 空值 :true 
        /// </summary>
        public DateTime? MaraLIQDT { get; set; }

        /// <summary>
        /// 描述 :退货到后勤等级 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraLOGLEV_RETO")]
        public string MaraloglevReto { get; set; }

        /// <summary>
        /// 描述 :后勤计量单位 
        /// 空值 :true 
        /// </summary>
        public string MaraLOGUNIT { get; set; }

        /// <summary>
        /// 描述 :集团级的 DF 
        /// 空值 :true 
        /// </summary>
        public string MaraLVORM { get; set; }

        /// <summary>
        /// 描述 :物料组包装物料 
        /// 空值 :true 
        /// </summary>
        public string MaraMAGRV { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// 空值 :true 
        /// </summary>
        public string MaraMANDT { get; set; }

        /// <summary>
        /// 描述 :物料被锁定  
        /// 空值 :true 
        /// </summary>
        public string MaraMATFI { get; set; }

        /// <summary>
        /// 描述 :物料组  
        /// 空值 :false 
        /// </summary>
        public string MaraMATKL { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MaraMATNR { get; set; }

        /// <summary>
        /// 描述 :最大包宽度 
        /// 空值 :false 
        /// </summary>
        public decimal MaraMAXB { get; set; }

        /// <summary>
        /// 描述 :最大容量  
        /// 空值 :false 
        /// </summary>
        public decimal MaraMAXC { get; set; }

        /// <summary>
        /// 描述 :超过容量容差 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "maraMAXC_TOL")]
        public decimal MaramaxcTol { get; set; }

        /// <summary>
        /// 描述 :计量单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraMAXDIM_UOM")]
        public string MaramaxdimUom { get; set; }

        /// <summary>
        /// 描述 :最大高度  
        /// 空值 :false 
        /// </summary>
        public decimal MaraMAXH { get; set; }

        /// <summary>
        /// 描述 :最大长度  
        /// 空值 :false 
        /// </summary>
        public decimal MaraMAXL { get; set; }

        /// <summary>
        /// 描述 :行业领域 
        /// 空值 :false 
        /// </summary>
        public string MaraMBRSH { get; set; }

        /// <summary>
        /// 描述 :物料条件管理 
        /// 空值 :true 
        /// </summary>
        public string MaraMCOND { get; set; }

        /// <summary>
        /// 描述 :单位 
        /// 空值 :true 
        /// </summary>
        public string MaraMEABM { get; set; }

        /// <summary>
        /// 描述 :中间 
        /// 空值 :true 
        /// </summary>
        public string MaraMEDIUM { get; set; }

        /// <summary>
        /// 描述 :基本单位 
        /// 空值 :false 
        /// </summary>
        public string MaraMEINS { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// 空值 :true 
        /// </summary>
        public string MaraMFRGR { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// 空值 :true 
        /// </summary>
        public string MaraMFRNR { get; set; }

        /// <summary>
        /// 描述 :制造商零件编号 
        /// 空值 :true 
        /// </summary>
        public string MaraMFRPN { get; set; }

        /// <summary>
        /// 描述 :总货架寿命  
        /// 空值 :false 
        /// </summary>
        public decimal MaraMHDHB { get; set; }

        /// <summary>
        /// 描述 :仓储 % 
        /// 空值 :false 
        /// </summary>
        public decimal MaraMHDLP { get; set; }

        /// <summary>
        /// 描述 :剩余货架寿命 
        /// 空值 :false 
        /// </summary>
        public decimal MaraMHDRZ { get; set; }

        /// <summary>
        /// 描述 :含空BOM 
        /// 空值 :true 
        /// </summary>
        public string MaraMLGUT { get; set; }

        /// <summary>
        /// 描述 :制造商部件参数文 
        /// 空值 :true 
        /// </summary>
        public string MaraMPROF { get; set; }

        /// <summary>
        /// 描述 :跨工厂物料状态 
        /// 空值 :true 
        /// </summary>
        public string MaraMSTAE { get; set; }

        /// <summary>
        /// 描述 :跨分销链状态  
        /// 空值 :true 
        /// </summary>
        public string MaraMSTAV { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// 空值 :true 
        /// </summary>
        public DateTime? MaraMSTDE { get; set; }

        /// <summary>
        /// 描述 :有效从  
        /// 空值 :true 
        /// </summary>
        public DateTime? MaraMSTDV { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// 空值 :false 
        /// </summary>
        public string MaraMTART { get; set; }

        /// <summary>
        /// 描述 :普通项目类别组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraMTPOS_MARA")]
        public string MaramtposMara { get; set; }

        /// <summary>
        /// 描述 :行业标准描述 
        /// 空值 :true 
        /// </summary>
        public string MaraNORMT { get; set; }

        /// <summary>
        /// 描述 :折扣类型 
        /// 空值 :true 
        /// </summary>
        public string MaraNRFHG { get; set; }

        /// <summary>
        /// 描述 :NIIN 
        /// 空值 :true 
        /// </summary>
        public string MaraNSNID { get; set; }

        /// <summary>
        /// 描述 :净重  
        /// 空值 :false 
        /// </summary>
        public decimal MaraNTGEW { get; set; }

        /// <summary>
        /// 描述 :EAN 类别 
        /// 空值 :true 
        /// </summary>
        public string MaraNUMTP { get; set; }

        /// <summary>
        /// 描述 :Packaging Code 
        /// 空值 :true 
        /// </summary>
        public string MaraPACKCODE { get; set; }

        /// <summary>
        /// 描述 :链编号  
        /// 空值 :true 
        /// </summary>
        public string MaraPICNUM { get; set; }

        /// <summary>
        /// 描述 :可偷窃的 
        /// 空值 :true 
        /// </summary>
        public string MaraPILFERABLE { get; set; }

        /// <summary>
        /// 描述 :价格标记类型 
        /// 空值 :true 
        /// </summary>
        public string MaraPLGTP { get; set; }

        /// <summary>
        /// 描述 :定价参考物料  
        /// 空值 :true 
        /// </summary>
        public string MaraPMATA { get; set; }

        /// <summary>
        /// 描述 :产品层次 
        /// 空值 :true 
        /// </summary>
        public string MaraPRDHA { get; set; }

        /// <summary>
        /// 描述 :DG标识参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraPROFL { get; set; }

        /// <summary>
        /// 描述 :产品成分 
        /// 空值 :true 
        /// </summary>
        public string MaraPRZUS { get; set; }

        /// <summary>
        /// 描述 :表格名  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraPS_SMARTFORM")]
        public string MarapsSmartform { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// 空值 :true 
        /// </summary>
        public string MaraPSTAT { get; set; }

        /// <summary>
        /// 描述 :质量检查组 
        /// 空值 :true 
        /// </summary>
        public string MaraQGRP { get; set; }

        /// <summary>
        /// 描述 :QM 采购 
        /// 空值 :true 
        /// </summary>
        public string MaraQMPUR { get; set; }

        /// <summary>
        /// 描述 :隔离期间 
        /// 空值 :false 
        /// </summary>
        public decimal MaraQQTIME { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// 空值 :true 
        /// </summary>
        public string MaraQQTIMEUOM { get; set; }

        /// <summary>
        /// 描述 :存储条件 
        /// 空值 :true 
        /// </summary>
        public string MaraRAUBE { get; set; }

        /// <summary>
        /// 描述 :类别参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraRBNRM { get; set; }

        /// <summary>
        /// 描述 :舍入规则 
        /// 空值 :true 
        /// </summary>
        public string MaraRDMHD { get; set; }

        /// <summary>
        /// 描述 :返回代码 
        /// 空值 :true 
        /// </summary>
        public string MaraRETDELC { get; set; }

        /// <summary>
        /// 描述 :包装的参考物料 
        /// 空值 :true 
        /// </summary>
        public string MaraRMATP { get; set; }

        /// <summary>
        /// 描述 :季度年  
        /// 空值 :true 
        /// </summary>
        public string MaraSAISJ { get; set; }

        /// <summary>
        /// 描述 :季节 
        /// 空值 :true 
        /// </summary>
        public string MaraSAISO { get; set; }

        /// <summary>
        /// 描述 :展开 
        /// 空值 :true 
        /// </summary>
        public string MaraSAITY { get; set; }

        /// <summary>
        /// 描述 :一般可配置物料 
        /// 空值 :true 
        /// </summary>
        public string MaraSATNR { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraSERIAL { get; set; }

        /// <summary>
        /// 描述 :序列化层次  
        /// 空值 :true 
        /// </summary>
        public string MaraSERLV { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSGT_COVSA")]
        public string MarasgtCovsa { get; set; }

        /// <summary>
        /// 描述 :分段结构 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSGT_CSGR")]
        public string MarasgtCsgr { get; set; }

        /// <summary>
        /// 描述 :分段相关 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSGT_REL")]
        public string MarasgtRel { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSGT_SCOPE")]
        public string MarasgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSGT_STAT")]
        public string MarasgtStat { get; set; }

        /// <summary>
        /// 描述 :主尺寸  
        /// 空值 :true 
        /// </summary>
        public string MaraSIZE1 { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSIZE1_ATINN")]
        public string Marasize1Atinn { get; set; }

        /// <summary>
        /// 描述 :次尺寸  
        /// 空值 :true 
        /// </summary>
        public string MaraSIZE2 { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSIZE2_ATINN")]
        public string Marasize2Atinn { get; set; }

        /// <summary>
        /// 描述 :过期日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraSLED_BBD")]
        public string MarasledBbd { get; set; }

        /// <summary>
        /// 描述 :产品组  
        /// 空值 :true 
        /// </summary>
        public string MaraSPART { get; set; }

        /// <summary>
        /// 描述 :定价参数文件 
        /// 空值 :true 
        /// </summary>
        public string MaraSPROF { get; set; }

        /// <summary>
        /// 描述 :堆栈因子 
        /// 空值 :false 
        /// </summary>
        public int MaraSTFAK { get; set; }

        /// <summary>
        /// 描述 :危险物料号  
        /// 空值 :true 
        /// </summary>
        public string MaraSTOFF { get; set; }

        /// <summary>
        /// 描述 :税收分类 
        /// 空值 :true 
        /// </summary>
        public string MaraTAKLV { get; set; }

        /// <summary>
        /// 描述 :可变皮重 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraTARE_VAR")]
        public string MaratareVar { get; set; }

        /// <summary>
        /// 描述 :温度 
        /// 空值 :true 
        /// </summary>
        public string MaraTEMPB { get; set; }

        /// <summary>
        /// 描述 :纺织组分活动 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "maraTEXTILE_COMP_IND")]
        public string MaratextileCompInd { get; set; }

        /// <summary>
        /// 描述 :运输组  
        /// 空值 :true 
        /// </summary>
        public string MaraTRAGR { get; set; }

        /// <summary>
        /// 描述 :可变的订单单位 
        /// 空值 :true 
        /// </summary>
        public string MaraVABME { get; set; }

        /// <summary>
        /// 描述 :包装物料类型 
        /// 空值 :true 
        /// </summary>
        public string MaraVHART { get; set; }

        /// <summary>
        /// 描述 :体积单位 
        /// 空值 :true 
        /// </summary>
        public string MaraVOLEH { get; set; }

        /// <summary>
        /// 描述 :超过体积容差 
        /// 空值 :false 
        /// </summary>
        public decimal MaraVOLTO { get; set; }

        /// <summary>
        /// 描述 :业务量  
        /// 空值 :false 
        /// </summary>
        public decimal MaraVOLUM { get; set; }

        /// <summary>
        /// 描述 :比较价格单位 
        /// 空值 :false 
        /// </summary>
        public decimal MaraVPREH { get; set; }

        /// <summary>
        /// 描述 :完整状态  
        /// 空值 :true 
        /// </summary>
        public string MaraVPSTA { get; set; }

        /// <summary>
        /// 描述 :原始接受 
        /// 空值 :true 
        /// </summary>
        public string MaraWEORA { get; set; }

        /// <summary>
        /// 描述 :GR单数量  
        /// 空值 :false 
        /// </summary>
        public decimal MaraWESCH { get; set; }

        /// <summary>
        /// 描述 :仓库物料组  
        /// 空值 :true 
        /// </summary>
        public string MaraWHMATGR { get; set; }

        /// <summary>
        /// 描述 :仓库存储条件 
        /// 空值 :true 
        /// </summary>
        public string MaraWHSTC { get; set; }

        /// <summary>
        /// 描述 :基本物料 
        /// 空值 :true 
        /// </summary>
        public string MaraWRKST { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// 空值 :true 
        /// </summary>
        public string MaraXCHPF { get; set; }

        /// <summary>
        /// 描述 :需要批量记录  
        /// 空值 :true 
        /// </summary>
        public string MaraXGCHP { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// 空值 :true 
        /// </summary>
        public string MaraZEIAR { get; set; }

        /// <summary>
        /// 描述 :页面大小 
        /// 空值 :true 
        /// </summary>
        public string MaraZEIFO { get; set; }

        /// <summary>
        /// 描述 :凭证 
        /// 空值 :true 
        /// </summary>
        public string MaraZEINR { get; set; }

        /// <summary>
        /// 描述 :凭证版本 
        /// 空值 :true 
        /// </summary>
        public string MaraZEIVR { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :false 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :false 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :false 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :false 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :false 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :false 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :false 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}