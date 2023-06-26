CREATE TABLE [dbo].[PageModule] (
    [PageModuleId]  INT            IDENTITY (1, 1) NOT NULL,
    [PageId]        INT            NOT NULL,
    [ModuleId]      INT            NOT NULL,
    [Title]         NVARCHAR (200) NOT NULL,
    [Pane]          NVARCHAR (50)  NOT NULL,
    [Order]         INT            NOT NULL,
    [ContainerType] NVARCHAR (200) NOT NULL,
    [CreatedBy]     NVARCHAR (256) NOT NULL,
    [CreatedOn]     DATETIME2 (7)  NOT NULL,
    [ModifiedBy]    NVARCHAR (256) NOT NULL,
    [ModifiedOn]    DATETIME2 (7)  NOT NULL,
    [DeletedBy]     NVARCHAR (256) NULL,
    [DeletedOn]     DATETIME2 (7)  NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_PageModule] PRIMARY KEY CLUSTERED ([PageModuleId] ASC),
    CONSTRAINT [FK_PageModule_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([ModuleId]),
    CONSTRAINT [FK_PageModule_Page] FOREIGN KEY ([PageId]) REFERENCES [dbo].[Page] ([PageId]) ON DELETE CASCADE
);

