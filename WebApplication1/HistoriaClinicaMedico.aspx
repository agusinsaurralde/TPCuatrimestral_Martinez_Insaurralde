<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriaClinicaMedico.aspx.cs" Inherits="WebApplication1.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3>Historia Clínica</h3>
    <hr />
    <body>
        <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Ver" onclick="Click_Ver" runat="server" />
        </div>
        <div>
        <table class="table">
             <tr>
                <td>DNI</td> <td>Nombre y Apellido</td> <td>Última Actualización</td> 
            </tr>
            <tr>
                <td>22543697</td> <td>Ricardo López</td> <td>15/11/2021</td>
            </tr>
        </table>
        </div>
    </body>
</asp:Content>
