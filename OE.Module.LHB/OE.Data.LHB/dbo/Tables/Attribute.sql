CREATE TABLE [lhb-dev-sqldb].dbo.[Attribute] (
	[AttributeId] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR (2000) NOT NULL,
	[Description] NVARCHAR (2000) NULL,
	[ParentAttributeId] INT NULL,
	
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([AttributeId] ASC)
   );
  