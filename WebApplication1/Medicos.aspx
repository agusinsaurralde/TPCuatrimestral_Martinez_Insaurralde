<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Médicos</h1>
    <hr />

    <div>
        <asp:TextBox ID="txtBusqueda" runat="server" />
        <asp:Button Text="Buscar" OnClick="Click_Buscar" runat="server" />
        <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblBusquedaIncorrecta" Text="" runat="server" /></div>
    <div>
        <asp:GridView CssClass="table table-hover" BorderStyle="None" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged"  OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" EmptyDataRowStyle-BorderStyle="None" HeaderStyle-BorderColor="#333333" HeaderStyle-CssClass="table-dark" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField datafield = "ID" HeaderText ="#" />
                <asp:BoundField datafield = "Matricula" HeaderText ="Matrícula" />
                <asp:BoundField datafield = "NombreCompleto" HeaderText ="Nombre y apellido" />              
                <asp:BoundField datafield = "Telefono" HeaderText ="Teléfono" />
                <asp:BoundField datafield = "Email" HeaderText ="Email" />
                <asp:BoundField datafield = "Dirección" HeaderText ="Dirección" />
                <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}"  HeaderText ="Fecha de Nacimiento" />
                <asp:BoundField datafield = "Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Especialidaes" />
                <asp:CommandField ButtonType="Button" ShowEditButton="true" />   
                <asp:CommandField ButtonType ="Button" ShowDeleteButton="true" />
            </Columns>
        </asp:gridview>
    </div>
   
</asp:Content>
