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
using Aliyun.OSS;

namespace La.Service.Financial
{
    /// <summary>
    /// 汇率表Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [AppService(ServiceType = typeof(IFicoExchangeRateService), ServiceLifetime = LifeTime.Transient)]
    public class FicoExchangeRateService : BaseService<FicoExchangeRate>, IFicoExchangeRateService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoExchangeRate>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.BeginErEffDate == null, it => it.ErEffDate >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginErEffDate != null, it => it.ErEffDate >= parm.BeginErEffDate && it.ErEffDate <= parm.EndErEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ErfmCcy), it => it.ErfmCcy == parm.ErfmCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ErtoCcy), it => it.ErtoCcy == parm.ErtoCcy);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoExchangeRate, FicoExchangeRateDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
           
            int count = Count(it => Convert.ToDateTime(it.ErEffDate).ToString("yyyyMMdd") + it.ErfmCcy + it.ErtoCcy == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoExchangeRate(FicoExchangeRate parm)
        {
            var response = Insert(parm, it => new
            {
                it.ErEffDate,
                it.ErStd,
                it.ErfmCcy,
                it.ErRate,
                it.ErtoCcy,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoExchangeRate(FicoExchangeRate parm)
        {
            var response = Update(w => w.ErId == parm.ErId, it => new FicoExchangeRate()
            {
                ErEffDate = parm.ErEffDate,
                ErStd = parm.ErStd,
                ErfmCcy = parm.ErfmCcy,
                ErRate = parm.ErRate,
                ErtoCcy = parm.ErtoCcy,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空汇率表
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoExchangeRate()
        {
            Truncate();
        }
        #endregion
    }
}