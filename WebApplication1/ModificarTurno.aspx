<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h3>Modificar turno</h3>
        <hr />
        <div>
             <asp:TextBox runat="server" text="Ricardo" />
        </div>
       <div>
             <asp:TextBox runat="server" text="López" />
        </div>
        <div>
            <asp:DropDownList runat="server">
                <asp:ListItem Text="Cardiología" />
                <asp:ListItem Text="Odontología" />
                <asp:ListItem Text="Pediatría" />
            </asp:DropDownList>
            <asp:DropDownList runat="server">
                <asp:ListItem Text="Seleccionar criterio" />
                <asp:ListItem Text="Horario" />
                <asp:ListItem Text="Médico" />
            </asp:DropDownList>
            <asp:TextBox runat="server" />
            <asp:Button Text="Buscar" runat="server" />
        </div>
        <div>
            <table class="table table-hover">
           <tr class="info">
               <td>Hector Ramirez</td>
                <td>17 hs</td><td>17:30 hs</td><td>18 hs</td>
           </tr>
            <tr>
                <td>Victoria Espinoza</td>
                <td>14 hs</td><td>14:30 hs</td><td>15 hs</td>
            </tr>
             <tr>
                <td>Mónica Torres</td>
                <td>10 hs</td><td>10:30 hs</td><td>11 hs</td>
            </tr>

            </table>
            <div>
                <asp:TextBox runat="server" text="Chequeo" />
            </div>
            <div>
                <asp:DropDownList runat="server">
                    <asp:ListItem Text="Cancelado" />
                    <asp:ListItem Text="Reprogramado" />
                     <asp:ListItem Text="Nuevo" />
                     <asp:ListItem Text="No asistió" />
                     <asp:ListItem Text="Cerrado" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button Text="Aceptar" onclick="Click_Aceptar" runat ="server" /></div>
        </div>
    </body>
</asp:Content>
