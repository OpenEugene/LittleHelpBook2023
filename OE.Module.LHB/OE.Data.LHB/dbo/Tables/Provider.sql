CREATE TABLE [dbo].[Provider] (
    [ProviderId]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (200)  NOT NULL,
    [Description]      NVARCHAR (2000) NULL,
    [WebAddress]       NVARCHAR (500)  NULL,
    [EmailAddress]     NVARCHAR (100)  NULL,
    [HoursOfOperation] NVARCHAR (500)  NULL,
    [IsActive]         BIT             DEFAULT ((1)) NOT NULL,
    [l10N]             NVARCHAR (MAX)  NULL,
    [CreatedBy]        NVARCHAR (256)  NOT NULL,
    [CreatedOn]        DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]       NVARCHAR (256)  NOT NULL,
    [ModifiedOn]       DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED ([ProviderId] ASC)
);


