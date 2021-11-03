<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <br />
        <div style = "float: left">   
            <div  style="padding: 40px 10px">
                <asp:Button Text="Asignar turno" runat="server" OnClick="Redirect_Click" />
            </div>
        </div>

        <div style = "float: left" >  
            <div style="padding: 40px 10px">
                <asp:Button Text="Ver turnos" runat="server" />
            </div>
        </div>

        <div style = "float: left">
            <div style="padding: 40px 10px">
                <asp:Button Text="Modificar turno" runat="server" />
            </div>
        </div>

        <div style = "float: left">
            <div style="padding: 40px 10px">
                <asp:Button Text = "Ver Especialidades" runat="server" OnClick="SpecialtysView_Click" />
            </div>
        </div>
        <br />
        <br />
    </body>
</asp:Content>
