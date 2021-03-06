USE [master]
GO
/****** Object:  Database [JSearchDB]    Script Date: 8/8/2016 4:00:45 PM ******/
CREATE DATABASE [JSearchDB] ON  PRIMARY 
( NAME = N'JSearchDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JSearchDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JSearchDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JSearchDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JSearchDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JSearchDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JSearchDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JSearchDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JSearchDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JSearchDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [JSearchDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JSearchDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JSearchDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JSearchDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JSearchDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JSearchDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JSearchDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JSearchDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JSearchDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JSearchDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JSearchDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JSearchDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JSearchDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JSearchDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JSearchDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JSearchDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JSearchDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JSearchDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JSearchDB] SET  MULTI_USER 
GO
ALTER DATABASE [JSearchDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JSearchDB] SET DB_CHAINING OFF 
GO
USE [JSearchDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courts]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courts](
	[CourtId] [int] NOT NULL,
	[CourtCode] [nvarchar](50) NULL,
	[CourtName] [nvarchar](max) NULL,
	[CourtRemarks] [nvarchar](max) NULL,
	[CourtStatus] [int] NULL,
	[UserId] [nvarchar](128) NULL,
	[CourtDateTimeStamp] [datetime] NULL,
	[UserName] [nvarchar](256) NULL,
	[TerminalName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Courts] PRIMARY KEY CLUSTERED 
(
	[CourtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FileSections]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileSections](
	[FileSectionId] [int] NOT NULL,
	[FileSectionCode] [nvarchar](100) NULL,
	[SectionId] [int] NULL,
	[FileId] [int] NULL,
	[UserId] [nchar](128) NULL,
	[TerminalName] [nvarchar](100) NULL,
	[FileSectionStatus] [int] NULL,
	[FSDateTimeStamp] [datetime] NULL,
 CONSTRAINT [PK_FileSections] PRIMARY KEY CLUSTERED 
(
	[FileSectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Judges]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Judges](
	[JudgeId] [int] NOT NULL,
	[JudgeCode] [nvarchar](50) NULL,
	[JudgeName] [nvarchar](max) NULL,
	[JudgeRemarks] [nvarchar](max) NULL,
	[JudgeStatus] [int] NULL,
	[UserId] [nvarchar](128) NULL,
	[JudgeDateTimeStamp] [datetime] NULL,
	[TerminalName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Judges] PRIMARY KEY CLUSTERED 
(
	[JudgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LawFiles]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LawFiles](
	[FileId] [int] NOT NULL,
	[FileCode] [nvarchar](50) NULL,
	[FileTitle] [nvarchar](200) NULL,
	[FileDescription] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileAbstract] [nvarchar](max) NULL,
	[JudgeId] [int] NULL,
	[FileRemarks] [nvarchar](max) NULL,
	[CourtId] [int] NULL,
	[FileYear] [nvarchar](10) NULL,
	[UserId] [nvarchar](128) NULL,
	[FileDateTimeStamp] [datetime] NULL,
	[TerminalName] [nvarchar](100) NULL,
 CONSTRAINT [PK_LawFiles] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Laws]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laws](
	[LawId] [int] NOT NULL,
	[LawCode] [nvarchar](100) NULL,
	[LawTitle] [nvarchar](max) NULL,
	[LawRemarks] [nvarchar](max) NULL,
	[LawStatus] [int] NULL,
	[UserId] [nvarchar](128) NULL,
	[LawDateTimeStamp] [datetime] NULL,
	[TerminalName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Laws] PRIMARY KEY CLUSTERED 
(
	[LawId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sections]    Script Date: 8/8/2016 4:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[SectionId] [int] NOT NULL,
	[SectionCode] [nvarchar](100) NULL,
	[SectionName] [nvarchar](max) NULL,
	[LawId] [int] NULL,
	[SectionRefId] [int] NULL,
	[SectionStatus] [int] NULL,
	[UserId] [nvarchar](128) NULL,
	[SectionRemarks] [nvarchar](max) NULL,
	[SectionDateTimeStamp] [datetime] NULL,
	[TerminalName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'2a7aa117-1862-4e78-ac04-5109fa53c736', N'imranrabbani@gmail.com', 0, N'AISepm9PDOr+fTphr+/U74viTPAnkZ147zAEsGJNEdtLmWajHa9XeyPGrq8hPuNuQw==', N'dfe2280f-7aa3-481d-8d48-095ae6102f1e', NULL, 0, 0, NULL, 1, 0, N'Imran', N'')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', N'zubairmohsin33@gmail.com', 0, N'AAELh5Mg+16QMXf4W6t+4krQLYL4buOndemyvIfXI3Qk5lEx3g8JvVcl8E5FPSb3MQ==', N'c9d28617-f84f-457d-9176-9b2f36d6896b', NULL, 0, 0, NULL, 1, 0, N'zubairmohsin33@gmail.com', N'')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'76cf2853-6499-49b2-9dec-e39976ea6a19', N'omer@gmail.com', 0, N'ABOAMHtV3jLXom1U2JdDaYo93ebAMVV2G2VwEzLRA2OJHfMezwlses/bGVP3cxa5IA==', N'ba667bcf-b204-4bbe-bff0-4bf4b5bea25f', NULL, 0, 0, NULL, 1, 0, N'omer', N'')
INSERT [dbo].[Courts] ([CourtId], [CourtCode], [CourtName], [CourtRemarks], [CourtStatus], [UserId], [CourtDateTimeStamp], [UserName], [TerminalName]) VALUES (1, N'C-1', N'Supreme High Court', N'Court Is Active', 0, NULL, CAST(0x0000A65700AE5FEA AS DateTime), NULL, N'ZUBAIR-PC')
INSERT [dbo].[Courts] ([CourtId], [CourtCode], [CourtName], [CourtRemarks], [CourtStatus], [UserId], [CourtDateTimeStamp], [UserName], [TerminalName]) VALUES (2, N'C-2', N'Lahore High Court', N'Lahore High Court Is Active Right Now', 1, NULL, CAST(0x0000A65700AFD0B7 AS DateTime), NULL, N'ZUBAIR-PC')
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (1, N'S-1', 2, 2, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc                                                                                            ', N'ZUBAIR-PC', NULL, CAST(0x0000A65C00C59857 AS DateTime))
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (2, N'S-2', 3, 3, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc                                                                                            ', N'ZUBAIR-PC', NULL, CAST(0x0000A65C00C6CDE4 AS DateTime))
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (3, N'S-3', 0, 4, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc                                                                                            ', N'ZUBAIR-PC', NULL, CAST(0x0000A65C00D556B2 AS DateTime))
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (4, N'S-4', 3, 5, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc                                                                                            ', N'ZUBAIR-PC', NULL, CAST(0x0000A65C00D5B7CF AS DateTime))
INSERT [dbo].[FileSections] ([FileSectionId], [FileSectionCode], [SectionId], [FileId], [UserId], [TerminalName], [FileSectionStatus], [FSDateTimeStamp]) VALUES (5, N'S-5', 3, 6, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc                                                                                            ', N'ZUBAIR-PC', NULL, CAST(0x0000A65C00F1B2D5 AS DateTime))
INSERT [dbo].[Judges] ([JudgeId], [JudgeCode], [JudgeName], [JudgeRemarks], [JudgeStatus], [UserId], [JudgeDateTimeStamp], [TerminalName]) VALUES (1, NULL, N'Abdul Waheed Siddiqi', N'Okay Okay Now', 1, NULL, NULL, NULL)
INSERT [dbo].[Judges] ([JudgeId], [JudgeCode], [JudgeName], [JudgeRemarks], [JudgeStatus], [UserId], [JudgeDateTimeStamp], [TerminalName]) VALUES (2, N'J2', N'Chaudhry Zafar', N'Achy Judge Hain', 0, NULL, CAST(0x0000A65600F386DE AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Judges] ([JudgeId], [JudgeCode], [JudgeName], [JudgeRemarks], [JudgeStatus], [UserId], [JudgeDateTimeStamp], [TerminalName]) VALUES (3, N'J3', N'Muhammad Yousuf', N'Good', 1, NULL, CAST(0x0000A65601007A83 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Judges] ([JudgeId], [JudgeCode], [JudgeName], [JudgeRemarks], [JudgeStatus], [UserId], [JudgeDateTimeStamp], [TerminalName]) VALUES (4, N'J4', N'Muhammad Husnain', N'Good', 1, NULL, CAST(0x0000A65601037F77 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Judges] ([JudgeId], [JudgeCode], [JudgeName], [JudgeRemarks], [JudgeStatus], [UserId], [JudgeDateTimeStamp], [TerminalName]) VALUES (5, N'J5', N'Sardar Muhammad Raza Khan', N'Good', 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00FDB143 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (1, N'F-1', N'Introducing Razor Syntax.pdf', NULL, N'c:\users\zubair\documents\visual studio 2015\Projects\JSearch\JSearch\Files\Introducing Razor Syntax.pdf', NULL, 3, NULL, 2, NULL, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65800CB90F0 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (2, N'F-2', N'1992 SCMR 2184.doc', NULL, N'c:\users\zubair\documents\visual studio 2015\Projects\JSearch\JSearch\Files\1992 SCMR 2184.doc', NULL, 2, NULL, 1, N'1992', N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00C5984C AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (3, N'F-3', N'1991 SCMR 2063.docx', NULL, N'', NULL, 2, NULL, 1, N'1991', N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00C6CDE3 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (4, N'F-4', N'2014 MLD 1602.docx', NULL, N'c:\users\zubair\documents\visual studio 2015\Projects\JSearch\JSearch\Files\2014 MLD 1602.docx', NULL, 0, NULL, 0, NULL, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00D556AF AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (5, N'F-5', N'2014 MLD 1602.docx', NULL, N'c:\users\zubair\documents\visual studio 2015\Projects\JSearch\JSearch\Files\2014 MLD 1602.docx', NULL, 0, NULL, 0, NULL, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00D5B7CE AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[LawFiles] ([FileId], [FileCode], [FileTitle], [FileDescription], [FilePath], [FileAbstract], [JudgeId], [FileRemarks], [CourtId], [FileYear], [UserId], [FileDateTimeStamp], [TerminalName]) VALUES (6, N'F-6', N'treating application as under order iX ruel13.docx', NULL, N'c:\users\zubair\documents\visual studio 2015\Projects\JSearch\JSearch\Files\treating application as under order iX ruel13.docx', NULL, 2, NULL, 1, N'2004', N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65C00F1B2D3 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (1, N'AC', N'Acts', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (2, N'CV', N'Civil Matters', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (3, N'CR', N'Criminal Matters', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (4, N'FM', N'Family Matters', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (5, N'SM', N'Service Matters', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Laws] ([LawId], [LawCode], [LawTitle], [LawRemarks], [LawStatus], [UserId], [LawDateTimeStamp], [TerminalName]) VALUES (6, N'WP', N'Words and Phrases', NULL, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', CAST(0x0000A65600B8F2D7 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Sections] ([SectionId], [SectionCode], [SectionName], [LawId], [SectionRefId], [SectionStatus], [UserId], [SectionRemarks], [SectionDateTimeStamp], [TerminalName]) VALUES (1, N'S-1', N'7 Rule 11', 2, 0, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', N'Civil     ', CAST(0x0000A65C00B04621 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Sections] ([SectionId], [SectionCode], [SectionName], [LawId], [SectionRefId], [SectionStatus], [UserId], [SectionRemarks], [SectionDateTimeStamp], [TerminalName]) VALUES (2, N'S-2', N'12(2) CPC', 2, 0, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', N'Under Civil Law', CAST(0x0000A65C00C1CEA5 AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Sections] ([SectionId], [SectionCode], [SectionName], [LawId], [SectionRefId], [SectionStatus], [UserId], [SectionRemarks], [SectionDateTimeStamp], [TerminalName]) VALUES (3, N'S-3', N'Adverse Posession', 2, 0, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', N'Anything', CAST(0x0000A65C00C68F9A AS DateTime), N'ZUBAIR-PC')
INSERT [dbo].[Sections] ([SectionId], [SectionCode], [SectionName], [LawId], [SectionRefId], [SectionStatus], [UserId], [SectionRemarks], [SectionDateTimeStamp], [TerminalName]) VALUES (4, N'S-4', N'Ammendment of Pleadings', 2, 0, 1, N'6e887d7c-74c6-41ed-9e50-d32bc9f87bfc', NULL, CAST(0x0000A65C00F468F1 AS DateTime), N'ZUBAIR-PC')
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [JSearchDB] SET  READ_WRITE 
GO
