using System;
using La.Model.System;

namespace La.Service.System
{
    /// <summary>
    /// 参数配置service接口
    ///
    /// @author Davis.Cheng
    /// @date 2021-09-29
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}
