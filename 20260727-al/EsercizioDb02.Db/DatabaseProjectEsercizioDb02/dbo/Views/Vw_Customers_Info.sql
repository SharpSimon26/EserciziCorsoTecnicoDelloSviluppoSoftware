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

