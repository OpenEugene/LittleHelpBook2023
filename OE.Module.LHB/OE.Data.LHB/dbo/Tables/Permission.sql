CREATE TABLE [dbo].[Permission] (
    [PermissionId]   INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]         INT            NOT NULL,
    [EntityName]     NVARCHAR (50)  NOT NULL,
    [EntityId]       INT            NOT NULL,
    [PermissionName] NVARCHAR (50)  NOT NULL,
    [RoleId]         INT            NULL,
    [UserId]         INT            NULL,
    [IsAuthorized]   BIT            NOT NULL,
    [CreatedBy]      NVARCHAR (256) NOT NULL,
    [CreatedOn]      DATETIME2 (7)  NOT NULL,
    [ModifiedBy]     NVARCHAR (256) NOT NULL,
    [ModifiedOn]     DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([PermissionId] ASC),
    CONSTRAINT [FK_Permission_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_Permission_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permission_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Permission]
    ON [dbo].[Permission]([SiteId] ASC, [EntityName] ASC, [EntityId] ASC, [PermissionName] ASC, [RoleId] ASC, [UserId] ASC) WHERE ([SiteId] IS NOT NULL AND [EntityName] IS NOT NULL AND [EntityId] IS NOT NULL AND [PermissionName] IS NOT NULL AND [RoleId] IS NOT NULL AND [UserId] IS NOT NULL);

