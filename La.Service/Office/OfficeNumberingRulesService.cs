using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Office.IOfficeService;
using System.Linq;

namespace La.Service.Office
{
    /// <summary>
    /// 单据编码Service业务层处理
    ///
    /// @author Davis.Ching
    /// @date 2023-05-16
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeNumberingRulesService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeNumberingRulesService : BaseService<OfficeNumberingRules>, IOfficeNumberingRulesService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询单据编码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeNumberingRulesDto> GetList(OfficeNumberingRulesQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<OfficeNumberingRules>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefModule), it => it.RefModule == parm.RefModule);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefCategory), it => it.RefCategory == parm.RefCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefName), it => it.RefName.Contains(parm.RefName));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<OfficeNumberingRules, OfficeNumberingRulesDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.RefId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加单据编码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddOfficeNumberingRules(OfficeNumberingRules parm)
        {
            var response = Insert(parm, it => new
            {
                it.RefModule,
                it.RefCategory,
                it.RefCode,
                it.RefName,
                it.RefPattern,
                it.RefPrefix,
                it.RefLenth,
                it.InitNumber,
                it.IsoNumber,
                it.Status,
                it.Sort,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改单据编码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateOfficeNumberingRules(OfficeNumberingRules parm)
        {
            var response = Update(w => w.RefId == parm.RefId, it => new OfficeNumberingRules()
            {
                RefModule = parm.RefModule,
                RefCategory = parm.RefCategory,
                RefCode = parm.RefCode,
                RefName = parm.RefName,
                RefPattern = parm.RefPattern,
                RefPrefix = parm.RefPrefix,
                RefLenth = parm.RefLenth,
                InitNumber = parm.InitNumber,
                IsoNumber = parm.IsoNumber,
                Status = parm.Status,
                Sort = parm.Sort,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空单据编码
        /// </summary>
        /// <returns></returns>
        public void TruncateOfficeNumberingRules()
        {
            Truncate();
        }
        #endregion
    }
}