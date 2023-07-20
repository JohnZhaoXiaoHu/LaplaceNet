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
    /// oph主表
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputMasterService : BaseService<PpOutputMaster>, IPpOutputMasterService
    {
        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputMasterDto> GetList(PpOutputMasterQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpOutputMaster>();

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
        /// 获取详情
        /// </summary>
        /// <param name="PomId"></param>
        /// <returns></returns>
        public PpOutputMaster GetInfo(int PomId)
        {
            var response = Queryable()
                .Where(x => x.PomId == PomId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加
        /// oph主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPpOutputMaster(PpOutputMaster model)
        {
            return Add(model, true);
        }

        /// <summary>
        /// 修改编辑
        /// oph主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputMaster(PpOutputMaster model)
        {
            //var response = Update(w => w.PomId == model.PomId, it => new PpOutputMaster()
            //{
            //    PomOrder = model.PomOrder,
            //    PomOrderQty = model.PomOrderQty,
            //    PomOrderSerial = model.PomOrderSerial,
            //    PomMflot = model.PomMflot,
            //    PomModelName = model.PomModelName,
            //    PomMfItem = model.PomMfItem,
            //    PomMfDate = model.PomMfDate,
            //    PomLineName = model.PomLineName,
            //    PomDirect = model.PomDirect,
            //    PomIndirect = model.PomIndirect,
            //    PomStdTime = model.PomStdTime,
            //    PomStdOutput = model.PomStdOutput,
            //    ReMark = model.ReMark,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }
        /// <summary>
        /// 清空
        /// oph主表
        /// </summary>
        /// <returns></returns>
        public bool TruncatePpOutputMaster()
        {
            var newTableName = $"pp_output_master_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("pp_output_master", newTableName);
            }
            
            return Truncate();
        }
    }
}