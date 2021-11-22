<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplication1.Formulario_web117" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <h1>Usuarios</h1>

    <div>
        <asp:Button Text="Agregar" OnClick="Click_Agregar" runat="server" />
        <asp:Button Text="Modificar" OnClick="Click_Modificar" runat="server" />
        <asp:Button Text="Eliminar" OnClick="Click_Eliminar" runat="server" />

    </div>
    <div>
        <table class="table">
             <tr>
                <td>ID</td> <td>Nombre de Usuario</td> <td>Contraseña</td> <td>Tipo de Usuario</td> <td>Estado</td>
        </table>
        </div>
    </body>
</asp:Content>
