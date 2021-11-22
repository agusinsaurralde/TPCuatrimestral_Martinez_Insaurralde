<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web112" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h1>Agregar Paciente</h1>
    <hr />
    <div>
        <asp:Label Text="DNI" runat="server" />
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
            <asp:Label Text="Cobertura" runat="server" />
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
            <asp:Button Text="Aceptar" runat="server" />
        </div>
    </body>

</asp:Content>
