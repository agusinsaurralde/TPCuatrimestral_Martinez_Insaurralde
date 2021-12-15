<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="WebApplication1.AgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h3>Agregar Empleado</h3>
    <hr />

 

  <div class="estilo">
     <div class="container">
          <div class="row">
              <div class="col-md-3">
                  <h5 style="margin-top: 40px">Datos</h5>
                  <h5>Personales</h5>
              </div>
          <div class="col-md-3" style="margin:40px 0px 40px 0px">
               <label for="txtDNI" class="form-label">DNI</label>
               <asp:TextBox class="form-control rounded-pill" ID="txtDNI"  runat="server" />
          </div>
          </div>
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px"">
            <label for="txtApellido" class="form-label">APELLIDO</label>
            <asp:TextBox  class="form-control rounded-pill" ID="txtApellido"  runat="server" />
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtNombre" class="form-label">NOMBRE</label>
            <asp:TextBox  class="form-control rounded-pill" ID="txtNombre"  runat="server" />
          </div>
        </div>
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="ddlistTipoEmpleado" class="form-label">TIPO DE EMPLEADO</label>
            <asp:DropDownList ID="ddlistTipoEmpleado" class="form-select rounded-pill" runat="server"></asp:DropDownList>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
            <asp:TextBox type="date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
          </div>
         </div>
        
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtTelefono" class="form-label">TELÉFONO</label>
            <asp:TextBox type="tel" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
            <asp:TextBox class="form-control rounded-pill" ID="txtDireccion" runat="server" />
          </div>
         </div>
        
        <div class="row justify-content-center">
          <div class="col-md-6" style="margin-bottom: 40px">
            <label for="txtEmail" class="form-label">EMAIL</label>
            <asp:TextBox type="email" class="form-control rounded-pill" ID="txtEmail" runat="server" />
          </div>
         </div>
        

        </div>
 
</div>

<br />
    <hr />

  <div ">
    <div class="estilo">
        <div class="row">
            <div class="col-md-3">
                <h5 style="margin-top: 40px">Usuario</h5>
            </div>
         
           <div class="col-md-3" style="margin:40px 0px 70px 0px">
              <label for="txtNombreUsuario" class="form-label">USUARIO</label>
              <asp:TextBox class="form-control rounded-pill" ID="txtNombreUsuario" runat="server" />
           </div>
           <div class="col-md-3" style="margin:40px 0px 70px 0px">
             <label for="txtContraseña" class="form-label">CONTRASEÑA</label>
             <asp:TextBox class="form-control rounded-pill" type="Password" ID="txtContraseña" runat="server" />
           </div>
         </div>              
       
    </div>
 </div>
    <hr />
    <div class="d-flex justify-content-end">
         <div class="row" style="margin-bottom: 40px; margin-top:20px">
               <div class="col">
                     <asp:Button class="btn btn-outline-secondary rounded-pill" Text="CANCELAR" Font-Size="Small" BorderColor="White" OnClick="Cancelar_Click" Font-Bold="true" runat="server" />
               </div>
               <div class="col"  >
                     <asp:Button class="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="Click_Aceptar" runat="server" />
               </div>
        </div>
    </div>
</asp:Content>
