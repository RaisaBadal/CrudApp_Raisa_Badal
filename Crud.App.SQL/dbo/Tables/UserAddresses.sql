CREATE TABLE [dbo].[UserAddresses] (
    [UserAddressID] INT            IDENTITY (1, 1) NOT NULL,
    [City]          NVARCHAR (MAX) NULL,
    [Street]        NVARCHAR (MAX) NULL,
    [ZipCode]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserAddresses] PRIMARY KEY CLUSTERED ([UserAddressID] ASC)
);

