using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 工作流service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-15
    /// </summary>
    public interface ISysWorkFlowService : IBaseService<SysWorkFlow>
    {
        PagedInfo<SysWorkFlowDto> GetList(SysWorkFlowQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSysWorkFlow(SysWorkFlow parm);

        int UpdateSysWorkFlow(SysWorkFlow parm);
        
        void TruncateSysWorkFlow();
    }
}
