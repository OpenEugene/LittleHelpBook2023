CREATE TABLE [dbo].[JobLog] (
    [JobLogId]   INT            IDENTITY (1, 1) NOT NULL,
    [JobId]      INT            NOT NULL,
    [StartDate]  DATETIME2 (7)  NOT NULL,
    [FinishDate] DATETIME2 (7)  NULL,
    [Succeeded]  BIT            NULL,
    [Notes]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_JobLog] PRIMARY KEY CLUSTERED ([JobLogId] ASC),
    CONSTRAINT [FK_JobLog_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job] ([JobId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_JobLog_JobId]
    ON [dbo].[JobLog]([JobId] ASC);

