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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Idrole] [int] NOT NULL,
	[Role1] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idrole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14.06.2024 10:41:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Iduser] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NULL,
	[Idrole] [int] NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Login] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Iduser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
INSERT [dbo].[Roles] ([Idrole], [Role1]) VALUES (1, N'Клиент')
INSERT [dbo].[Roles] ([Idrole], [Role1]) VALUES (2, N'Менеджер')
INSERT [dbo].[Roles] ([Idrole], [Role1]) VALUES (3, N'Администратор')
GO
INSERT [dbo].[Users] ([Iduser], [Name], [Surname], [Patronymic], [Idrole], [Password], [Login]) VALUES (1, N'Вадим', N'Девяткин', N'Евгеньевич', 3, N'1234567890', N'admin')
INSERT [dbo].[Users] ([Iduser], [Name], [Surname], [Patronymic], [Idrole], [Password], [Login]) VALUES (2, N'Пётр', N'Петров', N'Петрович', 2, N'1234567890', N'manager')
INSERT [dbo].[Users] ([Iduser], [Name], [Surname], [Patronymic], [Idrole], [Password], [Login]) VALUES (3, N'Иван', N'Иванов', N'Иванович', 1, N'1234567890', N'Client')