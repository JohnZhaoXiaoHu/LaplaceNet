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
    /// oph从表Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-18
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputSlaveService : BaseService<PpOutputSlave>, IPpOutputSlaveService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputSlaveDto> GetList(PpOutputSlaveQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpOutputSlave>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomGuid), it => it.PomGuid.Contains(parm.PomGuid));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOutputSlave, PpOutputSlaveDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.PomGuid.ToString()+it.PosStartEndTime == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpOutputSlave(PpOutputSlave parm)
        {
            var response = Insert(parm, it => new
            {
                it.PomGuid,
                it.PosStartEndTime,
                it.PosRealOutput,
                it.PosLineStopTime,
                it.PosStopCause,
                it.PosStopMemo,
                it.PosBadCause,
                it.PosBadMemo,
                it.PosRealTime,
                it.PosRealWork,
                it.PosRealWorkDiff,
                it.PosRealOutputDiff,
                it.PosAchRatio,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpOutputSlave(PpOutputSlave parm)
        {
            var response = Update(w => w.PosId == parm.PosId, it => new PpOutputSlave()
            {
                PosRealOutput = parm.PosRealOutput,
                PosLineStopTime = parm.PosLineStopTime,
                PosStopCause = parm.PosStopCause,
                PosStopMemo = parm.PosStopMemo,
                PosBadCause = parm.PosBadCause,
                PosBadMemo = parm.PosBadMemo,
                PosRealTime = parm.PosRealTime,
                PosRealWork = parm.PosRealWork,
                PosRealWorkDiff = parm.PosRealWorkDiff,
                PosRealOutputDiff = parm.PosRealOutputDiff,
                PosAchRatio = parm.PosAchRatio,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空oph从表
        /// </summary>
        /// <returns></returns>
        public void TruncatePpOutputSlave()
        {
            Truncate();
        }
        #endregion
    }
}