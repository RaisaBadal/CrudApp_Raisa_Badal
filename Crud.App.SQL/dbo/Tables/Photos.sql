CREATE TABLE [dbo].[Photos] (
    [PhotoID]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Url]          NVARCHAR (MAX) NULL,
    [thumbnailUrl] NVARCHAR (MAX) NULL,
    [AlbumID]      INT            NOT NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([PhotoID] ASC),
    CONSTRAINT [FK_Photos_Albums_AlbumID] FOREIGN KEY ([AlbumID]) REFERENCES [dbo].[Albums] ([AlbumID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Photos_AlbumID]
    ON [dbo].[Photos]([AlbumID] ASC);

