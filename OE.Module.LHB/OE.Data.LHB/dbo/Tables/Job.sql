CREATE TABLE [dbo].[Job] (
    [JobId]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (200) NOT NULL,
    [JobType]          NVARCHAR (200) NOT NULL,
    [Frequency]        NVARCHAR (1)   NOT NULL,
    [Interval]         INT            NOT NULL,
    [StartDate]        DATETIME2 (7)  NULL,
    [EndDate]          DATETIME2 (7)  NULL,
    [IsEnabled]        BIT            NOT NULL,
    [IsStarted]        BIT            NOT NULL,
    [IsExecuting]      BIT            NOT NULL,
    [NextExecution]    DATETIME2 (7)  NULL,
    [RetentionHistory] INT            NOT NULL,
    [CreatedBy]        NVARCHAR (256) NOT NULL,
    [CreatedOn]        DATETIME2 (7)  NOT NULL,
    [ModifiedBy]       NVARCHAR (256) NOT NULL,
    [ModifiedOn]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([JobId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Job]
    ON [dbo].[Job]([JobType] ASC);

