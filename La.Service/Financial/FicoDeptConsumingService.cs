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
    /// 部门消耗Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [AppService(ServiceType = typeof(IFicoDeptConsumingService), ServiceLifetime = LifeTime.Transient)]
    public class FicoDeptConsumingService : BaseService<FicoDeptConsuming>, IFicoDeptConsumingService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoDeptConsumingDto> GetList(FicoDeptConsumingQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoDeptConsuming>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcYm), it => it.DcYm == parm.DcYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcCorpCode), it => it.DcCorpCode == parm.DcCorpCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcExpCategory), it => it.DcExpCategory == parm.DcExpCategory);
            predicate = predicate.And(it => it.IsDeleted == false);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoDeptConsuming, FicoDeptConsumingDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.DcYm + it.DcCostCode + it.DcPlant + it.DcMateriel + it.DcStorageLocation + it.DcMoveType == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoDeptConsuming(FicoDeptConsuming parm)
        {
            var response = Insert(parm, it => new
            {
                it.DcFy,
                it.DcYm,
                it.DcCorpCode,
                it.DcCorpName,
                it.DcExpCategory,
                it.DcCostCode,
                it.DcCostName,
                it.DcTitleCode,
                it.DcTitleName,
                it.DcTitleNote,
                it.DcBudgetAmt,
                it.DcActualAmt,
                it.DcDiffAmt,
                it.DcPlant,
                it.DcMateriel,
                it.DcStorageLocation,
                it.DcMoveType,
                it.DcMaterielDoc,
                it.DcMaterielDocDetails,
                it.DcUseQty,
                it.DcUseAmt,
                it.DcReserveDoc,
                it.DcAccountant,
                it.DcBalanceDate,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoDeptConsuming(FicoDeptConsuming parm)
        {
            var response = Update(w => w.DcId == parm.DcId, it => new FicoDeptConsuming()
            {
                DcFy = parm.DcFy,
                DcYm = parm.DcYm,
                DcCorpCode = parm.DcCorpCode,
                DcCorpName = parm.DcCorpName,
                DcExpCategory = parm.DcExpCategory,
                DcCostCode = parm.DcCostCode,
                DcCostName = parm.DcCostName,
                DcTitleCode = parm.DcTitleCode,
                DcTitleName = parm.DcTitleName,
                DcTitleNote = parm.DcTitleNote,
                DcBudgetAmt = parm.DcBudgetAmt,
                DcActualAmt = parm.DcActualAmt,
                DcDiffAmt = parm.DcDiffAmt,
                DcPlant = parm.DcPlant,
                DcMateriel = parm.DcMateriel,
                DcStorageLocation = parm.DcStorageLocation,
                DcMoveType = parm.DcMoveType,
                DcMaterielDoc = parm.DcMaterielDoc,
                DcMaterielDocDetails = parm.DcMaterielDocDetails,
                DcUseQty = parm.DcUseQty,
                DcUseAmt = parm.DcUseAmt,
                DcReserveDoc = parm.DcReserveDoc,
                DcAccountant = parm.DcAccountant,
                DcBalanceDate = parm.DcBalanceDate,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空部门消耗
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoDeptConsuming()
        {
            Truncate();
        }
        #endregion
    }
}