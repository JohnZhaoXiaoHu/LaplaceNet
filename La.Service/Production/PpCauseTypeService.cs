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
    /// 原因类别Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IPpCauseTypeService), ServiceLifetime = LifeTime.Transient)]
    public class PpCauseTypeService : BaseService<PpCauseType>, IPpCauseTypeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpCauseTypeDto> GetList(PpCauseTypeQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpCauseType>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CtCauseType), it => it.CtCauseType == parm.CtCauseType);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpCauseType, PpCauseTypeDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.CtId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpCauseType(PpCauseType parm)
        {
            var response = Insert(parm, it => new
            {
                it.CtCauseType,
                it.CtcausetextZh,
                it.CtcausetextEn,
                it.CtcausetextJa,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpCauseType(PpCauseType parm)
        {
            var response = Update(w => w.CtId == parm.CtId, it => new PpCauseType()
            {
                CtcausetextZh = parm.CtcausetextZh,
                CtcausetextEn = parm.CtcausetextEn,
                CtcausetextJa = parm.CtcausetextJa,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空原因类别
        /// </summary>
        /// <returns></returns>
        public void TruncatePpCauseType()
        {
            Truncate();
        }
        #endregion
    }
}