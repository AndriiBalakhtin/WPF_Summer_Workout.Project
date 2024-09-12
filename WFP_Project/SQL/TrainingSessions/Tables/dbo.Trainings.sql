CREATE TABLE [dbo].[Trainings] (
    [TrainingId]   INT           IDENTITY (1, 1) NOT NULL,
    [TrainingName] VARCHAR (255) NULL,
    [AthleteName]  VARCHAR (255) NULL,
    [CoachName]    VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([TrainingId] ASC)
);

