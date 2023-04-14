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

namespace La.Service.Production
{
    /// <summary>
    /// 主源设变Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMaSourceService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMaSourceService : BaseService<PpEcMaSource>, IPpEcMaSourceService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMaSourceDto> GetList(PpEcMaSourceQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcMaSource>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdZ001), it => it.DSapZpabdZ001.Contains(parm.DSapZpabdZ001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdZ003), it => it.DSapZpabdZ003.Contains(parm.DSapZpabdZ003));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DSapZpabdZ004), it => it.DSapZpabdZ004 == parm.DSapZpabdZ004);
            predicate = predicate.AndIF(parm.BeginDSapZpabdZ005 == null, it => it.DSapZpabdZ005 >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginDSapZpabdZ005 != null, it => it.DSapZpabdZ005 >= parm.BeginDSapZpabdZ005 && it.DSapZpabdZ005 <= parm.EndDSapZpabdZ005);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsSolved.ToString()), it => it.IsSolved.ToString().Contains(parm.IsSolved.ToString()));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcMaSource, PpEcMaSourceDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.Guid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcMaSource(PpEcMaSource parm)
        {
            var response = Insert(parm, it => new
            {
                it.Guid,
                it.DSapZpabdZ001,
                it.DSapZpabdZ002,
                it.DSapZpabdZ003,
                it.DSapZpabdZ004,
                it.DSapZpabdZ005,
                it.DSapZpabdZ006,
                it.DSapZpabdZ007,
                it.DSapZpabdZ008,
                it.DSapZpabdZ009,
                it.DSapZpabdZ010,
                it.DSapZpabdZ011,
                it.DSapZpabdZ012,
                it.DSapZpabdZ013,
                it.DSapZpabdZ014,
                it.DSapZpabdZ015,
                it.DSapZpabdZ016,
                it.DSapZpabdZ017,
                it.DSapZpabdZ018,
                it.DSapZpabdZ019,
                it.DSapZpabdZ020,
                it.DSapZpabdZ021,
                it.DSapZpabdZ022,
                it.DSapZpabdZ023,
                it.DSapZpabdZ024,
                it.DSapZpabdZ025,
                it.DSapZpabdZ026,
                it.DSapZpabdZ027,
                it.IsSolved,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcMaSource(PpEcMaSource parm)
        {
            var response = Update(w => w.Guid == parm.Guid, it => new PpEcMaSource()
            {
                DSapZpabdZ001 = parm.DSapZpabdZ001,
                DSapZpabdZ002 = parm.DSapZpabdZ002,
                DSapZpabdZ003 = parm.DSapZpabdZ003,
                DSapZpabdZ004 = parm.DSapZpabdZ004,
                DSapZpabdZ005 = parm.DSapZpabdZ005,
                DSapZpabdZ006 = parm.DSapZpabdZ006,
                DSapZpabdZ007 = parm.DSapZpabdZ007,
                DSapZpabdZ008 = parm.DSapZpabdZ008,
                DSapZpabdZ009 = parm.DSapZpabdZ009,
                DSapZpabdZ010 = parm.DSapZpabdZ010,
                DSapZpabdZ011 = parm.DSapZpabdZ011,
                DSapZpabdZ012 = parm.DSapZpabdZ012,
                DSapZpabdZ013 = parm.DSapZpabdZ013,
                DSapZpabdZ014 = parm.DSapZpabdZ014,
                DSapZpabdZ015 = parm.DSapZpabdZ015,
                DSapZpabdZ016 = parm.DSapZpabdZ016,
                DSapZpabdZ017 = parm.DSapZpabdZ017,
                DSapZpabdZ018 = parm.DSapZpabdZ018,
                DSapZpabdZ019 = parm.DSapZpabdZ019,
                DSapZpabdZ020 = parm.DSapZpabdZ020,
                DSapZpabdZ021 = parm.DSapZpabdZ021,
                DSapZpabdZ022 = parm.DSapZpabdZ022,
                DSapZpabdZ023 = parm.DSapZpabdZ023,
                DSapZpabdZ024 = parm.DSapZpabdZ024,
                DSapZpabdZ025 = parm.DSapZpabdZ025,
                DSapZpabdZ026 = parm.DSapZpabdZ026,
                DSapZpabdZ027 = parm.DSapZpabdZ027,
                IsSolved = parm.IsSolved,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空主源设变
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcMaSource()
        {
            Truncate();
        }
        #endregion
    }
}