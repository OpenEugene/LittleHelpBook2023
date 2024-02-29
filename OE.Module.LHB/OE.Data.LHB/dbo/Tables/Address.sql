CREATE TABLE [dbo].[Address] (
    [AddressId]           INT            IDENTITY (1, 1) NOT NULL,
    [ProviderId]          INT            NULL,
    [Address1]            NVARCHAR (120) NULL,
    [Address2]            NVARCHAR (120) NULL,
    [Address3]            NVARCHAR (120) NULL,
    [City]                NVARCHAR (100) NULL,
    [State]               CHAR (2)       NULL,
    [PostalCode]          VARCHAR (16)   NULL,
    [HasWheelchairAccess] BIT            CONSTRAINT [DF_Address_HasWheelchairAccess] DEFAULT ((0)) NOT NULL,
    [HasLanguageSupport]  BIT            CONSTRAINT [DF_Address_HasLanguageSupport] DEFAULT ((0)) NOT NULL,
    [Geocoding]           VARCHAR (64)   NULL,
    [Longitude]           REAL           NULL,
    [Latitude]            REAL           NULL,
    [IsActive]            BIT            CONSTRAINT [DF__Address__IsActiv__2DE6D218] DEFAULT ((1)) NOT NULL,
    [CreatedBy]           NVARCHAR (256) NOT NULL,
    [CreatedOn]           DATETIME2 (7)  CONSTRAINT [DF__Address__Created__2CF2ADDF] DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]          NVARCHAR (256) NOT NULL,
    [ModifiedOn]          DATETIME2 (7)  CONSTRAINT [DF__Address__Modifie__2BFE89A6] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);







