CREATE TABLE [dbo].[SalesChannels] (
    [SalesChannelID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesChannelName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesChannels] PRIMARY KEY CLUSTERED ([SalesChannelID] ASC)
);


GO

