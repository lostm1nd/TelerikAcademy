USE [master]
GO
/****** Object:  Database [TransactSQL]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
CREATE DATABASE [TransactSQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransactSQL', FILENAME = N'F:\PROGRAMMING\TELERIKACADEMY\12Databases\HOMEWORK\06Transact-SQL\TransactSQL.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TransactSQL_log', FILENAME = N'F:\PROGRAMMING\TELERIKACADEMY\12Databases\HOMEWORK\06Transact-SQL\TransactSQL_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TransactSQL] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransactSQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransactSQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransactSQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TransactSQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransactSQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransactSQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransactSQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransactSQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransactSQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransactSQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransactSQL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TransactSQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransactSQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransactSQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransactSQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransactSQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransactSQL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TransactSQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransactSQL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TransactSQL] SET  MULTI_USER 
GO
ALTER DATABASE [TransactSQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransactSQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransactSQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransactSQL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TransactSQL]
GO
/****** Object:  StoredProcedure [dbo].[usp_CalculateInterestForOneMonth]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CalculateInterestForOneMonth](@accountId int, @interest float)
AS
	SELECT TransactSQL.dbo.ufn_CalculateInterest(Balance, @interest, 1)
	FROM Accounts
	WHERE AccountId = @accountId

GO
/****** Object:  StoredProcedure [dbo].[usp_DepositMoney]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_DepositMoney](@accountId int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE AccountId = @accountId
	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_PersonWithBalanceMoreThan]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_PersonWithBalanceMoreThan](@balance as money)
AS
	SELECT *
		FROM Accounts a
			INNER JOIN People p
				ON a.PersonId = p.PersonId
	WHERE a.Balance > @balance

GO
/****** Object:  StoredProcedure [dbo].[usp_WithdrawMoney]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_WithdrawMoney](@accountId int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE AccountId = @accountId
	COMMIT

GO
/****** Object:  UserDefinedFunction [dbo].[ufn_CalculateInterest]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_CalculateInterest](@balance money, @interest float, @months int)
	RETURNS money
AS
BEGIN
	RETURN @balance * ( (@interest / 100) * (@months / 12.0))
END

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 26.8.2014 г. 00:30:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 26.8.2014 г. 00:30:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[OldSum] [money] NOT NULL,
	[NewSum] [money] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 26.8.2014 г. 00:30:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (1, 1, 150.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (4, 3, 1232.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (5, 4, 232.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (8, 6, 34444.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (9, 5, 1232.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (10, 2, 5500.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogId], [AccountId], [OldSum], [NewSum]) VALUES (4, 1, 100.0000, -100.0000)
INSERT [dbo].[Logs] ([LogId], [AccountId], [OldSum], [NewSum]) VALUES (5, 1, -100.0000, 100.0000)
INSERT [dbo].[Logs] ([LogId], [AccountId], [OldSum], [NewSum]) VALUES (6, 1, 100.0000, 300.0000)
INSERT [dbo].[Logs] ([LogId], [AccountId], [OldSum], [NewSum]) VALUES (7, 1, 300.0000, 150.0000)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (1, N'Peter', N'Petrov', N'PP88')
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (2, N'Ivan', N'Ivanov', N'II99')
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (3, N'Mariya', N'Mareva', N'MM00')
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (4, N'Kiril', N'Kirilov', N'KK55')
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (5, N'Krasimir', N'Krasimov', N'KK77')
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (6, N'Teodor', N'Teodorov', N'TT99')
SET IDENTITY_INSERT [dbo].[People] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_People] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_People]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Accounts]
GO
USE [master]
GO
ALTER DATABASE [TransactSQL] SET  READ_WRITE 
GO
