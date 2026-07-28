CREATE TABLE [dbo].[SalesReps] (
    [SalesRepID]        NVARCHAR (50) NOT NULL,
    [SalesRepFirstName] NVARCHAR (50) NOT NULL,
    [SalesRepLastName]  NVARCHAR (50) NOT NULL,
    [SalesRepEmail]     NVARCHAR (50) NOT NULL,
    [SalesAreaID]       INT           NOT NULL,
    CONSTRAINT [PK_SalesReps] PRIMARY KEY CLUSTERED ([SalesRepID] ASC),
    CONSTRAINT [FK_SalesReps_SalesAreas] FOREIGN KEY ([SalesAreaID]) REFERENCES [dbo].[SalesAreas] ([SalesAreaID]),
    CONSTRAINT [UNI_SalesRepEmail] UNIQUE NONCLUSTERED ([SalesRepEmail] ASC)
);


GO


