CREATE TABLE [dbo].[Profile] (
    [ProfileId]    INT             IDENTITY (1, 1) NOT NULL,
    [SiteId]       INT             NULL,
    [Name]         NVARCHAR (50)   NOT NULL,
    [Title]        NVARCHAR (50)   NOT NULL,
    [Description]  NVARCHAR (256)  NULL,
    [Category]     NVARCHAR (50)   NOT NULL,
    [ViewOrder]    INT             NOT NULL,
    [MaxLength]    INT             NOT NULL,
    [DefaultValue] NVARCHAR (2000) NULL,
    [IsRequired]   BIT             NOT NULL,
    [IsPrivate]    BIT             NOT NULL,
    [CreatedBy]    NVARCHAR (256)  NOT NULL,
    [CreatedOn]    DATETIME2 (7)   NOT NULL,
    [ModifiedBy]   NVARCHAR (256)  NOT NULL,
    [ModifiedOn]   DATETIME2 (7)   NOT NULL,
    [Options]      NVARCHAR (2000) NULL,
    [Validation]   NVARCHAR (200)  NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED ([ProfileId] ASC),
    CONSTRAINT [FK_Profile_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Profile]
    ON [dbo].[Profile]([SiteId] ASC, [Name] ASC) WHERE ([SiteId] IS NOT NULL AND [Name] IS NOT NULL);

