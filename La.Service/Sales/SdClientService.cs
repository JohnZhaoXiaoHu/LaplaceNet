using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Sales.ISalesService;
using System.Linq;

namespace La.Service.Sales
{
    /// <summary>
    /// 客户信息Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(ISdClientService), ServiceLifetime = LifeTime.Transient)]
    public class SdClientService : BaseService<SdClient>, ISdClientService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询客户信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdClientDto> GetList(SdClientQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SdClient>();

            //搜索条件查询语法参考Sqlsugar
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
        /// 添加客户信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSdClient(SdClient parm)
        {
            var response = Insert(parm, it => new
            {
                it.ScOrg,
                it.ScPlant,
                it.ScIndustryType,
                it.ScEnterpriseNature,
                it.ScCode,
                it.ScAbbr,
                it.ScName,
                it.ScEbe,
                it.ScBusinessNo,
                it.ScTaxNo,
                it.ScTaxType,
                it.ScMainBusiness,
                it.ScCcy,
                it.ScPayTerms,
                it.ScPayMethod,
                it.ScRecAccount,
                it.ScTradeTerms,
                it.ScShippingTerms,
                it.ScCustomerGrade,
                it.ScCustomerCredit,
                it.ScFirstTransDate,
                it.ScLastTransDate,
                it.ScBankCode,
                it.ScBankName,
                it.ScBranchName,
                it.ScBankCountry,
                it.ScBankState,
                it.ScBankCity,
                it.ScBankCounty,
                it.ScBankAddr,
                it.ScBankAddr1,
                it.ScBankAddr2,
                it.ScBankAccount,
                it.ScBankSwiftNo,
                it.ScRegionCode,
                it.ScState,
                it.ScCity,
                it.ScCounty,
                it.ScAddr,
                it.ScAddr1,
                it.ScAddr2,
                it.ScContacts,
                it.ScEmail,
                it.ScTelNo,
                it.ScFaxNp,
                it.ScPhoneNo,
                it.IsFroze,
                it.UDF01,
                it.UDF02,
                it.UDF03,
                it.UDF04,
                it.UDF05,
                it.UDF06,
                it.UDF51,
                it.UDF52,
                it.UDF53,
                it.UDF54,
                it.UDF55,
                it.UDF56,
                it.Remark,
                it.IsDeleted,
                it.CreateBy,
                it.CreateTime,
                it.UpdateBy,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSdClient(SdClient parm)
        {
            var response = Update(w => w.ScId == parm.ScId, it => new SdClient()
            {
                ScIndustryType = parm.ScIndustryType,
                ScEnterpriseNature = parm.ScEnterpriseNature,
                ScAbbr = parm.ScAbbr,
                ScName = parm.ScName,
                ScEbe = parm.ScEbe,
                ScBusinessNo = parm.ScBusinessNo,
                ScTaxNo = parm.ScTaxNo,
                ScTaxType = parm.ScTaxType,
                ScMainBusiness = parm.ScMainBusiness,
                ScCcy = parm.ScCcy,
                ScPayTerms = parm.ScPayTerms,
                ScPayMethod = parm.ScPayMethod,
                ScRecAccount = parm.ScRecAccount,
                ScTradeTerms = parm.ScTradeTerms,
                ScShippingTerms = parm.ScShippingTerms,
                ScCustomerGrade = parm.ScCustomerGrade,
                ScCustomerCredit = parm.ScCustomerCredit,
                ScFirstTransDate = parm.ScFirstTransDate,
                ScLastTransDate = parm.ScLastTransDate,
                ScBankCode = parm.ScBankCode,
                ScBankName = parm.ScBankName,
                ScBranchName = parm.ScBranchName,
                ScBankCountry = parm.ScBankCountry,
                ScBankState = parm.ScBankState,
                ScBankCity = parm.ScBankCity,
                ScBankCounty = parm.ScBankCounty,
                ScBankAddr = parm.ScBankAddr,
                ScBankAddr1 = parm.ScBankAddr1,
                ScBankAddr2 = parm.ScBankAddr2,
                ScBankAccount = parm.ScBankAccount,
                ScBankSwiftNo = parm.ScBankSwiftNo,
                ScRegionCode = parm.ScRegionCode,
                ScState = parm.ScState,
                ScCity = parm.ScCity,
                ScCounty = parm.ScCounty,
                ScAddr = parm.ScAddr,
                ScAddr1 = parm.ScAddr1,
                ScAddr2 = parm.ScAddr2,
                ScContacts = parm.ScContacts,
                ScEmail = parm.ScEmail,
                ScTelNo = parm.ScTelNo,
                ScFaxNp = parm.ScFaxNp,
                ScPhoneNo = parm.ScPhoneNo,
                IsFroze = parm.IsFroze,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空客户信息
        /// </summary>
        /// <returns></returns>
        public void TruncateSdClient()
        {
            Truncate();
        }
        #endregion
    }
}