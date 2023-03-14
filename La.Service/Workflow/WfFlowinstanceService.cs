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
    /// 流程实例模板Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowinstanceService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowinstanceService : BaseService<WfFlowinstance>, IWfFlowinstanceService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询流程实例模板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowinstanceDto> GetList(WfFlowinstanceQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowinstance>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowinstance, WfFlowinstanceDto>(parm);

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
        /// 添加流程实例模板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowinstance(WfFlowinstance parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.InstanceSchemeId,
                it.Code,
                it.CustomName,
                it.ActivityId,
                it.ActivityType,
                it.ActivityName,
                it.PreviousId,
                it.SchemeContent,
                it.SchemeId,
                it.DbName,
                it.FrmData,
                it.FrmType,
                it.FrmContentData,
                it.FrmContentParse,
                it.FrmId,
                it.SchemeType,
                it.FlowLevel,
                it.IsFinish,
                it.FrmContent,
                it.MakerList,
                it.OrgId,
                it.Active,
                it.Status,
                it.IsDeleted,
                it.TenantId,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改流程实例模板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowinstance(WfFlowinstance parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowinstance()
            {
                InstanceSchemeId = parm.InstanceSchemeId,
                Code = parm.Code,
                CustomName = parm.CustomName,
                ActivityId = parm.ActivityId,
                ActivityType = parm.ActivityType,
                ActivityName = parm.ActivityName,
                PreviousId = parm.PreviousId,
                SchemeContent = parm.SchemeContent,
                SchemeId = parm.SchemeId,
                DbName = parm.DbName,
                FrmData = parm.FrmData,
                FrmType = parm.FrmType,
                FrmContentData = parm.FrmContentData,
                FrmContentParse = parm.FrmContentParse,
                FrmId = parm.FrmId,
                SchemeType = parm.SchemeType,
                FlowLevel = parm.FlowLevel,
                IsFinish = parm.IsFinish,
                FrmContent = parm.FrmContent,
                MakerList = parm.MakerList,
                OrgId = parm.OrgId,
                Active = parm.Active,
                Status = parm.Status,
                TenantId = parm.TenantId,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空流程实例模板
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowinstance()
        {
            Truncate();
        }
        #endregion
    }
}