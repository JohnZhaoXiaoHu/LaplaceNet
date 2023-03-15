using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 工厂物料数据，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("mm_marc")]
    public class MmMarc
    {
        /// <summary>
        /// 描述 :ID主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int MarcID { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// 空值 :true 
        /// </summary>
        public string MarcABCIN { get; set; }

        /// <summary>
        /// 描述 :空气浮力因子 
        /// 空值 :false 
        /// </summary>
        public decimal MarcABFAC { get; set; }

        /// <summary>
        /// 描述 :MRP 相关需求  
        /// 空值 :true 
        /// </summary>
        public string MarcAHDIS { get; set; }

        /// <summary>
        /// 描述 :选择方法 
        /// 空值 :true 
        /// </summary>
        public string MarcALTSL { get; set; }

        /// <summary>
        /// 描述 :组计数器 
        /// 空值 :true 
        /// </summary>
        public string MarcAPLAL { get; set; }

        /// <summary>
        /// 描述 :相关于 APO 
        /// 空值 :true 
        /// </summary>
        public string MarcAPOKZ { get; set; }

        /// <summary>
        /// 描述 :替换部件 
        /// 空值 :true 
        /// </summary>
        public string MarcATPKZ { get; set; }

        /// <summary>
        /// 描述 :分割标识 
        /// 空值 :true 
        /// </summary>
        public string MarcAUFTL { get; set; }

        /// <summary>
        /// 描述 :中断日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcAUSDT { get; set; }

        /// <summary>
        /// 描述 :发货单位 
        /// 空值 :true 
        /// </summary>
        public string MarcAUSME { get; set; }

        /// <summary>
        /// 描述 :装配报废 
        /// 空值 :false 
        /// </summary>
        public decimal MarcAUSSS { get; set; }

        /// <summary>
        /// 描述 :自动重置 
        /// 空值 :true 
        /// </summary>
        public string MarcAUTRU { get; set; }

        /// <summary>
        /// 描述 :差异码  
        /// 空值 :true 
        /// </summary>
        public string MarcAWSLS { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
        public decimal MarcBASMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcBEARZ { get; set; }

        /// <summary>
        /// 描述 :采购 
        /// 空值 :false 
        /// </summary>
        public string MarcBESKZ { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
        public decimal MarcBSTFE { get; set; }

        /// <summary>
        /// 描述 :最大批量  
        /// 空值 :false 
        /// </summary>
        public decimal MarcBSTMA { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
        public decimal MarcBSTMI { get; set; }

        /// <summary>
        /// 描述 :舍入值  
        /// 空值 :false 
        /// </summary>
        public decimal MarcBSTRF { get; set; }

        /// <summary>
        /// 描述 :评估收货锁定库存 
        /// 空值 :false 
        /// </summary>
        public decimal MarcBWESB { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// 空值 :true 
        /// </summary>
        public string MarcBWSCL { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// 空值 :true 
        /// </summary>
        public string MarcBWTTY { get; set; }

        /// <summary>
        /// 描述 :CAS 号（药品）  
        /// 空值 :true 
        /// </summary>
        public string MarcCASNR { get; set; }

        /// <summary>
        /// 描述 :周期标识被固定 
        /// 空值 :true 
        /// </summary>
        public string MarcCCFIX { get; set; }

        /// <summary>
        /// 描述 :该字段不再使用 
        /// 空值 :true 
        /// </summary>
        public string MarcCOMPL { get; set; }

        /// <summary>
        /// 描述 :寄售控制 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcCONS_PROCG")]
        public string MarcconsProcg { get; set; }

        /// <summary>
        /// 描述 :转换类型 
        /// 空值 :true 
        /// </summary>
        public string MarcCONVT { get; set; }

        /// <summary>
        /// 描述 :字段名  
        /// 空值 :true 
        /// </summary>
        public string MarcCOPAM { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        public string MarcCUOBJ { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        public string MarcCUOBV { get; set; }

        /// <summary>
        /// 描述 :MRP  范围存在 
        /// 空值 :true 
        /// </summary>
        public string MarcDIBER { get; set; }

        /// <summary>
        /// 描述 :MRP组  
        /// 空值 :true 
        /// </summary>
        public string MarcDISGR { get; set; }

        /// <summary>
        /// 描述 :批量大小 
        /// 空值 :false 
        /// </summary>
        public string MarcDISLS { get; set; }

        /// <summary>
        /// 描述 :MRP 类型 
        /// 空值 :false 
        /// </summary>
        public string MarcDISMM { get; set; }

        /// <summary>
        /// 描述 :MRP 控制者  
        /// 空值 :true 
        /// </summary>
        public string MarcDISPO { get; set; }

        /// <summary>
        /// 描述 :MRP 参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcDISPR { get; set; }

        /// <summary>
        /// 描述 :公平分享规则 
        /// 空值 :true 
        /// </summary>
        public string MarcDPLFS { get; set; }

        /// <summary>
        /// 描述 :发布界限 
        /// 空值 :false 
        /// </summary>
        public decimal MarcDPLHO { get; set; }

        /// <summary>
        /// 描述 :推式分配 
        /// 空值 :true 
        /// </summary>
        public string MarcDPLPU { get; set; }

        /// <summary>
        /// 描述 :厂内生产时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcDZEIT { get; set; }

        /// <summary>
        /// 描述 :安全库存 
        /// 空值 :false 
        /// </summary>
        public decimal MarcEISBE { get; set; }

        /// <summary>
        /// 描述 :最小安全库存  
        /// 空值 :false 
        /// </summary>
        public decimal MarcEISLO { get; set; }

        /// <summary>
        /// 描述 :采购组  
        /// 空值 :false 
        /// </summary>
        public string MarcEKGRP { get; set; }

        /// <summary>
        /// 描述 :库存确定组  
        /// 空值 :true 
        /// </summary>
        public string MarcEPRIO { get; set; }

        /// <summary>
        /// 描述 :商品代码单位 
        /// 空值 :true 
        /// </summary>
        public string MarcEXPME { get; set; }

        /// <summary>
        /// 描述 :JIT 标识 
        /// 空值 :true 
        /// </summary>
        public string MarcFABKZ { get; set; }

        /// <summary>
        /// 描述 :生产管理员  
        /// 空值 :true 
        /// </summary>
        public string MarcFEVOR { get; set; }

        /// <summary>
        /// 描述 :自动批准 
        /// 空值 :true 
        /// </summary>
        public string MarcFFREI { get; set; }

        /// <summary>
        /// 描述 :计划边际码  
        /// 空值 :true 
        /// </summary>
        public string MarcFHORI { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
        public decimal MarcFIXLS { get; set; }

        /// <summary>
        /// 描述 :分配 prof. 
        /// 空值 :true 
        /// </summary>
        public string MarcFPRFM { get; set; }

        /// <summary>
        /// 描述 :生产单位 
        /// 空值 :true 
        /// </summary>
        public string MarcFRTME { get; set; }

        /// <summary>
        /// 描述 :订单分配运行 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_MG_ARUN_REQ")]
        public string MarcfshMgArunReq { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_SEAIM")]
        public string MarcfshSeaim { get; set; }

        /// <summary>
        /// 描述 :生产版本 
        /// 空值 :true 
        /// </summary>
        public string MarcFVIDK { get; set; }

        /// <summary>
        /// 描述 :计划的时界  
        /// 空值 :true 
        /// </summary>
        public string MarcFXHOR { get; set; }

        /// <summary>
        /// 描述 :固定价格联产品 
        /// 空值 :true 
        /// </summary>
        public string MarcFXPRU { get; set; }

        /// <summary>
        /// 描述 :发货处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcGI_PR_TIME")]
        public decimal MarcgiPrTime { get; set; }

        /// <summary>
        /// 描述 :有约束的虚拟 
        /// 空值 :false 
        /// </summary>
        public decimal MarcGLGMG { get; set; }

        /// <summary>
        /// 描述 :粗略计划 
        /// 空值 :true 
        /// </summary>
        public string MarcGPMKZ { get; set; }

        /// <summary>
        /// 描述 :PRODCOM号  
        /// 空值 :true 
        /// </summary>
        public string MarcGPNUM { get; set; }

        /// <summary>
        /// 描述 :生产状态  
        /// 空值 :true 
        /// </summary>
        public string MarcHERBL { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// 空值 :true 
        /// </summary>
        public string MarcHERKL { get; set; }

        /// <summary>
        /// 描述 :货源地  
        /// 空值 :true 
        /// </summary>
        public string MarcHERKR { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// 空值 :true 
        /// </summary>
        public string MarcINDUS { get; set; }

        /// <summary>
        /// 描述 :过帐到检验库存 
        /// 空值 :false 
        /// </summary>
        public string MarcINSMK { get; set; }

        /// <summary>
        /// 描述 :军用物资 
        /// 空值 :true 
        /// </summary>
        public string MarcITARK { get; set; }

        /// <summary>
        /// 描述 :IUID 相关 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_RELEVANT")]
        public string MarciuidRelevant { get; set; }

        /// <summary>
        /// 描述 :IUID 类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_TYPE")]
        public string MarciuidType { get; set; }

        /// <summary>
        /// 描述 :组件报废 
        /// 空值 :false 
        /// </summary>
        public decimal MarcKAUSF { get; set; }

        /// <summary>
        /// 描述 :自动采购单  
        /// 空值 :true 
        /// </summary>
        public string MarcKAUTB { get; set; }

        /// <summary>
        /// 描述 :源清单  
        /// 空值 :true 
        /// </summary>
        public string MarcKORDB { get; set; }

        /// <summary>
        /// 描述 :平滑促销消耗  
        /// 空值 :true 
        /// </summary>
        public string MarcKZAGL { get; set; }

        /// <summary>
        /// 描述 :非连续标识  
        /// 空值 :true 
        /// </summary>
        public string MarcKZAUS { get; set; }

        /// <summary>
        /// 描述 :需求分组  
        /// 空值 :true 
        /// </summary>
        public string MarcKZBED { get; set; }

        /// <summary>
        /// 描述 :MRP控制者=买者  
        /// 空值 :true 
        /// </summary>
        public string MarcKZDIE { get; set; }

        /// <summary>
        /// 描述 :凭证需求  
        /// 空值 :true 
        /// </summary>
        public string MarcKZDKZ { get; set; }

        /// <summary>
        /// 描述 :输入批量 
        /// 空值 :true 
        /// </summary>
        public string MarcKZECH { get; set; }

        /// <summary>
        /// 描述 :修正因子 
        /// 空值 :true 
        /// </summary>
        public string MarcKZKFK { get; set; }

        /// <summary>
        /// 描述 :关键组件 
        /// 空值 :true 
        /// </summary>
        public string MarcKZKRI { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// 空值 :true 
        /// </summary>
        public string MarcKZKUP { get; set; }

        /// <summary>
        /// 描述 :检查计划标识  
        /// 空值 :true 
        /// </summary>
        public string MarcKZPPV { get; set; }

        /// <summary>
        /// 描述 :从产品货位提取 
        /// 空值 :true 
        /// </summary>
        public string MarcKZPRO { get; set; }

        /// <summary>
        /// 描述 :跨项目  
        /// 空值 :true 
        /// </summary>
        public string MarcKZPSP { get; set; }

        /// <summary>
        /// 描述 :装载组  
        /// 空值 :true 
        /// </summary>
        public string MarcLADGR { get; set; }

        /// <summary>
        /// 描述 :库存成本 
        /// 空值 :true 
        /// </summary>
        public string MarcLAGPR { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// 空值 :true 
        /// </summary>
        public string MarcLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// 空值 :true 
        /// </summary>
        public string MarcLFMON { get; set; }

        /// <summary>
        /// 描述 :计划周期 
        /// 空值 :true 
        /// </summary>
        public string MarcLFRHY { get; set; }

        /// <summary>
        /// 描述 :外部采购仓储地 
        /// 空值 :false 
        /// </summary>
        public string MarcLGFSB { get; set; }

        /// <summary>
        /// 描述 :生产仓储地点 
        /// 空值 :false 
        /// </summary>
        public string MarcLGPRO { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :false 
        /// </summary>
        public decimal MarcLGRAD { get; set; }

        /// <summary>
        /// 描述 :取消激活的 
        /// 空值 :true 
        /// </summary>
        public string MarcLIZYK { get; set; }

        /// <summary>
        /// 描述 :后勤组  
        /// 空值 :true 
        /// </summary>
        public string MarcLOGGR { get; set; }

        /// <summary>
        /// 描述 :订购成本 
        /// 空值 :false 
        /// </summary>
        public decimal MarcLOSFX { get; set; }

        /// <summary>
        /// 描述 :成本核算批量 
        /// 空值 :false 
        /// </summary>
        public decimal MarcLOSGR { get; set; }

        /// <summary>
        /// 描述 :批尺寸增加  
        /// 空值 :false 
        /// </summary>
        public decimal MarcLTINC { get; set; }

        /// <summary>
        /// 描述 :工厂级 DF 
        /// 空值 :true 
        /// </summary>
        public string MarcLVORM { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// 空值 :true 
        /// </summary>
        public string MarcLZEIH { get; set; }

        /// <summary>
        /// 描述 :ABC 标识 
        /// 空值 :true 
        /// </summary>
        public string MarcMAABC { get; set; }

        /// <summary>
        /// 描述 :最大库存水平  
        /// 空值 :false 
        /// </summary>
        public decimal MarcMABST { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// 空值 :false 
        /// </summary>
        public string MarcMANDT { get; set; }

        /// <summary>
        /// 描述 :物料分组 
        /// 空值 :true 
        /// </summary>
        public string MarcMATGR { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MarcMATNR { get; set; }

        /// <summary>
        /// 描述 :最大目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMAX_TROC")]
        public string MarcmaxTroc { get; set; }

        /// <summary>
        /// 描述 :最大批量大小  
        /// 空值 :false 
        /// </summary>
        public decimal MarcMAXLS { get; set; }

        /// <summary>
        /// 描述 :最大存储期间  
        /// 空值 :false 
        /// </summary>
        public decimal MarcMAXLZ { get; set; }

        /// <summary>
        /// 描述 :最后的MARD 期间之前，MARDH 记 
        /// 空值 :true 
        /// </summary>
        public string MarcMCRUE { get; set; }

        /// <summary>
        /// 描述 :活动控制 
        /// 空值 :true 
        /// </summary>
        public string MarcMDACH { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        public string MarcMEGRU { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// 空值 :true 
        /// </summary>
        public string MarcMFRGR { get; set; }

        /// <summary>
        /// 描述 :最小目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMIN_TROC")]
        public string MarcminTroc { get; set; }

        /// <summary>
        /// 描述 :再订货点 
        /// 空值 :false 
        /// </summary>
        public decimal MarcMINBE { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
        public decimal MarcMINLS { get; set; }

        /// <summary>
        /// 描述 :综合MRP 
        /// 空值 :true 
        /// </summary>
        public string MarcMISKZ { get; set; }

        /// <summary>
        /// 描述 :P-S 物料状态  
        /// 空值 :true 
        /// </summary>
        public string MarcMMSTA { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcMMSTD { get; set; }

        /// <summary>
        /// 描述 :CAP 产品组  
        /// 空值 :true 
        /// </summary>
        public string MarcMOGRU { get; set; }

        /// <summary>
        /// 描述 :EU 产品清单编号 
        /// 空值 :true 
        /// </summary>
        public string MarcMOWNR { get; set; }

        /// <summary>
        /// 描述 :平均检查持续期 
        /// 空值 :false 
        /// </summary>
        public decimal MarcMPDAU { get; set; }

        /// <summary>
        /// 描述 :计划日历 
        /// 空值 :true 
        /// </summary>
        public string MarcMRPPP { get; set; }

        /// <summary>
        /// 描述 :出口/进口组  
        /// 空值 :true 
        /// </summary>
        public string MarcMTVER { get; set; }

        /// <summary>
        /// 描述 :可用性检查  
        /// 空值 :false 
        /// </summary>
        public string MarcMTVFP { get; set; }

        /// <summary>
        /// 描述 :交叉的采购组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMULTIPLE_EKGRP")]
        public string MarcmultipleEkgrp { get; set; }

        /// <summary>
        /// 描述 :无成本核算  
        /// 空值 :true 
        /// </summary>
        public string MarcNCOST { get; set; }

        /// <summary>
        /// 描述 :后继物料 
        /// 空值 :true 
        /// </summary>
        public string MarcNFMAT { get; set; }

        /// <summary>
        /// 描述 :下一次检查  
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcNKMPR { get; set; }

        /// <summary>
        /// 描述 :对象标识 
        /// 空值 :true 
        /// </summary>
        public string MarcOBJID { get; set; }

        /// <summary>
        /// 描述 :总体参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcOCMPF { get; set; }

        /// <summary>
        /// 描述 :对象类型 
        /// 空值 :true 
        /// </summary>
        public string MarcOTYPE { get; set; }

        /// <summary>
        /// 描述 :会计年度变式 
        /// 空值 :true 
        /// </summary>
        public string MarcPERIV { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// 空值 :true 
        /// </summary>
        public string MarcPERKZ { get; set; }

        /// <summary>
        /// 描述 :自动更改工厂订单 
        /// 空值 :true 
        /// </summary>
        public string MarcPFREI { get; set; }

        /// <summary>
        /// 描述 :计划交货时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcPLIFZ { get; set; }

        /// <summary>
        /// 描述 :组  
        /// 空值 :true 
        /// </summary>
        public string MarcPLNNR { get; set; }

        /// <summary>
        /// 描述 :任务清单类型 
        /// 空值 :true 
        /// </summary>
        public string MarcPLNTY { get; set; }

        /// <summary>
        /// 描述 :计划版本 
        /// 空值 :true 
        /// </summary>
        public string MarcPLVAR { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        public string MarcPRCTR { get; set; }

        /// <summary>
        /// 描述 :优先权  
        /// 空值 :true 
        /// </summary>
        public string MarcPREFE { get; set; }

        /// <summary>
        /// 描述 :免税证书 
        /// 空值 :true 
        /// </summary>
        public string MarcPRENC { get; set; }

        /// <summary>
        /// 描述 :发放证书日  
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcPREND { get; set; }

        /// <summary>
        /// 描述 :供应商申报  
        /// 空值 :true 
        /// </summary>
        public string MarcPRENE { get; set; }

        /// <summary>
        /// 描述 :供应商申报日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcPRENG { get; set; }

        /// <summary>
        /// 描述 :免税证书编号 
        /// 空值 :true 
        /// </summary>
        public string MarcPRENO { get; set; }

        /// <summary>
        /// 描述 :检查间隔  
        /// 空值 :false 
        /// </summary>
        public decimal MarcPRFRQ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// 空值 :true 
        /// </summary>
        public string MarcPSTAT { get; set; }

        /// <summary>
        /// 描述 :QM 物料授权 
        /// 空值 :true 
        /// </summary>
        public string MarcQMATA { get; set; }

        /// <summary>
        /// 描述 :检验设置  
        /// 空值 :true 
        /// </summary>
        public string MarcQMATV { get; set; }

        /// <summary>
        /// 描述 :目标 QM 系统 
        /// 空值 :true 
        /// </summary>
        public string MarcQSSYS { get; set; }

        /// <summary>
        /// 描述 :隔离 
        /// 空值 :false 
        /// </summary>
        public decimal MarcQUAZT { get; set; }

        /// <summary>
        /// 描述 :证书类型 
        /// 空值 :true 
        /// </summary>
        public string MarcQZGTP { get; set; }

        /// <summary>
        /// 描述 :舍入参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcRDPRF { get; set; }

        /// <summary>
        /// 描述 :确定方案 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcREF_SCHEMA")]
        public string MarcrefSchema { get; set; }

        /// <summary>
        /// 描述 :调整期间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcRESVP { get; set; }

        /// <summary>
        /// 描述 :反冲 
        /// 空值 :true 
        /// </summary>
        public string MarcRGEKZ { get; set; }

        /// <summary>
        /// 描述 :库存入库/出库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcROTATION_DATE")]
        public string MarcrotationDate { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcRUEZT { get; set; }

        /// <summary>
        /// 描述 :供货天数参文件 
        /// 空值 :true 
        /// </summary>
        public string MarcRWPRO { get; set; }

        /// <summary>
        /// 描述 :重复生产 
        /// 空值 :true 
        /// </summary>
        public string MarcSAUFT { get; set; }

        /// <summary>
        /// 描述 :独立/集中 
        /// 空值 :true 
        /// </summary>
        public string MarcSBDKZ { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        public string MarcSCHGT { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcSERNP { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :true 
        /// </summary>
        public string MarcSERVG { get; set; }

        /// <summary>
        /// 描述 :生产参数文  
        /// 空值 :true 
        /// </summary>
        public string MarcSFCPF { get; set; }

        /// <summary>
        /// 描述 :REM 参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcSFEPR { get; set; }

        /// <summary>
        /// 描述 :离散批次编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_CHINT")]
        public string MarcsgtChint { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_COVS")]
        public string MarcsgtCovs { get; set; }

        /// <summary>
        /// 描述 :库存排序方法 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_MRPSI")]
        public string MarcsgtMrpsi { get; set; }

        /// <summary>
        /// 描述 :消耗优先级 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_PRCM")]
        public string MarcsgtPrcm { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_SCOPE")]
        public string MarcsgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态 MRP 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STATC")]
        public string MarcsgtStatc { get; set; }

        /// <summary>
        /// 描述 :库存保护 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STK_PRT")]
        public string MarcsgtStkPrt { get; set; }

        /// <summary>
        /// 描述 :安全时间标识 
        /// 空值 :true 
        /// </summary>
        public string MarcSHFLG { get; set; }

        /// <summary>
        /// 描述 :ST 期间参数文件 
        /// 空值 :true 
        /// </summary>
        public string MarcSHPRO { get; set; }

        /// <summary>
        /// 描述 :安全时间 
        /// 空值 :true 
        /// </summary>
        public string MarcSHZET { get; set; }

        /// <summary>
        /// 描述 :特殊工艺类型 
        /// 空值 :true 
        /// </summary>
        public string MarcSOBSK { get; set; }

        /// <summary>
        /// 描述 :特殊采购 
        /// 空值 :false 
        /// </summary>
        public string MarcSOBSL { get; set; }

        /// <summary>
        /// 描述 :样本% 
        /// 空值 :false 
        /// </summary>
        public decimal MarcSPROZ { get; set; }

        /// <summary>
        /// 描述 :QM 控制码  
        /// 空值 :true 
        /// </summary>
        public string MarcSSQSS { get; set; }

        /// <summary>
        /// 描述 :Comm./imp. code 
        /// 空值 :true 
        /// </summary>
        public string MarcSTAWN { get; set; }

        /// <summary>
        /// 描述 :可配置的物料 
        /// 空值 :true 
        /// </summary>
        public string MarcSTDPD { get; set; }

        /// <summary>
        /// 描述 :控制代码 
        /// 空值 :true 
        /// </summary>
        public string MarcSTEUC { get; set; }

        /// <summary>
        /// 描述 :备选  
        /// 空值 :true 
        /// </summary>
        public string MarcSTLAL { get; set; }

        /// <summary>
        /// 描述 :用途  
        /// 空值 :true 
        /// </summary>
        public string MarcSTLAN { get; set; }

        /// <summary>
        /// 描述 :策略组  
        /// 空值 :true 
        /// </summary>
        public string MarcSTRGR { get; set; }

        /// <summary>
        /// 描述 :间隔时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcTAKZT { get; set; }

        /// <summary>
        /// 描述 :目标库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcTARGET_STOCK")]
        public decimal MarctargetStock { get; set; }

        /// <summary>
        /// 描述 :在途库存  
        /// 空值 :false 
        /// </summary>
        public decimal MarcTRAME { get; set; }

        /// <summary>
        /// 描述 :工序间  
        /// 空值 :false 
        /// </summary>
        public decimal MarcTRANZ { get; set; }

        /// <summary>
        /// 描述 :OB管理 
        /// 空值 :true 
        /// </summary>
        public string MarcUCHKZ { get; set; }

        /// <summary>
        /// 描述 :OB参考物料  
        /// 空值 :true 
        /// </summary>
        public string MarcUCMAT { get; set; }

        /// <summary>
        /// 描述 :无限的  
        /// 空值 :true 
        /// </summary>
        public string MarcUEETK { get; set; }

        /// <summary>
        /// 描述 :过度交货允差 
        /// 空值 :false 
        /// </summary>
        public decimal MarcUEETO { get; set; }

        /// <summary>
        /// 描述 :外部分配 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcUID_IEA")]
        public string MarcuidIea { get; set; }

        /// <summary>
        /// 描述 :中转库存 
        /// 空值 :false 
        /// </summary>
        public decimal MarcUMLMC { get; set; }

        /// <summary>
        /// 描述 :转换组  
        /// 空值 :true 
        /// </summary>
        public string MarcUMRSL { get; set; }

        /// <summary>
        /// 描述 :不足交货允差 
        /// 空值 :false 
        /// </summary>
        public decimal MarcUNETO { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        public string MarcUOMGR { get; set; }

        /// <summary>
        /// 描述 :配额使用安排 
        /// 空值 :true 
        /// </summary>
        public string MarcUSEQU { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVBAMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVBEAZ { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// 空值 :true 
        /// </summary>
        public string MarcVERKZ { get; set; }

        /// <summary>
        /// 描述 :逆向消耗期间  
        /// 空值 :true 
        /// </summary>
        public string MarcVINT1 { get; set; }

        /// <summary>
        /// 描述 :向前消耗期间  
        /// 空值 :true 
        /// </summary>
        public string MarcVINT2 { get; set; }

        /// <summary>
        /// 描述 :SlsVal.TiedEmpt 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVKGLG { get; set; }

        /// <summary>
        /// 描述 :运输库存/SP 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVKTRW { get; set; }

        /// <summary>
        /// 描述 :库存转移 SV 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVKUMC { get; set; }

        /// <summary>
        /// 描述 :日期到  
        /// 空值 :true 
        /// </summary>
        public DateTime? MarcVRBDT { get; set; }

        /// <summary>
        /// 描述 :乘数 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVRBFK { get; set; }

        /// <summary>
        /// 描述 :参考物料:消耗  
        /// 空值 :true 
        /// </summary>
        public string MarcVRBMT { get; set; }

        /// <summary>
        /// 描述 :参考工厂：寄存 
        /// 空值 :true 
        /// </summary>
        public string MarcVRBWK { get; set; }

        /// <summary>
        /// 描述 :消耗模式  
        /// 空值 :true 
        /// </summary>
        public string MarcVRMOD { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVRVEZ { get; set; }

        /// <summary>
        /// 描述 :提议供应区域 
        /// 空值 :true 
        /// </summary>
        public string MarcVSPVB { get; set; }

        /// <summary>
        /// 描述 :附加费 % 
        /// 空值 :false 
        /// </summary>
        public decimal MarcVZUSL { get; set; }

        /// <summary>
        /// 描述 :收货处理时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcWEBAZ { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string MarcWERKS { get; set; }

        /// <summary>
        /// 描述 :活动性物质  
        /// 空值 :false 
        /// </summary>
        public decimal MarcWSTGH { get; set; }

        /// <summary>
        /// 描述 :总补货提前时间 
        /// 空值 :false 
        /// </summary>
        public decimal MarcWZEIT { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :true 
        /// </summary>
        public string MarcXCHAR { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// 空值 :true 
        /// </summary>
        public string MarcXCHPF { get; set; }

        /// <summary>
        /// 描述 :负的库存 
        /// 空值 :true 
        /// </summary>
        public string MarcXMCNG { get; set; }

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