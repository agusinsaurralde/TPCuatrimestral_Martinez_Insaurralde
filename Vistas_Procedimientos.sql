alter VIEW VW_TURNOS AS
select t.Numero, t.IDPaciente, p.Apellido as ApellidoPaciente, p.Nombre as NombrePaciente, e.ID as IDEspecialidad, e.Nombre AS Especialidad, exm.IDMedico, m.Apellido as ApellidoMedico, m.Nombre as NombreMedico, t.HoraInicio, t.HoraFin, t.Dia, t.Observaciones, t.IDRecepcionista, emp.Apellido as ApellidoRecepcionista, emp.Nombre as NombreRecepcionista,
t.IDEstado, est.Descripcion as Estado from turno as t
inner join EspecialidadXMedico as exm on exm.ID = t.IDEspXMedico
inner join Especialidad as e on e.ID = exm.IDEspecialidad
inner join Paciente as p on p.ID = t.IDPaciente
inner join Medico as m on m.ID = exm.IDMedico
inner join Empleado as emp on emp.ID = t.IDRecepcionista
inner join EstadoTurno as est on est.id = t.IDEstado


CREATE PROCEDURE SP_ASIGNARTURNO(
	@IDPaciente bigint, @IDEspecialidad bigint, @IDMedico bigint, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista bigint, @IDEstado bigint)
AS 
BEGIN
	DECLARE @IDEspXMed bigint
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	INSERT INTO Turno(IDPaciente, IDEspXMedico, Dia, Observaciones, IDRecepcionista, IDEstado, HoraInicio, HoraFin)
	VALUES(@IDPaciente, @IDEspXMed, @Dia, @Observaciones, @IDRecepcionista, @IDEstado, @HoraInicio, @HoraFin)
END

CREATE PROCEDURE SP_MODIFICARTURNO(
	@IDPaciente bigint, @IDEspecialidad bigint, @IDMedico bigint, @Dia date, @HoraInicio datetime, @HoraFin datetime, @Observaciones varchar(500), @IDRecepcionista bigint, @IDEstado bigint)
AS 
BEGIN
	DECLARE @IDEspXMed bigint
	Select @IDEspXMed = ID from EspecialidadXMedico where IDMedico = @IDMedico and IDEspecialidad = @IDEspecialidad
	UPDATE Turno SET IDPaciente = @IDPaciente, IDEspXMedico = @IDEspXMed, Dia = @Dia, Observaciones = @Observaciones, IDRecepcionista =  @IDRecepcionista, IDEstado = @IDEstado, HoraInicio = @HoraInicio, HoraFin = @HoraFin
END

SELECT * FROM Especialidad
SELECT * FROM Medico
SELECT * FROM EspecialidadXMedico
SELECT * FROM Paciente

--EXEC SP_ASIGNARTURNO 1, 23, 1, '2021/11/17', '7:00', '8:00', 'Dolor de estómago', 1, 1

