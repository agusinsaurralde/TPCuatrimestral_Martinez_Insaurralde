<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarDiaMedico.aspx.cs" Inherits="WebApplication1.ModificarDiaMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <div class="col-md-3">
            <asp:Label Text="" ID="lblEspecialidad" CssClass="form-label" runat="server" />
          </div>

      <div>
          <div class="col-md-3">
            <asp:Label Text="Días" ID="lblDias" CssClass="form-label" runat="server" />
            <asp:DropDownList ID="ddlistDias" class="form-select" runat="server" AutoPostBack="true">
                <asp:ListItem Text="Seleccionar" />
                <asp:ListItem Text="Lunes" />
                <asp:ListItem Text="Martes" />
                <asp:ListItem Text="Miércoles" />
                <asp:ListItem Text="Jueves" />
                <asp:ListItem Text="Viernes" />
                <asp:ListItem Text="Sábado" />
            </asp:DropDownList>              
          </div>

          <div>
             <asp:DropDownList ID="ddlistEntrada" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged"/>
          </div>
          <div>
              <asp:TextBox ID="txtHoraSalida"  Enabled="false" DataFormatString="HH:mm" AutoPostBack="true"  class="form-control" runat="server" />
          </div>
          <div>
             <asp:Button  ID="btnModificarDia" Text="Aceptar"  OnClick="btnModificarDia_Click" AutoPostBack="true" runat="server" />
          </div>

            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
