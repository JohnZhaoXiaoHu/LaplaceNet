using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 物料评估查询对象
    /// </summary>
    public class MmMbewQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 物料评估输入输出对象
    /// </summary>
    public class MmMbewDto
    {
        /// <summary>
        /// 描述 :ID主键 
        /// </summary>
        [Required(ErrorMessage = "ID主键不能为空")]

        [ExcelColumn(Name = "ID主键")]
        public int MbewID { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// </summary>

        [ExcelColumn(Name = "CC 库存盘点")]
        public string MbewABCIW { get; set; }

        /// <summary>
        /// 描述 :贬值标识   
        /// </summary>

        [ExcelColumn(Name = "贬值标识  ")]
        public string MbewABWKZ { get; set; }

        /// <summary>
        /// 描述 :评估类  
        /// </summary>

        [ExcelColumn(Name = "评估类 ")]
        public string MbewBKLAS { get; set; }

        /// <summary>
        /// 描述 :评估范围 
        /// </summary>
        [Required(ErrorMessage = "评估范围不能为空")]

        [ExcelColumn(Name = "评估范围")]
        public string MbewBWKEY { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// </summary>
        [Required(ErrorMessage = "价格单位不能为空")]

        [ExcelColumn(Name = "价格单位")]
        public decimal MbewBWPEI { get; set; }

        /// <summary>
        /// 描述 :商业价格 2 
        /// </summary>
        [Required(ErrorMessage = "商业价格 2不能为空")]

        [ExcelColumn(Name = "商业价格 2")]
        public decimal MbewBWPH1 { get; set; }

        /// <summary>
        /// 描述 :商业价格 1 
        /// </summary>
        [Required(ErrorMessage = "商业价格 1不能为空")]

        [ExcelColumn(Name = "商业价格 1")]
        public decimal MbewBWPRH { get; set; }

        /// <summary>
        /// 描述 :税价1 
        /// </summary>
        [Required(ErrorMessage = "税价1不能为空")]

        [ExcelColumn(Name = "税价1")]
        public decimal MbewBWPRS { get; set; }

        /// <summary>
        /// 描述 :税价2 
        /// </summary>
        [Required(ErrorMessage = "税价2不能为空")]

        [ExcelColumn(Name = "税价2")]
        public decimal MbewBWPS1 { get; set; }

        /// <summary>
        /// 描述 :评价毛利 
        /// </summary>
        [Required(ErrorMessage = "评价毛利不能为空")]

        [ExcelColumn(Name = "评价毛利")]
        public decimal MbewBWSPA { get; set; }

        /// <summary>
        /// 描述 :评估类型 
        /// </summary>
        [Required(ErrorMessage = "评估类型不能为空")]

        [ExcelColumn(Name = "评估类型")]
        public string MbewBWTAR { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// </summary>

        [ExcelColumn(Name = "评估类别")]
        public string MbewBWTTY { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// </summary>

        [ExcelColumn(Name = "评估变式")]
        public string MbewBWVA1 { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// </summary>

        [ExcelColumn(Name = "评估变式")]
        public string MbewBWVA2 { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// </summary>

        [ExcelColumn(Name = "评估变式")]
        public string MbewBWVA3 { get; set; }

        /// <summary>
        /// 描述 :用QS的成本估算 
        /// </summary>

        [ExcelColumn(Name = "用QS的成本估算")]
        public string MbewEKALR { get; set; }

        /// <summary>
        /// 描述 :VC:销售订单库存 
        /// </summary>

        [ExcelColumn(Name = "VC:销售订单库存")]
        public string MbewEKLAS { get; set; }

        /// <summary>
        /// 描述 :未来评估决策 
        /// </summary>

        [ExcelColumn(Name = "未来评估决策")]
        public string MbewFBWST { get; set; }

        /// <summary>
        /// 描述 :固定的未来计划价格 
        /// </summary>
        [Required(ErrorMessage = "固定的未来计划价格不能为空")]

        [ExcelColumn(Name = "固定的未来计划价格")]
        public decimal MbewFPLPX { get; set; }

        /// <summary>
        /// 描述 :物料来源 
        /// </summary>

        [ExcelColumn(Name = "物料来源")]
        public string MbewHKMAT { get; set; }

        /// <summary>
        /// 描述 :原始组  
        /// </summary>

        [ExcelColumn(Name = "原始组 ")]
        public string MbewHRKFT { get; set; }

        /// <summary>
        /// 描述 :当前成本估算 
        /// </summary>

        [ExcelColumn(Name = "当前成本估算")]
        public string MbewKALKL { get; set; }

        /// <summary>
        /// 描述 :上期成本估计 
        /// </summary>

        [ExcelColumn(Name = "上期成本估计")]
        public string MbewKALKV { get; set; }

        /// <summary>
        /// 描述 :未来成本估算 
        /// </summary>

        [ExcelColumn(Name = "未来成本估算")]
        public string MbewKALKZ { get; set; }

        /// <summary>
        /// 描述 :产品成本核算号 
        /// </summary>

        [ExcelColumn(Name = "产品成本核算号")]
        public string MbewKALN1 { get; set; }

        /// <summary>
        /// 描述 :成本估算编号 
        /// </summary>

        [ExcelColumn(Name = "成本估算编号")]
        public string MbewKALNR { get; set; }

        /// <summary>
        /// 描述 :一般费用代码  
        /// </summary>

        [ExcelColumn(Name = "一般费用代码 ")]
        public string MbewKALSC { get; set; }

        /// <summary>
        /// 描述 :间接费分组  
        /// </summary>

        [ExcelColumn(Name = "间接费分组 ")]
        public string MbewKOSGR { get; set; }

        /// <summary>
        /// 描述 :盘点库存VO物料 
        /// </summary>

        [ExcelColumn(Name = "盘点库存VO物料")]
        public string MbewKZIWL { get; set; }

        /// <summary>
        /// 描述 :最近价格更改  
        /// </summary>

        [ExcelColumn(Name = "最近价格更改 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewLAEPR { get; set; }

        /// <summary>
        /// 描述 :总库存  
        /// </summary>
        [Required(ErrorMessage = "总库存 不能为空")]

        [ExcelColumn(Name = "总库存 ")]
        public decimal MbewLBKUM { get; set; }

        /// <summary>
        /// 描述 :当前的值决策  
        /// </summary>

        [ExcelColumn(Name = "当前的值决策 ")]
        public string MbewLBWST { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// </summary>

        [ExcelColumn(Name = "年  当前期间")]
        public string MbewLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// </summary>

        [ExcelColumn(Name = "本期")]
        public string MbewLFMON { get; set; }

        /// <summary>
        /// 描述 :当前计划价格 
        /// </summary>
        [Required(ErrorMessage = "当前计划价格不能为空")]

        [ExcelColumn(Name = "当前计划价格")]
        public decimal MbewLPLPR { get; set; }

        /// <summary>
        /// 描述 :固定的当前计划价格 
        /// </summary>
        [Required(ErrorMessage = "固定的当前计划价格不能为空")]

        [ExcelColumn(Name = "固定的当前计划价格")]
        public decimal MbewLPLPX { get; set; }

        /// <summary>
        /// 描述 :评估类型 
        /// </summary>

        [ExcelColumn(Name = "评估类型")]
        public string MbewLVORM { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// </summary>
        [Required(ErrorMessage = "集团不能为空")]

        [ExcelColumn(Name = "集团")]
        public string MbewMANDT { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MbewMATNR { get; set; }

        /// <summary>
        /// 描述 :MBEW 最后期间之前，期间的 MBEW 
        /// </summary>

        [ExcelColumn(Name = "MBEW 最后期间之前，期间的 MBEW")]
        public string MbewMBRUE { get; set; }

        /// <summary>
        /// 描述 :价格确定 
        /// </summary>

        [ExcelColumn(Name = "价格确定")]
        public string MbewMLAST { get; set; }

        /// <summary>
        /// 描述 :ML 作业 
        /// </summary>

        [ExcelColumn(Name = "ML 作业")]
        public string MbewMLMAA { get; set; }

        /// <summary>
        /// 描述 :物料来源 
        /// </summary>

        [ExcelColumn(Name = "物料来源")]
        public string MbewMTORG { get; set; }

        /// <summary>
        /// 描述 :物料用途  
        /// </summary>

        [ExcelColumn(Name = "物料用途 ")]
        public string MbewMTUSE { get; set; }

        /// <summary>
        /// 描述 :LIFO评估储备号  
        /// </summary>

        [ExcelColumn(Name = "LIFO评估储备号 ")]
        public string MbewMYPOL { get; set; }

        /// <summary>
        /// 描述 :预付库存 
        /// </summary>

        [ExcelColumn(Name = "预付库存")]
        public string MbewOIPPINV { get; set; }

        /// <summary>
        /// 描述 :VC: 供应商  
        /// </summary>

        [ExcelColumn(Name = "VC: 供应商 ")]
        public string MbewOKLAS { get; set; }

        /// <summary>
        /// 描述 :自制产品 
        /// </summary>

        [ExcelColumn(Name = "自制产品")]
        public string MbewOWNPR { get; set; }

        /// <summary>
        /// 描述 :当前会计年度 
        /// </summary>

        [ExcelColumn(Name = "当前会计年度")]
        public string MbewPDATL { get; set; }

        /// <summary>
        /// 描述 :上一会计年  
        /// </summary>

        [ExcelColumn(Name = "上一会计年 ")]
        public string MbewPDATV { get; set; }

        /// <summary>
        /// 描述 :来年会计年度 
        /// </summary>

        [ExcelColumn(Name = "来年会计年度")]
        public string MbewPDATZ { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// </summary>
        [Required(ErrorMessage = "价格单位不能为空")]

        [ExcelColumn(Name = "价格单位")]
        public decimal MbewPEINH { get; set; }

        /// <summary>
        /// 描述 :期间成本估算 
        /// </summary>

        [ExcelColumn(Name = "期间成本估算")]
        public string MbewPPERL { get; set; }

        /// <summary>
        /// 描述 :上期成本估算 
        /// </summary>

        [ExcelColumn(Name = "上期成本估算")]
        public string MbewPPERV { get; set; }

        /// <summary>
        /// 描述 :未来成本估算 
        /// </summary>

        [ExcelColumn(Name = "未来成本估算")]
        public string MbewPPERZ { get; set; }

        /// <summary>
        /// 描述 :当前期间 
        /// </summary>

        [ExcelColumn(Name = "当前期间")]
        public string MbewPPRDL { get; set; }

        /// <summary>
        /// 描述 :前一期间 
        /// </summary>

        [ExcelColumn(Name = "前一期间")]
        public string MbewPPRDV { get; set; }

        /// <summary>
        /// 描述 :记帐期间 
        /// </summary>

        [ExcelColumn(Name = "记帐期间")]
        public string MbewPPRDZ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// </summary>

        [ExcelColumn(Name = "维护状态 ")]
        public string MbewPSTAT { get; set; }

        /// <summary>
        /// 描述 :项目库存评估类 
        /// </summary>

        [ExcelColumn(Name = "项目库存评估类")]
        public string MbewQKLAS { get; set; }

        /// <summary>
        /// 描述 :总价值  
        /// </summary>
        [Required(ErrorMessage = "总价值 不能为空")]

        [ExcelColumn(Name = "总价值 ")]
        public decimal MbewSALK3 { get; set; }

        /// <summary>
        /// 描述 :价值/MA价格 
        /// </summary>
        [Required(ErrorMessage = "价值/MA价格不能为空")]

        [ExcelColumn(Name = "价值/MA价格")]
        public decimal MbewSALKV { get; set; }

        /// <summary>
        /// 描述 :库存冻结 
        /// </summary>

        [ExcelColumn(Name = "库存冻结")]
        public string MbewSPERW { get; set; }

        /// <summary>
        /// 描述 :标准价格 
        /// </summary>
        [Required(ErrorMessage = "标准价格不能为空")]

        [ExcelColumn(Name = "标准价格")]
        public decimal MbewSTPRS { get; set; }

        /// <summary>
        /// 描述 :上期价格 
        /// </summary>
        [Required(ErrorMessage = "上期价格不能为空")]

        [ExcelColumn(Name = "上期价格")]
        public decimal MbewSTPRV { get; set; }

        /// <summary>
        /// 描述 :时戳 
        /// </summary>
        [Required(ErrorMessage = "时戳不能为空")]

        [ExcelColumn(Name = "时戳")]
        public decimal MbewTIMESTAMP { get; set; }

        /// <summary>
        /// 描述 :上年评估策略 
        /// </summary>

        [ExcelColumn(Name = "上年评估策略")]
        public string MbewVBWST { get; set; }

        /// <summary>
        /// 描述 :移动价格 
        /// </summary>
        [Required(ErrorMessage = "移动价格不能为空")]

        [ExcelColumn(Name = "移动价格")]
        public decimal MbewVERPR { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// </summary>

        [ExcelColumn(Name = "成本核算版本")]
        public string MbewVERS1 { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// </summary>

        [ExcelColumn(Name = "成本核算版本")]
        public string MbewVERS2 { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// </summary>

        [ExcelColumn(Name = "成本核算版本")]
        public string MbewVERS3 { get; set; }

        /// <summary>
        /// 描述 :上年估价类  
        /// </summary>

        [ExcelColumn(Name = "上年估价类 ")]
        public string MbewVJBKL { get; set; }

        /// <summary>
        /// 描述 :商业价格 3 
        /// </summary>
        [Required(ErrorMessage = "商业价格 3不能为空")]

        [ExcelColumn(Name = "商业价格 3")]
        public decimal MbewVJBWH { get; set; }

        /// <summary>
        /// 描述 :税价3 
        /// </summary>
        [Required(ErrorMessage = "税价3不能为空")]

        [ExcelColumn(Name = "税价3")]
        public decimal MbewVJBWS { get; set; }

        /// <summary>
        /// 描述 :前年总库存值  
        /// </summary>
        [Required(ErrorMessage = "前年总库存值 不能为空")]

        [ExcelColumn(Name = "前年总库存值 ")]
        public decimal MbewVJKUM { get; set; }

        /// <summary>
        /// 描述 :上年价格单位 
        /// </summary>
        [Required(ErrorMessage = "上年价格单位不能为空")]

        [ExcelColumn(Name = "上年价格单位")]
        public decimal MbewVJPEI { get; set; }

        /// <summary>
        /// 描述 :上年总值  
        /// </summary>
        [Required(ErrorMessage = "上年总值 不能为空")]

        [ExcelColumn(Name = "上年总值 ")]
        public decimal MbewVJSAL { get; set; }

        /// <summary>
        /// 描述 :上年价值  
        /// </summary>
        [Required(ErrorMessage = "上年价值 不能为空")]

        [ExcelColumn(Name = "上年价值 ")]
        public decimal MbewVJSAV { get; set; }

        /// <summary>
        /// 描述 :去年标准价格 
        /// </summary>
        [Required(ErrorMessage = "去年标准价格不能为空")]

        [ExcelColumn(Name = "去年标准价格")]
        public decimal MbewVJSTP { get; set; }

        /// <summary>
        /// 描述 :去年移动平均价 
        /// </summary>
        [Required(ErrorMessage = "去年移动平均价不能为空")]

        [ExcelColumn(Name = "去年移动平均价")]
        public decimal MbewVJVER { get; set; }

        /// <summary>
        /// 描述 :前一年价格控制 
        /// </summary>

        [ExcelColumn(Name = "前一年价格控制")]
        public string MbewVJVPR { get; set; }

        /// <summary>
        /// 描述 :总SP值  
        /// </summary>
        [Required(ErrorMessage = "总SP值 不能为空")]

        [ExcelColumn(Name = "总SP值 ")]
        public decimal MbewVKSAL { get; set; }

        /// <summary>
        /// 描述 :上期的评价分类 
        /// </summary>

        [ExcelColumn(Name = "上期的评价分类")]
        public string MbewVMBKL { get; set; }

        /// <summary>
        /// 描述 :前期总库存  
        /// </summary>
        [Required(ErrorMessage = "前期总库存 不能为空")]

        [ExcelColumn(Name = "前期总库存 ")]
        public decimal MbewVMKUM { get; set; }

        /// <summary>
        /// 描述 :上期间价格单位 
        /// </summary>
        [Required(ErrorMessage = "上期间价格单位不能为空")]

        [ExcelColumn(Name = "上期间价格单位")]
        public decimal MbewVMPEI { get; set; }

        /// <summary>
        /// 描述 :前期总值  
        /// </summary>
        [Required(ErrorMessage = "前期总值 不能为空")]

        [ExcelColumn(Name = "前期总值 ")]
        public decimal MbewVMSAL { get; set; }

        /// <summary>
        /// 描述 :上期的价值  
        /// </summary>
        [Required(ErrorMessage = "上期的价值 不能为空")]

        [ExcelColumn(Name = "上期的价值 ")]
        public decimal MbewVMSAV { get; set; }

        /// <summary>
        /// 描述 :前期标准价格 
        /// </summary>
        [Required(ErrorMessage = "前期标准价格不能为空")]

        [ExcelColumn(Name = "前期标准价格")]
        public decimal MbewVMSTP { get; set; }

        /// <summary>
        /// 描述 :前期移动平均价 
        /// </summary>
        [Required(ErrorMessage = "前期移动平均价不能为空")]

        [ExcelColumn(Name = "前期移动平均价")]
        public decimal MbewVMVER { get; set; }

        /// <summary>
        /// 描述 :前期间价格控制 
        /// </summary>

        [ExcelColumn(Name = "前期间价格控制")]
        public string MbewVMVPR { get; set; }

        /// <summary>
        /// 描述 :上期标准价格 
        /// </summary>
        [Required(ErrorMessage = "上期标准价格不能为空")]

        [ExcelColumn(Name = "上期标准价格")]
        public decimal MbewVPLPR { get; set; }

        /// <summary>
        /// 描述 :固定的上年计划价格 
        /// </summary>
        [Required(ErrorMessage = "固定的上年计划价格不能为空")]

        [ExcelColumn(Name = "固定的上年计划价格")]
        public decimal MbewVPLPX { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// </summary>

        [ExcelColumn(Name = "价格控制")]
        public string MbewVPRSV { get; set; }

        /// <summary>
        /// 描述 :前年的总库存  
        /// </summary>
        [Required(ErrorMessage = "前年的总库存 不能为空")]

        [ExcelColumn(Name = "前年的总库存 ")]
        public decimal MbewVVJLB { get; set; }

        /// <summary>
        /// 描述 :计价在  
        /// </summary>
        [Required(ErrorMessage = "计价在 不能为空")]

        [ExcelColumn(Name = "计价在 ")]
        public decimal MbewVVJSL { get; set; }

        /// <summary>
        /// 描述 :前期的总库存值 
        /// </summary>
        [Required(ErrorMessage = "前期的总库存值不能为空")]

        [ExcelColumn(Name = "前期的总库存值")]
        public decimal MbewVVMLB { get; set; }

        /// <summary>
        /// 描述 :计价在  
        /// </summary>
        [Required(ErrorMessage = "计价在 不能为空")]

        [ExcelColumn(Name = "计价在 ")]
        public decimal MbewVVSAL { get; set; }

        /// <summary>
        /// 描述 :最后实际盘点日 
        /// </summary>

        [ExcelColumn(Name = "最后实际盘点日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewWLINL { get; set; }

        /// <summary>
        /// 描述 :评估单位 
        /// </summary>

        [ExcelColumn(Name = "评估单位")]
        public string MbewXBEWM { get; set; }

        /// <summary>
        /// 描述 :LIFO/FIFO-相关 
        /// </summary>

        [ExcelColumn(Name = "LIFO/FIFO-相关")]
        public string MbewXLIFO { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// </summary>

        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewZKDAT { get; set; }

        /// <summary>
        /// 描述 :未来价格 
        /// </summary>
        [Required(ErrorMessage = "未来价格不能为空")]

        [ExcelColumn(Name = "未来价格")]
        public decimal MbewZKPRS { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 1 
        /// </summary>

        [ExcelColumn(Name = "计划价格日期 1", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewZPLD1 { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 2 
        /// </summary>

        [ExcelColumn(Name = "计划价格日期 2", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewZPLD2 { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 3 
        /// </summary>

        [ExcelColumn(Name = "计划价格日期 3", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MbewZPLD3 { get; set; }

        /// <summary>
        /// 描述 :计划价格 1 
        /// </summary>
        [Required(ErrorMessage = "计划价格 1不能为空")]

        [ExcelColumn(Name = "计划价格 1")]
        public decimal MbewZPLP1 { get; set; }

        /// <summary>
        /// 描述 :计划价格 2 
        /// </summary>
        [Required(ErrorMessage = "计划价格 2不能为空")]

        [ExcelColumn(Name = "计划价格 2")]
        public decimal MbewZPLP2 { get; set; }

        /// <summary>
        /// 描述 :计划价格 3 
        /// </summary>
        [Required(ErrorMessage = "计划价格 3不能为空")]

        [ExcelColumn(Name = "计划价格 3")]
        public decimal MbewZPLP3 { get; set; }

        /// <summary>
        /// 描述 :未来计划价格 
        /// </summary>
        [Required(ErrorMessage = "未来计划价格不能为空")]

        [ExcelColumn(Name = "未来计划价格")]
        public decimal MbewZPLPR { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}