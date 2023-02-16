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
    /// 月度存货明细Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthInventoryService : BaseService<FicoMonthInventory>, IFicoMonthInventoryService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询月度存货明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthInventoryDto> GetList(FicoMonthInventoryQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoMonthInventory>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiPlant), it => it.MiPlant == parm.MiPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiFy), it => it.MiFy == parm.MiFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiYm), it => it.MiYm == parm.MiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiItem), it => it.MiItem == parm.MiItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiValType), it => it.MiValType == parm.MiValType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiLocalCcy), it => it.MiLocalCcy == parm.MiLocalCcy);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthInventory, FicoMonthInventoryDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.MiId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加月度存货明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoMonthInventory(FicoMonthInventory parm)
        {
            var response = Insert(parm, it => new
            {
                it.MiId,
                it.MiPlant,
                it.MiFy,
                it.MiYm,
                it.MiItem,
                it.MiValType,
                it.MiPriceControl,
                it.MiMovingAverage,
                it.MiPerUnit,
                it.MiLocalCcy,
                it.MiInventoryQty,
                it.MiInventoryAmount,
                it.MiBalancedate,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改月度存货明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoMonthInventory(FicoMonthInventory parm)
        {
            var response = Update(w => w.MiId == parm.MiId, it => new FicoMonthInventory()
            {
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空月度存货明细
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoMonthInventory()
        {
            Truncate();
        }
        #endregion
    }
}