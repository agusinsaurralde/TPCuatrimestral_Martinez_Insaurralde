use master
use Clinica
go
alter VIEW VW_TURNOS AS
select t.Numero, t.IDPaciente, p.Apellido as ApellidoPaciente, p.Nombre as NombrePaciente, e.ID as IDEspecialidad, e.Nombre AS Especialidad, exm.IDMedico, m.Apellido as ApellidoMedico, m.Nombre as NombreMedico, t.HoraInicio, t.HoraFin, t.Dia, t.Observaciones, t.IDRecepcionista, emp.Apellido as ApellidoRecepcionista, emp.Nombre as NombreRecepcionista,
t.IDEstado, est.Descripcion as Estado from turno as t
inner join EspecialidadXMedico as exm on exm.ID = t.IDEspXMedico
inner join Especialidad as e on e.ID = exm.IDEspecialidad
inner join Paciente as p on p.ID = t.IDPaciente
inner join Medico as m on m.ID = exm.IDMedico
inner join Empleado as emp on emp.ID = t.IDRecepcionista
inner join EstadoTurno as est on est.id = t.IDEstado
go

CREATE PROCEDURE SP_ASIGNARTURNO(
	@IDPaciente bigint, @IDEspecialidad bigint, @IDMedico bigint, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista bigint, @IDEstado bigint)
AS 
BEGIN
	DECLARE @IDEspXMed bigint
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	INSERT INTO Turno(IDPaciente, IDEspXMedico, Dia, Observaciones, IDRecepcionista, IDEstado, HoraInicio, HoraFin)
	VALUES(@IDPaciente, @IDEspXMed, @Dia, @Observaciones, @IDRecepcionista, @IDEstado, @HoraInicio, @HoraFin)
END

go
ALTER PROCEDURE SP_MODIFICARTURNO(
	@IDPaciente bigint, @IDEspecialidad bigint, @IDMedico bigint, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista bigint, @IDEstado bigint, @Numero BIGINT)
AS 
BEGIN
	DECLARE @IDEspXMed bigint
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	UPDATE Turno SET IDPaciente = @IDPaciente, IDEspXMedico = @IDEspXMed, Dia = @Dia, Observaciones = @Observaciones, IDRecepcionista =  @IDRecepcionista, IDEstado = @IDEstado, HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE Numero = @Numero
END

ALTER PROCEDURE SP_AGREGARMEDICO(
	@DNI bigint, @Matricula bigint, @Apellido varchar(50), @Nombre varchar(50), @IDEspecialidad bigint, @Telefono varchar(15), @Email varchar(320), @Direccion varchar(320), @FechaNacimiento date, 
	@IDTurnoTrabajo bigint, @HoraEntrada datetime, @HoraSalida datetime, @Estado bit)
AS 
BEGIN
	INSERT Medico(DNI, Matricula, Apellido, Nombre, Telefono, Email, Direccion, FechaNacimiento, IDTurnoTrabajo, HoraEntrada, HoraSalida, Estado)
	VALUES(@DNI, @Matricula, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida, @Estado)

	DECLARE @IDMedico bigint
	SELECT @IDMedico = @@IDENTITY
	INSERT EspecialidadXMedico(IDEspecialidad, IDMedico, Estado) VALUES (@IDEspecialidad, @IDMedico, 1)
END

EXEC SP_AGREGARMEDICO @DNI, @Matricula, @Apellido, @Nombre, @IDEspecialidad, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida, @Estado


CREATE PROCEDURE SP_MODIFICARMEDICO(
	@ID bigint, @DNI bigint, @Matricula bigint, @Apellido varchar(50), @Nombre varchar(50), @IDEspecialidad bigint, @Telefono varchar(15), @Email varchar(320), @Direccion varchar(320), @FechaNacimiento date, 
	@IDTurnoTrabajo bigint, @HoraEntrada datetime, @HoraSalida datetime, @Estado bit)
AS 
BEGIN
	UPDATE Medico SET DNI = @DNI, Matricula = @Matricula, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, 
	IDTurnoTrabajo = @IDTurnoTrabajo, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida, Estado = @Estado WHERE ID = @ID

	UPDATE EspecialidadXMedico SET IDEspecialidad = @IDEspecialidad WHERE IDMedico = @ID
END

EXEC SP_MODIFICARMEDICO @ID, @DNI, @Matricula, @Apellido, @Nombre, @IDEspecialidad, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida, @Estado

CREATE PROCEDURE SP_ELIMINARMEDICO(
	@ID bigint
)
AS
BEGIN
	UPDATE Medico SET Estado = 0 WHERE ID = @ID
	UPDATE EspecialidadXMedico SET ESTADO = 0 WHERE IDMedico = @ID
END



SELECT * FROM Especialidad
SELECT * FROM Medico
SELECT * FROM EspecialidadXMedico
SELECT * FROM Turno
SELECT * FROM TurnoTrabajo

--EXEC SP_ASIGNARTURNO 1, 23, 1, '2021/11/17', '7:00', '8:00', 'Dolor de est�mago', 1, 1

