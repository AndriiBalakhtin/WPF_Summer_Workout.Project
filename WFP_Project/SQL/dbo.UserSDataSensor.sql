CREATE TABLE [dbo].[UserSDataSensor]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [WaterLevel] FLOAT NOT NULL,
    [Timestamp] DATETIME NOT NULL
);
