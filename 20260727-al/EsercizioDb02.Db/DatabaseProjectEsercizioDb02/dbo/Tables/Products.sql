CREATE TABLE [dbo].[Products] (
    [ProductCode] NVARCHAR (50)   NOT NULL,
    [ProductName] NVARCHAR (50)   NOT NULL,
    [CategoryID]  INT             NOT NULL,
    [BrandID]     INT             NOT NULL,
    [PriceEUR]    DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductCode] ASC),
    CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID]),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID])
);


GO

