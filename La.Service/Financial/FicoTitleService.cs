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
    /// 会计科目Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IFicoTitleService), ServiceLifetime = LifeTime.Transient)]
    public class FicoTitleService : BaseService<FicoTitle>, IFicoTitleService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoTitleDto> GetList(FicoTitleQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<FicoTitle>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtCorpCode), it => it.FtCorpCode == parm.FtCorpCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtTitleCode), it => it.FtTitleCode.Contains(parm.FtTitleCode));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoTitle, FicoTitleDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.FtId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddFicoTitle(FicoTitle parm)
        {
            var response = Insert(parm, it => new
            {
                it.FtCorpCode,
                it.FtTitleCode,
                it.FttitlenameZh,
                it.FttitlenameEn,
                it.FttitlenameJa,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateFicoTitle(FicoTitle parm)
        {
            var response = Update(w => w.FtId == parm.FtId, it => new FicoTitle()
            {
                FtCorpCode = parm.FtCorpCode,
                FtTitleCode = parm.FtTitleCode,
                FttitlenameZh = parm.FttitlenameZh,
                FttitlenameEn = parm.FttitlenameEn,
                FttitlenameJa = parm.FttitlenameJa,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空会计科目
        /// </summary>
        /// <returns></returns>
        public void TruncateFicoTitle()
        {
            Truncate();
        }
        #endregion
    }
}