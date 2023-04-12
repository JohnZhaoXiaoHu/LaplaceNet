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
    /// 表单Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfFormService), ServiceLifetime = LifeTime.Transient)]
    public class WfFormService : BaseService<WfForm>, IWfFormService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询表单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfFormDto> GetList(WfFormQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfForm>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfForm, WfFormDto>(parm);

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
        /// 添加表单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfForm(WfForm parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.FrmType,
                it.WebId,
                it.Fields,
                it.ContentData,
                it.ContentParse,
                it.Content,
                it.DbName,
                it.OrgId,
                it.Active,
                it.Status,
                it.Sort,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改表单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfForm(WfForm parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfForm()
            {
                Name = parm.Name,
                FrmType = parm.FrmType,
                WebId = parm.WebId,
                Fields = parm.Fields,
                ContentData = parm.ContentData,
                ContentParse = parm.ContentParse,
                Content = parm.Content,
                DbName = parm.DbName,
                OrgId = parm.OrgId,
                Active = parm.Active,
                Status = parm.Status,
                Sort = parm.Sort,
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空表单
        /// </summary>
        /// <returns></returns>
        public void TruncateWfForm()
        {
            Truncate();
        }
        #endregion
    }
}