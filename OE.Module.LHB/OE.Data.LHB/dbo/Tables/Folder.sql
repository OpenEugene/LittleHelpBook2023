CREATE TABLE [dbo].[Folder] (
    [FolderId]   INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]     INT            NOT NULL,
    [ParentId]   INT            NULL,
    [Name]       NVARCHAR (256) NOT NULL,
    [Path]       NVARCHAR (512) NOT NULL,
    [Order]      INT            NOT NULL,
    [IsSystem]   BIT            NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NOT NULL,
    [Type]       NVARCHAR (50)  NULL,
    [Capacity]   INT            NULL,
    [ImageSizes] NVARCHAR (512) NULL,
    [IsDeleted]  BIT            NULL,
    CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED ([FolderId] ASC),
    CONSTRAINT [FK_Folder_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Folder]
    ON [dbo].[Folder]([SiteId] ASC, [Path] ASC) WHERE ([SiteId] IS NOT NULL AND [Path] IS NOT NULL);

