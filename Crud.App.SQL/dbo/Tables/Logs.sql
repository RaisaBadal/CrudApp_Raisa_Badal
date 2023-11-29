CREATE TABLE [dbo].[Logs] (
    [LogID]   INT            IDENTITY (1, 1) NOT NULL,
    [LogText] NVARCHAR (MAX) NOT NULL,
    [LogDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

