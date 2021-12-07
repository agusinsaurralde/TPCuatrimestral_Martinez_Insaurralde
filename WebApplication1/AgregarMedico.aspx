<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web113" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Agregar Médico</h1>
    <hr />
    <br />
   
  <!-- tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li class="nav-item">
      <a class="nav-link active" data-bs-toggle="tab" href="#datos">Datos Personales</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" href="#especialidades">Especialidades</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" href="#usuario">Usuario</a>
    </li>
  </ul>

  <!-- contenido -->
  <div class="tab-content">
    <div id="datos" class="container tab-pane active"><br>
      <h4>Datos Personales</h4>
        <hr />
      <br />

       <div class="row g-3">
           <div class="col-md-4">
               <label for="txtDNI" class="form-label">DNI</label>
               <asp:TextBox class="form-control" ID="txtDNI" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtMatricula" class="form-label">Matrícula</label>
               <asp:TextBox class="form-control" ID="txtMatricula" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtApellido" class="form-label">Apellido</label>
               <asp:TextBox class="form-control" ID="txtApellido" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtNombre" class="form-label">Nombre</label>
               <asp:TextBox class="form-control" ID="txtNombre" runat="server" />
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

         </div>
    </div>


    <div id="especialidades" class="container tab-pane fade"><br>
      <h3>Especialidades</h3>

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
