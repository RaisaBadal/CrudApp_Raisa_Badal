CREATE TABLE [dbo].[Posts] (
    [PostID] INT            IDENTITY (1, 1) NOT NULL,
    [Title]  NVARCHAR (MAX) NOT NULL,
    [Body]   NVARCHAR (MAX) NOT NULL,
    [UserID] INT            NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([PostID] ASC),
    CONSTRAINT [FK_Posts_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Posts_UserID]
    ON [dbo].[Posts]([UserID] ASC);

