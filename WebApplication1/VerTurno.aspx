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
        <asp:Button Text="Modificar turno" OnClick="Click_ModificarTurno" runat="server" />
        
        <asp:Button Text="Agregar Observación" onclick ="Click_AgregarObservacion" runat="server" />
    </div>
    <div>
        <asp:GridView  class="table table-hover" ID="Grilla" runat="server"></asp:GridView>
    </div>
 
</asp:Content>
