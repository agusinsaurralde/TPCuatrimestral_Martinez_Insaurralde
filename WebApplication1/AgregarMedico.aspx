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
    <div id="datos" class="container tab-pane active">

        <div class="estilo">
          <div class="row justify-content-center">
             <div class="col-md-3" style="margin-bottom: 40px; margin-top:60px">
                  <label for="txtDNI" class="form-label">DNI</label>
                  <asp:TextBox class="form-control rounded-pill" ID="txtDNI"  runat="server" />
             </div>
             <div class="col-md-3" style="margin-bottom: 40px;margin-top:60px">
                  <label for="txtMatricula" class="form-label">MATRÍCULA</label>
                  <asp:TextBox class="form-control rounded-pill" ID="txtMatricula"  runat="server" />
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
                   <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
                   <asp:TextBox type="date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
                 </div>
                 <div class="col-md-3" style="margin-bottom: 40px">
                   <label for="txtTelefono" class="form-label">TELÉFONO</label>
                   <asp:TextBox type="tel" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
                 </div>
             </div>
               
                
             <div class="row justify-content-center">
              
               <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                 <asp:TextBox class="form-control rounded-pill" ID="txtDireccion" runat="server" />
               </div>
                <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtEmail" class="form-label">E-MAIL</label>
                 <asp:TextBox type="email" class="form-control rounded-pill" ID="txtEmail" runat="server" />
               </div>
              </div>
            </div>
        </div>
 


        <div id="especialidades" class="container tab-pane fade"><br>
            
         <div class="estilo">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                 <div class="row justify-content-center" style="margin-bottom: 40px;margin-top:40px"">
                   <div class="col-md-3">
                     <asp:Label Text="ESPECIALIDAD" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                     <asp:DropDownList ID="ddlistEspecialidad" class="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                   </div>
                  </div>

                   <div class="row justify-content-center" style="margin-bottom: 40px">
                       <div class="col-md-3">
                         <asp:Label Text="DÍA" ID="lblDias" Enabled="false" CssClass="form-label" runat="server" />
                         <asp:DropDownList ID="ddlistDias" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDias_SelectedIndexChanged">
                             <asp:ListItem Text="Seleccionar" />
                             <asp:ListItem Text="Lunes" />
                             <asp:ListItem Text="Martes" />
                             <asp:ListItem Text="Miércoles" />
                             <asp:ListItem Text="Jueves" />
                             <asp:ListItem Text="Viernes" />
                             <asp:ListItem Text="Sábado" />
                         </asp:DropDownList>              
                       </div>
                     </div>

                    <div class="row justify-content-center" style="margin-bottom: 40px">
                       <div class="col-md-1" >
                           <asp:Label Text="RANGO HORARIO" CssClass="form-label" runat="server" />
                          <asp:DropDownList ID="ddlistEntrada" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged"/>
                       </div>
                       <div class="col-md-1" style="margin:25px 0px 0px 0px">
                           <asp:TextBox ID="txtHoraSalida" Enabled="false"  CssClass="form-select rounded-pill" DataFormatString="HH:mm" AutoPostBack="true" runat="server" />
                       </div>
                    </div>

                       <div class="row justify-content-center">
                           <div class="col-md-3" style="margin:0px 0px 40px 550px">
                             <asp:Button  ID="btnAgregarDia" Text="+ DÍA" CssClass="btn btn-primary rounded-pill" Enabled="false" OnClick="Click_AgregarDia" AutoPostBack="true" runat="server" />
                           </div>
                       </div>   
                     
                    <div>
                         <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoPostback="true"  AutoGenerateColumns="False" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
                            <Columns>
                                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="ESPECIALIDAD" />
                                <asp:BoundField datafield = "NombreDia" HeaderText ="DÍA" />
                                <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}" HeaderText ="ENTRADA" />              
                                <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}" HeaderText ="SALIDA" />
                                
                            </Columns>
                           </asp:gridview>
                    </div>
                   
                </ContentTemplate>
              </asp:UpdatePanel>
                
                </div>
            </div>
      
 

    <div id="usuario" class="container tab-pane fade">
     <div class="estilo">
            <div class="container">
               <div class="row d-flex justify-content-center" style="margin-top:60px">
                   <div class="col-md-3">
                  <label for="txtNombreUsuario" class="form-label">USUARIO</label>
                  <asp:TextBox class="form-control rounded-pill" ID="txtNombreUsuario" runat="server" />
                </div>
               </div>

               <div class="row justify-content-center" style="margin-top:40px">
                    <div class="col-md-3" >
                  <label for="txtContraseña" class="form-label">CONTRASEÑA</label>
                  <asp:TextBox class="form-control rounded-pill" type="Password" ID="txtContraseña" runat="server" />
                </div>
               </div>

               <div class="row justify-content-center" style="margin:40px 0px 60px 320px">
                    
                   <div class="col-md-3">
                    <asp:Button class="btn btn-primary rounded-pill" Font-Size="Small" Font-Bold="true" Text="ACEPTAR" OnClick="Click_Aceptar" runat="server" />
                  </div>
               </div>
             </div>
         </div>
    </div>
 </div>
 

     

</asp:Content>
