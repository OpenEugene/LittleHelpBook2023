CREATE TABLE [dbo].[ModuleDefinition] (
    [ModuleDefinitionId]   INT             IDENTITY (1, 1) NOT NULL,
    [ModuleDefinitionName] NVARCHAR (200)  NOT NULL,
    [Name]                 NVARCHAR (200)  NULL,
    [Description]          NVARCHAR (2000) NULL,
    [Categories]           NVARCHAR (200)  NULL,
    [Version]              NVARCHAR (50)   NULL,
    [CreatedBy]            NVARCHAR (256)  NOT NULL,
    [CreatedOn]            DATETIME2 (7)   NOT NULL,
    [ModifiedBy]           NVARCHAR (256)  NOT NULL,
    [ModifiedOn]           DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_ModuleDefinition] PRIMARY KEY CLUSTERED ([ModuleDefinitionId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ModuleDefinition]
    ON [dbo].[ModuleDefinition]([ModuleDefinitionName] ASC);

