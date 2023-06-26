CREATE TABLE [dbo].[File] (
    [FileId]      INT            IDENTITY (1, 1) NOT NULL,
    [FolderId]    INT            NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Extension]   NVARCHAR (50)  NOT NULL,
    [Size]        INT            NOT NULL,
    [ImageHeight] INT            NOT NULL,
    [ImageWidth]  INT            NOT NULL,
    [CreatedBy]   NVARCHAR (256) NOT NULL,
    [CreatedOn]   DATETIME2 (7)  NOT NULL,
    [ModifiedBy]  NVARCHAR (256) NOT NULL,
    [ModifiedOn]  DATETIME2 (7)  NOT NULL,
    [Description] NVARCHAR (512) NULL,
    [IsDeleted]   BIT            NULL,
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([FileId] ASC),
    CONSTRAINT [FK_File_Folder] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folder] ([FolderId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_File]
    ON [dbo].[File]([FolderId] ASC, [Name] ASC) WHERE ([FolderId] IS NOT NULL AND [Name] IS NOT NULL);

