<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Modificar Médico</h1>
    <hr />
    <div class="row g-3">
      <div class="col-md-4">
           <label for="txtDNI" class="form-label">DNI</label>
           <asp:TextBox class="form-control" ID="txtDNI"  runat="server" />
  </div>

    <div class="col-md-4">
    <label for="txtMatricula" class="form-label">Matrícula</label>
    <asp:TextBox  class="form-control" ID="txtMatricula"  runat="server" />
  </div>

  <div class="col-md-4">
    <label for="txtApellido" class="form-label">Apellido</label>
    <asp:TextBox  class="form-control" ID="txtApellido"  runat="server" />
  </div>

  <div class="col-md-4">
    <label for="txtNombre" class="form-label">Nombre</label>
    <asp:TextBox  class="form-control" ID="txtNombre"  runat="server" />
  </div>


  <div class="col-md-6">
    <label for="ddlistEspecialidad" class="form-label">Especialidad</label>
    <asp:DropDownList ID="ddlistEspecialidad" class="form-select" runat="server"></asp:DropDownList>
  </div>


  <div class="col-md-3">
    <label for="txtFechaNac" class="form-label">Fecha de Nacimiento</label>
    <asp:TextBox type="date" class="form-control" ID="txtFechaNac" runat="server" />
  </div>


  <div class="col-md-3">
    <label for="txtTelefono" class="form-label">Teléfono</label>
    <asp:TextBox type="tel" class="form-control" ID="txtTelefono" runat="server" />
  </div>

  <div class="col-12">
    <label for="txtEmail" class="form-label">Email</label>
    <asp:TextBox type="email" class="form-control" ID="txtEmail" runat="server" />
  </div>

  <div class="col-12">
    <label for="txtDireccion" class="form-label">Dirección</label>
    <asp:TextBox class="form-control" ID="txtDireccion" runat="server" />
  </div>

  <div class="col-12">
    <label for="ddlistTurno" class="form-label">Turno</label>
    <asp:DropDownList ID="ddlistTurno" class="form-select" runat="server"></asp:DropDownList>
  </div>

  <div class="col-12">
    <label for="txtEntrada" class="form-label">Horario de Entrada</label>
     <asp:TextBox class="form-control" ID="txtEntrada" runat="server" />
  </div>
    
  <div class="col-12">
    <label for="txtSalida" class="form-label">Horario de Salida</label>
     <asp:TextBox class="form-control" ID="txtSalida" runat="server" />
  </div>


  <div class="col-12">
        <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
  </div>
</div>

</asp:Content>
       
              
              
  
