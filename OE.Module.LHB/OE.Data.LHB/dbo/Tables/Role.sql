CREATE TABLE [dbo].[Role] (
    [RoleId]         INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]         INT            NULL,
    [Name]           NVARCHAR (256) NOT NULL,
    [Description]    NVARCHAR (256) NOT NULL,
    [IsAutoAssigned] BIT            NOT NULL,
    [IsSystem]       BIT            NOT NULL,
    [CreatedBy]      NVARCHAR (256) NOT NULL,
    [CreatedOn]      DATETIME2 (7)  NOT NULL,
    [ModifiedBy]     NVARCHAR (256) NOT NULL,
    [ModifiedOn]     DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC),
    CONSTRAINT [FK_Role_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Role]
    ON [dbo].[Role]([SiteId] ASC, [Name] ASC) WHERE ([SiteId] IS NOT NULL AND [Name] IS NOT NULL);

