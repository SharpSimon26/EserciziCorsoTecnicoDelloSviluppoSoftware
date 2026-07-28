CREATE TABLE [dbo].[CustomerSegments] (
    [CustomerSegmentID]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerSegmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CustomerSegments] PRIMARY KEY CLUSTERED ([CustomerSegmentID] ASC)
);


GO

