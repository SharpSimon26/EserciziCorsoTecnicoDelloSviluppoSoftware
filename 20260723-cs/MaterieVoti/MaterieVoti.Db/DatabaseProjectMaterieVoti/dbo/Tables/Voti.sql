CREATE TABLE [dbo].[Voti] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [MateriaId]       INT        NOT NULL,
    [Voto]            FLOAT (53) NOT NULL,
    [DataInserimento] DATE       NOT NULL,
    CONSTRAINT [PK_Voti] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Voti_Materie] FOREIGN KEY ([MateriaId]) REFERENCES [dbo].[Materie] ([Id])
);


GO

