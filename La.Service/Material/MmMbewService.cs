using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Material.IMaterialService;
using System.Linq;

namespace La.Service.Material
{
    /// <summary>
    /// 物料评估Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IMmMbewService), ServiceLifetime = LifeTime.Transient)]
    public class MmMbewService : BaseService<MmMbew>, IMmMbewService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMbewDto> GetList(MmMbewQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<MmMbew>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMbew, MmMbewDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.MbewID.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddMmMbew(MmMbew parm)
        {
            var response = Insert(parm, it => new
            {
                it.MbewID,
                it.MbewABCIW,
                it.MbewABWKZ,
                it.MbewBKLAS,
                it.MbewBWKEY,
                it.MbewBWPEI,
                it.MbewBWPH1,
                it.MbewBWPRH,
                it.MbewBWPRS,
                it.MbewBWPS1,
                it.MbewBWSPA,
                it.MbewBWTAR,
                it.MbewBWTTY,
                it.MbewBWVA1,
                it.MbewBWVA2,
                it.MbewBWVA3,
                it.MbewEKALR,
                it.MbewEKLAS,
                it.MbewFBWST,
                it.MbewFPLPX,
                it.MbewHKMAT,
                it.MbewHRKFT,
                it.MbewKALKL,
                it.MbewKALKV,
                it.MbewKALKZ,
                it.MbewKALN1,
                it.MbewKALNR,
                it.MbewKALSC,
                it.MbewKOSGR,
                it.MbewKZIWL,
                it.MbewLAEPR,
                it.MbewLBKUM,
                it.MbewLBWST,
                it.MbewLFGJA,
                it.MbewLFMON,
                it.MbewLPLPR,
                it.MbewLPLPX,
                it.MbewLVORM,
                it.MbewMANDT,
                it.MbewMATNR,
                it.MbewMBRUE,
                it.MbewMLAST,
                it.MbewMLMAA,
                it.MbewMTORG,
                it.MbewMTUSE,
                it.MbewMYPOL,
                it.MbewOIPPINV,
                it.MbewOKLAS,
                it.MbewOWNPR,
                it.MbewPDATL,
                it.MbewPDATV,
                it.MbewPDATZ,
                it.MbewPEINH,
                it.MbewPPERL,
                it.MbewPPERV,
                it.MbewPPERZ,
                it.MbewPPRDL,
                it.MbewPPRDV,
                it.MbewPPRDZ,
                it.MbewPSTAT,
                it.MbewQKLAS,
                it.MbewSALK3,
                it.MbewSALKV,
                it.MbewSPERW,
                it.MbewSTPRS,
                it.MbewSTPRV,
                it.MbewTIMESTAMP,
                it.MbewVBWST,
                it.MbewVERPR,
                it.MbewVERS1,
                it.MbewVERS2,
                it.MbewVERS3,
                it.MbewVJBKL,
                it.MbewVJBWH,
                it.MbewVJBWS,
                it.MbewVJKUM,
                it.MbewVJPEI,
                it.MbewVJSAL,
                it.MbewVJSAV,
                it.MbewVJSTP,
                it.MbewVJVER,
                it.MbewVJVPR,
                it.MbewVKSAL,
                it.MbewVMBKL,
                it.MbewVMKUM,
                it.MbewVMPEI,
                it.MbewVMSAL,
                it.MbewVMSAV,
                it.MbewVMSTP,
                it.MbewVMVER,
                it.MbewVMVPR,
                it.MbewVPLPR,
                it.MbewVPLPX,
                it.MbewVPRSV,
                it.MbewVVJLB,
                it.MbewVVJSL,
                it.MbewVVMLB,
                it.MbewVVSAL,
                it.MbewWLINL,
                it.MbewXBEWM,
                it.MbewXLIFO,
                it.MbewZKDAT,
                it.MbewZKPRS,
                it.MbewZPLD1,
                it.MbewZPLD2,
                it.MbewZPLD3,
                it.MbewZPLP1,
                it.MbewZPLP2,
                it.MbewZPLP3,
                it.MbewZPLPR,
                it.Remark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateMmMbew(MmMbew parm)
        {
            var response = Update(w => w.MbewID == parm.MbewID, it => new MmMbew()
            {
                MbewABCIW = parm.MbewABCIW,
                MbewABWKZ = parm.MbewABWKZ,
                MbewBWPEI = parm.MbewBWPEI,
                MbewBWPH1 = parm.MbewBWPH1,
                MbewBWPRH = parm.MbewBWPRH,
                MbewBWPRS = parm.MbewBWPRS,
                MbewBWPS1 = parm.MbewBWPS1,
                MbewBWSPA = parm.MbewBWSPA,
                MbewBWTAR = parm.MbewBWTAR,
                MbewBWTTY = parm.MbewBWTTY,
                MbewBWVA1 = parm.MbewBWVA1,
                MbewBWVA2 = parm.MbewBWVA2,
                MbewBWVA3 = parm.MbewBWVA3,
                MbewEKALR = parm.MbewEKALR,
                MbewEKLAS = parm.MbewEKLAS,
                MbewFBWST = parm.MbewFBWST,
                MbewFPLPX = parm.MbewFPLPX,
                MbewHKMAT = parm.MbewHKMAT,
                MbewHRKFT = parm.MbewHRKFT,
                MbewKALKL = parm.MbewKALKL,
                MbewKALKV = parm.MbewKALKV,
                MbewKALKZ = parm.MbewKALKZ,
                MbewKALN1 = parm.MbewKALN1,
                MbewKALNR = parm.MbewKALNR,
                MbewKALSC = parm.MbewKALSC,
                MbewKOSGR = parm.MbewKOSGR,
                MbewKZIWL = parm.MbewKZIWL,
                MbewLAEPR = parm.MbewLAEPR,
                MbewLBKUM = parm.MbewLBKUM,
                MbewLBWST = parm.MbewLBWST,
                MbewLFGJA = parm.MbewLFGJA,
                MbewLFMON = parm.MbewLFMON,
                MbewLPLPR = parm.MbewLPLPR,
                MbewLPLPX = parm.MbewLPLPX,
                MbewLVORM = parm.MbewLVORM,
                MbewMANDT = parm.MbewMANDT,
                MbewMBRUE = parm.MbewMBRUE,
                MbewMLAST = parm.MbewMLAST,
                MbewMLMAA = parm.MbewMLMAA,
                MbewMTORG = parm.MbewMTORG,
                MbewMTUSE = parm.MbewMTUSE,
                MbewMYPOL = parm.MbewMYPOL,
                MbewOIPPINV = parm.MbewOIPPINV,
                MbewOKLAS = parm.MbewOKLAS,
                MbewOWNPR = parm.MbewOWNPR,
                MbewPDATL = parm.MbewPDATL,
                MbewPDATV = parm.MbewPDATV,
                MbewPDATZ = parm.MbewPDATZ,
                MbewPEINH = parm.MbewPEINH,
                MbewPPERL = parm.MbewPPERL,
                MbewPPERV = parm.MbewPPERV,
                MbewPPERZ = parm.MbewPPERZ,
                MbewPPRDL = parm.MbewPPRDL,
                MbewPPRDV = parm.MbewPPRDV,
                MbewPPRDZ = parm.MbewPPRDZ,
                MbewPSTAT = parm.MbewPSTAT,
                MbewQKLAS = parm.MbewQKLAS,
                MbewSALK3 = parm.MbewSALK3,
                MbewSALKV = parm.MbewSALKV,
                MbewSPERW = parm.MbewSPERW,
                MbewSTPRS = parm.MbewSTPRS,
                MbewSTPRV = parm.MbewSTPRV,
                MbewTIMESTAMP = parm.MbewTIMESTAMP,
                MbewVBWST = parm.MbewVBWST,
                MbewVERPR = parm.MbewVERPR,
                MbewVERS1 = parm.MbewVERS1,
                MbewVERS2 = parm.MbewVERS2,
                MbewVERS3 = parm.MbewVERS3,
                MbewVJBKL = parm.MbewVJBKL,
                MbewVJBWH = parm.MbewVJBWH,
                MbewVJBWS = parm.MbewVJBWS,
                MbewVJKUM = parm.MbewVJKUM,
                MbewVJPEI = parm.MbewVJPEI,
                MbewVJSAL = parm.MbewVJSAL,
                MbewVJSAV = parm.MbewVJSAV,
                MbewVJSTP = parm.MbewVJSTP,
                MbewVJVER = parm.MbewVJVER,
                MbewVJVPR = parm.MbewVJVPR,
                MbewVKSAL = parm.MbewVKSAL,
                MbewVMBKL = parm.MbewVMBKL,
                MbewVMKUM = parm.MbewVMKUM,
                MbewVMPEI = parm.MbewVMPEI,
                MbewVMSAL = parm.MbewVMSAL,
                MbewVMSAV = parm.MbewVMSAV,
                MbewVMSTP = parm.MbewVMSTP,
                MbewVMVER = parm.MbewVMVER,
                MbewVMVPR = parm.MbewVMVPR,
                MbewVPLPR = parm.MbewVPLPR,
                MbewVPLPX = parm.MbewVPLPX,
                MbewVPRSV = parm.MbewVPRSV,
                MbewVVJLB = parm.MbewVVJLB,
                MbewVVJSL = parm.MbewVVJSL,
                MbewVVMLB = parm.MbewVVMLB,
                MbewVVSAL = parm.MbewVVSAL,
                MbewWLINL = parm.MbewWLINL,
                MbewXBEWM = parm.MbewXBEWM,
                MbewXLIFO = parm.MbewXLIFO,
                MbewZKDAT = parm.MbewZKDAT,
                MbewZKPRS = parm.MbewZKPRS,
                MbewZPLD1 = parm.MbewZPLD1,
                MbewZPLD2 = parm.MbewZPLD2,
                MbewZPLD3 = parm.MbewZPLD3,
                MbewZPLP1 = parm.MbewZPLP1,
                MbewZPLP2 = parm.MbewZPLP2,
                MbewZPLP3 = parm.MbewZPLP3,
                MbewZPLPR = parm.MbewZPLPR,
                Remark = parm.Remark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空物料评估
        /// </summary>
        /// <returns></returns>
        public void TruncateMmMbew()
        {
            Truncate();
        }
        #endregion
    }
}