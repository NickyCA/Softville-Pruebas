CREATE TABLE [dbo].[Professional]
(
id int,
name VARCHAR(25) NOT NULL,
lastName1 VARCHAR(25) NOT NULL,
lastName2 VARCHAR(25),
speciality VARCHAR(25) NOT NULL,
constraint professionalPK primary key(id)
)
