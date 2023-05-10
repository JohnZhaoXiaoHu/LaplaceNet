using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 人事信息，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-05-09
    /// </summary>
    [SugarTable("ehr_employee")]
    public class EhrEmployee
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string EeId { get; set; }

        /// <summary>
        /// 描述 :姓名 
        /// 空值 :false 
        /// </summary>
        public string EeName { get; set; }

        /// <summary>
        /// 描述 :曾用名 
        /// 空值 :true 
        /// </summary>
        public string EeNameUsed { get; set; }

        /// <summary>
        /// 描述 :昵称 
        /// 空值 :true 
        /// </summary>
        public string EeNickName { get; set; }

        /// <summary>
        /// 描述 :英文名 
        /// 空值 :true 
        /// </summary>
        public string EeEnglishName { get; set; }

        /// <summary>
        /// 描述 :性别 
        /// 空值 :false 
        /// </summary>
        public string EeGender { get; set; }

        /// <summary>
        /// 描述 :出生日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 描述 :身份证号 
        /// 空值 :false 
        /// </summary>
        public string EeIdentityCard { get; set; }

        /// <summary>
        /// 描述 :婚姻状态 
        /// 空值 :false 
        /// </summary>
        public byte EeWedlock { get; set; }

        /// <summary>
        /// 描述 :民族 
        /// 空值 :false 
        /// </summary>
        public byte EeNationId { get; set; }

        /// <summary>
        /// 描述 :籍贯 
        /// 空值 :false 
        /// </summary>
        public byte EeNativePlace { get; set; }

        /// <summary>
        /// 描述 :政治面貌 
        /// 空值 :false 
        /// </summary>
        public byte EePoliticId { get; set; }

        /// <summary>
        /// 描述 :邮件 
        /// 空值 :true 
        /// </summary>
        public string EeEmail { get; set; }

        /// <summary>
        /// 描述 :电话 
        /// 空值 :true 
        /// </summary>
        public string EePhone { get; set; }

        /// <summary>
        /// 描述 :国家/地区 
        /// 空值 :false 
        /// </summary>
        public string EeCountry { get; set; }

        /// <summary>
        /// 描述 :省区 
        /// 空值 :false 
        /// </summary>
        public string EeProvince { get; set; }

        /// <summary>
        /// 描述 :市区 
        /// 空值 :false 
        /// </summary>
        public string EeCity { get; set; }

        /// <summary>
        /// 描述 :县区 
        /// 空值 :false 
        /// </summary>
        public string EeCounty { get; set; }

        /// <summary>
        /// 描述 :家庭住址 
        /// 空值 :false 
        /// </summary>
        public string EeHomeAddress { get; set; }

        /// <summary>
        /// 描述 :邮编 
        /// 空值 :true 
        /// </summary>
        public string EePostCode { get; set; }

        /// <summary>
        /// 描述 :户口性质 
        /// 空值 :true 
        /// </summary>
        public byte EeHouseholdType { get; set; }

        /// <summary>
        /// 描述 :暂住地址 
        /// 空值 :true 
        /// </summary>
        public string EeStayAddress { get; set; }

        /// <summary>
        /// 描述 :部门 
        /// 空值 :false 
        /// </summary>
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 描述 :职称 
        /// 空值 :false 
        /// </summary>
        public int EeTitlesId { get; set; }

        /// <summary>
        /// 描述 :岗位 
        /// 空值 :false 
        /// </summary>
        public int EePostId { get; set; }

        /// <summary>
        /// 描述 :等级 
        /// 空值 :false 
        /// </summary>
        public int EePostLevel { get; set; }

        /// <summary>
        /// 描述 :职务 
        /// 空值 :false 
        /// </summary>
        public int EeDutyName { get; set; }

        /// <summary>
        /// 描述 :招聘来源 
        /// 空值 :false 
        /// </summary>
        public int EeRecruited { get; set; }

        /// <summary>
        /// 描述 :聘用形式 
        /// 空值 :true 
        /// </summary>
        public string EeEngageForm { get; set; }

        /// <summary>
        /// 描述 :学历 
        /// 空值 :true 
        /// </summary>
        public int? EeTiptopDegrEe { get; set; }

        /// <summary>
        /// 描述 :专业 
        /// 空值 :true 
        /// </summary>
        public int? EeSpecialty { get; set; }

        /// <summary>
        /// 描述 :院校 
        /// 空值 :true 
        /// </summary>
        public string EeSchool { get; set; }

        /// <summary>
        /// 描述 :工号 
        /// 空值 :true 
        /// </summary>
        public string EeWorkID { get; set; }

        /// <summary>
        /// 描述 :入职日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EeBeginDate { get; set; }

        /// <summary>
        /// 描述 :在职状态 
        /// 空值 :true 
        /// </summary>
        public byte EeWorkState { get; set; }

        /// <summary>
        /// 描述 :试用期 
        /// 空值 :true 
        /// </summary>
        public byte EeProbation { get; set; }

        /// <summary>
        /// 描述 :合同期限 
        /// 空值 :true 
        /// </summary>
        public byte EeContractTerm { get; set; }

        /// <summary>
        /// 描述 :转正日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EeConversionTime { get; set; }

        /// <summary>
        /// 描述 :离职日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EeLeaveDate { get; set; }

        /// <summary>
        /// 描述 :合同起始日 
        /// 空值 :true 
        /// </summary>
        public DateTime? EeBeginContract { get; set; }

        /// <summary>
        /// 描述 :合同终止晶 
        /// 空值 :true 
        /// </summary>
        public DateTime? EeBndContract { get; set; }

        /// <summary>
        /// 描述 :工龄 
        /// 空值 :true 
        /// </summary>
        public int? EeWorkAge { get; set; }

        /// <summary>
        /// 描述 :头像 
        /// 空值 :true 
        /// </summary>
        public string EeAvatar { get; set; }

        /// <summary>
        /// 描述 :学历附件 
        /// 空值 :true 
        /// </summary>
        public string EeQualificationAffix { get; set; }

        /// <summary>
        /// 描述 :职称附件 
        /// 空值 :true 
        /// </summary>
        public string EeTitleAffix { get; set; }

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
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

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