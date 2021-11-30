<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h3>¿Esta seguro que desea eliminar al paciente '<asp:Label Text="text" ID="txtNombre" runat="server" />'?</h3>
        <asp:Button Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
        <asp:Button Text="Cancelar" OnClick="Click_Cancelar" runat="server" />
</asp:Content>
