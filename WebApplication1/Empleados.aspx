<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="WebApplication1.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Empleados</h1>
    <hr />

   <div>
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Seleccionar criterio" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="DNI" />
         </asp:DropDownList>
        <asp:TextBox runat="server" />
        <asp:Button Text="Buscar" runat="server" />
        <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
    </div>
    <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "ID" HeaderText ="ID" />
                <asp:BoundField datafield = "Apellido" HeaderText ="Apellido" />
                <asp:BoundField datafield = "Nombre" HeaderText ="Nombre" />
                <asp:BoundField datafield = "Telefono" HeaderText ="Teléfono" />
                <asp:BoundField datafield = "Email" HeaderText ="Email" />
                <asp:BoundField datafield = "Dirección" HeaderText ="Dirección" />
                <asp:BoundField datafield = "FechaNacimiento" HeaderText ="Fecha de Nacimiento" />
                <asp:BoundField datafield = "TipoEmp.Nombre" HeaderText ="Tipo de Empleado"/>
                <asp:BoundField datafield = "Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button" ShowEditButton="true" />   
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />  
            </Columns>
        </asp:gridview>
    </div>
</asp:Content>
