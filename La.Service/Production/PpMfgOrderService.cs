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
    /// 生产工单Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IPpMfgOrderService), ServiceLifetime = LifeTime.Transient)]
    public class PpMfgOrderService : BaseService<PpMfgOrder>, IPpMfgOrderService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMfgOrderDto> GetList(PpMfgOrderQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpMfgOrder>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoPlant), it => it.MoPlant == parm.MoPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderType), it => it.MoOrderType == parm.MoOrderType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderNo), it => it.MoOrderNo.Contains(parm.MoOrderNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderItem), it => it.MoOrderItem.Contains(parm.MoOrderItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderlot), it => it.MoOrderlot.Contains(parm.MoOrderlot));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpMfgOrder, PpMfgOrderDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.MoId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpMfgOrder(PpMfgOrder parm)
        {
            var response = Insert(parm, it => new
            {
                it.MoPlant,
                it.MoOrderType,
                it.MoOrderNo,
                it.MoOrderItem,
                it.MoOrderlot,
                it.MoOrderQty,
                it.MoOrderProQty,
                it.MoOrderDate,
                it.MoOrderRoute,
                it.MoOrderSerial,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpMfgOrder(PpMfgOrder parm)
        {
            var response = Update(w => w.MoId == parm.MoId, it => new PpMfgOrder()
            {
                MoOrderQty = parm.MoOrderQty,
                MoOrderProQty = parm.MoOrderProQty,
                MoOrderDate = parm.MoOrderDate,
                MoOrderRoute = parm.MoOrderRoute,
                MoOrderSerial = parm.MoOrderSerial,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空生产工单
        /// </summary>
        /// <returns></returns>
        public void TruncatePpMfgOrder()
        {
            Truncate();
        }
        #endregion
    }
}