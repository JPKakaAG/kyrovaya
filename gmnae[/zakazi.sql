CREATE TABLE [dbo].[������](
	[ID������] [int] IDENTITY(1,1) NOT NULL,
	[ID��������������] [int] NOT NULL,
	[ID������] [int] NOT NULL,
	[Iduser] [int] NOT NULL,
	[����������] [datetime] NOT NULL,
	[����������] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[������]  WITH CHECK ADD FOREIGN KEY([ID��������������])
REFERENCES [dbo].[�������������] ([ID��������������])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[������]  WITH CHECK ADD FOREIGN KEY([ID������])
REFERENCES [dbo].[�����] ([ID������])
GO

ALTER TABLE [dbo].[������]  WITH CHECK ADD FOREIGN KEY([Iduser])
REFERENCES [dbo].[Users] ([Iduser])
ON DELETE CASCADE
GO
