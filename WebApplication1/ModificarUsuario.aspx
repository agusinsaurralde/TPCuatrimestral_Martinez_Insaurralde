<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="WebApplication1.Formulario_web23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h1>Modificar Usuario Usuario</h1>
        <hr />
        <div>
            <asp:Label Text="Nombre de Usuario" runat="server" />
            <asp:TextBox runat="server" />
            <asp:Label Text="Contraseña" runat="server" />
            <asp:TextBox runat="server" />
            <asp:Label Text="Tipo de Usuario" runat="server" />
            <asp:DropDownList runat="server">
                <asp:ListItem Text="Médico" />
                <asp:ListItem Text="Administrador" />
                <asp:ListItem Text="Recepcionista" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button Text="Aceptar" runat="server" />
        </div>
    </body> 
</asp:Content>
