<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpecialtysViews.aspx.cs" Inherits="WebApplication1.SpecialtysViews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <%-- VER LAS ESPECIALIDADES DE LA DB DE UNA FORMA BONITA POR AHORA SOLO MUESTRA DE MANERA FEA.--%>
    <body>
     <h1>Especialidades</h1>
    <hr />
        <div>
            <asp:TextBox runat="server" />
            <asp:Button Text="Buscar" runat="server" />
            <asp:Button Text="Modificar" OnClick ="Click_Modificar" runat="server" />
            <asp:Button Text="Eliminar" OnClick ="Click_Eliminar" runat="server" />
        </div>

        <div>   
             <asp:GridView ID="Grilla" runat="server"></asp:GridView>
         </div>
    </body>
</asp:Content>
