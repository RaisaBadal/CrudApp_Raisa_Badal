CREATE TABLE [dbo].[Comments] (
    [CommentID] INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    [Body]      NVARCHAR (MAX) NOT NULL,
    [PostID]    INT            NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_Comments_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Posts] ([PostID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Comments_PostID]
    ON [dbo].[Comments]([PostID] ASC);

