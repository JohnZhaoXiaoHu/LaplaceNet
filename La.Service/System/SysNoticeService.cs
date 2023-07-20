using La.Infra.Attribute;
using SqlSugar;
using System.Collections.Generic;
using La.Model.Models;
using La.Model.System;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 通知公告表Service业务层处理
    ///
    /// @author zr
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceType = typeof(ISysNoticeService), ServiceLifetime = LifeTime.Transient)]
    public class SysNoticeService : BaseService<SysNotice>, ISysNoticeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<SysNotice> GetSysNotices()
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SysNotice>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.And(m => m.Status == 0);
            return GetList(predicate.ToExpression());
        }

        #endregion
    }
}