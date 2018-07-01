CREATE TABLE [dbo].[Bank]
(
    [Id]					uniqueidentifier    NOT NULL,
	[FullNameBank]			NVARCHAR (500) NULL,
    [AddressBank]			NVARCHAR (max) NULL,
    [BIK]					NVARCHAR (16)  NOT NULL,
    [CorrespondingAccount]	NVARCHAR (25) NOT NULL,
	[Created]				DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]				DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]				DATETIME NULL,
    CONSTRAINT [PK_dbo.Bank] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
