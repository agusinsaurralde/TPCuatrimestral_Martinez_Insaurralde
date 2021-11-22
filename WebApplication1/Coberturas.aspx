<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="WebApplication1.Formulario_web115" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Coberturas</h1>
    <body>
        <div>
            <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
            <asp:Button Text="Modificar" OnClick ="Click_Modificar" runat="server" />
            <asp:Button Text="Eliminar" OnClick ="Click_Eliminar" runat="server" />
        </div>
        <div>
            <table class="table">
             <tr>
                <td>ID</td> <td>Cobertura</td>
            </tr>
            <tr>
                <td>1</td> <td>OSDE</td> 
            </tr>
        </div>
    </body>
</asp:Content>
