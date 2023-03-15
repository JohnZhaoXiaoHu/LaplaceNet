using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 常规物料数据查询对象
    /// </summary>
    public class MmMaraQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 常规物料数据输入输出对象
    /// </summary>
    public class MmMaraDto
    {
        /// <summary>
        /// 描述 :ID主键 
        /// </summary>
        [Required(ErrorMessage = "ID主键不能为空")]

        [ExcelColumn(Name = "ID主键")]
        public int MaraID { get; set; }

        /// <summary>
        /// 描述 :调整参数文件 
        /// </summary>

        [ExcelColumn(Name = "调整参数文件")]
        public string MaraADPROF { get; set; }

        /// <summary>
        /// 描述 :净改变成本核算 
        /// </summary>

        [ExcelColumn(Name = "净改变成本核算")]
        public string MaraAEKLK { get; set; }

        /// <summary>
        /// 描述 :更改者  
        /// </summary>
        [Required(ErrorMessage = "更改者 不能为空")]

        [ExcelColumn(Name = "更改者 ")]
        public string MaraAENAM { get; set; }

        /// <summary>
        /// 描述 :文档变更号  
        /// </summary>

        [ExcelColumn(Name = "文档变更号 ")]
        public string MaraAESZN { get; set; }

        /// <summary>
        /// 描述 :允许的变式价格 
        /// </summary>

        [ExcelColumn(Name = "允许的变式价格")]
        public string MaraallowPmatIgno { get; set; }

        /// <summary>
        /// 描述 :动物源  
        /// </summary>

        [ExcelColumn(Name = "动物源 ")]
        public string MaraanimalOrigin { get; set; }

        /// <summary>
        /// 描述 :ANP Code 
        /// </summary>

        [ExcelColumn(Name = "ANP Code")]
        public string MaraANP { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// </summary>
        [Required(ErrorMessage = "物料类别不能为空")]

        [ExcelColumn(Name = "物料类别")]
        public string MaraATTYP { get; set; }

        /// <summary>
        /// 描述 :分类清单类型 
        /// </summary>

        [ExcelColumn(Name = "分类清单类型")]
        public string MaraBBTYP { get; set; }

        /// <summary>
        /// 描述 :权限组  
        /// </summary>

        [ExcelColumn(Name = "权限组 ")]
        public string MaraBEGRU { get; set; }

        /// <summary>
        /// 描述 :容器 
        /// </summary>

        [ExcelColumn(Name = "容器")]
        public string MaraBEHVO { get; set; }

        /// <summary>
        /// 描述 :后勤变量 
        /// </summary>

        [ExcelColumn(Name = "后勤变量")]
        public string MaraBFLME { get; set; }

        /// <summary>
        /// 描述 :旧物料号 
        /// </summary>

        [ExcelColumn(Name = "旧物料号")]
        public string MaraBISMT { get; set; }

        /// <summary>
        /// 描述 :页数 
        /// </summary>

        [ExcelColumn(Name = "页数")]
        public string MaraBLANZ { get; set; }

        /// <summary>
        /// 描述 :页号 
        /// </summary>

        [ExcelColumn(Name = "页号")]
        public string MaraBLATT { get; set; }

        /// <summary>
        /// 描述 :内部物料编号 
        /// </summary>

        [ExcelColumn(Name = "内部物料编号")]
        public string MaraBMATN { get; set; }

        /// <summary>
        /// 描述 :商标 
        /// </summary>

        [ExcelColumn(Name = "商标")]
        public string MarabrandId { get; set; }

        /// <summary>
        /// 描述 :宽度 
        /// </summary>
        [Required(ErrorMessage = "宽度不能为空")]

        [ExcelColumn(Name = "宽度")]
        public decimal MaraBREIT { get; set; }

        /// <summary>
        /// 描述 :毛重 
        /// </summary>
        [Required(ErrorMessage = "毛重不能为空")]

        [ExcelColumn(Name = "毛重")]
        public decimal MaraBRGEW { get; set; }

        /// <summary>
        /// 描述 :创建状态  
        /// </summary>

        [ExcelColumn(Name = "创建状态 ")]
        public string MaraBSTAT { get; set; }

        /// <summary>
        /// 描述 :订单单位 
        /// </summary>

        [ExcelColumn(Name = "订单单位")]
        public string MaraBSTME { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// </summary>

        [ExcelColumn(Name = "货源")]
        public string MaraBWSCL { get; set; }

        /// <summary>
        /// 描述 :采购规则 
        /// </summary>

        [ExcelColumn(Name = "采购规则")]
        public string MaraBWVOR { get; set; }

        /// <summary>
        /// 描述 :CAD 标识 
        /// </summary>

        [ExcelColumn(Name = "CAD 标识")]
        public string MaraCADKZ { get; set; }

        /// <summary>
        /// 描述 :护理代码 
        /// </summary>

        [ExcelColumn(Name = "护理代码")]
        public string MaracareCode { get; set; }

        /// <summary>
        /// 描述 :转换方法 
        /// </summary>

        [ExcelColumn(Name = "转换方法")]
        public string MaraCMETH { get; set; }

        /// <summary>
        /// 描述 :CM 相关 
        /// </summary>

        [ExcelColumn(Name = "CM 相关")]
        public string MaraCMREL { get; set; }

        /// <summary>
        /// 描述 :颜色 
        /// </summary>

        [ExcelColumn(Name = "颜色")]
        public string MaraCOLOR { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// </summary>

        [ExcelColumn(Name = "内部特性 ")]
        public string MaracolorAtinn { get; set; }

        /// <summary>
        /// 描述 :实物商品 
        /// </summary>

        [ExcelColumn(Name = "实物商品")]
        public string MaraCOMMODITY { get; set; }

        /// <summary>
        /// 描述 :完成水平 
        /// </summary>

        [ExcelColumn(Name = "完成水平")]
        public string MaraCOMPL { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// </summary>

        [ExcelColumn(Name = "内部对象号 ")]
        public string MaraCUOBF { get; set; }

        /// <summary>
        /// 描述 :CW 参数文件 
        /// </summary>

        [ExcelColumn(Name = "CW 参数文件")]
        public string MaraCWQPROC { get; set; }

        /// <summary>
        /// 描述 :称重物料相关 
        /// </summary>

        [ExcelColumn(Name = "称重物料相关")]
        public string MaraCWQREL { get; set; }

        /// <summary>
        /// 描述 :CW 容差组  
        /// </summary>

        [ExcelColumn(Name = "CW 容差组 ")]
        public string MaraCWQTOLGR { get; set; }

        /// <summary>
        /// 描述 :有效起始日  
        /// </summary>

        [ExcelColumn(Name = "有效起始日 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraDATAB { get; set; }

        /// <summary>
        /// 描述 :危险品包装状态 
        /// </summary>

        [ExcelColumn(Name = "危险品包装状态")]
        public string MaradgPackStatus { get; set; }

        /// <summary>
        /// 描述 :低层代码 
        /// </summary>

        [ExcelColumn(Name = "低层代码")]
        public string MaraDISST { get; set; }

        /// <summary>
        /// 描述 :EAN/UPC 
        /// </summary>

        [ExcelColumn(Name = "EAN/UPC")]
        public string MaraEAN11 { get; set; }

        /// <summary>
        /// 描述 :EAN 号  
        /// </summary>

        [ExcelColumn(Name = "EAN 号 ")]
        public string MaraEANNR { get; set; }

        /// <summary>
        /// 描述 :采购值代码  
        /// </summary>

        [ExcelColumn(Name = "采购值代码 ")]
        public string MaraEKWSL { get; set; }

        /// <summary>
        /// 描述 :取消激活字段  
        /// </summary>

        [ExcelColumn(Name = "取消激活字段 ")]
        public string MaraENTAR { get; set; }

        /// <summary>
        /// 描述 :重量单位 
        /// </summary>

        [ExcelColumn(Name = "重量单位")]
        public string MaraERGEI { get; set; }

        /// <summary>
        /// 描述 :允许的包装重量 
        /// </summary>
        [Required(ErrorMessage = "允许的包装重量不能为空")]

        [ExcelColumn(Name = "允许的包装重量")]
        public decimal MaraERGEW { get; set; }

        /// <summary>
        /// 描述 :创建者  
        /// </summary>
        [Required(ErrorMessage = "创建者 不能为空")]

        [ExcelColumn(Name = "创建者 ")]
        public string MaraERNAM { get; set; }

        /// <summary>
        /// 描述 :创建日期 
        /// </summary>
        [Required(ErrorMessage = "创建日期不能为空")]

        [ExcelColumn(Name = "创建日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraERSDA { get; set; }

        /// <summary>
        /// 描述 :体积单位 
        /// </summary>

        [ExcelColumn(Name = "体积单位")]
        public string MaraERVOE { get; set; }

        /// <summary>
        /// 描述 :允许的体积  
        /// </summary>
        [Required(ErrorMessage = "允许的体积 不能为空")]

        [ExcelColumn(Name = "允许的体积 ")]
        public decimal MaraERVOL { get; set; }

        /// <summary>
        /// 描述 :给物料组加标签 
        /// </summary>

        [ExcelColumn(Name = "给物料组加标签")]
        public string MaraETIAG { get; set; }

        /// <summary>
        /// 描述 :标号类型 
        /// </summary>

        [ExcelColumn(Name = "标号类型")]
        public string MaraETIAR { get; set; }

        /// <summary>
        /// 描述 :标签格式 
        /// </summary>

        [ExcelColumn(Name = "标签格式")]
        public string MaraETIFO { get; set; }

        /// <summary>
        /// 描述 :外部物料组  
        /// </summary>

        [ExcelColumn(Name = "外部物料组 ")]
        public string MaraEXTWG { get; set; }

        /// <summary>
        /// 描述 :时装等级 
        /// </summary>

        [ExcelColumn(Name = "时装等级")]
        public string MaraFASHGRD { get; set; }

        /// <summary>
        /// 描述 :生产/检验备忘录 
        /// </summary>

        [ExcelColumn(Name = "生产/检验备忘录")]
        public string MaraFERTH { get; set; }

        /// <summary>
        /// 描述 :组件1 
        /// </summary>

        [ExcelColumn(Name = "组件1")]
        public string MarafiberCode1 { get; set; }

        /// <summary>
        /// 描述 :组件2 
        /// </summary>

        [ExcelColumn(Name = "组件2")]
        public string MarafiberCode2 { get; set; }

        /// <summary>
        /// 描述 :组件3 
        /// </summary>

        [ExcelColumn(Name = "组件3")]
        public string MarafiberCode3 { get; set; }

        /// <summary>
        /// 描述 :组件4 
        /// </summary>

        [ExcelColumn(Name = "组件4")]
        public string MarafiberCode4 { get; set; }

        /// <summary>
        /// 描述 :组件5 
        /// </summary>

        [ExcelColumn(Name = "组件5")]
        public string MarafiberCode5 { get; set; }

        /// <summary>
        /// 描述 :百分比共享1 
        /// </summary>

        [ExcelColumn(Name = "百分比共享1")]
        public string MarafiberPart1 { get; set; }

        /// <summary>
        /// 描述 :百分比共享2 
        /// </summary>

        [ExcelColumn(Name = "百分比共享2")]
        public string MarafiberPart2 { get; set; }

        /// <summary>
        /// 描述 :百分比共享3 
        /// </summary>

        [ExcelColumn(Name = "百分比共享3")]
        public string MarafiberPart3 { get; set; }

        /// <summary>
        /// 描述 :百分比共享4 
        /// </summary>

        [ExcelColumn(Name = "百分比共享4")]
        public string MarafiberPart4 { get; set; }

        /// <summary>
        /// 描述 :百分比共享5 
        /// </summary>

        [ExcelColumn(Name = "百分比共享5")]
        public string MarafiberPart5 { get; set; }

        /// <summary>
        /// 描述 :页格式  
        /// </summary>

        [ExcelColumn(Name = "页格式 ")]
        public string MaraFORMT { get; set; }

        /// <summary>
        /// 描述 :特性值  
        /// </summary>

        [ExcelColumn(Name = "特性值 ")]
        public string MarafreeChar { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 1 
        /// </summary>

        [ExcelColumn(Name = "Fashion 属性 1")]
        public string MarafshMgAt1 { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 2 
        /// </summary>

        [ExcelColumn(Name = "Fashion 属性 2")]
        public string MarafshMgAt2 { get; set; }

        /// <summary>
        /// 描述 :Fashion 属性 3 
        /// </summary>

        [ExcelColumn(Name = "Fashion 属性 3")]
        public string MarafshMgAt3 { get; set; }

        /// <summary>
        /// 描述 :物料转换标识 
        /// </summary>

        [ExcelColumn(Name = "物料转换标识")]
        public string MarafshScMid { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// </summary>

        [ExcelColumn(Name = "库存管理中激活季节")]
        public string MarafshSeaim { get; set; }

        /// <summary>
        /// 描述 :季节使用 
        /// </summary>

        [ExcelColumn(Name = "季节使用")]
        public string MarafshSealv { get; set; }

        /// <summary>
        /// 描述 :最大层次  
        /// </summary>
        [Required(ErrorMessage = "最大层次 不能为空")]

        [ExcelColumn(Name = "最大层次 ")]
        public decimal MaraFUELG { get; set; }

        /// <summary>
        /// 描述 :GDS 相关 
        /// </summary>

        [ExcelColumn(Name = "GDS 相关")]
        public string MaragdsRelevant { get; set; }

        /// <summary>
        /// 描述 :一般物料  
        /// </summary>

        [ExcelColumn(Name = "一般物料 ")]
        public string MaraGENNR { get; set; }

        /// <summary>
        /// 描述 :重量单位 
        /// </summary>

        [ExcelColumn(Name = "重量单位")]
        public string MaraGEWEI { get; set; }

        /// <summary>
        /// 描述 :超重量容差  
        /// </summary>
        [Required(ErrorMessage = "超重量容差 不能为空")]

        [ExcelColumn(Name = "超重量容差 ")]
        public decimal MaraGEWTO { get; set; }

        /// <summary>
        /// 描述 :大小/量纲 
        /// </summary>

        [ExcelColumn(Name = "大小/量纲")]
        public string MaraGROES { get; set; }

        /// <summary>
        /// 描述 :EAN变式 
        /// </summary>

        [ExcelColumn(Name = "EAN变式")]
        public string MaragtinVariant { get; set; }

        /// <summary>
        /// 描述 :危险物料 
        /// </summary>

        [ExcelColumn(Name = "危险物料")]
        public string MaraHAZMAT { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// </summary>

        [ExcelColumn(Name = "原产地国")]
        public string MaraHERKL { get; set; }

        /// <summary>
        /// 描述 :处理标识 
        /// </summary>

        [ExcelColumn(Name = "处理标识")]
        public string MaraHNDLCODE { get; set; }

        /// <summary>
        /// 描述 :高度 
        /// </summary>
        [Required(ErrorMessage = "高度不能为空")]

        [ExcelColumn(Name = "高度")]
        public decimal MaraHOEHE { get; set; }

        /// <summary>
        /// 描述 :处理单位类型 
        /// </summary>

        [ExcelColumn(Name = "处理单位类型")]
        public string MaraHUTYP { get; set; }

        /// <summary>
        /// 描述 :标准处理单位类 
        /// </summary>

        [ExcelColumn(Name = "标准处理单位类")]
        public string MarahutypDflt { get; set; }

        /// <summary>
        /// 描述 :高粘性的 
        /// </summary>

        [ExcelColumn(Name = "高粘性的")]
        public string MaraIHIVI { get; set; }

        /// <summary>
        /// 描述 :以大批/液体 
        /// </summary>

        [ExcelColumn(Name = "以大批/液体")]
        public string MaraILOOS { get; set; }

        /// <summary>
        /// 描述 :完全互换组  
        /// </summary>

        [ExcelColumn(Name = "完全互换组 ")]
        public string MaraIMATN { get; set; }

        /// <summary>
        /// 描述 :净内容 
        /// </summary>
        [Required(ErrorMessage = "净内容不能为空")]

        [ExcelColumn(Name = "净内容")]
        public decimal MaraINHAL { get; set; }

        /// <summary>
        /// 描述 :毛内容  
        /// </summary>
        [Required(ErrorMessage = "毛内容 不能为空")]

        [ExcelColumn(Name = "毛内容 ")]
        public decimal MaraINHBR { get; set; }

        /// <summary>
        /// 描述 :内容单位 
        /// </summary>

        [ExcelColumn(Name = "内容单位")]
        public string MaraINHME { get; set; }

        /// <summary>
        /// 描述 :知识产权 
        /// </summary>

        [ExcelColumn(Name = "知识产权")]
        public string MaraIPMIPPRODUCT { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// </summary>

        [ExcelColumn(Name = "期间标识")]
        public string MaraIPRKZ { get; set; }

        /// <summary>
        /// 描述 :产品分配 
        /// </summary>

        [ExcelColumn(Name = "产品分配")]
        public string MaraKOSCH { get; set; }

        /// <summary>
        /// 描述 :竞争者  
        /// </summary>

        [ExcelColumn(Name = "竞争者 ")]
        public string MaraKUNNR { get; set; }

        /// <summary>
        /// 描述 :参数有效值·  
        /// </summary>

        [ExcelColumn(Name = "参数有效值· ")]
        public string MaraKZEFF { get; set; }

        /// <summary>
        /// 描述 :密闭的  
        /// </summary>

        [ExcelColumn(Name = "密闭的 ")]
        public string MaraKZGVH { get; set; }

        /// <summary>
        /// 描述 :可配置  
        /// </summary>

        [ExcelColumn(Name = "可配置 ")]
        public string MaraKZKFG { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// </summary>

        [ExcelColumn(Name = "联产品 ")]
        public string MaraKZKUP { get; set; }

        /// <summary>
        /// 描述 :后继的物料  
        /// </summary>

        [ExcelColumn(Name = "后继的物料 ")]
        public string MaraKZNFM { get; set; }

        /// <summary>
        /// 描述 :修订等级 
        /// </summary>

        [ExcelColumn(Name = "修订等级")]
        public string MaraKZREV { get; set; }

        /// <summary>
        /// 描述 :环境是相关的 
        /// </summary>

        [ExcelColumn(Name = "环境是相关的")]
        public string MaraKZUMW { get; set; }

        /// <summary>
        /// 描述 :测量单位用法 
        /// </summary>

        [ExcelColumn(Name = "测量单位用法")]
        public string MaraKZWSM { get; set; }

        /// <summary>
        /// 描述 :实验室/办公室  
        /// </summary>

        [ExcelColumn(Name = "实验室/办公室 ")]
        public string MaraLABOR { get; set; }

        /// <summary>
        /// 描述 :上次更改 
        /// </summary>

        [ExcelColumn(Name = "上次更改", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraLAEDA { get; set; }

        /// <summary>
        /// 描述 :长度 
        /// </summary>
        [Required(ErrorMessage = "长度不能为空")]

        [ExcelColumn(Name = "长度")]
        public decimal MaraLAENG { get; set; }

        /// <summary>
        /// 描述 :有效至  
        /// </summary>

        [ExcelColumn(Name = "有效至 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraLIQDT { get; set; }

        /// <summary>
        /// 描述 :退货到后勤等级 
        /// </summary>

        [ExcelColumn(Name = "退货到后勤等级")]
        public string MaraloglevReto { get; set; }

        /// <summary>
        /// 描述 :后勤计量单位 
        /// </summary>

        [ExcelColumn(Name = "后勤计量单位")]
        public string MaraLOGUNIT { get; set; }

        /// <summary>
        /// 描述 :集团级的 DF 
        /// </summary>

        [ExcelColumn(Name = "集团级的 DF")]
        public string MaraLVORM { get; set; }

        /// <summary>
        /// 描述 :物料组包装物料 
        /// </summary>

        [ExcelColumn(Name = "物料组包装物料")]
        public string MaraMAGRV { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// </summary>

        [ExcelColumn(Name = "集团")]
        public string MaraMANDT { get; set; }

        /// <summary>
        /// 描述 :物料被锁定  
        /// </summary>

        [ExcelColumn(Name = "物料被锁定 ")]
        public string MaraMATFI { get; set; }

        /// <summary>
        /// 描述 :物料组  
        /// </summary>
        [Required(ErrorMessage = "物料组 不能为空")]

        [ExcelColumn(Name = "物料组 ")]
        public string MaraMATKL { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MaraMATNR { get; set; }

        /// <summary>
        /// 描述 :最大包宽度 
        /// </summary>
        [Required(ErrorMessage = "最大包宽度不能为空")]

        [ExcelColumn(Name = "最大包宽度")]
        public decimal MaraMAXB { get; set; }

        /// <summary>
        /// 描述 :最大容量  
        /// </summary>
        [Required(ErrorMessage = "最大容量 不能为空")]

        [ExcelColumn(Name = "最大容量 ")]
        public decimal MaraMAXC { get; set; }

        /// <summary>
        /// 描述 :超过容量容差 
        /// </summary>
        [Required(ErrorMessage = "超过容量容差不能为空")]

        [ExcelColumn(Name = "超过容量容差")]
        public decimal MaramaxcTol { get; set; }

        /// <summary>
        /// 描述 :计量单位 
        /// </summary>

        [ExcelColumn(Name = "计量单位")]
        public string MaramaxdimUom { get; set; }

        /// <summary>
        /// 描述 :最大高度  
        /// </summary>
        [Required(ErrorMessage = "最大高度 不能为空")]

        [ExcelColumn(Name = "最大高度 ")]
        public decimal MaraMAXH { get; set; }

        /// <summary>
        /// 描述 :最大长度  
        /// </summary>
        [Required(ErrorMessage = "最大长度 不能为空")]

        [ExcelColumn(Name = "最大长度 ")]
        public decimal MaraMAXL { get; set; }

        /// <summary>
        /// 描述 :行业领域 
        /// </summary>
        [Required(ErrorMessage = "行业领域不能为空")]

        [ExcelColumn(Name = "行业领域")]
        public string MaraMBRSH { get; set; }

        /// <summary>
        /// 描述 :物料条件管理 
        /// </summary>

        [ExcelColumn(Name = "物料条件管理")]
        public string MaraMCOND { get; set; }

        /// <summary>
        /// 描述 :单位 
        /// </summary>

        [ExcelColumn(Name = "单位")]
        public string MaraMEABM { get; set; }

        /// <summary>
        /// 描述 :中间 
        /// </summary>

        [ExcelColumn(Name = "中间")]
        public string MaraMEDIUM { get; set; }

        /// <summary>
        /// 描述 :基本单位 
        /// </summary>
        [Required(ErrorMessage = "基本单位不能为空")]

        [ExcelColumn(Name = "基本单位")]
        public string MaraMEINS { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// </summary>

        [ExcelColumn(Name = "物料运输组 ")]
        public string MaraMFRGR { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// </summary>

        [ExcelColumn(Name = "制造商")]
        public string MaraMFRNR { get; set; }

        /// <summary>
        /// 描述 :制造商零件编号 
        /// </summary>

        [ExcelColumn(Name = "制造商零件编号")]
        public string MaraMFRPN { get; set; }

        /// <summary>
        /// 描述 :总货架寿命  
        /// </summary>
        [Required(ErrorMessage = "总货架寿命 不能为空")]

        [ExcelColumn(Name = "总货架寿命 ")]
        public decimal MaraMHDHB { get; set; }

        /// <summary>
        /// 描述 :仓储 % 
        /// </summary>
        [Required(ErrorMessage = "仓储 %不能为空")]

        [ExcelColumn(Name = "仓储 %")]
        public decimal MaraMHDLP { get; set; }

        /// <summary>
        /// 描述 :剩余货架寿命 
        /// </summary>
        [Required(ErrorMessage = "剩余货架寿命不能为空")]

        [ExcelColumn(Name = "剩余货架寿命")]
        public decimal MaraMHDRZ { get; set; }

        /// <summary>
        /// 描述 :含空BOM 
        /// </summary>

        [ExcelColumn(Name = "含空BOM")]
        public string MaraMLGUT { get; set; }

        /// <summary>
        /// 描述 :制造商部件参数文 
        /// </summary>

        [ExcelColumn(Name = "制造商部件参数文")]
        public string MaraMPROF { get; set; }

        /// <summary>
        /// 描述 :跨工厂物料状态 
        /// </summary>

        [ExcelColumn(Name = "跨工厂物料状态")]
        public string MaraMSTAE { get; set; }

        /// <summary>
        /// 描述 :跨分销链状态  
        /// </summary>

        [ExcelColumn(Name = "跨分销链状态 ")]
        public string MaraMSTAV { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// </summary>

        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraMSTDE { get; set; }

        /// <summary>
        /// 描述 :有效从  
        /// </summary>

        [ExcelColumn(Name = "有效从 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MaraMSTDV { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// </summary>
        [Required(ErrorMessage = "物料类型不能为空")]

        [ExcelColumn(Name = "物料类型")]
        public string MaraMTART { get; set; }

        /// <summary>
        /// 描述 :普通项目类别组 
        /// </summary>

        [ExcelColumn(Name = "普通项目类别组")]
        public string MaramtposMara { get; set; }

        /// <summary>
        /// 描述 :行业标准描述 
        /// </summary>

        [ExcelColumn(Name = "行业标准描述")]
        public string MaraNORMT { get; set; }

        /// <summary>
        /// 描述 :折扣类型 
        /// </summary>

        [ExcelColumn(Name = "折扣类型")]
        public string MaraNRFHG { get; set; }

        /// <summary>
        /// 描述 :NIIN 
        /// </summary>

        [ExcelColumn(Name = "NIIN")]
        public string MaraNSNID { get; set; }

        /// <summary>
        /// 描述 :净重  
        /// </summary>
        [Required(ErrorMessage = "净重 不能为空")]

        [ExcelColumn(Name = "净重 ")]
        public decimal MaraNTGEW { get; set; }

        /// <summary>
        /// 描述 :EAN 类别 
        /// </summary>

        [ExcelColumn(Name = "EAN 类别")]
        public string MaraNUMTP { get; set; }

        /// <summary>
        /// 描述 :Packaging Code 
        /// </summary>

        [ExcelColumn(Name = "Packaging Code")]
        public string MaraPACKCODE { get; set; }

        /// <summary>
        /// 描述 :链编号  
        /// </summary>

        [ExcelColumn(Name = "链编号 ")]
        public string MaraPICNUM { get; set; }

        /// <summary>
        /// 描述 :可偷窃的 
        /// </summary>

        [ExcelColumn(Name = "可偷窃的")]
        public string MaraPILFERABLE { get; set; }

        /// <summary>
        /// 描述 :价格标记类型 
        /// </summary>

        [ExcelColumn(Name = "价格标记类型")]
        public string MaraPLGTP { get; set; }

        /// <summary>
        /// 描述 :定价参考物料  
        /// </summary>

        [ExcelColumn(Name = "定价参考物料 ")]
        public string MaraPMATA { get; set; }

        /// <summary>
        /// 描述 :产品层次 
        /// </summary>

        [ExcelColumn(Name = "产品层次")]
        public string MaraPRDHA { get; set; }

        /// <summary>
        /// 描述 :DG标识参数文件 
        /// </summary>

        [ExcelColumn(Name = "DG标识参数文件")]
        public string MaraPROFL { get; set; }

        /// <summary>
        /// 描述 :产品成分 
        /// </summary>

        [ExcelColumn(Name = "产品成分")]
        public string MaraPRZUS { get; set; }

        /// <summary>
        /// 描述 :表格名  
        /// </summary>

        [ExcelColumn(Name = "表格名 ")]
        public string MarapsSmartform { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// </summary>

        [ExcelColumn(Name = "维护状态 ")]
        public string MaraPSTAT { get; set; }

        /// <summary>
        /// 描述 :质量检查组 
        /// </summary>

        [ExcelColumn(Name = "质量检查组")]
        public string MaraQGRP { get; set; }

        /// <summary>
        /// 描述 :QM 采购 
        /// </summary>

        [ExcelColumn(Name = "QM 采购")]
        public string MaraQMPUR { get; set; }

        /// <summary>
        /// 描述 :隔离期间 
        /// </summary>
        [Required(ErrorMessage = "隔离期间不能为空")]

        [ExcelColumn(Name = "隔离期间")]
        public decimal MaraQQTIME { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// </summary>

        [ExcelColumn(Name = "时间单位")]
        public string MaraQQTIMEUOM { get; set; }

        /// <summary>
        /// 描述 :存储条件 
        /// </summary>

        [ExcelColumn(Name = "存储条件")]
        public string MaraRAUBE { get; set; }

        /// <summary>
        /// 描述 :类别参数文件 
        /// </summary>

        [ExcelColumn(Name = "类别参数文件")]
        public string MaraRBNRM { get; set; }

        /// <summary>
        /// 描述 :舍入规则 
        /// </summary>

        [ExcelColumn(Name = "舍入规则")]
        public string MaraRDMHD { get; set; }

        /// <summary>
        /// 描述 :返回代码 
        /// </summary>

        [ExcelColumn(Name = "返回代码")]
        public string MaraRETDELC { get; set; }

        /// <summary>
        /// 描述 :包装的参考物料 
        /// </summary>

        [ExcelColumn(Name = "包装的参考物料")]
        public string MaraRMATP { get; set; }

        /// <summary>
        /// 描述 :季度年  
        /// </summary>

        [ExcelColumn(Name = "季度年 ")]
        public string MaraSAISJ { get; set; }

        /// <summary>
        /// 描述 :季节 
        /// </summary>

        [ExcelColumn(Name = "季节")]
        public string MaraSAISO { get; set; }

        /// <summary>
        /// 描述 :展开 
        /// </summary>

        [ExcelColumn(Name = "展开")]
        public string MaraSAITY { get; set; }

        /// <summary>
        /// 描述 :一般可配置物料 
        /// </summary>

        [ExcelColumn(Name = "一般可配置物料")]
        public string MaraSATNR { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// </summary>

        [ExcelColumn(Name = "序列号参数文件")]
        public string MaraSERIAL { get; set; }

        /// <summary>
        /// 描述 :序列化层次  
        /// </summary>

        [ExcelColumn(Name = "序列化层次 ")]
        public string MaraSERLV { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// </summary>

        [ExcelColumn(Name = "分段策略")]
        public string MarasgtCovsa { get; set; }

        /// <summary>
        /// 描述 :分段结构 
        /// </summary>

        [ExcelColumn(Name = "分段结构")]
        public string MarasgtCsgr { get; set; }

        /// <summary>
        /// 描述 :分段相关 
        /// </summary>

        [ExcelColumn(Name = "分段相关")]
        public string MarasgtRel { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// </summary>

        [ExcelColumn(Name = "分段范围")]
        public string MarasgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态  
        /// </summary>

        [ExcelColumn(Name = "分段状态 ")]
        public string MarasgtStat { get; set; }

        /// <summary>
        /// 描述 :主尺寸  
        /// </summary>

        [ExcelColumn(Name = "主尺寸 ")]
        public string MaraSIZE1 { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// </summary>

        [ExcelColumn(Name = "内部特性 ")]
        public string Marasize1Atinn { get; set; }

        /// <summary>
        /// 描述 :次尺寸  
        /// </summary>

        [ExcelColumn(Name = "次尺寸 ")]
        public string MaraSIZE2 { get; set; }

        /// <summary>
        /// 描述 :内部特性  
        /// </summary>

        [ExcelColumn(Name = "内部特性 ")]
        public string Marasize2Atinn { get; set; }

        /// <summary>
        /// 描述 :过期日期 
        /// </summary>

        [ExcelColumn(Name = "过期日期")]
        public string MarasledBbd { get; set; }

        /// <summary>
        /// 描述 :产品组  
        /// </summary>

        [ExcelColumn(Name = "产品组 ")]
        public string MaraSPART { get; set; }

        /// <summary>
        /// 描述 :定价参数文件 
        /// </summary>

        [ExcelColumn(Name = "定价参数文件")]
        public string MaraSPROF { get; set; }

        /// <summary>
        /// 描述 :堆栈因子 
        /// </summary>
        [Required(ErrorMessage = "堆栈因子不能为空")]

        [ExcelColumn(Name = "堆栈因子")]
        public int MaraSTFAK { get; set; }

        /// <summary>
        /// 描述 :危险物料号  
        /// </summary>

        [ExcelColumn(Name = "危险物料号 ")]
        public string MaraSTOFF { get; set; }

        /// <summary>
        /// 描述 :税收分类 
        /// </summary>

        [ExcelColumn(Name = "税收分类")]
        public string MaraTAKLV { get; set; }

        /// <summary>
        /// 描述 :可变皮重 
        /// </summary>

        [ExcelColumn(Name = "可变皮重")]
        public string MaratareVar { get; set; }

        /// <summary>
        /// 描述 :温度 
        /// </summary>

        [ExcelColumn(Name = "温度")]
        public string MaraTEMPB { get; set; }

        /// <summary>
        /// 描述 :纺织组分活动 
        /// </summary>

        [ExcelColumn(Name = "纺织组分活动")]
        public string MaratextileCompInd { get; set; }

        /// <summary>
        /// 描述 :运输组  
        /// </summary>

        [ExcelColumn(Name = "运输组 ")]
        public string MaraTRAGR { get; set; }

        /// <summary>
        /// 描述 :可变的订单单位 
        /// </summary>

        [ExcelColumn(Name = "可变的订单单位")]
        public string MaraVABME { get; set; }

        /// <summary>
        /// 描述 :包装物料类型 
        /// </summary>

        [ExcelColumn(Name = "包装物料类型")]
        public string MaraVHART { get; set; }

        /// <summary>
        /// 描述 :体积单位 
        /// </summary>

        [ExcelColumn(Name = "体积单位")]
        public string MaraVOLEH { get; set; }

        /// <summary>
        /// 描述 :超过体积容差 
        /// </summary>
        [Required(ErrorMessage = "超过体积容差不能为空")]

        [ExcelColumn(Name = "超过体积容差")]
        public decimal MaraVOLTO { get; set; }

        /// <summary>
        /// 描述 :业务量  
        /// </summary>
        [Required(ErrorMessage = "业务量 不能为空")]

        [ExcelColumn(Name = "业务量 ")]
        public decimal MaraVOLUM { get; set; }

        /// <summary>
        /// 描述 :比较价格单位 
        /// </summary>
        [Required(ErrorMessage = "比较价格单位不能为空")]

        [ExcelColumn(Name = "比较价格单位")]
        public decimal MaraVPREH { get; set; }

        /// <summary>
        /// 描述 :完整状态  
        /// </summary>

        [ExcelColumn(Name = "完整状态 ")]
        public string MaraVPSTA { get; set; }

        /// <summary>
        /// 描述 :原始接受 
        /// </summary>

        [ExcelColumn(Name = "原始接受")]
        public string MaraWEORA { get; set; }

        /// <summary>
        /// 描述 :GR单数量  
        /// </summary>
        [Required(ErrorMessage = "GR单数量 不能为空")]

        [ExcelColumn(Name = "GR单数量 ")]
        public decimal MaraWESCH { get; set; }

        /// <summary>
        /// 描述 :仓库物料组  
        /// </summary>

        [ExcelColumn(Name = "仓库物料组 ")]
        public string MaraWHMATGR { get; set; }

        /// <summary>
        /// 描述 :仓库存储条件 
        /// </summary>

        [ExcelColumn(Name = "仓库存储条件")]
        public string MaraWHSTC { get; set; }

        /// <summary>
        /// 描述 :基本物料 
        /// </summary>

        [ExcelColumn(Name = "基本物料")]
        public string MaraWRKST { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// </summary>

        [ExcelColumn(Name = "批次管理需求 ")]
        public string MaraXCHPF { get; set; }

        /// <summary>
        /// 描述 :需要批量记录  
        /// </summary>

        [ExcelColumn(Name = "需要批量记录 ")]
        public string MaraXGCHP { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// </summary>

        [ExcelColumn(Name = "凭证类型")]
        public string MaraZEIAR { get; set; }

        /// <summary>
        /// 描述 :页面大小 
        /// </summary>

        [ExcelColumn(Name = "页面大小")]
        public string MaraZEIFO { get; set; }

        /// <summary>
        /// 描述 :凭证 
        /// </summary>

        [ExcelColumn(Name = "凭证")]
        public string MaraZEINR { get; set; }

        /// <summary>
        /// 描述 :凭证版本 
        /// </summary>

        [ExcelColumn(Name = "凭证版本")]
        public string MaraZEIVR { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>

        [ExcelColumn(Name = "UDF01")]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>

        [ExcelColumn(Name = "UDF02")]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>

        [ExcelColumn(Name = "UDF03")]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>

        [ExcelColumn(Name = "UDF04")]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>

        [ExcelColumn(Name = "UDF05")]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>

        [ExcelColumn(Name = "UDF06")]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [Required(ErrorMessage = "UDF51不能为空")]

        [ExcelColumn(Name = "UDF51")]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [Required(ErrorMessage = "UDF52不能为空")]

        [ExcelColumn(Name = "UDF52")]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [Required(ErrorMessage = "UDF53不能为空")]

        [ExcelColumn(Name = "UDF53")]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [Required(ErrorMessage = "UDF54不能为空")]

        [ExcelColumn(Name = "UDF54")]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [Required(ErrorMessage = "UDF55不能为空")]

        [ExcelColumn(Name = "UDF55")]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [Required(ErrorMessage = "UDF56不能为空")]

        [ExcelColumn(Name = "UDF56")]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [Required(ErrorMessage = "IsDeleted不能为空")]

        [ExcelColumn(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>

        [ExcelColumn(Name = "Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>

        [ExcelColumn(Name = "CreateBy")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>

        [ExcelColumn(Name = "CreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>

        [ExcelColumn(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>

        [ExcelColumn(Name = "UpdateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }



    }
}