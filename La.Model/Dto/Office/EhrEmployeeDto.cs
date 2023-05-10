using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 人事信息查询对象
    /// @author Davis.Cheng
    /// @date 2023-05-09
    /// </summary>
    public class EhrEmployeeQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :姓名 
        /// </summary>
        public string EeName { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEeBirthday { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEeBirthday { get; set; }
        /// <summary>
        /// 描述 :身份证号 
        /// </summary>
        public string EeIdentityCard { get; set; }
        /// <summary>
        /// 描述 :省区 
        /// </summary>
        public string EeProvince { get; set; }
        /// <summary>
        /// 描述 :部门 
        /// </summary>
        public int? EeDepartmentId { get; set; }
        /// <summary>
        /// 描述 :学历 
        /// </summary>
        public int? EeTiptopDegrEe { get; set; }
        /// <summary>
        /// 描述 :工号 
        /// </summary>
        public string EeWorkID { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEeBeginDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEeBeginDate { get; set; }
        /// <summary>
        /// 描述 :在职状态 
        /// </summary>
        public byte? EeWorkState { get; set; }
    }

    /// <summary>
    /// 人事信息输入输出对象
    /// </summary>
    public class EhrEmployeeDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public string EeId { get; set; }

        /// <summary>
        /// 描述 :姓名 
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]

        [ExcelColumn(Name = "姓名")]
        public string EeName { get; set; }

        /// <summary>
        /// 描述 :曾用名 
        /// </summary>

        [ExcelColumn(Name = "曾用名")]
        public string EeNameUsed { get; set; }

        /// <summary>
        /// 描述 :昵称 
        /// </summary>

        [ExcelColumn(Name = "昵称")]
        public string EeNickName { get; set; }

        /// <summary>
        /// 描述 :英文名 
        /// </summary>

        [ExcelColumn(Name = "英文名")]
        public string EeEnglishName { get; set; }

        /// <summary>
        /// 描述 :性别 
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]

        [ExcelColumn(Name = "性别")]
        public string EeGender { get; set; }

        /// <summary>
        /// 描述 :出生日期 
        /// </summary>
        [Required(ErrorMessage = "出生日期不能为空")]

        [ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 描述 :身份证号 
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        [ExcelIgnore]
        public string EeIdentityCard { get; set; }

        /// <summary>
        /// 描述 :婚姻状态 
        /// </summary>
        [Required(ErrorMessage = "婚姻状态不能为空")]

        [ExcelColumn(Name = "婚姻状态")]
        public byte EeWedlock { get; set; }

        /// <summary>
        /// 描述 :民族 
        /// </summary>
        [Required(ErrorMessage = "民族不能为空")]
        [ExcelIgnore]
        public byte EeNationId { get; set; }

        /// <summary>
        /// 描述 :籍贯 
        /// </summary>
        [Required(ErrorMessage = "籍贯不能为空")]

        [ExcelColumn(Name = "籍贯")]
        public byte EeNativePlace { get; set; }

        /// <summary>
        /// 描述 :政治面貌 
        /// </summary>
        [Required(ErrorMessage = "政治面貌不能为空")]
        [ExcelIgnore]
        public byte EePoliticId { get; set; }

        /// <summary>
        /// 描述 :邮件 
        /// </summary>

        [ExcelColumn(Name = "邮件")]
        public string EeEmail { get; set; }

        /// <summary>
        /// 描述 :电话 
        /// </summary>

        [ExcelColumn(Name = "电话")]
        public string EePhone { get; set; }

        /// <summary>
        /// 描述 :国家/地区 
        /// </summary>
        [Required(ErrorMessage = "国家/地区不能为空")]

        [ExcelColumn(Name = "国家/地区")]
        public string EeCountry { get; set; }

        /// <summary>
        /// 描述 :省区 
        /// </summary>
        [Required(ErrorMessage = "省区不能为空")]

        [ExcelColumn(Name = "省区")]
        public string EeProvince { get; set; }

        /// <summary>
        /// 描述 :市区 
        /// </summary>
        [Required(ErrorMessage = "市区不能为空")]

        [ExcelColumn(Name = "市区")]
        public string EeCity { get; set; }

        /// <summary>
        /// 描述 :县区 
        /// </summary>
        [Required(ErrorMessage = "县区不能为空")]

        [ExcelColumn(Name = "县区")]
        public string EeCounty { get; set; }

        /// <summary>
        /// 描述 :家庭住址 
        /// </summary>
        [Required(ErrorMessage = "家庭住址不能为空")]

        [ExcelColumn(Name = "家庭住址")]
        public string EeHomeAddress { get; set; }

        /// <summary>
        /// 描述 :邮编 
        /// </summary>

        [ExcelColumn(Name = "邮编")]
        public string EePostCode { get; set; }

        /// <summary>
        /// 描述 :户口性质 
        /// </summary>

        [ExcelColumn(Name = "户口性质")]
        public byte EeHouseholdType { get; set; }

        /// <summary>
        /// 描述 :暂住地址 
        /// </summary>

        [ExcelColumn(Name = "暂住地址")]
        public string EeStayAddress { get; set; }

        /// <summary>
        /// 描述 :部门 
        /// </summary>
        [Required(ErrorMessage = "部门不能为空")]
        [ExcelIgnore]
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 描述 :职称 
        /// </summary>
        [Required(ErrorMessage = "职称不能为空")]
        [ExcelIgnore]
        public int EeTitlesId { get; set; }

        /// <summary>
        /// 描述 :岗位 
        /// </summary>
        [Required(ErrorMessage = "岗位不能为空")]
        [ExcelIgnore]
        public int EePostId { get; set; }

        /// <summary>
        /// 描述 :等级 
        /// </summary>
        [Required(ErrorMessage = "等级不能为空")]

        [ExcelColumn(Name = "等级")]
        public int EePostLevel { get; set; }

        /// <summary>
        /// 描述 :职务 
        /// </summary>
        [Required(ErrorMessage = "职务不能为空")]

        [ExcelColumn(Name = "职务")]
        public int EeDutyName { get; set; }

        /// <summary>
        /// 描述 :招聘来源 
        /// </summary>
        [Required(ErrorMessage = "招聘来源不能为空")]

        [ExcelColumn(Name = "招聘来源")]
        public int EeRecruited { get; set; }

        /// <summary>
        /// 描述 :聘用形式 
        /// </summary>

        [ExcelColumn(Name = "聘用形式")]
        public string EeEngageForm { get; set; }

        /// <summary>
        /// 描述 :学历 
        /// </summary>

        [ExcelColumn(Name = "学历")]
        public int? EeTiptopDegrEe { get; set; }

        /// <summary>
        /// 描述 :专业 
        /// </summary>

        [ExcelColumn(Name = "专业")]
        public int? EeSpecialty { get; set; }

        /// <summary>
        /// 描述 :院校 
        /// </summary>

        [ExcelColumn(Name = "院校")]
        public string EeSchool { get; set; }

        /// <summary>
        /// 描述 :工号 
        /// </summary>
        [ExcelIgnore]
        public string EeWorkID { get; set; }

        /// <summary>
        /// 描述 :入职日期 
        /// </summary>

        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeBeginDate { get; set; }

        /// <summary>
        /// 描述 :在职状态 
        /// </summary>

        [ExcelColumn(Name = "在职状态")]
        public byte EeWorkState { get; set; }

        /// <summary>
        /// 描述 :试用期 
        /// </summary>

        [ExcelColumn(Name = "试用期")]
        public byte EeProbation { get; set; }

        /// <summary>
        /// 描述 :合同期限 
        /// </summary>

        [ExcelColumn(Name = "合同期限")]
        public byte EeContractTerm { get; set; }

        /// <summary>
        /// 描述 :转正日期 
        /// </summary>

        [ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeConversionTime { get; set; }

        /// <summary>
        /// 描述 :离职日期 
        /// </summary>

        [ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeLeaveDate { get; set; }

        /// <summary>
        /// 描述 :合同起始日 
        /// </summary>

        [ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeBeginContract { get; set; }

        /// <summary>
        /// 描述 :合同终止晶 
        /// </summary>

        [ExcelColumn(Name = "合同终止晶", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EeBndContract { get; set; }

        /// <summary>
        /// 描述 :工龄 
        /// </summary>

        [ExcelColumn(Name = "工龄")]
        public int? EeWorkAge { get; set; }

        /// <summary>
        /// 描述 :头像 
        /// </summary>

        [ExcelColumn(Name = "头像")]
        public string EeAvatar { get; set; }

        /// <summary>
        /// 描述 :学历附件 
        /// </summary>

        [ExcelColumn(Name = "学历附件")]
        public string EeQualificationAffix { get; set; }

        /// <summary>
        /// 描述 :职称附件 
        /// </summary>

        [ExcelColumn(Name = "职称附件")]
        public string EeTitleAffix { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// </summary>
        [ExcelIgnore]
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}