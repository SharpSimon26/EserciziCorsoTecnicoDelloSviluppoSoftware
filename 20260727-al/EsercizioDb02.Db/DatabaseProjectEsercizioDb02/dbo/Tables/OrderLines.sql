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
    CONSTRAINT [CK_DiscountPct0_100] CHECK ([DiscountPct]>=(0) AND [DiscountPct]<=(100)),
    CONSTRAINT [CK_QuantityGreaterThanZero] CHECK ([Quantity]>(0)),
    CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    CONSTRAINT [FK_OrderLines_Products] FOREIGN KEY ([ProductCode]) REFERENCES [dbo].[Products] ([ProductCode])
);


GO


