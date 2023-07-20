using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Infra.Extensions;
using La.Model;
using La.Model.System;
using La.Model.Dto;
using La.Model.Production;
using La.Repository;
using La.Service.Production.IProductionService;
using System.Linq;

namespace La.Service.Production
{
    /// <summary>
    /// oph从表
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputSlaveService : BaseService<PpOutputSlave>, IPpOutputSlaveService
    {
        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputSlaveDto> GetList(PpOutputSlaveQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpOutputSlave>();

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
            int count = Count(it => it.PosId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PosId"></param>
        /// <returns></returns>
        public PpOutputSlave GetInfo(int PosId)
        {
            var response = Queryable()
                .Where(x => x.PosId == PosId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加
        /// oph从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPpOutputSlave(PpOutputSlave model)
        {
            return Add(model, true);
        }

        /// <summary>
        /// 修改编辑
        /// oph从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputSlave(PpOutputSlave model)
        {
            //var response = Update(w => w.PosId == model.PosId, it => new PpOutputSlave()
            //{
            //    PosStartEndTime = model.PosStartEndTime,
            //    PosRealOutput = model.PosRealOutput,
            //    PosLineStopTime = model.PosLineStopTime,
            //    PosStopCause = model.PosStopCause,
            //    PosStopMemo = model.PosStopMemo,
            //    PosBadCause = model.PosBadCause,
            //    PosBadMemo = model.PosBadMemo,
            //    PosRealTime = model.PosRealTime,
            //    PosRealWork = model.PosRealWork,
            //    PosRealWorkDiff = model.PosRealWorkDiff,
            //    PosRealOutputDiff = model.PosRealOutputDiff,
            //    PosAchRatio = model.PosAchRatio,
            //    Remark = model.Remark,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }
        /// <summary>
        /// 清空
        /// oph从表
        /// </summary>
        /// <returns></returns>
        public bool TruncatePpOutputSlave()
        {
            var newTableName = $"pp_output_slave_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("pp_output_slave", newTableName);
            }
            
            return Truncate();
        }
    }
}