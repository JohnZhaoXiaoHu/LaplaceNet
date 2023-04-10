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
    /// 从设变信息表Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询从设变信息表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcSlave>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

            return response;
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
        /// 添加从设变信息表
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
                it.EsPurType,
                it.EmEcImpDept,
                it.EsSloc,
                it.IsCheck,
                it.IsEol,
                it.EsOldCurrStock,
                it.EsNewCurrStock,
                it.EsDeptEntryDate,
                it.EsDeptName,
                it.EsSupplier,
                it.EsPurOrder,
                it.EsPurNote,
                it.EsPmcLot,
                it.EsPmcMemo,
                it.EsPmcNote,
                it.EsIqcOrder,
                it.EsIqcNote,
                it.EsMmLot,
                it.EsMmMocNo,
                it.EsMmNote,
                it.EsPpLine,
                it.EsPpLot,
                it.EsPpNote,
                it.EsPcbaLine,
                it.EsPcbaLot,
                it.EsPcbaNote,
                it.EsQaLot,
                it.EsQaNote,
                it.EsDeptCreator,
                it.EsDeptCreateTime,
                it.EsDeptModifier,
                it.EsDeptModifyTime,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改从设变信息表
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
                EsPurType = parm.EsPurType,
                EmEcImpDept = parm.EmEcImpDept,
                EsSloc = parm.EsSloc,
                IsCheck = parm.IsCheck,
                IsEol = parm.IsEol,
                EsOldCurrStock = parm.EsOldCurrStock,
                EsNewCurrStock = parm.EsNewCurrStock,
                EsDeptEntryDate = parm.EsDeptEntryDate,
                EsDeptName = parm.EsDeptName,
                EsSupplier = parm.EsSupplier,
                EsPurOrder = parm.EsPurOrder,
                EsPurNote = parm.EsPurNote,
                EsPmcLot = parm.EsPmcLot,
                EsPmcMemo = parm.EsPmcMemo,
                EsPmcNote = parm.EsPmcNote,
                EsIqcOrder = parm.EsIqcOrder,
                EsIqcNote = parm.EsIqcNote,
                EsMmLot = parm.EsMmLot,
                EsMmMocNo = parm.EsMmMocNo,
                EsMmNote = parm.EsMmNote,
                EsPpLine = parm.EsPpLine,
                EsPpLot = parm.EsPpLot,
                EsPpNote = parm.EsPpNote,
                EsPcbaLine = parm.EsPcbaLine,
                EsPcbaLot = parm.EsPcbaLot,
                EsPcbaNote = parm.EsPcbaNote,
                EsQaLot = parm.EsQaLot,
                EsQaNote = parm.EsQaNote,
                EsDeptCreator = parm.EsDeptCreator,
                EsDeptCreateTime = parm.EsDeptCreateTime,
                EsDeptModifier = parm.EsDeptModifier,
                EsDeptModifyTime = parm.EsDeptModifyTime,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空从设变信息表
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcSlave()
        {
            Truncate();
        }
        #endregion
    }
}