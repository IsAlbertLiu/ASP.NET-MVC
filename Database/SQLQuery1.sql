USE [master]
GO
/****** Object:  Database [MvcBookStore]    Script Date: 2020/10/9 13:38:14 ******/
CREATE DATABASE [MvcBookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MvcBookStore', FILENAME = N'D:\Database\MvcBookStore.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MvcBookStore_log', FILENAME = N'D:\Database\MvcBookStore_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MvcBookStore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MvcBookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MvcBookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MvcBookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MvcBookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MvcBookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MvcBookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MvcBookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MvcBookStore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MvcBookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MvcBookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MvcBookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MvcBookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MvcBookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MvcBookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MvcBookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MvcBookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MvcBookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MvcBookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MvcBookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MvcBookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MvcBookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MvcBookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MvcBookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MvcBookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MvcBookStore] SET RECOVERY FULL 
GO
ALTER DATABASE [MvcBookStore] SET  MULTI_USER 
GO
ALTER DATABASE [MvcBookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MvcBookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MvcBookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MvcBookStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MvcBookStore', N'ON'
GO
USE [MvcBookStore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2020/10/9 13:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[Price] [decimal](18, 2) NULL,
	[BookCoverUrl] [nvarchar](1024) NOT NULL,
	[Authors] [nvarchar](50) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2020/10/9 13:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[RecordId] [int] NOT NULL,
	[CartId] [nvarchar](max) NULL,
	[BookId] [int] NULL,
	[Count] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2020/10/9 13:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetailId]    Script Date: 2020/10/9 13:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetailId](
	[OrderDetailId] [int] NULL,
	[OrderId] [int] NULL,
	[BookId] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2020/10/9 13:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](160) NULL,
	[LastName] [nvarchar](160) NULL,
	[Address] [nvarchar](70) NULL,
	[City] [nvarchar](40) NULL,
	[State] [nvarchar](40) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](40) NULL,
	[Phone] [nvarchar](24) NULL,
	[Email] [nvarchar](max) NULL,
	[Total] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [MvcBookStore] SET  READ_WRITE 
GO