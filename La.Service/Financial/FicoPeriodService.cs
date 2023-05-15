using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Financial.IFinancialService;
using System.Linq;

namespace La.Service.Financial
{
    /// <summary>
    /// 财务期间Service业务层处理
    ///
    /// @author Davis.Ching
    /// @date 2023-05-15
    /// </summary>
    [AppService(ServiceType = typeof(IFicoPeriodService), ServiceLifetime = LifeTime.Transient)]
    public class FicoPeriodService : BaseService<FicoPeriod>, IFicoPeriodService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoPeriodDto> GetList(FicoPeriodQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoPeriod>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYm), it => it.FpYm.Contains(parm.FpYm));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoPeriod, FicoPeriodDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.FpId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoPeriod(FicoPeriod parm)
        {
            var response = Insert(parm, it => new
            {
                it.FpFy,
                it.FpYm,
                it.FpYear,
                it.FpMonth,
                it.FpQuarter,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoPeriod(FicoPeriod parm)
        {
            var response = Update(w => w.FpId == parm.FpId, it => new FicoPeriod()
            {
                FpFy = parm.FpFy,
                FpYm = parm.FpYm,
                FpYear = parm.FpYear,
                FpMonth = parm.FpMonth,
                FpQuarter = parm.FpQuarter,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空财务期间
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoPeriod()
        {
            Truncate();
        }
        #endregion
    }
}