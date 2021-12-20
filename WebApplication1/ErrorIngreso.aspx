<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorIngreso.aspx.cs" Inherits="WebApplication1.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        window.onload = function checkOk() {
            swal({
                title: "Error al iniciar",
                text: "Iniciar sesion fallo exitosamente :D!",
                icon: "warning",
                button: false,
            });
            setTimeout(function () { window.location.href = "Default.aspx"; }, 1800);
            
        }
         
        </script>    
    
    <body>
        <h1>Hubo un problema</h1>
        <asp:Label Text="text" ID="lblMensaje" runat="server" />
    </body>
   
</asp:Content>
