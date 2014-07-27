USE [master]
GO
/****** Object:  Database [GolfDb]    Script Date: 7/26/2014 10:59:05 PM ******/
CREATE DATABASE [GolfDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GolfDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GolfDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GolfDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GolfDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GolfDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GolfDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GolfDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GolfDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GolfDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GolfDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GolfDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GolfDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GolfDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GolfDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GolfDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GolfDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GolfDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GolfDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GolfDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GolfDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GolfDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GolfDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GolfDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GolfDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GolfDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GolfDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GolfDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GolfDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GolfDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GolfDb] SET  MULTI_USER 
GO
ALTER DATABASE [GolfDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GolfDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GolfDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GolfDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GolfDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GolfDb]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zip] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hole]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Par] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TotalYards] [int] NULL,
	[YardsFromBlue] [int] NULL,
	[YardsFromWhite] [int] NULL,
	[YardsFromRed] [int] NULL,
	[Score] [int] NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Hole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Player]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Handicap] [int] NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Round]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Round](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundDate] [datetime] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoundHole]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoundHole](
	[RoundId] [int] NOT NULL,
	[HoleId] [int] NOT NULL,
 CONSTRAINT [PK_RoundHole] PRIMARY KEY CLUSTERED 
(
	[RoundId] ASC,
	[HoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoundPlayer]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoundPlayer](
	[PlayerId] [int] NOT NULL,
	[RoundId] [int] NOT NULL,
 CONSTRAINT [PK_RoundPlayer] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC,
	[RoundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Score]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ScoreCardid] [int] NOT NULL,
	[Strokes] [int] NULL,
	[Holeid] [int] NOT NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScoreCard]    Script Date: 7/26/2014 10:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoreCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TotalScore] [int] NULL,
	[PlayerId] [int] NOT NULL,
	[RoundId] [int] NOT NULL,
 CONSTRAINT [PK_ScoreCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Hole]  WITH CHECK ADD  CONSTRAINT [FK_Hole_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Hole] CHECK CONSTRAINT [FK_Hole_Course]
GO
ALTER TABLE [dbo].[Round]  WITH CHECK ADD  CONSTRAINT [FK_Round_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Round] CHECK CONSTRAINT [FK_Round_Course]
GO
ALTER TABLE [dbo].[RoundHole]  WITH CHECK ADD  CONSTRAINT [FK_RoundHole_Hole] FOREIGN KEY([HoleId])
REFERENCES [dbo].[Hole] ([Id])
GO
ALTER TABLE [dbo].[RoundHole] CHECK CONSTRAINT [FK_RoundHole_Hole]
GO
ALTER TABLE [dbo].[RoundHole]  WITH CHECK ADD  CONSTRAINT [FK_RoundHole_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[RoundHole] CHECK CONSTRAINT [FK_RoundHole_Round]
GO
ALTER TABLE [dbo].[RoundPlayer]  WITH CHECK ADD  CONSTRAINT [FK_RoundPlayer_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
GO
ALTER TABLE [dbo].[RoundPlayer] CHECK CONSTRAINT [FK_RoundPlayer_Player]
GO
ALTER TABLE [dbo].[RoundPlayer]  WITH CHECK ADD  CONSTRAINT [FK_RoundPlayer_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[RoundPlayer] CHECK CONSTRAINT [FK_RoundPlayer_Round]
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Hole] FOREIGN KEY([Holeid])
REFERENCES [dbo].[Hole] ([Id])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Hole]
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_ScoreCard] FOREIGN KEY([ScoreCardid])
REFERENCES [dbo].[ScoreCard] ([Id])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_ScoreCard]
GO
ALTER TABLE [dbo].[ScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_ScoreCard_Player1] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
GO
ALTER TABLE [dbo].[ScoreCard] CHECK CONSTRAINT [FK_ScoreCard_Player1]
GO
ALTER TABLE [dbo].[ScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_ScoreCard_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[ScoreCard] CHECK CONSTRAINT [FK_ScoreCard_Round]
GO
USE [master]
GO
ALTER DATABASE [GolfDb] SET  READ_WRITE 
GO
