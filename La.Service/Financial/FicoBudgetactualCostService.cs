using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Financial.IFinancialService;
using System.Linq;

namespace La.Service.Financial
{
    /// <summary>
    /// 预算实际明细Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetactualCostService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetactualCostService : BaseService<FicoBudgetactualCost>, IFicoBudgetactualCostService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetactualCostDto> GetList(FicoBudgetactualCostQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoBudgetactualCost>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbFy), it => it.FbFy == parm.FbFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbYm), it => it.FbYm == parm.FbYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCorpCode), it => it.FbCorpCode == parm.FbCorpCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbExpCategory), it => it.FbExpCategory == parm.FbExpCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCostCode), it => it.FbCostCode == parm.FbCostCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbTitleCode), it => it.FbTitleCode == parm.FbTitleCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbTitleNote), it => it.FbTitleNote == parm.FbTitleNote);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetactualCost, FicoBudgetactualCostDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.FbId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoBudgetactualCost(FicoBudgetactualCost parm)
        {
            var response = Insert(parm, it => new
            {
                it.FbFy,
                it.FbYm,
                it.FbCorpCode,
                it.FbCorpName,
                it.FbExpCategory,
                it.FbCostCode,
                it.FbCostName,
                it.FbTitleCode,
                it.FbTitleName,
                it.FbTitleNote,
                it.FbBudgetAmt,
                it.FbActualAmt,
                it.FbDiffAmt,
                it.FbAccountant,
                it.FbBalanceDate,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetactualCost(FicoBudgetactualCost parm)
        {
            var response = Update(w => w.FbId == parm.FbId, it => new FicoBudgetactualCost()
            {
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空预算实际明细
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoBudgetactualCost()
        {
            Truncate();
        }
        #endregion
    }
}