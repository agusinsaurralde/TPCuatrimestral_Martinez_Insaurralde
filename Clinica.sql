use master
go
create database Clinica
go
use Clinica
go
--TIPOEMPLEADO------------------------------
create table TipoEmpleado(
    ID int PRIMARY key IDENTITY(1,1) not null,
    Tipo VARCHAR(14) not null
)
GO
--EMPLEADO----------------------------------
create table Empleado(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    DNI VARCHAR(8) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Email VARCHAR(320) UNIQUE NOT NULL,
    Direccion VARCHAR(320) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    IDTipo int NOT NULL,
	Estado bit not null,
	CONSTRAINT FK_IDTipoEmpleado FOREIGN KEY (IDTipo) REFERENCES TipoEmpleado(ID),
	CONSTRAINT CHK_DNIEmpleado CHECK (DNI NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_TelefonoEmpleado CHECK (Telefono NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_EmailEmpleado CHECK (Email LIKE '__%@__%.__%'),
	CONSTRAINT CHK_DireccionEmpleado CHECK (Direccion LIKE '[A-Z]%[0-9]'),
	CONSTRAINT CHK_FechaNacimientoEmpleado CHECK (FechaNacimiento < GETDATE() AND FechaNacimiento > '1900-01-01')
)
go
--ESPECIALIDAD---------------------------------
create table Especialidad(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(50) UNIQUE not NULL,
	Estado bit not null
)
GO
--ESPECIALIDADXMEDICO------------------------------
create table EspecialidadXMedico(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    IDEspecialidad int not null,
    IDMedico int not null,
	Estado bit not null,

	CONSTRAINT FK_IDMedico FOREIGN KEY (IDMedico) REFERENCES Empleado(ID),
	CONSTRAINT FK_IDEspecialidad FOREIGN KEY (IDEspecialidad) REFERENCES Especialidad(ID)
)
GO
--DIAS----------------------
CREATE TABLE DIAS(
	ID INT PRIMARY KEY NOT NULL,
	NombreDia varchar(9) not null

)
go
--INSERT--
INSERT DIAS(ID, NombreDia) VALUES(1, 'Lunes')
go
INSERT DIAS(ID, NombreDia) VALUES(2, 'Martes')
go
INSERT DIAS(ID, NombreDia) VALUES(3, 'Miércoles')
go
INSERT DIAS(ID, NombreDia) VALUES(4, 'Jueves')
go
INSERT DIAS(ID, NombreDia) VALUES(5, 'Viernes')
go
INSERT DIAS(ID, NombreDia) VALUES(6, 'Sábado')
go
--DIASHABILESMEDICO---------------------------------
CREATE TABLE DiasHabilesMedico(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IDMedico INT NOT NULL FOREIGN KEY REFERENCES Empleado(ID),
	IDEspecialidad INT NOT NULL FOREIGN KEY REFERENCES Especialidad(ID),
	IDDia int not null FOREIGN KEY REFERENCES Dias(ID),
	HorarioEntrada datetime not null,
	HorarioSalida datetime not null,
	Estado bit not null
)
go
--DATOSMEDICO---------------------------------------
create table DatosMedico(
    ID int PRIMARY KEY not NULL,
	Matricula VARCHAR(10) Unique not null,
	Estado bit not null,

	CONSTRAINT FK_ID FOREIGN KEY (ID) REFERENCES Empleado(ID),
	CONSTRAINT CHK_Matricula CHECK (Matricula NOT LIKE '%[^0-9]%'),
)
go
--COBERTURA----------------------------------------
create table Cobertura(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(30) not null,
	Estado bit not null
)
go
--PACIENTE-------------------------------------------
create table Paciente(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    DNI VARCHAR(8) UNIQUE not null,
    Nombre VARCHAR(50) not null,
    Apellido VARCHAR(50) not null,
    Telefono VARCHAR(15) not null,
    Email VARCHAR(320) null,
    Direccion VARCHAR(320) not null,
    FechaNacimiento DATE not null,
    Cobertura int not null,
	Estado bit not null,

	CONSTRAINT FK_IDCobertura FOREIGN KEY (Cobertura) REFERENCES Cobertura(ID),

	CONSTRAINT CHK_DNIPaciente CHECK (DNI NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_TelefonoPaciente CHECK (Telefono NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_EmailPaciente CHECK (Email LIKE '__%@__%.__%'),
	CONSTRAINT CHK_DireccionPaciente CHECK (Direccion LIKE '[A-Z]%[0-9]'),
	CONSTRAINT CHK_FechaNacimientoPaciente CHECK (FechaNacimiento < GETDATE() AND FechaNacimiento > '1900-01-01')
)
GO
--HISTORIACLINICA----------------------------------
create table HistoriaClinica(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
	IDPaciente int not null,
	Fecha DATE not null,
    Descripcion VARCHAR(500) not null,
	Estado bit not null,

	CONSTRAINT FK_IDPacienteHC FOREIGN KEY (IDPaciente) REFERENCES Paciente(ID)
)
GO
--ESTADOTURNO--------------------------------------
Create table EstadoTurno(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Descripcion VARCHAR(20) not null
)
go

--TURNO----------------------------------------------
create table Turno(
    Numero int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IDPaciente int not null,
    IDEspXMedico int not null,
    Dia DATETIME not null,
    Observaciones VARCHAR(500) null,
    IDRecepcionista int not null,
    IDEstado int not null,
    HoraInicio DATETIME not NULL,

	CONSTRAINT FK_IDPacienteTURNO FOREIGN KEY (IDPaciente) REFERENCES Paciente(ID),
	CONSTRAINT FK_IDEspXMedico FOREIGN KEY (IDEspXMedico) REFERENCES EspecialidadXMedico(ID),
	CONSTRAINT FK_IDRecepcionista FOREIGN KEY (IDRecepcionista) REFERENCES Empleado(ID),
	CONSTRAINT FK_IDEstado FOREIGN KEY (IDEstado) REFERENCES EstadoTurno(ID),
	CONSTRAINT CHK_Dia CHECK (Dia >getdate()),
)
go  
--TipoUsuario----------------------------------
create table TipoUsuario(
    ID int PRIMARY key IDENTITY(1,1) not null,
    Nombre VARCHAR (13) not null
)
--INSERT
go
insert into tipousuario(nombre) values('Médico')
go
insert into tipousuario(nombre) values('Administrador')
go
insert into tipousuario(nombre) values('Recepcionista')

GO
--USUARIO-----------------------------------------------
create table Usuario(
    ID int PRIMARY KEY not null FOREIGN KEY REFERENCES EMPLEADO(ID),
    NombreUsuario VARCHAR(15) UNIQUE not null,
    Contraseña VARCHAR(15) not null,
    IDTipo int not null,
	Estado bit not null

	CONSTRAINT FK_IDTipoUsuario FOREIGN KEY (IDTipo) REFERENCES TipoUsuario(ID)
)



/*select * from Usuario
select * from tipoempleado
select * from empleado
select * from TipoUsuario
select * from Cobertura
select * from Especialidad
select * from HistoriaClinica
select * from Paciente*/
go
set dateformat 'dmy'
-----------Insert especialidades-------------------------
go
insert Especialidad(Nombre, Estado) values('Anestesiología', 1)
go
insert Especialidad(Nombre, Estado) values('Anatomía Patológica', 1)
go
insert Especialidad(Nombre, Estado) values('Angiología y Cirugía Vascular', 1)
go
insert Especialidad(Nombre, Estado) values('Cardiología', 1)
GO
insert Especialidad(Nombre, Estado) values('Cardiología Intervencionista', 1)
go
insert Especialidad(Nombre, Estado) values('Cirugía General', 1)
go
insert Especialidad(Nombre, Estado) values('Cirugía Oncólogica', 1)
go
insert Especialidad(Nombre, Estado) values('Cirugía Pediátrica', 1)
go
insert Especialidad(Nombre, Estado) values('Cirugía Plástica y Reconstructiva', 1)
go
insert Especialidad(Nombre, Estado) values('Médico Clínico', 1)
go
insert Especialidad(Nombre, Estado) values('Dermatología', 1)
go
insert Especialidad(Nombre, Estado) values('Endoscopía', 1)
go
insert Especialidad(Nombre, Estado) values('Gastroenterología', 1)
go
insert Especialidad(Nombre, Estado) values('Ginecología y Obstetricía', 1)
go
insert Especialidad(Nombre, Estado) values('Hematología', 1)
go
insert Especialidad(Nombre, Estado) values('Infectología', 1)
go
insert Especialidad(Nombre, Estado) values('Medicina Aeroespacial', 1)
go
insert Especialidad(Nombre, Estado) values('Medicina del Enfermo en Estado Crítico', 1)
go
insert Especialidad(Nombre, Estado) values('Medicina de Rehabilitación', 1)
go
insert Especialidad(Nombre, Estado) values('Medicina Interna', 1)
go
insert Especialidad(Nombre, Estado) values('Nefrología', 1)
go
insert Especialidad(Nombre, Estado) values('Neumonología', 1)
go
insert Especialidad(Nombre, Estado) values('Neurología', 1)
go
insert Especialidad(Nombre, Estado) values('Oftalmología', 1)
go
insert Especialidad(Nombre, Estado) values('Oncólogía Medica', 1)
go
insert Especialidad(Nombre, Estado) values('Oncólogía Pediátrica', 1)
go
insert Especialidad(Nombre, Estado) values('Ortopedia', 1)
go
insert Especialidad(Nombre, Estado) values('Otorrinolaringología', 1)
go
insert Especialidad(Nombre, Estado) values('Patología Clinica', 1)
go
insert Especialidad(Nombre, Estado) values('Pediatría', 1)
go
insert Especialidad(Nombre, Estado) values('Psiquiatría General', 1)
go
insert Especialidad(Nombre, Estado) values('Radiología e Imagen', 1)
go
insert Especialidad(Nombre, Estado) values('Radio-Oncólogía', 1)
go
insert Especialidad(Nombre, Estado) values('Urología', 1)
go

-----------------------------INSERT PACIENTES--------------------------------------------
insert Cobertura(Nombre, Estado)VALUES('OSDE', 1)
go
insert Cobertura(Nombre, Estado)VALUES('OSECAC', 1)
go
insert Cobertura(Nombre, Estado)VALUES('OSPATCA', 1)
go
insert Cobertura(Nombre, Estado)VALUES('OSDEPYM', 1)
go
insert Cobertura(Nombre, Estado)VALUES('OSPIAD', 1)
go
insert Cobertura(Nombre, Estado)VALUES('Particular', 1)
go
insert Cobertura(Nombre, Estado)VALUES('Unión Personal', 1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura, Estado)VALUES('123456', 'Jose', 'Argento', '753951', 'argentoJ@hotmail.com', 'Flores 1855', '10-05-1996',1,1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura, Estado)VALUES('123457', 'Erica', 'Rivas', '753952', 'rivasR@hotmail.com', 'Montes 1387', '23-05-1966',1,1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura, Estado)VALUES('123458', 'Marcelo', 'de Bellis', '753953', 'debellisM@hotmail.com', 'San Justo 503', '01-01-2000',2,1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura, Estado)VALUES('123459', 'Manuel', 'Wirtz', '753954', 'wirtzM@hotmail.com', 'Rojas 8088', '02-02-2010',2,1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura, Estado)VALUES('123450', 'Carla', 'Quevedo', '753955', 'quevedoC@hotmail.com', 'Rosset 99', '23-04-1988',3,1)
go
insert HistoriaClinica(IDPaciente, Descripcion, Fecha, Estado) VALUES (1, 'Síndrome de intestino irritable', '10-10-2021', 1)
GO
insert HistoriaClinica(IDPaciente, Descripcion, Fecha, Estado) VALUES (2, 'Síndrome de ovario poliquístico', '07-11-2021', 1)


---------------------insert Empleado----------------------------
------Tipo
go
insert into TipoEmpleado(Tipo) values('Médico')
go
insert into TipoEmpleado(Tipo) values('Administrador')
go
insert into TipoEmpleado(Tipo) values('Recepcionista')


go
INSERT EstadoTurno(Descripcion)VALUES('Programado')
go
INSERT EstadoTurno(Descripcion)VALUES('Cerrado')
go
INSERT EstadoTurno(Descripcion)VALUES('Reprogramado')
go
INSERT EstadoTurno(Descripcion)VALUES('Cancelado')
go
INSERT EstadoTurno(Descripcion)VALUES('No asistió')

-----------Medicos
go
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124578, 'Dante', 'Mastopierro', '784512', 'mastopierroD@hotmail.com','Av.Cordoba 1642','10-10-1981', 1,1)
go																						 
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124570, 'Franco', 'Tirri', '784510', 'tirriF@hotmail.com','Av.Rivadavia 5201','01-4-1991',1,1)
go																						  
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124571, 'Diego', 'Gomez','7845113', 'gomezD@hotmail.com','Calle de tierra 1500','06-6-1998',1,1)
go																						 
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124572, 'Rodrigo', 'De la Serna', '784513', 'delasarnaR@hotmail.com','Bolivia 5654','10-4-1988',1,1)
go																						
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124573, 'Doris', 'Blanca', '784514', 'blancaD@hotmail.com','P´sherman 42','07-05-1987',1,1)
go																						  
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124574, 'Ana', 'Celentano', '784515', 'celentanoA@hotmail.com','Riobamba 7812','05-11-1990',1,1)
go																						 
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124575, 'Sergio', 'Podeley', '784516', 'podeleyS@hotmail.com','Neyer 88','14-02-1971',1,1)
go																						  
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124576, 'Rosina', 'Soto', '784517', 'sotoR@hotmail.com','Av.Carabobo 3200','13-09-1986',1,1)
go																						 
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124577, 'Ariel', 'Staltari', '784518', 'staltariA@hotmail.com','Barrilete 6767','15-08-1979',1,1)
go																						 
insert Empleado(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado) VALUES(124579, 'Agusto', 'Britez', '784519', 'britezA@hotmail.com','Chile 2311','18-03-1993',1,1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(1,'11345', 1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(2,'12345',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(3,'26758',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(4,'48973',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(5,'90675',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(6,'34678',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(7,'87964',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(8,'37624',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(9,'87592',  1)
go
insert DatosMedico(ID,Matricula, Estado) VALUES(10,'98637', 1)
go
--usuarios medicos--------------
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(1, 'medico', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(2, 'ftirri', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(3, 'dgomez', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(4, 'rdelaserna', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(5, 'bdoris', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(6, 'acelentano', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(7, 'spodeley', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(8, 'rsoto', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(9, 'astaltari', '123medico', 1, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(10, 'abritez', '123medico', 1, 1)
go
--EspecialidadXMedico--------------------
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(1, 10,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(2, 10,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(2, 1, 1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(3, 3, 1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(4, 5, 1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(5, 13,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(6, 15,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(7, 14,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(8, 14,1)
go														   				  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(9, 5, 1)
go																		  
insert EspecialidadXMedico(IDMedico, IDEspecialidad, Estado) VALUES(10, 5,1)
go
--DiasHabiles---------------------------
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(1, 10, 1, '8:00', '12:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(1, 10, 2, '8:00', '12:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(1, 10, 4, '15:00', '19:00', 1)

go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(2, 10, 6, '13:00', '17:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(2, 10, 2, '9:00', '13:00', 1)

go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(2, 1, 3, '15:00', '19:00', 1)

go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(3, 3,  5, '16:00', '20:00', 1)

go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado) VALUES(4, 5, 1, '8:00', '12:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(5, 13, 1, '8:00', '12:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(6, 15, 5, '16:00', '20:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(7, 14, 5, '16:00', '20:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(8, 14, 6, '13:00', '17:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(9, 5, 6, '13:00', '17:00', 1)
go
INSERT DiasHabilesMedico (IDMedico, IDEspecialidad, IDDia, HorarioEntrada, HorarioSalida, Estado)	VALUES(10, 5, 6, '13:00', '17:00', 1)
go
----Administradores y recepcionistas															

insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(9999, 2, 'Maria', 'Ster', 535353, 'sterM@hotmail.com', 'Monte agudo 1742', '10-10-2002',1)
go
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(8888, 3, 'Roberto', 'Totora', 121212, 'robertototo@hotmail.com', 'Hernandez Hijo 4212', '14-12-1994',1)
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(7777, 3, 'Luna', 'Riveros', 456873, 'riverosL@hotmail.com', 'Sucre 2626', '08-2-2002',1)
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(4444, 3, 'Alicia', 'Becker', 124574, 'beckerA@hotmail.com', 'Vaporub 12', '05-06-1990',1)
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(5555, 3, 'Theodore Jasper', 'Detweiler', 976431, 'detweilerTJ@hotmail.com', 'AV.Siempre Viva 742', '13-06-1988',1)
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(1010, 2, 'Carla', 'Medina', 395864, 'medinaC@hotmail.com', 'Santa Maria de oro 2354', '13-10-1996',1)
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(1111, 2, 'Gregorio', 'Atlante', 895623, 'atlanteG@hotmail.com', 'Italia 44', '02-07-1998',1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(11, 'admin', '123admin', 2, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(12, 'recepcionista', '123recep', 3, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(13, 'lriveros', '123recep', 3, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(14, 'abecker', '123recep', 3, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(15, 'tjasper', '123recep', 3, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(16, 'cmedina', '123admin', 2, 1)
go
Insert into Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado)Values(17, 'gatlante', '123admin', 2, 1)

---TURNOS----------------------------------------------------------------
GO
INSERT Turno(IDPaciente,IDEspXMedico,Dia,Observaciones,IDRecepcionista,IDEstado,HoraInicio)VALUES(5,1,'12-12-2021','Dolor abdominal al estar parado mucho tiempo',3,1,'09:00')

