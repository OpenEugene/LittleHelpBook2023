CREATE TABLE [dbo].[Visitor] (
    [VisitorId] INT             IDENTITY (1, 1) NOT NULL,
    [SiteId]    INT             NOT NULL,
    [UserId]    INT             NULL,
    [Visits]    INT             NOT NULL,
    [IPAddress] NVARCHAR (50)   NOT NULL,
    [UserAgent] NVARCHAR (256)  NOT NULL,
    [Language]  NVARCHAR (50)   NOT NULL,
    [CreatedOn] DATETIME2 (7)   NOT NULL,
    [VisitedOn] DATETIME2 (7)   NOT NULL,
    [Referrer]  NVARCHAR (500)  NULL,
    [Url]       NVARCHAR (2048) NOT NULL,
    CONSTRAINT [PK_Visitor] PRIMARY KEY CLUSTERED ([VisitorId] ASC),
    CONSTRAINT [FK_Visitor_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);

