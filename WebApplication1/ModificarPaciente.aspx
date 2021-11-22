<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Modificar Paciente</h3>
    <body>
        <hr />
        <div><asp:TextBox runat="server" text="1111" /></div>
       <div>
             <asp:TextBox runat="server" text="López" />
        </div>
        <div>
             <asp:TextBox runat="server" text="Ricardo" />
        </div>
        <div>
            <asp:DropDownList runat="server">
                <asp:ListItem Text="Cobertura" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:TextBox runat="server" /></div>
        <div>
        <div>
            <asp:TextBox runat="server" /></div>
        <div>
         <div>
            <asp:TextBox runat="server" /></div>
        <div>
        <div>
            <asp:TextBox runat="server" /></div>
        <div>
                <asp:Button Text="Aceptar" runat ="server" />
        </div>
    </body>
</asp:Content>
