<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCobertura.aspx.cs" Inherits="WebApplication1.Formulario_web116" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Cobertura</h1>
    <hr />
    <div class="row g-3">
    <div class="col-md-4">
        <label for="txtCobertura" class="form-label">Cobertura</label>
        <asp:TextBox class="form-control" ID="txtCobertura"  runat="server" />
    </div>
    <div>
        <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
    </div>
    </div>
</asp:Content>
