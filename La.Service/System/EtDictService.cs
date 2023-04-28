using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.System.ISystemService;
using System.Linq;

namespace La.Service.System
{
    /// <summary>
    /// 电子辞典Service业务层处理
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [AppService(ServiceType = typeof(IEtDictService), ServiceLifetime = LifeTime.Transient)]
    public class EtDictService : BaseService<EtDict>, IEtDictService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询电子辞典列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EtDictDto> GetList(EtDictQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<EtDict>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtType), it => it.EtType == parm.EtType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtLetter), it => it.EtLetter.Contains(parm.EtLetter));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtArea), it => it.EtArea == parm.EtArea);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<EtDict, EtDictDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.EtGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加电子辞典
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddEtDict(EtDict parm)
        {
            var response = Insert(parm, it => new
            {
                it.EtType,
                it.EtLetter,
                it.EtLangKey,
                it.EtPhrase,
                it.EtExplain,
                it.EtArea,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改电子辞典
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateEtDict(EtDict parm)
        {
            var response = Update(w => w.EtGuid == parm.EtGuid, it => new EtDict()
            {
                EtType = parm.EtType,
                EtLetter = parm.EtLetter,
                EtLangKey = parm.EtLangKey,
                EtPhrase = parm.EtPhrase,
                EtExplain = parm.EtExplain,
                EtArea = parm.EtArea,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空电子辞典
        /// </summary>
        /// <returns></returns>
        public void TruncateEtDict()
        {
            Truncate();
        }
        #endregion
    }
}