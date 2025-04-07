CREATE TABLE [dbo].[ProductImage] (
    [ProductImageID]  INT            IDENTITY (1, 1) NOT NULL,
    [ProductNameID]   INT            NOT NULL,
    [Logo]            NVARCHAR (MAX) NULL,
    [QRAndroid]       NVARCHAR (MAX) NULL,
    [QRApple]         NVARCHAR (MAX) NULL,
    [QRHuawei]        NVARCHAR (MAX) NULL,
    [BackgroundImage] NVARCHAR (MAX) NULL,
    [IsActive]        BIT            NOT NULL,
    [CreatedDate]     DATETIME       CONSTRAINT [DF_ProductImage_CreatedDate] DEFAULT (getdate()) NULL,
    [CreatedBy]       INT            NULL,
    [ModifiedDate]    DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED ([ProductImageID] ASC),
    CONSTRAINT [FK_ProductImage_ProductName] FOREIGN KEY ([ProductImageID]) REFERENCES [dbo].[ProductName] ([ProductNameID])
);

