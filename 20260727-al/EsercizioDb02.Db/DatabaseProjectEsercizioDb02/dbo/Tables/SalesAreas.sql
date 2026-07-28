CREATE TABLE [dbo].[SalesAreas] (
    [SalesAreaID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesAreaName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesAreas] PRIMARY KEY CLUSTERED ([SalesAreaID] ASC),
    CONSTRAINT [UNI_SalesAreaName] UNIQUE NONCLUSTERED ([SalesAreaName] ASC)
);


GO

