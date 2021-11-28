<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Médicos</h1>
    <hr />

        <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
            <asp:ListItem Text="Especialidad" />
            <asp:ListItem Text="Turno" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
        <asp:Button Text="Eliminar" OnClick ="Click_Eliminar" runat="server" />
    </div>
    <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "ID" HeaderText ="ID" />
                <asp:BoundField datafield = "Matricula" HeaderText ="Matrícula" />
                <asp:BoundField datafield = "Apellido" HeaderText ="Apellido" />
                <asp:BoundField datafield = "Nombre" HeaderText ="Nombre" />
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="Especialidad" />
                <asp:BoundField datafield = "Telefono" HeaderText ="Teléfono" />
                <asp:BoundField datafield = "Email" HeaderText ="Email" />
                <asp:BoundField datafield = "Dirección" HeaderText ="Dirección" />
                <asp:BoundField datafield = "FechaNacimiento" HeaderText ="Fecha de Nacimiento" />
                <asp:BoundField datafield = "Turno.NombreTurno" HeaderText ="Turno" />
                <asp:BoundField datafield = "HorarioEntrada" HeaderText ="Horario de Entrada" />
                <asp:BoundField datafield = "HorarioSalida" HeaderText ="Horario de Salida" />
                <asp:CommandField ButtonType="Button" ShowEditButton="true" />   
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />  
            </Columns>
        </asp:gridview>
    </div>
   
</asp:Content>
