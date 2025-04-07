CREATE TABLE [dbo].[FAQ] (
    [FAQID]        INT            IDENTITY (1, 1) NOT NULL,
    [ProductID]    INT            NOT NULL,
    [FAQ]          NVARCHAR (250) NOT NULL,
    [FAQSubPoint]  NVARCHAR (550) NULL,
    [IsActive]     BIT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [CreatedBy]    INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED ([FAQID] ASC),
    CONSTRAINT [FK_FAQ_ProductName] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[ProductName] ([ProductNameID])
);

