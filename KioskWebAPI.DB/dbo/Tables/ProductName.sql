CREATE TABLE [dbo].[ProductName] (
    [ProductNameID] INT            IDENTITY (1, 1) NOT NULL,
    [CategoryID]    INT            NOT NULL,
    [ProdEng]       NVARCHAR (250) NULL,
    [ProdSin]       NVARCHAR (250) NULL,
    [ProdTam]       NVARCHAR (250) NULL,
    [IsActive]      BIT            NULL,
    [CreatedDate]   DATETIME       NULL,
    [CreatedBy]     INT            NULL,
    [ModifiedDate]  DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    CONSTRAINT [PK_ProductName] PRIMARY KEY CLUSTERED ([ProductNameID] ASC),
    CONSTRAINT [FK_ProductName_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);

