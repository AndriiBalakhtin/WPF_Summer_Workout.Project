CREATE TABLE [dbo].[Exercises] (
    [ExerciseId]   INT           IDENTITY (1, 1) NOT NULL,
    [TrainingId]   INT           NULL,
    [ExerciseName] VARCHAR (255) NULL,
    [Reps]         INT           NULL,
    [Sets]         INT           NULL,
    PRIMARY KEY CLUSTERED ([ExerciseId] ASC),
    FOREIGN KEY ([TrainingId]) REFERENCES [dbo].[Trainings] ([TrainingId])
);

