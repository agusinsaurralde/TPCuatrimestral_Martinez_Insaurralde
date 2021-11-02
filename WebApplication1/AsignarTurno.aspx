<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <div>
             <asp:TextBox runat="server" placeholder="Nombre" />
        </div>
       <div>
             <asp:TextBox runat="server" placeholder="Apellido" />
        </div>
        <div>
            <asp:DropDownList runat="server" placeholder="Especialidad">
                <asp:ListItem Text="Seleccionar especialidad" />
                <asp:ListItem Text="Odontología" />
                <asp:ListItem Text="Pediatría" />
            </asp:DropDownList>
        </div>
        <div>
            <table class="table table-hover">
            <tr>
                <td>Victoria Espinoza</td>
                <td>14 hs</td><td>14:30 hs</td><td>15 hs</td>
            </tr>
             <tr>
                <td>Mónica Torres</td>
                <td>10 hs</td><td>10:30 hs</td><td>11 hs</td>
            </tr>
            <tr>
                <td>Hector Ramirez</td>
                <td>17 hs</td><td>17:30 hs</td><td>18 hs</td>
            </tr>
            </table>
            <div>
                <asp:TextBox runat="server" placeholder="Observaciones" />
            </div>
            <div>
                <asp:Button Text="Aceptar" runat="server" /></div>
        </div>
    </body>
</asp:Content>
