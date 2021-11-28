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
        <asp:Button Text="Modificar" OnClick ="Click_Modificar" runat="server" />
        <asp:Button Text="Eliminar" OnClick ="Click_Eliminar" runat="server" />
    </div>
    <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla" runat="server" />
    </div>
   
</asp:Content>
