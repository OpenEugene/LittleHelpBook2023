CREATE TABLE [dbo].[Setting] (
    [SettingId]    INT            IDENTITY (1, 1) NOT NULL,
    [EntityName]   NVARCHAR (50)  NOT NULL,
    [EntityId]     INT            NOT NULL,
    [SettingName]  NVARCHAR (200) NOT NULL,
    [SettingValue] NVARCHAR (MAX) NOT NULL,
    [CreatedBy]    NVARCHAR (256) NOT NULL,
    [CreatedOn]    DATETIME2 (7)  NOT NULL,
    [ModifiedBy]   NVARCHAR (256) NOT NULL,
    [ModifiedOn]   DATETIME2 (7)  NOT NULL,
    [IsPrivate]    BIT            NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([SettingId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Setting]
    ON [dbo].[Setting]([EntityName] ASC, [EntityId] ASC, [SettingName] ASC) WHERE ([EntityName] IS NOT NULL AND [EntityId] IS NOT NULL AND [SettingName] IS NOT NULL);

