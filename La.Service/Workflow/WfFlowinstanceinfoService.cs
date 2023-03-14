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
    /// 工作流实例操作记录Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowinstanceinfoService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowinstanceinfoService : BaseService<WfFlowinstanceinfo>, IWfFlowinstanceinfoService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询工作流实例操作记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowinstanceinfoDto> GetList(WfFlowinstanceinfoQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowinstanceinfo>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowinstanceinfo, WfFlowinstanceinfoDto>(parm);

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
        /// 添加工作流实例操作记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowinstanceinfo(WfFlowinstanceinfo parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.InstanceId,
                it.Content,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改工作流实例操作记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowinstanceinfo(WfFlowinstanceinfo parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowinstanceinfo()
            {
                InstanceId = parm.InstanceId,
                Content = parm.Content,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空工作流实例操作记录
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowinstanceinfo()
        {
            Truncate();
        }
        #endregion
    }
}