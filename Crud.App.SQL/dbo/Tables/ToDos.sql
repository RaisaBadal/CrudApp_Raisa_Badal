CREATE TABLE [dbo].[ToDos] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NOT NULL,
    [Completed] BIT            NOT NULL,
    [UserId]    INT            NOT NULL,
    CONSTRAINT [PK_ToDos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ToDos_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ToDos_UserId]
    ON [dbo].[ToDos]([UserId] ASC);

