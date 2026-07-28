CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [UNI_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);


GO

