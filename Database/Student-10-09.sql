USE [master]
GO
/****** Object:  Database [a]    Script Date: 2020/10/9 14:12:10 ******/
CREATE DATABASE [a]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'a', FILENAME = N'D:\data\a.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'a_log', FILENAME = N'D:\data\a_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [a] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [a].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [a] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [a] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [a] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [a] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [a] SET ARITHABORT OFF 
GO
ALTER DATABASE [a] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [a] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [a] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [a] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [a] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [a] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [a] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [a] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [a] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [a] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [a] SET  DISABLE_BROKER 
GO
ALTER DATABASE [a] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [a] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [a] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [a] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [a] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [a] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [a] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [a] SET RECOVERY FULL 
GO
ALTER DATABASE [a] SET  MULTI_USER 
GO
ALTER DATABASE [a] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [a] SET DB_CHAINING OFF 
GO
ALTER DATABASE [a] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [a] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'a', N'ON'
GO
USE [a]
GO
/****** Object:  Table [dbo].[dm_xy]    Script Date: 2020/10/9 14:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dm_xy](
	[id] [nvarchar](50) NOT NULL,
	[xy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dm_xy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dm_zy]    Script Date: 2020/10/9 14:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dm_zy](
	[id] [nvarchar](50) NOT NULL,
	[zy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dm_zy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[s]    Script Date: 2020/10/9 14:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[s](
	[sno] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[xy] [nvarchar](50) NULL,
	[zy] [nvarchar](50) NULL,
 CONSTRAINT [PK_s] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[dm_xy] ([id], [xy]) VALUES (N'1', N'信息学院')
INSERT [dbo].[dm_xy] ([id], [xy]) VALUES (N'2', N'计算机学院')
INSERT [dbo].[dm_xy] ([id], [xy]) VALUES (N'3', N'商学院')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'1', N'软件技术')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'2', N'软件测试')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'3', N'人工智能')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'4', N'计算机网络')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'5', N'网络安全')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'6', N'物联网')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'7', N'物流管理')
INSERT [dbo].[dm_zy] ([id], [zy]) VALUES (N'8', N'人力资源管理')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'1', N'张', N'男', N'信息学院', N'软件技术')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'123', N'123', N'男', N'计算机学院', N'计算机网络')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'2', N'张三', N'男', N'信息学院', N'软件测试')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'3', N'张三丰', N'女', N'信息学院', N'人工智能')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'4', N'王', N'女', N'商学院', N'人力资源管理')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'41', N'李', N'女', N'计算机学院', N'计算机网络')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'52', N'李四', N'女', N'计算机学院', N'网络安全')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'63', N'赵', N'男', N'计算机学院', N'物联网')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'74', N'尼古拉赵四', N'男', N'商学院', N'物流管理')
INSERT [dbo].[s] ([sno], [name], [sex], [xy], [zy]) VALUES (N'93', N'王二', N'女', N'信息学院', N'软件技术')
USE [master]
GO
ALTER DATABASE [a] SET  READ_WRITE 
GO
