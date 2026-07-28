CREATE TABLE [dbo].[PaymentMethods] (
    [PaymentMethodID]   INT           IDENTITY (1, 1) NOT NULL,
    [PaymentMethodName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([PaymentMethodID] ASC),
    CONSTRAINT [UNI_PaymentMethods] UNIQUE NONCLUSTERED ([PaymentMethodName] ASC)
);


GO

