<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="WebApplication1.Formulario_web119" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script>
        function validar() {
            var usuario = document.getElementById("<% = txtbxUsuario.ClientID %>").value;
            var contraseña = document.getElementById("<% = txtbxContraseña.ClientID %>").value;
            

            var valido = true;

            if (usuario === "") {
                $("#txtbxUsuario").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtbxUsuario").removeClass("is-invalid");
            }

            if (contraseña === "") {
                $("#txtbxContraseña").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtbxContraseña").removeClass("is-invalid");
            }


            if (!valido) {
                return false;
            }
            return true;
        }
  </script>



    <div class="row">
        <div class="col-2"> </div>
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="USUARIO" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtbxUsuario" ClientIDMode="Static" CssClass="form-control rounded-pill" runat="server" />
            </div>
              <div class="mb-3">
                <asp:Label Text="CONTRASEÑA" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" />
                <asp:TextBox type="password" ClientIDMode="Static" ID="txtbxContraseña" CssClass="form-control rounded-pill" runat="server" />              
              </div>
            <asp:Button Text="INICIAR SESIÓN" CssClass="btn btn-primary rounded-pill" OnClientClick="return validar()" Font-Bold="true" Font-Size="Small" ID ="btnAceptar" OnClick="Click_Ingresar" runat="server" />
        </div>
         <div class="col-2"> </div>
    </div>

  
</asp:Content>
