CREATE TABLE [dbo].[Site] (
    [SiteId]               INT             IDENTITY (1, 1) NOT NULL,
    [TenantId]             INT             NOT NULL,
    [Name]                 NVARCHAR (200)  NOT NULL,
    [LogoFileId]           INT             NULL,
    [FaviconFileId]        INT             NULL,
    [DefaultThemeType]     NVARCHAR (200)  NOT NULL,
    [DefaultContainerType] NVARCHAR (200)  NOT NULL,
    [PwaIsEnabled]         BIT             NOT NULL,
    [PwaAppIconFileId]     INT             NULL,
    [PwaSplashIconFileId]  INT             NULL,
    [AllowRegistration]    BIT             NOT NULL,
    [CreatedBy]            NVARCHAR (256)  NOT NULL,
    [CreatedOn]            DATETIME2 (7)   NOT NULL,
    [ModifiedBy]           NVARCHAR (256)  NOT NULL,
    [ModifiedOn]           DATETIME2 (7)   NOT NULL,
    [DeletedBy]            NVARCHAR (256)  NULL,
    [DeletedOn]            DATETIME2 (7)   NULL,
    [IsDeleted]            BIT             NOT NULL,
    [AdminContainerType]   NVARCHAR (200)  NULL,
    [SiteGuid]             VARCHAR (36)    NULL,
    [Runtime]              NVARCHAR (50)   NULL,
    [RenderMode]           NVARCHAR (50)   NULL,
    [VisitorTracking]      BIT             NULL,
    [CaptureBrokenUrls]    BIT             NULL,
    [Version]              NVARCHAR (50)   NULL,
    [HomePageId]           INT             NULL,
    [HeadContent]          NVARCHAR (4000) NULL,
    [BodyContent]          NVARCHAR (4000) NULL,
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([SiteId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Site]
    ON [dbo].[Site]([TenantId] ASC, [Name] ASC) WHERE ([TenantId] IS NOT NULL AND [Name] IS NOT NULL);

