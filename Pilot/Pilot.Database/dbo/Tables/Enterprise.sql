CREATE TABLE [dbo].[Enterprise]
(
    [Id]					uniqueidentifier    NOT NULL,
    [TypeEnterprise]		NVARCHAR (50) NOT NULL,
	[FullName]				NVARCHAR (300) NOT NULL,
    [Position]				NVARCHAR (100) NULL,
    [Manager]				uniqueidentifier NOT NULL,
    [InPersonManager]		NVARCHAR (300) NULL,
    [Base]					NVARCHAR (max) NOT NULL,
    [INN]					NVARCHAR (12) NOT NULL,
    [KPP]					NVARCHAR (9) NULL,
    [OGRN]					NVARCHAR (20) NULL,
    [LegalAddress]			NVARCHAR (max) NOT NULL,
    [MailingAddress]		NVARCHAR (max) NOT NULL,
    [PhoneFax]				NVARCHAR (30) NULL,
    [Email]					NVARCHAR (100) NULL,
	[Passport]				NVARCHAR (25) NULL,
	[Created]				DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]				DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]				DATETIME NULL,
    CONSTRAINT [PK_dbo.Enterprise] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enterprise_To_Person] FOREIGN KEY ([Manager])  REFERENCES [Person] (Id),
);
GO
