<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Pacientes</h3>
    <hr />
    <body>
        <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
        <asp:Button Text="Modificar" OnClick ="Click_Modificar" runat="server" />
        <asp:Button Text="Eliminar" OnClick ="Click_Eliminar" runat="server" />
    </div>
        <div>
        <table class="table">
             <tr>
                <td>DNI</td> <td>Nombre y Apellido</td> <td>Teléfono</td> <td>E-mail</td> <td>Dirección</td><td>Cobertura</td><td>Fecha de nacimiento</td>
            </tr>
            <tr>
                <td>22543697</td> <td>Ricardo López</td> <td>1128567349</td> <td>rlopez@gmail.com</td> <td>Hipolíto Yrigoyen 345</td><td>OSDE</td><td>14/08/1971</td>
            </tr>
        </table>
        </div>
    </body>
</asp:Content>
