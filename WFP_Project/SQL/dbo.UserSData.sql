CREATE TABLE [dbo].[UserSData] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);