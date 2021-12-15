﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="WebApplication1.Formulario_web115" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Coberturas</h1>
    <hr />
    
     <div class="container">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <div>
            <asp:GridView CssClass="table table-hover" ID="Grilla" AutoPostback="true" runat="server" AutoGenerateColumns="False" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
                <Columns>
                    <asp:BoundField datafield = "ID" HeaderText ="ID" />            
                    <asp:BoundField datafield = "Nombre" HeaderText ="COBERTURA" />  
                    <asp:BoundField datafield = "Estado" HeaderText ="ESTADO" />                                
                    <asp:CommandField ButtonType="Image" ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                    <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                </Columns>
            </asp:gridview>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- modal agregar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnAgregarCoberturaModal" />
    
   <ajaxToolkit:ModalPopupExtender ID="btnAgregarCobertura_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnAgregarCobertura_Modal" TargetControlID="btnAgregarCoberturaModal" PopupControlID="PanelAgregarCobertura">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelAgregarCobertura" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Agregar Cobertura</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label for="txtCobertura" class="form-label">Cobertura</label>
            <asp:TextBox class="form-control rounded-pill" ID="txtCobertura"  runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" runat="server" />
        </div>
    </asp:Panel>


    <!-- modal editar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnEditarCobertura" />
    
   <ajaxToolkit:ModalPopupExtender ID="editarCobertura_Modal" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="editarCobertura_Modal" TargetControlID="btnEditarCobertura" PopupControlID="PanelEditarCobertura">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelEditarCobertura" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Editar Cobertura</h5>
          <button id="exitEditar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="COBERTURA" CssClass="form-label" Font-Bold="true" Font-Size="Small" runat="server" />
            <asp:TextBox ID="txtEditarCobertura" CssClass="form-control rounded-pill"  runat="server" />
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEditar" Text="Aceptar" OnClick="btnAceptarEditar_Click" runat="server" />
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
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminar" Text="Aceptar" OnClick="btnAceptarEliminar_Click" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
