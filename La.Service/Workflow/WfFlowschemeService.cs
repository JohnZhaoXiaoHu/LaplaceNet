using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.System;
using La.Repository;
using La.Service.Workflow.IWorkflowService;
using System.Linq;
using La.Model.Models.Workflow.Flowscheme;

namespace La.Service.Workflow
{
    /// <summary>
    /// 流程Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfFlowschemeService), ServiceLifetime = LifeTime.Transient)]
    public class WfFlowschemeService : BaseService<WfFlowscheme>, IWfFlowschemeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFlowschemeDto> GetList(WfFlowschemeQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfFlowscheme>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfFlowscheme, WfFlowschemeDto>(parm);

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
        /// 添加流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfFlowscheme(WfFlowscheme parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.SchemeCode,
                it.SchemeName,
                it.SchemeType,
                it.SchemeVersion,
                it.SchemeCanUser,
                it.SchemeContent,
                it.FrmId,
                it.FrmType,
                it.AuthorizeType,
                it.OrgId,
                it.Active,
                it.Status,
                it.Sort,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfFlowscheme(WfFlowscheme parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfFlowscheme()
            {
                SchemeCode = parm.SchemeCode,
                SchemeName = parm.SchemeName,
                SchemeType = parm.SchemeType,
                SchemeVersion = parm.SchemeVersion,
                SchemeCanUser = parm.SchemeCanUser,
                SchemeContent = parm.SchemeContent,
                FrmId = parm.FrmId,
                FrmType = parm.FrmType,
                AuthorizeType = parm.AuthorizeType,
                OrgId = parm.OrgId,
                Active = parm.Active,
                Status = parm.Status,
                Sort = parm.Sort,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空流程
        /// </summary>
        /// <returns></returns>
        public void TruncateWfFlowscheme()
        {
            Truncate();
        }
        #endregion
    }
}