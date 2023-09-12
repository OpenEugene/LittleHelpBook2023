CREATE TABLE [dbo].[Address] (
    [AddressId]  INT            IDENTITY (1, 1) NOT NULL,
    [Address1]   NVARCHAR (120) NULL,
    [Address2]   NVARCHAR (120) NULL,
    [Address3]   NVARCHAR (120) NULL,
    [City]       NVARCHAR (100) NULL,
    [State]      CHAR (2)       NULL,
    [PostalCode] VARCHAR (16)   NULL,
    [Geocoding]  VARCHAR (64)   NULL,
    [Longitude]  REAL           NULL,
    [Latitude]   REAL           NULL,
    [IsActive]   BIT            DEFAULT ((1)) NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);



