CREATE TABLE [dbo].[Tenant] (
    [TenantId]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (100)  NOT NULL,
    [DBConnectionString] NVARCHAR (1024) NOT NULL,
    [Version]            NVARCHAR (50)   NULL,
    [CreatedBy]          NVARCHAR (256)  NOT NULL,
    [CreatedOn]          DATETIME2 (7)   NOT NULL,
    [ModifiedBy]         NVARCHAR (256)  NOT NULL,
    [ModifiedOn]         DATETIME2 (7)   NOT NULL,
    [DBType]             NVARCHAR (200)  NULL,
    CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED ([TenantId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Tenant]
    ON [dbo].[Tenant]([Name] ASC);

