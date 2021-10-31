use master
go
create database Clinica
go
use Clinica
go
CREATE TABLE Especialidad(
    Codigo int primary key IDENTITY(1,1) not null,
    Nombre varchar(50) not null UNIQUE
)
go
insert Especialidad(Nombre) values('Anestesiologia')
go
insert Especialidad(Nombre) values('Anatomía Patologica')
go
insert Especialidad(Nombre) values('Cardiologia')
go
insert Especialidad(Nombre) values('Cardiologia Intervencionista')
go
insert Especialidad(Nombre) values('Cirugia Pediatrica')
go
insert Especialidad(Nombre) values('Cirugia General')
go
insert Especialidad(Nombre) values('Cirugia Plástica y Reconstructiva')
go
insert Especialidad(Nombre) values('Angiologia y Cirugia Vascular')
go
insert Especialidad(Nombre) values('Dermatologia')
go
insert Especialidad(Nombre) values('Endoscopia')
go
insert Especialidad(Nombre) values('Gastroenterologia')
go
insert Especialidad(Nombre) values('Ginegologia y Obstetricia')
go
insert Especialidad(Nombre) values('Hematologia')
go
insert Especialidad(Nombre) values('Infectologia')
go
insert Especialidad(Nombre) values('Medicina Aeroespacial')
go
insert Especialidad(Nombre) values('Medicina de Rehabilitacion')
go
insert Especialidad(Nombre) values('Medicina Interna')
go
insert Especialidad(Nombre) values('Nefrologia')
go
insert Especialidad(Nombre) values('Neurologia')
go
insert Especialidad(Nombre) values('Neumologia')
go
insert Especialidad(Nombre) values('Oftalmologia')
go
insert Especialidad(Nombre) values('Ortopedia')
go
insert Especialidad(Nombre) values('Otorrinolaringologia')
go
insert Especialidad(Nombre) values('Patología Clinica')
go
insert Especialidad(Nombre) values('Pediatria')
go
insert Especialidad(Nombre) values('Psiquiatria General')
go
insert Especialidad(Nombre) values('Radiologia e Imagen')
go
insert Especialidad(Nombre) values('Medicina del Enfermo en Estado Critico')
go
insert Especialidad(Nombre) values('Urologia')
go
insert Especialidad(Nombre) values('Cardiologia Intervencionista')
go
insert Especialidad(Nombre) values('Neumologia')
go
insert Especialidad(Nombre) values('Hematologia')
go
insert Especialidad(Nombre) values('Cirugia Oncologica')
go
insert Especialidad(Nombre) values('Oncologia Medica')
go
insert Especialidad(Nombre) values('Oncologia Pediatrica')
go
insert Especialidad(Nombre) values('Radio-Oncologia')
go
insert Especialidad(Nombre) values('otorrinolaringologia')