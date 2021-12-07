<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleEmpleados.aspx.cs" Inherits="WebApplication1.DetalleEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3> Usuario</h3>
      <hr />
    <div><label>Nombre de Usuario: <%: usuario.NombreUsuario %></label></div>
    <div><label>Nombre de Usuario: <%: usuario.Contraseña %></label></div>
</asp:Content>
