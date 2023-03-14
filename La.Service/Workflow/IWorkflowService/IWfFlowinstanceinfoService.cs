using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 工作流实例操作记录service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    public interface IWfFlowinstanceinfoService : IBaseService<WfFlowinstanceinfo>
    {
        PagedInfo<WfFlowinstanceinfoDto> GetList(WfFlowinstanceinfoQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfFlowinstanceinfo(WfFlowinstanceinfo parm);

        int UpdateWfFlowinstanceinfo(WfFlowinstanceinfo parm);
        
        void TruncateWfFlowinstanceinfo();
    }
}
