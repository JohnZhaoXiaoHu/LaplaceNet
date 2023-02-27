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
    /// 生产班组Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-25
    /// </summary>
    [AppService(ServiceType = typeof(IPpLinesService), ServiceLifetime = LifeTime.Transient)]
    public class PpLinesService : BaseService<PpLines>, IPpLinesService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpLinesDto> GetList(PpLinesQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpLines>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PlLineType), it => it.PlLineType == parm.PlLineType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PlLineCode), it => it.PlLineCode.Contains(parm.PlLineCode));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpLines, PpLinesDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.PlLineCode.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpLines(PpLines parm)
        {
            var response = Insert(parm, it => new
            {
                it.PlLineType,
                it.PlLineCode,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
                it.PlLineName,
            });
            return response;
        }

        /// <summary>
        /// 修改生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpLines(PpLines parm)
        {
            var response = Update(w => w.PlId == parm.PlId, it => new PpLines()
            {
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
                PlLineName = parm.PlLineName,
            });
            return response;
        }

        /// <summary>
        /// 清空生产班组
        /// </summary>
        /// <returns></returns>
        public void TruncatePpLines()
        {
            Truncate();
        }
        #endregion
    }
}