CREATE TABLE [dbo].[EnterpriseBank]
(
    [Id]			uniqueidentifier    NOT NULL,
	[EnterpriseId]	uniqueidentifier    NOT NULL,
	[BankId]	uniqueidentifier    NOT NULL,
	[Created]		DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]		DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]		DATETIME NULL,
    CONSTRAINT [PK_dbo.EnterpriseBank] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_EnterpriseBank_To_Enterprise] FOREIGN KEY ([EnterpriseId])  REFERENCES [Enterprise] (Id),
	CONSTRAINT [FK_EnterpriseBank_To_Bank] FOREIGN KEY ([BankId])  REFERENCES [Bank] (Id)
);
GO
