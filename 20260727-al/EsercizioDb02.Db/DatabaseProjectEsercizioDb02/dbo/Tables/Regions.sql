CREATE TABLE [dbo].[Regions] (
    [RegionID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([RegionID] ASC),
    CONSTRAINT [UNI_RegionName] UNIQUE NONCLUSTERED ([RegionName] ASC)
);


GO

