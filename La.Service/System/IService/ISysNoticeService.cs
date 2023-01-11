using System;
using System.Collections.Generic;
using La.Model.System;

namespace La.Service.System.IService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author Davis.Cheng
    /// @date 2021-12-15
    /// </summary>
    public interface ISysNoticeService: IBaseService<SysNotice>
    {
        List<SysNotice> GetSysNotices();
    }
}
