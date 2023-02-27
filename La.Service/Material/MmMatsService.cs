using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Material.IMaterialService;
using System.Linq;

namespace La.Service.Material
{
    /// <summary>
    /// 物料信息Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-25
    /// </summary>
    [AppService(ServiceType = typeof(IMmMatsService), ServiceLifetime = LifeTime.Transient)]
    public class MmMatsService : BaseService<MmMats>, IMmMatsService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMatsDto> GetList(MmMatsQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<MmMats>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPlnt), it => it.MmPlnt == parm.MmPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem.Contains(parm.MmMatItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmIndustry), it => it.MmIndustry == parm.MmIndustry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatType), it => it.MmMatType == parm.MmMatType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmBaseUnit), it => it.MmBaseUnit == parm.MmBaseUnit);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatGroup), it => it.MmMatGroup == parm.MmMatGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurGroup), it => it.MmPurGroup == parm.MmPurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurType), it => it.MmPurType == parm.MmPurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmProfitCenter), it => it.MmProfitCenter == parm.MmProfitCenter);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmValType), it => it.MmValType == parm.MmValType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmCcy), it => it.MmCcy == parm.MmCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmSLoc), it => it.MmSLoc == parm.MmSLoc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLocPosn), it => it.MmLocPosn.Contains(parm.MmLocPosn));
            var response = Queryable()
                //.OrderBy("MmMatItem asc")
                .Where(predicate.ToExpression())
                .ToPage<MmMats, MmMatsDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.MmPlnt+ it.MmMatItem == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddMmMats(MmMats parm)
        {
            var response = Insert(parm, it => new
            {
                it.MmLastDate,
                it.MmPlnt,
                it.MmMatItem,
                it.MmIndustry,
                it.MmMatType,
                it.MmMatDes,
                it.MmBaseUnit,
                it.MmProLevel,
                it.MmMatGroup,
                it.MmPurGroup,
                it.MmPurType,
                it.MmSpecType,
                it.MmBulkMat,
                it.MmMoq,
                it.MmRoundingVal,
                it.MmLeadTime,
                it.MmProDays,
                it.MmisChecked,
                it.MmProfitCenter,
                it.MmDiffCode,
                it.MmisLot,
                it.MmMpn,
                it.MmMfrs,
                it.MmValType,
                it.MmMovingAvg,
                it.MmCcy,
                it.MmPriceControl,
                it.MmPriceUnit,
                it.MmSLoc,
                it.MmESLoc,
                it.MmLocPosn,
                it.MmInventory,
                it.MmLocEol,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateMmMats(MmMats parm)
        {
            var response = Update(w => w.MmId == parm.MmId, it => new MmMats()
            {
                MmLastDate = parm.MmLastDate,
                MmMatDes = parm.MmMatDes,
                MmProLevel = parm.MmProLevel,
                MmMatGroup = parm.MmMatGroup,
                MmPurGroup = parm.MmPurGroup,
                MmPurType = parm.MmPurType,
                MmSpecType = parm.MmSpecType,
                MmBulkMat = parm.MmBulkMat,
                MmMoq = parm.MmMoq,
                MmRoundingVal = parm.MmRoundingVal,
                MmLeadTime = parm.MmLeadTime,
                MmProDays = parm.MmProDays,
                MmisChecked = parm.MmisChecked,
                MmProfitCenter = parm.MmProfitCenter,
                MmDiffCode = parm.MmDiffCode,
                MmisLot = parm.MmisLot,
                MmMpn = parm.MmMpn,
                MmMfrs = parm.MmMfrs,
                MmValType = parm.MmValType,
                MmMovingAvg = parm.MmMovingAvg,
                MmCcy = parm.MmCcy,
                MmPriceControl = parm.MmPriceControl,
                MmPriceUnit = parm.MmPriceUnit,
                MmSLoc = parm.MmSLoc,
                MmESLoc = parm.MmESLoc,
                MmLocPosn = parm.MmLocPosn,
                MmInventory = parm.MmInventory,
                MmLocEol = parm.MmLocEol,
                ReMark = parm.ReMark,
            });
            return response;
        }

        /// <summary>
        /// 清空物料信息
        /// </summary>
        /// <returns></returns>
        public void TruncateMmMats()
        {
            Truncate();
        }
        #endregion
    }
}