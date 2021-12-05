use master
use Clinica
go
---Turnos
CREATE VIEW VW_TURNOS AS
select t.Numero, t.IDPaciente, p.Apellido as ApellidoPaciente, p.Nombre as NombrePaciente, e.ID as IDEspecialidad, e.Nombre AS Especialidad, exm.IDMedico as IDMedico, med.Apellido as ApellidoMedico, med.Nombre as NombreMedico, t.HoraInicio, t.HoraFin, t.Dia, t.Observaciones, t.IDRecepcionista, emp.Apellido as ApellidoRecepcionista, emp.Nombre as NombreRecepcionista,
t.IDEstado, est.Descripcion as Estado from turno as t
inner join EspecialidadXMedico as exm on exm.ID = t.IDEspXMedico
inner join Especialidad as e on e.ID = exm.IDEspecialidad
inner join Empleado as med on med.ID = exm.IDMedico
inner join Paciente as p on p.ID = t.IDPaciente
inner join Empleado as emp on emp.ID = t.IDRecepcionista
inner join EstadoTurno as est on est.id = t.IDEstado
go

CREATE PROCEDURE SP_ASIGNARTURNO(
	@IDPaciente int, @IDEspecialidad int, @IDMedico int, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista int, @IDEstado int)
AS 
BEGIN
	DECLARE @IDEspXMed int
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	INSERT INTO Turno(IDPaciente, IDEspXMedico, Dia, Observaciones, IDRecepcionista, IDEstado, HoraInicio, HoraFin)
	VALUES(@IDPaciente, @IDEspXMed, @Dia, @Observaciones, @IDRecepcionista, @IDEstado, @HoraInicio, @HoraFin)
END

go
CREATE PROCEDURE SP_MODIFICARTURNO(
	@IDPaciente int, @IDEspecialidad int, @IDMedico int, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista int, @IDEstado int, @Numero INT)
AS 
BEGIN
	DECLARE @IDEspXMed bigint
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	UPDATE Turno SET IDPaciente = @IDPaciente, IDEspXMedico = @IDEspXMed, Dia = @Dia, Observaciones = @Observaciones, IDRecepcionista =  @IDRecepcionista, IDEstado = @IDEstado, HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE Numero = @Numero
END
GO


---Medicos


/*CREATE VIEW VW_MEDICO AS 
SELECT E.ID, E.DNI, E.Nombre, E.Apellido, D.Matricula, DH.IDTurnoTrabajo, T.Turno,DH.HorarioEntrada, DH.HorarioSalida, E.Direccion, E.FechaNacimiento, E.Telefono, E.Email, E.Estado FROM Empleado AS E 
INNER JOIN DatosMedico AS D ON D.ID = E.ID
INNER JOIN DiasHabilesMedico AS DH ON DH.ID = E.ID
INNER JOIN TurnoTrabajo AS T ON T.ID = DH.IDTurnoTrabajo
WHERE E.IDTipo = 1*/

CREATE VIEW VW_MEDICO AS 
SELECT E.ID, E.DNI, E.Nombre, E.Apellido, D.Matricula, E.Direccion, E.FechaNacimiento, E.Telefono, E.Email, E.Estado FROM Empleado AS E 
INNER JOIN DatosMedico AS D ON D.ID = E.ID
WHERE E.IDTipo = 1


GO
CREATE PROCEDURE SP_AGREGARMEDICO(
	@DNI VARCHAR(8), @Matricula VARCHAR(10), @Apellido varchar(50), @Nombre varchar(50), @Telefono varchar(15), @Email varchar(320), @Direccion varchar(320), @FechaNacimiento date)
AS 
BEGIN
	INSERT Empleado(DNI, Apellido, Nombre, Telefono, Email, Direccion, FechaNacimiento, Estado)
	VALUES(@DNI, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento, 1)

	DECLARE @IDMedico int
	SELECT @IDMedico = @@IDENTITY
	INSERT DatosMedico(ID, Matricula, Estado)VALUES(@IDMedico, @Matricula, 1)
END

GO
CREATE PROCEDURE SP_MODIFICARMEDICO(
	@ID int, @DNI varchar(8), @Matricula varchar(10), @Apellido varchar(50), @Nombre varchar(50), @Telefono varchar(15), @Email varchar(320), @Direccion varchar(320), @FechaNacimiento date)
AS 
BEGIN
	UPDATE Empleado SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento WHERE ID = @ID
	UPDATE DatosMedico SET Matricula = @Matricula

END

GO
CREATE PROCEDURE SP_ELIMINARMEDICO(
	@ID int
)
AS
BEGIN
	UPDATE DatosMedico SET Estado = 0 WHERE ID = @ID
	UPDATE Empleado SET Estado = 0 WHERE ID = @ID
	UPDATE EspecialidadXMedico SET ESTADO = 0 WHERE IDMedico = @ID
END

select * from EspecialidadXMedico
SELECT IDEspecialidad, IDMedico, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, IDTurnoTrabajo, T.Turno, HorarioEntrada, HorarioSalida, Estado FROM EspecialidadXMedico AS EXM 
INNER JOIN TurnoTrabajo AS T ON T.ID = EXM.IDTurnoTrabajo