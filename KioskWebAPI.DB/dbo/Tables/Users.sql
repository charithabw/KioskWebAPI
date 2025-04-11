CREATE TABLE [dbo].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NULL,
    [PasswordHash] NVARCHAR (256) NULL,
    [Email]        NVARCHAR (50)  NULL,
    [IsLock]       BIT            NULL,
    [LockCount]    INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [RoleID]       INT            NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Users_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);



