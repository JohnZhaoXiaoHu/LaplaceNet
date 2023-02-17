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
using Aliyun.OSS;

namespace La.Service.Financial
{
    /// <summary>
    /// bom成本核算Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBomCostingService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBomCostingService : BaseService<FicoBomCosting>, IFicoBomCostingService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBomCostingDto> GetList(FicoBomCostingQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoBomCosting>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcPlant), it => it.BcPlant == parm.BcPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcFy), it => it.BcFy == parm.BcFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcYm), it => it.BcYm == parm.BcYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcBomItem), it => it.BcBomItem == parm.BcBomItem);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBomCosting, FicoBomCostingDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => Convert.ToDateTime(it.BcBalancedate).ToString("yyyyMMdd") + it.BcPlant + it.BcFy + it.BcFy + it.BcBomItem == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoBomCosting(FicoBomCosting parm)
        {
            var response = Insert(parm, it => new
            {
                it.BcPlant,
                it.BcFy,
                it.BcYm,
                it.BcBomItem,
                it.BcItemText,
                it.BcBomCost,
                it.BcCurrency,
                it.BcBalancedate,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoBomCosting(FicoBomCosting parm)
        {
            var response = Update(w => w.BcId == parm.BcId, it => new FicoBomCosting()
            {
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空bom成本核算
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoBomCosting()
        {
            Truncate();
        }
        #endregion
    }
}