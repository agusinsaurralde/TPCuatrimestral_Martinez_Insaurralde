<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Ver Turnos</h1>
    <hr />
    <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="Número" />
            <asp:ListItem Text="Médico" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
    </div>
     <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowEditing="Grilla_editar" DataKeyNames="Numero"  >
            <Columns>   
                <asp:BoundField datafield = "Numero" HeaderText ="ID" />
                <asp:BoundField datafield = "Paciente.Apellido" HeaderText ="ApellidoPaciente" />
                <asp:BoundField datafield = "Paciente.Nombre" HeaderText ="NombrePaciente" />
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="Especialidad" />
                <asp:BoundField datafield = "Medico.Apellido" HeaderText ="ApellidoMédico" />
                <asp:BoundField datafield = "Medico.Nombre" HeaderText ="NombreMédico" />
                <asp:BoundField datafield = "Dia" HeaderText ="Dia" />
                <asp:BoundField datafield = "HorarioInicio" HeaderText ="Inicio" />
                <asp:BoundField datafield = "HorarioFin" HeaderText ="Finalización" />
                <asp:BoundField datafield = "Observaciones" HeaderText ="Observaciones" />
                <asp:BoundField datafield = "AdministrativoResponsable.Apellido" HeaderText ="ApellidoRecepcionista" />
                <asp:BoundField datafield = "AdministrativoResponsable.Nombre" HeaderText ="NombreRecepcionista" />
                <asp:BoundField datafield = "Estado.Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button" ShowEditButton="true" />   
            </Columns>
        </asp:gridview>
    </div>
 
</asp:Content>
