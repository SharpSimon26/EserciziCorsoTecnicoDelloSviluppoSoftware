USE [EsercizioDb02];
-- Fase 5 - Verifiche - Produrre query che dimostrino:

-- 20.000 righe in OrderLines
select count(*) as NumOrderLines from OrderLines;

-- Nessun OrderLineID duplicato;
-- > In ogni caso non possono esserci OrderLineID duplicati perchè OrderLineID è una PK quindi univoca per definizione
select OrderLineID, count(*) as Num from OrderLines group by OrderLineID having count(*) > 1;

-- Il Numero totale dei duplicati sarà sempre 0
select count(*) as NumDuplicati
from (
    select OrderLineID
    from OrderLines
    group by OrderLineID
    having count(*) > 1
) AS Dup;

-- Nessun record orfano

-- Totale righe per entità;
select
(select count(*) from Brands) as NumBrands,
(select count(*) from Categories) as NumCategories,
(select count(*) from Cities) as NumCities,
(select count(*) from Customers) as NumCustomers,
(select count(*) from CustomerSegments) as NumCustomerSegments,
(select count(*) from OrderLines) as NumOrderLines,
(select count(*) from Orders) as NumOrders,
(select count(*) from OrderStatuses) as NumOrderStatuses,
(select count(*) from PaymentMethods) as NumPaymentMethods,
(select count(*) from Products) as NumProducts,
(select count(*) from Provinces) as NumProvinces,
(select count(*) from Regions) as NumRegions,
(select count(*) from SalesAreas) as NumSalesAreas,
(select count(*) from SalesChannels) as NumSalesChannels,
(select count(*) from SalesReps) as NumSalesReps,
(select count(*) from Warehouses) as NumWarehouses

-- Uguaglianza tra ricavo importato e ricavo ricalcolato;
-- Formula: ((UnitPriceEUR * Quantity) - Discount Pct) + ShippingCostEUR
select OrderLineID, UnitPriceEUR, Quantity, DiscountPct, ShippingCostEUR, LineRevenueEUR,
cast(
    ((UnitPriceEUR * Quantity) * (1 - DiscountPct / 100.0))
    + ShippingCostEUR
    as decimal(10,2)
) AS CalcLineRevenueEUR,
LineRevenueEUR -
cast(
    ((UnitPriceEUR * Quantity) * (1 - DiscountPct / 100.0))
    + ShippingCostEUR
    as decimal(10,2)
) as Difference
from OrderLines
order by Difference desc;

-- Assenza di duplicati nelle anagrafiche;
-- Il campo CustomerEmail ha un indice univoco e il campo CustomerID è la chiave primaria della tabella quindi univoca.
select count(*) as NumEmailDuplicate
from (
    select CustomerEmail
    from Customers
    group by CustomerEmail
    having count(*) > 1
) AS Dup;

-- Non essendoci campi sufficientemente identificativi per il cliente vengono valutati i campi FirstName, LastName e City
-- ma anche questo dato non è prova certa che si tratti della stessa persona
select cu.CustomerFirstName, cu.CustomerLastName, ci.CityName, count(*) NumRipetute 
from Customers cu
inner join Cities ci on cu.CustomerCityID = ci.CityID 
group by cu.CustomerFirstName, cu.CustomerLastName, ci.CityName having count(*) > 1;

-- Corretta relazione tra ordine e righe ordine.
-- Nessun record in OrderLines che faccia riferimento ad un OrderID inesistente
select o.OrderID, ol.OrderLineID from OrderLines ol
left join Orders o on o.OrderID = ol.OrderID
where o.OrderID is null;

-- Nessun record in Orders che non abbia almeno 1 record associato in OrderLines;
select o.OrderID, ol.OrderLineID from Orders o
left join OrderLines ol on o.OrderID = ol.OrderID
where ol.OrderLineID is null;

-- Fase 6 - Analisi SQL
-- 1. Fatturato mensile
select FORMAT(o.OrderDate, 'yyyy-MM') AS OrderYearMonth, SUM(ol.LineRevenueEUR) as MonthRevenueEUR 
from OrderLines ol
inner join Orders o on o.OrderID = ol.OrderID
group by FORMAT(o.OrderDate, 'yyyy-MM')
order by OrderYearMonth desc;

-- 2. Fatturato per regione cliente
select re.RegionName, SUM(ol.LineRevenueEUR) RegionRevenue 
from Customers cu
inner join Cities ci on ci.CityID = cu.CustomerCityID
inner join Provinces pr on pr.ProvinceID = ci.ProvinceID
inner join Regions re on re.RegionID = pr.RegionID
inner join Orders od on od.CustomerID = cu.CustomerID
inner join OrderLines ol on ol.OrderID = od.OrderID
group by re.RegionName
order by re.RegionName;

-- 3. Top 10 prodotti per ricavi
select TOP 10 ProductName,
SUM(ol.LineRevenueEUR) Revenue
from Products pr
inner join OrderLines ol on ol.ProductCode = pr.ProductCode
group by ProductName
order by Revenue desc;

-- 4. Top 10 clienti per ricavi
select TOP 10 cu.CustomerID, cu.CustomerFirstName, cu.CustomerLastName, 
SUM(ol.LineRevenueEUR) CustomerRevenue
from Customers cu
inner join Orders od on od.CustomerID = cu.CustomerID
inner join OrderLines ol on ol.OrderID = od.OrderID
group by cu.CustomerID, cu.CustomerFirstName, cu.CustomerLastName
order by CustomerRevenue desc

