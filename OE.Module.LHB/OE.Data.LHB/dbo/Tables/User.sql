CREATE TABLE [dbo].[User] (
    [UserId]            INT            IDENTITY (1, 1) NOT NULL,
    [Username]          NVARCHAR (256) NOT NULL,
    [DisplayName]       NVARCHAR (50)  NOT NULL,
    [Email]             NVARCHAR (256) NOT NULL,
    [PhotoFileId]       INT            NULL,
    [LastLoginOn]       DATETIME2 (7)  NULL,
    [LastIpAddress]     NVARCHAR (50)  NOT NULL,
    [CreatedBy]         NVARCHAR (256) NOT NULL,
    [CreatedOn]         DATETIME2 (7)  NOT NULL,
    [ModifiedBy]        NVARCHAR (256) NOT NULL,
    [ModifiedOn]        DATETIME2 (7)  NOT NULL,
    [DeletedBy]         NVARCHAR (256) NULL,
    [DeletedOn]         DATETIME2 (7)  NULL,
    [IsDeleted]         BIT            NOT NULL,
    [TwoFactorRequired] BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [TwoFactorCode]     NVARCHAR (6)   NULL,
    [TwoFactorExpiry]   DATETIME2 (7)  NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User]
    ON [dbo].[User]([Username] ASC) WHERE ([Username] IS NOT NULL);

