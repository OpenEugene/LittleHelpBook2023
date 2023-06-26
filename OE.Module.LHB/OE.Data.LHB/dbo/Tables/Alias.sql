CREATE TABLE [dbo].[Alias] (
    [AliasId]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (200) NOT NULL,
    [TenantId]   INT            NOT NULL,
    [SiteId]     INT            NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NOT NULL,
    [IsDefault]  BIT            NULL,
    CONSTRAINT [PK_Alias] PRIMARY KEY CLUSTERED ([AliasId] ASC),
    CONSTRAINT [FK_Alias_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Alias_TenantId]
    ON [dbo].[Alias]([TenantId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Alias]
    ON [dbo].[Alias]([Name] ASC);