-- 5. Performance dei venditori
select sr.SalesRepID, sr.SalesRepFirstName, sr.SalesRepLastName,
sum(ol.LineRevenueEUR) SalesPerformance
from SalesReps sr
inner join Orders od on od.SalesRepID = sr.SalesRepID
inner join OrderLines ol on ol.OrderID = od.OrderID
group by sr.SalesRepID, sr.SalesRepFirstName, sr.SalesRepLastName
order by sr.SalesRepLastName, sr.SalesRepFirstName;

-- 6. Valore medio ordine per canale
select ords.SalesChannelName, AVG(OrderRevenueEUR) AvgOrderRevenueEUR from (
    select od.OrderID, sc.SalesChannelName, SUM(ol.LineRevenueEUR) OrderRevenueEUR
    from Orders od
    inner join OrderLines ol on ol.OrderID = od.OrderID
    inner join SalesChannels sc on sc.SalesChannelID = od.SalesChannelID
    group by od.OrderID, SalesChannelName
) as ords
group by SalesChannelName
order by SalesChannelName;

-- 7. Tasso di reso e annullamento
select ords.OrderStatusName, count(*) as NumOrdini, CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(5,2)) AS Percentuale
from(
    select od.OrderID, os.OrderStatusName
    from Orders od
    inner join OrderStatuses os on os.OrderStatusID = od.OrderStatusID
) as ords
group by OrderStatusName
order by Percentuale desc;

-- 8. Tempo medio di consegna per magazzino
select ords.WarehouseName, CAST(AVG(DaysBeforeDelivery * 1.00) as decimal(6,2) ) AverageDaysBeforeDelivery
from(
    select od.OrderID, wa.WarehouseName, od.OrderDate, od.DeliveryDate, DATEDIFF(DAY, od.OrderDate, od.DeliveryDate) DaysBeforeDelivery
    from Orders od
    inner join Warehouses wa on wa.WarehouseID = od.WharehouseID
    where DeliveryDate is not null
) as ords
group by WarehouseName
order by WareHouseName;

-- 9. Categoria più venduta per regione
-- Numero prodotti venduti ordinato per regione e categoria
select ca.CategoryName, sum(ol.Quantity) TotQuantity, re.RegionName from OrderLines ol
inner join Orders od on od.OrderID = ol.OrderID
inner join Products pd on pd.ProductCode = ol.ProductCode
inner join Categories ca on ca.CategoryID = pd.CategoryID
inner join Customers cu on cu.CustomerID = od.CustomerID
inner join Cities ci on ci.CityID = cu.CustomerCityID
inner join Provinces pr on pr.ProvinceID = ci.ProvinceID
inner join Regions re on re.RegionID = pr.RegionID
group by ca.CategoryName, re.RegionName
order by RegionName, TotQuantity desc;

-- Incasso ordinato per regione e categoria
select ca.CategoryName, sum(ol.LineRevenueEUR) TotRevenue, re.RegionName
from OrderLines ol
inner join Orders od on od.OrderID = ol.OrderID
inner join Products pd on pd.ProductCode = ol.ProductCode
inner join Categories ca on ca.CategoryID = pd.CategoryID
inner join Customers cu on cu.CustomerID = od.CustomerID
inner join Cities ci on ci.CityID = cu.CustomerCityID
inner join Provinces pr on pr.ProvinceID = ci.ProvinceID
inner join Regions re on re.RegionID = pr.RegionID
group by ca.CategoryName, re.RegionName
order by RegionName, TotRevenue desc;

-- Window function
WITH RankedSales AS (
    SELECT 
        re.RegionName,
        ca.CategoryName,
        SUM(ol.LineRevenueEUR) AS TotRevenue,
        ROW_NUMBER() OVER (
            PARTITION BY re.RegionID 
            ORDER BY SUM(ol.LineRevenueEUR) DESC
        ) AS Ranking
    FROM OrderLines ol
    INNER JOIN Orders od ON od.OrderID = ol.OrderID
    INNER JOIN Products pd ON pd.ProductCode = ol.ProductCode
    INNER JOIN Categories ca ON ca.CategoryID = pd.CategoryID
    INNER JOIN Customers cu ON cu.CustomerID = od.CustomerID
    INNER JOIN Cities ci ON ci.CityID = cu.CustomerCityID
    INNER JOIN Provinces pr ON pr.ProvinceID = ci.ProvinceID
    INNER JOIN Regions re ON re.RegionID = pr.RegionID
    GROUP BY 
        re.RegionID, 
        re.RegionName, 
        ca.CategoryID, 
        ca.CategoryName
)
SELECT 
    RegionName,
    CategoryName,
    TotRevenue
FROM RankedSales
WHERE Ranking = 1
ORDER BY RegionName;

-- 10. Clienti senza ordini negli ultimi 180 giorni rispetto alla data massima del dataset
-- Ultimi ordini
select cu.CustomerID, od.OrderDate from Customers cu
inner join Orders od on od.CustomerID = cu.CustomerID
order by OrderDate desc;


select DATEADD(DAY, -180, MAX(OrderDate)) as LastOrderDate from Orders;
