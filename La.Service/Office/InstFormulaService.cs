using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Infra.Extensions;
using La.Model;
using La.Model.System;
using La.Model.Dto;
using La.Model.Office;
using La.Repository;
using La.Service.Office.IOfficeService;
using System.Linq;

namespace La.Service.Office
{
    /// <summary>
    /// 计算公式
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [AppService(ServiceType = typeof(IInstFormulaService), ServiceLifetime = LifeTime.Transient)]
    public class InstFormulaService : BaseService<InstFormula>, IInstFormulaService
    {
        /// <summary>
        /// 查询计算公式列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstFormulaDto> GetList(InstFormulaQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<InstFormula>();

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InstFormula, InstFormulaDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.IfGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        public InstFormula GetInfo(string IfGuid)
        {
            var response = Queryable()
                .Where(x => x.IfGuid == IfGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加
        /// 计算公式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddInstFormula(InstFormula model)
        {
            return Add(model, true);
        }

        /// <summary>
        /// 修改编辑
        /// 计算公式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstFormula(InstFormula model)
        {
            //var response = Update(w => w.IfGuid == model.IfGuid, it => new InstFormula()
            //{
            //    IfType = model.IfType,
            //    IfLangKey = model.IfLangKey,
            //    IfFormula = model.IfFormula,
            //    Remark = model.Remark,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }
        /// <summary>
        /// 清空
        /// 计算公式
        /// </summary>
        /// <returns></returns>
        public bool TruncateInstFormula()
        {
            var newTableName = $"inst_formula_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("inst_formula", newTableName);
            }
            
            return Truncate();
        }
    }
}