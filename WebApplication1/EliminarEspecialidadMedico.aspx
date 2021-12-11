<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarEspecialidadMedico.aspx.cs" Inherits="WebApplication1.EliminarEspecialidadMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>¿Esta seguro que desea eliminar la especialidad?</h3>
    <asp:Button Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
    <asp:Button Text="Cancelar" OnClick="Click_Cancelar" runat="server" />
</asp:Content>
