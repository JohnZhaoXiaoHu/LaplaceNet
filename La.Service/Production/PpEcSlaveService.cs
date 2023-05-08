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
using System.Collections.Generic;
using La.Infra.Model;
using La.Infra.Extensions;

namespace La.Service.Production
{
    /// <summary>
    /// 从设变Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-05-02
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcSlave>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsEcNo), it => it.EsEcNo.Contains(parm.EsEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsModel), it => it.EsModel == parm.EsModel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsItem), it => it.EsItem == parm.EsItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsSubItem), it => it.EsSubItem.Contains(parm.EsSubItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsOldItem), it => it.EsOldItem.Contains(parm.EsOldItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsNewItem), it => it.EsNewItem.Contains(parm.EsNewItem));

            //数据量超大时无条件下只显示1000条记录
            if (parm.EsEcNo == null && parm.EsModel == null && parm.EsItem == null && parm.EsSubItem == null && parm.EsOldItem == null && parm.EsNewItem == null)
            {
                var response = Queryable().Take(1000)
                            .Where(predicate.ToExpression())
                            .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

                return response;
            }
            else
            {
                var response = Queryable()
                    .Where(predicate.ToExpression())
                    .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

                return response;

            }
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.EsId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcSlave(PpEcSlave parm)
        {
            var response = Insert(parm, it => new
            {
                it.EsEntryDate,
                it.EsEcNo,
                it.EsModel,
                it.EsItem,
                it.EsSubItem,
                it.EsOldItem,
                it.EsOldItemText,
                it.EsOldUsageQty,
                it.EsOldSetLoc,
                it.EsNewItem,
                it.EsNewItemText,
                it.EsNewUsageQty,
                it.EsNewSetLoc,
                it.EsBomNo,
                it.EsChange,
                it.Eslocal,
                it.Esnote,
                it.EsOldProcess,
                it.EsBomDate,
                it.EmEcImpDept,
                it.EsPurType,
                it.EsSloc,
                it.EsInsmk,
                it.EsMstae,
                it.EsSopStae,
                it.EsOldCurrStock,
                it.EsNewCurrStock,
                it.EsPurEntryDate,
                it.EsSupplier,
                it.EsPurOrder,
                it.EsPurNote,
                it.EsPurCreator,
                it.EsPurCreateTime,
                it.EsPurModifier,
                it.EsPurModifyTime,
                it.EsPmcEntryDate,
                it.EsPmcLot,
                it.EsPmcMemo,
                it.EsPmcNote,
                it.EsPmcCreator,
                it.EsPmcCreateTime,
                it.EsPmcModifier,
                it.EsPmcModifyTime,
                it.EsIqcEntryDate,
                it.EsIqcOrder,
                it.EsIqcNote,
                it.EsIqcCreator,
                it.EsIqcCreateTime,
                it.EsIqcModifier,
                it.EsIqcModifyTime,
                it.EsMmEntryDate,
                it.EsMmLot,
                it.EsMmMocNo,
                it.EsMmNote,
                it.EsMmCreator,
                it.EsMmCreateTime,
                it.EsMmModifier,
                it.EsMmModifyTime,
                it.EsPpEntryDate,
                it.EsPpLine,
                it.EsPpLot,
                it.EsPpNote,
                it.EsPpCreator,
                it.EsPpCreateTime,
                it.EsPpModifier,
                it.EsPpModifyTime,
                it.EsPcbaEntryDate,
                it.EsPcbaLine,
                it.EsPcbaLot,
                it.EsPcbaNote,
                it.EsPcbaCreator,
                it.EsPcbaCreateTime,
                it.EsPcbaModifier,
                it.EsPcbaModifyTime,
                it.EsQaEntryDate,
                it.EsQaLot,
                it.EsQaNote,
                it.EsQaCreator,
                it.EsQaCreateTime,
                it.EsQaModifier,
                it.EsQaModifyTime,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave parm)
        {
            var response = Update(w => w.EsId == parm.EsId, it => new PpEcSlave()
            {
                EsEntryDate = parm.EsEntryDate,
                EsEcNo = parm.EsEcNo,
                EsModel = parm.EsModel,
                EsItem = parm.EsItem,
                EsSubItem = parm.EsSubItem,
                EsOldItem = parm.EsOldItem,
                EsOldItemText = parm.EsOldItemText,
                EsOldUsageQty = parm.EsOldUsageQty,
                EsOldSetLoc = parm.EsOldSetLoc,
                EsNewItem = parm.EsNewItem,
                EsNewItemText = parm.EsNewItemText,
                EsNewUsageQty = parm.EsNewUsageQty,
                EsNewSetLoc = parm.EsNewSetLoc,
                EsBomNo = parm.EsBomNo,
                EsChange = parm.EsChange,
                Eslocal = parm.Eslocal,
                Esnote = parm.Esnote,
                EsOldProcess = parm.EsOldProcess,
                EsBomDate = parm.EsBomDate,
                EmEcImpDept = parm.EmEcImpDept,
                EsPurType = parm.EsPurType,
                EsSloc = parm.EsSloc,
                EsInsmk = parm.EsInsmk,
                EsMstae = parm.EsMstae,
                EsSopStae = parm.EsSopStae,
                EsOldCurrStock = parm.EsOldCurrStock,
                EsNewCurrStock = parm.EsNewCurrStock,
                EsPurEntryDate = parm.EsPurEntryDate,
                EsSupplier = parm.EsSupplier,
                EsPurOrder = parm.EsPurOrder,
                EsPurNote = parm.EsPurNote,
                EsPurCreator = parm.EsPurCreator,
                EsPurCreateTime = parm.EsPurCreateTime,
                EsPurModifier = parm.EsPurModifier,
                EsPurModifyTime = parm.EsPurModifyTime,
                EsPmcEntryDate = parm.EsPmcEntryDate,
                EsPmcLot = parm.EsPmcLot,
                EsPmcMemo = parm.EsPmcMemo,
                EsPmcNote = parm.EsPmcNote,
                EsPmcCreator = parm.EsPmcCreator,
                EsPmcCreateTime = parm.EsPmcCreateTime,
                EsPmcModifier = parm.EsPmcModifier,
                EsPmcModifyTime = parm.EsPmcModifyTime,
                EsIqcEntryDate = parm.EsIqcEntryDate,
                EsIqcOrder = parm.EsIqcOrder,
                EsIqcNote = parm.EsIqcNote,
                EsIqcCreator = parm.EsIqcCreator,
                EsIqcCreateTime = parm.EsIqcCreateTime,
                EsIqcModifier = parm.EsIqcModifier,
                EsIqcModifyTime = parm.EsIqcModifyTime,
                EsMmEntryDate = parm.EsMmEntryDate,
                EsMmLot = parm.EsMmLot,
                EsMmMocNo = parm.EsMmMocNo,
                EsMmNote = parm.EsMmNote,
                EsMmCreator = parm.EsMmCreator,
                EsMmCreateTime = parm.EsMmCreateTime,
                EsMmModifier = parm.EsMmModifier,
                EsMmModifyTime = parm.EsMmModifyTime,
                EsPpEntryDate = parm.EsPpEntryDate,
                EsPpLine = parm.EsPpLine,
                EsPpLot = parm.EsPpLot,
                EsPpNote = parm.EsPpNote,
                EsPpCreator = parm.EsPpCreator,
                EsPpCreateTime = parm.EsPpCreateTime,
                EsPpModifier = parm.EsPpModifier,
                EsPpModifyTime = parm.EsPpModifyTime,
                EsPcbaEntryDate = parm.EsPcbaEntryDate,
                EsPcbaLine = parm.EsPcbaLine,
                EsPcbaLot = parm.EsPcbaLot,
                EsPcbaNote = parm.EsPcbaNote,
                EsPcbaCreator = parm.EsPcbaCreator,
                EsPcbaCreateTime = parm.EsPcbaCreateTime,
                EsPcbaModifier = parm.EsPcbaModifier,
                EsPcbaModifyTime = parm.EsPcbaModifyTime,
                EsQaEntryDate = parm.EsQaEntryDate,
                EsQaLot = parm.EsQaLot,
                EsQaNote = parm.EsQaNote,
                EsQaCreator = parm.EsQaCreator,
                EsQaCreateTime = parm.EsQaCreateTime,
                EsQaModifier = parm.EsQaModifier,
                EsQaModifyTime = parm.EsQaModifyTime,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空从设变
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcSlave()
        {
            Truncate();
        }
        #endregion
    }
}