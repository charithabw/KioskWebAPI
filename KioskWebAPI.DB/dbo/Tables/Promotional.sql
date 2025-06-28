CREATE TABLE [dbo].[Promotional] (
    [PromotionalID]   INT            IDENTITY (1, 1) NOT NULL,
    [PromotionalName] NVARCHAR (50)  NULL,
    [PromotionalDesc] NVARCHAR (255) NULL,
    [IsActive]        BIT            NULL,
    [ImagePath]       NVARCHAR (50)  NULL,
    [Status]          NVARCHAR (50)  CONSTRAINT [DF_Promotional_Status] DEFAULT ('pending') NULL,
    [CreatedBy]       INT            NULL,
    [CreatedDate]     DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    [ModifiedDate]    DATETIME       NULL,
    CONSTRAINT [PK_Promotional] PRIMARY KEY CLUSTERED ([PromotionalID] ASC)
);

