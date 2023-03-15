﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 工厂物料数据查询对象
    /// </summary>
    public class MmMarcQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 工厂物料数据输入输出对象
    /// </summary>
    public class MmMarcDto
    {
        /// <summary>
        /// 描述 :ID主键 
        /// </summary>
        [Required(ErrorMessage = "ID主键不能为空")]

        [ExcelColumn(Name = "ID主键")]
        public int MarcID { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// </summary>

        [ExcelColumn(Name = "CC 库存盘点")]
        public string MarcABCIN { get; set; }

        /// <summary>
        /// 描述 :空气浮力因子 
        /// </summary>
        [Required(ErrorMessage = "空气浮力因子不能为空")]

        [ExcelColumn(Name = "空气浮力因子")]
        public decimal MarcABFAC { get; set; }

        /// <summary>
        /// 描述 :MRP 相关需求  
        /// </summary>

        [ExcelColumn(Name = "MRP 相关需求 ")]
        public string MarcAHDIS { get; set; }

        /// <summary>
        /// 描述 :选择方法 
        /// </summary>

        [ExcelColumn(Name = "选择方法")]
        public string MarcALTSL { get; set; }

        /// <summary>
        /// 描述 :组计数器 
        /// </summary>

        [ExcelColumn(Name = "组计数器")]
        public string MarcAPLAL { get; set; }

        /// <summary>
        /// 描述 :相关于 APO 
        /// </summary>

        [ExcelColumn(Name = "相关于 APO")]
        public string MarcAPOKZ { get; set; }

        /// <summary>
        /// 描述 :替换部件 
        /// </summary>

        [ExcelColumn(Name = "替换部件")]
        public string MarcATPKZ { get; set; }

        /// <summary>
        /// 描述 :分割标识 
        /// </summary>

        [ExcelColumn(Name = "分割标识")]
        public string MarcAUFTL { get; set; }

        /// <summary>
        /// 描述 :中断日期 
        /// </summary>

        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcAUSDT { get; set; }

        /// <summary>
        /// 描述 :发货单位 
        /// </summary>

        [ExcelColumn(Name = "发货单位")]
        public string MarcAUSME { get; set; }

        /// <summary>
        /// 描述 :装配报废 
        /// </summary>
        [Required(ErrorMessage = "装配报废不能为空")]

        [ExcelColumn(Name = "装配报废")]
        public decimal MarcAUSSS { get; set; }

        /// <summary>
        /// 描述 :自动重置 
        /// </summary>

        [ExcelColumn(Name = "自动重置")]
        public string MarcAUTRU { get; set; }

        /// <summary>
        /// 描述 :差异码  
        /// </summary>

        [ExcelColumn(Name = "差异码 ")]
        public string MarcAWSLS { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// </summary>
        [Required(ErrorMessage = "基准数量不能为空")]

        [ExcelColumn(Name = "基准数量")]
        public decimal MarcBASMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// </summary>
        [Required(ErrorMessage = "处理时间不能为空")]

        [ExcelColumn(Name = "处理时间")]
        public decimal MarcBEARZ { get; set; }

        /// <summary>
        /// 描述 :采购 
        /// </summary>
        [Required(ErrorMessage = "采购不能为空")]

        [ExcelColumn(Name = "采购")]
        public string MarcBESKZ { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// </summary>
        [Required(ErrorMessage = "固定批量大小不能为空")]

        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcBSTFE { get; set; }

        /// <summary>
        /// 描述 :最大批量  
        /// </summary>
        [Required(ErrorMessage = "最大批量 不能为空")]

        [ExcelColumn(Name = "最大批量 ")]
        public decimal MarcBSTMA { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// </summary>
        [Required(ErrorMessage = "最小批量大小 不能为空")]

        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcBSTMI { get; set; }

        /// <summary>
        /// 描述 :舍入值  
        /// </summary>
        [Required(ErrorMessage = "舍入值 不能为空")]

        [ExcelColumn(Name = "舍入值 ")]
        public decimal MarcBSTRF { get; set; }

        /// <summary>
        /// 描述 :评估收货锁定库存 
        /// </summary>
        [Required(ErrorMessage = "评估收货锁定库存不能为空")]

        [ExcelColumn(Name = "评估收货锁定库存")]
        public decimal MarcBWESB { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// </summary>

        [ExcelColumn(Name = "货源")]
        public string MarcBWSCL { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// </summary>

        [ExcelColumn(Name = "评估类别")]
        public string MarcBWTTY { get; set; }

        /// <summary>
        /// 描述 :CAS 号（药品）  
        /// </summary>

        [ExcelColumn(Name = "CAS 号（药品） ")]
        public string MarcCASNR { get; set; }

        /// <summary>
        /// 描述 :周期标识被固定 
        /// </summary>

        [ExcelColumn(Name = "周期标识被固定")]
        public string MarcCCFIX { get; set; }

        /// <summary>
        /// 描述 :该字段不再使用 
        /// </summary>

        [ExcelColumn(Name = "该字段不再使用")]
        public string MarcCOMPL { get; set; }

        /// <summary>
        /// 描述 :寄售控制 
        /// </summary>

        [ExcelColumn(Name = "寄售控制")]
        public string MarcconsProcg { get; set; }

        /// <summary>
        /// 描述 :转换类型 
        /// </summary>

        [ExcelColumn(Name = "转换类型")]
        public string MarcCONVT { get; set; }

        /// <summary>
        /// 描述 :字段名  
        /// </summary>

        [ExcelColumn(Name = "字段名 ")]
        public string MarcCOPAM { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// </summary>

        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBJ { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// </summary>

        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBV { get; set; }

        /// <summary>
        /// 描述 :MRP  范围存在 
        /// </summary>

        [ExcelColumn(Name = "MRP  范围存在")]
        public string MarcDIBER { get; set; }

        /// <summary>
        /// 描述 :MRP组  
        /// </summary>

        [ExcelColumn(Name = "MRP组 ")]
        public string MarcDISGR { get; set; }

        /// <summary>
        /// 描述 :批量大小 
        /// </summary>
        [Required(ErrorMessage = "批量大小不能为空")]

        [ExcelColumn(Name = "批量大小")]
        public string MarcDISLS { get; set; }

        /// <summary>
        /// 描述 :MRP 类型 
        /// </summary>
        [Required(ErrorMessage = "MRP 类型不能为空")]

        [ExcelColumn(Name = "MRP 类型")]
        public string MarcDISMM { get; set; }

        /// <summary>
        /// 描述 :MRP 控制者  
        /// </summary>

        [ExcelColumn(Name = "MRP 控制者 ")]
        public string MarcDISPO { get; set; }

        /// <summary>
        /// 描述 :MRP 参数文件 
        /// </summary>

        [ExcelColumn(Name = "MRP 参数文件")]
        public string MarcDISPR { get; set; }

        /// <summary>
        /// 描述 :公平分享规则 
        /// </summary>

        [ExcelColumn(Name = "公平分享规则")]
        public string MarcDPLFS { get; set; }

        /// <summary>
        /// 描述 :发布界限 
        /// </summary>
        [Required(ErrorMessage = "发布界限不能为空")]

        [ExcelColumn(Name = "发布界限")]
        public decimal MarcDPLHO { get; set; }

        /// <summary>
        /// 描述 :推式分配 
        /// </summary>

        [ExcelColumn(Name = "推式分配")]
        public string MarcDPLPU { get; set; }

        /// <summary>
        /// 描述 :厂内生产时间 
        /// </summary>
        [Required(ErrorMessage = "厂内生产时间不能为空")]

        [ExcelColumn(Name = "厂内生产时间")]
        public decimal MarcDZEIT { get; set; }

        /// <summary>
        /// 描述 :安全库存 
        /// </summary>
        [Required(ErrorMessage = "安全库存不能为空")]

        [ExcelColumn(Name = "安全库存")]
        public decimal MarcEISBE { get; set; }

        /// <summary>
        /// 描述 :最小安全库存  
        /// </summary>
        [Required(ErrorMessage = "最小安全库存 不能为空")]

        [ExcelColumn(Name = "最小安全库存 ")]
        public decimal MarcEISLO { get; set; }

        /// <summary>
        /// 描述 :采购组  
        /// </summary>
        [Required(ErrorMessage = "采购组 不能为空")]

        [ExcelColumn(Name = "采购组 ")]
        public string MarcEKGRP { get; set; }

        /// <summary>
        /// 描述 :库存确定组  
        /// </summary>

        [ExcelColumn(Name = "库存确定组 ")]
        public string MarcEPRIO { get; set; }

        /// <summary>
        /// 描述 :商品代码单位 
        /// </summary>

        [ExcelColumn(Name = "商品代码单位")]
        public string MarcEXPME { get; set; }

        /// <summary>
        /// 描述 :JIT 标识 
        /// </summary>

        [ExcelColumn(Name = "JIT 标识")]
        public string MarcFABKZ { get; set; }

        /// <summary>
        /// 描述 :生产管理员  
        /// </summary>

        [ExcelColumn(Name = "生产管理员 ")]
        public string MarcFEVOR { get; set; }

        /// <summary>
        /// 描述 :自动批准 
        /// </summary>

        [ExcelColumn(Name = "自动批准")]
        public string MarcFFREI { get; set; }

        /// <summary>
        /// 描述 :计划边际码  
        /// </summary>

        [ExcelColumn(Name = "计划边际码 ")]
        public string MarcFHORI { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// </summary>
        [Required(ErrorMessage = "固定批量大小不能为空")]

        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcFIXLS { get; set; }

        /// <summary>
        /// 描述 :分配 prof. 
        /// </summary>

        [ExcelColumn(Name = "分配 prof.")]
        public string MarcFPRFM { get; set; }

        /// <summary>
        /// 描述 :生产单位 
        /// </summary>

        [ExcelColumn(Name = "生产单位")]
        public string MarcFRTME { get; set; }

        /// <summary>
        /// 描述 :订单分配运行 
        /// </summary>

        [ExcelColumn(Name = "订单分配运行")]
        public string MarcfshMgArunReq { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// </summary>

        [ExcelColumn(Name = "库存管理中激活季节")]
        public string MarcfshSeaim { get; set; }

        /// <summary>
        /// 描述 :生产版本 
        /// </summary>

        [ExcelColumn(Name = "生产版本")]
        public string MarcFVIDK { get; set; }

        /// <summary>
        /// 描述 :计划的时界  
        /// </summary>

        [ExcelColumn(Name = "计划的时界 ")]
        public string MarcFXHOR { get; set; }

        /// <summary>
        /// 描述 :固定价格联产品 
        /// </summary>

        [ExcelColumn(Name = "固定价格联产品")]
        public string MarcFXPRU { get; set; }

        /// <summary>
        /// 描述 :发货处理时间 
        /// </summary>
        [Required(ErrorMessage = "发货处理时间不能为空")]

        [ExcelColumn(Name = "发货处理时间")]
        public decimal MarcgiPrTime { get; set; }

        /// <summary>
        /// 描述 :有约束的虚拟 
        /// </summary>
        [Required(ErrorMessage = "有约束的虚拟不能为空")]

        [ExcelColumn(Name = "有约束的虚拟")]
        public decimal MarcGLGMG { get; set; }

        /// <summary>
        /// 描述 :粗略计划 
        /// </summary>

        [ExcelColumn(Name = "粗略计划")]
        public string MarcGPMKZ { get; set; }

        /// <summary>
        /// 描述 :PRODCOM号  
        /// </summary>

        [ExcelColumn(Name = "PRODCOM号 ")]
        public string MarcGPNUM { get; set; }

        /// <summary>
        /// 描述 :生产状态  
        /// </summary>

        [ExcelColumn(Name = "生产状态 ")]
        public string MarcHERBL { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// </summary>

        [ExcelColumn(Name = "原产地国")]
        public string MarcHERKL { get; set; }

        /// <summary>
        /// 描述 :货源地  
        /// </summary>

        [ExcelColumn(Name = "货源地 ")]
        public string MarcHERKR { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// </summary>

        [ExcelColumn(Name = "物料类别")]
        public string MarcINDUS { get; set; }

        /// <summary>
        /// 描述 :过帐到检验库存 
        /// </summary>
        [Required(ErrorMessage = "过帐到检验库存不能为空")]

        [ExcelColumn(Name = "过帐到检验库存")]
        public string MarcINSMK { get; set; }

        /// <summary>
        /// 描述 :军用物资 
        /// </summary>

        [ExcelColumn(Name = "军用物资")]
        public string MarcITARK { get; set; }

        /// <summary>
        /// 描述 :IUID 相关 
        /// </summary>

        [ExcelColumn(Name = "IUID 相关")]
        public string MarciuidRelevant { get; set; }

        /// <summary>
        /// 描述 :IUID 类型 
        /// </summary>

        [ExcelColumn(Name = "IUID 类型")]
        public string MarciuidType { get; set; }

        /// <summary>
        /// 描述 :组件报废 
        /// </summary>
        [Required(ErrorMessage = "组件报废不能为空")]

        [ExcelColumn(Name = "组件报废")]
        public decimal MarcKAUSF { get; set; }

        /// <summary>
        /// 描述 :自动采购单  
        /// </summary>

        [ExcelColumn(Name = "自动采购单 ")]
        public string MarcKAUTB { get; set; }

        /// <summary>
        /// 描述 :源清单  
        /// </summary>

        [ExcelColumn(Name = "源清单 ")]
        public string MarcKORDB { get; set; }

        /// <summary>
        /// 描述 :平滑促销消耗  
        /// </summary>

        [ExcelColumn(Name = "平滑促销消耗 ")]
        public string MarcKZAGL { get; set; }

        /// <summary>
        /// 描述 :非连续标识  
        /// </summary>

        [ExcelColumn(Name = "非连续标识 ")]
        public string MarcKZAUS { get; set; }

        /// <summary>
        /// 描述 :需求分组  
        /// </summary>

        [ExcelColumn(Name = "需求分组 ")]
        public string MarcKZBED { get; set; }

        /// <summary>
        /// 描述 :MRP控制者=买者  
        /// </summary>

        [ExcelColumn(Name = "MRP控制者=买者 ")]
        public string MarcKZDIE { get; set; }

        /// <summary>
        /// 描述 :凭证需求  
        /// </summary>

        [ExcelColumn(Name = "凭证需求 ")]
        public string MarcKZDKZ { get; set; }

        /// <summary>
        /// 描述 :输入批量 
        /// </summary>

        [ExcelColumn(Name = "输入批量")]
        public string MarcKZECH { get; set; }

        /// <summary>
        /// 描述 :修正因子 
        /// </summary>

        [ExcelColumn(Name = "修正因子")]
        public string MarcKZKFK { get; set; }

        /// <summary>
        /// 描述 :关键组件 
        /// </summary>

        [ExcelColumn(Name = "关键组件")]
        public string MarcKZKRI { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// </summary>

        [ExcelColumn(Name = "联产品 ")]
        public string MarcKZKUP { get; set; }

        /// <summary>
        /// 描述 :检查计划标识  
        /// </summary>

        [ExcelColumn(Name = "检查计划标识 ")]
        public string MarcKZPPV { get; set; }

        /// <summary>
        /// 描述 :从产品货位提取 
        /// </summary>

        [ExcelColumn(Name = "从产品货位提取")]
        public string MarcKZPRO { get; set; }

        /// <summary>
        /// 描述 :跨项目  
        /// </summary>

        [ExcelColumn(Name = "跨项目 ")]
        public string MarcKZPSP { get; set; }

        /// <summary>
        /// 描述 :装载组  
        /// </summary>

        [ExcelColumn(Name = "装载组 ")]
        public string MarcLADGR { get; set; }

        /// <summary>
        /// 描述 :库存成本 
        /// </summary>

        [ExcelColumn(Name = "库存成本")]
        public string MarcLAGPR { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// </summary>

        [ExcelColumn(Name = "年  当前期间")]
        public string MarcLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// </summary>

        [ExcelColumn(Name = "本期")]
        public string MarcLFMON { get; set; }

        /// <summary>
        /// 描述 :计划周期 
        /// </summary>

        [ExcelColumn(Name = "计划周期")]
        public string MarcLFRHY { get; set; }

        /// <summary>
        /// 描述 :外部采购仓储地 
        /// </summary>
        [Required(ErrorMessage = "外部采购仓储地不能为空")]

        [ExcelColumn(Name = "外部采购仓储地")]
        public string MarcLGFSB { get; set; }

        /// <summary>
        /// 描述 :生产仓储地点 
        /// </summary>
        [Required(ErrorMessage = "生产仓储地点不能为空")]

        [ExcelColumn(Name = "生产仓储地点")]
        public string MarcLGPRO { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// </summary>
        [Required(ErrorMessage = "服务水平不能为空")]

        [ExcelColumn(Name = "服务水平")]
        public decimal MarcLGRAD { get; set; }

        /// <summary>
        /// 描述 :取消激活的 
        /// </summary>

        [ExcelColumn(Name = "取消激活的")]
        public string MarcLIZYK { get; set; }

        /// <summary>
        /// 描述 :后勤组  
        /// </summary>

        [ExcelColumn(Name = "后勤组 ")]
        public string MarcLOGGR { get; set; }

        /// <summary>
        /// 描述 :订购成本 
        /// </summary>
        [Required(ErrorMessage = "订购成本不能为空")]

        [ExcelColumn(Name = "订购成本")]
        public decimal MarcLOSFX { get; set; }

        /// <summary>
        /// 描述 :成本核算批量 
        /// </summary>
        [Required(ErrorMessage = "成本核算批量不能为空")]

        [ExcelColumn(Name = "成本核算批量")]
        public decimal MarcLOSGR { get; set; }

        /// <summary>
        /// 描述 :批尺寸增加  
        /// </summary>
        [Required(ErrorMessage = "批尺寸增加 不能为空")]

        [ExcelColumn(Name = "批尺寸增加 ")]
        public decimal MarcLTINC { get; set; }

        /// <summary>
        /// 描述 :工厂级 DF 
        /// </summary>

        [ExcelColumn(Name = "工厂级 DF")]
        public string MarcLVORM { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// </summary>

        [ExcelColumn(Name = "时间单位")]
        public string MarcLZEIH { get; set; }

        /// <summary>
        /// 描述 :ABC 标识 
        /// </summary>

        [ExcelColumn(Name = "ABC 标识")]
        public string MarcMAABC { get; set; }

        /// <summary>
        /// 描述 :最大库存水平  
        /// </summary>
        [Required(ErrorMessage = "最大库存水平 不能为空")]

        [ExcelColumn(Name = "最大库存水平 ")]
        public decimal MarcMABST { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// </summary>
        [Required(ErrorMessage = "集团不能为空")]

        [ExcelColumn(Name = "集团")]
        public string MarcMANDT { get; set; }

        /// <summary>
        /// 描述 :物料分组 
        /// </summary>

        [ExcelColumn(Name = "物料分组")]
        public string MarcMATGR { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MarcMATNR { get; set; }

        /// <summary>
        /// 描述 :最大目标范围  
        /// </summary>

        [ExcelColumn(Name = "最大目标范围 ")]
        public string MarcmaxTroc { get; set; }

        /// <summary>
        /// 描述 :最大批量大小  
        /// </summary>
        [Required(ErrorMessage = "最大批量大小 不能为空")]

        [ExcelColumn(Name = "最大批量大小 ")]
        public decimal MarcMAXLS { get; set; }

        /// <summary>
        /// 描述 :最大存储期间  
        /// </summary>
        [Required(ErrorMessage = "最大存储期间 不能为空")]

        [ExcelColumn(Name = "最大存储期间 ")]
        public decimal MarcMAXLZ { get; set; }

        /// <summary>
        /// 描述 :最后的MARD 期间之前，MARDH 记 
        /// </summary>

        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记")]
        public string MarcMCRUE { get; set; }

        /// <summary>
        /// 描述 :活动控制 
        /// </summary>

        [ExcelColumn(Name = "活动控制")]
        public string MarcMDACH { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// </summary>

        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcMEGRU { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// </summary>

        [ExcelColumn(Name = "物料运输组 ")]
        public string MarcMFRGR { get; set; }

        /// <summary>
        /// 描述 :最小目标范围  
        /// </summary>

        [ExcelColumn(Name = "最小目标范围 ")]
        public string MarcminTroc { get; set; }

        /// <summary>
        /// 描述 :再订货点 
        /// </summary>
        [Required(ErrorMessage = "再订货点不能为空")]

        [ExcelColumn(Name = "再订货点")]
        public decimal MarcMINBE { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// </summary>
        [Required(ErrorMessage = "最小批量大小 不能为空")]

        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcMINLS { get; set; }

        /// <summary>
        /// 描述 :综合MRP 
        /// </summary>

        [ExcelColumn(Name = "综合MRP")]
        public string MarcMISKZ { get; set; }

        /// <summary>
        /// 描述 :P-S 物料状态  
        /// </summary>

        [ExcelColumn(Name = "P-S 物料状态 ")]
        public string MarcMMSTA { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// </summary>

        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcMMSTD { get; set; }

        /// <summary>
        /// 描述 :CAP 产品组  
        /// </summary>

        [ExcelColumn(Name = "CAP 产品组 ")]
        public string MarcMOGRU { get; set; }

        /// <summary>
        /// 描述 :EU 产品清单编号 
        /// </summary>

        [ExcelColumn(Name = "EU 产品清单编号")]
        public string MarcMOWNR { get; set; }

        /// <summary>
        /// 描述 :平均检查持续期 
        /// </summary>
        [Required(ErrorMessage = "平均检查持续期不能为空")]

        [ExcelColumn(Name = "平均检查持续期")]
        public decimal MarcMPDAU { get; set; }

        /// <summary>
        /// 描述 :计划日历 
        /// </summary>

        [ExcelColumn(Name = "计划日历")]
        public string MarcMRPPP { get; set; }

        /// <summary>
        /// 描述 :出口/进口组  
        /// </summary>

        [ExcelColumn(Name = "出口/进口组 ")]
        public string MarcMTVER { get; set; }

        /// <summary>
        /// 描述 :可用性检查  
        /// </summary>
        [Required(ErrorMessage = "可用性检查 不能为空")]

        [ExcelColumn(Name = "可用性检查 ")]
        public string MarcMTVFP { get; set; }

        /// <summary>
        /// 描述 :交叉的采购组 
        /// </summary>

        [ExcelColumn(Name = "交叉的采购组")]
        public string MarcmultipleEkgrp { get; set; }

        /// <summary>
        /// 描述 :无成本核算  
        /// </summary>

        [ExcelColumn(Name = "无成本核算 ")]
        public string MarcNCOST { get; set; }

        /// <summary>
        /// 描述 :后继物料 
        /// </summary>

        [ExcelColumn(Name = "后继物料")]
        public string MarcNFMAT { get; set; }

        /// <summary>
        /// 描述 :下一次检查  
        /// </summary>

        [ExcelColumn(Name = "下一次检查 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcNKMPR { get; set; }

        /// <summary>
        /// 描述 :对象标识 
        /// </summary>

        [ExcelColumn(Name = "对象标识")]
        public string MarcOBJID { get; set; }

        /// <summary>
        /// 描述 :总体参数文件 
        /// </summary>

        [ExcelColumn(Name = "总体参数文件")]
        public string MarcOCMPF { get; set; }

        /// <summary>
        /// 描述 :对象类型 
        /// </summary>

        [ExcelColumn(Name = "对象类型")]
        public string MarcOTYPE { get; set; }

        /// <summary>
        /// 描述 :会计年度变式 
        /// </summary>

        [ExcelColumn(Name = "会计年度变式")]
        public string MarcPERIV { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// </summary>

        [ExcelColumn(Name = "期间标识")]
        public string MarcPERKZ { get; set; }

        /// <summary>
        /// 描述 :自动更改工厂订单 
        /// </summary>

        [ExcelColumn(Name = "自动更改工厂订单")]
        public string MarcPFREI { get; set; }

        /// <summary>
        /// 描述 :计划交货时间 
        /// </summary>
        [Required(ErrorMessage = "计划交货时间不能为空")]

        [ExcelColumn(Name = "计划交货时间")]
        public decimal MarcPLIFZ { get; set; }

        /// <summary>
        /// 描述 :组  
        /// </summary>

        [ExcelColumn(Name = "组 ")]
        public string MarcPLNNR { get; set; }

        /// <summary>
        /// 描述 :任务清单类型 
        /// </summary>

        [ExcelColumn(Name = "任务清单类型")]
        public string MarcPLNTY { get; set; }

        /// <summary>
        /// 描述 :计划版本 
        /// </summary>

        [ExcelColumn(Name = "计划版本")]
        public string MarcPLVAR { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// </summary>
        [Required(ErrorMessage = "利润中心不能为空")]

        [ExcelColumn(Name = "利润中心")]
        public string MarcPRCTR { get; set; }

        /// <summary>
        /// 描述 :优先权  
        /// </summary>

        [ExcelColumn(Name = "优先权 ")]
        public string MarcPREFE { get; set; }

        /// <summary>
        /// 描述 :免税证书 
        /// </summary>

        [ExcelColumn(Name = "免税证书")]
        public string MarcPRENC { get; set; }

        /// <summary>
        /// 描述 :发放证书日  
        /// </summary>

        [ExcelColumn(Name = "发放证书日 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPREND { get; set; }

        /// <summary>
        /// 描述 :供应商申报  
        /// </summary>

        [ExcelColumn(Name = "供应商申报 ")]
        public string MarcPRENE { get; set; }

        /// <summary>
        /// 描述 :供应商申报日期 
        /// </summary>

        [ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPRENG { get; set; }

        /// <summary>
        /// 描述 :免税证书编号 
        /// </summary>

        [ExcelColumn(Name = "免税证书编号")]
        public string MarcPRENO { get; set; }

        /// <summary>
        /// 描述 :检查间隔  
        /// </summary>
        [Required(ErrorMessage = "检查间隔 不能为空")]

        [ExcelColumn(Name = "检查间隔 ")]
        public decimal MarcPRFRQ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// </summary>

        [ExcelColumn(Name = "维护状态 ")]
        public string MarcPSTAT { get; set; }

        /// <summary>
        /// 描述 :QM 物料授权 
        /// </summary>

        [ExcelColumn(Name = "QM 物料授权")]
        public string MarcQMATA { get; set; }

        /// <summary>
        /// 描述 :检验设置  
        /// </summary>

        [ExcelColumn(Name = "检验设置 ")]
        public string MarcQMATV { get; set; }

        /// <summary>
        /// 描述 :目标 QM 系统 
        /// </summary>

        [ExcelColumn(Name = "目标 QM 系统")]
        public string MarcQSSYS { get; set; }

        /// <summary>
        /// 描述 :隔离 
        /// </summary>
        [Required(ErrorMessage = "隔离不能为空")]

        [ExcelColumn(Name = "隔离")]
        public decimal MarcQUAZT { get; set; }

        /// <summary>
        /// 描述 :证书类型 
        /// </summary>

        [ExcelColumn(Name = "证书类型")]
        public string MarcQZGTP { get; set; }

        /// <summary>
        /// 描述 :舍入参数文件 
        /// </summary>

        [ExcelColumn(Name = "舍入参数文件")]
        public string MarcRDPRF { get; set; }

        /// <summary>
        /// 描述 :确定方案 
        /// </summary>

        [ExcelColumn(Name = "确定方案")]
        public string MarcrefSchema { get; set; }

        /// <summary>
        /// 描述 :调整期间 
        /// </summary>
        [Required(ErrorMessage = "调整期间不能为空")]

        [ExcelColumn(Name = "调整期间")]
        public decimal MarcRESVP { get; set; }

        /// <summary>
        /// 描述 :反冲 
        /// </summary>

        [ExcelColumn(Name = "反冲")]
        public string MarcRGEKZ { get; set; }

        /// <summary>
        /// 描述 :库存入库/出库 
        /// </summary>

        [ExcelColumn(Name = "库存入库/出库")]
        public string MarcrotationDate { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// </summary>
        [Required(ErrorMessage = "准备时间不能为空")]

        [ExcelColumn(Name = "准备时间")]
        public decimal MarcRUEZT { get; set; }

        /// <summary>
        /// 描述 :供货天数参文件 
        /// </summary>

        [ExcelColumn(Name = "供货天数参文件")]
        public string MarcRWPRO { get; set; }

        /// <summary>
        /// 描述 :重复生产 
        /// </summary>

        [ExcelColumn(Name = "重复生产")]
        public string MarcSAUFT { get; set; }

        /// <summary>
        /// 描述 :独立/集中 
        /// </summary>

        [ExcelColumn(Name = "独立/集中")]
        public string MarcSBDKZ { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// </summary>

        [ExcelColumn(Name = "散装物料")]
        public string MarcSCHGT { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// </summary>

        [ExcelColumn(Name = "序列号参数文件")]
        public string MarcSERNP { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// </summary>

        [ExcelColumn(Name = "服务水平")]
        public string MarcSERVG { get; set; }

        /// <summary>
        /// 描述 :生产参数文  
        /// </summary>

        [ExcelColumn(Name = "生产参数文 ")]
        public string MarcSFCPF { get; set; }

        /// <summary>
        /// 描述 :REM 参数文件 
        /// </summary>

        [ExcelColumn(Name = "REM 参数文件")]
        public string MarcSFEPR { get; set; }

        /// <summary>
        /// 描述 :离散批次编号 
        /// </summary>

        [ExcelColumn(Name = "离散批次编号")]
        public string MarcsgtChint { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// </summary>

        [ExcelColumn(Name = "分段策略")]
        public string MarcsgtCovs { get; set; }

        /// <summary>
        /// 描述 :库存排序方法 
        /// </summary>

        [ExcelColumn(Name = "库存排序方法")]
        public string MarcsgtMrpsi { get; set; }

        /// <summary>
        /// 描述 :消耗优先级 
        /// </summary>

        [ExcelColumn(Name = "消耗优先级")]
        public string MarcsgtPrcm { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// </summary>

        [ExcelColumn(Name = "分段范围")]
        public string MarcsgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态 MRP 
        /// </summary>

        [ExcelColumn(Name = "分段状态 MRP")]
        public string MarcsgtStatc { get; set; }

        /// <summary>
        /// 描述 :库存保护 
        /// </summary>

        [ExcelColumn(Name = "库存保护")]
        public string MarcsgtStkPrt { get; set; }

        /// <summary>
        /// 描述 :安全时间标识 
        /// </summary>

        [ExcelColumn(Name = "安全时间标识")]
        public string MarcSHFLG { get; set; }

        /// <summary>
        /// 描述 :ST 期间参数文件 
        /// </summary>

        [ExcelColumn(Name = "ST 期间参数文件")]
        public string MarcSHPRO { get; set; }

        /// <summary>
        /// 描述 :安全时间 
        /// </summary>

        [ExcelColumn(Name = "安全时间")]
        public string MarcSHZET { get; set; }

        /// <summary>
        /// 描述 :特殊工艺类型 
        /// </summary>

        [ExcelColumn(Name = "特殊工艺类型")]
        public string MarcSOBSK { get; set; }

        /// <summary>
        /// 描述 :特殊采购 
        /// </summary>
        [Required(ErrorMessage = "特殊采购不能为空")]

        [ExcelColumn(Name = "特殊采购")]
        public string MarcSOBSL { get; set; }

        /// <summary>
        /// 描述 :样本% 
        /// </summary>
        [Required(ErrorMessage = "样本%不能为空")]

        [ExcelColumn(Name = "样本%")]
        public decimal MarcSPROZ { get; set; }

        /// <summary>
        /// 描述 :QM 控制码  
        /// </summary>

        [ExcelColumn(Name = "QM 控制码 ")]
        public string MarcSSQSS { get; set; }

        /// <summary>
        /// 描述 :Comm./imp. code 
        /// </summary>

        [ExcelColumn(Name = "Comm./imp. code")]
        public string MarcSTAWN { get; set; }

        /// <summary>
        /// 描述 :可配置的物料 
        /// </summary>

        [ExcelColumn(Name = "可配置的物料")]
        public string MarcSTDPD { get; set; }

        /// <summary>
        /// 描述 :控制代码 
        /// </summary>

        [ExcelColumn(Name = "控制代码")]
        public string MarcSTEUC { get; set; }

        /// <summary>
        /// 描述 :备选  
        /// </summary>

        [ExcelColumn(Name = "备选 ")]
        public string MarcSTLAL { get; set; }

        /// <summary>
        /// 描述 :用途  
        /// </summary>

        [ExcelColumn(Name = "用途 ")]
        public string MarcSTLAN { get; set; }

        /// <summary>
        /// 描述 :策略组  
        /// </summary>

        [ExcelColumn(Name = "策略组 ")]
        public string MarcSTRGR { get; set; }

        /// <summary>
        /// 描述 :间隔时间 
        /// </summary>
        [Required(ErrorMessage = "间隔时间不能为空")]

        [ExcelColumn(Name = "间隔时间")]
        public decimal MarcTAKZT { get; set; }

        /// <summary>
        /// 描述 :目标库存 
        /// </summary>
        [Required(ErrorMessage = "目标库存不能为空")]

        [ExcelColumn(Name = "目标库存")]
        public decimal MarctargetStock { get; set; }

        /// <summary>
        /// 描述 :在途库存  
        /// </summary>
        [Required(ErrorMessage = "在途库存 不能为空")]

        [ExcelColumn(Name = "在途库存 ")]
        public decimal MarcTRAME { get; set; }

        /// <summary>
        /// 描述 :工序间  
        /// </summary>
        [Required(ErrorMessage = "工序间 不能为空")]

        [ExcelColumn(Name = "工序间 ")]
        public decimal MarcTRANZ { get; set; }

        /// <summary>
        /// 描述 :OB管理 
        /// </summary>

        [ExcelColumn(Name = "OB管理")]
        public string MarcUCHKZ { get; set; }

        /// <summary>
        /// 描述 :OB参考物料  
        /// </summary>

        [ExcelColumn(Name = "OB参考物料 ")]
        public string MarcUCMAT { get; set; }

        /// <summary>
        /// 描述 :无限的  
        /// </summary>

        [ExcelColumn(Name = "无限的 ")]
        public string MarcUEETK { get; set; }

        /// <summary>
        /// 描述 :过度交货允差 
        /// </summary>
        [Required(ErrorMessage = "过度交货允差不能为空")]

        [ExcelColumn(Name = "过度交货允差")]
        public decimal MarcUEETO { get; set; }

        /// <summary>
        /// 描述 :外部分配 
        /// </summary>

        [ExcelColumn(Name = "外部分配")]
        public string MarcuidIea { get; set; }

        /// <summary>
        /// 描述 :中转库存 
        /// </summary>
        [Required(ErrorMessage = "中转库存不能为空")]

        [ExcelColumn(Name = "中转库存")]
        public decimal MarcUMLMC { get; set; }

        /// <summary>
        /// 描述 :转换组  
        /// </summary>

        [ExcelColumn(Name = "转换组 ")]
        public string MarcUMRSL { get; set; }

        /// <summary>
        /// 描述 :不足交货允差 
        /// </summary>
        [Required(ErrorMessage = "不足交货允差不能为空")]

        [ExcelColumn(Name = "不足交货允差")]
        public decimal MarcUNETO { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// </summary>

        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcUOMGR { get; set; }

        /// <summary>
        /// 描述 :配额使用安排 
        /// </summary>

        [ExcelColumn(Name = "配额使用安排")]
        public string MarcUSEQU { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// </summary>
        [Required(ErrorMessage = "基准数量不能为空")]

        [ExcelColumn(Name = "基准数量")]
        public decimal MarcVBAMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// </summary>
        [Required(ErrorMessage = "处理时间不能为空")]

        [ExcelColumn(Name = "处理时间")]
        public decimal MarcVBEAZ { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// </summary>

        [ExcelColumn(Name = "版本")]
        public string MarcVERKZ { get; set; }

        /// <summary>
        /// 描述 :逆向消耗期间  
        /// </summary>

        [ExcelColumn(Name = "逆向消耗期间 ")]
        public string MarcVINT1 { get; set; }

        /// <summary>
        /// 描述 :向前消耗期间  
        /// </summary>

        [ExcelColumn(Name = "向前消耗期间 ")]
        public string MarcVINT2 { get; set; }

        /// <summary>
        /// 描述 :SlsVal.TiedEmpt 
        /// </summary>
        [Required(ErrorMessage = "SlsVal.TiedEmpt不能为空")]

        [ExcelColumn(Name = "SlsVal.TiedEmpt")]
        public decimal MarcVKGLG { get; set; }

        /// <summary>
        /// 描述 :运输库存/SP 
        /// </summary>
        [Required(ErrorMessage = "运输库存/SP不能为空")]

        [ExcelColumn(Name = "运输库存/SP")]
        public decimal MarcVKTRW { get; set; }

        /// <summary>
        /// 描述 :库存转移 SV 
        /// </summary>
        [Required(ErrorMessage = "库存转移 SV不能为空")]

        [ExcelColumn(Name = "库存转移 SV")]
        public decimal MarcVKUMC { get; set; }

        /// <summary>
        /// 描述 :日期到  
        /// </summary>

        [ExcelColumn(Name = "日期到 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcVRBDT { get; set; }

        /// <summary>
        /// 描述 :乘数 
        /// </summary>
        [Required(ErrorMessage = "乘数不能为空")]

        [ExcelColumn(Name = "乘数")]
        public decimal MarcVRBFK { get; set; }

        /// <summary>
        /// 描述 :参考物料:消耗  
        /// </summary>

        [ExcelColumn(Name = "参考物料:消耗 ")]
        public string MarcVRBMT { get; set; }

        /// <summary>
        /// 描述 :参考工厂：寄存 
        /// </summary>

        [ExcelColumn(Name = "参考工厂：寄存")]
        public string MarcVRBWK { get; set; }

        /// <summary>
        /// 描述 :消耗模式  
        /// </summary>

        [ExcelColumn(Name = "消耗模式 ")]
        public string MarcVRMOD { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// </summary>
        [Required(ErrorMessage = "准备时间不能为空")]

        [ExcelColumn(Name = "准备时间")]
        public decimal MarcVRVEZ { get; set; }

        /// <summary>
        /// 描述 :提议供应区域 
        /// </summary>

        [ExcelColumn(Name = "提议供应区域")]
        public string MarcVSPVB { get; set; }

        /// <summary>
        /// 描述 :附加费 % 
        /// </summary>
        [Required(ErrorMessage = "附加费 %不能为空")]

        [ExcelColumn(Name = "附加费 %")]
        public decimal MarcVZUSL { get; set; }

        /// <summary>
        /// 描述 :收货处理时间 
        /// </summary>
        [Required(ErrorMessage = "收货处理时间不能为空")]

        [ExcelColumn(Name = "收货处理时间")]
        public decimal MarcWEBAZ { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string MarcWERKS { get; set; }

        /// <summary>
        /// 描述 :活动性物质  
        /// </summary>
        [Required(ErrorMessage = "活动性物质 不能为空")]

        [ExcelColumn(Name = "活动性物质 ")]
        public decimal MarcWSTGH { get; set; }

        /// <summary>
        /// 描述 :总补货提前时间 
        /// </summary>
        [Required(ErrorMessage = "总补货提前时间不能为空")]

        [ExcelColumn(Name = "总补货提前时间")]
        public decimal MarcWZEIT { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// </summary>

        [ExcelColumn(Name = "批次")]
        public string MarcXCHAR { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// </summary>

        [ExcelColumn(Name = "批次管理需求 ")]
        public string MarcXCHPF { get; set; }

        /// <summary>
        /// 描述 :负的库存 
        /// </summary>

        [ExcelColumn(Name = "负的库存")]
        public string MarcXMCNG { get; set; }

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