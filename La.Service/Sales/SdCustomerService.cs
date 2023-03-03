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
    /// 顾客信息Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [AppService(ServiceType = typeof(ISdCustomerService), ServiceLifetime = LifeTime.Transient)]
    public class SdCustomerService : BaseService<SdCustomer>, ISdCustomerService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询顾客信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdCustomerDto> GetList(SdCustomerQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SdCustomer>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScOrg), it => it.ScOrg == parm.ScOrg);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScPlant), it => it.ScPlant == parm.ScPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScIndustryType), it => it.ScIndustryType == parm.ScIndustryType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScEnterpriseNature), it => it.ScEnterpriseNature == parm.ScEnterpriseNature);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScCcy), it => it.ScCcy == parm.ScCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScPayTerms), it => it.ScPayTerms == parm.ScPayTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScPayMethod), it => it.ScPayMethod == parm.ScPayMethod);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdCustomer, SdCustomerDto>(parm);

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
        /// 添加顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSdCustomer(SdCustomer parm)
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
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSdCustomer(SdCustomer parm)
        {
            var response = Update(w => w.ScId == parm.ScId, it => new SdCustomer()
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
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空顾客信息
        /// </summary>
        /// <returns></returns>
        public void TruncateSdCustomer()
        {
            Truncate();
        }
        #endregion
    }
}