CREATE TABLE dbo.[ProviderAttribute] (
	[ProviderAttributeId] INT IDENTITY (1, 1) NOT NULL,
	[ProviderId] INT NOT NULL,
	[AddressId] INT NOT NULL,
	
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    
    CONSTRAINT [PK_ProviderAttribute] PRIMARY KEY CLUSTERED ([ProviderAttributeId] ASC),
    CONSTRAINT FK_ProviderAttribute_Provider FOREIGN KEY (ProviderId) REFERENCES dbo.[Provider](ProviderId),
    CONSTRAINT FK_ProviderAttribute_Attribut FOREIGN KEY (AddressId) REFERENCES  dbo.[Attribute](AttributeId)

   );