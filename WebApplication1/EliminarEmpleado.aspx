<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarEmpleado.aspx.cs" Inherits="WebApplication1.EliminarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>¿Está seguro que desea eliminar al empleado '<asp:Label Text="text" ID="txtNombre" runat="server" />'?</h3>
        <asp:Button Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
        <asp:Button Text="Cancelar" OnClick="Click_Cancelar" runat="server" />
</asp:Content>
