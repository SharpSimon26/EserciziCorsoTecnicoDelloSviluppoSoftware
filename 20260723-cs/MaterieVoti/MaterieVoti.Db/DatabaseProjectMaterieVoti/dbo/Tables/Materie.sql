CREATE TABLE [dbo].[Materie] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Materia] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_materie] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

