CREATE TABLE [scrn].[CategoryScreen] (
    [RecordID]      INT            IDENTITY (1, 1) NOT NULL,
    [ScrnHeading]   VARCHAR (50)   NULL,
    [ScrnBannerImg] VARBINARY (50) NULL,
    [ScrnParagraph] VARCHAR (1500) NULL,
    [IsActive]      BIT            NULL,
    [CreatedDate]   DATETIME       NULL,
    [CreatedBy]     INT            NULL,
    [ModifiedDate]  DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    CONSTRAINT [PK_CategoryScreen] PRIMARY KEY CLUSTERED ([RecordID] ASC)
);

