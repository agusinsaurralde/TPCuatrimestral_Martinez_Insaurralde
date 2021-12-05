<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h1>Asignar Turno</h1>
        <hr />
        <div class="col-md-2">
             <label for="txtDNI" class="form-label">DNI</label>
             <asp:TextBox  class="form-control" ID="txtDNI"  runat="server" />
             <asp:Label Text="" ID="txtPaciente" runat="server" />

        </div>
        <div class="col-md-4">
             <asp:Button class="btn btn-primary" Text="Buscar" OnClick="Click_Buscar" runat="server" />
         </div>
        <div class="col-md-4">
            <asp:Label Text="" ID="txtApellido" runat="server" />             
        </div>
     <div class="col-md-4">
            <asp:Label Text="" ID="txtNombre" runat="server" />
      </div>
    <div class="col-md-4">
            <asp:Label Text="" ID="txtCobertura" runat="server" />
      </div>

    <asp:UpdatePanel/ runat="server">
        <ContentTemplate>
            <div class="col-md-3">
            <label for="ddlistEspecialidad" class="form-label">Especialidad</label>
            <asp:DropDownList ID="ddlistEspecialidad" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
          </div>

        <div class="col-md-3">
            <label for="ddlistMedico" class="form-label">Médico</label>
            <asp:DropDownList ID="ddlistMedico" class="form-select" CssClass="form-select" runat="server" Enabled="False" EnableViewState="True" ></asp:DropDownList>
        </div>
        <div class="col-md-3">
            <label for="txtFecha" class="form-label">Día</label>
            <asp:TextBox type="date" ID="txtFecha" CssClass="form-select" AutoPostBack="true" DataFormatString="{0:d}" runat="server" OnTextChanged="txtFecha_textChanged" Enabled="False" />
        </div>
        <div class="col-md-3">
            <label for="ddlistHora" class="form-label">Horario</label>
            <asp:DropDownList ID="ddlistHora" class="form-select" CssClass="form-select" SelectedIndexChanged="ddlistaDia_SelectedIndexChanged" AutoPostBack="true" runat="server" Enabled="False" EnableViewState="True"></asp:DropDownList>
        </div>

        </ContentTemplate>

    </asp:UpdatePanel>   

          
     <div class="col-md-4">
            <label for="txtObservaciones" class="form-label">Observaciones</label>
            <asp:TextBox  class="form-control" ID="txtObservaciones"  runat="server" />
     </div>

    <div class="col-md-3">
            <label for="ddlistRecepcionista" class="form-label">Recepcionista</label>
            <asp:DropDownList ID="ddlistRecepcionista" class="form-select" runat="server"></asp:DropDownList>
    </div>
     <div class="col-md-3">
            <label for="ddlistEstado" class="form-label">Estado</label>
            <asp:DropDownList ID="ddlistEstado" class="form-select" runat="server"></asp:DropDownList>
    </div>

     <div class="col-md-4">
             <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
     </div>
            
</asp:Content>
