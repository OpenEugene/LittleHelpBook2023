CREATE TABLE [dbo].[Provider] (
    [ProviderId] INT  IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    [Description] NVARCHAR(2000) NULL,
    [WebAddress] NVARCHAR(128) NULL,
    [EmailAddress] NVARCHAR(64) NULL,
    [HoursOfOperation] NVARCHAR(2000) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
        
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED ([ProviderId] ASC)
);
