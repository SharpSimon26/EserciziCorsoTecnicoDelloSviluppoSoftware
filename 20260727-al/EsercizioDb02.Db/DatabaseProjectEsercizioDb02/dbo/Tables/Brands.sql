CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandID] ASC),
    CONSTRAINT [UNI_BrandName] UNIQUE NONCLUSTERED ([BrandName] ASC)
);


GO

