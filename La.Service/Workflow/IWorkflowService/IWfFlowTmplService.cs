using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// OA流程模板表service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    public interface IWfFlowTmplService : IBaseService<WfFlowTmpl>
    {
        PagedInfo<WfFlowTmplDto> GetList(WfFlowTmplQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfFlowTmpl(WfFlowTmpl parm);

        int UpdateWfFlowTmpl(WfFlowTmpl parm);
        
        void TruncateWfFlowTmpl();
    }
}
