CREATE TABLE [dbo].[Screen] (
    [ScreenID]    INT           IDENTITY (1, 1) NOT NULL,
    [ScreenCode]  NVARCHAR (50) NOT NULL,
    [ScreenName]  NVARCHAR (50) NULL,
    [IsActive]    BIT           NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_Screen_CreatedDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED ([ScreenID] ASC)
);

