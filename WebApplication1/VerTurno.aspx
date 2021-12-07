<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" SelectedRowStyle-BackColor="#999999" OnRowEditing="Grilla_editar" DataKeyNames="Numero"  >
            <Columns>   
               <asp:BoundField datafield = "Numero" HeaderText ="#" />
                <asp:BoundField datafield = "Paciente.NombreCompleto" HeaderText ="Paciente" />
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="Especialidad" />
                <asp:BoundField datafield = "Medico.NombreCompleto" HeaderText ="Médico" />
                <asp:BoundField datafield = "Dia" DataFormatString="{0:d}"  HeaderText ="Día" />
                <asp:BoundField datafield = "HorarioInicio" DataFormatString="{0:HH:mm}"  HeaderText ="Hora" />
                <asp:BoundField datafield = "Observaciones" HeaderText ="Observaciones" />
                <asp:BoundField datafield = "AdministrativoResponsable.NombreCompleto" HeaderText ="Recepcionista" />
                <asp:BoundField datafield = "Estado.Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />   
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" /> 
            </Columns>
        </asp:gridview>
    </div>
 
</asp:Content>
