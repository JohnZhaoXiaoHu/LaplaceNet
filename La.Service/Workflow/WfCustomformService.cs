using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.System;
using La.Repository;
using La.Service.Workflow.IWorkflowService;
using System.Linq;
using La.Model.Models.Workflow.Flowinstance;

namespace La.Service.Workflow
{
    /// <summary>
    /// 自定义表单Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [AppService(ServiceType = typeof(IWfCustomformService), ServiceLifetime = LifeTime.Transient)]
    public class WfCustomformService : BaseService<WfCustomform>, IWfCustomformService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询自定义表单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WfCustomformDto> GetList(WfCustomformQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<WfCustomform>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WfCustomform, WfCustomformDto>(parm);

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
        /// 添加自定义表单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddWfCustomform(WfCustomform parm)
        {
            var response = Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.Sort,
                it.FlowInstanceId,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改自定义表单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateWfCustomform(WfCustomform parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new WfCustomform()
            {
                Name = parm.Name,
                Sort = parm.Sort,
                FlowInstanceId = parm.FlowInstanceId,
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空自定义表单
        /// </summary>
        /// <returns></returns>
        public void TruncateWfCustomform()
        {
            Truncate();
        }
        #endregion
    }
}