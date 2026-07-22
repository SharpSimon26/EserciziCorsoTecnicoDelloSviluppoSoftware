CREATE TABLE [dbo].[Todos] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [Done]        BIT           CONSTRAINT [DEFAULT_Todos_Done] DEFAULT 0 NOT NULL,
    CONSTRAINT [PK_Todos] PRIMARY KEY CLUSTERED ([Id] ASC)
);