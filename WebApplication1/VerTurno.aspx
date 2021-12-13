<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Ver Turnos</h1>
    <hr />
    <div class="input-group mb-3">
        <asp:TextBox class="form-control" ID="txtBusqueda" runat="server" />  
        <asp:DropDownList ID="ddlistCriterio" class="btn btn-outline-secondary dropdown-toggle" runat="server">
            <asp:ListItem Text="Paciente" />
            <asp:ListItem Text="Médico" />
            </asp:DropDownList>
        <asp:Button Text="Buscar" OnClick ="Click_Buscar" class="btn btn-outline-secondary" runat="server" />
    </div>
     <div class="container">
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" OnRowEditing="Grilla_editar" DataKeyNames="Numero" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>   
                <asp:BoundField datafield = "Paciente.NombreCompleto" HeaderText ="PACIENTE" />
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="ESPECIALIDAD" />
                <asp:BoundField datafield = "Medico.NombreCompleto" HeaderText ="MÉDICO" />
                <asp:BoundField datafield = "Dia" DataFormatString="{0:d}"  HeaderText ="DÍA" />
                <asp:BoundField datafield = "HorarioInicio" DataFormatString="{0:HH:mm}"  HeaderText ="HORA" />
                <asp:BoundField datafield = "Observaciones" HeaderText ="OBSERVACIONES" />
                <asp:BoundField datafield = "AdministrativoResponsable.NombreCompleto" HeaderText ="RECEPCIONISTA" />
                <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Agregar Observación" ControlStyle-CssClass="btn btn-primary rounded-pill"/> 
            </Columns>
        </asp:gridview>
    </div>
 
</asp:Content>
