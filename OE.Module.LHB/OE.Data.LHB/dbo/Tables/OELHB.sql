CREATE TABLE [dbo].[OELHB] (
    [LHBId]      INT            IDENTITY (1, 1) NOT NULL,
    [ModuleId]   INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_OELHB] PRIMARY KEY CLUSTERED ([LHBId] ASC),
    CONSTRAINT [FK_OELHB_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([ModuleId]) ON DELETE CASCADE
);

