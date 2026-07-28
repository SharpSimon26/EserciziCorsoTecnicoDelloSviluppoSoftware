CREATE TABLE [dbo].[Provinces] (
    [ProvinceID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionID]     INT           NOT NULL,
    [ProvinceCode] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED ([ProvinceID] ASC),
    CONSTRAINT [FK_Provinces_Regions] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Regions] ([RegionID]),
    CONSTRAINT [UNI_ProvinceCode] UNIQUE NONCLUSTERED ([ProvinceCode] ASC)
);


GO

