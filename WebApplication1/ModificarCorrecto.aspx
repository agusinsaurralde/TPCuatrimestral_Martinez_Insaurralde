<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCorrecto.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        window.onload = function checkOk() {
            swal({
                title: "Ok!",
                text: "Los cambios fueron guardados :D!",
                icon: "success",
                button: false,
            });
            setTimeout(function () { window.location.href = "Default.aspx"; }, 1800);
            
        }
         
    </script>
    
    <asp:Label Text="text" ID="lblModificado" runat="server"/>
    <asp:Button Text="Volver" OnClick="Click_Volver" runat="server"/>
</asp:Content>
