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
    /// 标准工时Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IPpManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class PpManhoursService : BaseService<PpManhours>, IPpManhoursService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpManhoursDto> GetList(PpManhoursQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpManhours>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.BeginMhEffDate == null, it => it.MhEffDate >= DateTime.Now.AddDays(-1));
            predicate = predicate.AndIF(parm.BeginMhEffDate != null, it => it.MhEffDate >= parm.BeginMhEffDate && it.MhEffDate <= parm.EndMhEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhPlant), it => it.MhPlant == parm.MhPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhModelType), it => it.MhModelType == parm.MhModelType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhRegionType), it => it.MhRegionType == parm.MhRegionType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhItem), it => it.MhItem == parm.MhItem);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpManhours, PpManhoursDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.MhId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpManhours(PpManhours parm)
        {
            var response = Insert(parm, it => new
            {
                it.MhEffDate,
                it.MhPlant,
                it.MhModelType,
                it.MhRegionType,
                it.MhItem,
                it.MhItemText,
                it.MhWcName,
                it.MhWcText,
                it.MhStdShort,
                it.MhShortUnit,
                it.MhToMinRate,
                it.MhStdTime,
                it.MhTimeUnit,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpManhours(PpManhours parm)
        {
            var response = Update(w => w.MhId == parm.MhId, it => new PpManhours()
            {
                MhEffDate = parm.MhEffDate,
                MhStdShort = parm.MhStdShort,
                MhToMinRate = parm.MhToMinRate,
                MhStdTime = parm.MhStdTime,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空标准工时
        /// </summary>
        /// <returns></returns>
        public void TruncatePpManhours()
        {
            Truncate();
        }
        #endregion
    }
}