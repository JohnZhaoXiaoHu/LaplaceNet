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
    /// 利润中心Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [AppService(ServiceType = typeof(IFicoPrctrService), ServiceLifetime = LifeTime.Transient)]
    public class FicoPrctrService : BaseService<FicoPrctr>, IFicoPrctrService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoPrctrDto> GetList(FicoPrctrQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoPrctr>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpPlnt), it => it.FpPlnt == parm.FpPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpCode), it => it.FpCode.Contains(parm.FpCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpName), it => it.FpName.Contains(parm.FpName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpType), it => it.FpType == parm.FpType);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoPrctr, FicoPrctrDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.FpPlnt+ it.FpCode == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoPrctr(FicoPrctr parm)
        {
            var response = Insert(parm, it => new
            {
                it.FpPlnt,
                it.FpCode,
                it.FpName,
                it.FpType,
                it.FpActDate,
                it.FpExpDate,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoPrctr(FicoPrctr parm)
        {
            var response = Update(w => w.FpId == parm.FpId, it => new FicoPrctr()
            {
                FpName = parm.FpName,
                FpType = parm.FpType,
                FpActDate = parm.FpActDate,
                FpExpDate = parm.FpExpDate,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空利润中心
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoPrctr()
        {
            Truncate();
        }
        #endregion
    }
}