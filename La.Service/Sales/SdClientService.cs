using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Infra.Extensions;
using La.Model;
using La.Model.System;
using La.Model.Dto;
using La.Model.Sales;
using La.Repository;
using La.Service.Sales.ISalesService;
using System.Linq;

namespace La.Service.Sales
{
    /// <summary>
    /// 客户信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISdClientService), ServiceLifetime = LifeTime.Transient)]
    public class SdClientService : BaseService<SdClient>, ISdClientService
    {
        /// <summary>
        /// 查询客户信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdClientDto> GetList(SdClientQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SdClient>();

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdClient, SdClientDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.ScId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="ScId"></param>
        /// <returns></returns>
        public SdClient GetInfo(long ScId)
        {
            var response = Queryable()
                .Where(x => x.ScId == ScId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSdClient(SdClient model)
        {
            return Add(model, true);
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdClient(SdClient model)
        {
            //var response = Update(w => w.ScId == model.ScId, it => new SdClient()
            //{
            //    ScOrg = model.ScOrg,
            //    ScPlant = model.ScPlant,
            //    ScIndustryType = model.ScIndustryType,
            //    ScEnterpriseNature = model.ScEnterpriseNature,
            //    ScCode = model.ScCode,
            //    ScAbbr = model.ScAbbr,
            //    ScName = model.ScName,
            //    ScEbe = model.ScEbe,
            //    ScBusinessNo = model.ScBusinessNo,
            //    ScTaxNo = model.ScTaxNo,
            //    ScTaxType = model.ScTaxType,
            //    ScMainBusiness = model.ScMainBusiness,
            //    ScCcy = model.ScCcy,
            //    ScPayTerms = model.ScPayTerms,
            //    ScPayMethod = model.ScPayMethod,
            //    ScRecAccount = model.ScRecAccount,
            //    ScTradeTerms = model.ScTradeTerms,
            //    ScShippingTerms = model.ScShippingTerms,
            //    ScCustomerGrade = model.ScCustomerGrade,
            //    ScCustomerCredit = model.ScCustomerCredit,
            //    ScFirstTransDate = model.ScFirstTransDate,
            //    ScLastTransDate = model.ScLastTransDate,
            //    ScBankCode = model.ScBankCode,
            //    ScBankName = model.ScBankName,
            //    ScBranchName = model.ScBranchName,
            //    ScBankCountry = model.ScBankCountry,
            //    ScBankState = model.ScBankState,
            //    ScBankCity = model.ScBankCity,
            //    ScBankCounty = model.ScBankCounty,
            //    ScBankAddr = model.ScBankAddr,
            //    ScBankAddr1 = model.ScBankAddr1,
            //    ScBankAddr2 = model.ScBankAddr2,
            //    ScBankAccount = model.ScBankAccount,
            //    ScBankSwiftNo = model.ScBankSwiftNo,
            //    ScRegionCode = model.ScRegionCode,
            //    ScState = model.ScState,
            //    ScCity = model.ScCity,
            //    ScCounty = model.ScCounty,
            //    ScAddr = model.ScAddr,
            //    ScAddr1 = model.ScAddr1,
            //    ScAddr2 = model.ScAddr2,
            //    ScContacts = model.ScContacts,
            //    ScEmail = model.ScEmail,
            //    ScTelNo = model.ScTelNo,
            //    ScFaxNp = model.ScFaxNp,
            //    ScPhoneNo = model.ScPhoneNo,
            //    IsFroze = model.IsFroze,
            //    ReMark = model.ReMark,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }
        /// <summary>
        /// 清空客户信息
        /// </summary>
        /// <returns></returns>
        public bool TruncateSdClient()
        {
            var newTableName = $"sd_client_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("sd_client", newTableName);
            }
            
            return Truncate();
        }
    }
}