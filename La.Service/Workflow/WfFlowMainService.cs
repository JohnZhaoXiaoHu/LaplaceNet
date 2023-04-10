using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Workflow.IWorkflowService;
using System.Linq;

namespace La.Service.Workflow
{
    /// <summary>
    /// OA流程实例表Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowMainService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowMainService : BaseService<WfFlowMain>, IWfFlowMainService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询OA流程实例表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowMainDto> GetList(WfFlowMainQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowMain>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Protd), it => it.Protd.Contains(parm.Protd));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.BeginCrtim == null, it => it.Crtim >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginCrtim != null, it => it.Crtim >= parm.BeginCrtim && it.Crtim <= parm.EndCrtim);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Crmid), it => it.Crmid.Contains(parm.Crmid));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowMain, WfFlowMainDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.Id.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加OA流程实例表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowMain(WfFlowMain parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.Protd,
                it.Zform,
                it.Tmpid,
                it.State,
                it.Name,
                it.Crtim,
                it.Uptim,
                it.Crmid,
                it.Upmid,
                it.Avtag,
                it.Notes,
            });
            return response;
        }

        /// <summary>
        /// 修改OA流程实例表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowMain(WfFlowMain parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowMain()
            {
                Protd = parm.Protd,
                Zform = parm.Zform,
                State = parm.State,
                Name = parm.Name,
                Crtim = parm.Crtim,
                Uptim = parm.Uptim,
                Avtag = parm.Avtag,
                Notes = parm.Notes,
            });
            return response;
        }

        /// <summary>
        /// 清空OA流程实例表
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowMain()
        {
            Truncate();
        }
        #endregion
    }
}