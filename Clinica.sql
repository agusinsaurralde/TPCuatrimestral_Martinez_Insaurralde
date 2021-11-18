use master
go
create database Clinica
go
use Clinica
go
create table TurnoTrabajo(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Turno VARCHAR(6) UNIQUE not null,
	CONSTRAINT CHK_Turno CHECK (Turno NOT LIKE '%[^A-Z]%')
)
go
create table Medico(
    ID int PRIMARY KEY not NULL IDENTITY(1,1),
    DNI VARCHAR(8) UNIQUE not null,
	Matricula VARCHAR(10) Unique not null,
    Nombre VARCHAR(50) not null,
    Apellido VARCHAR(50) not null,
    Telefono VARCHAR(15) not null,
    Email VARCHAR(320) UNIQUE not null,
    Direccion VARCHAR(320) not null,
    FechaNacimiento DATE not null,
    IDTurnoTrabajo int not null,
    HoraEntrada DATETIME not null,
    HoraSalida DATETIME not null,

	CONSTRAINT FK_IDTurnoTrabajo FOREIGN KEY (IDTurnoTrabajo) REFERENCES TurnoTrabajo(ID),
	CONSTRAINT CHK_DNIMedico CHECK (DNI NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_Matricula CHECK (Matricula NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_TelefonoMedico CHECK (Telefono NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_EmailMedico CHECK (Email LIKE '__%@__%.__%'),
	CONSTRAINT CHK_DireccionMedico CHECK (Direccion LIKE '[A-Z]%[0-9]'),
	CONSTRAINT CHK_FechaNacimiento CHECK (FechaNacimiento < GETDATE() AND FechaNacimiento > '1900-01-01')
)

go
create table Especialidad(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(50) UNIQUE not NULL,
)
GO
create table EspecialidadXMedico(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    IDEspecialidad int not null,
    IDMedico int not null,

	CONSTRAINT FK_IDMedico FOREIGN KEY (IDMedico) REFERENCES Medico(ID),
	CONSTRAINT FK_IDEspecialidad FOREIGN KEY (IDEspecialidad) REFERENCES Especialidad(ID)
)
GO
create table Cobertura(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(30) not null
)
go
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

	CONSTRAINT FK_IDCobertura FOREIGN KEY (Cobertura) REFERENCES Cobertura(ID),

	CONSTRAINT CHK_DNIPaciente CHECK (DNI NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_TelefonoPaciente CHECK (Telefono NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_EmailPaciente CHECK (Email LIKE '__%@__%.__%'),
	CONSTRAINT CHK_DireccionPaciente CHECK (Direccion LIKE '[A-Z]%[0-9]'),
	CONSTRAINT CHK_FechaNacimientoPaciente CHECK (FechaNacimiento < GETDATE() AND FechaNacimiento > '1900-01-01')
)

Alter table Paciente
add Estado bit;
GO
create table HistoriaClinica(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
	IDPaciente int not null,
	Fecha DATE not null,
    Descripcion VARCHAR(500) not null,

	CONSTRAINT FK_IDPacienteHC FOREIGN KEY (IDPaciente) REFERENCES Paciente(ID)
)
GO
create table TipoEmpleado(
    ID int PRIMARY key IDENTITY(1,1) not null,
    Tipo VARCHAR(14) not null,
)
GO
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

	CONSTRAINT FK_IDTipoEmpleado FOREIGN KEY (IDTipo) REFERENCES TipoEmpleado(ID),
	CONSTRAINT CHK_DNIEmpleado CHECK (DNI NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_TelefonoEmpleado CHECK (Telefono NOT LIKE '%[^0-9]%'),
	CONSTRAINT CHK_EmailEmpleado CHECK (Email LIKE '__%@__%.__%'),
	CONSTRAINT CHK_DireccionEmpleado CHECK (Direccion LIKE '[A-Z]%[0-9]'),
	CONSTRAINT CHK_FechaNacimientoEmpleado CHECK (FechaNacimiento < GETDATE() AND FechaNacimiento > '1900-01-01')
)
GO
Create table EstadoTurno(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Descripcion VARCHAR(20)
)
go
create table Turno(
    Numero int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IDPaciente int not null,
    IDEspXMedico int not null,
    Dia DATETIME not null,
    Observaciones VARCHAR(500) null,
    IDRecepcionista int not null,
    IDEstado int not null,
    HoraInicio DATETIME not NULL,
    HoraFin DATETIME not NULL

	CONSTRAINT FK_IDPacienteTURNO FOREIGN KEY (IDPaciente) REFERENCES Paciente(ID),
	CONSTRAINT FK_IDEspXMedico FOREIGN KEY (IDEspXMedico) REFERENCES EspecialidadXMedico(ID),
	CONSTRAINT FK_IDRecepcionista FOREIGN KEY (IDRecepcionista) REFERENCES Empleado(ID),
	CONSTRAINT FK_IDEstado FOREIGN KEY (IDEstado) REFERENCES EstadoTurno(ID),
	
	CONSTRAINT CHK_Dia CHECK (Dia >getdate()),
)
go  
create table TipoUsuario(
    ID int PRIMARY key IDENTITY(1,1) not null,
    Nombre VARCHAR (8) not null
)
GO
create table Usuario(
    ID int PRIMARY KEY not null,
    NombreUsuario VARCHAR(15) UNIQUE,
    Contraseña VARCHAR(15),
    IDTipo int

	CONSTRAINT FK_IDTipoUsuario FOREIGN KEY (IDTipo) REFERENCES TipoUsuario(ID),
	CONSTRAINT CHK_NombreUsuario CHECK(Contraseña NOT LIKE '%[|!"#$%&/()=?¡¿´¨*[]{}]%')
)

-----------Insert especialidades-------------------------
go
insert Especialidad(Nombre) values('Anestesiología')
go
insert Especialidad(Nombre) values('Anatomía Patológica')
go
insert Especialidad(Nombre) values('Cardiología')
go
insert Especialidad(Nombre) values('Cardiología Intervencionista')
go
insert Especialidad(Nombre) values('Cirugía Pediátrica')
go
insert Especialidad(Nombre) values('Cirugía General')
go
insert Especialidad(Nombre) values('Cirugía Plástica y Reconstructiva')
go
insert Especialidad(Nombre) values('Angiología y Cirugía Vascular')
go
insert Especialidad(Nombre) values('Dermatología')
go
insert Especialidad(Nombre) values('Endoscopía')
go
insert Especialidad(Nombre) values('Gastroenterología')
go
insert Especialidad(Nombre) values('Ginecología y Obstetricía')
go
insert Especialidad(Nombre) values('Hematología')
go
insert Especialidad(Nombre) values('Infectología')
go
insert Especialidad(Nombre) values('Medicina Aeroespacial')
go
insert Especialidad(Nombre) values('Medicina de Rehabilitación')
go
insert Especialidad(Nombre) values('Medicina Interna')
go
insert Especialidad(Nombre) values('Nefrología')
go
insert Especialidad(Nombre) values('Neurología')
go
insert Especialidad(Nombre) values('Neumonología')
go
insert Especialidad(Nombre) values('Oftalmología')
go
insert Especialidad(Nombre) values('Ortopedia')
go
insert Especialidad(Nombre) values('Otorrinolaringología')
go
insert Especialidad(Nombre) values('Patología Clinica')
go
insert Especialidad(Nombre) values('Pediatría')
go
insert Especialidad(Nombre) values('Psiquiatría General')
go
insert Especialidad(Nombre) values('Radiología e Imagen')
go
insert Especialidad(Nombre) values('Medicina del Enfermo en Estado Crítico')
go
insert Especialidad(Nombre) values('Urología')
go
insert Especialidad(Nombre) values('Cirugía Oncólogica')
go
insert Especialidad(Nombre) values('Oncólogía Medica')
go
insert Especialidad(Nombre) values('Oncólogía Pediátrica')
go
insert Especialidad(Nombre) values('Radio-Oncólogía')

---------------------INSERT MEDICOS--------------------------------------
--set dateformat 'dmy'

INSERT TurnoTrabajo(Turno)VALUES('Mañana')
go
INSERT TurnoTrabajo(Turno)VALUES('Tarde')
go
INSERT TurnoTrabajo(Turno)VALUES('Noche')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124578, 'Dante', 'Mastopierro', 784512, 'mastopierroD@hotmail.com','Av.Cordoba 1642','10-10-1981','11345', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124570, 'Franco', 'Tirri', 784510, 'tirriF@hotmail.com','Av.Rivadavia 5201','01-4-1991','12345', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124571, 'Diego', 'Gomez', 784511, 'gomezD@hotmail.com','Calle de tierra 1500','06-6-1998','26758', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124572, 'Rodrigo', 'De la sarna', 784513, 'delasarnaR@hotmail.com','Bolivia 5654','10-4-1988','48973', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124573, 'Doris', 'Blanca', 784514, 'blancaD@hotmail.com','P´sherman 42','07-05-1987','90675', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124574, 'Ana', 'Celentano', 784515, 'celentanoA@hotmail.com','Riobamba 7812','05-11-1990','34678', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124575, 'Sergio', 'Podeley', 784516, 'podeleyS@hotmail.com','Neyer 88','14-02-1971','87964', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124576, 'Rosina', 'Soto', 784517, 'sotoR@hotmail.com','Av.Carabobo 3200','13-09-1986','37624', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124577, 'Ariel', 'Staltari', 784518, 'staltariA@hotmail.com','Barrilete 6767','15-08-1979','87592', 3, '23:00', '07:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124579, 'Agusto', 'Britez', 784519, 'britezA@hotmail.com','Chile 2311','18-03-1993','98637', 3, '23:00', '07:00')

-----------------------------INSERT PACIENTES--------------------------------------------
insert Cobertura(Nombre)VALUES('Royalcanin')
go
insert Cobertura(Nombre)VALUES('Purina')
go
insert Cobertura(Nombre)VALUES('Infinity')
go
insert Cobertura(Nombre)VALUES('Whiskas')
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura)VALUES(123456, 'Jose', 'Argento', 753951, 'argentoJ@hotmail.com', 'Flores 1855', '10-05-1996',1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura)VALUES(123457, 'Erica', 'Rivas', 753952, 'rivasR@hotmail.com', 'Montes 1387', '23-05-1966',1)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura)VALUES(123458, 'Marcelo', 'de Bellis', 753953, 'debellisM@hotmail.com', 'San Justo 503', '01-01-2000',2)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura)VALUES(123459, 'Manuel', 'Wirtz', 753954, 'wirtzM@hotmail.com', 'Rojas 8088', '02-02-2010',2)
go
insert Paciente(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Cobertura)VALUES(123450, 'Carla', 'Quevedo', 753955, 'quevedoC@hotmail.com', 'Rosset 99', '23-04-1988',3)
go
UPDATE Paciente SET Estado = 1 WHERE DNI = 123450
select * from Paciente
---------------------insert Estado----------------------------
INSERT EstadoTurno(Descripcion)VALUES('Programado')
INSERT EstadoTurno(Descripcion)VALUES('Cerrado')
INSERT EstadoTurno(Descripcion)VALUES('Reprogramado')
INSERT EstadoTurno(Descripcion)VALUES('Cancelado')
INSERT EstadoTurno(Descripcion)VALUES('No asistió')
---------------------insert Empleado----------------------------

INSERT TipoEmpleado(Tipo)VALUES('Administrativo')
GO
INSERT TipoEmpleado(Tipo)VALUES('Recepcionista')
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(9999, 1, 'Maria', 'Ster', 535353, 'sterM@hotmail.com', 'Monte agudo 1742', '10-10-2002')
go
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(8888, 1, 'Roberto', 'Totora', 121212, 'robertototo@hotmail.com', 'Hernandez Hijo 4212', '14-12-1994')
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(7777, 1, 'Luna', 'Riveros', 456873, 'riverosL@hotmail.com', 'Sucre 2626', '08-2-2002')
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(4444, 1, 'Alicia', 'Becker', 124574, 'beckerA@hotmail.com', 'Vaporub 12', '05-06-1990')
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(5555, 1, 'Theodore Jasper', 'Detweiler', 976431, 'detweilerTJ@hotmail.com', 'AV.Siempre Viva 742', '13-06-1988')
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(1010, 2, 'Carla', 'Medina', 395864, 'medinaC@hotmail.com', 'Santa Maria de oro 2354', '13-10-1996')
GO
insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento)VALUES(1111, 2, 'Gregorio', 'Atlante', 895623, 'atlanteG@hotmail.com', 'Italia 44', '02-07-1998')
go
INSERT EspecialidadXMedico(IDEspecialidad,IDMedico)VALUES(23,1)
GO
INSERT EspecialidadXMedico(IDEspecialidad,IDMedico)VALUES(2,2)
GO
INSERT EspecialidadXMedico(IDEspecialidad,IDMedico)VALUES(1,9)
GO
INSERT EspecialidadXMedico(IDEspecialidad,IDMedico)VALUES(20,7)
GO
INSERT EspecialidadXMedico(IDEspecialidad,IDMedico)VALUES(6,8)
GO
INSERT Turno(IDPaciente,IDEspXMedico,Dia,Observaciones,IDRecepcionista,IDEstado,HoraInicio,HoraFin)VALUES(5,2,'01-01-2022','Dolor abdominal al estar parado mucho tiempo',3,1,'09:00', '10:00')
select * from EstadoTurno

--CONSULTA TURNO
CREATE VIEW VW_TURNO AS
	SELECT T.Numero AS NUMERO, P.Apellido AS APELLIDOPACIENTE, P.Nombre AS NOMBREPACIENTE, E.Nombre AS ESPECIALIDAD, M.Apellido AS APELLIDOMEDICO, M.Nombre AS NOMBREMEDICO, 
	T.HoraInicio AS HORAINICIO, T.HoraFin AS HORAFIN, T.Dia AS DIA, 
	T.OBSERVACIONES AS OBSERVACIONES,EMP.Apellido AS APELLIDORECEPCIONISTA, EMP.Nombre AS NOMBRERECEPCIONISTA, ET.Descripcion AS ESTADO from Turno AS T 
	INNER JOIN Paciente AS P ON T.IDPaciente = P.ID
	INNER JOIN EspecialidadXMedico AS EXM ON EXM.ID = T.IDEspXMedico
	INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad
	INNER JOIN Medico AS M ON M.ID = EXM.IDMedico 
	INNER JOIN Empleado AS EMP ON EMP.ID = T.IDRecepcionista
	INNER JOIN EstadoTurno AS ET ON ET.ID = T.IDEstado

SELECT * FROM VW_TURNO


