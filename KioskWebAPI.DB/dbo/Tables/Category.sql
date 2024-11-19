CREATE TABLE [dbo].[Category] (
    [CategoryID]   INT            IDENTITY (1, 1) NOT NULL,
    [CatEng]       NVARCHAR (255) COLLATE Latin1_General_BIN NULL,
    [CatSin]       NVARCHAR (255) COLLATE Latin1_General_100_BIN2_UTF8 NULL,
    [CatTam]       NVARCHAR (255) NULL,
    [IsActive]     BIT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [CreatedBy]    INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

