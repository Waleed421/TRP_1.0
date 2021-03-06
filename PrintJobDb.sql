USE [master]
GO
/****** Object:  Database [PrintJobDb]    Script Date: 8/30/2016 6:17:15 PM ******/
CREATE DATABASE [PrintJobDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrintJobDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PrintJobDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PrintJobDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PrintJobDb_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PrintJobDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrintJobDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrintJobDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrintJobDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrintJobDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrintJobDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrintJobDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrintJobDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrintJobDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrintJobDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrintJobDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrintJobDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrintJobDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrintJobDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrintJobDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrintJobDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrintJobDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrintJobDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrintJobDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrintJobDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrintJobDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrintJobDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrintJobDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PrintJobDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrintJobDb] SET RECOVERY FULL 
GO
ALTER DATABASE [PrintJobDb] SET  MULTI_USER 
GO
ALTER DATABASE [PrintJobDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrintJobDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrintJobDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrintJobDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PrintJobDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PrintJobDb]
GO
/****** Object:  Table [dbo].[Cases]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cases](
	[Case_No] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Case_Comment] [nvarchar](max) NULL,
	[Type_Id] [int] NULL,
	[Customer_Id] [int] NULL,
	[Date_Time_Created] [datetime] NULL,
	[Created_By_User_Id] [int] NULL,
	[Last_Edit_Date_Time] [datetime] NULL,
	[Last_Edit_By_User_Id] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Worked_Time_in_Minutes] [varchar](50) NULL,
	[Manual_Work_Time] [varchar](50) NULL,
 CONSTRAINT [PK_Cases] PRIMARY KEY CLUSTERED 
(
	[Case_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_No] [nvarchar](max) NULL,
	[Customer_Name] [nvarchar](max) NULL,
	[Customer_Status] [nvarchar](50) NULL,
	[User_Id] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrintJob]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrintJob](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Printer_Name] [nvarchar](max) NULL,
	[Document_Name] [nvarchar](max) NULL,
	[Document_Pages] [nvarchar](max) NULL,
	[Submitted_By] [nvarchar](max) NULL,
	[Submitted_At] [datetime] NULL,
	[Username] [nvarchar](max) NULL,
	[Customer_Id] [int] NULL,
 CONSTRAINT [PK_PrintJob] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeRegistration]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TimeRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Case_No] [int] NULL,
	[Start_Date_Time] [datetime] NULL,
	[Stop_Date_Time] [datetime] NULL,
	[Action_Comment] [nvarchar](max) NULL,
	[Invoice] [nvarchar](50) NULL,
	[Time_In_Minutes] [varchar](50) NULL,
	[User_Id] [int] NULL,
 CONSTRAINT [PK_TimeRegistration_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeofCases]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeofCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Invoice_Type] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypeofCases_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Username] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewReport]    Script Date: 8/30/2016 6:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewReport]
AS
SELECT        dbo.PrintJob.Printer_Name, dbo.PrintJob.Document_Name, dbo.PrintJob.Document_Pages, dbo.PrintJob.Submitted_By, dbo.PrintJob.Submitted_At, dbo.PrintJob.Username, dbo.Customer.Customer_Name, 
                         dbo.Customer.Customer_No
FROM            dbo.Customer INNER JOIN
                         dbo.PrintJob ON dbo.Customer.Id = dbo.PrintJob.Customer_Id

GO
ALTER TABLE [dbo].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Cases] CHECK CONSTRAINT [FK_Cases_Customer]
GO
ALTER TABLE [dbo].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_TypeofCases1] FOREIGN KEY([Type_Id])
REFERENCES [dbo].[TypeofCases] ([Id])
GO
ALTER TABLE [dbo].[Cases] CHECK CONSTRAINT [FK_Cases_TypeofCases1]
GO
ALTER TABLE [dbo].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_User] FOREIGN KEY([Created_By_User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Cases] CHECK CONSTRAINT [FK_Cases_User]
GO
ALTER TABLE [dbo].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_User1] FOREIGN KEY([Last_Edit_By_User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Cases] CHECK CONSTRAINT [FK_Cases_User1]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[PrintJob]  WITH CHECK ADD  CONSTRAINT [FK_PrintJob_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[PrintJob] CHECK CONSTRAINT [FK_PrintJob_Customer]
GO
ALTER TABLE [dbo].[TimeRegistration]  WITH CHECK ADD  CONSTRAINT [FK_TimeRegistration_Cases] FOREIGN KEY([Case_No])
REFERENCES [dbo].[Cases] ([Case_No])
GO
ALTER TABLE [dbo].[TimeRegistration] CHECK CONSTRAINT [FK_TimeRegistration_Cases]
GO
ALTER TABLE [dbo].[TimeRegistration]  WITH CHECK ADD  CONSTRAINT [FK_TimeRegistration_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TimeRegistration] CHECK CONSTRAINT [FK_TimeRegistration_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[35] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Customer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PrintJob"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 136
               Right = 436
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewReport'
GO
USE [master]
GO
ALTER DATABASE [PrintJobDb] SET  READ_WRITE 
GO
