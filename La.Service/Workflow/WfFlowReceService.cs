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
    /// 流程使用记录Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowReceService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowReceService : BaseService<WfFlowRece>, IWfFlowReceService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询流程使用记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowReceDto> GetList(WfFlowReceQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowRece>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Useid), it => it.Useid.Contains(parm.Useid));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Floid), it => it.Floid.Contains(parm.Floid));
            predicate = predicate.AndIF(parm.BeginUptim == null, it => it.Uptim >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginUptim != null, it => it.Uptim >= parm.BeginUptim && it.Uptim <= parm.EndUptim);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowRece, WfFlowReceDto>(parm);

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
        /// 添加流程使用记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowRece(WfFlowRece parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.Useid,
                it.Floid,
                it.Uptim,
            });
            return response;
        }

        /// <summary>
        /// 修改流程使用记录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowRece(WfFlowRece parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowRece()
            {
                Uptim = parm.Uptim,
            });
            return response;
        }

        /// <summary>
        /// 清空流程使用记录
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowRece()
        {
            Truncate();
        }
        #endregion
    }
}