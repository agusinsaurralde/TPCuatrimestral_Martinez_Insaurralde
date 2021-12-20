<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.PRUEBA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


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
                  <asp:TextBox MaxLength="8" class="form-control rounded-pill" ID="txtDNI"  runat="server" />
                  <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDNI" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese un DNI válido" ControlToValidate="txtDNI" Runat="server" Display="Dynamic" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                     <asp:CustomValidator ID="CustomValidatorDNI" OnServerValidate="CustomValidatorDNI_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El DNI ingresado ya existe" ControlToValidate="txtDNI" Display="Dynamic"></asp:CustomValidator>
                     <asp:CustomValidator ID="CustomValidatorDNIInactivo" OnServerValidate="CustomValidatorDNIInactivo_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El DNI ingresado pertenece a un médico inactivo" ControlToValidate="txtDNI" Display="Dynamic"></asp:CustomValidator>
                    
                  </div>
             </div>
             <div class="col-md-3" style="margin-bottom: 40px;margin-top:60px">
                  <label for="txtMatricula" class="form-label">MATRÍCULA</label>
                  <asp:TextBox MaxLength="10" class="form-control rounded-pill" ID="txtMatricula"  runat="server" />
                 <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtMatricula" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese una matrícula válido" ControlToValidate="txtMatricula" Runat="server" Display="Dynamic" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                     <asp:CustomValidator ID="CustomValidatorMatricula" OnServerValidate="CustomValidatorMatricula_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*La matrícula ingresada ya existe" ControlToValidate="txtMatricula" Display="Dynamic"></asp:CustomValidator>
                  </div>

             </div>
          </div>
        
          <div class="row justify-content-center">
            <div class="col-md-3" style="margin-bottom: 40px"">
              <label for="txtApellido" class="form-label">APELLIDO</label>
              <asp:TextBox MaxLength="50" class="form-control rounded-pill" ID="txtApellido"  runat="server" />
                 <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtApellido" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese un apellido válido" ControlToValidate="txtApellido" Runat="server" Display="Dynamic" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                 </div>
            </div>
              <div class="col-md-3" style="margin-bottom: 40px">
              <label for="txtNombre" class="form-label">NOMBRE</label>
              <asp:TextBox MaxLength="50" class="form-control rounded-pill" ID="txtNombre"  runat="server" />
                  <div style="font-size:13px">
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtNombre" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ErrorMessage="*Ingrese un nombre válido" ControlToValidate="txtNombre" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                 </div>
            </div>
           </div>
                
            <div class="row justify-content-center">
                 <div class="col-md-3" style="margin-bottom: 40px">
                   <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
                   <asp:TextBox type="date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
                     <div style="font-size:13px">
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                          <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="*Ingrese una fecha válida" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RangeValidator>
                    </div>
                 </div>
                 <div class="col-md-3" style="margin-bottom: 40px">
                   <label for="txtTelefono" class="form-label">TELÉFONO</label>
                   <asp:TextBox MaxLength="10" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
                     <div style="font-size:13px">
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtTelefono" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ErrorMessage="*Ingrese un número válido" ControlToValidate="txtTelefono" Runat="server" Display="Dynamic" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                     </div>
                 </div>
             </div>
               
                
             <div class="row justify-content-center">
              
               <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                 <asp:TextBox MaxLength="320" class="form-control rounded-pill" ID="txtDireccion" runat="server" />
                   <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDireccion" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
               </div>
                <div class="col-md-3" style="margin-bottom: 70px">
                 <label for="txtEmail" class="form-label">E-MAIL</label>
                 <asp:TextBox MaxLength="320" type="email" class="form-control rounded-pill" ID="txtEmail" runat="server" />
                    <div style="font-size:13px">
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtEmail" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                         <asp:CustomValidator ID="CustomValidatorEmail" OnServerValidate="CustomValidatorEmail_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El email ingresado ya existe" ControlToValidate="txtEmail" Display="Dynamic"></asp:CustomValidator>
                     </div>
               </div>
              </div>
            </div>
            <div class="row  justify-content-end" style="margin-bottom: 60px; margin-top:30px">
                <div class="col-md-2"><asp:Button ID="btn0a1" runat="server" Text="SIGUIENTE >" Font-Bold="true" Font-Size="Small"  CssClass="btn btn-primary rounded-pill" OnClick="btn0a1_Click" /></div>
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
                     <asp:DropDownList ID="ddlistEspecialidad" class="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                        <div style="font-size:13px">
                               <asp:CustomValidator ID="CustomValidatorEspecialidad" OnServerValidate="CustomValidatorEspecialidad_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*Debe seleccionar una especialidad" ControlToValidate="ddlistEspecialidad" Display="Dynamic"></asp:CustomValidator>
                         </div>
                   </div>
                  </div>

                    <div class="row justify-content-center">
                         <div class="col-md-4" style="margin-bottom:5px"><asp:Label Text="DÍA" Font-Bold="true" Font-Size="Small" ID="lblDias" Enabled="false" CssClass="form-label" runat="server" /></div>
                    </div>
                   <div class="row justify-content-center" style="margin-bottom: 40px">
                       <div class="col-md-4">
                         
                         <asp:DropDownList ID="ddlistDias" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDias_SelectedIndexChanged">
                             <asp:ListItem Text="Seleccionar" />
                             <asp:ListItem Text="Lunes" />
                             <asp:ListItem Text="Martes" />
                             <asp:ListItem Text="Miércoles" />
                             <asp:ListItem Text="Jueves" />
                             <asp:ListItem Text="Viernes" />
                             <asp:ListItem Text="Sábado" />
                         </asp:DropDownList>  
                           <div style="font-size:13px">
                               <asp:CustomValidator ID="CustomValidatorDia" OnServerValidate="CustomValidatorDia_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*Debe seleccionar un día" ControlToValidate="ddlistDias" Display="Dynamic"></asp:CustomValidator>
                         </div>
                       </div>
                     </div>

                    <div class="row justify-content-center">
                        <div class="col-md-4" style="margin-bottom:5px"><asp:Label Text="RANGO HORARIO" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" /></div>
                    </div>                        
                    <div class="row justify-content-center">
                       <div class="col-md-2" >
                          <asp:DropDownList ID="ddlistEntrada" Enabled="false" CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged"/>
                             <div style="font-size:13px">
                                     <asp:CustomValidator ID="CustomValidatorEntrada" OnServerValidate="CustomValidatorEntrada_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*Debe seleccionar un horario" ControlToValidate="ddlistEntrada" Display="Dynamic"></asp:CustomValidator>
                               </div>
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
                    <div class="row justify-content-center">
                        <asp:Label id="errorEspecialidad" Text="*Debe agregar un día hábil" Visible="false" ForeColor="#CC0000" runat="server" />
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

            <div class="row justify-content-md-between" style="margin-bottom: 60px; margin-top:60px">
                <div class="col-md-2" style="margin-left:80px">
                       <asp:Button ID="btn1a0" runat="server" OnClick="btn1a0_Click" Text="< ANTERIOR" CausesValidation="false" CssClass="btn btn-outline-secondary rounded-pill" Font-Bold="true" Font-Size="Small" /> 
                 </div>
                <div class="col-md-2"> 
                    <asp:Button ID="btn1a2" runat="server" OnClick="btn1a2_Click" Text="SIGUIENTE >" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" />

                </div>
            </div>
        </asp:View>

        <asp:View ID="vistaUsuario" runat="server">
            <div class="estilo">
            <div class="container">
               <div class="row d-flex justify-content-center" style="margin-top:60px">
                   <div class="col-md-3">
                        <label for="txtNombreUsuario" class="form-label">USUARIO</label>
                         <asp:TextBox  MaxLength="15" CssClass="form-control rounded-pill" ID="txtNombreUsuario" runat="server" />
                       <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtNombreUsuario" FilterMode="InvalidChars" InvalidChars=" @/()\?¿+*´;,.-}{][°|¡!=&%$#´'" runat="server" />
                         <div style="font-size:13px">
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtNombreUsuario" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                             <asp:CustomValidator ID="CustomValidator1" OnServerValidate="CustomValidator1Usuario_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El nombre de usuario ingresado ya existe" ControlToValidate="txtNombreUsuario" Display="Dynamic"></asp:CustomValidator>
                         </div>
                </div>
               </div>

               <div class="row justify-content-center" style="margin-top:40px">
                    <div class="col-md-3" >
                       <label for="txtContraseña" class="form-label">CONTRASEÑA</label>
                       <asp:TextBox MaxLength="15" class="form-control rounded-pill" type="Password" ID="txtContraseña" runat="server" />
                        <div style="font-size:13px">
                             <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtContraseña" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                         </div>
                     </div>
               </div>

               <div class="row justify-content-center" style="margin:40px 0px 60px 320px">
                    
               </div>
             </div>


                <div class="row justify-content-md-between" style="margin-bottom: 60px; margin-top:60px">
                <div class="col-md-2" style="margin-left:80px">
                       <asp:Button ID="btn2a1" runat="server" OnClick="btn2a1_Click" Text="< ANTERIOR" CausesValidation="false" CssClass="btn btn-outline-secondary rounded-pill" Font-Bold="true" Font-Size="Small" />
                 </div>
                <div class="col-md-2"> 
                    <asp:Button ID="btnAceptar" runat="server" OnClick="Aceptar_Click" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" Text="ACEPTAR" />
                </div>
            </div>
        </div>


            
           
        </asp:View>
    </asp:MultiView>

    <!-- modal verificación -->
    <asp:Button  style="display:none" runat="server" ID="btnVerificacion" />
   <ajaxToolkit:ModalPopupExtender ID="verificacion_Modal" CancelControlID="exitV" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="verificacion_Modal" TargetControlID="btnVerificacion" PopupControlID="PanelVerificacion">
    </ajaxToolkit:ModalPopupExtender>
   

    <asp:Panel ID="PanelVerificacion" BackColor="White" runat="server">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                     <div class="modal-header">
                         <asp:Label ID="lblTituloAlertModal" class="modal-title" Font-Bold="true" Font-Size="X-Large" runat="server" />
                       <button id="exitV" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                     </div>
                     <div class="modal-body">
                         <asp:Label ID="lblVerificacion" runat="server" />
                       
                     </div>
                </ContentTemplate>
        </asp:UpdatePanel>
        <div class="modal-footer">
                <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" ID="btnCerrar" OnClick="btnCerrar_Click" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>

</asp:Content>