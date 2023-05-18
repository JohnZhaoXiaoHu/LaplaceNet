using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Office.IOfficeService;
using System.Linq;

namespace La.Service.Office
{
    /// <summary>
    /// 人事信息Service业务层处理
    ///
    /// @author Davis.Ching
    /// @date 2023-05-16
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeEhrEmployeeService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeEhrEmployeeService : BaseService<OfficeEhrEmployee>, IOfficeEhrEmployeeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeEhrEmployeeDto> GetList(OfficeEhrEmployeeQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<OfficeEhrEmployee>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeName), it => it.EeName.Contains(parm.EeName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeGender), it => it.EeGender == parm.EeGender);
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >=parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday && it.EeBirthday <= parm.EndEeBirthday);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeIdentityCard), it => it.EeIdentityCard.Contains(parm.EeIdentityCard));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCountry), it => it.EeCountry == parm.EeCountry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeProvince), it => it.EeProvince == parm.EeProvince);
            predicate = predicate.AndIF(parm.EeDepartmentId != null, it => it.EeDepartmentId == parm.EeDepartmentId);
            predicate = predicate.AndIF(parm.EeTitlesId != null, it => it.EeTitlesId == parm.EeTitlesId);
            predicate = predicate.AndIF(parm.EePostId != null, it => it.EePostId == parm.EePostId);
            predicate = predicate.AndIF(parm.EePostLevel != null, it => it.EePostLevel == parm.EePostLevel);
            predicate = predicate.AndIF(parm.EeDutyName != null, it => it.EeDutyName == parm.EeDutyName);
            predicate = predicate.AndIF(parm.EeRecruited != null, it => it.EeRecruited == parm.EeRecruited);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeEngageForm), it => it.EeEngageForm == parm.EeEngageForm);
            predicate = predicate.AndIF(parm.EeTiptopDegrEe != null, it => it.EeTiptopDegrEe == parm.EeTiptopDegrEe);
            predicate = predicate.AndIF(parm.EeSpecialty != null, it => it.EeSpecialty == parm.EeSpecialty);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID.Contains(parm.EeWorkID));
            predicate = predicate.AndIF(parm.BeginEeLeaveDate != null, it => it.EeLeaveDate >=parm.BeginEeLeaveDate);
            predicate = predicate.AndIF(parm.BeginEeLeaveDate != null, it => it.EeLeaveDate >= parm.BeginEeLeaveDate && it.EeLeaveDate <= parm.EndEeLeaveDate);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<OfficeEhrEmployee, OfficeEhrEmployeeDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.EeId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加人事信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddOfficeEhrEmployee(OfficeEhrEmployee parm)
        {
            var response = Insert(parm, it => new
            {
                it.EeId,
                it.EeName,
                it.EeNameUsed,
                it.EeNickName,
                it.EeEnglishName,
                it.EeGender,
                it.EeBirthday,
                it.EeIdentityCard,
                it.EeWedlock,
                it.EeNationId,
                it.EeNativePlace,
                it.EePoliticId,
                it.EeEmail,
                it.EePhone,
                it.EeCountry,
                it.EeProvince,
                it.EeCity,
                it.EeCounty,
                it.EeHomeAddress,
                it.EePostCode,
                it.EeHouseholdType,
                it.EeStayAddress,
                it.EeDepartmentId,
                it.EeTitlesId,
                it.EePostId,
                it.EePostLevel,
                it.EeDutyName,
                it.EeRecruited,
                it.EeEngageForm,
                it.EeTiptopDegrEe,
                it.EeSpecialty,
                it.EeSchool,
                it.EeWorkID,
                it.EeBeginDate,
                it.EeWorkState,
                it.EeProbation,
                it.EeContractTerm,
                it.EeConversionTime,
                it.EeLeaveDate,
                it.EeBeginContract,
                it.EeBndContract,
                it.EeWorkAge,
                it.EeAvatar,
                it.EeQualificationAffix,
                it.EeTitleAffix,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改人事信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateOfficeEhrEmployee(OfficeEhrEmployee parm)
        {
            var response = Update(w => w.EeId == parm.EeId, it => new OfficeEhrEmployee()
            {
                EeName = parm.EeName,
                EeNameUsed = parm.EeNameUsed,
                EeNickName = parm.EeNickName,
                EeEnglishName = parm.EeEnglishName,
                EeGender = parm.EeGender,
                EeBirthday = parm.EeBirthday,
                EeIdentityCard = parm.EeIdentityCard,
                EeWedlock = parm.EeWedlock,
                EeNationId = parm.EeNationId,
                EeNativePlace = parm.EeNativePlace,
                EePoliticId = parm.EePoliticId,
                EeEmail = parm.EeEmail,
                EePhone = parm.EePhone,
                EeCountry = parm.EeCountry,
                EeProvince = parm.EeProvince,
                EeCity = parm.EeCity,
                EeCounty = parm.EeCounty,
                EeHomeAddress = parm.EeHomeAddress,
                EePostCode = parm.EePostCode,
                EeHouseholdType = parm.EeHouseholdType,
                EeStayAddress = parm.EeStayAddress,
                EeDepartmentId = parm.EeDepartmentId,
                EeTitlesId = parm.EeTitlesId,
                EePostId = parm.EePostId,
                EePostLevel = parm.EePostLevel,
                EeDutyName = parm.EeDutyName,
                EeRecruited = parm.EeRecruited,
                EeEngageForm = parm.EeEngageForm,
                EeTiptopDegrEe = parm.EeTiptopDegrEe,
                EeSpecialty = parm.EeSpecialty,
                EeSchool = parm.EeSchool,
                EeWorkID = parm.EeWorkID,
                EeBeginDate = parm.EeBeginDate,
                EeWorkState = parm.EeWorkState,
                EeProbation = parm.EeProbation,
                EeContractTerm = parm.EeContractTerm,
                EeConversionTime = parm.EeConversionTime,
                EeLeaveDate = parm.EeLeaveDate,
                EeBeginContract = parm.EeBeginContract,
                EeBndContract = parm.EeBndContract,
                EeWorkAge = parm.EeWorkAge,
                EeAvatar = parm.EeAvatar,
                EeQualificationAffix = parm.EeQualificationAffix,
                EeTitleAffix = parm.EeTitleAffix,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空人事信息
        /// </summary>
        /// <returns></returns>
        public void TruncateOfficeEhrEmployee()
        {
            Truncate();
        }
        #endregion
    }
}