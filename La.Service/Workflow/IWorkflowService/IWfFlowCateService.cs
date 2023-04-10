using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// OA流程分类表service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    public interface IWfFlowCateService : IBaseService<WfFlowCate>
    {
        PagedInfo<WfFlowCateDto> GetList(WfFlowCateQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfFlowCate(WfFlowCate parm);

        int UpdateWfFlowCate(WfFlowCate parm);
        
        void TruncateWfFlowCate();
    }
}
