USE [DemoDB]
GO

/****** Object:  Table [dbo].[URL]    Script Date: 07/10/2021 16:08:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[URL](
	[URLid] [int] IDENTITY(1,1) NOT NULL,
	[UrlOriginal] [varchar](400) NULL,
	[NewUrl] [varchar](30) NULL,
	[createDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[URLid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into[dbo].[URL]([UrlOriginal],[NewUrl],[createDate]) 
values 
('7','https://www.bbc.co.uk/sport/football/58827632',	'f6b05db1', getdate()),
('6','https://www.bbc.co.uk/',	'445fc7e3', getdate()),
('5','https://google.com',	'05046f26', getdate()),
('4','http://facebook.com',	'92718783', getdate());