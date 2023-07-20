using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Infra.Extensions;
using La.Model;
using La.Model.System;
using La.Model.Dto;
using La.Model.Office;
using La.Repository;
using La.Service.Office.IOfficeService;
using System.Linq;

namespace La.Service.Office
{
    /// <summary>
    /// 人事信息
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeEhrEmployeeService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeEhrEmployeeService : BaseService<OfficeEhrEmployee>, IOfficeEhrEmployeeService
    {
        /// <summary>
        /// 查询人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeEhrEmployeeDto> GetList(OfficeEhrEmployeeQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<OfficeEhrEmployee>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeName), it => it.EeName.Contains(parm.EeName));
            predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.EndEeBirthday != null, it => it.EeBirthday <= parm.EndEeBirthday);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID.Contains(parm.EeWorkID));
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
        /// 获取详情
        /// </summary>
        /// <param name="EeId"></param>
        /// <returns></returns>
        public OfficeEhrEmployee GetInfo(string EeId)
        {
            var response = Queryable()
                .Where(x => x.EeId == EeId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加
        /// 人事信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddOfficeEhrEmployee(OfficeEhrEmployee model)
        {
            return Add(model, true);
        }

        /// <summary>
        /// 修改编辑
        /// 人事信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOfficeEhrEmployee(OfficeEhrEmployee model)
        {
            //var response = Update(w => w.EeId == model.EeId, it => new OfficeEhrEmployee()
            //{
            //    EeName = model.EeName,
            //    EeNameUsed = model.EeNameUsed,
            //    EeNickName = model.EeNickName,
            //    EeEnglishName = model.EeEnglishName,
            //    EeGender = model.EeGender,
            //    EeBirthday = model.EeBirthday,
            //    EeIdentityCard = model.EeIdentityCard,
            //    EeWedlock = model.EeWedlock,
            //    EeNationId = model.EeNationId,
            //    EeNativePlace = model.EeNativePlace,
            //    EePoliticId = model.EePoliticId,
            //    EeEmail = model.EeEmail,
            //    EePhone = model.EePhone,
            //    EeCountry = model.EeCountry,
            //    EeProvince = model.EeProvince,
            //    EeCity = model.EeCity,
            //    EeCounty = model.EeCounty,
            //    EeHomeAddress = model.EeHomeAddress,
            //    EePostCode = model.EePostCode,
            //    EeHouseholdType = model.EeHouseholdType,
            //    EeStayAddress = model.EeStayAddress,
            //    EeDepartmentId = model.EeDepartmentId,
            //    EeTitlesId = model.EeTitlesId,
            //    EePostId = model.EePostId,
            //    EePostLevel = model.EePostLevel,
            //    EeDutyName = model.EeDutyName,
            //    EeRecruited = model.EeRecruited,
            //    EeEngageForm = model.EeEngageForm,
            //    EeTiptopDegrEe = model.EeTiptopDegrEe,
            //    EeSpecialty = model.EeSpecialty,
            //    EeSchool = model.EeSchool,
            //    EeWorkID = model.EeWorkID,
            //    EeBeginDate = model.EeBeginDate,
            //    EeWorkState = model.EeWorkState,
            //    EeProbation = model.EeProbation,
            //    EeContractTerm = model.EeContractTerm,
            //    EeConversionTime = model.EeConversionTime,
            //    EeLeaveDate = model.EeLeaveDate,
            //    EeBeginContract = model.EeBeginContract,
            //    EeBndContract = model.EeBndContract,
            //    EeWorkAge = model.EeWorkAge,
            //    EeAvatar = model.EeAvatar,
            //    EeQualificationAffix = model.EeQualificationAffix,
            //    EeTitleAffix = model.EeTitleAffix,
            //    Remark = model.Remark,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }
        /// <summary>
        /// 清空
        /// 人事信息
        /// </summary>
        /// <returns></returns>
        public bool TruncateOfficeEhrEmployee()
        {
            var newTableName = $"office_ehr_employee_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("office_ehr_employee", newTableName);
            }
            
            return Truncate();
        }
    }
}