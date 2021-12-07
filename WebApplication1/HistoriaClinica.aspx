<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriaClinica.aspx.cs" Inherits="WebApplication1.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3>Historia Clínica</h3>
    <hr />
    <div class="input-group mb-3">
        <asp:TextBox class="form-control" ID="txtBusqueda" aria-describedby="button-addon2" runat="server" />
        <asp:Button Text="Buscar" OnClick ="Click_Buscar" class="btn btn-outline-secondary" runat="server" />
    </div>
  
     <div class="container">
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" SelectedRowStyle-BackColor="#999999" DataKeyNames="ID"  >
            <Columns>   
                <asp:BoundField datafield = "Paciente.NombreCompleto" HeaderText ="Paciente" />
                <asp:BoundField datafield = "Fecha" DataFormatString="{0:d}"  HeaderText ="Última Actualización" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Detalle"  ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" /> 
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
