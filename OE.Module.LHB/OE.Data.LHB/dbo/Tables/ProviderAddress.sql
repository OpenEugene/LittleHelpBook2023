CREATE TABLE [dbo].[ProviderAddress] (
	[ProviderAddressId] INT IDENTITY (1, 1) NOT NULL,
	[ProviderId] INT NOT NULL,
	[AddressId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ProviderAddress] PRIMARY KEY CLUSTERED ([ProviderAddressId] ASC),
    CONSTRAINT FK_ProviderAddress_Provider FOREIGN KEY (ProviderId) REFERENCES dbo.[Provider](ProviderId),
    CONSTRAINT FK_ProviderAddress_Address FOREIGN KEY (AddressId) REFERENCES dbo.[Address](AddressId)
);