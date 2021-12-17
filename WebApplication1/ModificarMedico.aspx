<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web21" %>

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

        function validarAgregarEsp() {
            var grilla = document.getElementById("<% = grillaDiasAgregados.ClientID %>");

            if (grilla === null) {
                alert("Debe agregar una especialidad");
                return false;
            }

            return true;
        }

        function validarAgregarDia() {
            var grilla = document.getElementById("<% = grillaAgregarDia.ClientID %>");
            
            if (grilla === null) {
                alert("Debe agregar un día");
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






    <br />
    <h1>Modificar Médico</h1>
    <hr />
    <br />

    <div>
       <asp:Menu ID="Menu" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="50px" Font-Bold="true" Font-Size="Small" StaticSelectedStyle-BackColor="LightBlue" runat="server" OnMenuItemClick="Menu_MenuItemClick">
           <Items>
               <asp:MenuItem Text="DATOS PERSONALES" Value="0" Selected="true"></asp:MenuItem>
               <asp:MenuItem Text="ESPECIALIDADES" Value="1"></asp:MenuItem>
               <asp:MenuItem Text="USUARIO" Value="2"></asp:MenuItem>            
           </Items>
       </asp:Menu>
    </div>

    <div>
        <asp:MultiView ID="multiview" ActiveViewIndex="0" runat="server">
        
           <asp:View ID="vistaDatos" runat="server">
                     <div class="estilo">
                <div class="row justify-content-center">
                   <div class="col-md-3" style="margin-bottom: 40px; margin-top:60px">
                        <label for="txtDNI" class="form-label">DNI</label>
                        <asp:TextBox ClientIDMode="Static" class="form-control rounded-pill" ID="txtDNI"  runat="server" />
                   </div>
                   <div class="col-md-3" style="margin-bottom: 40px;margin-top:60px">
                        <label for="txtMatricula" class="form-label">MATRÍCULA</label>
                        <asp:TextBox ClientIDMode="Static" class="form-control rounded-pill" ID="txtMatricula"  runat="server" />
                   </div>
                </div>
              
                <div class="row justify-content-center">
                  <div class="col-md-3" style="margin-bottom: 40px"">
                    <label for="txtApellido" class="form-label">APELLIDO</label>
                    <asp:TextBox ClientIDMode="Static" class="form-control rounded-pill" ID="txtApellido"  runat="server" />
                  </div>
                    <div class="col-md-3" style="margin-bottom: 40px">
                    <label for="txtNombre" class="form-label">NOMBRE</label>
                    <asp:TextBox ClientIDMode="Static" class="form-control rounded-pill" ID="txtNombre"  runat="server" />
                  </div>
                 </div>
                      
                  <div class="row justify-content-center">
                       <div class="col-md-3" style="margin-bottom: 40px">
                         <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
                         <asp:TextBox ClientIDMode="Static" type="date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
                       </div>
                       <div class="col-md-3" style="margin-bottom: 40px">
                         <label for="txtTelefono" class="form-label">TELÉFONO</label>
                         <asp:TextBox ClientIDMode="Static" type="tel" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
                       </div>
                   </div>
                     
                      
                   <div class="row justify-content-center">
                    
                     <div class="col-md-3" style="margin-bottom: 70px">
                       <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                       <asp:TextBox ClientIDMode="Static" class="form-control rounded-pill" ID="txtDireccion" runat="server" />
                     </div>
                      <div class="col-md-3" style="margin-bottom: 70px">
                       <label for="txtEmail" ClientIDMode="Static" class="form-label">E-MAIL</label>
                       <asp:TextBox type="email" ClientIDMode="Static" class="form-control rounded-pill" ID="txtEmail" runat="server" />
                     </div>
                    </div>
                  </div>

               <div class="row justify-content-end">
                   <div class="col-md-3">
                       <asp:Button Text="ACEPTAR" Font-Bold="true" Font-Size="Small" ID="btnAceptarDatos" OnClientClick="return validarVistaDatos()" OnClick="btnAceptarDatos_Click" CssClass="btn btn-primary rounded-pill" runat="server" />
                   </div>
               </div>
           </asp:View>



            <asp:View ID="vistaEsp" runat="server">
                  <div class="d-flex flex-row" style="margin-bottom:20px; margin-top:50px">
                       <div class="p2" style=" margin-right:20px"><h4>Especialidades</h4></div>
                       <div class="p-0"><asp:Button class="btn btn-primary rounded-pill" id="btnAgregar" Font-Bold="true" Font-Size="X-Small" OnClick="btnAgregar_Click" Text="AGREGAR +" runat="server" /></div>
                  </div>
                 
                   <div style="display: flex; flex-direction: row">

                      <%foreach (var item in listaEsp)
                        {
                              string eliminar = "eliminar";
                              string agregarDia = "agregarDia";
                              if (item.Estado == true)
                              { %>
                                         <div class="card border-primary mb-3" style="max-width: 18rem; margin: 10px 10px 10px 10px">
                                       <div class="card-body text-primary">
                                             <h6 class="card-text"><%: item.especialidad.Nombre%></h6>
                                            <a href="ModificarMedico.aspx?id=<%:item.especialidad.Id%>&accion=<%:agregarDia%>" style="font-weight:bold; font-size:10px" class="btn btn-primary rounded-pill">AGREGAR DÍA +</a>
                                           <a style="font-weight:bold;font-size:10px"" href="ModificarMedico.aspx?id=<%:item.especialidad.Id%>&accion=<%:eliminar %>" class="btn btn-primary rounded-pill">X</a>
                                        </div>
                                    </div>
                               <%}%>
                       <% } %>
                  </div>

               <h5>Horarios</h5> 
                  <asp:GridView CssClass="table table-hover" BorderStyle="None" ID="Grilla" AutoPostback="true" HeaderStyle-CssClass="table-primary" HeaderStyle-Font-Size="Small" runat="server" AutoGenerateColumns="False" OnRowDeleting="Grilla_RowDeleting" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" DataKeyNames="ID">
                       <Columns>
                           <asp:BoundField datafield = "ID" HeaderText ="#" />
                           <asp:BoundField datafield = "especialidad.Nombre" HeaderText ="Especialidad" />
                           <asp:BoundField datafield = "NombreDia" HeaderText ="Día" />
                           <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}"  HeaderText ="Entrada" />
                           <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}"  HeaderText ="Salida" />
                           <asp:CommandField ButtonType="Image" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" SelectImageUrl="Iconos/pencil-square.svg" />   
                           <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                                
                       </Columns>
                   </asp:gridview>

           </asp:View>


            <asp:View ID="vistaUsuario" runat="server">
               <div class="estilo">
             
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

                </div>

                <div class="row justify-content-end">
                   <div class="col-md-3">
                       <asp:Button Text="ACEPTAR" Font-Bold="true" Font-Size="Small" ID="btnAceptarUsuario" OnClientClick="return validarVistaUsuario()" OnClick="btnAceptarUsuario_Click" CssClass="btn btn-primary rounded-pill" runat="server" />
                   </div>
               </div>
           </asp:View>

        </asp:MultiView>
    </div>




