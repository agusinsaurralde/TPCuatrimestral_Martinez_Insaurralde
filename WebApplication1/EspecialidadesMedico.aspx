<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspecialidadesMedico.aspx.cs" Inherits="WebApplication1.EspecialidadesMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> <asp:Label Text="" runat="server" /></h1>
    <%foreach (Dominio.Medico medico in (List<Dominio.Medico>)Session["EspMedico"])
      { %>
    <asp:Label Text="" ID="txtEspecialidad" runat="server" />
    <div>
        <asp:Label Text="" ID="txtTurno" runat="server" />
    </div>
    <div>
        <asp:Label Text="" ID="txtEntrada" runat="server" />
    </div>
    <div>
        <asp:Label Text="" ID="txtSalida" runat="server" />
    </div>
    <div>
        <asp:Label Text="" ID="txtDiasHabiles" runat="server" />
    </div>
    <%} %>
</asp:Content>
