CREATE TABLE [dbo].[OrderStatuses] (
    [OrderStatusID]   INT           IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED ([OrderStatusID] ASC),
    CONSTRAINT [UNI_OrderStatusName] UNIQUE NONCLUSTERED ([OrderStatusName] ASC)
);


GO

