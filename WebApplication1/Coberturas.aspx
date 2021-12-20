<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="WebApplication1.Formulario_web115" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <br />
    <h1>Coberturas</h1>
    <hr />
     <asp:UpdatePanel runat="server">
        <ContentTemplate>
      <div class="container" style="margin:20px 0px 20px 0px">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostBack="true" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
            <div class="col " style="margin-right: 600px">
                  <asp:Button Text="Dar de alta" CssClass="btn btn-primary rounded-pill" ID="btnDarDeAlta" OnClick="btnDarDeAlta_Click" Font-Bold="true" runat="server" />
            </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>
    </div>

         <asp:Label id="resultados" Text="No se encontraron resultados." Visible ="false" runat="server" />

   
             <div>
            <asp:GridView CssClass="table table-hover" ID="Grilla" AutoPostback="true" runat="server" AutoGenerateColumns="False" OnRowDeleting="Grilla_eliminar" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
                <Columns>
                    <asp:BoundField datafield = "ID" HeaderText ="ID" />            
                    <asp:BoundField datafield = "Nombre" HeaderText ="COBERTURA" />  
                    <asp:BoundField datafield = "Estado" HeaderText ="ESTADO" />                                
                    <asp:CommandField ButtonType="Image" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" SelectImageUrl="Iconos/pencil-square.svg" />   
                    <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                </Columns>
            </asp:gridview>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>


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

    <!-- modal agregar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnAgregarCoberturaModal" />
    
   <ajaxToolkit:ModalPopupExtender ID="btnAgregarCobertura_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnAgregarCobertura_Modal" TargetControlID="btnAgregarCoberturaModal" PopupControlID="PanelAgregarCobertura">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelAgregarCobertura" Width="400px" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Agregar Cobertura</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div class="modal-body" style="margin:25px 15px 35px 15px">
                        <div class="row"><asp:Label Text="COBERTURA" class="form-label" Font-Size="Small" Font-Bold="true" runat="server" /></div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox class="form-control rounded-pill" AutoPostBack="true" ID="txtCobertura"  runat="server" />
                                     <div style="font-size: 13px">
                                          <asp:Label id="errorAgregar" Visible="false" runat="server" ForeColor="#CC0000" />
                                     </div>                  
                                </div>
                        </div>
                        
                    </div>
                </ContentTemplate>
        </asp:UpdatePanel>
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" Font-Size="Small" Font-Bold="true" BorderStyle="None" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptar" Font-Size="Small" Font-Bold="true" Text="ACEPTAR" OnClick="btnAceptar_Click" runat="server" />
        </div>
    </asp:Panel>


    <!-- modal editar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnEditarCobertura" />
    
   <ajaxToolkit:ModalPopupExtender ID="editarCobertura_Modal" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="editarCobertura_Modal" TargetControlID="btnEditarCobertura" PopupControlID="PanelEditarCobertura">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelEditarCobertura" Width="400px" BackColor="White" runat="server">
       
                <div class="modal-header">
                  <h5 class="modal-title" >Editar Cobertura</h5>
                     <button id="exitEditar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="margin:25px 15px 35px 15px">
                    <div class="row"> <asp:Label Text="COBERTURA" CssClass="form-label" Font-Bold="true" Font-Size="Small" runat="server" /></div>
                 <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtEditarCobertura" CssClass="form-control rounded-pill"  runat="server" />
                                <div style="font-size: 13px">
                                          <asp:Label id="errorEditar" Visible="false" runat="server" ForeColor="#CC0000" />
                                 </div> 
                            </div>
                        </div>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </div>
        
        
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" Font-Size="Small" Font-Bold="true" BorderStyle="None" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEditar" Font-Size="Small" Font-Bold="true" BorderStyle="None" Text="ACEPTAR" OnClick="btnAceptarEditar_Click" runat="server" />
        </div>
    </asp:Panel>


       <!-- modal eliminar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnEliminarCoberturaModal" />
    
   <ajaxToolkit:ModalPopupExtender ID="eliminarCobertura_Modal" CancelControlID="exitEliminar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="eliminarCobertura_Modal" TargetControlID="btnEliminarCoberturaModal" PopupControlID="PanelEliminarCobertura">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelEliminarCobertura" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar Cobertura</h5>
          <button id="exitEliminar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="¿Está seguro que desea eliminar la cobertura?" runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminar" Text="ACEPTAR" Font-Bold="true" Font-Size="Small" OnClick="btnAceptarEliminar_Click" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
