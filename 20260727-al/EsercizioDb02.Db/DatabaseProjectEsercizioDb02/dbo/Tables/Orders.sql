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
    CONSTRAINT [CK_DeliveryDateOrderDate] CHECK ([DeliveryDate] IS NULL OR [DeliveryDate]>=[OrderDate]),
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]),
    CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY ([OrderStatusID]) REFERENCES [dbo].[OrderStatuses] ([OrderStatusID]),
    CONSTRAINT [FK_Orders_PaymentMethods] FOREIGN KEY ([PaymentMethodID]) REFERENCES [dbo].[PaymentMethods] ([PaymentMethodID]),
    CONSTRAINT [FK_Orders_SalesChannels] FOREIGN KEY ([SalesChannelID]) REFERENCES [dbo].[SalesChannels] ([SalesChannelID]),
    CONSTRAINT [FK_Orders_SalesReps] FOREIGN KEY ([SalesRepID]) REFERENCES [dbo].[SalesReps] ([SalesRepID]),
    CONSTRAINT [FK_Orders_Warehouses] FOREIGN KEY ([WharehouseID]) REFERENCES [dbo].[Warehouses] ([WarehouseID])
);


GO


