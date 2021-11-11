CREATE TABLE [dbo].[Secretary]
(
id int,
name VARCHAR(25) NOT NULL,
lastName1 VARCHAR(25) NOT NULL,
lastName2 VARCHAR(25),
password VARCHAR(20) NOT NULL,
constraint secretaryPK primary key(id)
)
