<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="WebApplication1.InicioAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <div> 
        <header>
            Vista de Administrador.
        </header> 
    </div>
    <div>
        <asp:Button id="btnAdministrarRecepcionistas" Text="Recepcionistas" runat="server" OnClick="btnAdministrarRecepcionistas_Click" />
        <asp:Button id="btnMedicos" Text="Medicos" runat="server"  OnClick="btnMedicos_Click"/>
        <asp:Button id="btnAdministradores" Text="Administradores" runat="server" OnClick="btnAdministradores_Click"/>
    </div>

</body>
</asp:Content>
