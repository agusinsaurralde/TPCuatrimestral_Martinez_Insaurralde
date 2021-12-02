<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h1>Asignar Turno</h1>
        <hr />
    <div class="col-md-4">
             <label for="txtDNI" class="form-label">DNI</label>
             <asp:TextBox  class="form-control" ID="txtDNI"  runat="server" />
        </div>
   
        <div class="col-md-4">
         <asp:Button class="btn btn-primary" Text="Buscar" OnClick="Click_Buscar" runat="server" />
         </div>
 
        <div class="col-md-4">
             <label for="txtApellido" class="form-label">Apellido</label>
             <asp:TextBox  class="form-control" ID="txtApellido"  runat="server" />
        </div>

          <div class="col-md-4">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox  class="form-control" ID="txtNombre"  runat="server" />
          </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="col-md-6">
            <label for="ddlistEspecialidad" class="form-label">Especialidad</label>
            <asp:DropDownList ID="ddlistEspecialidad" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
          </div>

        <div class="col-md-3">
            <label for="ddlistMedico" class="form-label">Médico</label>
            <asp:DropDownList ID="ddlistMedico" class="form-select" runat="server" Enabled="False" EnableViewState="True"></asp:DropDownList>
        </div>

        </ContentTemplate>
    </asp:UpdatePanel>   
</asp:Content>
