SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HealthData](
	[Email] [varchar](150) NOT NULL,
	[Weight] [varchar](max) NULL,
	[Height] [varchar](max) NULL,
	[BloodType] [varchar](max) NULL,
	[Diabetes] [varchar](max) NULL,
	[Epilepsy] [varchar](max) NULL,
	[Asma] [varchar](max) NULL,
	[Allergies] [varchar](max) NULL,
	[Observations] [varchar](max) NULL,
	[IDLinkHealthData] [nchar](10) NULL,
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_LeituraBandas]    Script Date: 28/06/2019 16:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_LeituraBandas](
	[IDM] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[Blob] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_RealTimeData]    Script Date: 28/06/2019 16:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_RealTimeData](
	[Email] [varchar](150) NOT NULL,
	[Lat] [varchar](max) NULL,
	[Lng] [varchar](max) NULL,
	[BPM] [varchar](max) NULL,
	[Temperatura] [varchar](max) NULL,
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_SOSEvent]    Script Date: 28/06/2019 16:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_SOSEvent](
	[SOSID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Relatorio] [varchar](max) NULL,
	[Data] [date] NULL,
	[IDLinkEvent] [varchar](max) NULL,
	[NomeOperador] [varchar](max) NULL,
 CONSTRAINT [PK__tb_SOSEv__860A2FEE7BDCA1A7] PRIMARY KEY CLUSTERED 
(
	[SOSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_User]    Script Date: 28/06/2019 16:12:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[Email] [varchar](150) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[LastName] [varchar](max) NOT NULL,
	[PhoneNumber] [varchar](max) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Gender] [varchar](max) NULL,
	[IDLinkUser] [varchar](max) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_HealthData]  WITH CHECK ADD  CONSTRAINT [FK_Email] FOREIGN KEY([Email])
REFERENCES [dbo].[tb_User] ([Email])
GO
ALTER TABLE [dbo].[tb_HealthData] CHECK CONSTRAINT [FK_Email]
GO
ALTER TABLE [dbo].[tb_RealTimeData]  WITH CHECK ADD  CONSTRAINT [TK_Email] FOREIGN KEY([Email])
REFERENCES [dbo].[tb_User] ([Email])
GO
ALTER TABLE [dbo].[tb_RealTimeData] CHECK CONSTRAINT [TK_Email]
GO
ALTER TABLE [dbo].[tb_SOSEvent]  WITH CHECK ADD  CONSTRAINT [UK_Email] FOREIGN KEY([Email])
REFERENCES [dbo].[tb_User] ([Email])
GO
ALTER TABLE [dbo].[tb_SOSEvent] CHECK CONSTRAINT [UK_Email]
GO