<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="WebApplication1.Formulario_web119" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="row">
        <div class="col-2"> </div>
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Usuario" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtbxUsuario" CssClass="form-control" runat="server" />
            </div>
              <div class="mb-3">
                <asp:Label Text="Contraseña" CssClass="form-label" runat="server" />
                <asp:TextBox type="password" ID="txtbxContraseña" CssClass="form-control" runat="server" />              
              </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID ="btnAceptar" OnClick="Click_Ingresar" runat="server" />
        </div>
         <div class="col-2"> </div>
    </div>

  
</asp:Content>
