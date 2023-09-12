CREATE TABLE [dbo].[Theme] (
    [ThemeId]    INT            IDENTITY (1, 1) NOT NULL,
    [ThemeName]  NVARCHAR (200) NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NOT NULL,
    [Name]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED ([ThemeId] ASC)
);

