CREATE TABLE [dbo].[Address] (
    [AddressId] INT IDENTITY (1, 1) NOT NULL,
    [Address1]    NVARCHAR(120) NULL,
	[Address2]    NVARCHAR(120) NULL,
	[Address3]    NVARCHAR(120) NULL,
	[City]        NVARCHAR(100) NULL,
	[State]       CHAR(2) NULL,
	[PostalCode]  VARCHAR(16) NULL,
	[Geocoding] VARCHAR(64) NULL,
	[Longitude] real NULL,
	[Latitude] real NULL,
	[Mapcache] VARCHAR(512) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
       
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
   );