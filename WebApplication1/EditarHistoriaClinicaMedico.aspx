<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHistoriaClinicaMedico.aspx.cs" Inherits="WebApplication1.Formulario_web18" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <style>
        td{
              font-weight: bold;
              font-size: 12px;
        }
    </style>


    <h3 style="margin-top:40px">Historia Clínica - <asp:Label Text="" ID="txtNombrePaciente" runat="server" /></h3>
    <br />
  
        <div>
        <table class="table">
             <tr>
                <td>FECHA</td> <td>DESCRIPCIÓN</td> 
            </tr>
            <tr>
                <td>
                    <asp:Label Text="" ID="lblFecha" runat="server" /> </td>
                <td><asp:TextBox CssClass="form-control" TextMode="MultiLine" runat="server" ID="txtDescripcion" Height="78px" Width="1180px" /></td>  
            </tr>
        </table>
            <div style="font-size:13px">
                     <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDescripcion" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
        </div>
        <div class="d-flex justify-content-end"><asp:Button Text="ACEPTAR" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" runat="server" /></div>


            <!-- modal -->
        <asp:Button  style="display:none" runat="server" ID="btnModificarHistoriaClinicaF" />
   <ajaxToolkit:ModalPopupExtender ID="btnEditarHistoriaClinica_Modal" CancelControlID="exitCheck" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEditarHistoriaClinica_Modal" TargetControlID="btnModificarHistoriaClinicaF" PopupControlID="PanelCheck">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelCheck" Width="300px" BackColor="White" runat="server">
        <div class="modal-header">
            
            <asp:Label ID="lblTituloModificarHistoriaClinica" Text="" class="modal-title;" Font-Bold="true" Font-Size="X-Large" runat="server" />
          
            <button id="exitCheck" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <div class="modal-body">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <div class="row">
                      <div class="col">
                          <asp:Label ID="lblHistoriaClinicaContext" runat="server" />
                      </div>
                  </div>

              </ContentTemplate>
       </asp:UpdatePanel>
        </div>

        <div class="modal-footer">
            <asp:Button ID="btnCerrarModalModificarHistoriaClinica" Text="CERRAR" OnClick="btnCerrarModalModificarHistoriaClinica_Click" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>



</asp:Content>
