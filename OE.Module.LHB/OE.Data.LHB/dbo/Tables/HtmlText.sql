CREATE TABLE [dbo].[HtmlText] (
    [HtmlTextId] INT            IDENTITY (1, 1) NOT NULL,
    [ModuleId]   INT            NOT NULL,
    [Content]    NVARCHAR (MAX) NOT NULL,
    [CreatedBy]  NVARCHAR (256) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy] NVARCHAR (256) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_HtmlText] PRIMARY KEY CLUSTERED ([HtmlTextId] ASC),
    CONSTRAINT [FK_HtmlText_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([ModuleId]) ON DELETE CASCADE
);

