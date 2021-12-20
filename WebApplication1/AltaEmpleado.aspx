<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEmpleado.aspx.cs" Inherits="WebApplication1.AltaEmpleado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <br />
     <h3>Alta Empleado</h3>
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
        
         <asp:UpdatePanel runat="server">
             <ContentTemplate>
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px"">
            <label for="txtApellido" class="form-label">APELLIDO</label>
            <asp:TextBox  class="form-control rounded-pill" ClientIDMode="Static" ID="txtApellido"  runat="server" AutoPostBack="True" />
              <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtApellido" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="REV1" ErrorMessage="*Ingrese un apellido válido" ControlToValidate="txtApellido" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
             </div>
          </div>

           <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtNombre" class="form-label">NOMBRE</label>
            <asp:TextBox  class="form-control rounded-pill" ClientIDMode="Static" ID="txtNombre"  runat="server" AutoPostBack="True" />
               <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtNombre" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ErrorMessage="*Ingrese un nombre válido" ControlToValidate="txtNombre" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="^[a-zA-Z ]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
              </div>
          </div>
        </div>
        

        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="ddlistTipoEmpleado" class="form-label">TIPO DE EMPLEADO</label>
            <asp:DropDownList ID="ddlistTipoEmpleado" class="form-select rounded-pill" runat="server"></asp:DropDownList>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtFechaNac" class="form-label">FECHA DE NACIMIENTO</label>
            <asp:TextBox TextMode="Date" class="form-control rounded-pill" ClientIDMode="Static" ID="txtFechaNac" runat="server" AutoPostBack="True" />
              <div style="font-size:13px">
                  <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                  <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="*Ingrese una fecha válida" ControlToValidate="txtFechaNac" ForeColor="#CC0000" Display="Dynamic"></asp:RangeValidator>
               </div>
          </div>
         </div>

        
        <div class="row justify-content-center">
          <div class="col-md-3" style="margin-bottom: 40px">
            <label for="txtTelefono" class="form-label">TELÉFONO</label>
            <asp:TextBox type="tel" MaxLength="10" class="form-control rounded-pill" ClientIDMode="Static" ID="txtTelefono" runat="server" AutoPostBack="True" />
              <div style="font-size:13px">
                 <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtTelefono" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ErrorMessage="*Ingrese un número válido" ControlToValidate="txtTelefono" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
              </div>
          </div>
            <div class="col-md-3" style="margin-bottom: 40px">
                 <label for="txtDireccion" class="form-label">DIRECCIÓN</label>
                 <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtDireccion" runat="server" AutoPostBack="True" />
                <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDireccion" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
          </div>
         </div>
        
        <div class="row justify-content-center">
          <div class="col-md-6" style="margin-bottom: 40px">
            <label for="txtEmail" class="form-label">EMAIL</label>
            <asp:TextBox type="email" class="form-control rounded-pill" ClientIDMode="Static" ID="txtEmail" runat="server" AutoPostBack="True" />
             <div style="font-size:13px">
                  <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtEmail" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
          </div>
         </div>
        
                 </ContentTemplate>
         </asp:UpdatePanel>

        </div>
 
</div>

<br />
    <hr />

   
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
                  <asp:CustomValidator ID="CustomValidator1" OnServerValidate="CustomValidator1_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El nombre de usuario ingresado ya existe" ControlToValidate="txtNombreUsuario" Display="Dynamic"></asp:CustomValidator>
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
                <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" CausesValidation="false" OnClick="btnCerrarModal_Click" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>


</asp:Content>
