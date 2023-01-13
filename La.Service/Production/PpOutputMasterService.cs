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
    /// oph主表Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-12
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputMasterService : BaseService<PpOutputMaster>, IPpOutputMasterService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputMasterDto> GetList(PpOutputMasterQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpOutputMaster>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomOrder), it => it.PomOrder == parm.PomOrder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMflot), it => it.PomMflot == parm.PomMflot);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomModelName), it => it.PomModelName == parm.PomModelName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfItem), it => it.PomMfItem == parm.PomMfItem);
            predicate = predicate.AndIF(parm.BeginPomMfDate == null, it => it.PomMfDate >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginPomMfDate != null, it => it.PomMfDate >= parm.BeginPomMfDate && it.PomMfDate <= parm.EndPomMfDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomLineName), it => it.PomLineName == parm.PomLineName);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOutputMaster, PpOutputMasterDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.PomId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpOutputMaster(PpOutputMaster parm)
        {
            var response = Insert(parm, it => new
            {
                it.PomGuid,
                it.PomOrder,
                it.PomOrderQty,
                it.PomOrderSerial,
                it.PomMflot,
                it.PomModelName,
                it.PomMfItem,
                it.PomMfDate,
                it.PomLineName,
                it.PomDirect,
                it.PomIndirect,
                it.PomStdTime,
                it.PomStdOutput,
                it.UDF54,
                it.UDF55,
                it.UDF56,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpOutputMaster(PpOutputMaster parm)
        {
            var response = Update(w => w.PomId == parm.PomId, it => new PpOutputMaster()
            {
                PomMfDate = parm.PomMfDate,
                PomLineName = parm.PomLineName,
                PomDirect = parm.PomDirect,
                PomIndirect = parm.PomIndirect,
                PomStdTime = parm.PomStdTime,
                PomStdOutput = parm.PomStdOutput,
                UDF54 = parm.UDF54,
                UDF55 = parm.UDF55,
                UDF56 = parm.UDF56,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空oph主表
        /// </summary>
        /// <returns></returns>
        public void TruncatePpOutputMaster()
        {
            Truncate();
        }
        #endregion
    }
}