using System;
using La.Model;
using La.Model.Dto;
using System.Collections.Generic;
using La.Model.Models.Workflow.Flowinstance;

namespace La.Service.Workflow.IWorkflowService
{
    /// <summary>
    /// 自定义表单service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    public interface IWfCustomformService : IBaseService<WfCustomform>
    {
        PagedInfo<WfCustomformDto> GetList(WfCustomformQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddWfCustomform(WfCustomform parm);

        int UpdateWfCustomform(WfCustomform parm);
        
        void TruncateWfCustomform();
    }
}
