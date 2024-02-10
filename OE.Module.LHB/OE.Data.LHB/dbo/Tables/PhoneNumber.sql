CREATE TABLE [dbo].[PhoneNumber] (
    [PhoneNumberId] INT             IDENTITY (1, 1) NOT NULL,
    [ProviderId]    INT             NULL,
    [CountryCode]   INT             NULL,
    [AreaCode]      INT             NULL,
    [Number]        NVARCHAR (500)  NULL,
    [Extension]     INT             NULL,
    [Description]   NVARCHAR (500)  NULL,
    [l10N]          NVARCHAR (4000) NULL,
    [CreatedBy]     NVARCHAR (256)  NOT NULL,
    [CreatedOn]     DATETIME2 (7)   CONSTRAINT [DF__PhoneNumb__Creat__1F98B2C1] DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (256)  NOT NULL,
    [ModifiedOn]    DATETIME2 (7)   CONSTRAINT [DF__PhoneNumb__Modif__208CD6FA] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED ([PhoneNumberId] ASC)
);





