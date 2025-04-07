CREATE TABLE [dbo].[ProductDetail] (
    [ProductDetailID] INT            IDENTITY (1, 1) NOT NULL,
    [ProductNameID]   INT            NOT NULL,
    [TitleEng]        NVARCHAR (250) NULL,
    [TitleSin]        NVARCHAR (250) NULL,
    [TitleTam]        NVARCHAR (250) NULL,
    [DesEng]          NVARCHAR (550) NULL,
    [DesSin]          NVARCHAR (550) NULL,
    [DesTam]          NVARCHAR (550) NULL,
    [SubTitleEng]     NVARCHAR (250) NULL,
    [SubTitleSin]     NVARCHAR (250) NULL,
    [SubTitleTam]     NVARCHAR (250) NULL,
    [PointListEng]    NVARCHAR (550) NULL,
    [PointListSin]    NVARCHAR (550) NULL,
    [PointListTam]    NVARCHAR (550) NULL,
    [IsActive]        BIT            NOT NULL,
    [CreatedDate]     DATETIME       CONSTRAINT [DF_ProductDetail_CreatedDate] DEFAULT (getdate()) NULL,
    [CreatedBy]       INT            NULL,
    [ModifiedDate]    DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED ([ProductDetailID] ASC),
    CONSTRAINT [FK_ProductDetail_ProductName] FOREIGN KEY ([ProductNameID]) REFERENCES [dbo].[ProductName] ([ProductNameID])
);



