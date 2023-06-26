CREATE TABLE [dbo].[Module] (
    [ModuleId]             INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]               INT            NOT NULL,
    [ModuleDefinitionName] NVARCHAR (200) NOT NULL,
    [AllPages]             BIT            NOT NULL,
    [CreatedBy]            NVARCHAR (256) NOT NULL,
    [CreatedOn]            DATETIME2 (7)  NOT NULL,
    [ModifiedBy]           NVARCHAR (256) NOT NULL,
    [ModifiedOn]           DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([ModuleId] ASC),
    CONSTRAINT [FK_Module_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);

