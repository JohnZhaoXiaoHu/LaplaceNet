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
    /// SOPService业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-05-03
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSopService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSopService : BaseService<PpEcSop>, IPpEcSopService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询SOP列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSopDto> GetList(PpEcSopQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcSop>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.BeginEsIssueDate != null, it => it.EsIssueDate >=parm.BeginEsIssueDate);
            predicate = predicate.AndIF(parm.BeginEsIssueDate != null, it => it.EsIssueDate >= parm.BeginEsIssueDate && it.EsIssueDate <= parm.EndEsIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsEcNo), it => it.EsEcNo == parm.EsEcNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsModel), it => it.EsModel == parm.EsModel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsItem), it => it.EsItem == parm.EsItem);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSop, PpEcSopDto>(parm);

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
        /// 添加SOP
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcSop(PpEcSop parm)
        {
            var response = Insert(parm, it => new
            {
                it.EsIssueDate,
                it.EsEcNo,
                it.EsEntryDate,
                it.EsAssigned,
                it.EsModel,
                it.EsItem,
                it.EsPeaAssigned,
                it.IsPeaModifysop,
                it.EsPeaDate,
                it.EsPeaNote,
                it.EmPeaDocNo,
                it.EmPeaDoc,
                it.EsPeaModifier,
                it.EsPeaModifyTime,
                it.EsPepAssigned,
                it.IsPepModifysop,
                it.EsPepDate,
                it.EsPepNote,
                it.EmPepDocNo,
                it.EmPepDoc,
                it.EsPepModifier,
                it.EsPepModifyTime,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改SOP
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcSop(PpEcSop parm)
        {
            var response = Update(w => w.EsId == parm.EsId, it => new PpEcSop()
            {
                EsIssueDate = parm.EsIssueDate,
                EsEcNo = parm.EsEcNo,
                EsEntryDate = parm.EsEntryDate,
                EsAssigned = parm.EsAssigned,
                EsModel = parm.EsModel,
                EsItem = parm.EsItem,
                EsPeaAssigned = parm.EsPeaAssigned,
                IsPeaModifysop = parm.IsPeaModifysop,
                EsPeaDate = parm.EsPeaDate,
                EsPeaNote = parm.EsPeaNote,
                EmPeaDocNo = parm.EmPeaDocNo,
                EmPeaDoc = parm.EmPeaDoc,
                EsPeaModifier = parm.EsPeaModifier,
                EsPeaModifyTime = parm.EsPeaModifyTime,
                EsPepAssigned = parm.EsPepAssigned,
                IsPepModifysop = parm.IsPepModifysop,
                EsPepDate = parm.EsPepDate,
                EsPepNote = parm.EsPepNote,
                EmPepDocNo = parm.EmPepDocNo,
                EmPepDoc = parm.EmPepDoc,
                EsPepModifier = parm.EsPepModifier,
                EsPepModifyTime = parm.EsPepModifyTime,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空SOP
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcSop()
        {
            Truncate();
        }
        #endregion
    }
}