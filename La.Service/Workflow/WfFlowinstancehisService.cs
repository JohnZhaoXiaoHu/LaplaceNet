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
    /// 工作流实例流转历史记录Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowinstancehisService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowinstancehisService : BaseService<WfFlowinstancehis>, IWfFlowinstancehisService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询工作流实例流转历史记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowinstancehisDto> GetList(WfFlowinstancehisQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowinstancehis>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowinstancehis, WfFlowinstancehisDto>(parm);

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
        /// 添加工作流实例流转历史记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowinstancehis(WfFlowinstancehis parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.InstanceId,
                it.FromNodeId,
                it.FromNodeType,
                it.FromNodeName,
                it.ToNodeId,
                it.ToNodeType,
                it.ToNodeName,
                it.TransitionSate,
                it.IsFinish,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改工作流实例流转历史记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowinstancehis(WfFlowinstancehis parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowinstancehis()
            {
                InstanceId = parm.InstanceId,
                FromNodeId = parm.FromNodeId,
                FromNodeType = parm.FromNodeType,
                FromNodeName = parm.FromNodeName,
                ToNodeId = parm.ToNodeId,
                ToNodeType = parm.ToNodeType,
                ToNodeName = parm.ToNodeName,
                TransitionSate = parm.TransitionSate,
                IsFinish = parm.IsFinish,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空工作流实例流转历史记录
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowinstancehis()
        {
            Truncate();
        }
        #endregion
    }
}