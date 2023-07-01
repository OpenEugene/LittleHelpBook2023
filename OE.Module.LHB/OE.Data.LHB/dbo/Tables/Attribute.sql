CREATE TABLE [dbo].[Attribute] (
    [AttributeId]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [Description]       NVARCHAR (500)  NULL,
    [ParentAttributeId] INT             NULL,
    [l10N]              NVARCHAR (4000) NULL,
    [CreatedBy]         NVARCHAR (256)  NOT NULL,
    [CreatedOn]         DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]        NVARCHAR (256)  NOT NULL,
    [ModifiedOn]        DATETIME2 (7)   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([AttributeId] ASC)
);


  