<!-- modal eliminar especialidad -->
   <asp:Button  style="display:none" runat="server" ID="btnEliminarEspecialidadModal" />
   <ajaxToolkit:ModalPopupExtender ID="btnEliminarEspecialidad_Modal" CancelControlID="exitEliminarEspecialidad" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminarEspecialidad_Modal" TargetControlID="btnEliminarEspecialidadModal" PopupControlID="PanelEliminarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelEliminarEspecialidad" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exitEliminarEspecialidad" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar la especialidad?</label>
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" ID="btnCancelarEliminarEsp" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" OnClick="btnCancelarEliminarEsp_Click" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminarEspecialidad" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="btnAceptarEliminarEspecialidad_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>


<!-- modal agregar dia a especialidad existente -->
    <asp:Button  style="display:none" runat="server" ID="btnModalAgregarDia" />
   <ajaxToolkit:ModalPopupExtender ID="btnModalAgregarDia_Modal" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnModalAgregarDia_Modal" TargetControlID="btnModalAgregarDia" PopupControlID="PanelAgregarDia">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarDia" BackColor="White" Width="300px" runat="server">
        
        <div class="modal-header">
          <h5 class="modal-title" >Agregar Día</h5>
        </div>
        <div class="modal-body"> 
            <asp:UpdatePanel runat="server">
                 <ContentTemplate>
                  <div style="margin-bottom:25px">
                     <div style="margin-bottom:8px"><asp:Label Text="DÍA" CssClass="form-label" Font-Bold="true" Font-Size="Small" runat="server" /></div>
                      <div>
                          <asp:DropDownList ID="ddlistAgregarDiaEspecialidadExistente" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true">
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
                <div class="estilo" style="margin-bottom:25px">
                    <div class="row">
                         <div class="col">
                             <div style="margin-bottom:8px"><asp:Label Text="RANGO HORARIO" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" /></div>
                             <div>
                              <asp:DropDownList ID="ddlistEntradaAgregarDia" CssClass="form-select rounded-pill" OnSelectedIndexChanged="ddlistEntradaAgregarDia_SelectedIndexChanged" runat="server" AutoPostBack="true"  />
                             </div>
                         </div>
                         <div class="col" style="margin-top:35px">
                              <asp:TextBox ID="txtSalidaAgregarDia"  Enabled="false" DataFormatString="HH:mm" AutoPostBack="true"  CssClass="form-control rounded-pill" runat="server" />
                         </div>
                     </div>
               </div>
              
                <div class="row">
                    <div class="col">
                        <asp:Button Text="+ DÍA" Font-Bold="true" Font-Size="Small" ID="btnAgregarDiaAGrilla" Enabled="false" CssClass="btn btn-primary rounded-pill" OnClick="btnAgregarDiaAGrilla_Click" runat="server" />
                    </div>
                </div>

                 <div>
                     <asp:GridView  CssClass="table table-hover" ClientIDMode="Static" runat="server" id="grillaAgregarDia" AutoGenerateColumns="false" AutoPostback="true" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small">
                         <Columns>
                            <asp:BoundField datafield = "NombreDia" HeaderText="Dia" />
                            <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}" HeaderText ="Entrada" />
                             <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}" HeaderText ="Salida" />
                        </Columns>
                     </asp:GridView>
                 </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <div class="modal-footer">
          <asp:Button Text="CERRAR" id="btnCancelarDia" OnClick="btnCancelarDia_Click" class="btn btn-outline-secondary rounded-pill" Font-Bold="true" Font-Size="Small" BorderStyle="None" data-bs-dismiss="modal"  runat="server" />
          <asp:Button  ID="btnAceptarAgregarDia" class="btn btn-primary rounded-pill" OnClientClick="return validarAgregarDia()" Text="ACEPTAR" Font-Bold="true" Font-Size="Small" OnClick="btnAceptarAgregarDia_Click"  runat="server" />
        </div>

    </asp:Panel>


