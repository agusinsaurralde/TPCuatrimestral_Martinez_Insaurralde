<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpecialtysViews.aspx.cs" Inherits="WebApplication1.SpecialtysViews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <%-- VER LAS ESPECIALIDADES DE LA DB DE UNA FORMA BONITA POR AHORA SOLO MUESTRA DE MANERA FEA.--%>

    <div>   
         <asp:GridView ID="Grilla" runat="server"></asp:GridView>
     </div>

</asp:Content>
