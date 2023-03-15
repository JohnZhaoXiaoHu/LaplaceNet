using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 审批节点service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    public interface IWfWorkflowtablestepService : IBaseService<WfWorkflowtablestep>
    {
        PagedInfo<WfWorkflowtablestepDto> GetList(WfWorkflowtablestepQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfWorkflowtablestep(WfWorkflowtablestep parm);

        int UpdateWfWorkflowtablestep(WfWorkflowtablestep parm);
        
        void TruncateWfWorkflowtablestep();
    }
}
