CREATE TABLE [dbo].[Patients]
(
id int,
name VARCHAR(25) NOT NULL,
lastName1 VARCHAR(25) NOT NULL,
lastName2 VARCHAR(25),
email VARCHAR(50) NULL,
phone int NOT NULL, 
constraint patientsPK primary key(id)
)
