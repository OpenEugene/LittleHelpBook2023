CREATE TABLE [dbo].[ProviderPhoneNumber] (
	[ProviderPhoneNumberId] INT IDENTITY (1, 1) NOT NULL,
	[ProviderId] INT NOT NULL,
	[PhoneNumberId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
       
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ProviderPhoneNumber] PRIMARY KEY CLUSTERED ([ProviderPhoneNumberId] ASC),
    CONSTRAINT FK_ProviderPhoneNumber_Provider FOREIGN KEY (ProviderId) REFERENCES [dbo].[Provider] (ProviderId) ON DELETE CASCADE,
    CONSTRAINT FK_ProviderPhoneNumber_PhoneNumber FOREIGN KEY (ProviderId) REFERENCES [dbo].[Provider] (ProviderId) ON DELETE CASCADE
);

