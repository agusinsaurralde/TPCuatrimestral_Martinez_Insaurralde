<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <h3>Ver Turnos</h3>
    <hr />
    <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="Número" />
            <asp:ListItem Text="Médico" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Modificar turno" OnClick="Click_ModificarTurno" runat="server" />
        
        <asp:Button Text="Agregar Observación" onclick ="Click_AgregarObservacion" runat="server" />
    </div>
    <div>
         <table class="table table-hover">
            <tr>
                <td>Número</td> <td>Nombre y Apellido</td> <td>Especialidad</td> <td>Médico</td> <td>Horario</td><td>Motivo de consulta</td><td>Estado</td><td>Observaciones</td>
            </tr>
             <tr>
                <td>1</td> <td>Martina Gutierrez</td> <td>Dermatología</td><td>Mónica Torres</td><td>10 hs</td><td>Chequeo</td><td>Reprogramado</td>
            </tr>
            <tr>
                 <td>2</td> <td>Ricardo López</td> <td>Cardiología</td><td>Hector Ramirez</td><td>17 hs</td><td>Chequeo</td><td>Cancelado</td>

            </tr>
        </table>
    </div>
    </body>
</asp:Content>
