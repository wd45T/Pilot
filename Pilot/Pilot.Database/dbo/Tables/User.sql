CREATE TABLE [dbo].[User]
(
    [Id]			uniqueidentifier    NOT NULL,
    [Name]			NVARCHAR (100) NOT NULL,
	[Created]		DATETIME NOT NULL DEFAULT getdate(), 
    [Modified]		DATETIME NOT NULL DEFAULT getdate(), 
    [Deleted]		DATETIME NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TRIGGER [dbo].[User_U_TR]
   ON [dbo].[User] FOR UPDATE AS
BEGIN
 set nocount on
  if not exists (select 1 from inserted) or 
     not exists (select 1 from deleted) return
update [User] set Modified=getdate()
    from inserted i, deleted d, [User] upd_id
   where i.Id = d.Id and d.Id=upd_id.Id
 return       
END
GO
