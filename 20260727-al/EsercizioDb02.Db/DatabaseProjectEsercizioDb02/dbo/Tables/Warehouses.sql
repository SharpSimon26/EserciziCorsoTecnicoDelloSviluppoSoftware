CREATE TABLE [dbo].[Warehouses] (
    [WarehouseID]     NVARCHAR (50) NOT NULL,
    [WarehouseName]   NVARCHAR (50) NOT NULL,
    [WarehouseCityID] INT           NOT NULL,
    CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED ([WarehouseID] ASC),
    CONSTRAINT [FK_Warehouses_Cities] FOREIGN KEY ([WarehouseCityID]) REFERENCES [dbo].[Cities] ([CityID])
);


GO

