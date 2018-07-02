CREATE TABLE [dbo].[PaymentAccount]
(
    [Id]			uniqueidentifier    NOT NULL,
	[Account]		NVARCHAR (25) NOT NULL,
	[EnterpriseId]	uniqueidentifier    NOT NULL,
	[BankId]		uniqueidentifier    NOT NULL,
	[Created]		DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]		DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]		DATETIME NULL,
    CONSTRAINT [PK_dbo.PaymentAccount] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_PaymentAccount_To_Enterprise] FOREIGN KEY ([EnterpriseId])  REFERENCES [Enterprise] (Id),
	CONSTRAINT [FK_PaymentAccount_To_Bank] FOREIGN KEY ([BankId])  REFERENCES [Bank] (Id)
);
GO
