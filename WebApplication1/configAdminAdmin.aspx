<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="configAdminAdmin.aspx.cs" Inherits="WebApplication1.configAdminAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <header>
        <h1>
            Configuracion de administradores.
        </h1>
    </header>
    <body> 
        <div>
            <div style="float:left"> <h4>Nombre:</h4> <asp:TextBox  runat="server" /> </div>
            <div style="float:left" > <h4>Apellido:</h4> <asp:TextBox runat="server" /> </div>
            <div style="float:left"> <h4>Legajo:</h4> <asp:TextBox  runat="server" /> </div>
            
        </div>
        <div>
            <div style="float:left"> <h4>Nombre de Usuario:</h4> <asp:TextBox  runat="server" /> </div>
        </div>
    </body>
    <br />
    <br />
    <footer>  
        <div style="float:initial">
            <div style="padding: 40px 0px">
                <asp:Button ID="btnVolver3" Text="Volver" runat="server" OnClick="btnVolver3_Click"/>
            </div>
        </div>       
    </footer>
</asp:Content>
