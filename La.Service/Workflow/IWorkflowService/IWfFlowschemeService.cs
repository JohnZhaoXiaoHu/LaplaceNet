using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 流程service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    public interface IWfFlowschemeService : IBaseService<WfFlowscheme>
    {
        PagedInfo<WfFlowschemeDto> GetList(WfFlowschemeQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfFlowscheme(WfFlowscheme parm);

        int UpdateWfFlowscheme(WfFlowscheme parm);
        
        void TruncateWfFlowscheme();
    }
}
