<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHistoriaClinicaMedico.aspx.cs" Inherits="WebApplication1.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Historia Clínica</h3>
    <hr />
    <h4>Ricardo López</h4>  
    <body>
        <div>
        <table class="table">
             <tr>
                <td>Fecha</td> <td>Descripción</td> 
            </tr>
            <tr>
                <td>15/11/2021</td><td><asp:TextBox runat="server" TextMode="MultiLine" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" Height="78px" Width="1180px" /></td>  
            </tr>
        </table>
        </div>
        <div><asp:Button Text="Aceptar" runat="server" /></div>
    </body>
</asp:Content>
