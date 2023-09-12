CREATE TABLE [dbo].[Notification] (
    [NotificationId]  INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]          INT            NOT NULL,
    [FromUserId]      INT            NULL,
    [ToUserId]        INT            NULL,
    [ToEmail]         NVARCHAR (256) NOT NULL,
    [ParentId]        INT            NULL,
    [Subject]         NVARCHAR (256) NOT NULL,
    [Body]            NVARCHAR (MAX) NOT NULL,
    [CreatedOn]       DATETIME2 (7)  NOT NULL,
    [IsDelivered]     BIT            NOT NULL,
    [DeliveredOn]     DATETIME2 (7)  NULL,
    [DeletedBy]       NVARCHAR (256) NULL,
    [DeletedOn]       DATETIME2 (7)  NULL,
    [IsDeleted]       BIT            NOT NULL,
    [FromDisplayName] NVARCHAR (50)  NULL,
    [FromEmail]       NVARCHAR (256) NULL,
    [ToDisplayName]   NVARCHAR (50)  NULL,
    [SendOn]          DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationId] ASC),
    CONSTRAINT [FK_Notification_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([SiteId]) ON DELETE CASCADE
);

