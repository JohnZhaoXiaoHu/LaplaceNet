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
using System.Collections.Generic;

namespace La.Service.System
{
    /// <summary>
    /// 电子技术辞典Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-10
    /// </summary>
    [AppService(ServiceType = typeof(IEtDictService), ServiceLifetime = LifeTime.Transient)]
    public class EtDictService : BaseService<EtDict>, IEtDictService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询电子技术辞典列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EtDictDto> GetList(EtDictQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<EtDict>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtLangcode), it => it.EtLangcode.Contains(parm.EtLangcode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtPhrase), it => it.EtPhrase.Contains(parm.EtPhrase));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtExplain), it => it.EtExplain.Contains(parm.EtExplain));
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
            int count = Count(it => it.Id.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }
        /// <summary>
        /// 行转列
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetListToPivot(EtDictQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<EtDict>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtLangcode), it => it.EtLangcode.Contains(parm.EtLangcode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtPhrase), it => it.EtPhrase.Contains(parm.EtPhrase));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtExplain), it => it.EtExplain.Contains(parm.EtExplain));
            var response = Queryable()
                
                .Where(predicate.ToExpression())

                .ToPivotList(it => it.EtLangcode, it => it.EtPhrase, it => it.Max(f => f.EtExplain));


                
            return response;
        }

        public List<EtDict> GetSysEtDictList(EtDictQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<EtDict>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtLangcode), it => it.EtLangcode == parm.EtLangcode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EtPhrase), it => it.EtPhrase.Contains(parm.EtPhrase));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();
            return response;
        }

        public void StorageSysEtDict(EtDictDto parm)
        {
            List<EtDict> langs = new();
            foreach (var item in parm.EtDictList)
            {
                langs.Add(new EtDict()
                {
                    CreateTime = DateTime.Now,
                    EtPhrase = parm.EtPhrase,
                    EtLangcode = item.EtLangcode,
                    EtExplain = item.EtExplain,
                });
            }
            var storage = Storageable(langs)
                .WhereColumns(it => new { it.EtPhrase, it.EtLangcode })
                .ToStorage();

            storage.AsInsertable.ExecuteReturnSnowflakeIdList();//执行插入
            storage.AsUpdateable.UpdateColumns(it => new { it.EtExplain }).ExecuteCommand();//执行修改
        }

        public Dictionary<string, object> SetSysEtDict(List<EtDict> msgList)
        {
            Dictionary<string, object> dic = new();

            foreach (var item in msgList)
            {
                if (!dic.ContainsKey(item.EtPhrase))
                {
                    dic.Add(item.EtPhrase, item.EtExplain);
                }
            }
            return dic;
        }
        /// <summary>
        /// 添加电子技术辞典
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddSysEtDict(EtDict parm)
        {
            var response = Insert(parm, it => new
            {
                it.EtLetter,
                it.EtLangcode,
                it.EtPhrase,
                it.EtExplain,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改电子技术辞典
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateSysEtDict(EtDict parm)
        {
            var response = Update(w => w.Id == parm.Id, it => new EtDict()
            {
                EtLetter = parm.EtLetter,
                EtLangcode = parm.EtLangcode,
                EtPhrase = parm.EtPhrase,
                EtExplain = parm.EtExplain,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空电子技术辞典
        /// </summary>
        /// <returns></returns>
        public void TruncateSysEtDict()
        {
            Truncate();
        }
        #endregion
    }
}