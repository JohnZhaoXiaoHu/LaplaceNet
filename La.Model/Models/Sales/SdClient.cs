
namespace La.Model.Sales
{
    /// <summary>
    /// 客户信息
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [SugarTable("sd_client")]
    public class SdClient
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long ScId { get; set; }

        /// <summary>
        /// 描述 :销售组织 
        /// 空值 :false 
        /// </summary>
        public string ScOrg { get; set; }

        /// <summary>
        /// 描述 :销售工厂 
        /// 空值 :false 
        /// </summary>
        public string ScPlant { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// 空值 :false 
        /// </summary>
        public string ScIndustryType { get; set; }

        /// <summary>
        /// 描述 :企业性质 
        /// 空值 :false 
        /// </summary>
        public string ScEnterpriseNature { get; set; }

        /// <summary>
        /// 描述 :客户代码 
        /// 空值 :false 
        /// </summary>
        public string ScCode { get; set; }

        /// <summary>
        /// 描述 :客户简称 
        /// 空值 :false 
        /// </summary>
        public string ScAbbr { get; set; }

        /// <summary>
        /// 描述 :客户名称 
        /// 空值 :false 
        /// </summary>
        public string ScName { get; set; }

        /// <summary>
        /// 描述 :企业法人 
        /// 空值 :false 
        /// </summary>
        public string ScEbe { get; set; }

        /// <summary>
        /// 描述 :营业执照 
        /// 空值 :false 
        /// </summary>
        public string ScBusinessNo { get; set; }

        /// <summary>
        /// 描述 :税号 
        /// 空值 :false 
        /// </summary>
        public string ScTaxNo { get; set; }

        /// <summary>
        /// 描述 :税别 
        /// 空值 :false 
        /// </summary>
        public string ScTaxType { get; set; }

        /// <summary>
        /// 描述 :主营业务 
        /// 空值 :false 
        /// </summary>
        public string ScMainBusiness { get; set; }

        /// <summary>
        /// 描述 :交易币种 
        /// 空值 :false 
        /// </summary>
        public string ScCcy { get; set; }

        /// <summary>
        /// 描述 :付款条件 
        /// 空值 :false 
        /// </summary>
        public string ScPayTerms { get; set; }

        /// <summary>
        /// 描述 :付款方式 
        /// 空值 :false 
        /// </summary>
        public string ScPayMethod { get; set; }

        /// <summary>
        /// 描述 :统驭科目 
        /// 空值 :false 
        /// </summary>
        public string ScRecAccount { get; set; }

        /// <summary>
        /// 描述 :贸易条件 
        /// 空值 :false 
        /// </summary>
        public string ScTradeTerms { get; set; }

        /// <summary>
        /// 描述 :装运条件 
        /// 空值 :false 
        /// </summary>
        public string ScShippingTerms { get; set; }

        /// <summary>
        /// 描述 :客户等级 
        /// 空值 :true 
        /// </summary>
        public string ScCustomerGrade { get; set; }

        /// <summary>
        /// 描述 :客户信用 
        /// 空值 :true 
        /// </summary>
        public string ScCustomerCredit { get; set; }

        /// <summary>
        /// 描述 :首次交易 
        /// 空值 :true 
        /// </summary>
        public DateTime? ScFirstTransDate { get; set; }

        /// <summary>
        /// 描述 :最近交易 
        /// 空值 :true 
        /// </summary>
        public DateTime? ScLastTransDate { get; set; }

        /// <summary>
        /// 描述 :银行代码 
        /// 空值 :false 
        /// </summary>
        public string ScBankCode { get; set; }

        /// <summary>
        /// 描述 :银行名称 
        /// 空值 :false 
        /// </summary>
        public string ScBankName { get; set; }

        /// <summary>
        /// 描述 :分行名称 
        /// 空值 :true 
        /// </summary>
        public string ScBranchName { get; set; }

        /// <summary>
        /// 描述 :银行所在国 
        /// 空值 :false 
        /// </summary>
        public string ScBankCountry { get; set; }

        /// <summary>
        /// 描述 :银行所在州省 
        /// 空值 :false 
        /// </summary>
        public string ScBankState { get; set; }

        /// <summary>
        /// 描述 :银行所在市 
        /// 空值 :false 
        /// </summary>
        public string ScBankCity { get; set; }

        /// <summary>
        /// 描述 :银行所在县 
        /// 空值 :false 
        /// </summary>
        public string ScBankCounty { get; set; }

        /// <summary>
        /// 描述 :银行地址 
        /// 空值 :false 
        /// </summary>
        public string ScBankAddr { get; set; }

        /// <summary>
        /// 描述 :银行地址1 
        /// 空值 :true 
        /// </summary>
        public string ScBankAddr1 { get; set; }

        /// <summary>
        /// 描述 :银行地址2 
        /// 空值 :true 
        /// </summary>
        public string ScBankAddr2 { get; set; }

        /// <summary>
        /// 描述 :银行账号 
        /// 空值 :false 
        /// </summary>
        public string ScBankAccount { get; set; }

        /// <summary>
        /// 描述 :SWIFT代码 
        /// 空值 :true 
        /// </summary>
        public string ScBankSwiftNo { get; set; }

        /// <summary>
        /// 描述 :国家地区 
        /// 空值 :true 
        /// </summary>
        public string ScRegionCode { get; set; }

        /// <summary>
        /// 描述 :州省 
        /// 空值 :true 
        /// </summary>
        public string ScState { get; set; }

        /// <summary>
        /// 描述 :市 
        /// 空值 :true 
        /// </summary>
        public string ScCity { get; set; }

        /// <summary>
        /// 描述 :县 
        /// 空值 :true 
        /// </summary>
        public string ScCounty { get; set; }

        /// <summary>
        /// 描述 :地址 
        /// 空值 :false 
        /// </summary>
        public string ScAddr { get; set; }

        /// <summary>
        /// 描述 :地址1 
        /// 空值 :true 
        /// </summary>
        public string ScAddr1 { get; set; }

        /// <summary>
        /// 描述 :地址2 
        /// 空值 :true 
        /// </summary>
        public string ScAddr2 { get; set; }

        /// <summary>
        /// 描述 :联系人 
        /// 空值 :true 
        /// </summary>
        public string ScContacts { get; set; }

        /// <summary>
        /// 描述 :电邮 
        /// 空值 :true 
        /// </summary>
        public string ScEmail { get; set; }

        /// <summary>
        /// 描述 :电话 
        /// 空值 :true 
        /// </summary>
        public string ScTelNo { get; set; }

        /// <summary>
        /// 描述 :传真 
        /// 空值 :true 
        /// </summary>
        public string ScFaxNp { get; set; }

        /// <summary>
        /// 描述 :手机 
        /// 空值 :true 
        /// </summary>
        public string ScPhoneNo { get; set; }

        /// <summary>
        /// 描述 :冻结标记 
        /// 空值 :false 
        /// </summary>
        public bool IsFroze { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}