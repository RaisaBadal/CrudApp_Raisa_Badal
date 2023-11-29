CREATE TABLE [dbo].[UserProfiles] (
    [UserProfileID]  INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (MAX) NOT NULL,
    [LastName]       NVARCHAR (MAX) NOT NULL,
    [PersonalNumber] NVARCHAR (11)  NOT NULL,
    [ExpireDate]     DATETIME2 (7)  NULL,
    [AddressID]      INT            NOT NULL,
    [CompanyID]      INT            NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([UserProfileID] ASC),
    CONSTRAINT [FK_UserProfiles_Companys_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Companys] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserProfiles_UserAddresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[UserAddresses] ([UserAddressID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_AddressID]
    ON [dbo].[UserProfiles]([AddressID] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_CompanyID]
    ON [dbo].[UserProfiles]([CompanyID] ASC);

