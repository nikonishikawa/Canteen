USE [master]
GO
/****** Object:  Database [Canteen]    Script Date: 24/03/2024 10:09:38 pm ******/
CREATE DATABASE [Canteen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Canteen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Canteen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Canteen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Canteen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Canteen] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Canteen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Canteen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Canteen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Canteen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Canteen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Canteen] SET ARITHABORT OFF 
GO
ALTER DATABASE [Canteen] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Canteen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Canteen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Canteen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Canteen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Canteen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Canteen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Canteen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Canteen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Canteen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Canteen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Canteen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Canteen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Canteen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Canteen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Canteen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Canteen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Canteen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Canteen] SET  MULTI_USER 
GO
ALTER DATABASE [Canteen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Canteen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Canteen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Canteen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Canteen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Canteen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Canteen] SET QUERY_STORE = OFF
GO
USE [Canteen]
GO
/****** Object:  Table [dbo].[TblAddress]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAddress](
	[AddressID] [bigint] IDENTITY(1,1) NOT NULL,
	[Barangay] [nvarchar](50) NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
	[Postal_Code] [nchar](4) NOT NULL,
 CONSTRAINT [PK_TblAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblAddressGeneral]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAddressGeneral](
	[GenAddressID] [bigint] IDENTITY(1,1) NOT NULL,
	[AddressID] [bigint] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ContactNumber] [nchar](15) NOT NULL,
 CONSTRAINT [PK_TblAddressGeneral] PRIMARY KEY CLUSTERED 
(
	[GenAddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblAdmin]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAdmin](
	[AdminID] [bigint] IDENTITY(1,1) NOT NULL,
	[AdminCredentials] [bigint] NOT NULL,
	[AdminName] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblAdmin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArchive]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArchive](
	[ArchiveID] [bigint] IDENTITY(1,1) NOT NULL,
	[ArchivedBy] [bigint] NOT NULL,
	[ArchiveStamp] [datetime] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblArchive] PRIMARY KEY CLUSTERED 
(
	[ArchiveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCategory]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCategory](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCourier]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCourier](
	[CourierID] [bigint] IDENTITY(1,1) NOT NULL,
	[Courier] [nvarchar](50) NOT NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK_TblCourier] PRIMARY KEY CLUSTERED 
(
	[CourierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCredentials]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCredentials](
	[CredentialsID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblCredentials] PRIMARY KEY CLUSTERED 
(
	[CredentialsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCustomer]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[CusCredentials] [bigint] NOT NULL,
	[CusName] [bigint] NOT NULL,
	[CusAddress] [bigint] NOT NULL,
	[Membership] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblItems]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblItems](
	[ItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[Item] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[FoodImage] [nvarchar](50) NULL,
	[isHalal] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Category] [bigint] NOT NULL,
 CONSTRAINT [PK_TblViand] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMembership]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMembership](
	[MemberShipID] [bigint] IDENTITY(1,1) NOT NULL,
	[Membership] [nvarchar](50) NOT NULL,
	[LoyaltyPoints] [smallint] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblMembership] PRIMARY KEY CLUSTERED 
(
	[MemberShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblModeOfPayment]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblModeOfPayment](
	[ModeOfPaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[ModeOfPayment] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TblModeOfPayment] PRIMARY KEY CLUSTERED 
(
	[ModeOfPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblName]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblName](
	[NameID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblName] PRIMARY KEY CLUSTERED 
(
	[NameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderCancelled]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderCancelled](
	[OrderCancelledID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[CancelledBy] [bigint] NOT NULL,
	[CancelledStamp] [datetime] NOT NULL,
	[Reason] [nvarchar](100) NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblOrderCancelled] PRIMARY KEY CLUSTERED 
(
	[OrderCancelledID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderCompleted]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderCompleted](
	[OrderCompletedID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[CompletedStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_TblOrderCompleted] PRIMARY KEY CLUSTERED 
(
	[OrderCompletedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderItem]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderItem](
	[OrderItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[Item] [bigint] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblOrderItem] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderStatus]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderStatus](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[CusID] [bigint] NOT NULL,
	[OrderStamp] [datetime] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[ModeOfPayment] [bigint] NOT NULL,
 CONSTRAINT [PK_TblOrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblParcelInfo]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblParcelInfo](
	[TrackingID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[ShipStamp] [datetime] NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Courier] [bigint] NOT NULL,
	[Notes] [nvarchar](50) NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblParcelInfo] PRIMARY KEY CLUSTERED 
(
	[TrackingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPosition]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPosition](
	[PositionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblPosition] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblShippingStatus]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblShippingStatus](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblShippingStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTicket]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTicket](
	[TicketID] [bigint] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](25) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedStamp] [datetime] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[CateredBy] [bigint] NOT NULL,
	[CateredStamp] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
	[Priority] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TblTicket] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTicketStatus]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTicketStatus](
	[TicketStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TblTicketStatus] PRIMARY KEY CLUSTERED 
(
	[TicketStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTray]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTray](
	[TrayID] [bigint] IDENTITY(1,1) NOT NULL,
	[CusID] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblTray] PRIMARY KEY CLUSTERED 
(
	[TrayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTrayItems]    Script Date: 24/03/2024 10:09:38 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTrayItems](
	[TrayItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[TrayID] [bigint] NOT NULL,
	[Item] [bigint] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[AddStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_TblTrayItems] PRIMARY KEY CLUSTERED 
(
	[TrayItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTrayItemsTemp]    Script Date: 24/03/2024 10:09:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTrayItemsTemp](
	[TrayItemTempID] [bigint] IDENTITY(1,1) NOT NULL,
	[TrayTempID] [bigint] NOT NULL,
	[Item] [bigint] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[AddStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_TblTrayItemsTemp] PRIMARY KEY CLUSTERED 
(
	[TrayItemTempID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTrayStatus]    Script Date: 24/03/2024 10:09:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTrayStatus](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblTrayStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTrayTemp]    Script Date: 24/03/2024 10:09:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTrayTemp](
	[TrayTempID] [bigint] IDENTITY(1,1) NOT NULL,
	[CusID] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblTrayTemp] PRIMARY KEY CLUSTERED 
(
	[TrayTempID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUserStatus]    Script Date: 24/03/2024 10:09:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserStatus](
	[UserStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TblUserStatus] PRIMARY KEY CLUSTERED 
(
	[UserStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblVendor]    Script Date: 24/03/2024 10:09:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblVendor](
	[VendorID] [bigint] IDENTITY(1,1) NOT NULL,
	[VendCredentials] [bigint] NOT NULL,
	[VendName] [bigint] NOT NULL,
	[VendAddress] [bigint] NOT NULL,
	[Position] [bigint] NOT NULL,
	[Status] [bigint] NOT NULL,
 CONSTRAINT [PK_TblVendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblArchive] ADD  CONSTRAINT [DF_TblArchive_ArchiveStam[p]  DEFAULT (getdate()) FOR [ArchiveStamp]
GO
ALTER TABLE [dbo].[TblOrderCancelled] ADD  CONSTRAINT [DF_TblOrderCancelled_CancelledStamp]  DEFAULT (getdate()) FOR [CancelledStamp]
GO
ALTER TABLE [dbo].[TblTicket] ADD  CONSTRAINT [DF_TblTicket_CreatedStamp]  DEFAULT (getdate()) FOR [CreatedStamp]
GO
ALTER TABLE [dbo].[TblAddressGeneral]  WITH CHECK ADD  CONSTRAINT [FK_TblAddressGeneral_TblAddress] FOREIGN KEY([AddressID])
REFERENCES [dbo].[TblAddress] ([AddressID])
GO
ALTER TABLE [dbo].[TblAddressGeneral] CHECK CONSTRAINT [FK_TblAddressGeneral_TblAddress]
GO
ALTER TABLE [dbo].[TblAdmin]  WITH CHECK ADD  CONSTRAINT [FK_TblAdmin_TblCredentials] FOREIGN KEY([AdminCredentials])
REFERENCES [dbo].[TblCredentials] ([CredentialsID])
GO
ALTER TABLE [dbo].[TblAdmin] CHECK CONSTRAINT [FK_TblAdmin_TblCredentials]
GO
ALTER TABLE [dbo].[TblAdmin]  WITH CHECK ADD  CONSTRAINT [FK_TblAdmin_TblName] FOREIGN KEY([AdminName])
REFERENCES [dbo].[TblName] ([NameID])
GO
ALTER TABLE [dbo].[TblAdmin] CHECK CONSTRAINT [FK_TblAdmin_TblName]
GO
ALTER TABLE [dbo].[TblArchive]  WITH CHECK ADD  CONSTRAINT [FK_TblArchive_TblAdmin] FOREIGN KEY([ArchivedBy])
REFERENCES [dbo].[TblAdmin] ([AdminID])
GO
ALTER TABLE [dbo].[TblArchive] CHECK CONSTRAINT [FK_TblArchive_TblAdmin]
GO
ALTER TABLE [dbo].[TblArchive]  WITH CHECK ADD  CONSTRAINT [FK_TblArchive_TblUserStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[TblUserStatus] ([UserStatusID])
GO
ALTER TABLE [dbo].[TblArchive] CHECK CONSTRAINT [FK_TblArchive_TblUserStatus]
GO
ALTER TABLE [dbo].[TblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomer_TblAddressGeneral] FOREIGN KEY([CusAddress])
REFERENCES [dbo].[TblAddressGeneral] ([GenAddressID])
GO
ALTER TABLE [dbo].[TblCustomer] CHECK CONSTRAINT [FK_TblCustomer_TblAddressGeneral]
GO
ALTER TABLE [dbo].[TblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomer_TblCredentials] FOREIGN KEY([CusCredentials])
REFERENCES [dbo].[TblCredentials] ([CredentialsID])
GO
ALTER TABLE [dbo].[TblCustomer] CHECK CONSTRAINT [FK_TblCustomer_TblCredentials]
GO
ALTER TABLE [dbo].[TblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomer_TblMembership] FOREIGN KEY([Membership])
REFERENCES [dbo].[TblMembership] ([MemberShipID])
GO
ALTER TABLE [dbo].[TblCustomer] CHECK CONSTRAINT [FK_TblCustomer_TblMembership]
GO
ALTER TABLE [dbo].[TblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomer_TblName] FOREIGN KEY([CusName])
REFERENCES [dbo].[TblName] ([NameID])
GO
ALTER TABLE [dbo].[TblCustomer] CHECK CONSTRAINT [FK_TblCustomer_TblName]
GO
ALTER TABLE [dbo].[TblItems]  WITH CHECK ADD  CONSTRAINT [FK_TblViand_TblCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[TblCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[TblItems] CHECK CONSTRAINT [FK_TblViand_TblCategory]
GO
ALTER TABLE [dbo].[TblOrderCancelled]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderCancelled_TblOrderStatus] FOREIGN KEY([OrderID])
REFERENCES [dbo].[TblOrderStatus] ([OrderID])
GO
ALTER TABLE [dbo].[TblOrderCancelled] CHECK CONSTRAINT [FK_TblOrderCancelled_TblOrderStatus]
GO
ALTER TABLE [dbo].[TblOrderCompleted]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderCompleted_TblOrderStatus] FOREIGN KEY([OrderID])
REFERENCES [dbo].[TblOrderStatus] ([OrderID])
GO
ALTER TABLE [dbo].[TblOrderCompleted] CHECK CONSTRAINT [FK_TblOrderCompleted_TblOrderStatus]
GO
ALTER TABLE [dbo].[TblOrderItem]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderItem_TblOrderStatus] FOREIGN KEY([OrderID])
REFERENCES [dbo].[TblOrderStatus] ([OrderID])
GO
ALTER TABLE [dbo].[TblOrderItem] CHECK CONSTRAINT [FK_TblOrderItem_TblOrderStatus]
GO
ALTER TABLE [dbo].[TblOrderItem]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderItem_TblViand] FOREIGN KEY([Item])
REFERENCES [dbo].[TblItems] ([ItemID])
GO
ALTER TABLE [dbo].[TblOrderItem] CHECK CONSTRAINT [FK_TblOrderItem_TblViand]
GO
ALTER TABLE [dbo].[TblOrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderStatus_TblCustomer] FOREIGN KEY([CusID])
REFERENCES [dbo].[TblCustomer] ([CustomerID])
GO
ALTER TABLE [dbo].[TblOrderStatus] CHECK CONSTRAINT [FK_TblOrderStatus_TblCustomer]
GO
ALTER TABLE [dbo].[TblOrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderStatus_TblModeOfPayment] FOREIGN KEY([ModeOfPayment])
REFERENCES [dbo].[TblModeOfPayment] ([ModeOfPaymentID])
GO
ALTER TABLE [dbo].[TblOrderStatus] CHECK CONSTRAINT [FK_TblOrderStatus_TblModeOfPayment]
GO
ALTER TABLE [dbo].[TblParcelInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblParcelInfo_TblCourier] FOREIGN KEY([Courier])
REFERENCES [dbo].[TblCourier] ([CourierID])
GO
ALTER TABLE [dbo].[TblParcelInfo] CHECK CONSTRAINT [FK_TblParcelInfo_TblCourier]
GO
ALTER TABLE [dbo].[TblParcelInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblParcelInfo_TblOrderStatus] FOREIGN KEY([OrderID])
REFERENCES [dbo].[TblOrderStatus] ([OrderID])
GO
ALTER TABLE [dbo].[TblParcelInfo] CHECK CONSTRAINT [FK_TblParcelInfo_TblOrderStatus]
GO
ALTER TABLE [dbo].[TblParcelInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblParcelInfo_TblShippingStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[TblShippingStatus] ([StatusID])
GO
ALTER TABLE [dbo].[TblParcelInfo] CHECK CONSTRAINT [FK_TblParcelInfo_TblShippingStatus]
GO
ALTER TABLE [dbo].[TblTicket]  WITH CHECK ADD  CONSTRAINT [FK_TblTicket_TblCustomer] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblCustomer] ([CustomerID])
GO
ALTER TABLE [dbo].[TblTicket] CHECK CONSTRAINT [FK_TblTicket_TblCustomer]
GO
ALTER TABLE [dbo].[TblTicket]  WITH CHECK ADD  CONSTRAINT [FK_TblTicket_TblTicketStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[TblTicketStatus] ([TicketStatusID])
GO
ALTER TABLE [dbo].[TblTicket] CHECK CONSTRAINT [FK_TblTicket_TblTicketStatus]
GO
ALTER TABLE [dbo].[TblTray]  WITH CHECK ADD  CONSTRAINT [FK_TblTray_TblCustomer] FOREIGN KEY([CusID])
REFERENCES [dbo].[TblCustomer] ([CustomerID])
GO
ALTER TABLE [dbo].[TblTray] CHECK CONSTRAINT [FK_TblTray_TblCustomer]
GO
ALTER TABLE [dbo].[TblTray]  WITH CHECK ADD  CONSTRAINT [FK_TblTray_TblTrayStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[TblTrayStatus] ([StatusID])
GO
ALTER TABLE [dbo].[TblTray] CHECK CONSTRAINT [FK_TblTray_TblTrayStatus]
GO
ALTER TABLE [dbo].[TblTrayItems]  WITH CHECK ADD  CONSTRAINT [FK_TblTrayItems_TblTray] FOREIGN KEY([TrayID])
REFERENCES [dbo].[TblTray] ([TrayID])
GO
ALTER TABLE [dbo].[TblTrayItems] CHECK CONSTRAINT [FK_TblTrayItems_TblTray]
GO
ALTER TABLE [dbo].[TblTrayItemsTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblTrayItemsTemp_TblTrayTemp] FOREIGN KEY([TrayTempID])
REFERENCES [dbo].[TblTrayTemp] ([TrayTempID])
GO
ALTER TABLE [dbo].[TblTrayItemsTemp] CHECK CONSTRAINT [FK_TblTrayItemsTemp_TblTrayTemp]
GO
ALTER TABLE [dbo].[TblVendor]  WITH CHECK ADD  CONSTRAINT [FK_TblVendor_TblAddressGeneral] FOREIGN KEY([VendAddress])
REFERENCES [dbo].[TblAddressGeneral] ([GenAddressID])
GO
ALTER TABLE [dbo].[TblVendor] CHECK CONSTRAINT [FK_TblVendor_TblAddressGeneral]
GO
ALTER TABLE [dbo].[TblVendor]  WITH CHECK ADD  CONSTRAINT [FK_TblVendor_TblCredentials] FOREIGN KEY([VendCredentials])
REFERENCES [dbo].[TblCredentials] ([CredentialsID])
GO
ALTER TABLE [dbo].[TblVendor] CHECK CONSTRAINT [FK_TblVendor_TblCredentials]
GO
ALTER TABLE [dbo].[TblVendor]  WITH CHECK ADD  CONSTRAINT [FK_TblVendor_TblName] FOREIGN KEY([VendName])
REFERENCES [dbo].[TblName] ([NameID])
GO
ALTER TABLE [dbo].[TblVendor] CHECK CONSTRAINT [FK_TblVendor_TblName]
GO
ALTER TABLE [dbo].[TblVendor]  WITH CHECK ADD  CONSTRAINT [FK_TblVendor_TblPosition] FOREIGN KEY([Position])
REFERENCES [dbo].[TblPosition] ([PositionID])
GO
ALTER TABLE [dbo].[TblVendor] CHECK CONSTRAINT [FK_TblVendor_TblPosition]
GO
USE [master]
GO
ALTER DATABASE [Canteen] SET  READ_WRITE 
GO
