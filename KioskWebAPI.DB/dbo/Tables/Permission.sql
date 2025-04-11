CREATE TABLE [dbo].[Permission] (
    [PermissionID]   INT           IDENTITY (1, 1) NOT NULL,
    [PermissionName] NVARCHAR (50) NULL,
    [PermissionCode] NVARCHAR (50) NULL,
    [ScreenID]       INT           NOT NULL,
    [RoleID]         INT           NOT NULL,
    [CanAdd]         BIT           CONSTRAINT [DF_Permission_CanAdd] DEFAULT ((0)) NULL,
    [CanEdit]        BIT           CONSTRAINT [DF_Permission_CanEdit] DEFAULT ((0)) NULL,
    [CanDelete]      BIT           CONSTRAINT [DF_Permission_CanDelete] DEFAULT ((0)) NULL,
    [CanView]        BIT           CONSTRAINT [DF_Permission_CanView] DEFAULT ((1)) NULL,
    [IsActive]       BIT           NULL,
    [CreatedDate]    DATETIME      CONSTRAINT [DF_Permission_CreatedDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([PermissionID] ASC),
    CONSTRAINT [FK_Permission_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID]),
    CONSTRAINT [FK_Permission_Screen] FOREIGN KEY ([ScreenID]) REFERENCES [dbo].[Screen] ([ScreenID])
);

