CREATE TABLE [dbo].[PhoneNumber] (
    [PhoneNumberId] INT             IDENTITY (1, 1) NOT NULL,
    [PhoneNumber]   VARCHAR (200)   NULL,
    [Description]   NVARCHAR (500)  NULL,
    [l10N]          NVARCHAR (4000) NULL,
    [CreatedBy]     NVARCHAR (256)  NOT NULL,
    [CreatedOn]     DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (256)  NOT NULL,
    [ModifiedOn]    DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED ([PhoneNumberId] ASC)
);

