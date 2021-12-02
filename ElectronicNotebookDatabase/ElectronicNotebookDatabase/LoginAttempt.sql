CREATE TABLE [dbo].[LoginAttempt]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[attempts] INT NOT NULL,
	constraint secretaryFK foreign key(Id) references Secretary(id)
)
