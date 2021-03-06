USE [projet]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [int] NULL,
	[Role] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedDate] [datetime] NULL,
	[Salt] [varchar](250) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Content] [varchar](max) NULL,
	[Image] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
	[ListImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[Status] [bit] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[Note] [nvarchar](500) NULL,
	[UserId] [int] NULL,
	[Fee] [nvarchar](500) NULL,
	[ShipMethod] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[TotalPrice] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Amount] [int] NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[CategoryID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Image] [varchar](100) NULL,
	[ListImage] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 11/10/2020 11:22:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[IDReview] [int] NOT NULL,
	[Content] [nvarchar](100) NULL,
	[Rating] [int] NULL,
	[ProductID] [int] NULL,
 CONSTRAINT [PK_Review_1] PRIMARY KEY CLUSTERED 
(
	[IDReview] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
