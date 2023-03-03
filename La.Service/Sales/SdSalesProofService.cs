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
    /// 销售凭证Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [AppService(ServiceType = typeof(ISdSalesProofService), ServiceLifetime = LifeTime.Transient)]
    public class SdSalesProofService : BaseService<SdSalesProof>, ISdSalesProofService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSalesProofDto> GetList(SdSalesProofQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SdSalesProof>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpPlnt), it => it.SpPlnt == parm.SpPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpYm), it => it.SpYm == parm.SpYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpCustomerCode), it => it.SpCustomerCode == parm.SpCustomerCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpPrctr), it => it.SpPrctr == parm.SpPrctr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpSalesItem), it => it.SpSalesItem == parm.SpSalesItem);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdSalesProof, SdSalesProofDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.SpId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSdSalesProof(SdSalesProof parm)
        {
            var response = Insert(parm, it => new
            {
                it.SpPlnt,
                it.SpFy,
                it.SpYm,
                it.SpProofNo,
                it.SpProofDetails,
                it.SpCustomerCode,
                it.SpPrctr,
                it.SpSalesItem,
                it.SpTitleCode,
                it.SpSalesQty,
                it.SpSalesUnit,
                it.SpOriginalAmount,
                it.SpOriginalCcy,
                it.SpLocalAmount,
                it.SpLocalCcy,
                it.SpReferenceNo,
                it.SpReferenceDetails,
                it.SpPostingDate,
                it.SpPostingUser,
                it.SpEntryDate,
                it.SpEntryTime,
                it.SpOrigin,
                it.SpPgroup,
                it.SpInvoiceType,
                it.SpInvoiceText,
                it.SpBalancedate,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSdSalesProof(SdSalesProof parm)
        {
            var response = Update(w => w.SpId == parm.SpId, it => new SdSalesProof()
            {
                SpPlnt = parm.SpPlnt,
                SpFy = parm.SpFy,
                SpYm = parm.SpYm,
                SpProofNo = parm.SpProofNo,
                SpProofDetails = parm.SpProofDetails,
                SpCustomerCode = parm.SpCustomerCode,
                SpPrctr = parm.SpPrctr,
                SpSalesItem = parm.SpSalesItem,
                SpTitleCode = parm.SpTitleCode,
                SpSalesQty = parm.SpSalesQty,
                SpSalesUnit = parm.SpSalesUnit,
                SpOriginalAmount = parm.SpOriginalAmount,
                SpOriginalCcy = parm.SpOriginalCcy,
                SpLocalAmount = parm.SpLocalAmount,
                SpLocalCcy = parm.SpLocalCcy,
                SpReferenceNo = parm.SpReferenceNo,
                SpReferenceDetails = parm.SpReferenceDetails,
                SpPostingDate = parm.SpPostingDate,
                SpPostingUser = parm.SpPostingUser,
                SpEntryDate = parm.SpEntryDate,
                SpEntryTime = parm.SpEntryTime,
                SpOrigin = parm.SpOrigin,
                SpPgroup = parm.SpPgroup,
                SpInvoiceType = parm.SpInvoiceType,
                SpInvoiceText = parm.SpInvoiceText,
                SpBalancedate = parm.SpBalancedate,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空销售凭证
        /// </summary>
        /// <returns></returns>
        public void TruncateSdSalesProof()
        {
            Truncate();
        }
        #endregion
    }
}