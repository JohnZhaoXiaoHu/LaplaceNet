using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Sales.ISalesService;
using System.Linq;

namespace La.Service.Sales
{
    /// <summary>
    /// 销售价格Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [AppService(ServiceType = typeof(ISdSellingpriceService), ServiceLifetime = LifeTime.Transient)]
    public class SdSellingpriceService : BaseService<SdSellingprice>, ISdSellingpriceService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询销售价格列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSellingpriceDto> GetList(SdSellingpriceQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<SdSellingprice>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpPlnt), it => it.SpPlnt == parm.SpPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpYm), it => it.SpYm == parm.SpYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpItem), it => it.SpItem == parm.SpItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpItemText), it => it.SpItemText.Contains(parm.SpItemText));
            predicate = predicate.AndIF(parm.BeginSpEffDate == null, it => it.SpEffDate >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginSpEffDate != null, it => it.SpEffDate >= parm.BeginSpEffDate && it.SpEffDate <= parm.EndSpEffDate);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdSellingprice, SdSellingpriceDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.SpId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSdSellingprice(SdSellingprice parm)
        {
            var response = Insert(parm, it => new
            {
                it.SpPlnt,
                it.SpFy,
                it.SpYm,
                it.SpItem,
                it.SpItemText,
                it.SpOriginalFob,
                it.SpOriginalCcy,
                it.SpOriginalPerUnit,
                it.SpOriginalPrctr,
                it.SpLocalFob,
                it.SpLocalCcy,
                it.SpLocalPerUnit,
                it.SpLocalPrctr,
                it.SpEffDate,
                it.SpExpDate,
                it.SpBalancedate,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSdSellingprice(SdSellingprice parm)
        {
            var response = Update(w => w.SpId == parm.SpId, it => new SdSellingprice()
            {
                SpPlnt = parm.SpPlnt,
                SpFy = parm.SpFy,
                SpYm = parm.SpYm,
                SpItem = parm.SpItem,
                SpItemText = parm.SpItemText,
                SpOriginalFob = parm.SpOriginalFob,
                SpOriginalCcy = parm.SpOriginalCcy,
                SpOriginalPerUnit = parm.SpOriginalPerUnit,
                SpOriginalPrctr = parm.SpOriginalPrctr,
                SpLocalFob = parm.SpLocalFob,
                SpLocalCcy = parm.SpLocalCcy,
                SpLocalPerUnit = parm.SpLocalPerUnit,
                SpLocalPrctr = parm.SpLocalPrctr,
                SpEffDate = parm.SpEffDate,
                SpExpDate = parm.SpExpDate,
                SpBalancedate = parm.SpBalancedate,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空销售价格
        /// </summary>
        /// <returns></returns>
        public void TruncateSdSellingprice()
        {
            Truncate();
        }
        #endregion
    }
}