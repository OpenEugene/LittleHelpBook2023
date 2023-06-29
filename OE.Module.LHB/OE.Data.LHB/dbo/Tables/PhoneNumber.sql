CREATE TABLE [dbo].[PhoneNumber] (
    [PhoneNumberId] INT IDENTITY (1, 1) NOT NULL,
    [CountryCode] INT NULL,
	[AreaCode] INT NULL,
	[Number] INT NULL,
	[Extension] INT NULL,
	[Description]  NVARCHAR (1000) NULL,
	       
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED ([PhoneNumberId] ASC)
   );