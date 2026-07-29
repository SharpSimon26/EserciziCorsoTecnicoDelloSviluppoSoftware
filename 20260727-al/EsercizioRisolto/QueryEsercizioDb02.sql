USE [EsercizioDb02];
-- Produrre query che dimostrino:

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
