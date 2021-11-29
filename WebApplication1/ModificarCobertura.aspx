<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCobertura.aspx.cs" Inherits="WebApplication1.Formulario_web22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Modificar Cobertura</h1>
    <hr />
    <div class="row g-3">
    <div class="col-md-4">
        <label for="txtCobertura" class="form-label">Especialidad</label>
        <asp:TextBox class="form-control" ID="txtCobertura"  runat="server" />
    </div>
    <div>
        <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
        <asp:Button class="btn btn-primary" Text="Cancelar" OnClick="Click_Cancelar" runat="server" />
    </div>
    </div>
</asp:Content>
