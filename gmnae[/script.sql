USE [kyrsovaya]
GO
/****** Object:  Table [dbo].[Комплектующие]    Script Date: 08.05.2024 3:30:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Комплектующие](
	[IDКомплектующего] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеКомплектующего] [varchar](50) NOT NULL,
	[IDПроизводителя] [int] NULL,
	[IDТИпаКомплектующего] [int] NULL,
	[Цена] [decimal](10, 2) NOT NULL,
	[IDСклада] [int] NULL,
	[КолвоНаСкладе] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDКомплектующего] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Отгрузки]    Script Date: 08.05.2024 3:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Отгрузки](
	[IDОтгрузки] [int] IDENTITY(1,1) NOT NULL,
	[IDКомплектующего] [int] NULL,
	[IDСклада] [int] NULL,
	[ДатаОтгрузки] [date] NULL,
	[Колво] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDОтгрузки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Приемка]    Script Date: 08.05.2024 3:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Приемка](
	[IDПриемки] [int] IDENTITY(1,1) NOT NULL,
	[IDКомплектующего] [int] NULL,
	[IDСклада] [int] NULL,
	[ДатаПоступления] [date] NULL,
	[КолвоПоступивших] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDПриемки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Производители]    Script Date: 08.05.2024 3:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Производители](
	[IDПроизводителя] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеПроизводителя] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDПроизводителя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Склад]    Script Date: 08.05.2024 3:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Склад](
	[IDСклада] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDСклада] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипыКомплектующего]    Script Date: 08.05.2024 3:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипыКомплектующего](
	[IDТипаКомплектующего] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеТипаКомплектующего] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDТипаКомплектующего] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Комплектующие]  WITH CHECK ADD FOREIGN KEY([IDПроизводителя])
REFERENCES [dbo].[Производители] ([IDПроизводителя])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Комплектующие]  WITH CHECK ADD FOREIGN KEY([IDСклада])
REFERENCES [dbo].[Склад] ([IDСклада])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Комплектующие]  WITH CHECK ADD FOREIGN KEY([IDТИпаКомплектующего])
REFERENCES [dbo].[ТипыКомплектующего] ([IDТипаКомплектующего])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Отгрузки]  WITH CHECK ADD FOREIGN KEY([IDКомплектующего])
REFERENCES [dbo].[Комплектующие] ([IDКомплектующего])
GO
ALTER TABLE [dbo].[Отгрузки]  WITH CHECK ADD FOREIGN KEY([IDСклада])
REFERENCES [dbo].[Склад] ([IDСклада])
GO
ALTER TABLE [dbo].[Приемка]  WITH CHECK ADD FOREIGN KEY([IDКомплектующего])
REFERENCES [dbo].[Комплектующие] ([IDКомплектующего])
GO
ALTER TABLE [dbo].[Приемка]  WITH CHECK ADD FOREIGN KEY([IDСклада])
REFERENCES [dbo].[Склад] ([IDСклада])
GO
ALTER TABLE [dbo].[Комплектующие]  WITH CHECK ADD  CONSTRAINT [chk_Price] CHECK  (([Цена]>=(0)))
GO
ALTER TABLE [dbo].[Комплектующие] CHECK CONSTRAINT [chk_Price]
GO
ALTER TABLE [dbo].[Комплектующие]  WITH CHECK ADD  CONSTRAINT [chk_StockQuantity] CHECK  (([КолвоНаСкладе]>=(0)))
GO
ALTER TABLE [dbo].[Комплектующие] CHECK CONSTRAINT [chk_StockQuantity]
GO
