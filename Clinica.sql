use master
go
create database Clinica
go
use Clinica
go
create table Medico(
    ID int PRIMARY KEY not NULL IDENTITY(1,1),
    DNI int UNIQUE,
    Nombre VARCHAR(30),
    Apellido VARCHAR(30),
    Telefono int,
    Email VARCHAR(30) UNIQUE,
    Direccion VARCHAR(30),
    FechaNacimiento DATE,
    Matricula VARCHAR(30) Unique,
    IDTurnoTrabajo int,
    HoraEntrada DATETIME,
    HoraSalida DATETIME
)
go
create table Paciente(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    DNI int UNIQUE,
    Nombre VARCHAR(30),
    Apellido VARCHAR(30),
    Telefono int,
    Email VARCHAR(30) UNIQUE,
    Direccion VARCHAR(30),
    FechaNacimiento DATE,
    Cobertura int
)
GO
create table Empleado(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    DNI int UNIQUE,
    Nombre VARCHAR(30),
    Apellido VARCHAR(30),
    Telefono int,
    Email VARCHAR(30) UNIQUE,
    Direccion VARCHAR(30),
    FechaNacimiento DATE,
    IDTipo int
)
go
create table Turno(
    Numero int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IDPaciente int,
    IDEspXMedico int,
    Dia DATETIME not null CHECK(Dia>=getdate()),
    Observaciones VARCHAR(250) null,
    IDRecepcionista int,
    Estado bit not null default 1,
    HoraInicio DATETIME not NULL,
    HoraFin DATETIME not NULL
)
go
create table Especialidad(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(20) UNIQUE not NULL
)
GO
create table EspecialidadXMedico(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    IDEspecialidad int not null,
    IDMedico int not null
)
go
create table TurnoTrabajo(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Turno VARCHAR(13)
)
GO
Create table EstadoTurno(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Descripción VARCHAR(250)
)
GO
create table HistoriaClinica(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Descripción VARCHAR(250),
    IDPaciente int
)
GO
create table Cobertura(
    ID int PRIMARY KEY IDENTITY(1,1) not null,
    Nombre VARCHAR(30)
)
GO
create table Usuario(
    ID int PRIMARY KEY not null,
    NombreUsuario VARCHAR(13),
    contraseña VARCHAR(13),
    IDTipo int
)
go  
create table TipoUsuario(
    IDTipo int PRIMARY key IDENTITY(1,1) not null,
    Nombre VARCHAR (30) not null
)
GO
create table TipoEmpleado(
    ID int PRIMARY key IDENTITY(1,1) not null,
    Tipo VARCHAR(30)
)
--------------------------------------------
ALTER TABLE Medico
ADD CONSTRAINT FK_TurnoTrabajoID FOREIGN KEY (IDTurnoTrabajo)
REFERENCES TurnoTrabajo (ID)
GO
ALTER TABLE Paciente
ADD CONSTRAINT FK_Cobertura FOREIGN KEY (Cobertura)
REFERENCES Cobertura (ID)
GO
ALTER TABLE Turno
ADD CONSTRAINT FK_IDPaciente FOREIGN KEY (IDPaciente)
REFERENCES Paciente (ID)
GO
ALTER TABLE Empleado
ADD CONSTRAINT FK_IDTipo FOREIGN KEY (IDTipo)
REFERENCES TipoEmpleado (ID)
GO
ALTER TABLE Turno
ADD CONSTRAINT FK_IDEspXMedico FOREIGN KEY (IDEspXMedico)
REFERENCES EspecialidadXMedico (ID)
GO
ALTER TABLE Turno
ADD CONSTRAINT FK_IDRecepcionista FOREIGN KEY (IDRecepcionista)
REFERENCES Empleado (ID)
GO
ALTER TABLE EspecialidadXMedico
ADD CONSTRAINT FK_IDEspecialidad FOREIGN KEY (IDEspecialidad)
REFERENCES Especialidad (ID)
GO
ALTER TABLE EspecialidadXMedico
ADD CONSTRAINT FK_IDMedico FOREIGN KEY (IDMedico)
REFERENCES Medico (id)
GO
ALTER TABLE HistoriaClinica
ADD CONSTRAINT FK_IDPaciente FOREIGN KEY (IDPaciente)
REFERENCES Paciente (ID)
GO
ALTER TABLE Usuario
ADD CONSTRAINT FK_ID FOREIGN KEY (ID)
REFERENCES Empleado (ID)
GO
ALTER TABLE Usuario
ADD CONSTRAINT FK_IDTipo FOREIGN KEY (IDTipo)
REFERENCES TipoUsuario (ID)
-----------Insert especialidades-------------------------
go
insert Especialidad(Nombre) values('Anestesiologia')
go
insert Especialidad(Nombre) values('Anatomía Patologica')
go
insert Especialidad(Nombre) values('Cardiología')
go
insert Especialidad(Nombre) values('Cardiología Intervencionista')
go
insert Especialidad(Nombre) values('Cirugía Pediatrica')
go
insert Especialidad(Nombre) values('Cirugía General')
go
insert Especialidad(Nombre) values('Cirugía Plástica y Reconstructiva')
go
insert Especialidad(Nombre) values('Angiologia y Cirugía Vascular')
go
insert Especialidad(Nombre) values('Dermatología')
go
insert Especialidad(Nombre) values('Endoscopía')
go
insert Especialidad(Nombre) values('Gastroenterología')
go
insert Especialidad(Nombre) values('Ginegología y Obstetricía')
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
insert Especialidad(Nombre) values('Neumología')
go
insert Especialidad(Nombre) values('Oftalmología')
go
insert Especialidad(Nombre) values('Ortopedia')
go
insert Especialidad(Nombre) values('Otorrinolaringología')
go
insert Especialidad(Nombre) values('Patología Clinica')
go
insert Especialidad(Nombre) values('Pediatria')
go
insert Especialidad(Nombre) values('Psiquiatria General')
go
insert Especialidad(Nombre) values('Radiología e Imagen')
go
insert Especialidad(Nombre) values('Medicina del Enfermo en Estado Critico')
go
insert Especialidad(Nombre) values('Urología')
go
insert Especialidad(Nombre) values('Cardiología Intervencionista')
go
insert Especialidad(Nombre) values('Neumología')
go
insert Especialidad(Nombre) values('Hematología')
go
insert Especialidad(Nombre) values('Cirugía Oncólogica')
go
insert Especialidad(Nombre) values('Oncólogía Medica')
go
insert Especialidad(Nombre) values('Oncólogía Pediatrica')
go
insert Especialidad(Nombre) values('Radio-Oncólogía')
go
insert Especialidad(Nombre) values('Otorrinolaringología')
---------------------INSERT MEDICOS--------------------------------------
--set dateformat 'dmy'

