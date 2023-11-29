CREATE TABLE [dbo].[Companys] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [catchPhrase] NVARCHAR (MAX) NOT NULL,
    [bs]          NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Companys] PRIMARY KEY CLUSTERED ([ID] ASC)
);

