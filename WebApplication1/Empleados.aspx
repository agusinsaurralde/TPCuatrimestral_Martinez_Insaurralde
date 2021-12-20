<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="WebApplication1.Empleados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Empleados</h1>
    <hr />

   <div class="container">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostBack="true" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>
    </div>
    <asp:Label id="resultados" Text="No se encontraron resultados." Visible="false" runat="server" />
    <div>
          <asp:UpdatePanel runat="server">
            <ContentTemplate>
              <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" AutoPostback="true" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small">
                  <Columns>
                      <asp:BoundField datafield = "DNI" HeaderText ="DNI" />
                      <asp:BoundField datafield = "NombreCompleto" HeaderText ="NOMBRE" />
                      <asp:BoundField datafield = "Telefono" HeaderText ="TELÉFONO" />
                      <asp:BoundField datafield = "Email" HeaderText ="EMAIL" />
                      <asp:BoundField datafield = "Dirección" HeaderText ="DIRECCIÓN" />
                      <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}"  HeaderText ="FECHA DE NACIMIENTO" />
                      <asp:BoundField datafield = "TipoEmp.Nombre" HeaderText ="TIPO"/>
                      <asp:BoundField datafield = "Estado" HeaderText ="ESTADO"/>
                      <asp:CommandField ButtonType="Button"  ShowSelectButton="True" SelectText="USUARIO" ControlStyle-Font-Bold="true" ControlStyle-Font-Size="Small" ControlStyle-CssClass="btn btn-primary rounded-pill"/>  
                      <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                      <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                  </Columns>
              </asp:gridview>
                </ContentTemplate>
        </asp:UpdatePanel>
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
                <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>




<!-- modal eliminar-->
   <asp:Button  style="display:none" runat="server" ID="btnEliminar" />
   <ajaxToolkit:ModalPopupExtender ID="btnEliminar_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminar_Modal" TargetControlID="btnEliminar" PopupControlID="Panel">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="Panel" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar el empleado?</label>
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptar" Text="ACEPTAR" Font-Size="Small" Font-Bold="true" OnClick="btnAceptar_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>


<!-- modal usuario-->
   <asp:Button  style="display:none" runat="server" ID="btnUsuario" />
   <ajaxToolkit:ModalPopupExtender ID="btnUsuario_Modal" CancelControlID="exitUsuario" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnUsuario_Modal" TargetControlID="btnUsuario" PopupControlID="PanelUsuario">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelUsuario" Width="300px" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Usuario</h5>
          <button id="exitUsuario" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body" style="margin:30px 0px 30px 0px">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                  <div class="row">
                      <div class="col">
                          <asp:Label Text="NOMBRE DE USUARIO: " Font-Bold="true" Font-Size="Small" runat="server" />
                          <asp:Label id="lblUsuario" runat="server" />
                      </div>
                  </div>
                  <div class="row">
                      <div class="col">
                            <asp:Label Text="CONTRASEÑA: " Font-Bold="true" Font-Size="Small" runat="server" />
                            <asp:Label id="lblContraseña" runat="server" />
                      </div>
                  </div>
              </ContentTemplate>
       </asp:UpdatePanel>
            
        </div>
        <div class="modal-footer">
            <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Size="Small" Font-Bold="true" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>

</asp:Content>
