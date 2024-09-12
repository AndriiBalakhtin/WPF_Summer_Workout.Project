CREATE TABLE [dbo].[UserSDataConfirmations] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (50)  NOT NULL,
    [Role]     VARCHAR (13)  NOT NULL,
    [Email]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

