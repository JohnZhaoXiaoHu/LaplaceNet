using La.Model.System;
using La.Model.System.Dto;

namespace La.Service.System.IService
{
    public interface ISysTasksQzService : IBaseService<SysTasks>
    {
        //SysTasksQz GetId(object id);
        int AddTasks(SysTasks parm);
        int UpdateTasks(SysTasks parm);
    }
}
