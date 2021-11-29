<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="WebApplication1.Formulario_web115" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Coberturas</h1>
    <hr />
    <br />
        <div>
            <asp:TextBox runat="server" />
            <asp:Button Text="Buscar" runat="server" />
            <asp:Button Text="Agregar" OnClick ="Click_Agregar" runat="server" />
        </div>

         <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "Id" HeaderText ="ID" />
                <asp:BoundField datafield = "Nombre" HeaderText ="Cobertura" />            
                <asp:BoundField datafield = "Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button" ShowEditButton="true" />   
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />  
            </Columns>
        </asp:gridview>
    </div>
</asp:Content>
