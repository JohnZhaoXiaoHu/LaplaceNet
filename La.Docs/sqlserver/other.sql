USE La_Deb
GO
/****** Object:  Table [dbo].[fico_asset]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_asset]',N'U') is not NULL DROP TABLE [fico_asset]
GO
CREATE TABLE [dbo].[fico_asset](
	[FaGuid] [uniqueidentifier] NOT NULL,
	[FaClassCode] [nvarchar](20) NOT NULL,
	[FaAssetNo] [nvarchar](20) NOT NULL,
	[FaCostCenter] [nvarchar](20) NOT NULL,
	[FaAssetName] [nvarchar](200) NOT NULL,
	[FaAssetQty] [int] NOT NULL,
	[FaAcquisitionPrice] [decimal](18, 5) NOT NULL,
	[FaCapitalizedDate] [date] NOT NULL,
	[FaDepreciationValue] [decimal](18, 5) NOT NULL,
	[FaScrapDate] [date] NULL,
	[FaScrapValue] [decimal](18, 5) NOT NULL,
	[FaDept] [nvarchar](20) NOT NULL,
	[FaLocale] [nvarchar](200) NOT NULL,
	[FaEntity] [nvarchar](2) NOT NULL,
	[FaHaveorNot] [nvarchar](2) NOT NULL,
	[FaCheckedby] [nvarchar](50) NOT NULL,
	[FaCheckedDate] [date] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_asset] PRIMARY KEY CLUSTERED 
(
	[FaGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_bom_costing]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_bom_costing]',N'U') is not NULL DROP TABLE [fico_bom_costing]
GO
CREATE TABLE [dbo].[fico_bom_costing](
	[BcId] [bigint] IDENTITY(1,1) NOT NULL,
	[BcPlant] [nvarchar](4) NOT NULL,
	[BcFy] [nvarchar](6) NOT NULL,
	[BcYm] [nvarchar](6) NOT NULL,
	[BcBomItem] [nvarchar](20) NOT NULL,
	[BcItemText] [nvarchar](40) NOT NULL,
	[BcBomCost] [decimal](18, 5) NOT NULL,
	[BcCurrency] [nvarchar](3) NOT NULL,
	[BcBalancedate] [date] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_bom_costing] PRIMARY KEY CLUSTERED 
(
	[BcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_budget_asset]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_budget_asset]',N'U') is not NULL DROP TABLE [fico_budget_asset]
GO
CREATE TABLE [dbo].[fico_budget_asset](
	[FbaGuid] [uniqueidentifier] NOT NULL,
	[FbaDept] [nvarchar](20) NOT NULL,
	[FbaFy] [nvarchar](6) NOT NULL,
	[FbaFm] [nvarchar](100) NOT NULL,
	[FbaTitle] [int] NOT NULL,
	[FbaClass] [nvarchar](100) NOT NULL,
	[FbaName] [nvarchar](100) NOT NULL,
	[FbaDesc] [nvarchar](250) NOT NULL,
	[FbaServiceLife] [int] NOT NULL,
	[FbaBudgetAmount] [decimal](18, 2) NOT NULL,
	[FbaActualAmount] [decimal](18, 2) NOT NULL,
	[FbaDifferenceAmount] [decimal](18, 2) NOT NULL,
	[FbaDepreciation] [decimal](18, 2) NOT NULL,
	[FbaFlag] [int] NOT NULL,
	[FbaAuditDate] [date] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_budget_asset] PRIMARY KEY CLUSTERED 
(
	[FbaGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_budget_expense]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_budget_expense]',N'U') is not NULL DROP TABLE [fico_budget_expense]
GO
CREATE TABLE [dbo].[fico_budget_expense](
	[FbeGuid] [uniqueidentifier] NOT NULL,
	[FbeDept] [nvarchar](20) NOT NULL,
	[FbeFy] [nvarchar](6) NOT NULL,
	[FbeFm] [nvarchar](100) NOT NULL,
	[FbeTitle] [int] NOT NULL,
	[FbeClass] [nvarchar](100) NOT NULL,
	[FbeTitlesub] [int] NOT NULL,
	[FbeClasssub] [nvarchar](100) NOT NULL,
	[FbeClassmemo] [nvarchar](255) NOT NULL,
	[FbeBudgetAmount] [decimal](18, 2) NOT NULL,
	[FbeActualAmount] [decimal](18, 2) NOT NULL,
	[FbeDifferenceAmount] [decimal](18, 2) NOT NULL,
	[FbsFlag] [int] NOT NULL,
	[FbsAuditDate] [date] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_budget_expense] PRIMARY KEY CLUSTERED 
(
	[FbeGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_budget_overtime]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_budget_overtime]',N'U') is not NULL DROP TABLE [fico_budget_overtime]
GO
CREATE TABLE [dbo].[fico_budget_overtime](
	[FboGuid] [uniqueidentifier] NOT NULL,
	[FboDept] [nvarchar](20) NOT NULL,
	[FboFy] [nvarchar](6) NOT NULL,
	[FboFm] [nvarchar](100) NOT NULL,
	[FboTitle] [int] NOT NULL,
	[FboClass] [nvarchar](100) NOT NULL,
	[FboRequiredst] [decimal](18, 2) NOT NULL,
	[FboDirectEmployee] [int] NOT NULL,
	[FboIndirectEmployee] [int] NOT NULL,
	[FboDays] [int] NOT NULL,
	[FboContent] [nvarchar](500) NOT NULL,
	[FboRetainst] [decimal](18, 2) NOT NULL,
	[FboRetainstdiff] [decimal](18, 2) NOT NULL,
	[FboOvertime] [decimal](18, 2) NOT NULL,
	[FboDirectovertime] [decimal](18, 2) NOT NULL,
	[FboIndirectovertime] [decimal](18, 2) NOT NULL,
	[FboOvertimetotal] [decimal](18, 2) NOT NULL,
	[FboFlag] [int] NOT NULL,
	[FboAuditDate] [date] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_budget_overtime] PRIMARY KEY CLUSTERED 
(
	[FboGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_budget_staff]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_budget_staff]',N'U') is not NULL DROP TABLE [fico_budget_staff]
GO
CREATE TABLE [dbo].[fico_budget_staff](
	[FbsGuid] [uniqueidentifier] NOT NULL,
	[FbsDept] [nvarchar](20) NOT NULL,
	[FbsFy] [nvarchar](6) NOT NULL,
	[FbsFm] [nvarchar](100) NOT NULL,
	[FbsTitle] [int] NOT NULL,
	[FbsClass] [nvarchar](100) NOT NULL,
	[FbsCategory] [nvarchar](100) NOT NULL,
	[FbsKeepPersonnel] [int] NOT NULL,
	[FbsNowPersonnel] [int] NOT NULL,
	[FbsPersonnel] [int] NOT NULL,
	[FbsFlag] [int] NOT NULL,
	[FbsAuditDate] [date] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_budget_staff] PRIMARY KEY CLUSTERED 
(
	[FbsGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_budgetactual_cost]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_budgetactual_cost]',N'U') is not NULL DROP TABLE [fico_budgetactual_cost]
GO
CREATE TABLE [dbo].[fico_budgetactual_cost](
	[FbId] [uniqueidentifier] NOT NULL,
	[FbFy] [nvarchar](6) NOT NULL,
	[FbYm] [nvarchar](6) NOT NULL,
	[FbCorpCode] [nvarchar](4) NOT NULL,
	[FbCorpName] [nvarchar](40) NOT NULL,
	[FbExpCategory] [nvarchar](10) NOT NULL,
	[FbCostCode] [nvarchar](10) NOT NULL,
	[FbCostName] [nvarchar](20) NOT NULL,
	[FbTitleCode] [nvarchar](10) NOT NULL,
	[FbTitleName] [nvarchar](40) NOT NULL,
	[FbTitleNote] [nvarchar](40) NOT NULL,
	[FbBudgetAmt] [decimal](18, 2) NOT NULL,
	[FbActualAmt] [decimal](18, 2) NOT NULL,
	[FbDiffAmt] [decimal](18, 2) NOT NULL,
	[FbAccountant] [nvarchar](10) NOT NULL,
	[FbBalanceDate] [date] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_budgetactual_cost] PRIMARY KEY CLUSTERED 
(
	[FbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_dept_consuming]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_dept_consuming]',N'U') is not NULL DROP TABLE [fico_dept_consuming]
GO
CREATE TABLE [dbo].[fico_dept_consuming](
	[DcId] [uniqueidentifier] NOT NULL,
	[DcFy] [nvarchar](6) NOT NULL,
	[DcYm] [nvarchar](6) NOT NULL,
	[DcCorpCode] [nvarchar](4) NOT NULL,
	[DcCorpName] [nvarchar](40) NOT NULL,
	[DcExpCategory] [nvarchar](10) NOT NULL,
	[DcCostCode] [nvarchar](10) NOT NULL,
	[DcCostName] [nvarchar](40) NOT NULL,
	[DcTitleCode] [nvarchar](10) NOT NULL,
	[DcTitleName] [nvarchar](40) NOT NULL,
	[DcTitleNote] [nvarchar](40) NOT NULL,
	[DcBudgetAmt] [decimal](18, 2) NOT NULL,
	[DcActualAmt] [decimal](18, 2) NOT NULL,
	[DcDiffAmt] [decimal](18, 2) NOT NULL,
	[DcPlant] [nvarchar](4) NOT NULL,
	[DcMateriel] [nvarchar](20) NOT NULL,
	[DcStorageLocation] [nvarchar](4) NOT NULL,
	[DcMoveType] [nvarchar](3) NOT NULL,
	[DcMaterielDoc] [nvarchar](10) NOT NULL,
	[DcMaterielDocDetails] [nvarchar](5) NOT NULL,
	[DcUseQty] [decimal](18, 2) NOT NULL,
	[DcUseAmt] [decimal](18, 2) NOT NULL,
	[DcReserveDoc] [nvarchar](10) NOT NULL,
	[DcAccountant] [nvarchar](10) NOT NULL,
	[DcBalanceDate] [date] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_dept_consuming] PRIMARY KEY CLUSTERED 
(
	[DcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_exchange_rate]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_exchange_rate]',N'U') is not NULL DROP TABLE [fico_exchange_rate]
GO
CREATE TABLE [dbo].[fico_exchange_rate](
	[ErId] [uniqueidentifier] NOT NULL,
	[ErEffDate] [date] NOT NULL,
	[ErStd] [int] NOT NULL,
	[ErfmCcy] [nvarchar](3) NOT NULL,
	[ErRate] [decimal](18, 5) NOT NULL,
	[ErtoCcy] [nvarchar](3) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_exchange_rate] PRIMARY KEY CLUSTERED 
(
	[ErId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_monthly_inventory]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_monthly_inventory]',N'U') is not NULL DROP TABLE [fico_monthly_inventory]
GO
CREATE TABLE [dbo].[fico_monthly_inventory](
	[MiId] [uniqueidentifier] NOT NULL,
	[MiPlant] [nvarchar](4) NOT NULL,
	[MiFy] [nvarchar](6) NOT NULL,
	[MiYm] [nvarchar](6) NOT NULL,
	[MiItem] [nvarchar](20) NOT NULL,
	[MiValType] [nvarchar](4) NOT NULL,
	[MiPriceControl] [nvarchar](1) NOT NULL,
	[MiMovingAverage] [decimal](18, 2) NOT NULL,
	[MiPerUnit] [int] NOT NULL,
	[MiLocalCcy] [nvarchar](3) NOT NULL,
	[MiInventoryQty] [decimal](18, 2) NOT NULL,
	[MiInventoryAmount] [decimal](18, 2) NOT NULL,
	[MiBalancedate] [date] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_monthly_inventory] PRIMARY KEY CLUSTERED 
(
	[MiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_period]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_period]',N'U') is not NULL DROP TABLE [fico_period]
GO
CREATE TABLE [dbo].[fico_period](
	[FpId] [uniqueidentifier] NOT NULL,
	[FpFy] [nvarchar](6) NOT NULL,
	[FpYm] [nvarchar](6) NOT NULL,
	[FpYear] [nvarchar](4) NOT NULL,
	[FpMonth] [nvarchar](2) NOT NULL,
	[FpQuarter] [nvarchar](2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_period] PRIMARY KEY CLUSTERED 
(
	[FpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_prctr]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_prctr]',N'U') is not NULL DROP TABLE [fico_prctr]
GO
CREATE TABLE [dbo].[fico_prctr](
	[FpId] [uniqueidentifier] NOT NULL,
	[FpPlnt] [nvarchar](4) NOT NULL,
	[FpCode] [nvarchar](8) NOT NULL,
	[FpName] [nvarchar](50) NOT NULL,
	[FpType] [nvarchar](1) NOT NULL,
	[FpActDate] [datetime] NOT NULL,
	[FpExpDate] [datetime] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_prctr] PRIMARY KEY CLUSTERED 
(
	[FpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_accounting_title]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_accounting_title]',N'U') is not NULL DROP TABLE [fico_accounting_title]
GO
CREATE TABLE [dbo].[fico_accounting_title](
	[FtId] [uniqueidentifier] NOT NULL,
	[FtCorpCode] [varchar](4) NOT NULL,
	[FtTitleCode] [nvarchar](10) NOT NULL,
	[FtTitleName] [nvarchar](100) NOT NULL,
	[FtTitleLang] [nvarchar](100) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_accounting_title] PRIMARY KEY CLUSTERED 
(
	[FtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_wage_rates]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[fico_wage_rates]',N'U') is not NULL DROP TABLE [fico_wage_rates]
GO
CREATE TABLE [dbo].[fico_wage_rates](
	[FwId][uniqueidentifier] NOT NULL,
	[FwYm] [nvarchar](6) NOT NULL,
	[FwPlant] [nvarchar](4) NOT NULL,
	[FwCcy] [nvarchar](3) NOT NULL,
	[FwSalesVolume] [decimal](18, 2) NOT NULL,
	[FwWorkingDays] [decimal](18, 2) NOT NULL,
	[FwDirectWageRate] [decimal](18, 2) NOT NULL,
	[FwDirect] [decimal](18, 2) NOT NULL,
	[FwDirectOverTime] [decimal](18, 2) NOT NULL,
	[FwDirectWages] [decimal](18, 2) NOT NULL,
	[FwInDirectWageRate] [decimal](18, 2) NOT NULL,
	[FwInDirect] [decimal](18, 2) NOT NULL,
	[FwInDirectOverTime] [decimal](18, 2) NOT NULL,
	[FwInDirectWages] [decimal](18, 2) NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_wage_rates] PRIMARY KEY CLUSTERED 
(
	[FwId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inst_formula]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[inst_formula]',N'U') is not NULL DROP TABLE [inst_formula]
GO
CREATE TABLE [dbo].[inst_formula](
	[IfGuid] [uniqueidentifier] NOT NULL,
	[IfType] [nvarchar](10) NOT NULL,
	[IfLangKey] [nvarchar](max) NOT NULL,
	[IfFormula] [nvarchar](max) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.inst_formula] PRIMARY KEY CLUSTERED 
(
	[IfGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inst_info]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[inst_info]',N'U') is not NULL DROP TABLE [inst_info]
GO
CREATE TABLE [dbo].[inst_info](
	[IiGuid] [uniqueidentifier] NOT NULL,
	[IiLangkey] [nvarchar](20) NOT NULL,
	[IiCategory] [nvarchar](20) NOT NULL,
	[IiShortName] [nvarchar](50) NOT NULL,
	[IiFullName] [nvarchar](200) NOT NULL,
	[IiNature] [nvarchar](50) NOT NULL,
	[IiOuterPhone] [nvarchar](50) NOT NULL,
	[IiInnerPhone] [nvarchar](50) NOT NULL,
	[IiFax] [nvarchar](50) NOT NULL,
	[IiPostalcode] [nvarchar](10) NULL,
	[IiEmail] [nvarchar](50) NULL,
	[IiOrgCode] [nvarchar](50) NULL,
	[IiCorporate] [nvarchar](50) NOT NULL,
	[IiProvinceId] [nvarchar](50) NOT NULL,
	[IiCityId] [nvarchar](50) NOT NULL,
	[IiCountyId] [nvarchar](50) NOT NULL,
	[IiTownId] [nvarchar](50) NULL,
	[IiVillageId] [nvarchar](50) NULL,
	[IiAddress] [nvarchar](500) NOT NULL,
	[IiEnAddress] [nvarchar](500) NOT NULL,
	[IiWebSite] [nvarchar](50) NULL,
	[IiFoundedTime] [datetime] NOT NULL,
	[IiBusinessScope] [nvarchar](200) NOT NULL,
	[IiParentCorp] [nvarchar](200) NULL,
	[IiSortCode] [int] NOT NULL,
	[IiisEnabled] [tinyint] NOT NULL,
	[IiSlogan] [nvarchar](500) NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.inst_info] PRIMARY KEY CLUSTERED 
(
	[IiGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inst_kpi]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[inst_kpi]',N'U') is not NULL DROP TABLE [inst_kpi]
GO
CREATE TABLE [dbo].[inst_kpi](
	[IkGuid] [uniqueidentifier] NOT NULL,
	[IkAbbrName] [nvarchar](10) NOT NULL,
	[IkAnnual] [nvarchar](4) NOT NULL,
	[IkLangKey] [nvarchar](20) NOT NULL,
	[IkTarget] [nvarchar](max) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.inst_kpi] PRIMARY KEY CLUSTERED 
(
	[IkGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_mara]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_mara]',N'U') is not NULL DROP TABLE [mm_mara]
GO
CREATE TABLE [dbo].[mm_mara](
	[MaraID] [uniqueidentifier] NOT NULL,
	[MaraADPROF] [nvarchar](3) NULL,
	[MaraAEKLK] [nvarchar](1) NULL,
	[MaraAENAM] [nvarchar](12) NOT NULL,
	[MaraAESZN] [nvarchar](6) NULL,
	[MaraALLOW_PMAT_IGNO] [nvarchar](1) NULL,
	[MaraANIMAL_ORIGIN] [nvarchar](1) NULL,
	[MaraANP] [nvarchar](9) NULL,
	[MaraATTYP] [nvarchar](2) NOT NULL,
	[MaraBBTYP] [nvarchar](1) NULL,
	[MaraBEGRU] [nvarchar](4) NULL,
	[MaraBEHVO] [nvarchar](2) NULL,
	[MaraBFLME] [nvarchar](1) NULL,
	[MaraBISMT] [nvarchar](18) NULL,
	[MaraBLANZ] [nvarchar](3) NULL,
	[MaraBLATT] [nvarchar](3) NULL,
	[MaraBMATN] [nvarchar](18) NULL,
	[MaraBRAND_ID] [nvarchar](4) NULL,
	[MaraBREIT] [decimal](13, 3) NOT NULL,
	[MaraBRGEW] [decimal](13, 3) NOT NULL,
	[MaraBSTAT] [nvarchar](2) NULL,
	[MaraBSTME] [nvarchar](3) NULL,
	[MaraBWSCL] [nvarchar](1) NULL,
	[MaraBWVOR] [nvarchar](1) NULL,
	[MaraCADKZ] [nvarchar](1) NULL,
	[MaraCARE_CODE] [nvarchar](16) NULL,
	[MaraCMETH] [nvarchar](1) NULL,
	[MaraCMREL] [nvarchar](1) NULL,
	[MaraCOLOR] [nvarchar](18) NULL,
	[MaraCOLOR_ATINN] [nvarchar](10) NULL,
	[MaraCOMMODITY] [nvarchar](18) NULL,
	[MaraCOMPL] [nvarchar](2) NULL,
	[MaraCUOBF] [nvarchar](18) NULL,
	[MaraCWQPROC] [nvarchar](2) NULL,
	[MaraCWQREL] [nvarchar](1) NULL,
	[MaraCWQTOLGR] [nvarchar](9) NULL,
	[MaraDATAB] [date] NULL,
	[MaraDG_PACK_STATUS] [nvarchar](10) NULL,
	[MaraDISST] [nvarchar](3) NULL,
	[MaraEAN11] [nvarchar](18) NULL,
	[MaraEANNR] [nvarchar](13) NULL,
	[MaraEKWSL] [nvarchar](4) NULL,
	[MaraENTAR] [nvarchar](1) NULL,
	[MaraERGEI] [nvarchar](3) NULL,
	[MaraERGEW] [decimal](13, 3) NOT NULL,
	[MaraERNAM] [nvarchar](12) NOT NULL,
	[MaraERSDA] [date] NOT NULL,
	[MaraERVOE] [nvarchar](3) NULL,
	[MaraERVOL] [decimal](13, 3) NOT NULL,
	[MaraETIAG] [nvarchar](18) NULL,
	[MaraETIAR] [nvarchar](2) NULL,
	[MaraETIFO] [nvarchar](2) NULL,
	[MaraEXTWG] [nvarchar](18) NULL,
	[MaraFASHGRD] [nvarchar](4) NULL,
	[MaraFERTH] [nvarchar](18) NULL,
	[MaraFIBER_CODE1] [nvarchar](3) NULL,
	[MaraFIBER_CODE2] [nvarchar](3) NULL,
	[MaraFIBER_CODE3] [nvarchar](3) NULL,
	[MaraFIBER_CODE4] [nvarchar](3) NULL,
	[MaraFIBER_CODE5] [nvarchar](3) NULL,
	[MaraFIBER_PART1] [nvarchar](3) NULL,
	[MaraFIBER_PART2] [nvarchar](3) NULL,
	[MaraFIBER_PART3] [nvarchar](3) NULL,
	[MaraFIBER_PART4] [nvarchar](3) NULL,
	[MaraFIBER_PART5] [nvarchar](3) NULL,
	[MaraFORMT] [nvarchar](4) NULL,
	[MaraFREE_CHAR] [nvarchar](18) NULL,
	[MaraFSH_MG_AT1] [nvarchar](10) NULL,
	[MaraFSH_MG_AT2] [nvarchar](10) NULL,
	[MaraFSH_MG_AT3] [nvarchar](6) NULL,
	[MaraFSH_SC_MID] [nvarchar](2) NULL,
	[MaraFSH_SEAIM] [nvarchar](1) NULL,
	[MaraFSH_SEALV] [nvarchar](1) NULL,
	[MaraFUELG] [decimal](3, 0) NOT NULL,
	[MaraGDS_RELEVANT] [nvarchar](1) NULL,
	[MaraGENNR] [nvarchar](18) NULL,
	[MaraGEWEI] [nvarchar](3) NULL,
	[MaraGEWTO] [decimal](3, 0) NOT NULL,
	[MaraGROES] [nvarchar](32) NULL,
	[MaraGTIN_VARIANT] [nvarchar](2) NULL,
	[MaraHAZMAT] [nvarchar](1) NULL,
	[MaraHERKL] [nvarchar](3) NULL,
	[MaraHNDLCODE] [nvarchar](4) NULL,
	[MaraHOEHE] [decimal](13, 3) NOT NULL,
	[MaraHUTYP] [nvarchar](4) NULL,
	[MaraHUTYP_DFLT] [nvarchar](4) NULL,
	[MaraIHIVI] [nvarchar](1) NULL,
	[MaraILOOS] [nvarchar](1) NULL,
	[MaraIMATN] [nvarchar](18) NULL,
	[MaraINHAL] [decimal](13, 3) NOT NULL,
	[MaraINHBR] [decimal](13, 3) NOT NULL,
	[MaraINHME] [nvarchar](3) NULL,
	[MaraIPMIPPRODUCT] [nvarchar](40) NULL,
	[MaraIPRKZ] [nvarchar](1) NULL,
	[MaraKOSCH] [nvarchar](18) NULL,
	[MaraKUNNR] [nvarchar](10) NULL,
	[MaraKZEFF] [nvarchar](1) NULL,
	[MaraKZGVH] [nvarchar](1) NULL,
	[MaraKZKFG] [nvarchar](1) NULL,
	[MaraKZKUP] [nvarchar](1) NULL,
	[MaraKZNFM] [nvarchar](1) NULL,
	[MaraKZREV] [nvarchar](1) NULL,
	[MaraKZUMW] [nvarchar](1) NULL,
	[MaraKZWSM] [nvarchar](1) NULL,
	[MaraLABOR] [nvarchar](3) NULL,
	[MaraLAEDA] [date] NULL,
	[MaraLAENG] [decimal](13, 3) NOT NULL,
	[MaraLIQDT] [date] NULL,
	[MaraLOGLEV_RETO] [nvarchar](1) NULL,
	[MaraLOGUNIT] [nvarchar](3) NULL,
	[MaraLVORM] [nvarchar](1) NULL,
	[MaraMAGRV] [nvarchar](4) NULL,
	[MaraMANDT] [nvarchar](3) NULL,
	[MaraMATFI] [nvarchar](1) NULL,
	[MaraMATKL] [nvarchar](9) NOT NULL,
	[MaraMATNR] [nvarchar](18) NOT NULL,
	[MaraMAXB] [decimal](15, 3) NOT NULL,
	[MaraMAXC] [decimal](15, 0) NOT NULL,
	[MaraMAXC_TOL] [decimal](3, 0) NOT NULL,
	[MaraMAXDIM_UOM] [nvarchar](3) NULL,
	[MaraMAXH] [decimal](15, 3) NOT NULL,
	[MaraMAXL] [decimal](15, 3) NOT NULL,
	[MaraMBRSH] [nvarchar](1) NOT NULL,
	[MaraMCOND] [nvarchar](1) NULL,
	[MaraMEABM] [nvarchar](3) NULL,
	[MaraMEDIUM] [nvarchar](6) NULL,
	[MaraMEINS] [nvarchar](3) NOT NULL,
	[MaraMFRGR] [nvarchar](8) NULL,
	[MaraMFRNR] [nvarchar](10) NULL,
	[MaraMFRPN] [nvarchar](40) NULL,
	[MaraMHDHB] [decimal](4, 0) NOT NULL,
	[MaraMHDLP] [decimal](3, 0) NOT NULL,
	[MaraMHDRZ] [decimal](4, 0) NOT NULL,
	[MaraMLGUT] [nvarchar](1) NULL,
	[MaraMPROF] [nvarchar](4) NULL,
	[MaraMSTAE] [nvarchar](2) NULL,
	[MaraMSTAV] [nvarchar](2) NULL,
	[MaraMSTDE] [date] NULL,
	[MaraMSTDV] [date] NULL,
	[MaraMTART] [nvarchar](4) NOT NULL,
	[MaraMTPOS_MARA] [nvarchar](4) NULL,
	[MaraNORMT] [nvarchar](18) NULL,
	[MaraNRFHG] [nvarchar](1) NULL,
	[MaraNSNID] [nvarchar](9) NULL,
	[MaraNTGEW] [decimal](13, 3) NOT NULL,
	[MaraNUMTP] [nvarchar](2) NULL,
	[MaraPACKCODE] [nvarchar](10) NULL,
	[MaraPICNUM] [nvarchar](18) NULL,
	[MaraPILFERABLE] [nvarchar](1) NULL,
	[MaraPLGTP] [nvarchar](2) NULL,
	[MaraPMATA] [nvarchar](18) NULL,
	[MaraPRDHA] [nvarchar](18) NULL,
	[MaraPROFL] [nvarchar](3) NULL,
	[MaraPRZUS] [nvarchar](1) NULL,
	[MaraPS_SMARTFORM] [nvarchar](30) NULL,
	[MaraPSTAT] [nvarchar](15) NULL,
	[MaraQGRP] [nvarchar](4) NULL,
	[MaraQMPUR] [nvarchar](1) NULL,
	[MaraQQTIME] [decimal](3, 0) NOT NULL,
	[MaraQQTIMEUOM] [nvarchar](3) NULL,
	[MaraRAUBE] [nvarchar](2) NULL,
	[MaraRBNRM] [nvarchar](9) NULL,
	[MaraRDMHD] [nvarchar](1) NULL,
	[MaraRETDELC] [nvarchar](1) NULL,
	[MaraRMATP] [nvarchar](18) NULL,
	[MaraSAISJ] [nvarchar](4) NULL,
	[MaraSAISO] [nvarchar](4) NULL,
	[MaraSAITY] [nvarchar](2) NULL,
	[MaraSATNR] [nvarchar](18) NULL,
	[MaraSERIAL] [nvarchar](4) NULL,
	[MaraSERLV] [nvarchar](1) NULL,
	[MaraSGT_COVSA] [nvarchar](8) NULL,
	[MaraSGT_CSGR] [nvarchar](4) NULL,
	[MaraSGT_REL] [nvarchar](1) NULL,
	[MaraSGT_SCOPE] [nvarchar](1) NULL,
	[MaraSGT_STAT] [nvarchar](1) NULL,
	[MaraSIZE1] [nvarchar](18) NULL,
	[MaraSIZE1_ATINN] [nvarchar](10) NULL,
	[MaraSIZE2] [nvarchar](18) NULL,
	[MaraSIZE2_ATINN] [nvarchar](10) NULL,
	[MaraSLED_BBD] [nvarchar](1) NULL,
	[MaraSPART] [nvarchar](2) NULL,
	[MaraSPROF] [nvarchar](1) NULL,
	[MaraSTFAK] [int] NOT NULL,
	[MaraSTOFF] [nvarchar](18) NULL,
	[MaraTAKLV] [nvarchar](1) NULL,
	[MaraTARE_VAR] [nvarchar](1) NULL,
	[MaraTEMPB] [nvarchar](2) NULL,
	[MaraTEXTILE_COMP_IND] [nvarchar](1) NULL,
	[MaraTRAGR] [nvarchar](4) NULL,
	[MaraVABME] [nvarchar](1) NULL,
	[MaraVHART] [nvarchar](4) NULL,
	[MaraVOLEH] [nvarchar](3) NULL,
	[MaraVOLTO] [decimal](3, 1) NOT NULL,
	[MaraVOLUM] [decimal](13, 3) NOT NULL,
	[MaraVPREH] [decimal](5, 0) NOT NULL,
	[MaraVPSTA] [nvarchar](15) NULL,
	[MaraWEORA] [nvarchar](1) NULL,
	[MaraWESCH] [decimal](13, 3) NOT NULL,
	[MaraWHMATGR] [nvarchar](4) NULL,
	[MaraWHSTC] [nvarchar](2) NULL,
	[MaraWRKST] [nvarchar](48) NULL,
	[MaraXCHPF] [nvarchar](1) NULL,
	[MaraXGCHP] [nvarchar](1) NULL,
	[MaraZEIAR] [nvarchar](3) NULL,
	[MaraZEIFO] [nvarchar](4) NULL,
	[MaraZEINR] [nvarchar](22) NULL,
	[MaraZEIVR] [nvarchar](2) NULL,
	[UDF01] [nvarchar](500) NULL,
	[UDF02] [nvarchar](500) NULL,
	[UDF03] [nvarchar](500) NULL,
	[UDF04] [nvarchar](500) NULL,
	[UDF05] [nvarchar](500) NULL,
	[UDF06] [nvarchar](500) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_mara] PRIMARY KEY CLUSTERED 
(
	[MaraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_marc]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_marc]',N'U') is not NULL DROP TABLE [mm_marc]
GO
CREATE TABLE [dbo].[mm_marc](
	[MarcID] [uniqueidentifier] NOT NULL,
	[MarcABCIN] [varchar](1) NULL,
	[MarcABFAC] [decimal](2, 1) NOT NULL,
	[MarcAHDIS] [varchar](1) NULL,
	[MarcALTSL] [varchar](1) NULL,
	[MarcAPLAL] [varchar](2) NULL,
	[MarcAPOKZ] [varchar](1) NULL,
	[MarcATPKZ] [varchar](1) NULL,
	[MarcAUFTL] [varchar](1) NULL,
	[MarcAUSDT] [date] NULL,
	[MarcAUSME] [varchar](3) NULL,
	[MarcAUSSS] [decimal](5, 2) NOT NULL,
	[MarcAUTRU] [varchar](1) NULL,
	[MarcAWSLS] [varchar](6) NULL,
	[MarcBASMG] [decimal](13, 3) NOT NULL,
	[MarcBEARZ] [decimal](5, 2) NOT NULL,
	[MarcBESKZ] [varchar](1) NOT NULL,
	[MarcBSTFE] [decimal](13, 3) NOT NULL,
	[MarcBSTMA] [decimal](13, 3) NOT NULL,
	[MarcBSTMI] [decimal](13, 3) NOT NULL,
	[MarcBSTRF] [decimal](13, 3) NOT NULL,
	[MarcBWESB] [decimal](13, 3) NOT NULL,
	[MarcBWSCL] [varchar](1) NULL,
	[MarcBWTTY] [varchar](1) NULL,
	[MarcCASNR] [varchar](15) NULL,
	[MarcCCFIX] [varchar](1) NULL,
	[MarcCOMPL] [varchar](2) NULL,
	[MarcCONS_PROCG] [varchar](1) NULL,
	[MarcCONVT] [varchar](2) NULL,
	[MarcCOPAM] [varchar](10) NULL,
	[MarcCUOBJ] [varchar](18) NULL,
	[MarcCUOBV] [varchar](18) NULL,
	[MarcDIBER] [varchar](1) NULL,
	[MarcDISGR] [varchar](4) NULL,
	[MarcDISLS] [varchar](2) NOT NULL,
	[MarcDISMM] [varchar](2) NOT NULL,
	[MarcDISPO] [varchar](3) NULL,
	[MarcDISPR] [varchar](4) NULL,
	[MarcDPLFS] [varchar](2) NULL,
	[MarcDPLHO] [decimal](3, 0) NOT NULL,
	[MarcDPLPU] [varchar](1) NULL,
	[MarcDZEIT] [decimal](3, 0) NOT NULL,
	[MarcEISBE] [decimal](13, 3) NOT NULL,
	[MarcEISLO] [decimal](13, 3) NOT NULL,
	[MarcEKGRP] [varchar](3) NOT NULL,
	[MarcEPRIO] [varchar](4) NULL,
	[MarcEXPME] [varchar](3) NULL,
	[MarcFABKZ] [varchar](1) NULL,
	[MarcFEVOR] [varchar](3) NULL,
	[MarcFFREI] [varchar](1) NULL,
	[MarcFHORI] [varchar](3) NULL,
	[MarcFIXLS] [decimal](13, 3) NOT NULL,
	[MarcFPRFM] [varchar](3) NULL,
	[MarcFRTME] [varchar](3) NULL,
	[MarcFSH_MG_ARUN_REQ] [varchar](1) NULL,
	[MarcFSH_SEAIM] [varchar](1) NULL,
	[MarcFVIDK] [varchar](4) NULL,
	[MarcFXHOR] [varchar](3) NULL,
	[MarcFXPRU] [varchar](1) NULL,
	[MarcGI_PR_TIME] [decimal](3, 0) NOT NULL,
	[MarcGLGMG] [decimal](13, 3) NOT NULL,
	[MarcGPMKZ] [varchar](1) NULL,
	[MarcGPNUM] [varchar](9) NULL,
	[MarcHERBL] [varchar](2) NULL,
	[MarcHERKL] [varchar](3) NULL,
	[MarcHERKR] [varchar](3) NULL,
	[MarcINDUS] [varchar](2) NULL,
	[MarcINSMK] [varchar](1) NOT NULL,
	[MarcITARK] [varchar](1) NULL,
	[MarcIUID_RELEVANT] [varchar](1) NULL,
	[MarcIUID_TYPE] [varchar](10) NULL,
	[MarcKAUSF] [decimal](5, 2) NOT NULL,
	[MarcKAUTB] [varchar](1) NULL,
	[MarcKORDB] [varchar](1) NULL,
	[MarcKZAGL] [varchar](1) NULL,
	[MarcKZAUS] [varchar](1) NULL,
	[MarcKZBED] [varchar](1) NULL,
	[MarcKZDIE] [varchar](1) NULL,
	[MarcKZDKZ] [varchar](1) NULL,
	[MarcKZECH] [varchar](1) NULL,
	[MarcKZKFK] [varchar](1) NULL,
	[MarcKZKRI] [varchar](1) NULL,
	[MarcKZKUP] [varchar](1) NULL,
	[MarcKZPPV] [varchar](1) NULL,
	[MarcKZPRO] [varchar](1) NULL,
	[MarcKZPSP] [varchar](1) NULL,
	[MarcLADGR] [varchar](4) NULL,
	[MarcLAGPR] [varchar](1) NULL,
	[MarcLFGJA] [varchar](4) NULL,
	[MarcLFMON] [varchar](2) NULL,
	[MarcLFRHY] [varchar](3) NULL,
	[MarcLGFSB] [varchar](4) NOT NULL,
	[MarcLGPRO] [varchar](4) NOT NULL,
	[MarcLGRAD] [decimal](3, 1) NOT NULL,
	[MarcLIZYK] [varchar](4) NULL,
	[MarcLOGGR] [varchar](4) NULL,
	[MarcLOSFX] [decimal](11, 2) NOT NULL,
	[MarcLOSGR] [decimal](13, 3) NOT NULL,
	[MarcLTINC] [decimal](13, 3) NOT NULL,
	[MarcLVORM] [varchar](1) NULL,
	[MarcLZEIH] [varchar](3) NULL,
	[MarcMAABC] [varchar](1) NULL,
	[MarcMABST] [decimal](13, 3) NOT NULL,
	[MarcMANDT] [varchar](3) NOT NULL,
	[MarcMATGR] [varchar](20) NULL,
	[MarcMATNR] [varchar](18) NOT NULL,
	[MarcMAX_TROC] [varchar](3) NULL,
	[MarcMAXLS] [decimal](13, 3) NOT NULL,
	[MarcMAXLZ] [decimal](5, 0) NOT NULL,
	[MarcMCRUE] [varchar](1) NULL,
	[MarcMDACH] [varchar](2) NULL,
	[MarcMEGRU] [varchar](4) NULL,
	[MarcMFRGR] [varchar](8) NULL,
	[MarcMIN_TROC] [varchar](3) NULL,
	[MarcMINBE] [decimal](13, 3) NOT NULL,
	[MarcMINLS] [decimal](13, 3) NOT NULL,
	[MarcMISKZ] [varchar](1) NULL,
	[MarcMMSTA] [varchar](2) NULL,
	[MarcMMSTD] [date] NULL,
	[MarcMOGRU] [varchar](6) NULL,
	[MarcMOWNR] [varchar](12) NULL,
	[MarcMPDAU] [decimal](5, 0) NOT NULL,
	[MarcMRPPP] [varchar](3) NULL,
	[MarcMTVER] [varchar](4) NULL,
	[MarcMTVFP] [varchar](2) NOT NULL,
	[MarcMULTIPLE_EKGRP] [varchar](1) NULL,
	[MarcNCOST] [varchar](1) NULL,
	[MarcNFMAT] [varchar](18) NULL,
	[MarcNKMPR] [date] NULL,
	[MarcOBJID] [varchar](8) NULL,
	[MarcOCMPF] [varchar](6) NULL,
	[MarcOTYPE] [varchar](2) NULL,
	[MarcPERIV] [varchar](2) NULL,
	[MarcPERKZ] [varchar](1) NULL,
	[MarcPFREI] [varchar](1) NULL,
	[MarcPLIFZ] [decimal](3, 0) NOT NULL,
	[MarcPLNNR] [varchar](8) NULL,
	[MarcPLNTY] [varchar](1) NULL,
	[MarcPLVAR] [varchar](2) NULL,
	[MarcPRCTR] [varchar](10) NOT NULL,
	[MarcPREFE] [varchar](1) NULL,
	[MarcPRENC] [varchar](1) NULL,
	[MarcPREND] [date] NULL,
	[MarcPRENE] [varchar](1) NULL,
	[MarcPRENG] [date] NULL,
	[MarcPRENO] [varchar](8) NULL,
	[MarcPRFRQ] [decimal](5, 0) NOT NULL,
	[MarcPSTAT] [varchar](15) NULL,
	[MarcQMATA] [varchar](6) NULL,
	[MarcQMATV] [varchar](1) NULL,
	[MarcQSSYS] [varchar](4) NULL,
	[MarcQUAZT] [decimal](3, 0) NOT NULL,
	[MarcQZGTP] [varchar](4) NULL,
	[MarcRDPRF] [varchar](4) NULL,
	[MarcREF_SCHEMA] [varchar](2) NULL,
	[MarcRESVP] [decimal](3, 0) NOT NULL,
	[MarcRGEKZ] [varchar](1) NULL,
	[MarcROTATION_DATE] [varchar](1) NULL,
	[MarcRUEZT] [decimal](5, 2) NOT NULL,
	[MarcRWPRO] [varchar](3) NULL,
	[MarcSAUFT] [varchar](1) NULL,
	[MarcSBDKZ] [varchar](1) NULL,
	[MarcSCHGT] [varchar](1) NULL,
	[MarcSERNP] [varchar](4) NULL,
	[MarcSERVG] [varchar](1) NULL,
	[MarcSFCPF] [varchar](6) NULL,
	[MarcSFEPR] [varchar](4) NULL,
	[MarcSGT_CHINT] [varchar](1) NULL,
	[MarcSGT_COVS] [varchar](8) NULL,
	[MarcSGT_MRPSI] [varchar](1) NULL,
	[MarcSGT_PRCM] [varchar](1) NULL,
	[MarcSGT_SCOPE] [varchar](1) NULL,
	[MarcSGT_STATC] [varchar](1) NULL,
	[MarcSGT_STK_PRT] [varchar](1) NULL,
	[MarcSHFLG] [varchar](1) NULL,
	[MarcSHPRO] [varchar](3) NULL,
	[MarcSHZET] [varchar](2) NULL,
	[MarcSOBSK] [varchar](2) NULL,
	[MarcSOBSL] [varchar](2) NOT NULL,
	[MarcSPROZ] [decimal](3, 1) NOT NULL,
	[MarcSSQSS] [varchar](8) NULL,
	[MarcSTAWN] [varchar](17) NULL,
	[MarcSTDPD] [varchar](18) NULL,
	[MarcSTEUC] [varchar](16) NULL,
	[MarcSTLAL] [varchar](2) NULL,
	[MarcSTLAN] [varchar](1) NULL,
	[MarcSTRGR] [varchar](2) NULL,
	[MarcTAKZT] [decimal](3, 0) NOT NULL,
	[MarcTARGET_STOCK] [decimal](13, 3) NOT NULL,
	[MarcTRAME] [decimal](13, 3) NOT NULL,
	[MarcTRANZ] [decimal](5, 2) NOT NULL,
	[MarcUCHKZ] [varchar](1) NULL,
	[MarcUCMAT] [varchar](18) NULL,
	[MarcUEETK] [varchar](1) NULL,
	[MarcUEETO] [decimal](3, 1) NOT NULL,
	[MarcUID_IEA] [varchar](1) NULL,
	[MarcUMLMC] [decimal](13, 3) NOT NULL,
	[MarcUMRSL] [varchar](4) NULL,
	[MarcUNETO] [decimal](3, 1) NOT NULL,
	[MarcUOMGR] [varchar](3) NULL,
	[MarcUSEQU] [varchar](1) NULL,
	[MarcVBAMG] [decimal](13, 3) NOT NULL,
	[MarcVBEAZ] [decimal](5, 2) NOT NULL,
	[MarcVERKZ] [varchar](1) NULL,
	[MarcVINT1] [varchar](3) NULL,
	[MarcVINT2] [varchar](3) NULL,
	[MarcVKGLG] [decimal](13, 2) NOT NULL,
	[MarcVKTRW] [decimal](13, 2) NOT NULL,
	[MarcVKUMC] [decimal](13, 2) NOT NULL,
	[MarcVRBDT] [date] NULL,
	[MarcVRBFK] [decimal](4, 2) NOT NULL,
	[MarcVRBMT] [varchar](18) NULL,
	[MarcVRBWK] [varchar](4) NULL,
	[MarcVRMOD] [varchar](1) NULL,
	[MarcVRVEZ] [decimal](5, 2) NOT NULL,
	[MarcVSPVB] [varchar](10) NULL,
	[MarcVZUSL] [decimal](5, 2) NOT NULL,
	[MarcWEBAZ] [decimal](3, 0) NOT NULL,
	[MarcWERKS] [varchar](4) NOT NULL,
	[MarcWSTGH] [decimal](9, 0) NOT NULL,
	[MarcWZEIT] [decimal](3, 0) NOT NULL,
	[MarcXCHAR] [varchar](1) NULL,
	[MarcXCHPF] [varchar](1) NULL,
	[MarcXMCNG] [varchar](1) NULL,
	[UDF01] [nvarchar](500) NULL,
	[UDF02] [nvarchar](500) NULL,
	[UDF03] [nvarchar](500) NULL,
	[UDF04] [nvarchar](500) NULL,
	[UDF05] [nvarchar](500) NULL,
	[UDF06] [nvarchar](500) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_marc] PRIMARY KEY CLUSTERED 
(
	[MarcID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_mats]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_mats]',N'U') is not NULL DROP TABLE [mm_mats]
GO
CREATE TABLE [dbo].[mm_mats](
	[MmId] [uniqueidentifier] NOT NULL,
	[MmLastDate] [date] NOT NULL,
	[MmPlnt] [nvarchar](4) NOT NULL,
	[MmMatItem] [nvarchar](20) NOT NULL,
	[MmIndustry] [nvarchar](1) NOT NULL,
	[MmMatType] [nvarchar](4) NOT NULL,
	[MmMatDes] [nvarchar](40) NOT NULL,
	[MmBaseUnit] [nvarchar](4) NOT NULL,
	[MmProLevel] [nvarchar](40) NULL,
	[MmMatGroup] [nvarchar](10) NOT NULL,
	[MmPurGroup] [nvarchar](4) NULL,
	[MmPurType] [nvarchar](1) NOT NULL,
	[MmSpecType] [nvarchar](2) NULL,
	[MmBulkMat] [nvarchar](1) NULL,
	[MmMoq] [int] NOT NULL,
	[MmRoundingVal] [int] NOT NULL,
	[MmLeadTime] [int] NOT NULL,
	[MmProDays] [decimal](18, 2) NOT NULL,
	[MmisChecked] [nvarchar](1) NULL,
	[MmProfitCenter] [nvarchar](5) NOT NULL,
	[MmDiffCode] [nvarchar](10) NULL,
	[MmisLot] [nvarchar](1) NULL,
	[MmMpn] [nvarchar](40) NULL,
	[MmMfrs] [nvarchar](40) NULL,
	[MmValType] [nvarchar](4) NOT NULL,
	[MmMovingAvg] [decimal](18, 2) NOT NULL,
	[MmCcy] [nvarchar](4) NOT NULL,
	[MmPriceControl] [nvarchar](1) NOT NULL,
	[MmPriceUnit] [int] NOT NULL,
	[MmSLoc] [nvarchar](4) NULL,
	[MmESLoc] [nvarchar](4) NULL,
	[MmLocPosn] [nvarchar](40) NULL,
	[MmInventory] [decimal](18, 2) NOT NULL,
	[MmLocEol] [nvarchar](2) NULL,
	[UDF01] [nvarchar](500) NULL,
	[UDF02] [nvarchar](500) NULL,
	[UDF03] [nvarchar](500) NULL,
	[UDF04] [nvarchar](500) NULL,
	[UDF05] [nvarchar](500) NULL,
	[UDF06] [nvarchar](500) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[IsDeleted] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_mats] PRIMARY KEY CLUSTERED 
(
	[MmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_mbew]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_mbew]',N'U') is not NULL DROP TABLE [mm_mbew]
GO
CREATE TABLE [dbo].[mm_mbew](
	[MbewID] [uniqueidentifier] NOT NULL,
	[MbewABCIW] [varchar](1) NULL,
	[MbewABWKZ] [varchar](2) NULL,
	[MbewBKLAS] [varchar](4) NULL,
	[MbewBWKEY] [varchar](4) NOT NULL,
	[MbewBWPEI] [decimal](5, 0) NOT NULL,
	[MbewBWPH1] [decimal](11, 2) NOT NULL,
	[MbewBWPRH] [decimal](11, 2) NOT NULL,
	[MbewBWPRS] [decimal](11, 2) NOT NULL,
	[MbewBWPS1] [decimal](11, 2) NOT NULL,
	[MbewBWSPA] [decimal](6, 2) NOT NULL,
	[MbewBWTAR] [varchar](10) NOT NULL,
	[MbewBWTTY] [varchar](1) NULL,
	[MbewBWVA1] [varchar](3) NULL,
	[MbewBWVA2] [varchar](3) NULL,
	[MbewBWVA3] [varchar](3) NULL,
	[MbewEKALR] [varchar](1) NULL,
	[MbewEKLAS] [varchar](4) NULL,
	[MbewFBWST] [varchar](1) NULL,
	[MbewFPLPX] [decimal](11, 2) NOT NULL,
	[MbewHKMAT] [varchar](1) NULL,
	[MbewHRKFT] [varchar](4) NULL,
	[MbewKALKL] [varchar](1) NULL,
	[MbewKALKV] [varchar](1) NULL,
	[MbewKALKZ] [varchar](1) NULL,
	[MbewKALN1] [varchar](12) NULL,
	[MbewKALNR] [varchar](12) NULL,
	[MbewKALSC] [varchar](6) NULL,
	[MbewKOSGR] [varchar](10) NULL,
	[MbewKZIWL] [varchar](3) NULL,
	[MbewLAEPR] [date] NULL,
	[MbewLBKUM] [decimal](13, 3) NOT NULL,
	[MbewLBWST] [varchar](1) NULL,
	[MbewLFGJA] [varchar](4) NULL,
	[MbewLFMON] [varchar](2) NULL,
	[MbewLPLPR] [decimal](11, 2) NOT NULL,
	[MbewLPLPX] [decimal](11, 2) NOT NULL,
	[MbewLVORM] [varchar](1) NULL,
	[MbewMANDT] [varchar](3) NOT NULL,
	[MbewMATNR] [varchar](18) NOT NULL,
	[MbewMBRUE] [varchar](1) NULL,
	[MbewMLAST] [varchar](1) NULL,
	[MbewMLMAA] [varchar](1) NULL,
	[MbewMTORG] [varchar](1) NULL,
	[MbewMTUSE] [varchar](1) NULL,
	[MbewMYPOL] [varchar](4) NULL,
	[MbewOIPPINV] [varchar](1) NULL,
	[MbewOKLAS] [varchar](4) NULL,
	[MbewOWNPR] [varchar](1) NULL,
	[MbewPDATL] [varchar](4) NULL,
	[MbewPDATV] [varchar](4) NULL,
	[MbewPDATZ] [varchar](4) NULL,
	[MbewPEINH] [decimal](5, 0) NOT NULL,
	[MbewPPERL] [varchar](6) NULL,
	[MbewPPERV] [varchar](6) NULL,
	[MbewPPERZ] [varchar](6) NULL,
	[MbewPPRDL] [varchar](3) NULL,
	[MbewPPRDV] [varchar](3) NULL,
	[MbewPPRDZ] [varchar](3) NULL,
	[MbewPSTAT] [varchar](15) NULL,
	[MbewQKLAS] [varchar](4) NULL,
	[MbewSALK3] [decimal](13, 2) NOT NULL,
	[MbewSALKV] [decimal](13, 2) NOT NULL,
	[MbewSPERW] [varchar](1) NULL,
	[MbewSTPRS] [decimal](11, 2) NOT NULL,
	[MbewSTPRV] [decimal](11, 2) NOT NULL,
	[MbewTIMESTAMP] [decimal](15, 0) NOT NULL,
	[MbewVBWST] [varchar](1) NULL,
	[MbewVERPR] [decimal](11, 2) NOT NULL,
	[MbewVERS1] [varchar](2) NULL,
	[MbewVERS2] [varchar](2) NULL,
	[MbewVERS3] [varchar](2) NULL,
	[MbewVJBKL] [varchar](4) NULL,
	[MbewVJBWH] [decimal](11, 2) NOT NULL,
	[MbewVJBWS] [decimal](11, 2) NOT NULL,
	[MbewVJKUM] [decimal](13, 3) NOT NULL,
	[MbewVJPEI] [decimal](5, 0) NOT NULL,
	[MbewVJSAL] [decimal](13, 2) NOT NULL,
	[MbewVJSAV] [decimal](13, 2) NOT NULL,
	[MbewVJSTP] [decimal](11, 2) NOT NULL,
	[MbewVJVER] [decimal](11, 2) NOT NULL,
	[MbewVJVPR] [varchar](1) NULL,
	[MbewVKSAL] [decimal](13, 2) NOT NULL,
	[MbewVMBKL] [varchar](4) NULL,
	[MbewVMKUM] [decimal](13, 3) NOT NULL,
	[MbewVMPEI] [decimal](5, 0) NOT NULL,
	[MbewVMSAL] [decimal](13, 2) NOT NULL,
	[MbewVMSAV] [decimal](13, 2) NOT NULL,
	[MbewVMSTP] [decimal](11, 2) NOT NULL,
	[MbewVMVER] [decimal](11, 2) NOT NULL,
	[MbewVMVPR] [varchar](1) NULL,
	[MbewVPLPR] [decimal](11, 2) NOT NULL,
	[MbewVPLPX] [decimal](11, 2) NOT NULL,
	[MbewVPRSV] [varchar](1) NULL,
	[MbewVVJLB] [decimal](13, 3) NOT NULL,
	[MbewVVJSL] [decimal](13, 2) NOT NULL,
	[MbewVVMLB] [decimal](13, 3) NOT NULL,
	[MbewVVSAL] [decimal](13, 2) NOT NULL,
	[MbewWLINL] [date] NULL,
	[MbewXBEWM] [varchar](1) NULL,
	[MbewXLIFO] [varchar](1) NULL,
	[MbewZKDAT] [date] NULL,
	[MbewZKPRS] [decimal](11, 2) NOT NULL,
	[MbewZPLD1] [date] NULL,
	[MbewZPLD2] [date] NULL,
	[MbewZPLD3] [date] NULL,
	[MbewZPLP1] [decimal](11, 2) NOT NULL,
	[MbewZPLP2] [decimal](11, 2) NOT NULL,
	[MbewZPLP3] [decimal](11, 2) NOT NULL,
	[MbewZPLPR] [decimal](11, 2) NOT NULL,
	[UDF01] [nvarchar](500) NULL,
	[UDF02] [nvarchar](500) NULL,
	[UDF03] [nvarchar](500) NULL,
	[UDF04] [nvarchar](500) NULL,
	[UDF05] [nvarchar](500) NULL,
	[UDF06] [nvarchar](500) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_mbew] PRIMARY KEY CLUSTERED 
(
	[MbewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_po_residue]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_po_residue]',N'U') is not NULL DROP TABLE [mm_po_residue]
GO
CREATE TABLE [dbo].[mm_po_residue](
	[PrId] [uniqueidentifier] NOT NULL,
	[PrPlant] [nvarchar](4) NOT NULL,
	[PrSupplierCode] [nvarchar](10) NOT NULL,
	[PrSupplierName] [nvarchar](40) NOT NULL,
	[PrPurItem] [nvarchar](20) NOT NULL,
	[PrPurItemText] [nvarchar](40) NOT NULL,
	[PrLocation] [nvarchar](4) NOT NULL,
	[PrDelivDate] [nvarchar](8) NOT NULL,
	[PrUnpaidQty] [decimal](18, 2) NOT NULL,
	[PrAlreadyQty] [decimal](18, 2) NOT NULL,
	[PrPurOrder] [nvarchar](10) NOT NULL,
	[PrPurOrderDetails] [nvarchar](5) NOT NULL,
	[PrPlannedQty] [decimal](18, 2) NOT NULL,
	[PrPurGroup] [nvarchar](4) NOT NULL,
	[PrPurDate] [nvarchar](8) NOT NULL,
	[PrPurUnit] [nvarchar](3) NOT NULL,
	[PrUnitPrice] [decimal](18, 5) NOT NULL,
	[PrPurCcy] [nvarchar](3) NOT NULL,
	[PrPurTaxType] [nvarchar](2) NOT NULL,
	[PrPrctr] [nvarchar](4) NOT NULL,
	[PrBalancedate] [date] NOT NULL,
	[isDelete] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_po_residue] PRIMARY KEY CLUSTERED 
(
	[PrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_supplier]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_supplier]',N'U') is not NULL DROP TABLE [mm_supplier]
GO
CREATE TABLE [dbo].[mm_supplier](
	[SuId] [uniqueidentifier] NOT NULL,
	[SuOrg] [nvarchar](4) NOT NULL,
	[SuPlant] [nvarchar](4) NOT NULL,
	[SuIndustryType] [nvarchar](1) NOT NULL,
	[SuEnterpriseNature] [nvarchar](1) NOT NULL,
	[SuCode] [nvarchar](10) NOT NULL,
	[SuAbbr] [nvarchar](4) NOT NULL,
	[SuName] [nvarchar](100) NOT NULL,
	[SuEbe] [nvarchar](50) NOT NULL,
	[SuBusinessNo] [nvarchar](100) NOT NULL,
	[SuTaxNo] [nvarchar](100) NOT NULL,
	[SuTaxType] [nvarchar](2) NOT NULL,
	[SuMainBusiness] [nvarchar](200) NOT NULL,
	[SuCcy] [nvarchar](3) NOT NULL,
	[SuPayTerms] [nvarchar](4) NOT NULL,
	[SuPayMethod] [nvarchar](1) NOT NULL,
	[SuRecAccount] [nvarchar](3) NOT NULL,
	[SuTradeTerms] [nvarchar](3) NOT NULL,
	[SuShippingTerms] [nvarchar](3) NOT NULL,
	[SuSupplierGrade] [nvarchar](1) NULL,
	[SuSupplierCredit] [nvarchar](1) NULL,
	[SuFirstTransDate] [date] NULL,
	[SuLastTransDate] [date] NULL,
	[SuBankCode] [nvarchar](8) NOT NULL,
	[SuBankName] [nvarchar](255) NOT NULL,
	[SuBranchName] [nvarchar](255) NULL,
	[SuBankCountry] [nvarchar](2) NOT NULL,
	[SuBankState] [nvarchar](40) NOT NULL,
	[SuBankCity] [nvarchar](40) NOT NULL,
	[SuBankCounty] [nvarchar](40) NOT NULL,
	[SuBankAddr] [nvarchar](40) NOT NULL,
	[SuBankAddr1] [nvarchar](40) NULL,
	[SuBankAddr2] [nvarchar](40) NULL,
	[SuBankAccount] [nvarchar](3) NOT NULL,
	[SuBankSwiftNo] [nvarchar](3) NULL,
	[SuRegionCode] [nvarchar](2) NULL,
	[SuState] [nvarchar](40) NULL,
	[SuCity] [nvarchar](40) NULL,
	[SuCounty] [nvarchar](40) NULL,
	[SuAddr] [nvarchar](40) NOT NULL,
	[SuAddr1] [nvarchar](40) NULL,
	[SuAddr2] [nvarchar](40) NULL,
	[SuContacts] [nvarchar](200) NULL,
	[SuEmail] [nvarchar](50) NULL,
	[SuTelNo] [nvarchar](16) NULL,
	[SuFaxNp] [nvarchar](16) NULL,
	[SuPhoneNo] [nvarchar](16) NULL,
	[IsFroze] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_supplier] PRIMARY KEY CLUSTERED 
(
	[SuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mm_vendor]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[mm_vendor]',N'U') is not NULL DROP TABLE [mm_vendor]
GO
CREATE TABLE [dbo].[mm_vendor](
	[VeId] [uniqueidentifier] NOT NULL,
	[VeOrg] [nvarchar](4) NOT NULL,
	[VePlant] [nvarchar](4) NOT NULL,
	[VeIndustryType] [nvarchar](1) NOT NULL,
	[VeEnterpriseNature] [nvarchar](1) NOT NULL,
	[VeCode] [nvarchar](10) NOT NULL,
	[VeAbbr] [nvarchar](4) NOT NULL,
	[VeName] [nvarchar](100) NOT NULL,
	[VeEbe] [nvarchar](50) NOT NULL,
	[VeBusinessNo] [nvarchar](100) NOT NULL,
	[VeTaxNo] [nvarchar](100) NOT NULL,
	[VeTaxType] [nvarchar](2) NOT NULL,
	[VeMainBusiness] [nvarchar](200) NOT NULL,
	[VeCcy] [nvarchar](3) NOT NULL,
	[VePayTerms] [nvarchar](4) NOT NULL,
	[VePayMethod] [nvarchar](1) NOT NULL,
	[VeRecAccount] [nvarchar](3) NOT NULL,
	[VeTradeTerms] [nvarchar](3) NOT NULL,
	[VeShippingTerms] [nvarchar](3) NOT NULL,
	[VeSupplierGrade] [nvarchar](1) NULL,
	[VeSupplierCredit] [nvarchar](1) NULL,
	[VeFirstTransDate] [date] NULL,
	[VeLastTransDate] [date] NULL,
	[VeBankCode] [nvarchar](8) NOT NULL,
	[VeBankName] [nvarchar](255) NOT NULL,
	[VeBranchName] [nvarchar](255) NULL,
	[VeBankCountry] [nvarchar](2) NOT NULL,
	[VeBankState] [nvarchar](40) NOT NULL,
	[VeBankCity] [nvarchar](40) NOT NULL,
	[VeBankCounty] [nvarchar](40) NOT NULL,
	[VeBankAddr] [nvarchar](40) NOT NULL,
	[VeBankAddr1] [nvarchar](40) NULL,
	[VeBankAddr2] [nvarchar](40) NULL,
	[VeBankAccount] [nvarchar](3) NOT NULL,
	[VeBankSwiftNo] [nvarchar](3) NULL,
	[VeRegionCode] [nvarchar](2) NULL,
	[VeState] [nvarchar](40) NULL,
	[VeCity] [nvarchar](40) NULL,
	[VeCounty] [nvarchar](40) NULL,
	[VeAddr] [nvarchar](40) NOT NULL,
	[VeAddr1] [nvarchar](40) NULL,
	[VeAddr2] [nvarchar](40) NULL,
	[VeContacts] [nvarchar](200) NULL,
	[VeEmail] [nvarchar](50) NULL,
	[VeTelNo] [nvarchar](16) NULL,
	[VeFaxNp] [nvarchar](16) NULL,
	[VePhoneNo] [nvarchar](16) NULL,
	[IsFroze] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.mm_vendor] PRIMARY KEY CLUSTERED 
(
	[VeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[office_article]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[office_article]',N'U') is not NULL DROP TABLE [office_article]
GO
CREATE TABLE [dbo].[office_article](
	[cid] [uniqueidentifier] NOT NULL,
	[title] [varchar](254) NULL,
	[content] [text] NULL,
	[userId] [bigint] NULL,
	[status] [varchar](20) NULL,
	[fmt_type] [varchar](20) NULL,
	[tags] [varchar](100) NULL,
	[hits] [int] NULL,
	[category_id] [int] NULL,
	[createTime] [datetime] NULL,
	[updateTime] [datetime] NULL,
	[authorName] [varchar](20) NULL,
	[coverUrl] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[office_article_category]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[office_article_category]',N'U') is not NULL DROP TABLE [office_article_category]
GO
CREATE TABLE [dbo].[office_article_category](
	[category_id] [uniqueidentifier] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[create_time] [datetime] NULL,
	[parentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[office_ehr_employee]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[office_ehr_employee]',N'U') is not NULL DROP TABLE [office_ehr_employee]
GO
CREATE TABLE [dbo].[office_ehr_employee](
	[EeId] [uniqueidentifier] NOT NULL,
	[EeName] [varchar](40) NOT NULL,
	[EeNameUsed] [varchar](40) NULL,
	[EeNickName] [varchar](40) NULL,
	[EeEnglishName] [varchar](200) NULL,
	[EeGender] [char](4) NOT NULL,
	[EeBirthday] [date] NOT NULL,
	[EeIdentityCard] [char](18) NOT NULL,
	[EeWedlock] [tinyint] NOT NULL,
	[EeNationId] [tinyint] NOT NULL,
	[EeNativePlace] [tinyint] NOT NULL,
	[EePoliticId] [tinyint] NOT NULL,
	[EeEmail] [varchar](20) NULL,
	[EePhone] [varchar](11) NULL,
	[EeCountry] [varchar](2) NOT NULL,
	[EeProvince] [varchar](10) NOT NULL,
	[EeCity] [varchar](10) NOT NULL,
	[EeCounty] [varchar](10) NOT NULL,
	[EeHomeAddress] [varchar](128) NOT NULL,
	[EePostCode] [varchar](8) NULL,
	[EeHouseholdType] [tinyint] NULL,
	[EeStayAddress] [varchar](128) NULL,
	[EeDepartmentId] [int] NOT NULL,
	[EeTitlesId] [int] NOT NULL,
	[EePostId] [int] NOT NULL,
	[EePostLevel] [int] NOT NULL,
	[EeDutyName] [int] NOT NULL,
	[EeRecruited] [int] NOT NULL,
	[EeEngageForm] [varchar](8) NULL,
	[EeTiptopDegrEe] [int] NULL,
	[EeSpecialty] [int] NULL,
	[EeSchool] [varchar](32) NULL,
	[EeWorkID] [varchar](8) NULL,
	[EeBeginDate] [date] NULL,
	[EeWorkState] [tinyint] NULL,
	[EeProbation] [tinyint] NULL,
	[EeContractTerm] [tinyint] NULL,
	[EeConversionTime] [date] NULL,
	[EeLeaveDate] [date] NULL,
	[EeBeginContract] [date] NULL,
	[EeBndContract] [date] NULL,
	[EeWorkAge] [int] NULL,
	[EeAvatar] [varchar](255) NULL,
	[EeQualificationAffix] [varchar](255) NULL,
	[EeTitleAffix] [varchar](255) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK__office_ehr_employee] PRIMARY KEY CLUSTERED 
(
	[EeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[office_et_dictionary]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[office_et_dictionary]',N'U') is not NULL DROP TABLE [office_et_dictionary]
GO
CREATE TABLE [dbo].[office_et_dictionary](
	[EtGuid] [uniqueidentifier] NOT NULL,
	[EtType] [varchar](2) NOT NULL,
	[EtLetter] [varchar](1) NOT NULL,
	[EtLangKey] [nvarchar](10) NOT NULL,
	[EtPhrase] [varchar](max) NOT NULL,
	[EtExplain] [nvarchar](max) NOT NULL,
	[EtArea] [nvarchar](4) NULL,
	[Remark] [varchar](max) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK__office_et_dictionary] PRIMARY KEY CLUSTERED 
(
	[EtGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[office_numbering_rules]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[office_numbering_rules]',N'U') is not NULL DROP TABLE [office_numbering_rules]
GO
CREATE TABLE [dbo].[office_numbering_rules](
	[refId] [uniqueidentifier] NOT NULL,
	[refModule] [varchar](64) NOT NULL,
	[refCategory] [varchar](64) NOT NULL,
	[refCode] [varchar](64) NOT NULL,
	[refName] [varchar](50) NOT NULL,
	[refPattern] [varchar](50) NOT NULL,
	[refPrefix] [varchar](4) NOT NULL,
	[refLenth] [int] NOT NULL,
	[initNumber] [varchar](20) NOT NULL,
	[isoNumber] [varchar](20) NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[Sort] [int] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [varchar](max) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK__office_numbering_rules] PRIMARY KEY CLUSTERED 
(
	[refId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_cause_type]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_cause_type]',N'U') is not NULL DROP TABLE [pp_cause_type]
GO
CREATE TABLE [dbo].[pp_cause_type](
	[CtId][uniqueidentifier] NOT NULL,
	[CtCauseType] [nvarchar](50) NOT NULL,
	[CtCauseText_Zh] [nvarchar](255) NOT NULL,
	[CtCauseText_En] [nvarchar](255) NOT NULL,
	[CtCauseText_Ja] [nvarchar](255) NOT NULL,
	[isDelete] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_cause_type] PRIMARY KEY CLUSTERED 
(
	[CtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_digest]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_digest]',N'U') is not NULL DROP TABLE [pp_ec_digest]
GO
CREATE TABLE [dbo].[pp_ec_digest](
	[EdId] [uniqueidentifier] NOT NULL,
	[EdBalanceDate] [date] NULL,
	[EdIssueDate] [date] NULL,
	[EdModel] [nvarchar](400) NULL,
	[Editem] [nvarchar](20) NULL,
	[EdEcNo] [nvarchar](100) NULL,
	[EdOldItem] [nvarchar](40) NULL,
	[EdOldQty] [decimal](18, 2) NOT NULL,
	[EdPoQty] [decimal](18, 2) NOT NULL,
	[EdBalanceQty] [decimal](18, 2) NOT NULL,
	[EdNewItem] [nvarchar](40) NULL,
	[EdNewQty] [decimal](18, 2) NOT NULL,
	[EdDisposal] [nvarchar](400) NULL,
	[EdNote] [nvarchar](400) NULL,
	[EdStatus] [nvarchar](40) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_ec_digest] PRIMARY KEY CLUSTERED 
(
	[EdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_ma_source]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_ma_source]',N'U') is not NULL DROP TABLE [pp_ec_ma_source]
GO
CREATE TABLE [dbo].[pp_ec_ma_source](
	[GUID] [uniqueidentifier] NOT NULL,
	[D_SAP_ZPABD_Z001] [nvarchar](6) NULL,
	[D_SAP_ZPABD_Z002] [nvarchar](10) NULL,
	[D_SAP_ZPABD_Z003] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z004] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z005] [date] NULL,
	[D_SAP_ZPABD_Z006] [nvarchar](20) NULL,
	[D_SAP_ZPABD_Z007] [nvarchar](20) NULL,
	[D_SAP_ZPABD_Z008] [nvarchar](20) NULL,
	[D_SAP_ZPABD_Z009] [nvarchar](10) NULL,
	[D_SAP_ZPABD_Z010] [nvarchar](10) NULL,
	[D_SAP_ZPABD_Z011] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z012] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z013] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z014] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z015] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z016] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z017] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z018] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z019] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z020] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z021] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z022] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z023] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z024] [nvarchar](40) NULL,
	[D_SAP_ZPABD_Z025] [nvarchar](13) NULL,
	[D_SAP_ZPABD_Z026] [nvarchar](210) NULL,
	[D_SAP_ZPABD_Z027] [nvarchar](4000) NULL,
	[IsSolved] [tinyint] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.PP_SapEcn] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_master]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_master]',N'U') is not NULL DROP TABLE [pp_ec_master]
GO
CREATE TABLE [dbo].[pp_ec_master](
	[EmId] [uniqueidentifier] NOT NULL,
	[EmEcIssueDate] [date] NOT NULL,
	[EmEcNo] [nvarchar](20) NOT NULL,
	[EmEcDoc] [nvarchar](500) NULL,
	[EmEcStatus] [nvarchar](40) NOT NULL,
	[EmEcTitle] [nvarchar](500) NOT NULL,
	[EmEcContent] [nvarchar](4000) NOT NULL,
	[EmEcAssigned] [nvarchar](50) NOT NULL,
	[EmEcLossAmount] [decimal](18, 2) NOT NULL,
	[EmEcManageCategory] [int] NOT NULL,
	[EmEcLiaisonNo] [nvarchar](10) NULL,
	[EmEcLiaisonDoc] [nvarchar](500) NULL,
	[EmEcEppLiaisonNo] [nvarchar](10) NULL,
	[EmEcEppLiaisonDoc] [nvarchar](500) NULL,
	[EmEcFppLiaisonNo] [nvarchar](10) NULL,
	[EmEcFppLiaisonDoc] [nvarchar](500) NULL,
	[EmEcExternalNo] [nvarchar](10) NULL,
	[EmEcExternalDoc] [nvarchar](500) NULL,
	[EmEcImpDept] [nvarchar](50) NOT NULL,
	[EmEcEntryDate] [date] NOT NULL,
	[EsSopStae] [tinyint] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_ec_master] PRIMARY KEY CLUSTERED 
(
	[EmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_slave]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_slave]',N'U') is not NULL DROP TABLE [pp_ec_slave]
GO
CREATE TABLE [dbo].[pp_ec_slave](
	[EsId] [uniqueidentifier] NOT NULL,
	[EsEntryDate] [date] NOT NULL,
	[EsEcNo] [nvarchar](20) NOT NULL,
	[EsModel] [nvarchar](200) NOT NULL,
	[EsItem] [nvarchar](20) NOT NULL,
	[EsSubItem] [nvarchar](20) NULL,
	[EsOldItem] [nvarchar](20) NULL,
	[EsOldItemText] [nvarchar](40) NULL,
	[EsOldUsageQty] [decimal](18, 2) NOT NULL,
	[EsOldSetLoc] [nvarchar](20) NULL,
	[EsNewItem] [nvarchar](20) NULL,
	[EsNewItemText] [nvarchar](40) NULL,
	[EsNewUsageQty] [decimal](18, 2) NOT NULL,
	[EsNewSetLoc] [nvarchar](20) NULL,
	[EsBomNo] [nvarchar](4) NULL,
	[EsChange] [nvarchar](4) NULL,
	[Eslocal] [nvarchar](4) NULL,
	[Esnote] [nvarchar](4) NULL,
	[EsOldProcess] [nvarchar](4) NULL,
	[EsBomDate] [date] NOT NULL,
	[EmEcImpDept] [nvarchar](50) NOT NULL,
	[EsPurType] [nvarchar](1) NOT NULL,
	[EsSloc] [nvarchar](4) NOT NULL,
	[EsInsmk] [nvarchar](1) NULL,
	[EsMstae] [nvarchar](4) NULL,
	[EsSopStae] [tinyint] NOT NULL,
	[EsOldCurrStock] [decimal](18, 2) NOT NULL,
	[EsNewCurrStock] [decimal](18, 2) NOT NULL,
	[EsPurEntryDate] [date] NULL,
	[EsSupplier] [nvarchar](20) NULL,
	[EsPurOrder] [nvarchar](20) NULL,
	[EsPurNote] [nvarchar](255) NULL,
	[EsPurCreator] [nvarchar](50) NULL,
	[EsPurCreateTime] [datetime] NULL,
	[EsPurModifier] [nvarchar](50) NULL,
	[EsPurModifyTime] [datetime] NULL,
	[EsPmcEntryDate] [date] NULL,
	[EsPmcLot] [nvarchar](255) NULL,
	[EsPmcMemo] [nvarchar](255) NULL,
	[EsPmcNote] [nvarchar](255) NULL,
	[EsPmcCreator] [nvarchar](50) NULL,
	[EsPmcCreateTime] [datetime] NULL,
	[EsPmcModifier] [nvarchar](50) NULL,
	[EsPmcModifyTime] [datetime] NULL,
	[EsIqcEntryDate] [date] NULL,
	[EsIqcOrder] [nvarchar](20) NULL,
	[EsIqcNote] [nvarchar](255) NULL,
	[EsIqcCreator] [nvarchar](50) NULL,
	[EsIqcCreateTime] [datetime] NULL,
	[EsIqcModifier] [nvarchar](50) NULL,
	[EsIqcModifyTime] [datetime] NULL,
	[EsMmEntryDate] [date] NULL,
	[EsMmLot] [nvarchar](255) NULL,
	[EsMmMocNo] [nvarchar](200) NULL,
	[EsMmNote] [nvarchar](255) NULL,
	[EsMmCreator] [nvarchar](50) NULL,
	[EsMmCreateTime] [datetime] NULL,
	[EsMmModifier] [nvarchar](50) NULL,
	[EsMmModifyTime] [datetime] NULL,
	[EsPpEntryDate] [date] NULL,
	[EsPpLine] [nvarchar](20) NULL,
	[EsPpLot] [nvarchar](255) NULL,
	[EsPpNote] [nvarchar](255) NULL,
	[EsPpCreator] [nvarchar](50) NULL,
	[EsPpCreateTime] [datetime] NULL,
	[EsPpModifier] [nvarchar](50) NULL,
	[EsPpModifyTime] [datetime] NULL,
	[EsPcbaEntryDate] [date] NULL,
	[EsPcbaLine] [nvarchar](20) NULL,
	[EsPcbaLot] [nvarchar](255) NULL,
	[EsPcbaNote] [nvarchar](255) NULL,
	[EsPcbaCreator] [nvarchar](50) NULL,
	[EsPcbaCreateTime] [datetime] NULL,
	[EsPcbaModifier] [nvarchar](50) NULL,
	[EsPcbaModifyTime] [datetime] NULL,
	[EsQaEntryDate] [date] NULL,
	[EsQaLot] [nvarchar](255) NULL,
	[EsQaNote] [nvarchar](255) NULL,
	[EsQaCreator] [nvarchar](50) NULL,
	[EsQaCreateTime] [datetime] NULL,
	[EsQaModifier] [nvarchar](50) NULL,
	[EsQaModifyTime] [datetime] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_ec_slave] PRIMARY KEY CLUSTERED 
(
	[EsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_slv_source]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_slv_source]',N'U') is not NULL DROP TABLE [pp_ec_slv_source]
GO
CREATE TABLE [dbo].[pp_ec_slv_source](
	[GUID] [uniqueidentifier] NOT NULL,
	[D_SAP_ZPABD_S001] [nvarchar](6) NULL,
	[D_SAP_ZPABD_S002] [nvarchar](20) NULL,
	[D_SAP_ZPABD_S003] [nvarchar](20) NULL,
	[D_SAP_ZPABD_S004] [nvarchar](20) NULL,
	[D_SAP_ZPABD_S005] [nvarchar](40) NULL,
	[D_SAP_ZPABD_S006] [decimal](18, 2) NOT NULL,
	[D_SAP_ZPABD_S007] [nvarchar](40) NULL,
	[D_SAP_ZPABD_S008] [nvarchar](20) NULL,
	[D_SAP_ZPABD_S009] [nvarchar](40) NULL,
	[D_SAP_ZPABD_S010] [decimal](18, 2) NOT NULL,
	[D_SAP_ZPABD_S011] [nvarchar](40) NULL,
	[D_SAP_ZPABD_S012] [nvarchar](4) NULL,
	[D_SAP_ZPABD_S013] [nvarchar](4) NULL,
	[D_SAP_ZPABD_S014] [nvarchar](4) NULL,
	[D_SAP_ZPABD_S015] [nvarchar](4) NULL,
	[D_SAP_ZPABD_S016] [nvarchar](4) NULL,
	[D_SAP_ZPABD_S017] [date] NULL,
	[IsSolved] [tinyint] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.PP_SapEcnSub] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_ec_sop]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_ec_sop]',N'U') is not NULL DROP TABLE [pp_ec_sop]
GO
CREATE TABLE [dbo].[pp_ec_sop](
	[EsId] [uniqueidentifier] NOT NULL,
	[EsIssueDate] [date] NULL,
	[EsEcNo] [nvarchar](20) NULL,
	[EsEntryDate] [date] NOT NULL,
	[EsAssigned] [nvarchar](50) NULL,
	[EsModel] [nvarchar](200) NULL,
	[EsItem] [nvarchar](20) NULL,
	[EsPeaAssigned] [nvarchar](50) NULL,
	[IsPeaModifysop] [varchar](1) NOT NULL,
	[EsPeaDate] [nvarchar](8) NULL,
	[EsPeaNote] [nvarchar](255) NULL,
	[EmPeaDocNo] [nvarchar](50) NULL,
	[EmPeaDoc] [nvarchar](500) NULL,
	[EsPeaModifier] [nvarchar](50) NULL,
	[EsPeaModifyTime] [datetime] NULL,
	[EsPepAssigned] [nvarchar](50) NULL,
	[IsPepModifysop] [varchar](1) NOT NULL,
	[EsPepDate] [nvarchar](8) NULL,
	[EsPepNote] [nvarchar](255) NULL,
	[EmPepDocNo] [nvarchar](50) NULL,
	[EmPepDoc] [nvarchar](500) NULL,
	[EsPepModifier] [nvarchar](50) NULL,
	[EsPepModifyTime] [datetime] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_ec_sop] PRIMARY KEY CLUSTERED 
(
	[EsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_lines]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_lines]',N'U') is not NULL DROP TABLE [pp_lines]
GO
CREATE TABLE [dbo].[pp_lines](
	[PlId] [uniqueidentifier] NOT NULL,
	[PlLineType] [nvarchar](200) NULL,
	[PlLineCode] [nvarchar](200) NULL,
	[PlLineName] [nvarchar](200) NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_lines] PRIMARY KEY CLUSTERED 
(
	[PlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_manhours]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_manhours]',N'U') is not NULL DROP TABLE [pp_manhours]
GO
CREATE TABLE [dbo].[pp_manhours](
	[MhId] [uniqueidentifier] NOT NULL,
	[MhEffDate] [date] NULL,
	[MhPlant] [nvarchar](4) NOT NULL,
	[MhModelType] [nvarchar](40) NOT NULL,
	[MhRegionType] [nvarchar](20) NULL,
	[MhItem] [nvarchar](20) NULL,
	[MhItemText] [nvarchar](40) NULL,
	[MhWcName] [nvarchar](40) NOT NULL,
	[MhWcText] [nvarchar](40) NULL,
	[MhStdShort] [decimal](18, 2) NOT NULL,
	[MhShortUnit] [nvarchar](31) NULL,
	[MhToMinRate] [decimal](18, 5) NOT NULL,
	[MhStdTime] [decimal](18, 2) NOT NULL,
	[MhTimeUnit] [nvarchar](3) NULL,
	[isDelete] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_manhours] PRIMARY KEY CLUSTERED 
(
	[MhId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_mfg_order]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_mfg_order]',N'U') is not NULL DROP TABLE [pp_mfg_order]
GO
CREATE TABLE [dbo].[pp_mfg_order](
	[MoId] [uniqueidentifier] NOT NULL,
	[MoPlant] [nvarchar](4) NOT NULL,
	[MoOrderType] [nvarchar](4) NOT NULL,
	[MoOrderNo] [nvarchar](7) NOT NULL,
	[MoOrderItem] [nvarchar](20) NOT NULL,
	[MoOrderlot] [nvarchar](20) NOT NULL,
	[MoOrderQty] [decimal](18, 2) NOT NULL,
	[MoOrderProQty] [decimal](18, 2) NOT NULL,
	[MoOrderDate] [date] NOT NULL,
	[MoOrderRoute] [nvarchar](8) NOT NULL,
	[MoOrderSerial] [nvarchar](50) NOT NULL,
	[isDelete] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_mfg_order] PRIMARY KEY CLUSTERED 
(
	[MoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_output_master]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_output_master]',N'U') is not NULL DROP TABLE [pp_output_master]
GO
CREATE TABLE [dbo].[pp_output_master](
	[PomId] [bigint] IDENTITY(1,1) NOT NULL,
	[PomGuid] [uniqueidentifier] NOT NULL,
	[PomOrder] [nvarchar](20) NOT NULL,
	[PomOrderQty] [decimal](18, 2) NOT NULL,
	[PomOrderSerial] [nvarchar](200) NOT NULL,
	[PomMflot] [nvarchar](20) NOT NULL,
	[PomModelName] [nvarchar](50) NOT NULL,
	[PomMfItem] [nvarchar](20) NOT NULL,
	[PomMfDate] [date] NOT NULL,
	[PomLineName] [nvarchar](20) NOT NULL,
	[PomDirect] [int] NOT NULL,
	[PomIndirect] [int] NOT NULL,
	[PomStdTime] [decimal](18, 2) NOT NULL,
	[PomStdOutput] [decimal](18, 2) NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_output_master] PRIMARY KEY CLUSTERED 
(
	[PomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pp_output_slave]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[pp_output_slave]',N'U') is not NULL DROP TABLE [pp_output_slave]
GO
CREATE TABLE [dbo].[pp_output_slave](
	[PosId] [bigint] IDENTITY(1,1) NOT NULL,
	[PomGuid] [uniqueidentifier] NOT NULL,
	[PosStartEndTime] [nvarchar](11) NULL,
	[PosRealOutput] [int] NOT NULL,
	[PosLineStopTime] [int] NOT NULL,
	[PosStopCause] [nvarchar](200) NULL,
	[PosStopMemo] [nvarchar](200) NULL,
	[PosBadCause] [nvarchar](300) NULL,
	[PosBadMemo] [nvarchar](300) NULL,
	[PosRealTime] [int] NOT NULL,
	[PosRealWork] [decimal](18, 2) NOT NULL,
	[PosRealWorkDiff] [decimal](18, 2) NOT NULL,
	[PosRealOutputDiff] [decimal](18, 2) NOT NULL,
	[PosAchRatio] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.pp_output_slave] PRIMARY KEY CLUSTERED 
(
	[PosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_check_aql]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_check_aql]',N'U') is not NULL DROP TABLE [qm_check_aql]
GO
CREATE TABLE [dbo].[qm_check_aql](
	[QcaqlGuid] [uniqueidentifier] NOT NULL,
	[QcaqlLevel] [nvarchar](40) NOT NULL,
	[QcaqlRange] [nvarchar](40) NOT NULL,
	[QcaqlRangeMinmum] [int] NOT NULL,
	[QcaqlRangeMaximum] [int] NOT NULL,
	[QcaqlSamplesCode] [nvarchar](4) NOT NULL,
	[QcaqlSamplesQty] [int] NOT NULL,
	[QcaqlAcQty] [int] NOT NULL,
	[QcaqlReQty] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_check_aql] PRIMARY KEY CLUSTERED 
(
	[QcaqlGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_complaints]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_complaints]',N'U') is not NULL DROP TABLE [qm_complaints]
GO
CREATE TABLE [dbo].[qm_complaints](
	[QmCcId] [uniqueidentifier] NOT NULL,
	[QmCcDocNo] [nvarchar](20) NOT NULL,
	[QmCcIssuesNo] [nvarchar](20) NOT NULL,
	[QmCcCustomer] [nvarchar](20) NOT NULL,
	[QmCcModel] [nvarchar](40) NOT NULL,
	[QmCcItem] [nvarchar](20) NOT NULL,
	[QmCcRegion] [nvarchar](20) NOT NULL,
	[QmCcOrder] [nvarchar](20) NULL,
	[QmCcReceivingDate] [nvarchar](8) NOT NULL,
	[QmCcFaultQty] [int] NOT NULL,
	[QmCcIssues] [nvarchar](2000) NULL,
	[QmCcSerialno] [nvarchar](200) NOT NULL,
	[QmCcReferenceDocs] [nvarchar](200) NULL,
	[QmCcFaultDescription] [nvarchar](2000) NOT NULL,
	[QmCcRootcauseanalysis] [nvarchar](2000) NOT NULL,
	[qaModifier] [nvarchar](50) NULL,
	[qaModifyTime] [datetime] NULL,
	[QmCcLine] [nvarchar](20) NULL,
	[QmCcProcessingDate] [nvarchar](8) NULL,
	[QmCcDescription] [nvarchar](4000) NULL,
	[QmCcCauseAnalysis] [nvarchar](4000) NULL,
	[QmCcOperator] [nvarchar](40) NULL,
	[QmCcStation] [nvarchar](4000) NULL,
	[QmCcLot] [nvarchar](40) NULL,
	[QmCcMeasures] [nvarchar](4000) NULL,
	[QmCcReformDocs] [nvarchar](200) NULL,
	[p1dModifier] [nvarchar](50) NULL,
	[p1dModifyTime] [datetime] NULL,
	[QmCcAdmitDept] [nvarchar](40) NOT NULL,
	[QmCcAdmitDate] [nvarchar](8) NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_complaints] PRIMARY KEY CLUSTERED 
(
	[QmCcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_improvement_replyletter]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_improvement_replyletter]',N'U') is not NULL DROP TABLE [qm_improvement_replyletter]
GO
CREATE TABLE [dbo].[qm_improvement_replyletter](
	[QirdGuid] [uniqueidentifier] NOT NULL,
	[QirdInspector] [nvarchar](20) NOT NULL,
	[QirdLine] [nvarchar](10) NOT NULL,
	[QirdOrder] [nvarchar](20) NOT NULL,
	[QirdModels] [nvarchar](20) NULL,
	[QirdMaterial] [nvarchar](20) NOT NULL,
	[QirdRegion] [nvarchar](20) NULL,
	[QirdCheckDate] [nvarchar](8) NOT NULL,
	[QirdProLot] [nvarchar](20) NULL,
	[QirdProSerial] [nvarchar](50) NULL,
	[QirdRejectQty] [decimal](18, 2) NOT NULL,
	[QirdJudgmentLevel] [nvarchar](10) NOT NULL,
	[QirdCheckNotes] [nvarchar](300) NOT NULL,
	[QirdPersonnel] [nvarchar](20) NOT NULL,
	[QirdDate] [nvarchar](8) NULL,
	[QirdDirectreason] [nvarchar](300) NULL,
	[QirdIndirectreason] [nvarchar](300) NULL,
	[QirdDisposal] [nvarchar](300) NULL,
	[QirdDirectsolutions] [nvarchar](300) NULL,
	[QirdIndirectsolutions] [nvarchar](300) NULL,
	[QirdVerify] [nvarchar](20) NOT NULL,
	[QirdCarryoutdate] [nvarchar](8) NULL,
	[QirdCarryoutverify] [int] NOT NULL,
	[QirdSolutionsverify] [nvarchar](300) NULL,
	[QirdNotes] [nvarchar](300) NULL,
	[QirdIssueno] [nvarchar](20) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_improvement_replyletter] PRIMARY KEY CLUSTERED 
(
	[QirdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_incoming]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_incoming]',N'U') is not NULL DROP TABLE [qm_incoming]
GO
CREATE TABLE [dbo].[qm_incoming](
	[qmInGuid] [uniqueidentifier] NOT NULL,
	[qmInPurOrder] [nvarchar](20) NOT NULL,
	[qmInMaterial] [nvarchar](20) NOT NULL,
	[qmInPurOrderQty] [decimal](18, 2) NOT NULL,
	[qmInPurDate] [date] NOT NULL,
	[qmInInspector] [nvarchar](20) NOT NULL,
	[qmInCheckDate] [date] NOT NULL,
	[qmInInspectingItem] [nvarchar](50) NOT NULL,
	[qmInSamplingLevel] [nvarchar](4) NOT NULL,
	[qmInCheckMethod] [nvarchar](4) NOT NULL,
	[qmInSamplingQty] [decimal](18, 2) NOT NULL,
	[qmInJudgment] [nvarchar](4) NOT NULL,
	[qmInJudgmentLevel] [nvarchar](10) NOT NULL,
	[qmInRejectQty] [decimal](18, 2) NOT NULL,
	[qmInSpecialNotes] [nvarchar](500) NULL,
	[qmInAcceptQty] [decimal](18, 2) NOT NULL,
	[qmInCheckoutSequence] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_incoming] PRIMARY KEY CLUSTERED 
(
	[qmInGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_inspecting_item]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_inspecting_item]',N'U') is not NULL DROP TABLE [qm_inspecting_item]
GO
CREATE TABLE [dbo].[qm_inspecting_item](
	[qmInsItemGuid] [uniqueidentifier] NOT NULL,
	[qmInsItemCode] [nvarchar](20) NOT NULL,
	[qmInsItemName] [nvarchar](10) NOT NULL,
	[qmInsItemType] [nvarchar](20) NOT NULL,
	[qmInsItemQcTool] [nvarchar](20) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_inspecting_item] PRIMARY KEY CLUSTERED 
(
	[qmInsItemGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_outgoing]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_outgoing]',N'U') is not NULL DROP TABLE [qm_outgoing]
GO
CREATE TABLE [dbo].[qm_outgoing](
	[qmOutGuid] [uniqueidentifier] NOT NULL,
	[qmOutProOrder] [nvarchar](20) NOT NULL,
	[qmOutProLine] [nvarchar](10) NOT NULL,
	[qmOutProModels] [nvarchar](20) NULL,
	[qmOutProMaterial] [nvarchar](20) NOT NULL,
	[qmOutProLot] [nvarchar](20) NOT NULL,
	[qmOutProSerial] [nvarchar](50) NOT NULL,
	[qmOutProQty] [decimal](18, 2) NOT NULL,
	[qmOutProDate] [date] NOT NULL,
	[qmOutInspector] [nvarchar](20) NOT NULL,
	[qmOutCheckDate] [date] NOT NULL,
	[qmOutInspectingItem] [nvarchar](50) NOT NULL,
	[qmOutSamplingLevel] [nvarchar](4) NOT NULL,
	[qmOutCheckMethod] [nvarchar](4) NOT NULL,
	[qmOutSamplingQty] [decimal](18, 2) NOT NULL,
	[qmOutJudgment] [nvarchar](4) NOT NULL,
	[qmOutJudgmentLevel] [nvarchar](10) NOT NULL,
	[qmOutRejectQty] [decimal](18, 2) NOT NULL,
	[qmOutCheckNotes] [nvarchar](500) NOT NULL,
	[qmOutSpecialNotes] [nvarchar](500) NULL,
	[qmOutAcceptQty] [decimal](18, 2) NOT NULL,
	[qmOutOrderQty] [decimal](18, 2) NOT NULL,
	[qmOutCheckoutSequence] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_Outgoing] PRIMARY KEY CLUSTERED 
(
	[qmOutGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_qccost_operation]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_qccost_operation]',N'U') is not NULL DROP TABLE [qm_qccost_operation]
GO
CREATE TABLE [dbo].[qm_qccost_operation](
	[QcodGuid] [uniqueidentifier] NOT NULL,
	[Qcod001] [nvarchar](6) NOT NULL,
	[Qcod002] [decimal](18, 2) NOT NULL,
	[Qcod003] [decimal](18, 2) NOT NULL,
	[Qcod004] [bigint] NOT NULL,
	[Qcod005] [decimal](18, 2) NOT NULL,
	[Qcod006] [decimal](18, 2) NOT NULL,
	[Qcod007] [nvarchar](500) NULL,
	[Qcod008] [decimal](18, 2) NOT NULL,
	[Qcod009] [bigint] NOT NULL,
	[Qcod010] [decimal](18, 2) NOT NULL,
	[Qcod011] [nvarchar](500) NULL,
	[Qcod012] [decimal](18, 2) NOT NULL,
	[Qcod013] [bigint] NOT NULL,
	[Qcod014] [decimal](18, 2) NOT NULL,
	[Qcod015] [decimal](18, 2) NOT NULL,
	[Qcod016] [nvarchar](500) NULL,
	[Qcod017] [decimal](18, 2) NOT NULL,
	[Qcod018] [bigint] NOT NULL,
	[Qcod019] [decimal](18, 2) NOT NULL,
	[Qcod020] [nvarchar](500) NULL,
	[Qcodqcr] [nvarchar](50) NULL,
	[Qcod021] [decimal](18, 2) NOT NULL,
	[Qcod022] [bigint] NOT NULL,
	[Qcod023] [decimal](18, 2) NOT NULL,
	[Qcod024] [nvarchar](500) NULL,
	[Qcod025] [decimal](18, 2) NOT NULL,
	[Qcod026] [int] NOT NULL,
	[Qcod027] [decimal](18, 2) NOT NULL,
	[Qcod028] [nvarchar](500) NULL,
	[Qcod029] [decimal](18, 2) NOT NULL,
	[Qcod030] [bigint] NOT NULL,
	[Qcod031] [decimal](18, 2) NOT NULL,
	[Qcod032] [nvarchar](500) NULL,
	[Qcod033] [decimal](18, 2) NOT NULL,
	[Qcod034] [bigint] NOT NULL,
	[Qcod035] [decimal](18, 2) NOT NULL,
	[Qcod036] [nvarchar](500) NULL,
	[Qcodqar] [nvarchar](50) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_qccost_operation] PRIMARY KEY CLUSTERED 
(
	[QcodGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_qccost_rework]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_qccost_rework]',N'U') is not NULL DROP TABLE [qm_qccost_rework]
GO
CREATE TABLE [dbo].[qm_qccost_rework](
	[QcrdGuid] [uniqueidentifier] NOT NULL,
	[Qcrd001] [nvarchar](8) NULL,
	[Qcrd002] [nvarchar](50) NULL,
	[Qcrd003] [nvarchar](50) NULL,
	[Qcrd004] [decimal](18, 2) NOT NULL,
	[Qcrd005] [decimal](18, 2) NOT NULL,
	[Qcrd006] [nvarchar](500) NULL,
	[Qcrd007] [decimal](18, 2) NOT NULL,
	[Qcrd008] [bigint] NOT NULL,
	[Qcrd009] [int] NOT NULL,
	[Qcrd010] [int] NOT NULL,
	[Qcrd011] [bigint] NOT NULL,
	[Qcrd012] [decimal](18, 2) NOT NULL,
	[Qcrd013] [decimal](18, 2) NOT NULL,
	[Qcrd014] [bigint] NOT NULL,
	[Qcrd015] [decimal](18, 2) NOT NULL,
	[Qcrd016] [int] NOT NULL,
	[Qcrd017] [nvarchar](500) NULL,
	[Qcrdqarec] [nvarchar](50) NULL,
	[Qcrd018] [nvarchar](8) NULL,
	[Qcrd019] [nvarchar](500) NULL,
	[Qcrd020] [decimal](18, 2) NOT NULL,
	[Qcrd021] [bigint] NOT NULL,
	[Qcrd022] [bigint] NOT NULL,
	[Qcrd023] [decimal](18, 2) NOT NULL,
	[Qcrd024] [decimal](18, 2) NOT NULL,
	[Qcrd025] [decimal](18, 2) NOT NULL,
	[Qcrd026] [nvarchar](500) NULL,
	[Qcrd027] [decimal](18, 2) NOT NULL,
	[Qcrd028] [nvarchar](50) NULL,
	[Qcrd029] [nvarchar](50) NULL,
	[Qcrd030] [decimal](18, 2) NOT NULL,
	[Qcrd031] [decimal](18, 2) NOT NULL,
	[Qcrd032] [nvarchar](500) NULL,
	[Qcrdmcrec] [nvarchar](50) NULL,
	[Qcrd033] [nvarchar](8) NULL,
	[Qcrd034] [nvarchar](500) NULL,
	[Qcrd035] [decimal](18, 2) NOT NULL,
	[Qcrd036] [bigint] NOT NULL,
	[Qcrd037] [bigint] NOT NULL,
	[Qcrd038] [decimal](18, 2) NOT NULL,
	[Qcrd039] [decimal](18, 2) NOT NULL,
	[Qcrd040] [decimal](18, 2) NOT NULL,
	[Qcrd041] [nvarchar](500) NULL,
	[Qcrd042] [decimal](18, 2) NOT NULL,
	[Qcrd043] [nvarchar](50) NULL,
	[Qcrd044] [nvarchar](50) NULL,
	[Qcrd045] [decimal](18, 2) NOT NULL,
	[Qcrd046] [decimal](18, 2) NOT NULL,
	[Qcrd047] [nvarchar](500) NULL,
	[Qcrdassrec] [nvarchar](50) NULL,
	[Qcrd048] [nvarchar](8) NULL,
	[Qcrd049] [nvarchar](500) NULL,
	[Qcrd050] [decimal](18, 2) NOT NULL,
	[Qcrd051] [bigint] NOT NULL,
	[Qcrd052] [bigint] NOT NULL,
	[Qcrd053] [decimal](18, 2) NOT NULL,
	[Qcrd054] [decimal](18, 2) NOT NULL,
	[Qcrd055] [decimal](18, 2) NOT NULL,
	[Qcrd056] [nvarchar](500) NULL,
	[Qcrd057] [decimal](18, 2) NOT NULL,
	[Qcrd058] [nvarchar](50) NULL,
	[Qcrd059] [nvarchar](50) NULL,
	[Qcrd060] [decimal](18, 2) NOT NULL,
	[Qcrd061] [decimal](18, 2) NOT NULL,
	[Qcrd062] [nvarchar](500) NULL,
	[Qcrdpcbrec] [nvarchar](50) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_qccost_rework] PRIMARY KEY CLUSTERED 
(
	[QcrdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_qccost_waste]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_qccost_waste]',N'U') is not NULL DROP TABLE [qm_qccost_waste]
GO
CREATE TABLE [dbo].[qm_qccost_waste](
	[QcwdGuid] [uniqueidentifier] NOT NULL,
	[Qcwd001] [nvarchar](8) NULL,
	[Qcwd002] [nvarchar](20) NULL,
	[Qcwd003] [decimal](18, 2) NOT NULL,
	[Qcwd004] [nvarchar](15) NULL,
	[Qcwd005] [nvarchar](100) NULL,
	[Qcwd006] [nvarchar](300) NULL,
	[Qcwd007] [decimal](18, 2) NOT NULL,
	[Qcwd008] [decimal](18, 2) NOT NULL,
	[Qcwd009] [decimal](18, 2) NOT NULL,
	[Qcwd010] [decimal](18, 2) NOT NULL,
	[Qcwd011] [decimal](18, 2) NOT NULL,
	[Qcwd012] [decimal](18, 2) NOT NULL,
	[Qcwd013] [int] NOT NULL,
	[Qcwd014] [decimal](18, 2) NOT NULL,
	[Qcwd015] [decimal](18, 2) NOT NULL,
	[Qcwd016] [nvarchar](200) NULL,
	[Qcwdrec] [nvarchar](50) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_qccost_waste] PRIMARY KEY CLUSTERED 
(
	[QcwdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_serial]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_serial]',N'U') is not NULL DROP TABLE [qm_serial]
GO
CREATE TABLE [dbo].[qm_serial](
	[QmId] [uniqueidentifier] NOT NULL,
	[QmInScan] [nvarchar](50) NOT NULL,
	[QmInDate] [date] NULL,
	[QmInQty] [int] NULL,
	[QmInHostname] [nvarchar](20) NULL,
	[QmInHostip] [nvarchar](20) NULL,
	[QmInHostmac] [nvarchar](20) NULL,
	[QmInUser] [nvarchar](20) NULL,
	[QmInTime] [datetime] NULL,
	[QmOutBill] [nvarchar](50) NULL,
	[QmOutTransport] [nvarchar](50) NULL,
	[QmOutScan] [nvarchar](50) NULL,
	[QmOutDate] [date] NULL,
	[QmOutQty] [int] NULL,
	[QmOutRegion] [nvarchar](20) NULL,
	[QmOutHostname] [nvarchar](20) NULL,
	[QmOutHostip] [nvarchar](20) NULL,
	[QmOutHostmac] [nvarchar](20) NULL,
	[QmOutUser] [nvarchar](20) NULL,
	[QmOutTime] [datetime] NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK__qm_serial] PRIMARY KEY CLUSTERED 
(
	[QmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qm_unqualified_contactletter]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[qm_unqualified_contactletter]',N'U') is not NULL DROP TABLE [qm_unqualified_contactletter]
GO
CREATE TABLE [dbo].[qm_unqualified_contactletter](
	[QucdGuid] [uniqueidentifier] NOT NULL,
	[QucdInspector] [nvarchar](20) NOT NULL,
	[QucdLine] [nvarchar](10) NOT NULL,
	[QucdOrder] [nvarchar](20) NOT NULL,
	[QucdModels] [nvarchar](20) NULL,
	[QucdMaterial] [nvarchar](20) NOT NULL,
	[QucdRegion] [nvarchar](20) NULL,
	[QucdCheckDate] [nvarchar](8) NOT NULL,
	[QucdProLot] [nvarchar](20) NULL,
	[QucdProSerial] [nvarchar](50) NULL,
	[QucdRejectQty] [decimal](18, 2) NOT NULL,
	[QucdJudgmentLevel] [nvarchar](10) NOT NULL,
	[QucdCheckNotes] [nvarchar](300) NOT NULL,
	[QucdIssueno] [nvarchar](20) NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](500) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.qm_unqualified_contactletter] PRIMARY KEY CLUSTERED 
(
	[QucdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sd_client]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[sd_client]',N'U') is not NULL DROP TABLE [sd_client]
GO
CREATE TABLE [dbo].[sd_client](
	[ScId] [uniqueidentifier] NOT NULL,
	[ScOrg] [nvarchar](4) NOT NULL,
	[ScPlant] [nvarchar](4) NOT NULL,
	[ScIndustryType] [nvarchar](1) NOT NULL,
	[ScEnterpriseNature] [nvarchar](1) NOT NULL,
	[ScCode] [nvarchar](10) NOT NULL,
	[ScAbbr] [nvarchar](20) NOT NULL,
	[ScName] [nvarchar](100) NOT NULL,
	[ScEbe] [nvarchar](50) NOT NULL,
	[ScBusinessNo] [nvarchar](100) NOT NULL,
	[ScTaxNo] [nvarchar](100) NOT NULL,
	[ScTaxType] [nvarchar](2) NOT NULL,
	[ScMainBusiness] [nvarchar](200) NOT NULL,
	[ScCcy] [nvarchar](3) NOT NULL,
	[ScPayTerms] [nvarchar](4) NOT NULL,
	[ScPayMethod] [nvarchar](1) NOT NULL,
	[ScRecAccount] [nvarchar](6) NOT NULL,
	[ScTradeTerms] [nvarchar](3) NOT NULL,
	[ScShippingTerms] [nvarchar](3) NOT NULL,
	[ScCustomerGrade] [nvarchar](1) NULL,
	[ScCustomerCredit] [nvarchar](1) NULL,
	[ScFirstTransDate] [date] NULL,
	[ScLastTransDate] [date] NULL,
	[ScBankCode] [nvarchar](8) NOT NULL,
	[ScBankName] [nvarchar](255) NOT NULL,
	[ScBranchName] [nvarchar](255) NULL,
	[ScBankCountry] [nvarchar](2) NOT NULL,
	[ScBankState] [nvarchar](40) NOT NULL,
	[ScBankCity] [nvarchar](40) NOT NULL,
	[ScBankCounty] [nvarchar](40) NOT NULL,
	[ScBankAddr] [nvarchar](40) NOT NULL,
	[ScBankAddr1] [nvarchar](40) NULL,
	[ScBankAddr2] [nvarchar](40) NULL,
	[ScBankAccount] [nvarchar](20) NOT NULL,
	[ScBankSwiftNo] [nvarchar](50) NULL,
	[ScRegionCode] [nvarchar](2) NULL,
	[ScState] [nvarchar](40) NULL,
	[ScCity] [nvarchar](40) NULL,
	[ScCounty] [nvarchar](40) NULL,
	[ScAddr] [nvarchar](40) NOT NULL,
	[ScAddr1] [nvarchar](40) NULL,
	[ScAddr2] [nvarchar](40) NULL,
	[ScContacts] [nvarchar](200) NULL,
	[ScEmail] [nvarchar](50) NULL,
	[ScTelNo] [nvarchar](16) NULL,
	[ScFaxNp] [nvarchar](16) NULL,
	[ScPhoneNo] [nvarchar](16) NULL,
	[IsFroze] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[ReMark] [nvarchar](200) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.sd_client] PRIMARY KEY CLUSTERED 
(
	[ScId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sd_customer]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[sd_customer]',N'U') is not NULL DROP TABLE [sd_customer]
GO
CREATE TABLE [dbo].[sd_customer](
	[ScId] [uniqueidentifier] NOT NULL,
	[ScOrg] [nvarchar](4) NOT NULL,
	[ScPlant] [nvarchar](4) NOT NULL,
	[ScIndustryType] [nvarchar](1) NOT NULL,
	[ScEnterpriseNature] [nvarchar](1) NOT NULL,
	[ScCode] [nvarchar](10) NOT NULL,
	[ScAbbr] [nvarchar](20) NOT NULL,
	[ScName] [nvarchar](100) NOT NULL,
	[ScEbe] [nvarchar](50) NOT NULL,
	[ScBusinessNo] [nvarchar](100) NOT NULL,
	[ScTaxNo] [nvarchar](100) NOT NULL,
	[ScTaxType] [nvarchar](2) NOT NULL,
	[ScMainBusiness] [nvarchar](200) NOT NULL,
	[ScCcy] [nvarchar](3) NOT NULL,
	[ScPayTerms] [nvarchar](4) NOT NULL,
	[ScPayMethod] [nvarchar](1) NOT NULL,
	[ScRecAccount] [nvarchar](6) NOT NULL,
	[ScTradeTerms] [nvarchar](3) NOT NULL,
	[ScShippingTerms] [nvarchar](3) NOT NULL,
	[ScCustomerGrade] [nvarchar](1) NULL,
	[ScCustomerCredit] [nvarchar](1) NULL,
	[ScFirstTransDate] [date] NULL,
	[ScLastTransDate] [date] NULL,
	[ScBankCode] [nvarchar](8) NOT NULL,
	[ScBankName] [nvarchar](255) NOT NULL,
	[ScBranchName] [nvarchar](255) NULL,
	[ScBankCountry] [nvarchar](2) NOT NULL,
	[ScBankState] [nvarchar](40) NOT NULL,
	[ScBankCity] [nvarchar](40) NOT NULL,
	[ScBankCounty] [nvarchar](40) NOT NULL,
	[ScBankAddr] [nvarchar](40) NOT NULL,
	[ScBankAddr1] [nvarchar](40) NULL,
	[ScBankAddr2] [nvarchar](40) NULL,
	[ScBankAccount] [nvarchar](20) NOT NULL,
	[ScBankSwiftNo] [nvarchar](50) NULL,
	[ScRegionCode] [nvarchar](2) NULL,
	[ScState] [nvarchar](40) NULL,
	[ScCity] [nvarchar](40) NULL,
	[ScCounty] [nvarchar](40) NULL,
	[ScAddr] [nvarchar](40) NOT NULL,
	[ScAddr1] [nvarchar](40) NULL,
	[ScAddr2] [nvarchar](40) NULL,
	[ScContacts] [nvarchar](200) NULL,
	[ScEmail] [nvarchar](50) NULL,
	[ScTelNo] [nvarchar](16) NULL,
	[ScFaxNp] [nvarchar](16) NULL,
	[ScPhoneNo] [nvarchar](16) NULL,
	[IsFroze] [int] NOT NULL,
	[UDF01] [nvarchar](200) NULL,
	[UDF02] [nvarchar](200) NULL,
	[UDF03] [nvarchar](200) NULL,
	[UDF04] [nvarchar](200) NULL,
	[UDF05] [nvarchar](200) NULL,
	[UDF06] [nvarchar](200) NULL,
	[UDF51] [decimal](18, 2) NOT NULL,
	[UDF52] [decimal](18, 2) NOT NULL,
	[UDF53] [decimal](18, 2) NOT NULL,
	[UDF54] [decimal](18, 2) NOT NULL,
	[UDF55] [decimal](18, 2) NOT NULL,
	[UDF56] [decimal](18, 2) NOT NULL,
	[ReMark] [nvarchar](200) NULL,
	 [IsDeleted] [int] NOT NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.sd_customer] PRIMARY KEY CLUSTERED 
(
	[ScId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sd_sales_accdoc]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[sd_sales_accdoc]',N'U') is not NULL DROP TABLE [sd_sales_accdoc]
GO
CREATE TABLE [dbo].[sd_sales_accdoc](
	[SpId] [uniqueidentifier] NOT NULL,
	[SpPlnt] [nvarchar](4) NOT NULL,
	[SpFy] [nvarchar](6) NOT NULL,
	[SpYm] [nvarchar](6) NOT NULL,
	[SpAccDocNo] [nvarchar](10) NOT NULL,
	[SpAccDocLineNo] [nvarchar](4) NOT NULL,
	[SpCustomerCode] [nvarchar](10) NOT NULL,
	[SpPrctr] [nvarchar](4) NOT NULL,
	[SpSalesItem] [nvarchar](20) NOT NULL,
	[SpAccountCode] [nvarchar](10) NOT NULL,
	[SpSalesQty] [decimal](18, 2) NOT NULL,
	[SpSalesUnit] [nvarchar](2) NOT NULL,
	[SpOriginalAmount] [decimal](18, 2) NOT NULL,
	[SpOriginalCcy] [nvarchar](4) NOT NULL,
	[SpLocalAmount] [decimal](18, 2) NOT NULL,
	[SpLocalCcy] [nvarchar](4) NOT NULL,
	[SpRefDocNo] [nvarchar](10) NOT NULL,
	[SpRefDocLineNo] [nvarchar](4) NOT NULL,
	[SpPostingDate] [date] NOT NULL,
	[SpPostingUser] [nvarchar](10) NOT NULL,
	[SpEntryDate] [date] NOT NULL,
	[SpEntryTime] [time](7) NOT NULL,
	[SpOrigin] [nvarchar](2) NOT NULL,
	[SpPgroup] [nvarchar](2) NOT NULL,
	[SpAccDocType] [nvarchar](10) NOT NULL,
	[SpAccDocText] [nvarchar](40) NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](400) NULL,
	[create_by] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_by] [nvarchar](50) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.sd_sales_accdoc] PRIMARY KEY CLUSTERED 
(
	[SpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sd_sellingprice]    Script Date: 2023/7/14 15:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if OBJECT_ID(N'[sd_sellingprice]',N'U') is not NULL DROP TABLE [sd_sellingprice]
GO
CREATE TABLE [dbo].[sd_sellingprice](
	[SpId] [uniqueidentifier] NOT NULL,
	[SpPlnt] [nvarchar](4) NOT NULL,
	[SpFy] [nvarchar](6) NOT NULL,
	[SpYm] [nvarchar](6) NOT NULL,
	[SpItem] [nvarchar](20) NOT NULL,
	[SpItemText] [nvarchar](40) NOT NULL,
	[SpOriginalFob] [decimal](18, 2) NOT NULL,
	[SpOriginalCcy] [nvarchar](3) NOT NULL,
	[SpOriginalPerUnit] [int] NOT NULL,
	[SpOriginalPrctr] [nvarchar](4) NOT NULL,
	[SpLocalFob] [decimal](18, 2) NOT NULL,
	[SpLocalCcy] [nvarchar](3) NOT NULL,
	[SpLocalPerUnit] [int] NOT NULL,
	[SpLocalPrctr] [nvarchar](4) NOT NULL,
	[SpEffDate] [date] NOT NULL,
	[SpExpDate] [date] NOT NULL,
	[SpBalancedate] [date] NOT NULL,
	 [IsDeleted] [int] NOT NULL,
	[ReMark] [nvarchar](400) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.sd_sellingprice] PRIMARY KEY CLUSTERED 
(
	[SpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[fico_asset] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_bom_costing] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[fico_budget_expense] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[fico_budget_overtime] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[fico_budget_staff] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_budgetactual_cost] ADD  DEFAULT ('0') FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_dept_consuming] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_exchange_rate] ADD  DEFAULT ((1)) FOR [ErStd]
GO
ALTER TABLE [dbo].[fico_exchange_rate] ADD  DEFAULT ((1)) FOR [ErRate]
GO
ALTER TABLE [dbo].[fico_exchange_rate] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_monthly_inventory] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[fico_period] ADD  DEFAULT ('0') FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_prctr] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_accounting_title] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[fico_wage_rates] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[inst_formula] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[inst_info] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_mara] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_marc] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_mats] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_mbew] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_po_residue] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [IsFroze]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_supplier] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [IsFroze]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[mm_vendor] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [title]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [userId]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [fmt_type]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [tags]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [hits]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [category_id]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [createTime]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [updateTime]
GO
ALTER TABLE [dbo].[office_article] ADD  DEFAULT (NULL) FOR [authorName]
GO
ALTER TABLE [dbo].[office_article_category] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[office_article_category] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [EeDepartmentId]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [EeTitlesId]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [EePostId]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [EePostLevel]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[office_ehr_employee] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[office_numbering_rules] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_cause_type] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_ec_digest] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_ec_ma_source] ADD  DEFAULT ((0)) FOR [IsSolved]
GO
ALTER TABLE [dbo].[pp_ec_ma_source] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [EmEcLossAmount]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [EsSopStae]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_ec_master] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [EsOldUsageQty]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [EsNewUsageQty]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [EsSopStae]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [EsOldCurrStock]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_ec_slave] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_ec_slv_source] ADD  DEFAULT ((0)) FOR [IsSolved]
GO
ALTER TABLE [dbo].[pp_ec_slv_source] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [IsPeaModifysop]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [IsPepModifysop]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_ec_sop] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_lines] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_manhours] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[pp_mfg_order] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_output_master] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[pp_output_slave] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_check_aql] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_complaints] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_improvement_replyletter] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_incoming] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_inspecting_item] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_outgoing] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_qccost_operation] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_qccost_rework] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_qccost_waste] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_serial] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[qm_unqualified_contactletter] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [IsFroze]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[sd_client] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [IsFroze]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF51]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF52]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF53]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF54]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF55]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [UDF56]
GO
ALTER TABLE [dbo].[sd_customer] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[sd_sellingprice] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaClassCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaAssetNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaCostCenter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaAssetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaAssetQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaAcquisitionPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资本化日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaCapitalizedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折旧价值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaDepreciationValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报废日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaScrapDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报废价值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaScrapValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaLocale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaEntity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有无' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaHaveorNot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaCheckedby'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'FaCheckedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定资产' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成品物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcBomItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcBomCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcCurrency'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'核算日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'BcBalancedate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bom成本核算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_bom_costing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaFm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaServiceLife'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaBudgetAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaActualAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaDifferenceAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折旧' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaDepreciation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset', @level2type=N'COLUMN',@level2name=N'FbaAuditDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeFm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'明细科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeTitlesub'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'明细名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeClasssub'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeClassmemo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeBudgetAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际发生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeActualAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbeDifferenceAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense', @level2type=N'COLUMN',@level2name=N'FbsFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_expense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboFm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'必要工数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboRequiredst'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保有人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboDirectEmployee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboIndirectEmployee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班事由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保有工数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboRetainst'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工数差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboRetainstdiff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投入加班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboOvertime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平均投入加班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboDirectovertime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接加班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboIndirectovertime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投入总加班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboOvertimetotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime', @level2type=N'COLUMN',@level2name=N'FboFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_overtime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsFm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保有' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsKeepPersonnel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'现有' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsNowPersonnel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsPersonnel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff', @level2type=N'COLUMN',@level2name=N'FbsFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budget_staff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbCorpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbCorpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbExpCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbCostCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbCostName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbTitleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbTitleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbTitleNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbBudgetAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbActualAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbDiffAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会计人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbAccountant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'FbBalanceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算实际明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_budgetactual_cost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcCorpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcCorpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcExpCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcCostCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcCostName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcTitleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcTitleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcTitleNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcBudgetAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcActualAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcDiffAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcMateriel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcStorageLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcMoveType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcMaterielDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcMaterielDocDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcUseQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcUseAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcReserveDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcAccountant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'DcBalanceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门消耗' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_dept_consuming'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErEffDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErStd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fm币别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErfmCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'To币别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ErtoCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_exchange_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiValType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiPriceControl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动平均价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiMovingAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Per单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiPerUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiLocalCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiInventoryQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiInventoryAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'MiBalancedate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'isDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月度存货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_monthly_inventory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpMonth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period', @level2type=N'COLUMN',@level2name=N'FpQuarter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_period'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpPlnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效从' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpActDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效到' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr', @level2type=N'COLUMN',@level2name=N'FpExpDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_prctr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'FtId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'FtCorpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'FtTitleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目名称_ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'FtTitleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'FtTitleLang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会计科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_accounting_title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwSalesVolume'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwWorkingDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接工资率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwDirectWageRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwDirect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接加班费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwDirectOverTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwDirectWages'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接工资率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwInDirectWageRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwInDirect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接加班费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwInDirectOverTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'FwInDirectWages'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂工资率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fico_wage_rates'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula', @level2type=N'COLUMN',@level2name=N'IfGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula', @level2type=N'COLUMN',@level2name=N'IfType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula', @level2type=N'COLUMN',@level2name=N'IfLangKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula', @level2type=N'COLUMN',@level2name=N'IfFormula'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计算公式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_formula'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiLangkey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiFullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiNature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiOuterPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiInnerPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiFax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiPostalcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiOrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiCorporate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiProvinceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiCityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县/区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiCountyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'镇' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiTownId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'村' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiVillageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiEnAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiWebSite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成立日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiFoundedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经营范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiBusinessScope'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'母公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiParentCorp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiSortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info', @level2type=N'COLUMN',@level2name=N'IiisEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi', @level2type=N'COLUMN',@level2name=N'IkGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi', @level2type=N'COLUMN',@level2name=N'IkAbbrName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi', @level2type=N'COLUMN',@level2name=N'IkAnnual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi', @level2type=N'COLUMN',@level2name=N'IkLangKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi', @level2type=N'COLUMN',@level2name=N'IkTarget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KPI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'inst_kpi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调整参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraADPROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'净改变成本核算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraAEKLK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更改者 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraAENAM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档变更号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraAESZN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许的变式价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraALLOW_PMAT_IGNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动物源 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraANIMAL_ORIGIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ANP Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraANP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraATTYP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类清单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBBTYP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBEGRU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBEHVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后勤变量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBFLME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧物料号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBISMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBLANZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBLATT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部物料编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBMATN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBRAND_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBREIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毛重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBRGEW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBSTAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBSTME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBWSCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraBWVOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAD 标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCADKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'护理代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCARE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCMETH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CM 相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCMREL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'颜色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCOLOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部特性 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCOLOR_ATINN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实物商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCOMMODITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成水平' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCOMPL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部对象号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCUOBF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CW 参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCWQPROC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'称重物料相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCWQREL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CW 容差组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraCWQTOLGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效起始日 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraDATAB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'危险品包装状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraDG_PACK_STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'低层代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraDISST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EAN/UPC' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraEAN11'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EAN 号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraEANNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购值代码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraEKWSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消激活字段 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraENTAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重量单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERGEI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许的包装重量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERGEW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERNAM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERSDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'体积单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERVOE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许的体积 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraERVOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'给物料组加标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraETIAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标号类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraETIAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签格式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraETIFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部物料组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraEXTWG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时装等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFASHGRD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产/检验备忘录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFERTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_CODE1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_CODE2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_CODE3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_CODE4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_CODE5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'百分比共享1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_PART1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'百分比共享2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_PART2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'百分比共享3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_PART3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'百分比共享4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_PART4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'百分比共享5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFIBER_PART5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页格式 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFORMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特性值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFREE_CHAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fashion 属性 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_MG_AT1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fashion 属性 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_MG_AT2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fashion 属性 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_MG_AT3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料转换标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_SC_MID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存管理中激活季节' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_SEAIM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季节使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFSH_SEALV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大层次 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraFUELG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GDS 相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGDS_RELEVANT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一般物料 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGENNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重量单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGEWEI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超重量容差 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGEWTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'大小/量纲' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGROES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EAN变式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraGTIN_VARIANT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'危险物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHAZMAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原产地国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHERKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHNDLCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHOEHE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理单位类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHUTYP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准处理单位类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraHUTYP_DFLT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高粘性的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraIHIVI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'以大批/液体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraILOOS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完全互换组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraIMATN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'净内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraINHAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毛内容 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraINHBR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraINHME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'知识产权' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraIPMIPPRODUCT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraIPRKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品分配' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKOSCH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'竞争者 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKUNNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数有效值· ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZEFF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密闭的 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZGVH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可配置 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZKFG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联产品 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZKUP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后继的物料 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZNFM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修订等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZREV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'环境是相关的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZUMW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测量单位用法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraKZWSM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验室/办公室 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLABOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次更改' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLAEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLAENG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效至 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLIQDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货到后勤等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLOGLEV_RETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后勤计量单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLOGUNIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集团级的 DF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraLVORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料组包装物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAGRV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集团' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMANDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料被锁定 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMATFI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMATKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMATNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大包宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大容量 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超过容量容差' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXC_TOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计量单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXDIM_UOM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大高度 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大长度 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMAXL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业领域' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMBRSH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料条件管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMCOND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMEABM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMEDIUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基本单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMEINS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料运输组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMFRGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMFRNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商零件编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMFRPN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总货架寿命 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMHDHB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓储 %' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMHDLP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余货架寿命' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMHDRZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'含空BOM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMLGUT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商部件参数文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMPROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跨工厂物料状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMSTAE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跨分销链状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMSTAV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效起始期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMSTDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效从 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMSTDV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMTART'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'普通项目类别组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraMTPOS_MARA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业标准描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraNORMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折扣类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraNRFHG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NIIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraNSNID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'净重 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraNTGEW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EAN 类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraNUMTP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Packaging Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPACKCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链编号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPICNUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可偷窃的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPILFERABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格标记类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPLGTP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定价参考物料 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPMATA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品层次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPRDHA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DG标识参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPROFL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品成分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPRZUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表格名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPS_SMARTFORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraPSTAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质量检查组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraQGRP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QM 采购' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraQMPUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隔离期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraQQTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraQQTIMEUOM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraRAUBE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraRBNRM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'舍入规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraRDMHD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraRETDELC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装的参考物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraRMATP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季度年 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSAISJ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季节' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSAISO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSAITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一般可配置物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSATNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSERIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列化层次 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSERLV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段策略' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSGT_COVSA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段结构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSGT_CSGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSGT_REL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSGT_SCOPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSGT_STAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主尺寸 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSIZE1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部特性 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSIZE1_ATINN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'次尺寸 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSIZE2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部特性 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSIZE2_ATINN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSLED_BBD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSPART'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定价参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSPROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'堆栈因子' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSTFAK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'危险物料号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraSTOFF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税收分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraTAKLV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可变皮重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraTARE_VAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'温度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraTEMPB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纺织组分活动' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraTEXTILE_COMP_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运输组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraTRAGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可变的订单单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVABME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装物料类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVHART'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'体积单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVOLEH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超过体积容差' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVOLTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务量 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVOLUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'比较价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVPREH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完整状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraVPSTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原始接受' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraWEORA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GR单数量 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraWESCH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库物料组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraWHMATGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库存储条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraWHSTC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基本物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraWRKST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次管理需求 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraXCHPF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'需要批量记录 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraXGCHP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraZEIAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraZEIFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraZEINR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara', @level2type=N'COLUMN',@level2name=N'MaraZEIVR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'常规物料数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mara'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CC 库存盘点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcABCIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'空气浮力因子' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcABFAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP 相关需求 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAHDIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选择方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcALTSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组计数器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAPLAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相关于 APO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAPOKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'替换部件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcATPKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分割标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAUFTL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中断日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAUSDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAUSME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装配报废' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAUSSS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动重置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAUTRU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcAWSLS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基准数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBASMG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBEARZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBESKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定批量大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBSTFE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大批量 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBSTMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小批量大小 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBSTMI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'舍入值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBSTRF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估收货锁定库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBWESB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBWSCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcBWTTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAS 号（药品） ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCASNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周期标识被固定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCCFIX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该字段不再使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCOMPL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寄售控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCONS_PROCG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCONVT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCOPAM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部对象号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCUOBJ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部对象号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcCUOBV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP  范围存在' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDIBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDISGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批量大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDISLS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP 类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDISMM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP 控制者 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDISPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP 参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDISPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公平分享规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDPLFS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布界限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDPLHO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推式分配' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDPLPU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂内生产时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcDZEIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcEISBE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小安全库存 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcEISLO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcEKGRP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存确定组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcEPRIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品代码单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcEXPME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'JIT 标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFABKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产管理员 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFEVOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动批准' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFFREI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划边际码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFHORI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定批量大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFIXLS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分配 prof.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFPRFM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFRTME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单分配运行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFSH_MG_ARUN_REQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存管理中激活季节' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFSH_SEAIM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFVIDK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划的时界 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFXHOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定价格联产品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcFXPRU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货处理时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcGI_PR_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有约束的虚拟' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcGLGMG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'粗略计划' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcGPMKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PRODCOM号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcGPNUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcHERBL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原产地国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcHERKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货源地 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcHERKR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcINDUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过帐到检验库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcINSMK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'军用物资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcITARK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IUID 相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcIUID_RELEVANT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IUID 类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcIUID_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件报废' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKAUSF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动采购单 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKAUTB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源清单 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKORDB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平滑促销消耗 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZAGL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'非连续标识 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZAUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'需求分组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZBED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MRP控制者=买者 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZDIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证需求 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZDKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入批量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZECH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修正因子' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZKFK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键组件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZKRI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联产品 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZKUP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查计划标识 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZPPV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'从产品货位提取' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZPRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跨项目 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcKZPSP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装载组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLADGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLAGPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年  当前期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLFGJA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLFMON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLFRHY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部采购仓储地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLGFSB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产仓储地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLGPRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务水平' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLGRAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消激活的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLIZYK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后勤组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLOGGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLOSFX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本核算批量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLOSGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批尺寸增加 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLTINC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂级 DF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLVORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcLZEIH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ABC 标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMAABC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大库存水平 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMABST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集团' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMANDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMATGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMATNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大目标范围 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMAX_TROC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大批量大小 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMAXLS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大存储期间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMAXLZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后的MARD 期间之前，MARDH 记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMCRUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMDACH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计量单位组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMEGRU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料运输组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMFRGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小目标范围 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMIN_TROC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'再订货点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMINBE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小批量大小 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMINLS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'综合MRP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMISKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P-S 物料状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMMSTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效起始期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMMSTD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAP 产品组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMOGRU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EU 产品清单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMOWNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平均检查持续期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMPDAU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划日历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMRPPP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出口/进口组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMTVER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可用性检查 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMTVFP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交叉的采购组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcMULTIPLE_EKGRP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无成本核算 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcNCOST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后继物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcNFMAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下一次检查 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcNKMPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcOBJID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总体参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcOCMPF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcOTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会计年度变式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPERIV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPERKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动更改工厂订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPFREI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划交货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPLIFZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPLNNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务清单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPLNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPLVAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRCTR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先权 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPREFE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'免税证书' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRENC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发放证书日 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPREND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商申报 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRENE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商申报日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRENG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'免税证书编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRENO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查间隔 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPRFRQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcPSTAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QM 物料授权' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcQMATA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验设置 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcQMATV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标 QM 系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcQSSYS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隔离' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcQUAZT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证书类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcQZGTP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'舍入参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcRDPRF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'确定方案' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcREF_SCHEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调整期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcRESVP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'反冲' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcRGEKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存入库/出库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcROTATION_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'准备时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcRUEZT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供货天数参文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcRWPRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重复生产' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSAUFT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'独立/集中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSBDKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散装物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSCHGT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSERNP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务水平' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSERVG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产参数文 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSFCPF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REM 参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSFEPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离散批次编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_CHINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段策略' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_COVS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存排序方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_MRPSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_PRCM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_SCOPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分段状态 MRP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_STATC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存保护' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSGT_STK_PRT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全时间标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSHFLG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ST 期间参数文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSHPRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSHZET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊工艺类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSOBSK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊采购' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSOBSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样本%' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSPROZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QM 控制码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSSQSS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comm./imp. code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTAWN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可配置的物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTDPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTEUC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备选 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTLAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用途 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTLAN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'策略组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcSTRGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间隔时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcTAKZT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcTARGET_STOCK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在途库存 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcTRAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工序间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcTRANZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OB管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUCHKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OB参考物料 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUCMAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无限的 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUEETK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过度交货允差' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUEETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部分配' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUID_IEA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中转库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUMLMC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUMRSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不足交货允差' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUNETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计量单位组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUOMGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配额使用安排' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcUSEQU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基准数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVBAMG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVBEAZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVERKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'逆向消耗期间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVINT1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'向前消耗期间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVINT2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SlsVal.TiedEmpt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVKGLG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运输库存/SP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVKTRW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存转移 SV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVKUMC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期到 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRBDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'乘数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRBFK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考物料:消耗 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRBMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考工厂：寄存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRBWK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗模式 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRMOD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'准备时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVRVEZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提议供应区域' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVSPVB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加费 %' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcVZUSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货处理时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcWEBAZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcWERKS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动性物质 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcWSTGH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总补货提前时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcWZEIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcXCHAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次管理需求 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcXCHPF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负的库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc', @level2type=N'COLUMN',@level2name=N'MarcXMCNG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂物料数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_marc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmLastDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmPlnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMatItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmIndustry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMatType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMatDes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmBaseUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmProLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMatGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmPurGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmPurType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊采购类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmSpecType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散装物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmBulkMat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小批量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMoq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'舍入值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmRoundingVal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmLeadTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmProDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmisChecked'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmProfitCenter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差异码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmDiffCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmisLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMpn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMfrs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmValType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动平均价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmMovingAvg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmPriceControl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmPriceUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmSLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmESLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmLocPosn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmInventory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EOL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'MmLocEol'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mats'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CC 库存盘点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewABCIW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'贬值标识  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewABWKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBKLAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWKEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWPEI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商业价格 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWPH1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商业价格 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWPRH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税价1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWPRS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税价2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWPS1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价毛利' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWSPA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWTAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWTTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估变式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWVA1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估变式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWVA2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估变式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewBWVA3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用QS的成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewEKALR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VC:销售订单库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewEKLAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未来评估决策' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewFBWST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定的未来计划价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewFPLPX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewHKMAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原始组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewHRKFT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期成本估计' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALKV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未来成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALKZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品成本核算号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALN1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本估算编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一般费用代码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKALSC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接费分组 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKOSGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点库存VO物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewKZIWL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近价格更改 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLAEPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总库存 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLBKUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前的值决策 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLBWST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年  当前期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLFGJA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLFMON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前计划价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLPLPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定的当前计划价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLPLPX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewLVORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集团' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMANDT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMATNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MBEW 最后期间之前，期间的 MBEW' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMBRUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格确定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMLAST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ML 作业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMLMAA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMTORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料用途 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMTUSE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LIFO评估储备号 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewMYPOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预付库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewOIPPINV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VC: 供应商 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewOKLAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自制产品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewOWNPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前会计年度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPDATL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一会计年 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPDATV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来年会计年度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPDATZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPEINH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPERL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPERV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未来成本估算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPERZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPRDL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前一期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPRDV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记帐期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPPRDZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护状态 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewPSTAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目库存评估类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewQKLAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总价值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewSALK3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价值/MA价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewSALKV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存冻结' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewSPERW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewSTPRS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewSTPRV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewTIMESTAMP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上年评估策略' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVBWST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVERPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本核算版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVERS1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本核算版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVERS2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本核算版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVERS3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上年估价类 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJBKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商业价格 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJBWH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税价3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJBWS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前年总库存值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJKUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上年价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJPEI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上年总值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJSAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上年价值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJSAV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'去年标准价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJSTP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'去年移动平均价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJVER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前一年价格控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVJVPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总SP值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVKSAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期的评价分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMBKL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期总库存 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMKUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期间价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMPEI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期总值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMSAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期的价值 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMSAV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期标准价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMSTP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期移动平均价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMVER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期间价格控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVMVPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上期标准价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVPLPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定的上年计划价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVPLPX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVPRSV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前年的总库存 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVVJLB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计价在 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVVJSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前期的总库存值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVVMLB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计价在 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewVVSAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后实际盘点日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewWLINL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评估单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewXBEWM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LIFO/FIFO-相关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewXLIFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效起始期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZKDAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未来价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZKPRS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格日期 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLD1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格日期 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLD2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格日期 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLD3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLP1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLP2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划价格 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLP3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未来计划价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew', @level2type=N'COLUMN',@level2name=N'MbewZPLPR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂物料评估' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_mbew'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrSupplierCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrSupplierName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrDelivDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未交' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrUnpaidQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已交' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrAlreadyQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurOrderDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPlannedQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPurTaxType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrPrctr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO残发行日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'PrBalancedate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'isDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO残清单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_po_residue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuOrg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuIndustryType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuEnterpriseNature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuAbbr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业法人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuEbe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBusinessNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuTaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuTaxType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主营业务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuMainBusiness'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuPayTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuPayMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统驭科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuRecAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'贸易条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuTradeTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装运条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuShippingTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuSupplierGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商信用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuSupplierCredit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuFirstTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'末次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuLastTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SWIFT代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuBankSwiftNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuRegionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuTelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuFaxNp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'SuPhoneNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'冻结标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'IsFroze'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_supplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeOrg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VePlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeIndustryType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeEnterpriseNature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeAbbr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业法人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeEbe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBusinessNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeTaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeTaxType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主营业务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeMainBusiness'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VePayTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VePayMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统驭科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeRecAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'贸易条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeTradeTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装运条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeShippingTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeSupplierGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商信用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeSupplierCredit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeFirstTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'末次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeLastTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SWIFT代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeBankSwiftNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeRegionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeTelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VeFaxNp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'VePhoneNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'冻结标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'IsFroze'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂商信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mm_vendor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'userId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章状态1、已发布 2、草稿' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑器类型markdown,html' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'fmt_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'tags'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'createTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'updateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article', @level2type=N'COLUMN',@level2name=N'authorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article_category', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article_category', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article_category', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article_category', @level2type=N'COLUMN',@level2name=N'parentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_article_category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'曾用名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeNameUsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeNickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeEnglishName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeGender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeBirthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeIdentityCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'婚姻状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeWedlock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeNationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'籍贯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeNativePlace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EePoliticId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EePhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家/地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeProvince'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家庭住址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeHomeAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EePostCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'户口性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeHouseholdType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'暂住地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeStayAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeDepartmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeTitlesId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EePostId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EePostLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeDutyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招聘来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeRecruited'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'聘用形式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeEngageForm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeTiptopDegrEe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeSpecialty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'院校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeSchool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeWorkID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入职日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在职状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeWorkState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试用期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeProbation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同期限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeContractTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转正日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeConversionTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离职日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeLeaveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同起始日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeBeginContract'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同终止晶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeBndContract'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeWorkAge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeAvatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学历附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeQualificationAffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职称附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee', @level2type=N'COLUMN',@level2name=N'EeTitleAffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人事信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_ehr_employee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字母' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtLangKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtPhrase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'解释' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtExplain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隶属范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'EtArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子辞典' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_et_dictionary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refModule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refPattern'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前缀' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refPrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'refLenth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初始编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'initNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ISO编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'isoNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_numbering_rules'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'CtId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'CtCauseType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因名称ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'CtCauseText_Zh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因名称E(N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'CtCauseText_EN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因名称JA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'CtCauseText_Ja'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'isDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_cause_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdBalanceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变发行日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdIssueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'Editem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdEcNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdOldItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdOldQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdPoQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdBalanceQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdNewItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdNewQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdDisposal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'EdStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新旧物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_digest'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z003'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'担当' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'依赖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PP番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联络书' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实施' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主理由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'次理由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安规' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机番' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z017'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务手册订正' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z018'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户手册订正' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宣传手册订正' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SOP订正' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z021'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信息发行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z022'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本变动' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z023'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z024'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模具改造费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z025'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图纸' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z026'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_Z027'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source', @level2type=N'COLUMN',@level2name=N'IsSolved'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主源设变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_ma_source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcIssueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'担当' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'损失金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcLossAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcManageCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联络No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcLiaisonNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联络文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcLiaisonDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EppNo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcEppLiaisonNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Epp文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcEppLiaisonDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FppNo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcFppLiaisonNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fpp文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcFppLiaisonDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcExternalNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcExternalDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcImpDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EmEcEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SOP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'EsSopStae'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主设变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_master'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsEcNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsSubItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldUsageQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldSetLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsNewItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsNewItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsNewUsageQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsNewSetLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bom番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsBomNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'互换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsChange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'Eslocal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'Esnote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧品处理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldProcess'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bom日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsBomDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实施部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EmEcImpDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsSloc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsInsmk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsMstae'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SOP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsSopStae'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧品库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsOldCurrStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新品库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsNewCurrStock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购PO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购新增' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurCreator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购新增日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurCreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购修改' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPurModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预投入批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcMemo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管新增' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcCreator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管新增日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcCreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管修改' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPmcModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC新增' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcCreator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC新增日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcCreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC修改' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsIqcModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部管登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsMmEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsMmLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsMmMocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsMmNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制一登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPpEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPpLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPpLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPpNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制二登入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPcbaEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pcba班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPcbaLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pcba批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPcbaLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsPcbaNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QA确认日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsQaEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsQaLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'EsQaNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'从设变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slave'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上阶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S003'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOM番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'互换性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安排指示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧品处理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOM生效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'D_SAP_ZPABD_S017'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'IsSolved'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'从源设变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_slv_source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsIssueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsEcNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'担当者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生技担当' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPeaAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组立变更否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'IsPeaModifysop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPeaDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPeaNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EmPeaDocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组立文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EmPeaDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组立确认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPeaModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组立确认日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPeaModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生技担当' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPepAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCBA变更否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'IsPepModifysop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPepDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPepNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EmPepDocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCBA文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EmPepDoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCBA确认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPepModifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCBA确认日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop', @level2type=N'COLUMN',@level2name=N'EsPepModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SOP确认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_ec_sop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines', @level2type=N'COLUMN',@level2name=N'PlId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines', @level2type=N'COLUMN',@level2name=N'PlLineType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines', @level2type=N'COLUMN',@level2name=N'PlLineCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines', @level2type=N'COLUMN',@level2name=N'PlLineName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_lines'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhEffDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhModelType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仕向别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhRegionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhWcName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作中心文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhWcText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准点数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhStdShort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Short单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhShortUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点数换算汇率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhToMinRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准工时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhStdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工时单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'MhTimeUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours', @level2type=N'COLUMN',@level2name=N'isDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准工时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_manhours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderlot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderProQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工艺路线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderRoute'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'MoOrderSerial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order', @level2type=N'COLUMN',@level2name=N'isDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产工单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_mfg_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GUID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产工单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomOrderQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomOrderSerial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomMflot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomModelName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomMfItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomMfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomLineName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomDirect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomIndirect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准工时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomStdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准产能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'PomStdOutput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'oph主表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_master'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父GUID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PomGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产时段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosStartEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际产能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosRealOutput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停线时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosLineStopTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停线原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosStopCause'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停线说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosStopMemo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未达成原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosBadCause'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未达成说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosBadMemo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际工数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosRealTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际工时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosRealWork'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工时差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosRealWorkDiff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产能差异' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosRealOutputDiff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'达成率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'PosAchRatio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'oph从表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'pp_output_slave'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查检水平' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批量范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlRangeMinmum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlRangeMaximum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样本码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlSamplesCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抽样数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlSamplesQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合格项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlAcQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不合格项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql', @level2type=N'COLUMN',@level2name=N'QcaqlReQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抽样标准' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_check_aql'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客诉No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcDocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部客诉No.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcIssuesNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仕向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcRegion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接收日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcReceivingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcFaultQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投诉事项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcIssues'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcSerialno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcReferenceDocs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'症状' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcFaultDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分析' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcRootcauseanalysis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcProcessingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'问题描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因分析' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcCauseAnalysis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作业员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcOperator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcStation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'改善对策' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcMeasures'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'改善文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcReformDocs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承认部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcAdmitDept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承认日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'QmCcAdmitDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客诉管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_complaints'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdInspector'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdModels'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仕向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdRegion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdCheckDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdProLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdProSerial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验退数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdRejectQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdJudgmentLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdCheckNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对策人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdPersonnel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdDirectreason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdIndirectreason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdDisposal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接对策' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdDirectsolutions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接对策' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdIndirectsolutions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检证人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdVerify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实施日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdCarryoutdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实施查证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdCarryoutverify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对策实施查证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdSolutionsverify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记事项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter', @level2type=N'COLUMN',@level2name=N'QirdIssueno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分析对策' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_improvement_replyletter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInPurOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInPurOrderQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInPurDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInInspector'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInCheckDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInInspectingItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验水准' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInSamplingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInCheckMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抽样数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInSamplingQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInJudgment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInJudgmentLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验退数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInRejectQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记事项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInSpecialNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInAcceptQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming', @level2type=N'COLUMN',@level2name=N'qmInCheckoutSequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进料检验' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_incoming'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'qmInsItemGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'qmInsItemCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'qmInsItemName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'qmInsItemType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查工具' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'qmInsItemQcTool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_inspecting_item'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产工单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProModels'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProSerial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送检数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutProDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutInspector'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查验日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutCheckDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutInspectingItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验水准' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutSamplingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutCheckMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抽样数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutSamplingQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutJudgment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutJudgmentLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验退数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutRejectQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutCheckNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记事项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutSpecialNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutAcceptQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutOrderQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检验次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'qmOutCheckoutSequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'UDF01'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出货检验' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_outgoing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'QcodGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接赁率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC检查费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod003'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'差旅费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初期检定・定期检定业务费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作业时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测定器校正业务费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'校正时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部委托，搬运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他通常费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod017'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通常作业时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod018'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通常其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IQC品质问题対応记录者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcodqcr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出货检查费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod021'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod022'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod023'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod024'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信赖性评价・ORT业务费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod025'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod026'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod027'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod028'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顾客品质要求对应业务费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod029'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价作业时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod030'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod031'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod032'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他通常业务费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod033'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通常业务作业时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod034'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通常业务其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod035'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcod036'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QA品质问题対応记录者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation', @level2type=N'COLUMN',@level2name=N'Qcodqar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品质业务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_operation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'QcrdGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd003'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接人员赁率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人员赁率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检讨・调查・试验内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检讨・调查・试验费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检讨会使用时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'直接人员参加人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人员参加人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调查评价试验工作时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交通费、旅费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他作业時間(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他设备购入费,工程费,搬运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'需要不良改修对应' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd017'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品质问题対応记录者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrdqarec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd018'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd021'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'再检查时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd022'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交通费、旅费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd023'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库管理费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd024'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd025'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd026'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'向顾客的费用请求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd027'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顾客名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd028'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Debit Note No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd029'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd030'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd031'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd032'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生管品质问题対応记录者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrdmcrec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd033'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd034'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd035'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd036'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'再检查时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd037'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交通费、旅费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd038'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库管理费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd039'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd040'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd041'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'向顾客的费用请求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd042'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顾客名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd043'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Debit Note No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd044'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd045'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd046'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd047'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'M/L不良改修対応记录者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrdassrec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd048'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不良内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd049'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd050'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd051'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'再检查时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd052'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交通费、旅费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd053'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库管理费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd054'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd055'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选别・改修备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd056'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'向顾客的费用请求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd057'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顾客名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd058'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Debit Note No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd059'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd060'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd061'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework', @level2type=N'COLUMN',@level2name=N'Qcrd062'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返工改修' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_rework'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'QcwdGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间接人员赁率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd003'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部品品号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部品品名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'废弃费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'废弃数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部品单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'废弃处理费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理作业时间(分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关税' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理发生其他费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste', @level2type=N'COLUMN',@level2name=N'Qcwd016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'废弃部品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_qccost_waste'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInScan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInHostname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostIp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInHostip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostMac' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInHostmac'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库扫描' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmInTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出货发票' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutBill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运输方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutTransport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutScan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域仕向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutRegion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutHostname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostIp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutHostip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PCHostMac' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutHostmac'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库扫描' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'QmOutTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号扫描' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_serial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdGuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdInspector'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdModels'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仕向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdRegion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查验日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdCheckDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdProLot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdProSerial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验退数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdRejectQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdJudgmentLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判定说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter', @level2type=N'COLUMN',@level2name=N'QucdCheckNotes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不合格联络' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'qm_unqualified_contactletter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScOrg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScIndustryType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScEnterpriseNature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScAbbr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业法人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScEbe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBusinessNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScTaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScTaxType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主营业务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScMainBusiness'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScPayTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScPayMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统驭科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScRecAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'贸易条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScTradeTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装运条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScShippingTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCustomerGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户信用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCustomerCredit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScFirstTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScLastTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SWIFT代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScBankSwiftNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScRegionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电邮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScTelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScFaxNp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ScPhoneNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'冻结标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'IsFroze'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_client'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScOrg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScIndustryType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScEnterpriseNature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScAbbr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业法人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScEbe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBusinessNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScTaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScTaxType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主营业务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScMainBusiness'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScPayTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScPayMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统驭科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScRecAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'贸易条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScTradeTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装运条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScShippingTerms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCustomerGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户信用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCustomerCredit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首次交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScFirstTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScLastTransDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在国' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行所在县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SWIFT代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScBankSwiftNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScRegionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'州省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScAddr1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScAddr2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电邮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScTelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScFaxNp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ScPhoneNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'冻结标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'IsFroze'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顾客信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpPlnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpAccDocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpAccDocLineNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpCustomerCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpPrctr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpSalesItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpAccountCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpSalesQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpSalesUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币销售额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpOriginalAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpOriginalCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币销售额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpLocalAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpLocalCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpRefDocNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpRefDocLineNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过账日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpPostingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpPostingUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpEntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpEntryTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpOrigin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpPgroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpAccDocType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'SpAccDocText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'isDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sales_accdoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工厂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpPlnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpFy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpYm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpItemText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpOriginalFob'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpOriginalCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币Per单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpOriginalPerUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原币利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpOriginalPrctr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpLocalFob'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpLocalCcy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币Per单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpLocalPerUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本币利润中心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpLocalPrctr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpEffDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpExpDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'SpBalancedate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice', @level2type=N'COLUMN',@level2name=N'ReMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售价格档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sd_sellingprice'
GO
