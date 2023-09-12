CREATE TABLE [dbo].[Page] (
    [PageId]               INT             IDENTITY (1, 1) NOT NULL,
    [SiteId]               INT             NOT NULL,
    [Path]                 NVARCHAR (256)  NOT NULL,
    [Name]                 NVARCHAR (50)   NOT NULL,
    [Title]                NVARCHAR (200)  NULL,
    [ThemeType]            NVARCHAR (200)  NULL,
    [Icon]                 NVARCHAR (50)   NOT NULL,
    [ParentId]             INT             NULL,
    [Order]                INT             NOT NULL,
    [IsNavigation]         BIT             NOT NULL,
    [Url]                  NVARCHAR (500)  NULL,
    [UserId]               INT             NULL,
    [IsPersonalizable]     BIT             NOT NULL,
    [DefaultContainerType] NVARCHAR (200)  NULL,
    [CreatedBy]            NVARCHAR (256)  NOT NULL,
    [CreatedOn]            DATETIME2 (7)   NOT NULL,
    [ModifiedBy]           NVARCHAR (256)  NOT NULL,
    [ModifiedOn]           DATETIME2 (7)   NOT NULL,
    [DeletedBy]            NVARCHAR (256)  NULL,
    [DeletedOn]            DATETIME2 (7)   NULL,
    [IsDeleted]            BIT             NOT NULL,
    [IsClickable]          BIT             NULL,
    [HeadContent]          NVARCHAR (4000) NULL,
    [BodyContent]          NVARCHAR (4000) NULL,
    CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED ([PageId] ASC),
    CONSTRAINT [FK_Page_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Page]
    ON [dbo].[Page]([SiteId] ASC, [Path] ASC, [UserId] ASC) WHERE ([SiteId] IS NOT NULL AND [Path] IS NOT NULL AND [UserId] IS NOT NULL);

