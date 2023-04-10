using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 流程使用记录service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    public interface IWfFlowReceService : IBaseService<WfFlowRece>
    {
        PagedInfo<WfFlowReceDto> GetList(WfFlowReceQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfFlowRece(WfFlowRece parm);

        int UpdateWfFlowRece(WfFlowRece parm);
        
        void TruncateWfFlowRece();
    }
}
