CREATE TABLE [dbo].[ProviderAddress] (
    [ProviderAddressId] INT            IDENTITY (1, 1) NOT NULL,
    [ProviderId]        INT            NOT NULL,
    [AddressId]         INT            NOT NULL,
    [IsActive]          BIT            DEFAULT ((1)) NOT NULL,
    [CreatedBy]         NVARCHAR (256) NOT NULL,
    [CreatedOn]         DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]        NVARCHAR (256) NOT NULL,
    [ModifiedOn]        DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProviderAddress] PRIMARY KEY CLUSTERED ([ProviderAddressId] ASC),
    CONSTRAINT [FK_ProviderAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([AddressId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProviderAddress_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Provider] ([ProviderId]) ON DELETE CASCADE
);

