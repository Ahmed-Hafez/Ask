USE [QuesAns_DB]
GO

/****** Object:  Table [dbo].[QuestionsTable]    Script Date: 5/30/2019 7:10:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE QuestionsTable(
	[Question_Number] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](3000) NOT NULL,
	[Answer] [varchar](3000) NOT NULL,
	[Kind] [varchar](100) NOT NULL,
	[Levels] [int] NOT NULL,
 CONSTRAINT [PK_QuestionsTable] PRIMARY KEY CLUSTERED 
(
	[Question_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

