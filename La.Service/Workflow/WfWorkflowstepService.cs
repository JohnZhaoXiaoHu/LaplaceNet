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
    /// 审批节点配置Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfWorkflowstepService), ServiceLifetime = LifeTime.Transient)]
    public class WfWorkflowstepService : BaseService<WfWorkflowstep>, IWfWorkflowstepService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询审批节点配置列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfWorkflowstepDto> GetList(WfWorkflowstepQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfWorkflowstep>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfWorkflowstep, WfWorkflowstepDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.WorkstepflowId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加审批节点配置
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfWorkflowstep(WfWorkflowstep parm)
        {
            var response = Insert(parm, it => new
            {
                it.WorkstepflowId,
                it.WorkflowId,
                it.StepId,
                it.StepName,
                it.StepType,
                it.StepValue,
                it.OrderId,
                it.ReMark,
                it.Enable,
                it.CreateBy,
                it.CreateTime,
                it.UpdateBy,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改审批节点配置
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfWorkflowstep(WfWorkflowstep parm)
        {
            var response = Update(w => w.WorkstepflowId == parm.WorkstepflowId, it => new WfWorkflowstep()
            {
                WorkflowId = parm.WorkflowId,
                StepId = parm.StepId,
                StepName = parm.StepName,
                StepType = parm.StepType,
                StepValue = parm.StepValue,
                OrderId = parm.OrderId,
                ReMark = parm.ReMark,
                Enable = parm.Enable,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空审批节点配置
        /// </summary>
        /// <returns></returns>
        public void TruncateWfWorkflowstep()
        {
            Truncate();
        }
        #endregion
    }
}