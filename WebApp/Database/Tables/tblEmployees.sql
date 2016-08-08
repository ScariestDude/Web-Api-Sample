SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblEmployees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Sex] [tinyint] NULL,
	[Birthday] [datetime] NULL,
	[Position] [varchar](max) NULL,
	[Location] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[PhoneNumber] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


