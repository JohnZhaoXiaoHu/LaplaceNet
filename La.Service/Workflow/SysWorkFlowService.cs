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
    /// 工作流Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-15
    /// </summary>
    [AppService(ServiceType = typeof(ISysWorkFlowService), ServiceLifetime = LifeTime.Transient)]
    public class SysWorkFlowService : BaseService<SysWorkFlow>, ISysWorkFlowService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询工作流列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysWorkFlowDto> GetList(SysWorkFlowQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SysWorkFlow>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.WorkName), it => it.WorkName.Contains(parm.WorkName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.WorkTable), it => it.WorkTable.Contains(parm.WorkTable));
            predicate = predicate.AndIF(parm.BeginCreateTime == null, it => it.CreateTime >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginCreateTime != null, it => it.CreateTime >= parm.BeginCreateTime && it.CreateTime <= parm.EndCreateTime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SysWorkFlow, SysWorkFlowDto>(parm);

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
        /// 添加工作流
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSysWorkFlow(SysWorkFlow parm)
        {
            var response = Insert(parm, it => new
            {
                it.WorkflowId,
                it.WorkName,
                it.WorkTable,
                it.WorkTableName,
                it.NodeConfig,
                it.LineConfig,
                it.Enable,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改工作流
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSysWorkFlow(SysWorkFlow parm)
        {
            var response = Update(w => w.WorkflowId == parm.WorkflowId, it => new SysWorkFlow()
            {
                WorkName = parm.WorkName,
                WorkTable = parm.WorkTable,
                WorkTableName = parm.WorkTableName,
                NodeConfig = parm.NodeConfig,
                LineConfig = parm.LineConfig,
                Enable = parm.Enable,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空工作流
        /// </summary>
        /// <returns></returns>
        public void TruncateSysWorkFlow()
        {
            Truncate();
        }
        #endregion
    }
}