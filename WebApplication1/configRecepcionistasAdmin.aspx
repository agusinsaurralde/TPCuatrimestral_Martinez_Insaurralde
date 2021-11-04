<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="configRecepcionistasAdmin.aspx.cs" Inherits="WebApplication1.configRecepcionistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <header>
        <h1>
            Configuración de Recepcionistas.
        </h1>
    </header>
    <body>
        <div>
            <div style="float:left"> <h4>Nombre:</h4> <asp:TextBox  runat="server" /> </div>
            <div style="float:left" > <h4>Apellido:</h4> <asp:TextBox runat="server" /> </div>
            <div style="float:left"> <h4>Legajo:</h4> <asp:TextBox  runat="server" /> </div>
            
        </div>
    </body>
    <br />
    <br />
    <footer>
        <div style="float:initial">
            <div style="padding: 40px 0px">
                <asp:Button ID="btnVolver1" Text="Volver" runat="server" OnClick="btnVolver1_Click" />
            </div>
       </div>
            
     </footer>
</asp:Content>
