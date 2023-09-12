CREATE TABLE [dbo].[UrlMapping] (
    [UrlMappingId] INT             IDENTITY (1, 1) NOT NULL,
    [SiteId]       INT             NOT NULL,
    [Url]          NVARCHAR (750)  NOT NULL,
    [MappedUrl]    NVARCHAR (2048) NOT NULL,
    [Requests]     INT             NOT NULL,
    [CreatedOn]    DATETIME2 (7)   NOT NULL,
    [RequestedOn]  DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_UrlMapping] PRIMARY KEY CLUSTERED ([UrlMappingId] ASC),
    CONSTRAINT [FK_UrlMapping_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UrlMapping]
    ON [dbo].[UrlMapping]([SiteId] ASC, [Url] ASC) WHERE ([SiteId] IS NOT NULL AND [Url] IS NOT NULL);

