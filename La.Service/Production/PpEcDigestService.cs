using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Production.IProductionService;
using System.Linq;

namespace La.Service.Production
{
    /// <summary>
    /// 新旧物料Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcDigestService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcDigestService : BaseService<PpEcDigest>, IPpEcDigestService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询新旧物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcDigestDto> GetList(PpEcDigestQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcDigest>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.BeginEdIssueDate != null, it => it.EdIssueDate >= parm.BeginEdIssueDate);
            predicate = predicate.AndIF(parm.BeginEdIssueDate != null, it => it.EdIssueDate >= parm.BeginEdIssueDate && it.EdIssueDate <= parm.EndEdIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EdModel), it => it.EdModel == parm.EdModel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Editem), it => it.Editem == parm.Editem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EdEcNo), it => it.EdEcNo.Contains(parm.EdEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EdOldItem), it => it.EdOldItem == parm.EdOldItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EdNewItem), it => it.EdNewItem == parm.EdNewItem);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcDigest, PpEcDigestDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.EdId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加新旧物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcDigest(PpEcDigest parm)
        {
            var response = Insert(parm, it => new
            {
                it.EdBalanceDate,
                it.EdIssueDate,
                it.EdModel,
                it.Editem,
                it.EdEcNo,
                it.EdOldItem,
                it.EdOldQty,
                it.EdPoQty,
                it.EdBalanceQty,
                it.EdNewItem,
                it.EdNewQty,
                it.EdDisposal,
                it.EdNote,
                it.EdStatus,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改新旧物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcDigest(PpEcDigest parm)
        {
            var response = Update(w => w.EdId == parm.EdId, it => new PpEcDigest()
            {
                EdOldQty = parm.EdOldQty,
                EdPoQty = parm.EdPoQty,
                EdBalanceQty = parm.EdBalanceQty,
                EdNewQty = parm.EdNewQty,
                EdDisposal = parm.EdDisposal,
                EdNote = parm.EdNote,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空新旧物料
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcDigest()
        {
            Truncate();
        }
        #endregion
    }
}