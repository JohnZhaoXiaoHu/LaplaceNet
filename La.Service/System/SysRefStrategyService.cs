using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.System.ISystemService;
using System.Linq;

namespace La.Service.System
{
    /// <summary>
    /// 单据编码Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-24
    /// </summary>
    [AppService(ServiceType = typeof(ISysRefStrategyService), ServiceLifetime = LifeTime.Transient)]
    public class SysRefStrategyService : BaseService<SysRefStrategy>, ISysRefStrategyService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询单据编码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysRefStrategyDto> GetList(SysRefStrategyQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SysRefStrategy>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefModule), it => it.RefModule == parm.RefModule);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefCategory), it => it.RefCategory == parm.RefCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefPattern), it => it.RefPattern == parm.RefPattern);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SysRefStrategy, SysRefStrategyDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.InitNumber.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加单据编码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSysRefStrategy(SysRefStrategy parm)
        {
            var response = Insert(parm, it => new
            {
                it.RefModule,
                it.RefCategory,
                it.RefCode,
                it.RefName,
                it.RefPattern,
                it.RefPrefix,
                it.RefLenth,
                it.InitNumber,
                it.IsoNumber,
                it.Status,
                it.Sort,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改单据编码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSysRefStrategy(SysRefStrategy parm)
        {
            var response = Update(w => w.RefId == parm.RefId, it => new SysRefStrategy()
            {
                Status = parm.Status,
                Sort = parm.Sort,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空单据编码
        /// </summary>
        /// <returns></returns>
        public void TruncateSysRefStrategy()
        {
            Truncate();
        }
        #endregion
    }
}