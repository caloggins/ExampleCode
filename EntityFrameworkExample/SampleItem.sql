USE [ChangeThisToWhateverDatabaseYouWantToUse]
GO

/****** Object:  Table [dbo].[SampleItem]    Script Date: 8/15/2016 2:34:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SampleItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Data] [varchar](50) NOT NULL,
	[RowVersion] [timestamp] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

