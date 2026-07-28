CREATE TABLE [dbo].[Customers] (
    [CustomerID]         NVARCHAR (50) NOT NULL,
    [CustomerFirstName]  NVARCHAR (50) NOT NULL,
    [CustomerLastName]   NVARCHAR (50) NOT NULL,
    [CustomerEmail]      NVARCHAR (50) NOT NULL,
    [CustomerCityID]     INT           NOT NULL,
    [CustomerSegmentID]  INT           NOT NULL,
    [CustomerSignupDate] DATE          NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    CONSTRAINT [FK_Customers_Cities] FOREIGN KEY ([CustomerCityID]) REFERENCES [dbo].[Cities] ([CityID]),
    CONSTRAINT [FK_Customers_CustomerSegments] FOREIGN KEY ([CustomerSegmentID]) REFERENCES [dbo].[CustomerSegments] ([CustomerSegmentID]),
    CONSTRAINT [UNI_CustomerEmail] UNIQUE NONCLUSTERED ([CustomerEmail] ASC)
);


GO


