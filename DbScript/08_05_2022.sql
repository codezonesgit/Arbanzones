USE [master]
GO
/****** Object:  Database [ArbanZones]    Script Date: 08-05-2022 23:56:25 ******/
CREATE DATABASE [ArbanZones]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArbanZones', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ArbanZones.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArbanZones_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ArbanZones_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ArbanZones] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArbanZones].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArbanZones] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArbanZones] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArbanZones] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArbanZones] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArbanZones] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArbanZones] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArbanZones] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArbanZones] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArbanZones] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArbanZones] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArbanZones] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArbanZones] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArbanZones] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArbanZones] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArbanZones] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArbanZones] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArbanZones] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArbanZones] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArbanZones] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArbanZones] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArbanZones] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArbanZones] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArbanZones] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArbanZones] SET  MULTI_USER 
GO
ALTER DATABASE [ArbanZones] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArbanZones] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArbanZones] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArbanZones] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArbanZones] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArbanZones] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ArbanZones] SET QUERY_STORE = OFF
GO
USE [ArbanZones]
GO
/****** Object:  Table [dbo].[tbl_Banner]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Banner](
	[BannerId] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](max) NULL,
	[Description] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryDate] [datetime] NULL,
	[EntryBy] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CategoryMaster]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CategoryMaster](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](80) NULL,
	[Images] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryBy] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Offer]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Offer](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[OfferImgUrl] [varchar](max) NULL,
	[Description] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryDate] [datetime] NULL,
	[EntryBy] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryBy] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ServiceProvider]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ServiceProvider](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[ServiceName] [varchar](100) NULL,
	[RegId] [varchar](80) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryBy] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserDetail]    Script Date: 08-05-2022 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserDetail](
	[Id] [varchar](80) NULL,
	[UserId] [varchar](50) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[MobileNo] [varchar](20) NOT NULL,
	[EmailId] [varchar](50) NULL,
	[Password] [nvarchar](500) NULL,
	[VCode] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[EntryDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[DeviceName] [varchar](40) NULL,
	[DeviceToken] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_UserDetail] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ArbanZones] SET  READ_WRITE 
GO
