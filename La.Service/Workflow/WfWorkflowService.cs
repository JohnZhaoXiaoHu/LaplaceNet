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
    /// 审批流程Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfWorkflowService), ServiceLifetime = LifeTime.Transient)]
    public class WfWorkflowService : BaseService<WfWorkflow>, IWfWorkflowService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询审批流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfWorkflowDto> GetList(WfWorkflowQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfWorkflow>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfWorkflow, WfWorkflowDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.WorkflowId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfWorkflow(WfWorkflow parm)
        {
            var response = Insert(parm, it => new
            {
                it.WorkflowId,
                it.WorkName,
                it.WorkTable,
                it.WorkTableName,
                it.NodeConfig,
                it.LineConfig,
                it.Remark,
                it.Enable,
                it.CreateBy,
                it.CreateTime,
                it.UpdateBy,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改审批流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfWorkflow(WfWorkflow parm)
        {
            var response = Update(w => w.WorkflowId == parm.WorkflowId, it => new WfWorkflow()
            {
                WorkName = parm.WorkName,
                WorkTable = parm.WorkTable,
                WorkTableName = parm.WorkTableName,
                NodeConfig = parm.NodeConfig,
                LineConfig = parm.LineConfig,
                Remark = parm.Remark,
                Enable = parm.Enable,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空审批流程
        /// </summary>
        /// <returns></returns>
        public void TruncateWfWorkflow()
        {
            Truncate();
        }
        #endregion
    }
}