 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web112" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <br />
    <h3>Agregar Paciente</h3>
    <hr />
    <style>
        .estilo label{
            font-weight: bold;
            font-size: 12px;
        }
    </style>
  <div class="estilo">
<div class="container">
  <div class="row">
  <div class="col-md-3" style="margin-bottom: 40px">
       <label for="txtDNI" class="form-label">DNI</label>
       <asp:TextBox class="form-control rounded-pill" ID="txtDNI"  runat="server" />
  </div>
  </div>

<div class="row">
  <div class="col-md-3" style="margin-bottom: 40px"">
    <label for="txtApellido" class="form-label">APELLIDO</label>
    <asp:TextBox  class="form-control rounded-pill" ID="txtApellido"  runat="server" />
  </div>
    <div class="col-md-3" style="margin-bottom: 40px">
    <label for="txtNombre" class="form-label">NOMBRE</label>
    <asp:TextBox  class="form-control rounded-pill" ID="txtNombre"  runat="server" />
  </div>


<div class="row">
  <div class="col-md-3" style="margin-bottom: 40px">
    <label for="ddlistCobertura" class="form-label">COBERTURA</label>
    <asp:DropDownList ID="ddlistCobertura" class="form-select rounded-pill" runat="server"></asp:DropDownList>
  </div>
    <div class="col-md-3" style="margin-bottom: 40px">
    <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
    <asp:TextBox type="date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
  </div>
 </div>


<div class="row">
  <div class="col-md-3" style="margin-bottom: 40px">
    <label for="txtTelefono" class="form-label">TELÉFONO</label>
    <asp:TextBox type="tel" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
  </div>
    <div class="col-md-3" style="margin-bottom: 40px">
    <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
    <asp:TextBox class="form-control rounded-pill" ID="txtDireccion" runat="server" />
  </div>
 </div>

<div class="row">
  <div class="col-md-6" style="margin-bottom: 40px">
    <label for="txtEmail" class="form-label">EMAIL</label>
    <asp:TextBox type="email" class="form-control rounded-pill" ID="txtEmail" runat="server" />
  </div>
 </div>

      
<div class="row" style="margin-bottom: 20px">
   
         <div class="col-md-1">
               <asp:Button class="btn btn-outline-secondary rounded-pill" Text="CANCELAR" Font-Size="Small" BorderColor="White" Font-Bold="true" OnClick="Cancelar_Click" runat="server" />
         </div>
         <div class="col-md-1"  >
               <asp:Button class="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="Click_Aceptar" runat="server" />
         </div>
   
</div>
</div>
</div>
</div>
</asp:Content>
