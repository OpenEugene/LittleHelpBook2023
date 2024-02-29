CREATE TABLE [dbo].[ProviderAttribute] (
    [ProviderAttributeId] INT            IDENTITY (1, 1) NOT NULL,
    [ProviderId]          INT            NOT NULL,
    [AttributeId]         INT            NOT NULL,
    [CreatedBy]           NVARCHAR (256) NOT NULL,
    [CreatedOn]           DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]          NVARCHAR (256) NOT NULL,
    [ModifiedOn]          DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProviderAttribute] PRIMARY KEY CLUSTERED ([ProviderAttributeId] ASC),
    CONSTRAINT [FK_ProviderAttribute_Attribute] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attribute] ([AttributeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProviderAttribute_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Provider] ([ProviderId]) ON DELETE CASCADE
);



