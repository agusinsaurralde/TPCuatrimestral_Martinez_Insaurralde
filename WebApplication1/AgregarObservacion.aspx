<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarObservacion.aspx.cs" Inherits="WebApplication1.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <h4>Ricardo López</h4>
    <body>
        <div>
        <table class="table">
             <tr>
                <td>Fecha</td> <td>Descripción</td> 
            </tr>
            <tr>
                <td>15/11/2021</td><td> <asp:TextBox runat="server" /></td><td><asp:Button Text="Agregar" runat="server" /></td>
            </tr>
        </table>
        </div>
    </body>
</asp:Content>
