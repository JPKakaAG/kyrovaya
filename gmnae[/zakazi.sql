CREATE TABLE [dbo].[Заказы](
	[IDЗаказа] [int] IDENTITY(1,1) NOT NULL,
	[IDКомплектующего] [int] NOT NULL,
	[IDСклада] [int] NOT NULL,
	[Iduser] [int] NOT NULL,
	[ДатаЗаказа] [datetime] NOT NULL,
	[Количество] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDЗаказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD FOREIGN KEY([IDКомплектующего])
REFERENCES [dbo].[Комплектующие] ([IDКомплектующего])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD FOREIGN KEY([IDСклада])
REFERENCES [dbo].[Склад] ([IDСклада])
GO

ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD FOREIGN KEY([Iduser])
REFERENCES [dbo].[Users] ([Iduser])
ON DELETE CASCADE
GO
