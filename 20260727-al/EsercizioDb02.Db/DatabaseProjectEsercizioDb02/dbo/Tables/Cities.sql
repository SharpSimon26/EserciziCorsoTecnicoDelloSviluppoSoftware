CREATE TABLE [dbo].[Cities] (
    [CityID]     INT           IDENTITY (1, 1) NOT NULL,
    [ProvinceID] INT           NOT NULL,
    [CityName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [FK_Cities_Provinces] FOREIGN KEY ([ProvinceID]) REFERENCES [dbo].[Provinces] ([ProvinceID]),
    CONSTRAINT [UNI_CityName] UNIQUE NONCLUSTERED ([CityName] ASC, [ProvinceID] ASC)
);


GO

