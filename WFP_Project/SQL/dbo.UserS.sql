CREATE TABLE [dbo].[UserS] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME      DEFAULT (getdate()) NOT NULL,
    [Force]       VARCHAR (25)  NULL,
    [1st]         INT           NULL,
    [Weight]      VARCHAR (50)  NULL,
    [2nd]         INT           NULL,
    [Goal]        VARCHAR (75)  NULL,
    [3rd]         INT           NULL,
    [Difficulty]  INT           NULL,
    [Description] VARCHAR (255) NULL,
    [Category]    VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

