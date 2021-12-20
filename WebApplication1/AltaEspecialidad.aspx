<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEspecialidad.aspx.cs" Inherits="WebApplication1.AltaEspecialidad" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3  >Alta de cobertura</h3>
    <hr />
    <div class="row  justify-content-center" style="margin-top:70px; margin-bottom:50px; margin-left:150px">
        <div class="col-md-3" >
            <asp:Label Text="ID" Font-Bold="true" runat="server" />
            <asp:TextBox ID="txtEspecialidad" CssClass="form-control rounded-pill" runat="server" />
            <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtEspecialidad" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ErrorMessage="*Ingrese un ID válido" ControlToValidate="txtEspecialidad" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>  
                     <asp:Label id="lblCobertura" ForeColor="#CC0000"  runat="server" />            
            </div>
        </div>
        <div class="col-md-3" style="margin-top:25px">
            <asp:Button Text="BUSCAR" CssClass="btn btn-primary rounded-pill" OnClick="btnBuscar_Click" Font-Bold="true" Font-Size="Small" runat="server" />
        </div>
        
    </div>
    <div class="row justify-content-md-end">
        <div class="col-md-4" style="margin-top:20px">
            <asp:Button Text="ACEPTAR" CssClass="btn btn-primary rounded-pill" CausesValidation="true" ID="btnAceptar" OnClick="btnAceptar_Click" Font-Bold="true" Font-Size="Small" runat="server" />
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
                <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" ID="btnCerrar" OnClick="btnCerrar_Click" CausesValidation="false" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>

</asp:Content>

