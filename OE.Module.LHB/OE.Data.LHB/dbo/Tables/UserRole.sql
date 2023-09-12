CREATE TABLE [dbo].[UserRole] (
    [UserRoleId]    INT            IDENTITY (1, 1) NOT NULL,
    [UserId]        INT            NOT NULL,
    [RoleId]        INT            NOT NULL,
    [EffectiveDate] DATETIME2 (7)  NULL,
    [ExpiryDate]    DATETIME2 (7)  NULL,
    [CreatedBy]     NVARCHAR (256) NOT NULL,
    [CreatedOn]     DATETIME2 (7)  NOT NULL,
    [ModifiedBy]    NVARCHAR (256) NOT NULL,
    [ModifiedOn]    DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRole]
    ON [dbo].[UserRole]([RoleId] ASC, [UserId] ASC) WHERE ([RoleId] IS NOT NULL AND [UserId] IS NOT NULL);

