using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Production.IProductionService;
using System.Linq;
using Aliyun.OSS;

namespace La.Service.Production
{
    /// <summary>
    /// 从源设变Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlvSourceService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlvSourceService : BaseService<PpEcSlvSource>, IPpEcSlvSourceService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlvSourceDto> GetList(PpEcSlvSourceQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcSlvSource>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdS001), it => it.DSapZpabdS001.Contains(parm.DSapZpabdS001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdS002), it => it.DSapZpabdS002.Contains(parm.DSapZpabdS002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdS003), it => it.DSapZpabdS003.Contains(parm.DSapZpabdS003));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdS004), it => it.DSapZpabdS004.Contains(parm.DSapZpabdS004));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdS008), it => it.DSapZpabdS008 == parm.DSapZpabdS008);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsSolved.ToString()), it => it.IsSolved.ToString().Contains(parm.IsSolved.ToString()));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlvSource, PpEcSlvSourceDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.DSapZpabdS001 + it.DSapZpabdS002 + it.DSapZpabdS003 + it.DSapZpabdS004 + it.DSapZpabdS008 == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcSlvSource(PpEcSlvSource parm)
        {
            var response = Insert(parm, it => new
            {
                it.Guid,
                it.DSapZpabdS001,
                it.DSapZpabdS002,
                it.DSapZpabdS003,
                it.DSapZpabdS004,
                it.DSapZpabdS005,
                it.DSapZpabdS006,
                it.DSapZpabdS007,
                it.DSapZpabdS008,
                it.DSapZpabdS009,
                it.DSapZpabdS010,
                it.DSapZpabdS011,
                it.DSapZpabdS012,
                it.DSapZpabdS013,
                it.DSapZpabdS014,
                it.DSapZpabdS015,
                it.DSapZpabdS016,
                it.DSapZpabdS017,
                it.IsSolved,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcSlvSource(PpEcSlvSource parm)
        {
            var response = Update(w => w.Guid == parm.Guid, it => new PpEcSlvSource()
            {
                DSapZpabdS001 = parm.DSapZpabdS001,
                DSapZpabdS002 = parm.DSapZpabdS002,
                DSapZpabdS003 = parm.DSapZpabdS003,
                DSapZpabdS004 = parm.DSapZpabdS004,
                DSapZpabdS005 = parm.DSapZpabdS005,
                DSapZpabdS006 = parm.DSapZpabdS006,
                DSapZpabdS007 = parm.DSapZpabdS007,
                DSapZpabdS008 = parm.DSapZpabdS008,
                DSapZpabdS009 = parm.DSapZpabdS009,
                DSapZpabdS010 = parm.DSapZpabdS010,
                DSapZpabdS011 = parm.DSapZpabdS011,
                DSapZpabdS012 = parm.DSapZpabdS012,
                DSapZpabdS013 = parm.DSapZpabdS013,
                DSapZpabdS014 = parm.DSapZpabdS014,
                DSapZpabdS015 = parm.DSapZpabdS015,
                DSapZpabdS016 = parm.DSapZpabdS016,
                DSapZpabdS017 = parm.DSapZpabdS017,
                IsSolved = parm.IsSolved,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空从源设变
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcSlvSource()
        {
            Truncate();
        }
        #endregion
    }
}