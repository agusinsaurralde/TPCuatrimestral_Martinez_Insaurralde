<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriaClinicaDetalle.aspx.cs" Inherits="WebApplication1.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Historia Clínica - <asp:Label Text="" id="lblNombrePaciente" runat="server" /></h3>
    <hr />

    <div class="container" style="margin:40px 0px 40px 0px">
        <asp:GridView CssClass="table table-hover" HeaderStyle-Font-Size="Small" BorderStyle="None" ID="Grilla"  runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="table-primary" OnRowEditing="Grilla_RowEditing" DataKeyNames="ID"  >
            <Columns>   
               <asp:BoundField datafield = "Fecha" DataFormatString="{0:d}" HeaderText ="FECHA" />
                <asp:BoundField datafield = "Descripcion" HeaderText ="DESCRIPCIÓN" />
                <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
            </Columns>
        </asp:gridview>
    </div>

    
</asp:Content>
 