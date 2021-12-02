/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
delete from LoginAttempt
delete from Appointment
delete from Secretary
delete from Professional
delete from Patients





INSERT INTO Secretary (name, lastName1, lastName2, id, password)
VALUES ('Veronica', 'Hernández', 'Chavarría', 207540415, 'admin1234'),
	    ('Pamela', 'Rodriguez', 'Ramirez', 307650214, 'admin1234'),
		('Antonio', 'Ugalde', 'Salas', 701420987, 'admin1234')

INSERT INTO Patients(name, lastName1, lastName2, id, email, phone)
VALUES ('Adriana', 'Torres', 'Quesada', 501240597, 'adriana@gmail.com', 87415412),
	   ('Alexander', 'Aguilar', 'Blanco', 401230987, 'alexander@gmail.com', 87462542),
	   ('Diego', 'Lopez', 'Guerrero', 601240784, 'diego@gmail.com', 87958812),
	   ('Randall', 'Guillén', 'Solano', 701240995, 'randall@gmail.com', 84510326)

INSERT INTO Professional (name, lastName1, lastName2, id, speciality)
VALUES ('Laura', 'García', 'Rojas', 301240497, 'Otorrinolaringólogía'),
	   ('Pedro', 'Cervantes', 'Diaz', 701420654, 'Neurología'),
	   ('María', 'Perez', 'Alvarez', 709540329, 'Dermatología')

INSERT INTO Appointment(date, time, patientId, professionalId)
VALUES ('2020-12-15', '13:00', 501240597, 301240497 ),
	   ('2020-12-16', '17:00', 401230987, 701420654 ),
	   ('2021-01-10', '11:00', 601240784, 709540329 ),
	   ('2023-08-10', '10:00', 701240995, 301240497)


INSERT INTO LoginAttempt (id, attempts)
VALUES ( 207540415, 0),
	    ( 307650214, 0),
		( 701420987, 0)