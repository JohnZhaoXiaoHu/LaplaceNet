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
    /// 月度存货Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthInventoryService : BaseService<FicoMonthInventory>, IFicoMonthInventoryService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthInventoryDto> GetList(FicoMonthInventoryQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoMonthInventory>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiPlant), it => it.MiPlant == parm.MiPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiYm), it => it.MiYm == parm.MiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiItem), it => it.MiItem.Contains(parm.MiItem));
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
            int count = Count(it => it.MiYm.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加月度存货
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
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoMonthInventory(FicoMonthInventory parm)
        {
            var response = Update(w => w.MiId == parm.MiId, it => new FicoMonthInventory()
            {
                MiPlant = parm.MiPlant,
                MiFy = parm.MiFy,
                MiYm = parm.MiYm,
                MiItem = parm.MiItem,
                MiValType = parm.MiValType,
                MiPriceControl = parm.MiPriceControl,
                MiMovingAverage = parm.MiMovingAverage,
                MiPerUnit = parm.MiPerUnit,
                MiLocalCcy = parm.MiLocalCcy,
                MiInventoryQty = parm.MiInventoryQty,
                MiInventoryAmount = parm.MiInventoryAmount,
                MiBalancedate = parm.MiBalancedate,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空月度存货
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoMonthInventory()
        {
            Truncate();
        }
        #endregion
    }
}