<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="WebApplication1.AltaMedico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
   <br />
    <h3>Alta Médico</h3>
    <hr />


    <div class="estilo">
     <div class="container" style="margin-top:60px; margin-bottom:60px">
         <div class="row">
                  <div class="col-md-3">
                      <h5 style="margin-top: 40px">Datos</h5>
                      <h5>Personales</h5>
                  </div>
              <div class="col-md-3" style="margin:40px 0px 40px 0px">
                   <label for="txtDNI" class="form-label">DNI</label>
                   <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtDNI"  runat="server" />
                   <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDNI" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese un DNI válido" ControlToValidate="txtDNI" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                  </div>
              </div>
              <div class="col-md-3" style="margin:72px 0px 40px 0px">
                <asp:Button Text="BUSCAR" Font-Bold="true" Font-Size="Small" ID="btnBuscar" CausesValidation="false" OnClick="btnBuscar_Click" CssClass="btn btn-primary rounded-pill" runat="server" />
              </div>
          </div>
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px"">
            <label for="txtApellido" class="form-label">APELLIDO</label>
            <asp:TextBox  class="form-control rounded-pill" ID="txtApellido"  runat="server" />
              <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtApellido" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="REV1" ErrorMessage="*Ingrese un apellido válido" ControlToValidate="txtApellido" Runat="server" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
             </div>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtNombre" class="form-label">NOMBRE</label>
            <asp:TextBox  class="form-control rounded-pill" ID="txtNombre"  runat="server" />
            <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtNombre" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ErrorMessage="*Ingrese un nombre válido" ControlToValidate="txtNombre" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
           </div>
          </div>
        </div>
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtMatricula" class="form-label">MATRÍCULA</label>
              <asp:TextBox runat="server" ID="txtMatricula" class="form-control rounded-pill" />
              <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtMatricula" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese una matrícula válido" ControlToValidate="txtMatricula" Runat="server" Display="Dynamic" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                  </div>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
             <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
             <asp:TextBox  TextMode="Date" class="form-control rounded-pill" ID="txtFechaNac" runat="server" />
              <div style="font-size:13px">
                         <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                          <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="*Ingrese una fecha válida" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RangeValidator>
                    </div>
          </div>
         </div>
        
        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtTelefono" class="form-label">TELÉFONO</label>
            <asp:TextBox MaxLength="10" class="form-control rounded-pill" ID="txtTelefono" runat="server" />
            <div style="font-size:13px">
               <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtTelefono" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ErrorMessage="*Ingrese un número válido" ControlToValidate="txtTelefono" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </div>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
                <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                 <asp:TextBox class="form-control rounded-pill" ID="txtDireccion" runat="server" />
                 <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDireccion" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
          </div>
         </div>
        
        <div class="row justify-content-center">
          <div class="col-md-6" style="margin-bottom: 40px">
            <label for="txtEmail" class="form-label">EMAIL</label>
            <asp:TextBox type="email" class="form-control rounded-pill" ID="txtEmail" runat="server" />
            <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtEmail" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
          </div>
         </div>
        

        </div>
          
    <div class="estilo">
        <div class="row">
            <div class="col-md-3">
                <h5 style="margin-top: 40px">Usuario</h5>
            </div>
        
           <div class="col-md-3" style="margin:40px 0px 70px 0px">
              <label for="txtNombreUsuario" class="form-label">USUARIO</label>
              <asp:TextBox MaxLength="15" class="form-control rounded-pill" ClientIDMode="Static" ID="txtNombreUsuario" runat="server" />
               <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtNombreUsuario" FilterMode="InvalidChars" InvalidChars=" @/()\?¿+*´;,.-}{][°|¡!=&%$#´'" runat="server" />
               <div style="font-size:13px">
                  <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtNombreUsuario" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
              </div>
           </div>
   
           <div class="col-md-3" style="margin:40px 0px 70px 0px">
             <label for="txtContraseña" class="form-label">CONTRASEÑA</label>
             <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" type="Password" ID="txtContraseña" runat="server" />
               <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtContraseña" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
           </div>
         </div>              
       
    </div>
           

    <hr />
    <div class="d-flex justify-content-end">
         <div class="row" style="margin-bottom: 40px; margin-top:20px">
               <div class="col">
                     <asp:Button class="btn btn-outline-secondary rounded-pill" Text="CANCELAR" Font-Size="Small" BorderColor="White" OnClick="Cancelar_Click" CausesValidation="false" Font-Bold="true" runat="server" />
               </div>
               <div class="col"  >
                     <asp:Button class="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="Click_Aceptar" runat="server" />
               </div>
        </div>
    </div>



</div>


        <!-- Modal para revisar si agrego bien -->
    <asp:Button  style="display:none" runat="server" ID="btnModal" />
   <ajaxToolkit:ModalPopupExtender ID="verificacion_Modal" CancelControlID="exitCheck" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="verificacion_Modal" TargetControlID="btnModal" PopupControlID="PanelCheck">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelCheck" Width="300px" BackColor="White" runat="server">
        <div class="modal-header">
          
            <asp:Label ID="lblTituloAlertModal" Text="" class="modal-title;" Font-Bold="true" Font-Size="X-Large" runat="server" />
          <button id="exitCheck" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <div class="row">
                      <div class="col">
                          <asp:Label id="lblVerificacion"  runat="server" />
                      </div>
                  </div>

              </ContentTemplate>
       </asp:UpdatePanel>
            
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnCerrarModal" Text="CERRAR" OnClick="btnCerrarModal_Click" CausesValidation="false" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>



</asp:Content>
