<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorModificar.aspx.cs" Inherits="WebApplication1.Formulario_web123" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <script>
        window.onload = function checkOk() {
            swal({
                title: "Wo Wo Wo",
                text: "Algo ha salido mal :D!",
                icon: "error",
                button: false,
            });
            setTimeout(function () { window.location.href = "Default.aspx"; }, 1800);
            
        }
         
        </script>
    
    <asp:Label Text="text" ID="lblModificado" runat="server" />
    <asp:Button Text="Volver" OnClick="Click_Volver" runat="server" />
</asp:Content>
