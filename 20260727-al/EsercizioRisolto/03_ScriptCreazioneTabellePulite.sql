USE [EsercizioDb02];

PRINT N'Creazione di Tabella [dbo].[Brands]...';


GO
CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandID] ASC),
    CONSTRAINT [UNI_BrandName] UNIQUE NONCLUSTERED ([BrandName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Categories]...';


GO
CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [UNI_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Cities]...';


GO
CREATE TABLE [dbo].[Cities] (
    [CityID]     INT           IDENTITY (1, 1) NOT NULL,
    [ProvinceID] INT           NOT NULL,
    [CityName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [UNI_CityName] UNIQUE NONCLUSTERED ([CityName] ASC, [ProvinceID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Customers]...';


GO
CREATE TABLE [dbo].[Customers] (
    [CustomerID]         NVARCHAR (50) NOT NULL,
    [CustomerFirstName]  NVARCHAR (50) NOT NULL,
    [CustomerLastName]   NVARCHAR (50) NOT NULL,
    [CustomerEmail]      NVARCHAR (50) NOT NULL,
    [CustomerCityID]     INT           NOT NULL,
    [CustomerSegmentID]  INT           NOT NULL,
    [CustomerSignupDate] DATE          NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    CONSTRAINT [UNI_CustomerEmail] UNIQUE NONCLUSTERED ([CustomerEmail] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[CustomerSegments]...';


GO
CREATE TABLE [dbo].[CustomerSegments] (
    [CustomerSegmentID]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerSegmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CustomerSegments] PRIMARY KEY CLUSTERED ([CustomerSegmentID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[OrderLines]...';


GO
CREATE TABLE [dbo].[OrderLines] (
    [OrderLineID]     NVARCHAR (50)   NOT NULL,
    [OrderID]         NVARCHAR (50)   NOT NULL,
    [ProductCode]     NVARCHAR (50)   NOT NULL,
    [UnitPriceEUR]    DECIMAL (10, 2) NOT NULL,
    [Quantity]        INT             NOT NULL,
    [DiscountPct]     DECIMAL (5, 2)  NOT NULL,
    [ShippingCostEUR] DECIMAL (10, 2) NOT NULL,
    [LineRevenueEUR]  DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED ([OrderLineID] ASC),
    CONSTRAINT [CK_DiscountPct0_100] CHECK ([DiscountPct]>=(0) AND [DiscountPct]<=(100))
);


GO
PRINT N'Creazione di Tabella [dbo].[Orders]...';


GO
CREATE TABLE [dbo].[Orders] (
    [OrderID]         NVARCHAR (50) NOT NULL,
    [OrderDate]       DATE          NOT NULL,
    [CustomerID]      NVARCHAR (50) NOT NULL,
    [SalesRepID]      NVARCHAR (50) NOT NULL,
    [SalesChannelID]  INT           NOT NULL,
    [WharehouseID]    NVARCHAR (50) NOT NULL,
    [PaymentMethodID] INT           NOT NULL,
    [OrderStatusID]   INT           NOT NULL,
    [DeliveryDate]    DATE          NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [CK_DeliveryDateOrderDate] CHECK ([DeliveryDate] IS NULL OR [DeliveryDate]>=[OrderDate])
);


GO
PRINT N'Creazione di Tabella [dbo].[OrderStatuses]...';


GO
CREATE TABLE [dbo].[OrderStatuses] (
    [OrderStatusID]   INT           IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED ([OrderStatusID] ASC),
    CONSTRAINT [UNI_OrderStatusName] UNIQUE NONCLUSTERED ([OrderStatusName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[PaymentMethods]...';


GO
CREATE TABLE [dbo].[PaymentMethods] (
    [PaymentMethodID]   INT           IDENTITY (1, 1) NOT NULL,
    [PaymentMethodName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([PaymentMethodID] ASC),
    CONSTRAINT [UNI_PaymentMethods] UNIQUE NONCLUSTERED ([PaymentMethodName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Products]...';


GO
CREATE TABLE [dbo].[Products] (
    [ProductCode] NVARCHAR (50)   NOT NULL,
    [ProductName] NVARCHAR (50)   NOT NULL,
    [CategoryID]  INT             NOT NULL,
    [BrandID]     INT             NOT NULL,
    [PriceEUR]    DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductCode] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Provinces]...';


GO
CREATE TABLE [dbo].[Provinces] (
    [ProvinceID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionID]     INT           NOT NULL,
    [ProvinceCode] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED ([ProvinceID] ASC),
    CONSTRAINT [UNI_ProvinceCode] UNIQUE NONCLUSTERED ([ProvinceCode] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Regions]...';


GO
CREATE TABLE [dbo].[Regions] (
    [RegionID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([RegionID] ASC),
    CONSTRAINT [UNI_RegionName] UNIQUE NONCLUSTERED ([RegionName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesAreas]...';


GO
CREATE TABLE [dbo].[SalesAreas] (
    [SalesAreaID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesAreaName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesAreas] PRIMARY KEY CLUSTERED ([SalesAreaID] ASC),
    CONSTRAINT [UNI_SalesAreaName] UNIQUE NONCLUSTERED ([SalesAreaName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesChannels]...';


GO
CREATE TABLE [dbo].[SalesChannels] (
    [SalesChannelID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesChannelName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesChannels] PRIMARY KEY CLUSTERED ([SalesChannelID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesReps]...';


GO
CREATE TABLE [dbo].[SalesReps] (
    [SalesRepID]        NVARCHAR (50) NOT NULL,
    [SalesRepFirstName] NVARCHAR (50) NOT NULL,
    [SalesRepLastName]  NVARCHAR (50) NOT NULL,
    [SalesRepEmail]     NVARCHAR (50) NOT NULL,
    [SalesAreaID]       INT           NOT NULL,
    CONSTRAINT [PK_SalesReps] PRIMARY KEY CLUSTERED ([SalesRepID] ASC),
    CONSTRAINT [UNI_SalesRepEmail] UNIQUE NONCLUSTERED ([SalesRepEmail] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Warehouses]...';


GO
CREATE TABLE [dbo].[Warehouses] (
    [WarehouseID]     NVARCHAR (50) NOT NULL,
    [WarehouseName]   NVARCHAR (50) NOT NULL,
    [WarehouseCityID] INT           NOT NULL,
    CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED ([WarehouseID] ASC)
);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Cities_Provinces]...';


GO
ALTER TABLE [dbo].[Cities]
    ADD CONSTRAINT [FK_Cities_Provinces] FOREIGN KEY ([ProvinceID]) REFERENCES [dbo].[Provinces] ([ProvinceID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Customers_CustomerSegments]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [FK_Customers_CustomerSegments] FOREIGN KEY ([CustomerSegmentID]) REFERENCES [dbo].[CustomerSegments] ([CustomerSegmentID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Customers_Cities]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [FK_Customers_Cities] FOREIGN KEY ([CustomerCityID]) REFERENCES [dbo].[Cities] ([CityID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_OrderLines_Products]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [FK_OrderLines_Products] FOREIGN KEY ([ProductCode]) REFERENCES [dbo].[Products] ([ProductCode]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_OrderLines_Orders]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_SalesReps]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_SalesReps] FOREIGN KEY ([SalesRepID]) REFERENCES [dbo].[SalesReps] ([SalesRepID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_PaymentMethods]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_PaymentMethods] FOREIGN KEY ([PaymentMethodID]) REFERENCES [dbo].[PaymentMethods] ([PaymentMethodID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_OrderStatuses]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY ([OrderStatusID]) REFERENCES [dbo].[OrderStatuses] ([OrderStatusID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_SalesChannels]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_SalesChannels] FOREIGN KEY ([SalesChannelID]) REFERENCES [dbo].[SalesChannels] ([SalesChannelID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_Warehouses]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Warehouses] FOREIGN KEY ([WharehouseID]) REFERENCES [dbo].[Warehouses] ([WarehouseID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_Customers]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Products_Brands]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Products_Categories]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Provinces_Regions]...';


GO
ALTER TABLE [dbo].[Provinces]
    ADD CONSTRAINT [FK_Provinces_Regions] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Regions] ([RegionID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_SalesReps_SalesAreas]...';


GO
ALTER TABLE [dbo].[SalesReps]
    ADD CONSTRAINT [FK_SalesReps_SalesAreas] FOREIGN KEY ([SalesAreaID]) REFERENCES [dbo].[SalesAreas] ([SalesAreaID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Warehouses_Cities]...';


GO
ALTER TABLE [dbo].[Warehouses]
    ADD CONSTRAINT [FK_Warehouses_Cities] FOREIGN KEY ([WarehouseCityID]) REFERENCES [dbo].[Cities] ([CityID]);


GO
PRINT N'Creazione di Vincolo CHECK [dbo].[CK_QuantityGreaterThanZero]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [CK_QuantityGreaterThanZero] CHECK ([Quantity]>(0));


GO
PRINT N'Creazione di Vista [dbo].[Vw_Customers_Info]...';


GO
CREATE VIEW [dbo].[Vw_Customers_Info]
AS
SELECT        dbo.Customers.CustomerID, dbo.Customers.CustomerFirstName, dbo.Customers.CustomerLastName, dbo.Customers.CustomerEmail, dbo.Customers.CustomerSignupDate, dbo.Cities.CityName, dbo.Provinces.ProvinceCode, 
                            dbo.CustomerSegments.CustomerSegmentName
FROM            dbo.Customers INNER JOIN
                            dbo.CustomerSegments ON dbo.Customers.CustomerSegmentID = dbo.CustomerSegments.CustomerSegmentID INNER JOIN
                            dbo.Cities ON dbo.Customers.CustomerCityID = dbo.Cities.CityID INNER JOIN
                            dbo.Provinces ON dbo.Cities.ProvinceID = dbo.Provinces.ProvinceID INNER JOIN
                            dbo.Regions ON dbo.Provinces.RegionID = dbo.Regions.RegionID
GO
PRINT N'Creazione di Proprietà estesa [dbo].[Vw_Customers_Info].[MS_DiagramPane2]...';


GO
PRINT N'Aggiornamento completato.';


GO
