USE [master]
GO
/****** Object:  Database [MyFavorRepos]    Script Date: 2021-03-26 12:12:18 ******/
CREATE DATABASE [MyFavorRepos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyFavorRepos', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\MyFavorRepos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyFavorRepos_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\MyFavorRepos_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyFavorRepos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyFavorRepos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyFavorRepos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyFavorRepos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyFavorRepos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyFavorRepos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyFavorRepos] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyFavorRepos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyFavorRepos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyFavorRepos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyFavorRepos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyFavorRepos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyFavorRepos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyFavorRepos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyFavorRepos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyFavorRepos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyFavorRepos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyFavorRepos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyFavorRepos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyFavorRepos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyFavorRepos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyFavorRepos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyFavorRepos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyFavorRepos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyFavorRepos] SET RECOVERY FULL 
GO
ALTER DATABASE [MyFavorRepos] SET  MULTI_USER 
GO
ALTER DATABASE [MyFavorRepos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyFavorRepos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyFavorRepos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyFavorRepos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyFavorRepos', N'ON'
GO
USE [MyFavorRepos]
GO
/****** Object:  Table [dbo].[tbl_Left]    Script Date: 2021-03-26 12:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Left](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Right]    Script Date: 2021-03-26 12:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Right](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MyFavorRepos] SET  READ_WRITE 
GO
