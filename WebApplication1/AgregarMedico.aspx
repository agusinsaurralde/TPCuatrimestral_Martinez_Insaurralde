<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.PRUEBA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function validarVistaDatos() {
            var dni = document.getElementById("<% = txtDNI.ClientID %>").value;
            var matricula = document.getElementById("<% = txtMatricula.ClientID %>").value;
            var apellido = document.getElementById("<% = txtApellido.ClientID %>").value;
            var nombre = document.getElementById("<% = txtNombre.ClientID %>").value;
            var telefono = document.getElementById("<% = txtTelefono.ClientID %>").value;
            var fecha = document.getElementById("<% = txtFechaNac.ClientID %>").value;
            var email = document.getElementById("<% = txtEmail.ClientID %>").value;
            var direccion = document.getElementById("<% = txtDireccion.ClientID %>").value;
            var valido = true;

            if (dni === "") {
                $("#txtDNI").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtDNI").removeClass("is-invalid");
            }

            if (matricula === "") {
                $("#txtMatricula").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtDNI").removeClass("is-invalid");
            }

            if (apellido === "") {
                $("#txtApellido").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtApellido").removeClass("is-invalid");
            }

            if (nombre === "") {
                $("#txtNombre").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtNombre").removeClass("is-invalid");
            }

            if (telefono === "") {
                $("#txtTelefono").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtTelefono").removeClass("is-invalid");
            }

            if (fecha === "") {
                $("#txtFechaNac").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtFechaNac").removeClass("is-invalid");
            }

            if (email === "") {
                $("#txtEmail").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtEmail").removeClass("is-invalid");
            }

            if (direccion === "") {
                $("#txtDireccion").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtDireccion").removeClass("is-invalid");
            }

            if (!valido) {
                return false;
            }
            return true;
        }

        function validarVistaEspecialidad() {
            var grilla = document.getElementById("Grilla");
            /*var especialidad = document.getElementById("ddlistEspecialidad");
            var hora = document.getElementById("ddlistEntrada");
            var dia = document.getElementById("ddlistDias");

            var indiceE = especialidad.options[especialidad.selectedIndex].index;
            var indiceH = hora.options[hora.selectedIndex].index;
            var indiceD = dia.options[dia.selectedIndex].index;

            if (grilla === 0) {
                if (indiceE === 0) {
                    $("#ddlistEspecialidad").addClass("is-invalid");
                }
                else {
                    $("#ddlistEspecialidad").removeClass("is-invalid");

                }

                if (indiceH === 0) {
                    $("#ddlistEntrada").addClass("is-invalid");
                }
                else {
                    $("#ddlistEntrada").removeClass("is-invalid");
                }

                if (indiceD === 0) {
                    $("#ddlistEntrada").addClass("is-invalid");
                    
                }
                else {
                    $("#ddlistEntrada").removeClass("is-invalid");
                }
                return false;
            }*/

            if (grilla === null) {
                alert("Debe agregar una especialidad");
                return false;
            }

            return true;
        }

        function validarVistaUsuario() {
            var usuario = document.getElementById("<% = txtNombreUsuario.ClientID %>").value;
            var contraseña = document.getElementById("<% = txtContraseña.ClientID %>").value;
           
            var valido = true;

            if (usuario === "") {
                $("#txtNombreUsuario").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtNombreUsuario").removeClass("is-invalid");
            }

            if (contraseña === "") {
                $("#txtContraseña").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtContraseña").removeClass("is-invalid");
            }

            
            if (!valido) {
                return false;
            }
            return true;
        }
    </script>
    


    <h3 style="margin-top:40px">Agregar Médico</h3>
    <br />
    <div class="row estilo" style="margin-top:40px">
        <div class="col"><asp:Label Text="1.DATOS PERSONALES" Font-Size="Small" ID="lblDatos" runat="server" /></div>
        <div class="col"> <asp:Label Text="2.ESPECIALIDADES"  Font-Size="Small" ID="lblEspecialidades" runat="server" /></div>
        <div class="col"><asp:Label Text="3.USUARIO"  Font-Size="Small" ID="lblUsuario" runat="server" /></div>
    </div>
    <hr />

    <asp:MultiView ID="MultiView" runat="server">
        <asp:View ID="vistaDatos" runat="server">
            <div class="estilo">
          <div class="row justify-content-center">
             <div class="col-md-3" style="margin-bottom: 40px; margin-top:60px">
                  <label for="txtDNI" class="form-label">DNI</label>
                  <asp:TextBox type="number" class="form-control rounded-pill" ClientIDMode="Static" ID="txtDNI"  runat="server" />
             </div>
             <div class="col-md-3" style="margin-bottom: 40px;margin-top:60px">
                  <label for="txtMatricula" class="form-label">MATRÍCULA</label>
                  <asp:TextBox type="number" class="form-control rounded-pill" ClientIDMode="Static" ID="txtMatricula"  runat="server" />
             </div>
          </div>
        
          <div class="row justify-content-center">
            <div class="col-md-3" style="margin-bottom: 40px"">
              <label for="txtApellido" class="form-label">APELLIDO</label>
              <asp:TextBox  class="form-control rounded-pill" ClientIDMode="Static" ID="txtApellido"  runat="server" />
            </div>
              <div class="col-md-3" style="margin-bottom: 40px">
              <label for="txtNombre" class="form-label">NOMBRE</label>
              <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtNombre"  runat="server" />
            </div>
           </div>
                
            <div class="row justify-content-center">
                 <div class="col-md-3" style="margin-bottom: 40px">
                   <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
                   <asp:TextBox type="date" ClientIDMode="Static" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
                 </div>
                 <div class="col-md-3" style="margin-bottom: 40px">
                   <label for="txtTelefono" class="form-label">TELÉFONO</label>
                   <asp:TextBox type="number" ClientIDMode="Static" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
                 </div>
             </div>
               
                
             <div class="row justify-content-center">
              
               <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                 <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtDireccion" runat="server" />
               </div>
                <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtEmail" class="form-label">E-MAIL</label>
                 <asp:TextBox type="email" ClientIDMode="Static" class="form-control rounded-pill" ID="txtEmail" runat="server" />
               </div>
              </div>
            </div>
            <div class="row  justify-content-end" style="margin-bottom: 60px; margin-top:30px">
                <div class="col-md-2"><asp:Button ID="btn0a1" runat="server" Text="SIGUIENTE >" OnClientClick="return validarVistaDatos()" Font-Bold="true" Font-Size="Small"  CssClass="btn btn-primary rounded-pill" OnClick="btn0a1_Click" /></div>
            </div>
        </asp:View>

        <asp:View ID="vistaEspecialidades" runat="server">
             <div class="estilo">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row justify-content-center" style="margin-bottom: 5px; margin-top:60px">
                        <div class="col-md-4">
                            <asp:Label Text="ESPECIALIDAD" ID="lblEspecialidad" CssClass="form-label" Font-Bold="true" Font-Size="Small" runat="server" />
                            </div>
                    </div>
                 <div class="row justify-content-center" style="margin-bottom: 40px">
                   <div class="col-md-4" >
                     <asp:DropDownList ID="ddlistEspecialidad" ClientIDMode="Static" class="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                   </div>
                  </div>

                    <div class="row justify-content-center">
                         <div class="col-md-4" style="margin-bottom:5px"><asp:Label Text="DÍA" Font-Bold="true" Font-Size="Small" ID="lblDias" Enabled="false" CssClass="form-label" runat="server" /></div>
                    </div>
                   <div class="row justify-content-center" style="margin-bottom: 40px">
                       <div class="col-md-4">
                         
                         <asp:DropDownList ID="ddlistDias" ClientIDMode="Static" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDias_SelectedIndexChanged">
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

                    <div class="row justify-content-center">
                        <div class="col-md-4" style="margin-bottom:5px"><asp:Label Text="RANGO HORARIO" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" /></div>
                    </div>                        
                    <div class="row justify-content-center">
                       <div class="col-md-2" >
                          <asp:DropDownList ID="ddlistEntrada" ClientIDMode="Static" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged"/>
                       </div>
                       <div class="col-md-2">
                           <asp:TextBox ID="txtHoraSalida" Enabled="false"  CssClass="form-select rounded-pill" DataFormatString="HH:mm" AutoPostBack="true" runat="server" />
                       </div>
                    </div>
                            
               

                       <div class="row justify-content-center" style="margin:40px 0px 40px 395px">
                           <div class="col-md-2">
                             <asp:Button  ID="btnAgregarDia" Text="+ DÍA" CssClass="btn btn-primary rounded-pill" Enabled="false" OnClick="Click_AgregarDia" AutoPostBack="true" runat="server" />
                           </div>
                       </div>   
               
                    <div>
                         <asp:GridView CssClass="table table-hover" ClientIDMode="Static" ID="Grilla"  runat="server" AutoPostback="true"  AutoGenerateColumns="False" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
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

            <div class="row justify-content-md-between" style="margin-bottom: 60px; margin-top:60px">
                <div class="col-md-2" style="margin-left:80px">
                       <asp:Button ID="btn1a0" runat="server" OnClick="btn1a0_Click" Text="< ANTERIOR" CssClass="btn btn-outline-secondary rounded-pill" Font-Bold="true" Font-Size="Small" /> 
                 </div>
                <div class="col-md-2"> 
                    <asp:Button ID="btn1a2" runat="server" OnClick="btn1a2_Click" Text="SIGUIENTE >" OnClientClick="return validarVistaEspecialidad()" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" />

                </div>
            </div>
        </asp:View>

        <asp:View ID="vistaUsuario" runat="server">
            <div class="estilo">
            <div class="container">
               <div class="row d-flex justify-content-center" style="margin-top:60px">
                   <div class="col-md-3">
                  <label for="txtNombreUsuario" class="form-label">USUARIO</label>
                  <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtNombreUsuario" runat="server" />
                </div>
               </div>

               <div class="row justify-content-center" style="margin-top:40px">
                    <div class="col-md-3" >
                  <label for="txtContraseña" class="form-label">CONTRASEÑA</label>
                  <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" type="Password" ID="txtContraseña" runat="server" />
                </div>
               </div>

               <div class="row justify-content-center" style="margin:40px 0px 60px 320px">
                    
               </div>
             </div>


                <div class="row justify-content-md-between" style="margin-bottom: 60px; margin-top:60px">
                <div class="col-md-2" style="margin-left:80px">
                       <asp:Button ID="btn2a1" runat="server" OnClick="btn2a1_Click" Text="< ANTERIOR" CssClass="btn btn-outline-secondary rounded-pill" Font-Bold="true" Font-Size="Small" />
                 </div>
                <div class="col-md-2"> 
                    <asp:Button ID="btnAceptar" runat="server" OnClick="Aceptar_Click" OnClientClick="return validarVistaUsuario()" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" Text="ACEPTAR" />
                </div>
            </div>
        </div>


            
           
        </asp:View>
    </asp:MultiView>

    <!-- Modal -->

    <asp:Button  style="display:none" runat="server" ID="btnAceptarFalso" />
   <ajaxToolkit:ModalPopupExtender ID="btnRevision_Modal" CancelControlID="exitCheck" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnRevision_Modal" TargetControlID="btnAceptarFalso" PopupControlID="PanelCheck">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelCheck" Width="300px" BackColor="White" runat="server">
        <div class="modal-header">
          
            <asp:Label ID="lblTituloModalAlert" Text="Medico." class="modal-title;" Font-Bold="true" Font-Size="X-Large" runat="server" />
          
          <button id="exitCheck" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body" style="margin:30px 0px 30px 0px">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <div class="row">
                      <div class="col">
                          <asp:Label ID="lblMedicoTituloNombre" Text="NOMBRE MEDICO: " Font-Bold="true" Font-Size="Small" runat="server" />
                          <asp:Label id="lblNombreMedico"  runat="server" />
                          <asp:Label ID="lblNombreUsuarioTitulo" runat="server" />
                          <asp:Label ID="lblNombreUsuario" runat="server" />
                      </div>
                  </div>
                  <div class="row">
                      <div class="col">
                            <asp:Label ID="lblAgregarFunciono" runat="server"/> 
                      </div>
                  </div>
              </ContentTemplate>
       </asp:UpdatePanel>
            
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnCerrarMedico" Text="CERRAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" OnClick="btnCerrarMedico_Click" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>


</asp:Content>
