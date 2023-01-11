USE [master]
GO
/****** Object:  Database [Laplace_Deb]    Script Date: 2023/1/11 10:02:00 ******/
CREATE DATABASE [Laplace_Deb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Laplace_Deb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Laplace_Deb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Laplace_Deb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Laplace_Deb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Laplace_Deb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Laplace_Deb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Laplace_Deb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Laplace_Deb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Laplace_Deb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Laplace_Deb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Laplace_Deb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Laplace_Deb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Laplace_Deb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Laplace_Deb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Laplace_Deb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Laplace_Deb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Laplace_Deb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Laplace_Deb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Laplace_Deb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Laplace_Deb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Laplace_Deb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Laplace_Deb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Laplace_Deb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Laplace_Deb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Laplace_Deb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Laplace_Deb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Laplace_Deb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Laplace_Deb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Laplace_Deb] SET RECOVERY FULL 
GO
ALTER DATABASE [Laplace_Deb] SET  MULTI_USER 
GO
ALTER DATABASE [Laplace_Deb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Laplace_Deb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Laplace_Deb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Laplace_Deb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Laplace_Deb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Laplace_Deb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Laplace_Deb', N'ON'
GO
ALTER DATABASE [Laplace_Deb] SET QUERY_STORE = OFF
GO
USE [Laplace_Deb]
GO
/****** Object:  Table [dbo].[article]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[cid] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[articleCategory]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleCategory](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[create_time] [datetime] NULL,
	[parentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_period]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fico_period](
	[FpId] [int] IDENTITY(1,1) NOT NULL,
	[FpFy] [nvarchar](6) NOT NULL,
	[FpYm] [nvarchar](6) NOT NULL,
	[FpYear] [nvarchar](4) NOT NULL,
	[FpMonth] [nvarchar](2) NOT NULL,
	[FpQuarter] [nvarchar](2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ReMark] [varchar](max) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_period] PRIMARY KEY CLUSTERED 
(
	[FpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fico_prctr]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fico_prctr](
	[FpId] [bigint] IDENTITY(1,1) NOT NULL,
	[FpPlnt] [nvarchar](4) NOT NULL,
	[FpCode] [nvarchar](8) NOT NULL,
	[FpName] [nvarchar](50) NOT NULL,
	[FpType] [nvarchar](1) NOT NULL,
	[FpActDate] [date] NOT NULL,
	[FpExpDate] [date] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remark] [varchar](max) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_dbo.fico_prctr] PRIMARY KEY CLUSTERED 
(
	[FpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_demo]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_demo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[icon] [varchar](255) NULL,
	[showStatus] [int] NOT NULL,
	[addTime] [datetime] NULL,
	[sex] [int] NULL,
	[sort] [int] NULL,
	[beginTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[remark] [varchar](200) NULL,
	[feature] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_table]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_table](
	[tableId] [bigint] IDENTITY(1,1) NOT NULL,
	[tableName] [varchar](200) NULL,
	[tableComment] [varchar](500) NULL,
	[subTableName] [varchar](64) NULL,
	[subTableFkName] [varchar](64) NULL,
	[className] [varchar](100) NULL,
	[tplCategory] [varchar](200) NULL,
	[baseNameSpace] [varchar](100) NULL,
	[moduleName] [varchar](30) NULL,
	[businessName] [varchar](30) NULL,
	[functionName] [varchar](50) NULL,
	[functionAuthor] [varchar](50) NULL,
	[genType] [varchar](1) NULL,
	[genPath] [varchar](200) NULL,
	[options] [varchar](1000) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_Time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[dbName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[tableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_table_column]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_table_column](
	[columnId] [bigint] IDENTITY(1,1) NOT NULL,
	[tableId] [bigint] NULL,
	[tableName] [varchar](200) NULL,
	[columnName] [varchar](200) NULL,
	[columnComment] [varchar](500) NULL,
	[columnType] [varchar](100) NULL,
	[csharpType] [varchar](500) NULL,
	[csharpField] [varchar](200) NULL,
	[isPk] [tinyint] NULL,
	[isIncrement] [tinyint] NULL,
	[isRequired] [tinyint] NULL,
	[isInsert] [tinyint] NULL,
	[isEdit] [tinyint] NULL,
	[isList] [tinyint] NULL,
	[isSort] [tinyint] NULL,
	[isQuery] [tinyint] NULL,
	[isExport] [tinyint] NULL,
	[queryType] [varchar](200) NULL,
	[htmlType] [varchar](200) NULL,
	[dictType] [varchar](200) NULL,
	[sort] [int] NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[columnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_common_lang]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_common_lang](
	[id] [bigint] NOT NULL,
	[lang_code] [varchar](10) NOT NULL,
	[lang_key] [nvarchar](100) NULL,
	[lang_name] [nvarchar](2000) NOT NULL,
	[addtime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_config]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_config](
	[configId] [int] IDENTITY(1,1) NOT NULL,
	[configName] [varchar](100) NULL,
	[configKey] [varchar](100) NULL,
	[configValue] [varchar](500) NULL,
	[configType] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[configId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dept]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dept](
	[deptId] [bigint] IDENTITY(100,1) NOT NULL,
	[parentId] [bigint] NULL,
	[ancestors] [varchar](50) NULL,
	[deptName] [varchar](30) NULL,
	[orderNum] [int] NULL,
	[leader] [varchar](20) NULL,
	[phone] [varchar](11) NULL,
	[email] [varchar](50) NULL,
	[status] [varchar](1) NULL,
	[delFlag] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[deptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dict_data]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dict_data](
	[dictCode] [bigint] IDENTITY(11000,1) NOT NULL,
	[dictSort] [int] NULL,
	[dictLabel] [varchar](100) NULL,
	[dictValue] [varchar](100) NULL,
	[dictType] [varchar](100) NULL,
	[cssClass] [varchar](100) NULL,
	[listClass] [varchar](100) NULL,
	[isDefault] [varchar](1) NULL,
	[status] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[dictCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dict_type]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dict_type](
	[dictId] [bigint] IDENTITY(10000,1) NOT NULL,
	[dictName] [varchar](100) NULL,
	[dictType] [varchar](100) NULL,
	[status] [varchar](1) NULL,
	[type] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[customSql] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[dictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_file]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_file](
	[id] [bigint] NOT NULL,
	[realName] [varchar](50) NULL,
	[fileName] [varchar](50) NULL,
	[fileUrl] [varchar](500) NULL,
	[storePath] [varchar](50) NULL,
	[accessUrl] [varchar](300) NULL,
	[fileSize] [varchar](20) NULL,
	[fileType] [varchar](200) NULL,
	[fileExt] [varchar](10) NULL,
	[create_by] [varchar](50) NULL,
	[create_time] [datetime] NULL,
	[storeType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_logininfor]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_logininfor](
	[infoId] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NULL,
	[ipaddr] [varchar](50) NULL,
	[loginLocation] [varchar](255) NULL,
	[browser] [varchar](50) NULL,
	[os] [varchar](50) NULL,
	[status] [char](1) NULL,
	[msg] [varchar](255) NULL,
	[loginTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[infoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_menu]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_menu](
	[menuId] [bigint] IDENTITY(1,1) NOT NULL,
	[menuName] [varchar](50) NOT NULL,
	[parentId] [bigint] NULL,
	[orderNum] [int] NULL,
	[path] [varchar](200) NULL,
	[component] [varchar](255) NULL,
	[isFrame] [int] NULL,
	[isCache] [int] NULL,
	[menuType] [char](1) NULL,
	[visible] [char](1) NULL,
	[status] [char](1) NULL,
	[perms] [varchar](100) NULL,
	[icon] [varchar](100) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[menuName_key] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[menuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_notice]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_notice](
	[notice_id] [int] IDENTITY(1,1) NOT NULL,
	[notice_title] [varchar](100) NULL,
	[notice_type] [char](1) NULL,
	[notice_content] [text] NULL,
	[status] [char](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[notice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_oper_log]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_oper_log](
	[operId] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[businessType] [int] NULL,
	[method] [varchar](100) NULL,
	[requestMethod] [varchar](10) NULL,
	[operatorType] [int] NULL,
	[operName] [varchar](50) NULL,
	[deptName] [varchar](50) NULL,
	[operUrl] [varchar](255) NULL,
	[operIP] [varchar](50) NULL,
	[operLocation] [varchar](255) NULL,
	[operParam] [varchar](2000) NULL,
	[jsonResult] [varchar](max) NULL,
	[status] [int] NULL,
	[errorMsg] [varchar](2000) NULL,
	[operTime] [datetime] NULL,
	[elapsed] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[operId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_post]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_post](
	[postId] [bigint] IDENTITY(1,1) NOT NULL,
	[postCode] [varchar](64) NOT NULL,
	[postName] [varchar](50) NOT NULL,
	[postSort] [int] NOT NULL,
	[status] [varchar](1) NOT NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role](
	[roleId] [bigint] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](30) NOT NULL,
	[roleKey] [varchar](100) NOT NULL,
	[roleSort] [int] NOT NULL,
	[dataScope] [varchar](1) NULL,
	[menu_check_strictly] [int] NULL,
	[dept_check_strictly] [int] NOT NULL,
	[status] [char](1) NOT NULL,
	[delFlag] [char](1) NOT NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role_dept]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role_dept](
	[roleId] [bigint] NOT NULL,
	[deptId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role_menu]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role_menu](
	[role_id] [bigint] NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[create_by] [varchar](20) NULL,
	[create_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_tasks]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_tasks](
	[id] [varchar](100) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[jobGroup] [varchar](255) NOT NULL,
	[cron] [varchar](255) NOT NULL,
	[assemblyName] [varchar](255) NOT NULL,
	[className] [varchar](255) NOT NULL,
	[remark] [varchar](200) NULL,
	[runTimes] [int] NOT NULL,
	[beginTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[triggerType] [int] NOT NULL,
	[intervalSecond] [int] NOT NULL,
	[isStart] [int] NOT NULL,
	[jobParams] [text] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[create_by] [varchar](50) NULL,
	[update_by] [varchar](50) NULL,
	[lastRunTime] [datetime] NULL,
	[taskType] [int] NULL,
	[apiUrl] [varchar](200) NULL,
	[sqlText] [varchar](1000) NULL,
	[requestMethod] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_tasks_log]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_tasks_log](
	[jobLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[jobId] [varchar](20) NOT NULL,
	[jobName] [varchar](64) NOT NULL,
	[jobGroup] [varchar](64) NOT NULL,
	[jobMessage] [varchar](500) NULL,
	[status] [varchar](1) NULL,
	[exception] [varchar](2000) NULL,
	[createTime] [datetime] NULL,
	[invokeTarget] [varchar](200) NULL,
	[elapsed] [decimal](10, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[jobLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user](
	[userId] [bigint] IDENTITY(1,1) NOT NULL,
	[deptId] [bigint] NULL,
	[userName] [varchar](30) NOT NULL,
	[nickName] [varchar](30) NOT NULL,
	[userType] [varchar](2) NULL,
	[email] [varchar](50) NULL,
	[phonenumber] [varchar](11) NULL,
	[sex] [varchar](1) NULL,
	[avatar] [varchar](400) NULL,
	[password] [varchar](100) NOT NULL,
	[status] [varchar](1) NULL,
	[delFlag] [varchar](1) NULL,
	[loginIP] [varchar](50) NULL,
	[loginDate] [datetime] NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user_post]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user_post](
	[userId] [bigint] NOT NULL,
	[postId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user_role]    Script Date: 2023/1/11 10:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user_role](
	[user_id] [bigint] NOT NULL,
	[role_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [postCode]    Script Date: 2023/1/11 10:02:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [postCode] ON [dbo].[sys_post]
(
	[postCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [index_userName]    Script Date: 2023/1/11 10:02:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [index_userName] ON [dbo].[sys_user]
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [title]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [userId]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [fmt_type]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [tags]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [hits]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [category_id]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [createTime]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [updateTime]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [authorName]
GO
ALTER TABLE [dbo].[articleCategory] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[articleCategory] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[fico_period] ADD  DEFAULT ('0') FOR [IsDeleted]
GO
ALTER TABLE [dbo].[fico_prctr] ADD  CONSTRAINT [DF__fico_prct__IsDel__405A880E]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[gen_demo] ADD  DEFAULT (NULL) FOR [sex]
GO
ALTER TABLE [dbo].[gen_demo] ADD  DEFAULT ((0)) FOR [sort]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [tableName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [tableComment]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [subTableName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [subTableFkName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [className]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('crud') FOR [tplCategory]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('0') FOR [genType]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('/') FOR [genPath]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('EQ') FOR [queryType]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configName]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configKey]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configValue]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('N') FOR [configType]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [ancestors]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [deptName]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ((0)) FOR [orderNum]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [leader]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [phone]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('0') FOR [delFlag]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ((0)) FOR [dictSort]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictLabel]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictValue]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [cssClass]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [listClass]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('N') FOR [isDefault]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [dictName]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('N') FOR [type]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [customSql]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [userName]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [ipaddr]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [loginLocation]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [browser]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [os]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [msg]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT (NULL) FOR [loginTime]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [orderNum]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [path]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [component]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [isFrame]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [isCache]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [menuType]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('0') FOR [visible]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [perms]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('#') FOR [icon]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [remark]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [menuName_key]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [title]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [businessType]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [method]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [requestMethod]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [operatorType]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operName]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [deptName]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operUrl]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operIP]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operLocation]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operParam]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [jsonResult]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [errorMsg]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT (NULL) FOR [operTime]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT (NULL) FOR [elapsed]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('1') FOR [dataScope]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ((1)) FOR [menu_check_strictly]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ((1)) FOR [dept_check_strictly]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('0') FOR [delFlag]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_role_menu] ADD  DEFAULT (NULL) FOR [create_by]
GO
ALTER TABLE [dbo].[sys_role_menu] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [beginTime]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [endTime]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [create_by]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [update_by]
GO
ALTER TABLE [dbo].[sys_tasks_log] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_tasks_log] ADD  DEFAULT ('') FOR [exception]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ((0)) FOR [deptId]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [userType]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [sex]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [delFlag]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码生成表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码生成表字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'多语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_common_lang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept'
GO
USE [master]
GO
ALTER DATABASE [Laplace_Deb] SET  READ_WRITE 
GO
