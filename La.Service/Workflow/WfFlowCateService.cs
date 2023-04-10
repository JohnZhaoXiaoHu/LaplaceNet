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
    /// OA流程分类表Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowCateService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowCateService : BaseService<WfFlowCate>, IWfFlowCateService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询OA流程分类表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowCateDto> GetList(WfFlowCateQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowCate>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.BeginCrtim == null, it => it.Crtim >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginCrtim != null, it => it.Crtim >= parm.BeginCrtim && it.Crtim <= parm.EndCrtim);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Crmid), it => it.Crmid.Contains(parm.Crmid));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowCate, WfFlowCateDto>(parm);

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
        /// 添加OA流程分类表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowCate(WfFlowCate parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.Ornum,
                it.Pid,
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
        /// 修改OA流程分类表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowCate(WfFlowCate parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowCate()
            {
                Ornum = parm.Ornum,
                Name = parm.Name,
                Crtim = parm.Crtim,
                Uptim = parm.Uptim,
                Avtag = parm.Avtag,
                Notes = parm.Notes,
            });
            return response;
        }

        /// <summary>
        /// 清空OA流程分类表
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowCate()
        {
            Truncate();
        }
        #endregion
    }
}