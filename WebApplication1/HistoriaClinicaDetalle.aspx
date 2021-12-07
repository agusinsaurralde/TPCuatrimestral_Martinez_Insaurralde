<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriaClinicaDetalle.aspx.cs" Inherits="WebApplication1.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Historia Clínica</h3>
    <hr />

    <div class="container">
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowEditing="Grilla_RowEditing" DataKeyNames="ID"  >
            <Columns>   
               <asp:BoundField datafield = "Fecha" DataFormatString="{0:d}" HeaderText ="Fecha" />
                <asp:BoundField datafield = "Descripcion" HeaderText ="Descripción" />
                <asp:CommandField ButtonType="Button"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />   
            </Columns>
        </asp:gridview>
    </div>

    
</asp:Content>
 