INSERT TurnoTrabajo(Turno)VALUES('Mañana')
go
INSERT TurnoTrabajo(Turno)VALUES('Tarde')
go
INSERT TurnoTrabajo(Turno)VALUES('Noche')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124578, 'Dante', 'Mastopierro', 784512, 'mastopierroD@hotmail.com','Av.Cordoba 1642','10-10-1981','a1s2d3f4', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124570, 'Franco', 'Tirri', 784510, 'tirriF@hotmail.com','Av.Rivadavia 5201','01-4-1991','q4w5e6r7', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124571, 'Diego', 'Gomez', 784511, 'gomezD@hotmail.com','Calle de tierra 1500','06-6-1998','t7y8u9i1', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124572, 'Rodrigo', 'De la sarna', 784513, 'delasarnaR@hotmail.com','Bolivia 5654','10-4-1988','z9x8c7v4', 1, '07:00', '15:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124573, 'Doris', 'Blanca', 784514, 'blancaD@hotmail.com','P´sherman 42','07-05-1987','v6b5n4m1', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124574, 'Ana', 'Celentano', 784515, 'celentanoA@hotmail.com','Riobamba 7812','05-11-1990','p1o4i7u2', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124575, 'Sergio', 'Podeley', 784516, 'podeleyS@hotmail.com','Neyer 88','14-02-1971','g2h5j8k3', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124576, 'Rosina', 'Soto', 784517, 'sotoR@hotmail.com','Av.Carabobo 3200','13-09-1986','h3j6k9l8', 2, '15:00', '23:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124577, 'Ariel', 'Staltari', 784518, 'staltariA@hotmail.com','Barrilete 6767','15-08-1979','q6s5e4r2', 3, '23:00', '07:00')
go
insert Medico(DNI, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Matricula, IDTurnoTrabajo, HoraEntrada, HoraSalida) VALUES(124579, 'Agusto', 'Britez', 784519, 'britezA@hotmail.com','Chile 2311','18-03-1993','z3e2c1t4', 3, '23:00', '07:00')

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
INSERT Turno(IDPaciente,IDEspXMedico,Dia,Observaciones,IDRecepcionista,Estado,HoraInicio,HoraFin)VALUES(12,2,'01-01-2022','Dolor abdominal al estar parado mucho tiempo',3,1,'09:00', '10:00')
select * from EstadoTurno