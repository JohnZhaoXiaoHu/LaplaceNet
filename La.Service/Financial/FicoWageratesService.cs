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
    /// 工厂工资率Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [AppService(ServiceType = typeof(IFicoWageratesService), ServiceLifetime = LifeTime.Transient)]
    public class FicoWageratesService : BaseService<FicoWagerates>, IFicoWageratesService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询工厂工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoWageratesDto> GetList(FicoWageratesQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoWagerates>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwYm), it => it.FwYm == parm.FwYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwPlant), it => it.FwPlant == parm.FwPlant);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoWagerates, FicoWageratesDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.FwYm+ it.FwPlant == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加工厂工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoWagerates(FicoWagerates parm)
        {
            var response = Insert(parm, it => new
            {
                it.FwYm,
                it.FwPlant,
                it.FwCcy,
                it.FwSalesVolume,
                it.FwWorkingDays,
                it.FwDirectWageRate,
                it.FwDirect,
                it.FwDirectOverTime,
                it.FwDirectWages,
                it.FwInDirectWageRate,
                it.FwInDirect,
                it.FwInDirectOverTime,
                it.FwInDirectWages,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改工厂工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoWagerates(FicoWagerates parm)
        {
            var response = Update(w => w.FwId == parm.FwId, it => new FicoWagerates()
            {
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空工厂工资率
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoWagerates()
        {
            Truncate();
        }
        #endregion
    }
}