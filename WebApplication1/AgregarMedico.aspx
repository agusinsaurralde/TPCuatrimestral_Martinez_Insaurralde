<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web113" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h1>Agregar Médico</h1>
        <hr />
        <div>
            <asp:Label Text="DNI" runat="server" />
            <asp:TextBox runat="server" />
        </div>
              <div>
            <asp:Label Text="Matrícula" runat="server" />
            <asp:TextBox runat="server" />
        </div>
        <div>
             <asp:Label Text="Apellido" runat="server" />
        <asp:TextBox runat="server" />
        </div>
        <div>
            <asp:Label Text="Nombre" runat="server" />
         <asp:TextBox runat="server" />
        </div>
        <div>
            <asp:Label Text="Fecha de Nacimiento" runat="server" />
             <asp:TextBox runat="server" />
        </div>
        <div>
             <asp:Label Text="Teléfono" runat="server" />
             <asp:TextBox runat="server" />
        </div>
        <div>
              <asp:Label Text="Email" runat="server" />
              <asp:TextBox runat="server" />
        </div>
        <div>
               <asp:Label Text="Dirección" runat="server" />
               <asp:TextBox runat="server" />
        </div>
        <div>
        <div>
            <asp:Label Text="Turno de Trabajo" runat="server" />
            <asp:DropDownList runat="server">
                <asp:ListItem Text="Mañana" />
                <asp:ListItem Text="Tarde" />
            </asp:DropDownList>       
        </div>
        <div>
            <asp:Label Text="Horario de Entrada" runat="server" />
             <asp:TextBox runat="server" />        
        </div>
         <div>
            <asp:Label Text="Horario de Salida" runat="server" />
             <asp:TextBox runat="server" />        
        </div>
            <asp:Button Text="Aceptar" runat="server" />
        </div>
    </body>
    
</asp:Content>
