CREATE TABLE [dbo].[Calculation] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [NumberA]    NVARCHAR (MAX)   NULL,
    [NumberB]    NVARCHAR (MAX)   NULL,
    [Op]         NVARCHAR (MAX)   NULL,
    [Result]     NVARCHAR (MAX)   NULL,
    [Person_Id]  UNIQUEIDENTIFIER NULL,
    [Person_Id1] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CalculationContext.Calculation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CalculationContext.Calculation_CalculationContext.Person_Person_Id] FOREIGN KEY ([Person_Id]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_CalculationContext.Calculation_CalculationContext.Person_Person_Id1] FOREIGN KEY ([Person_Id1]) REFERENCES [dbo].[Person] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Person_Id]
    ON [dbo].[Calculation]([Person_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Person_Id1]
    ON [dbo].[Calculation]([Person_Id1] ASC);