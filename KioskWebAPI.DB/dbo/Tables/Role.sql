CREATE TABLE [dbo].[Role] (
    [RoleID]      INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]    NVARCHAR (50) NULL,
    [IsActive]    BIT           NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_Role_CreatedDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

