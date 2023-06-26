CREATE TABLE [dbo].[Log] (
    [LogId]           INT             IDENTITY (1, 1) NOT NULL,
    [SiteId]          INT             NULL,
    [LogDate]         DATETIME2 (7)   NOT NULL,
    [PageId]          INT             NULL,
    [ModuleId]        INT             NULL,
    [UserId]          INT             NULL,
    [Url]             NVARCHAR (2048) NOT NULL,
    [Server]          NVARCHAR (200)  NOT NULL,
    [Category]        NVARCHAR (200)  NOT NULL,
    [Feature]         NVARCHAR (200)  NOT NULL,
    [Function]        NVARCHAR (20)   NOT NULL,
    [Level]           NVARCHAR (20)   NOT NULL,
    [Message]         NVARCHAR (MAX)  NOT NULL,
    [MessageTemplate] NVARCHAR (MAX)  NOT NULL,
    [Exception]       NVARCHAR (MAX)  NULL,
    [Properties]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId] ASC),
    CONSTRAINT [FK_Log_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);

