CREATE TABLE [dbo].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NULL,
    [PasswordHash] NVARCHAR (256) NULL,
    [Email]        NVARCHAR (50)  NULL,
    [CreatedDate]  DATETIME       NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

