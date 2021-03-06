USE [DataModelingAndERDiagrams]
GO
ALTER TABLE [dbo].[Words] DROP CONSTRAINT [FK_Words_Words]
GO
ALTER TABLE [dbo].[Words] DROP CONSTRAINT [FK_Words_Translations]
GO
ALTER TABLE [dbo].[Words] DROP CONSTRAINT [FK_Words_LexicalCategories]
GO
ALTER TABLE [dbo].[Words] DROP CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Translations] DROP CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations] DROP CONSTRAINT [FK_Translations_Languages]
GO
ALTER TABLE [dbo].[Translations] DROP CONSTRAINT [FK_Translations_Explanations]
GO
ALTER TABLE [dbo].[Towns] DROP CONSTRAINT [FK_Towns_Countries]
GO
ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[ProfessorsTitles] DROP CONSTRAINT [FK_ProfessorsTitles_Titles]
GO
ALTER TABLE [dbo].[ProfessorsTitles] DROP CONSTRAINT [FK_ProfessorsTitles_Professors]
GO
ALTER TABLE [dbo].[People] DROP CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[DepartmentsProfessors] DROP CONSTRAINT [FK_DepartmentsProfessors_Professors]
GO
ALTER TABLE [dbo].[DepartmentsProfessors] DROP CONSTRAINT [FK_DepartmentsProfessors_Departments]
GO
ALTER TABLE [dbo].[DepartmentsCourses] DROP CONSTRAINT [FK_DepartmentsCourses_Departments]
GO
ALTER TABLE [dbo].[DepartmentsCourses] DROP CONSTRAINT [FK_DepartmentsCourses_Courses]
GO
ALTER TABLE [dbo].[Departments] DROP CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[CoursesStudents] DROP CONSTRAINT [FK_CoursesStudents_Students]
GO
ALTER TABLE [dbo].[CoursesStudents] DROP CONSTRAINT [FK_CoursesStudents_Courses]
GO
ALTER TABLE [dbo].[Countries] DROP CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_Addresses_Towns]
GO
/****** Object:  Table [dbo].[Words]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Words]
GO
/****** Object:  Table [dbo].[Translations]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Translations]
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Towns]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Titles]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Students]
GO
/****** Object:  Table [dbo].[ProfessorsTitles]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[ProfessorsTitles]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Professors]
GO
/****** Object:  Table [dbo].[People]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[People]
GO
/****** Object:  Table [dbo].[LexicalCategories]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[LexicalCategories]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Languages]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Faculties]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Explanations]
GO
/****** Object:  Table [dbo].[DepartmentsProfessors]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[DepartmentsProfessors]
GO
/****** Object:  Table [dbo].[DepartmentsCourses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[DepartmentsCourses]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Departments]
GO
/****** Object:  Table [dbo].[CoursesStudents]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[CoursesStudents]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Courses]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Countries]
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Continents]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP TABLE [dbo].[Addresses]
GO
USE [master]
GO
/****** Object:  Database [DataModelingAndERDiagrams]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
DROP DATABASE [DataModelingAndERDiagrams]
GO
/****** Object:  Database [DataModelingAndERDiagrams]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
CREATE DATABASE [DataModelingAndERDiagrams]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingAndERDiagrams', FILENAME = N'F:\PROGRAMMING\TELERIKACADEMY\12Databases\HOMEWORK\03Data-Modeling-and-ER-Diagrams\DataModelingAndERDiagrams.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingAndERDiagrams_log', FILENAME = N'F:\PROGRAMMING\TELERIKACADEMY\12Databases\HOMEWORK\03Data-Modeling-and-ER-Diagrams\DataModelingAndERDiagrams_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModelingAndERDiagrams].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET  MULTI_USER 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DataModelingAndERDiagrams]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContitnentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContitnentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoursesStudents]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesStudents](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_CoursesStudents] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DepartmentsCourses]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentsCourses](
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentsCourses] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DepartmentsProfessors]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentsProfessors](
	[DepartmentId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentsProfessors] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [ntext] NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LexicalCategories]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LexicalCategories](
	[LexicalCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LexicalCategories] PRIMARY KEY CLUSTERED 
(
	[LexicalCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsTitles]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsTitles](
	[ProfessorId] [int] NOT NULL,
	[TitleId] [int] NOT NULL,
 CONSTRAINT [PK_ProfessorsTitles] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[TitleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[TranslationId] [int] IDENTITY(1,1) NOT NULL,
	[WordId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[ExplanationId] [int] NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[TranslationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 24.8.2014 г. 14:59:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](100) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[LexicalCategoryId] [int] NULL,
	[SynonymId] [int] NULL,
	[TranslationId] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [Street], [Number], [TownId]) VALUES (1, N'Rakovski', 101, 1)
INSERT [dbo].[Addresses] ([AddressId], [Street], [Number], [TownId]) VALUES (2, N'Gurko', 30, 1)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (3, N'Africa')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (4, N'Australia')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (5, N'North America')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (6, N'South America')
INSERT [dbo].[Continents] ([ContitnentId], [Name]) VALUES (7, N'Antarctica')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (2, N'Spain', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (3, N'Romania', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Ivan', N'Ivanov', 1)
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Gergana', N'Ivanova', 1)
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Trayan', N'Trayanov', 2)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (4, N'Burgas', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (5, N'Madrid', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (6, N'Bucharest', 3)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContitnentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[CoursesStudents]  WITH CHECK ADD  CONSTRAINT [FK_CoursesStudents_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CoursesStudents] CHECK CONSTRAINT [FK_CoursesStudents_Courses]
GO
ALTER TABLE [dbo].[CoursesStudents]  WITH CHECK ADD  CONSTRAINT [FK_CoursesStudents_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[CoursesStudents] CHECK CONSTRAINT [FK_CoursesStudents_Students]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FacultyId])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[DepartmentsCourses]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsCourses_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[DepartmentsCourses] CHECK CONSTRAINT [FK_DepartmentsCourses_Courses]
GO
ALTER TABLE [dbo].[DepartmentsCourses]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsCourses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentsCourses] CHECK CONSTRAINT [FK_DepartmentsCourses_Departments]
GO
ALTER TABLE [dbo].[DepartmentsProfessors]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsProfessors_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentsProfessors] CHECK CONSTRAINT [FK_DepartmentsProfessors_Departments]
GO
ALTER TABLE [dbo].[DepartmentsProfessors]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsProfessors_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[DepartmentsProfessors] CHECK CONSTRAINT [FK_DepartmentsProfessors_Professors]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[ProfessorsTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsTitles_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[ProfessorsTitles] CHECK CONSTRAINT [FK_ProfessorsTitles_Professors]
GO
ALTER TABLE [dbo].[ProfessorsTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsTitles_Titles] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Titles] ([TitleId])
GO
ALTER TABLE [dbo].[ProfessorsTitles] CHECK CONSTRAINT [FK_ProfessorsTitles_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FacultyId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Explanations] FOREIGN KEY([ExplanationId])
REFERENCES [dbo].[Explanations] ([ExplanationId])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Explanations]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_LexicalCategories] FOREIGN KEY([LexicalCategoryId])
REFERENCES [dbo].[LexicalCategories] ([LexicalCategoryId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_LexicalCategories]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations] FOREIGN KEY([TranslationId])
REFERENCES [dbo].[Translations] ([TranslationId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Translations]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Words] FOREIGN KEY([SynonymId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Words]
GO
USE [master]
GO
ALTER DATABASE [DataModelingAndERDiagrams] SET  READ_WRITE 
GO
