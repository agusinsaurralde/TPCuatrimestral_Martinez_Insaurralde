<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarHistoriaClinica.aspx.cs" Inherits="WebApplication1.AgregarHistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            var descripcion = document.getElementById("<% = txtDescripcion.ClientID %>").value;

            if (descripcion === "") {
                $("#txtDescripcion").addClass("is-invalid");
                return false;
            }
            else {
                $("#txtDescripcion").removeClass("is-invalid");
            }
            return true;

        }
    </script>
    
    <style>
        td{
              font-weight: bold;
              font-size: 12px;
        }
    </style>


    <h3 style="margin-top:40px">Historia Clínica - <asp:Label Text="" ID="txtNombrePaciente" runat="server" /></h3>
    <br />
  
        <div>
        <table class="table">
             <tr>
                <td>FECHA</td> <td>DESCRIPCIÓN</td> 
            </tr>
            <tr>
                <td>
                    <asp:Label Text="" ID="lblFecha" runat="server" /> </td><td><asp:TextBox CssClass="form-control" ClientIDMode="Static" runat="server" TextMode="MultiLine" ID="txtDescripcion" Text="" Height="78px" Width="1180px" /></td>  
            </tr>
        </table>
        </div>
            <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDescripcion" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        <div class="d-flex justify-content-end"><asp:Button Text="ACEPTAR" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" runat="server" /></div>
</asp:Content>
