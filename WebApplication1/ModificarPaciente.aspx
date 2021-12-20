<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h3>Modificar Paciente</h3>
    <hr />


    <div class="estilo">
     <div class="container" style="margin-top:60px; margin-bottom:60px">
          <div class="row justify-content-center">
          <div class="col-md-3" style="margin:0px 330px 40px 0px">
               <label for="txtDNI" class="form-label">DNI</label>
               <asp:TextBox class="form-control rounded-pill" ID="txtDNI"  runat="server" />
                <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDNI" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese un DNI válido" ControlToValidate="txtDNI" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                     <asp:CustomValidator ID="CustomValidatorDNI" OnServerValidate="CustomValidatorDNI_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*El DNI ingresado ya existe" ControlToValidate="txtDNI" Display="Dynamic"></asp:CustomValidator>
                </div>
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
            <label for="ddlistCobertura" class="form-label">TIPO DE EMPLEADO</label>
            <asp:DropDownList ID="ddlistCobertura" class="form-select rounded-pill" runat="server"></asp:DropDownList>
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
         <div class="row justify-content-end" style="margin-bottom: 40px; margin-top:20px">
             <div class="col-md-1" style="margin-right:10px">
               <asp:Button class="btn btn-outline-secondary rounded-pill" Text="CANCELAR" Font-Size="Small" BorderColor="White" Font-Bold="true" OnClick="Cancelar_Click" runat="server" CausesValidation="False"/>
            </div>
        
              <div class="col-md-1" style="margin-right:10px">
                      <asp:Button class="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="Click_Aceptar" runat="server" />
                </div>
         </div>


</div>


 <!-- modal verificación eliminar paciente -->
 <asp:Button  style="display:none" runat="server" ID="btnVerificacion" />
<ajaxToolkit:ModalPopupExtender ID="verificacion_Modal" CancelControlID="exitV" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="verificacion_Modal" TargetControlID="btnVerificacion" PopupControlID="PanelVerificacion">
 </ajaxToolkit:ModalPopupExtender>


 <asp:Panel ID="PanelVerificacion" BackColor="White" runat="server">
     <asp:UpdatePanel runat="server">
         <ContentTemplate>
                  <div class="modal-header">
                      <asp:Label ID="lblTituloAlertModal" Text="Modificar Paciente" class="modal-title" Font-Bold="true" Font-Size="X-Large" runat="server" />
                    <button id="exitV" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                      <asp:Label ID="lblVerificacion" runat="server" />
                    
                  </div>
             </ContentTemplate>
     </asp:UpdatePanel>
     <div class="modal-footer">
             <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" ID="btnCerrar" Font-Bold="true" OnClick="btnCerrar_Click" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
     </div>
 </asp:Panel>

</asp:Content>
