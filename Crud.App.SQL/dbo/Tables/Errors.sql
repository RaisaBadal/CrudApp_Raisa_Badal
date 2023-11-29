CREATE TABLE [dbo].[Errors] (
    [ErrorID]       INT            IDENTITY (1, 1) NOT NULL,
    [Text]          NVARCHAR (MAX) NOT NULL,
    [ErrorType]     INT            NOT NULL,
    [TimeofOccured] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED ([ErrorID] ASC)
);

