BEGIN TRY
	BEGIN TRANSACTION;

	use EsercizioDb02;

	PRINT N'Inserimento Dati nella Tabella [dbo].[SalesAreas]...';
	insert into SalesAreas (SalesAreaName) (select distinct SalesArea from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[PaymentMethods]...';
	insert into PaymentMethods (PaymentMethodName) (select distinct PaymentMethod from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Regions]...';
	insert into Regions (RegionName) (select distinct CustomerRegion from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[CustomerSegments]...';
	insert into CustomerSegments (CustomerSegmentName) (select distinct CustomerSegment from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[OrderStatuses]...';
	insert into OrderStatuses (OrderStatusName) (select distinct OrderStatus from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Brands]...';
	insert into Brands (BrandName) (select distinct Brand from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Categories]...';
	insert into Categories (CategoryName) (select distinct Category from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[SalesChannels]...';
	insert into SalesChannels (SalesChannelName) (select distinct SalesChannel from StagingSales);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Products]...';
	insert into Products (ProductCode, ProductName, CategoryID, BrandID, PriceEUR)
	(
		select distinct s.ProductCode, s.ProductName, c.CategoryID, b.BrandID, s.UnitPriceEUR 
		from StagingSales s
		inner join Categories c on s.Category = c.CategoryName
		inner join Brands b on s.Brand = b.BrandName
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Provinces]...';
	insert into Provinces (RegionID, ProvinceCode)
	(
		select distinct r.RegionID, s.CustomerProvince from StagingSales s
		inner join Regions r on r.RegionName = s.CustomerRegion
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Cities]...';
	insert into Cities (ProvinceID, CityName)
	(
		select distinct p.ProvinceID, s.CustomerCity from StagingSales s
		inner join Provinces p on p.ProvinceCode = s.CustomerProvince
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Customers]...';
	insert into Customers (CustomerID, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerCityID, CustomerSegmentID, CustomerSignupDate)
	(
		select distinct s.CustomerID, s.CustomerFirstName, s.CustomerLastName, s.CustomerEmail, c.CityID, cs.CustomerSegmentID, s.CustomerSignupDate
		from StagingSales s
		inner join CustomerSegments cs on cs.CustomerSegmentName = s.CustomerSegment
		inner join Cities c on c.CityName = s.CustomerCity
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Warehouses]...';
	insert into Warehouses (WarehouseID, WarehouseName, WarehouseCityID)
	(
		select distinct s.WarehouseID, s.WarehouseName, c.CityID from StagingSales s
		inner join Cities c on c.CityName = s.WarehouseCity
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[SalesReps]...';
	insert into SalesReps (SalesRepID, SalesRepFirstName, SalesRepLastName, SalesRepEmail, SalesAreaID)
	(
		select distinct s.SalesRepID, s.SalesRepFirstName, s.SalesRepLastName, s.SalesRepEmail, sa.SalesAreaID
		from StagingSales s
		inner join SalesAreas sa on sa.SalesAreaName = s.SalesArea
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[Orders]...';
	insert into Orders (OrderID, OrderDate, CustomerID, SalesRepID, SalesChannelID, WharehouseID, PaymentMethodID, OrderStatusID, DeliveryDate)
	(
		select distinct s.OrderID, s.OrderDate, s.CustomerID, s.SalesRepID, sc.SalesChannelID, s.WarehouseID, pm.PaymentMethodID, os.OrderStatusID, s.DeliveryDate 
		from StagingSales s
		inner join SalesChannels sc on sc.SalesChannelName = s.SalesChannel
		inner join PaymentMethods pm on pm.PaymentMethodName = s.PaymentMethod
		inner join OrderStatuses os on os.OrderStatusName = s.OrderStatus
	);

	PRINT N'Inserimento Dati nella Tabella [dbo].[OrderLines]...';
	insert into OrderLines (OrderLineID, OrderID, ProductCode, UnitPriceEUR, Quantity, DiscountPct, ShippingCostEUR, LineRevenueEUR)
	(
		select distinct OrderLineID, OrderID, ProductCode, UnitPriceEUR, Quantity, DiscountPct, ShippingCostEUR, LineRevenueEUR 
		from StagingSales
	);

	PRINT N'Inserimento Dati completato.';

	COMMIT TRANSACTION;

END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
	THROW;
END CATCH;
