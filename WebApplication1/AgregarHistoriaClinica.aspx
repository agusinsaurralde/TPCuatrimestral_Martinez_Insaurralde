<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarHistoriaClinica.aspx.cs" Inherits="WebApplication1.AgregarHistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Historia Clínica</h3>
    <hr />
    <h4>
        <asp:Label Text="" ID="txtNombrePaciente" runat="server" />  </h4>  
        <div>
        <table class="table">
             <tr>
                <td>Fecha</td> <td>Descripción</td> 
            </tr>
            <tr>
                <td>
                    <asp:Label Text="" ID="lblFecha" runat="server" /> </td><td><asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" Text="" Height="78px" Width="1180px" /></td>  
            </tr>
        </table>
        </div>
        <div><asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" /></div>
</asp:Content>
