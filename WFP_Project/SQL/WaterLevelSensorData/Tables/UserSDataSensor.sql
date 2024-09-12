CREATE TABLE [dbo].[UserSDataSensor] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [WaterLevel] FLOAT (53) NOT NULL,
    [Timestamp]  DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

