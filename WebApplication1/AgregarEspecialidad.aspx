<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidad.aspx.cs" Inherits="WebApplication1.AgregarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Agregar Especialidad</h1>
    <hr />
    <div class="row g-3">
    <div class="col-md-4">
        <label for="txtEspecialidad" class="form-label">Especialidad</label>
        <asp:TextBox class="form-control rounded-pill" ID="txtEspecialidad"  runat="server" />
    </div>
    <div>
        <asp:Button class="btn btn-primary rounded-pill" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
    </div>
    </div>
</asp:Content>
