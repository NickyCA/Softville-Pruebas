CREATE TABLE [dbo].[Appointment]
(
date date,
time time,
patientId int NOT NULL,
professionalId int NOT NULL,
constraint citasPR primary key (date,time),
constraint pacienteFK foreign key(patientId) references Patients(id),
constraint profesionalFK foreign key(professionalId) references Professional(id)
)
