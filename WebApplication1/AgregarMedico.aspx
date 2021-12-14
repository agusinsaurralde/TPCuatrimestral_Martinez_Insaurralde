<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web113" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Agregar Médico</h3>
    <hr />
    <br />
   
  <!-- tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li class="nav-item">
      <a class="nav-link active" data-bs-toggle="tab" style="font-weight:500" href="#datos">DATOS PERSONALES</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" style="font-weight:500" href="#especialidades">ESPECIALIDADES</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" style="font-weight:500" href="#usuario">USUARIO</a>
    </li>
  </ul>

  <!-- contenido -->
  <div class="tab-content">
    <div id="datos" class="container tab-pane active"><br>

      <br />

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
       <div class="col-md-3" style="margin-bottom: 40px">
       <label for="txtMatricula" class="form-label">MATRICULA</label>
       <asp:TextBox class="form-control rounded-pill" ID="txtMatricula"  runat="server" />
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
        
        
            </div>
        </div>
    </div>
</div>

    <div id="especialidades" class="container tab-pane fade"><br>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
               <div class="col-md-3">
                 <asp:Label Text="Especialidad" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                 <asp:DropDownList ID="ddlistEspecialidad" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
               </div>

               <div>
                   <div class="col-md-3">
                     <asp:Label Text="Días" ID="lblDias" Visible="false" CssClass="form-label" runat="server" />
                     <asp:DropDownList ID="ddlistDias" Visible="false" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDias_SelectedIndexChanged">
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
                      <asp:DropDownList ID="ddlistEntrada" Visible="false" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged"/>
                   </div>
                   <div>
                       <asp:TextBox ID="txtHoraSalida" Visible ="false" Enabled="false" DataFormatString="HH:mm" AutoPostBack="true"  class="form-control" runat="server" />
                   </div>
                   <div>
                      <asp:Button  ID="btnAgregarDia" Text="+ Día" Visible="false" OnClick="Click_AgregarDia" AutoPostBack="true" runat="server" />
                   </div>
                   <div>
                      <asp:Button  ID="btnAgregarEspecialidad" Text="Agregar Especialidad" Visible="false" OnClick="btnAgregarEspecialidad_Click" AutoPostBack="true" runat="server" />
                   </div>
                 </div>
            </ContentTemplate>
          </asp:UpdatePanel>
      </div>
    

    <div id="usuario" class="container tab-pane fade">
     
        <h4>Usuario</h4>
         <hr />
           <div class="col-12">
            <label for="txtNombreUsuario" class="form-label">Usuario</label>
            <asp:TextBox class="form-control" ID="txtNombreUsuario" runat="server" />
          </div>
          <div class="col-12">
            <label for="txtContraseña" class="form-label">Contraseña</label>
            <asp:TextBox class="form-control" type="Password" ID="txtContraseña" runat="server" />
          </div>
         <br />
         <div class="col-12">
         <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
        </div>
    </div>
    
  </div>


     

</asp:Content>
