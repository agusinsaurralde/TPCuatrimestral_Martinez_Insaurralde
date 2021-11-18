<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosMedico.aspx.cs" Inherits="WebApplication1.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <h3>Turnos</h3>
    <hr />
    <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Agregar observación" onclick ="Click_AgregarObservacion" runat="server" />
    </div>
    <div>
         <table class="table table-hover">
            <tr>
                <td>Número</td> <td>Nombre y Apellido</td> <td>Dia</td> <td>Horario</td><td>Motivo de consulta</td><td>Estado</td><td>Observaciones</td>
            </tr>
             <tr>
                <td>1</td> <td>Martina Gutierrez</td>  <td>10/11/2021</td><td>10 hs</td><td>Chequeo</td><td>Reprogramado</td><td></td>
            </tr>
            <tr>
                 <td>2</td> <td>Ricardo López</td> <td>5/11/2021</td> <td>17 hs</td><td>Chequeo</td><td>Cancelado</td>

            </tr>
        </table>
    </div>
    </body>
</asp:Content>
