using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Quality.IQualityService;
using System.Linq;

namespace La.Service.Quality
{
    /// <summary>
    /// 抽样标准Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-15
    /// </summary>
    [AppService(ServiceType = typeof(IQmCheckAqlService), ServiceLifetime = LifeTime.Transient)]
    public class QmCheckAqlService : BaseService<QmCheckAql>, IQmCheckAqlService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCheckAqlDto> GetList(QmCheckAqlQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<QmCheckAql>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmCheckAql, QmCheckAqlDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.QcaqlGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddQmCheckAql(QmCheckAql parm)
        {
            var response = Insert(parm, it => new
            {
                it.QcaqlGuid,
                it.QcaqlLevel,
                it.QcaqlRange,
                it.QcaqlRangeMinmum,
                it.QcaqlRangeMaximum,
                it.QcaqlSamplesCode,
                it.QcaqlSamplesQty,
                it.QcaqlAcQty,
                it.QcaqlReQty,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateQmCheckAql(QmCheckAql parm)
        {
            var response = Update(w => w.QcaqlGuid == parm.QcaqlGuid, it => new QmCheckAql()
            {
                QcaqlLevel = parm.QcaqlLevel,
                QcaqlRange = parm.QcaqlRange,
                QcaqlRangeMinmum = parm.QcaqlRangeMinmum,
                QcaqlRangeMaximum = parm.QcaqlRangeMaximum,
                QcaqlSamplesCode = parm.QcaqlSamplesCode,
                QcaqlSamplesQty = parm.QcaqlSamplesQty,
                QcaqlAcQty = parm.QcaqlAcQty,
                QcaqlReQty = parm.QcaqlReQty,
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空抽样标准
        /// </summary>
        /// <returns></returns>
        public void TruncateQmCheckAql()
        {
            Truncate();
        }
        #endregion
    }
}