<!-- modal agregar especialidad -->
   <asp:Button  style="display:none" runat="server" ID="btnEspecialidadModal" />
   <ajaxToolkit:ModalPopupExtender ID="btnAgregarEspecialidad_Modal"  CancelControlID="exitAgregar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnAgregarEspecialidad_Modal" TargetControlID="btnEspecialidadModal" PopupControlID="PanelAgregarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarEspecialidad" BackColor="White" runat="server">

        <div class="modal-header">
          <h5 class="modal-title" >Agregar Especialidad</h5>
            <asp:Button id="exitAgregar"  class="btn-close" data-bs-dismiss="modal" aria-label="Cancelar" runat="server" />
        </div>

        <div class="modal-body"> 
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <div class="estilo">
               

                    <div class="row" style="margin-bottom: 30px;margin-top:20px"">
                      <div class="col">
                        <asp:Label Text="ESPECIALIDAD" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlistEspecialidad" class="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                      </div>
                     </div>

                      <div class="row" style="margin-bottom: 30px">
                          <div class="col">
                            <asp:Label Text="DÍA" ID="lblDias" Enabled="false" CssClass="form-label" runat="server" />
                            <asp:DropDownList ID="ddlistDiaAgregar" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDiaAgregar_SelectedIndexChanged">
                                <asp:ListItem Text="Seleccionar" />
                                <asp:ListItem Text="Lunes" />
                                <asp:ListItem Text="Martes" />
                                <asp:ListItem Text="Miércoles" />
                                <asp:ListItem Text="Jueves" />
                                <asp:ListItem Text="Viernes" />
                                <asp:ListItem Text="Sábado" />
                            </asp:DropDownList>              
                          </div>
                          <div class="col" >
                              <asp:Label Text="RANGO HORARIO" CssClass="form-label" runat="server" />
                             <asp:DropDownList ID="ddlistEntradaAgregar" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntradaAgregar_SelectedIndexChanged"/>
                          </div>
                          <div class="col" style="margin:25px 0px 0px 0px">
                              <asp:TextBox ID="txtSalidaAgregar" Enabled="false"  CssClass="form-select rounded-pill" DataFormatString="HH:mm" AutoPostBack="true" runat="server" />
                          </div>
                        </div>

                      

                          <div class="row">
                              <div class="col" style="margin:0px 0px 25px 600px">
                                <asp:Button  ID="btnAgregarDia" Text="+ DÍA" CssClass="btn btn-primary rounded-pill" Enabled="false" OnClick="btnAgregarDia_Click" AutoPostBack="true" runat="server" />
                              </div>
                          </div>   
                  </div>

                         <div>
                             <asp:GridView CssClass="table table-hover" ClientIDMode="Static" runat="server" id="grillaDiasAgregados" AutoGenerateColumns="false" AutoPostback="true" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small">
                                 <Columns>
                                     <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="ESPECIALIDAD" />
                                     <asp:BoundField datafield = "NombreDia" HeaderText ="DÍA" />
                                     <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}" HeaderText ="ENTRADA" />              
                                     <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}" HeaderText ="SALIDA" />
                                            
                                 </Columns>
                             </asp:GridView>
                         </div>
                    
                </ContentTemplate>
              </asp:UpdatePanel>
                
          </div>
             
        <div class="modal-footer">
          <asp:Button Text="CANCELAR" id="btnCerrar" class="btn btn-outline-secondary rounded-pill" OnClick="btnCancelar_Click" Font-Bold="true" Font-Size="Small" BorderStyle="None" data-bs-dismiss="modal"  runat="server" />
          <asp:Button  ID="btnAceptarAgregar" class="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Bold="true" OnClientClick="return validarAgregarEsp()" OnClick="btnAceptarAgregar_Click" Font-Size="Small"  runat="server" />
        </div>

        
    </asp:Panel>



