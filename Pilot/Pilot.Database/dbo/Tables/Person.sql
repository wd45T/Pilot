CREATE TABLE [dbo].[Person]
(
    [Id]			uniqueidentifier    NOT NULL,
	[FirstName]     NVARCHAR (100) NOT NULL,
	[FamilyName]     NVARCHAR (100) NOT NULL,
	[Patronymic]     NVARCHAR (100) NULL,
	[Created]		DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]		DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]		DATETIME NULL,
    CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO