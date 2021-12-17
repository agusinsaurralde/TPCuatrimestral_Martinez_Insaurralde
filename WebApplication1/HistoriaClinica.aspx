<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriaClinica.aspx.cs" Inherits="WebApplication1.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Historia Clínica</h1>
    <hr />
    
        <div class="d-flex flex-row-reverse" style="margin:20px 0px 20px 0px">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostBack="true" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
         </div>
  
    <asp:Label ID="resultados" Text="No se encontraron resultados." Visible="false" runat="server" />
     <div style="margin-bottom:40px">
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" SelectedRowStyle-BackColor="#999999" DataKeyNames="ID"  HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>   
                <asp:BoundField datafield = "Paciente.NombreCompleto" HeaderText ="PACIENTE" />
                <asp:BoundField datafield = "Fecha" DataFormatString="{0:d}"  HeaderText ="ÚLTIMA ACTUALIZACIÓN" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Detalle"  ControlStyle-CssClass="btn btn-primary rounded-pill"/> 
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