<!-- modal eliminar dia -->
   <asp:Button  style="display:none" runat="server" ID="btnModalEliminar" />
   <ajaxToolkit:ModalPopupExtender ID="btnEliminar_ModalPopupExtender" CancelControlID="exitEliminar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminar_ModalPopupExtender" TargetControlID="btnModalEliminar" PopupControlID="Panel">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exitEliminar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar el día?</label>
          
        </div>
        <div class="modal-footer">
            <asp:Button class="btn btn-outline-secondary rounded-pill" Text="CANCELAR" BorderStyle="None" Font-Bold="true" data-bs-dismiss="modal" Font-Size="Small" AutoPostback="true" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminar" Text="ACEPTAR" Font-Bold="true" Font-Size="Small" OnClick="btnAceptarEliminar_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>

<!-- modal editar dia-->
   <asp:Button  style="display:none" runat="server" ID="btnModalEditar" />
   <ajaxToolkit:ModalPopupExtender ID="btnEditar_ModalPopupExtender" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEditar_ModalPopupExtender" TargetControlID="btnModalEditar" PopupControlID="PanelEditar">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelEditar" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Editar</h5>
            <asp:Button id="exitEditar" class="btn-close" data-bs-dismiss="modal" runat="server" />
        </div>
        <div class="modal-body">

            <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="margin-bottom:10px">
                    <asp:Label Text="DÍA" Font-Bold="true" CssClass="form-label"  Font-Size="Small" runat="server" />
                </div>
                <div class="col-md-6" style="margin-bottom:25px">
                     <asp:DropDownList ID="ddlistDia" CssClass="form-select rounded-pill" AutoPostBack="true" runat="server">
                         <asp:ListItem Text="Lunes" />
                         <asp:ListItem Text="Martes" />
                         <asp:ListItem Text="Miércoles" />
                         <asp:ListItem Text="Jueves" />
                         <asp:ListItem Text="Viernes" />
                         <asp:ListItem Text="Sábado" />
                     </asp:DropDownList>
                </div>


          
            <div class="row">
                <div style="margin-bottom:10px">
                 <asp:Label Text="RANGO HORARIO" Font-Bold="true" CssClass="form-label" Font-Size="Small" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlistEntrada" CssClass="form-select rounded-pill" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged" runat="server"> </asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <asp:TextBox id="txtHoraSalida" CssClass="form-select rounded-pill" Enabled="false" runat="server" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
            
          
        </div>
        <div class="modal-footer" >
            <div class="col-md-6">
                <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />         
                 <asp:Button CssClass="btn btn-primary rounded-pill" ID="btnAceptarEditar" Text="ACEPTAR" Font-Bold="true" Font-Size="Small" OnClick="btnAceptarEditar_Click" runat="server" />
            </div>
        </div>
    </asp:Panel>



</asp:Content>
       
              
              
  
