<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPermisosAcceso.aspx.cs" Inherits="WebApplication1.ErrorPermisosAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        window.onload = function checkOk() {
            swal({
                title: "Error de permisos",
                text: "Usted no puede entrar aqui ¯\_(ツ)_/¯",
                icon: "warning",
                button: false,
            });
            setTimeout(function () { window.location.href = "Default.aspx"; }, 1900);

        }

    </script>
    
    <asp:Label Text="error" runat="server" />
</asp:Content>
