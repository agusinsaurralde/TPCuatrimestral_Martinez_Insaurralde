<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Médicos</h3>
    <hr />
    <body>
        <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
            <asp:ListItem Text="Especialidad" />
            <asp:ListItem Text="Turno" />
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
                <td>DNI</td><td>Matrícula</td><td>Nombre y Apellido</td><td>Especialidad</td> <td>Turno</td><td>Horario</td><td>Teléfono</td> <td>E-mail</td> <td>Dirección</td>
            </tr>
            <tr>
                <td>22543696</td> <td>45768</td><td>Mónica Torres</td><td>Dermatología</td><td>Tarde</td><td>13 hs - 17 hs</td> <td>1128567344</td> <td>mtorres@gmail.com</td> <td>Hipolíto Yrigoyen 344</td>
            </tr>
        </table>
        </div>
    </body>
</asp:Content>
