using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 物料评估，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("mm_mbew")]
    public class MmMbew
    {
        /// <summary>
        /// 描述 :ID主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int MbewID { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// 空值 :true 
        /// </summary>
        public string MbewABCIW { get; set; }

        /// <summary>
        /// 描述 :贬值标识   
        /// 空值 :true 
        /// </summary>
        public string MbewABWKZ { get; set; }

        /// <summary>
        /// 描述 :评估类  
        /// 空值 :true 
        /// </summary>
        public string MbewBKLAS { get; set; }

        /// <summary>
        /// 描述 :评估范围 
        /// 空值 :false 
        /// </summary>
        public string MbewBWKEY { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWPEI { get; set; }

        /// <summary>
        /// 描述 :商业价格 2 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWPH1 { get; set; }

        /// <summary>
        /// 描述 :商业价格 1 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWPRH { get; set; }

        /// <summary>
        /// 描述 :税价1 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWPRS { get; set; }

        /// <summary>
        /// 描述 :税价2 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWPS1 { get; set; }

        /// <summary>
        /// 描述 :评价毛利 
        /// 空值 :false 
        /// </summary>
        public decimal MbewBWSPA { get; set; }

        /// <summary>
        /// 描述 :评估类型 
        /// 空值 :false 
        /// </summary>
        public string MbewBWTAR { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// 空值 :true 
        /// </summary>
        public string MbewBWTTY { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// 空值 :true 
        /// </summary>
        public string MbewBWVA1 { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// 空值 :true 
        /// </summary>
        public string MbewBWVA2 { get; set; }

        /// <summary>
        /// 描述 :评估变式 
        /// 空值 :true 
        /// </summary>
        public string MbewBWVA3 { get; set; }

        /// <summary>
        /// 描述 :用QS的成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewEKALR { get; set; }

        /// <summary>
        /// 描述 :VC:销售订单库存 
        /// 空值 :true 
        /// </summary>
        public string MbewEKLAS { get; set; }

        /// <summary>
        /// 描述 :未来评估决策 
        /// 空值 :true 
        /// </summary>
        public string MbewFBWST { get; set; }

        /// <summary>
        /// 描述 :固定的未来计划价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewFPLPX { get; set; }

        /// <summary>
        /// 描述 :物料来源 
        /// 空值 :true 
        /// </summary>
        public string MbewHKMAT { get; set; }

        /// <summary>
        /// 描述 :原始组  
        /// 空值 :true 
        /// </summary>
        public string MbewHRKFT { get; set; }

        /// <summary>
        /// 描述 :当前成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewKALKL { get; set; }

        /// <summary>
        /// 描述 :上期成本估计 
        /// 空值 :true 
        /// </summary>
        public string MbewKALKV { get; set; }

        /// <summary>
        /// 描述 :未来成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewKALKZ { get; set; }

        /// <summary>
        /// 描述 :产品成本核算号 
        /// 空值 :true 
        /// </summary>
        public string MbewKALN1 { get; set; }

        /// <summary>
        /// 描述 :成本估算编号 
        /// 空值 :true 
        /// </summary>
        public string MbewKALNR { get; set; }

        /// <summary>
        /// 描述 :一般费用代码  
        /// 空值 :true 
        /// </summary>
        public string MbewKALSC { get; set; }

        /// <summary>
        /// 描述 :间接费分组  
        /// 空值 :true 
        /// </summary>
        public string MbewKOSGR { get; set; }

        /// <summary>
        /// 描述 :盘点库存VO物料 
        /// 空值 :true 
        /// </summary>
        public string MbewKZIWL { get; set; }

        /// <summary>
        /// 描述 :最近价格更改  
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewLAEPR { get; set; }

        /// <summary>
        /// 描述 :总库存  
        /// 空值 :false 
        /// </summary>
        public decimal MbewLBKUM { get; set; }

        /// <summary>
        /// 描述 :当前的值决策  
        /// 空值 :true 
        /// </summary>
        public string MbewLBWST { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// 空值 :true 
        /// </summary>
        public string MbewLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// 空值 :true 
        /// </summary>
        public string MbewLFMON { get; set; }

        /// <summary>
        /// 描述 :当前计划价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewLPLPR { get; set; }

        /// <summary>
        /// 描述 :固定的当前计划价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewLPLPX { get; set; }

        /// <summary>
        /// 描述 :评估类型 
        /// 空值 :true 
        /// </summary>
        public string MbewLVORM { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// 空值 :false 
        /// </summary>
        public string MbewMANDT { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MbewMATNR { get; set; }

        /// <summary>
        /// 描述 :MBEW 最后期间之前，期间的 MBEW 
        /// 空值 :true 
        /// </summary>
        public string MbewMBRUE { get; set; }

        /// <summary>
        /// 描述 :价格确定 
        /// 空值 :true 
        /// </summary>
        public string MbewMLAST { get; set; }

        /// <summary>
        /// 描述 :ML 作业 
        /// 空值 :true 
        /// </summary>
        public string MbewMLMAA { get; set; }

        /// <summary>
        /// 描述 :物料来源 
        /// 空值 :true 
        /// </summary>
        public string MbewMTORG { get; set; }

        /// <summary>
        /// 描述 :物料用途  
        /// 空值 :true 
        /// </summary>
        public string MbewMTUSE { get; set; }

        /// <summary>
        /// 描述 :LIFO评估储备号  
        /// 空值 :true 
        /// </summary>
        public string MbewMYPOL { get; set; }

        /// <summary>
        /// 描述 :预付库存 
        /// 空值 :true 
        /// </summary>
        public string MbewOIPPINV { get; set; }

        /// <summary>
        /// 描述 :VC: 供应商  
        /// 空值 :true 
        /// </summary>
        public string MbewOKLAS { get; set; }

        /// <summary>
        /// 描述 :自制产品 
        /// 空值 :true 
        /// </summary>
        public string MbewOWNPR { get; set; }

        /// <summary>
        /// 描述 :当前会计年度 
        /// 空值 :true 
        /// </summary>
        public string MbewPDATL { get; set; }

        /// <summary>
        /// 描述 :上一会计年  
        /// 空值 :true 
        /// </summary>
        public string MbewPDATV { get; set; }

        /// <summary>
        /// 描述 :来年会计年度 
        /// 空值 :true 
        /// </summary>
        public string MbewPDATZ { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// 空值 :false 
        /// </summary>
        public decimal MbewPEINH { get; set; }

        /// <summary>
        /// 描述 :期间成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewPPERL { get; set; }

        /// <summary>
        /// 描述 :上期成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewPPERV { get; set; }

        /// <summary>
        /// 描述 :未来成本估算 
        /// 空值 :true 
        /// </summary>
        public string MbewPPERZ { get; set; }

        /// <summary>
        /// 描述 :当前期间 
        /// 空值 :true 
        /// </summary>
        public string MbewPPRDL { get; set; }

        /// <summary>
        /// 描述 :前一期间 
        /// 空值 :true 
        /// </summary>
        public string MbewPPRDV { get; set; }

        /// <summary>
        /// 描述 :记帐期间 
        /// 空值 :true 
        /// </summary>
        public string MbewPPRDZ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// 空值 :true 
        /// </summary>
        public string MbewPSTAT { get; set; }

        /// <summary>
        /// 描述 :项目库存评估类 
        /// 空值 :true 
        /// </summary>
        public string MbewQKLAS { get; set; }

        /// <summary>
        /// 描述 :总价值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewSALK3 { get; set; }

        /// <summary>
        /// 描述 :价值/MA价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewSALKV { get; set; }

        /// <summary>
        /// 描述 :库存冻结 
        /// 空值 :true 
        /// </summary>
        public string MbewSPERW { get; set; }

        /// <summary>
        /// 描述 :标准价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewSTPRS { get; set; }

        /// <summary>
        /// 描述 :上期价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewSTPRV { get; set; }

        /// <summary>
        /// 描述 :时戳 
        /// 空值 :false 
        /// </summary>
        public decimal MbewTIMESTAMP { get; set; }

        /// <summary>
        /// 描述 :上年评估策略 
        /// 空值 :true 
        /// </summary>
        public string MbewVBWST { get; set; }

        /// <summary>
        /// 描述 :移动价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVERPR { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// 空值 :true 
        /// </summary>
        public string MbewVERS1 { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// 空值 :true 
        /// </summary>
        public string MbewVERS2 { get; set; }

        /// <summary>
        /// 描述 :成本核算版本 
        /// 空值 :true 
        /// </summary>
        public string MbewVERS3 { get; set; }

        /// <summary>
        /// 描述 :上年估价类  
        /// 空值 :true 
        /// </summary>
        public string MbewVJBKL { get; set; }

        /// <summary>
        /// 描述 :商业价格 3 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJBWH { get; set; }

        /// <summary>
        /// 描述 :税价3 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJBWS { get; set; }

        /// <summary>
        /// 描述 :前年总库存值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJKUM { get; set; }

        /// <summary>
        /// 描述 :上年价格单位 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJPEI { get; set; }

        /// <summary>
        /// 描述 :上年总值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJSAL { get; set; }

        /// <summary>
        /// 描述 :上年价值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJSAV { get; set; }

        /// <summary>
        /// 描述 :去年标准价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJSTP { get; set; }

        /// <summary>
        /// 描述 :去年移动平均价 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVJVER { get; set; }

        /// <summary>
        /// 描述 :前一年价格控制 
        /// 空值 :true 
        /// </summary>
        public string MbewVJVPR { get; set; }

        /// <summary>
        /// 描述 :总SP值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVKSAL { get; set; }

        /// <summary>
        /// 描述 :上期的评价分类 
        /// 空值 :true 
        /// </summary>
        public string MbewVMBKL { get; set; }

        /// <summary>
        /// 描述 :前期总库存  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMKUM { get; set; }

        /// <summary>
        /// 描述 :上期间价格单位 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMPEI { get; set; }

        /// <summary>
        /// 描述 :前期总值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMSAL { get; set; }

        /// <summary>
        /// 描述 :上期的价值  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMSAV { get; set; }

        /// <summary>
        /// 描述 :前期标准价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMSTP { get; set; }

        /// <summary>
        /// 描述 :前期移动平均价 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVMVER { get; set; }

        /// <summary>
        /// 描述 :前期间价格控制 
        /// 空值 :true 
        /// </summary>
        public string MbewVMVPR { get; set; }

        /// <summary>
        /// 描述 :上期标准价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVPLPR { get; set; }

        /// <summary>
        /// 描述 :固定的上年计划价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVPLPX { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// 空值 :true 
        /// </summary>
        public string MbewVPRSV { get; set; }

        /// <summary>
        /// 描述 :前年的总库存  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVVJLB { get; set; }

        /// <summary>
        /// 描述 :计价在  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVVJSL { get; set; }

        /// <summary>
        /// 描述 :前期的总库存值 
        /// 空值 :false 
        /// </summary>
        public decimal MbewVVMLB { get; set; }

        /// <summary>
        /// 描述 :计价在  
        /// 空值 :false 
        /// </summary>
        public decimal MbewVVSAL { get; set; }

        /// <summary>
        /// 描述 :最后实际盘点日 
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewWLINL { get; set; }

        /// <summary>
        /// 描述 :评估单位 
        /// 空值 :true 
        /// </summary>
        public string MbewXBEWM { get; set; }

        /// <summary>
        /// 描述 :LIFO/FIFO-相关 
        /// 空值 :true 
        /// </summary>
        public string MbewXLIFO { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewZKDAT { get; set; }

        /// <summary>
        /// 描述 :未来价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewZKPRS { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 1 
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewZPLD1 { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 2 
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewZPLD2 { get; set; }

        /// <summary>
        /// 描述 :计划价格日期 3 
        /// 空值 :true 
        /// </summary>
        public DateTime? MbewZPLD3 { get; set; }

        /// <summary>
        /// 描述 :计划价格 1 
        /// 空值 :false 
        /// </summary>
        public decimal MbewZPLP1 { get; set; }

        /// <summary>
        /// 描述 :计划价格 2 
        /// 空值 :false 
        /// </summary>
        public decimal MbewZPLP2 { get; set; }

        /// <summary>
        /// 描述 :计划价格 3 
        /// 空值 :false 
        /// </summary>
        public decimal MbewZPLP3 { get; set; }

        /// <summary>
        /// 描述 :未来计划价格 
        /// 空值 :false 
        /// </summary>
        public decimal MbewZPLPR { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}