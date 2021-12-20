 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="WebApplication1.Formulario_web112" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <br />
    <h3>Agregar Paciente</h3>
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


        <!-- Modal para revisar si agrego bien -->
    <asp:Button  style="display:none" runat="server" ID="btnAceptarAgregar" />
   <ajaxToolkit:ModalPopupExtender ID="btnRevisaSiAgrega_Modal" CancelControlID="exitCheck" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnRevisaSiAgrega_Modal" TargetControlID="btnAceptarAgregar" PopupControlID="PanelCheck">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelCheck" Width="300px" BackColor="White" runat="server">
        <div class="modal-header">
          
            <asp:Label ID="lblTituloAlertModal" Text="" class="modal-title;" Font-Bold="true" Font-Size="X-Large" runat="server" />
          <button id="exitCheck" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body" style="margin:30px 0px 30px 0px">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <div class="row">
                      <div class="col">
                          <asp:Label ID="lblTituloNombrePaciente" Text="NOMBRE DE PACIENTE: " Font-Bold="true" Font-Size="Small" runat="server" />
                          <asp:Label id="lblPacienteDNI"  runat="server" />
                      </div>
                  </div>
                  <div class="row">
                      <div class="col">
                            <asp:Label ID="lblPacienteConfirmDNI" runat="server"/> 
                      </div>
                  </div>
              </ContentTemplate>
       </asp:UpdatePanel>
            
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnCerrarModalAgregarPaciente" Text="CERRAR" OnClick="btnCerrarModalAgregarPaciente_Click" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>


</asp:Content>
